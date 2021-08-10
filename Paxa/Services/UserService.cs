using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Paxa.Contexts;
using Paxa.Entities;
using Paxa.Helpers;
using Paxa.Authorization;

namespace Paxa.Services
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<ICollection<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Update(int id, User user);
        void Delete(int id);

        // Authentication
        Task<Views.AuthenticateResponse> Authenticate(Views.AuthenticateRequest request, string ipAddress);
        Task<Views.AuthenticateResponse> RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
    }

    public class UserService : IUserService
    {
        private readonly PaxaContext _context;
        private readonly AppSettings _appSettings;
        private readonly IJwtUtils _jwtUtils;

        public UserService(
            PaxaContext context,
            IOptions<AppSettings> appSettings,
            IJwtUtils jwtUtils)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _jwtUtils = jwtUtils;
        }

        private async Task<User> getUserByRefreshToken(string token)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(user => user.RefreshTokens
                    .Any(refreshToken => refreshToken.Token == token));

            if (user == null)
            {
                throw new AppException("Invalid token");
            }
            return user;
        }

        private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }

        private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private void removeOldRefreshTokens(User user)
        {
            // Remove old inactive refresh tokens from user based on TTL in app settings
            user.RefreshTokens.RemoveAll(x => 
                !x.IsActive && 
                x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }

        private void revokeDescendantRefreshTokens(
            RefreshToken refreshToken,
            User user,
            string ipAddress,
            string reason)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                {
                    revokeRefreshToken(childToken, ipAddress, reason);
                    return;
                }
                revokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
            }
        }

        public async Task<User> Create(User user)
        {
            await _context.Users
                .AddAsync(user);
            await _context.SaveChangesAsync();

            // Get entity
            var createdUser = await GetById(user.Id);
            return createdUser;
        }

        public async Task<ICollection<User>> GetAll()
        {
            var users = await _context.Users
                .Include(e => e.Organization).ThenInclude(e => e.Location)
                .Include(e => e.Person)
                .Include(e => e.Person).ThenInclude(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Person).ThenInclude(e => e.Followers)
                .Include(e => e.Person).ThenInclude(e => e.Following)
                .ToListAsync();

            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Users
                .Include(e => e.Organization).ThenInclude(e => e.Location)
                .Include(e => e.Person).ThenInclude(e => e.Bookings)
                .Include(e => e.Person).ThenInclude(e => e.Followers)
                .Include(e => e.Person).ThenInclude(e => e.Following)
                .Include(e => e.Person).ThenInclude(e => e.Ratings).ThenInclude(e => e.Type)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            return user;
        }

        public async Task<User> Update(int id, User user)
        {
            // Get from db
            var updatingUser = await _context.Users
                .Include(e => e.Organization).ThenInclude(e => e.Location)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            // Make updates
            updatingUser.Email = user.Email;

            // Persist changes
            await _context.SaveChangesAsync();

            // Get updated from db
            var updatedUser = await GetById(id);
            return updatedUser;
        }

        public async void Delete(int id)
        {
            var user = new User { Id = id };
            _context.Users.Attach(user);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<Views.AuthenticateResponse> Authenticate(Views.AuthenticateRequest request, string ipAddress)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == request.Email);

            // Validate
            if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
            {
                throw new AppException("Username or password is incorrect");
            }

            // Authentication successful so generate jwt and refresh tokens
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            user.RefreshTokens.Add(refreshToken);

            // Remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // Save changes to db
            _context.Update(user);
            _context.SaveChanges();

            return new Views.AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public async Task<Views.AuthenticateResponse> RefreshToken(string token, string ipAddress)
        {
            var user = await getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                // Revoke all descendant tokens in case this token has been compromised
                revokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                _context.Update(user);
                _context.SaveChanges();
            }

            if (!refreshToken.IsActive)
            {
                throw new AppException("Invalid token");
            }

            // Replace old refresh token with a new one (rotate token)
            var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress);
            user.RefreshTokens.Add(newRefreshToken);

            // Remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // Save changes to db
            _context.Update(user);
            _context.SaveChanges();

            // Generate new jwt-token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new Views.AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }

        public async void RevokeToken(string token, string ipAddress)
        {
            var user = await getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.IsActive)
            {
                throw new AppException("Invalid token");
            }

            // revoke token and save
            revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Paxa.Contexts;

namespace Paxa.Services
{
    public interface IUserService
    {
        Task<Views.User> Create(Views.User user);
        Task<ICollection<Views.User>> GetAll();
        Task<Views.User> GetById(int id);
        Task<Views.User> Update(int id, Views.User user);
        Task<Views.Confirmation> Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly PaxaContext _Context;
        private readonly IMapper _Mapper;

        public UserService(PaxaContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }

        public async Task<Views.User> Create(Views.User user)
        {
            // Create entity
            var entity = _Mapper.Map<Entities.User>(user);
            await _Context.User
                .AddAsync(entity);
            await _Context.SaveChangesAsync();

            // Get entity
            var persistedEntity = await GetById(entity.Id);
            var view = _Mapper.Map<Views.User>(persistedEntity);

            return view;
        }

        public async Task<ICollection<Views.User>> GetAll()
        {
            var entities = await _Context.User
                .Include(e => e.Organization).ThenInclude(e => e.Location)
                .Include(e => e.Person)
                .Include(e => e.Person).ThenInclude(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Person).ThenInclude(e => e.Followers)
                .Include(e => e.Person).ThenInclude(e => e.Following)
                .ToListAsync();

            var view = _Mapper.Map<Views.User[]>(entities);

            return view;
        }

        public async Task<Views.User> GetById(int id)
        {
            var entity = await _Context.User
                .Include(e => e.Organization).ThenInclude(e => e.Location)
                .Include(e => e.Person).ThenInclude(e => e.Bookings)
                .Include(e => e.Person).ThenInclude(e => e.Followers)
                .Include(e => e.Person).ThenInclude(e => e.Following)
                .Include(e => e.Person).ThenInclude(e => e.Ratings).ThenInclude(e => e.Type)
                .Include(e => e.Bookings)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            var view = _Mapper.Map<Views.User>(entity);

            return view;
        }

        public async Task<Views.User> Update(int id, Views.User user)
        {
            // Get from db
            var entity = await _Context.User
                .Include(e => e.Organization).ThenInclude(e => e.Location)
                .SingleOrDefaultAsync(e => e.Id.Equals(id));

            // Make updates
            entity.Email = user.Email;

            // Persist changes
            await _Context.SaveChangesAsync();

            // Get updated from db
            var view = await GetById(id);

            return view;
        }

        public async Task<Views.Confirmation> Delete(int id)
        {
            var user = new Entities.User { Id = id };
            _Context.User.Attach(user);
            _Context.User.Remove(user);
            await _Context.SaveChangesAsync();

            var view = new Views.Confirmation();
            return view;
        }
    }
}

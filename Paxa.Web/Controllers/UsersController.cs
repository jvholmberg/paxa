using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paxa.Authorization;
using Paxa.Services;
using Paxa.Views;

namespace Paxa.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService,
            IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        #region Util

        private void setTokenCookie(string token)
        {
            // Append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            // Get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }

        #endregion
        
        #region Authentication

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var (user, jwtToken, refreshToken) = await _userService.Authenticate(request, ipAddress());

            var view = _mapper.Map<Views.AuthenticateResponse>(user);
            view.JwtToken = jwtToken;

            setTokenCookie(refreshToken);

            return Ok(view);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var (user, jwtToken, newRefreshToken) = await _userService.RefreshToken(refreshToken, ipAddress());

            var view = _mapper.Map<Views.AuthenticateResponse>(user);
            view.JwtToken = jwtToken;

            setTokenCookie(newRefreshToken);

            return Ok(view);
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken(RevokeTokenRequest request)
        {
            // accept refresh token in request body or cookie
            var token = request.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new { message = "Token is required" });
            }

            var wasRevoked = await _userService.RevokeToken(token, ipAddress());
            if (wasRevoked)
            {
                return Ok(new { message = "Token revoked" });
            }
            return BadRequest(new { message = "Token was not revoked" });
        }

        [HttpGet("{id}/refresh-tokens")]
        public async Task<IActionResult> GetRefreshTokens(int id)
        {
            var userEntity = await _userService.GetById(id);
            var view = _mapper.Map<RefreshToken[]>(userEntity.RefreshTokens);
            return Ok(view);
        }

        #endregion

        #region CRUD

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            var entity = _mapper.Map<Entities.User>(user);
            entity = await _userService.Create(entity);

            var view = _mapper.Map<User>(user);
            return Ok(view);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _userService.GetAll();

            var views = _mapper.Map<User[]>(entities);
            return Ok(views);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _userService.GetById(id);

            var view = _mapper.Map<User[]>(entity);
            return Ok(view);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            var entity = _mapper.Map<Entities.User>(user);
            entity = await _userService.Update(id, entity);

            var view = _mapper.Map<User>(user);
            return Ok(view);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var wasRemoved = await _userService.Delete(id);
            if (wasRemoved)
            {
                return Ok(new { message = "Was removed successfully" });
            }
            return BadRequest(new { message = "Could not be removed" });
        }
    
        #endregion

    }
}

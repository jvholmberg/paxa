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
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(
            ILogger<UserController> logger,
            UserService userService,
            IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

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
            if (Request.Headers.ContainsKey("X-Forwarded-For")) {
                return Request.Headers["X-Forwarded-For"];
            }
            else {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(Views.AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _userService.RefreshToken(refreshToken, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [HttpPost("revoke-token")]
        public IActionResult RevokeToken(RevokeTokenRequest model)
        {
            // accept refresh token in request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token)) {
                return BadRequest(new { message = "Token is required" });
            }

            _userService.RevokeToken(token, ipAddress());
            return Ok(new { message = "Token revoked" });
        }

        [HttpGet("{id}/refresh-tokens")]
        public async Task<IActionResult> GetRefreshTokens(int id)
        {
            var entity = await _userService.GetById(id);

            var view = _mapper.Map<RefreshToken[]>(entity.RefreshTokens);
            return Ok(view);
        }

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
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}

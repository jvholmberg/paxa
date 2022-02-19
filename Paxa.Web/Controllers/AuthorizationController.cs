using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paxa.Web.Authorization;
using Paxa.Common.Authorization;
using Paxa.Common.Views;
using Paxa.Data.Services;

namespace Paxa.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/authorization")]
    public class AuthorizationController : ControllerBase
    {

        private readonly ILogger<AuthorizationController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthorizationController(
            ILogger<AuthorizationController> logger,
            IUserService userService,
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
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }

        [AllowAnonymous]
        [HttpPost("get-token")]
        public async Task<IActionResult> GetToken(AuthenticateRequest request)
        {
            var (user, jwtToken, refreshToken) = await _userService.Authenticate(request, ipAddress());

            var view = _mapper.Map<AuthenticateResponse>(user);
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

            var view = _mapper.Map<AuthenticateResponse>(user);
            view.JwtToken = jwtToken;

            setTokenCookie(newRefreshToken);

            return Ok(view);
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken(RevokeTokenRequest request)
        {
            // accept refresh token in request body or cookie
            var token = request.Token != null
                ? request.Token
                : Request.Cookies["refreshToken"];

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
            var view = _mapper.Map<RefreshTokenDto[]>(userEntity.RefreshTokens);
            return Ok(view);
        }

    }
}

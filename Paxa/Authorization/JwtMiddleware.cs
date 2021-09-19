using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Paxa.Helpers;
using Paxa.Services;

namespace Paxa.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public JwtMiddleware(
            RequestDelegate next,
            IOptions<AppSettings> appSettings,
            IMapper mapper)
        {
            _next = next;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // Attach user to context on successful jwt validation
                var userEntity = await userService.GetById(userId.Value);
                var userView = _mapper.Map<Views.User>(userEntity);
                context.Items["User"] = userEntity;
            }

            await _next(context);
        }
    }
}

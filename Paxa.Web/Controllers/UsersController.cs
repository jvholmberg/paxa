using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paxa.Web.Authorization;
using Paxa.Common.Entities;
using Paxa.Common.Views;
using Paxa.Data.Services;

namespace Paxa.Web.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto user)
        {
            var entity = _mapper.Map<User>(user);
            entity = await _userService.Create(entity);

            var view = _mapper.Map<UserDto>(user);
            return Ok(view);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _userService.GetAll();

            var views = _mapper.Map<UserDto[]>(entities);
            return Ok(views);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _userService.GetById(id);

            var view = _mapper.Map<UserDto>(entity);
            return Ok(view);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            var entity = _mapper.Map<User>(user);
            entity = await _userService.Update(id, entity);

            var view = _mapper.Map<UserDto>(user);
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

    }
}

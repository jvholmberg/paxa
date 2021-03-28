using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paxa.Services;

namespace Paxa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly UserService _UserService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _UserService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Views.User user)
        {
            var res = await _UserService.Create(user);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _UserService.GetAll();
            return Ok(res);
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMy()
        {
            var res = await _UserService.GetById(1);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _UserService.GetById(id);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Views.User user)
        {
            var res = await _UserService.Update(id, user);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _UserService.Delete(id);
            return Ok(res);
        }
    }
}

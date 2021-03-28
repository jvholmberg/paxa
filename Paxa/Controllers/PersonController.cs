using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paxa.Services;

namespace Paxa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private readonly PersonService _PersonService;

        public PersonController(ILogger<PersonController> logger, PersonService PersonService)
        {
            _logger = logger;
            _PersonService = PersonService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Views.Person Person)
        {
            var res = await _PersonService.Create(Person);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _PersonService.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _PersonService.GetById(id);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Views.Person Person)
        {
            var res = await _PersonService.Update(id, Person);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _PersonService.Delete(id);
            return Ok(res);
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Paxa.Authorization;
using Paxa.Services;
using Paxa.Common.Views;

namespace Paxa.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/persons")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(
            ILogger<PersonController> logger,
            IPersonService PersonService,
            IMapper mapper)
        {
            _logger = logger;
            _personService = PersonService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonDto person)
        {
            var res = await _personService.Create(person);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _personService.GetAll();
            var views = _mapper.Map<PersonDto[]>(entities);
            return Ok(views);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _personService.GetById(id);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonDto person)
        {
            var res = await _personService.Update(id, person);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _personService.Delete(id);
            return Ok(res);
        }
    }
}

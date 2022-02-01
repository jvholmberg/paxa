using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Paxa.Web.Authorization;
using Paxa.Common.Views;
using Paxa.Common.Entities;
using Paxa.Data.Services;

namespace Paxa.Web.Controllers
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
        public async Task<IActionResult> Create([FromBody] PersonDto view)
        {
            var entity = _mapper.Map<Person>(view);
            var createdEntity = await _personService.Create(entity);
            var createdView = _mapper.Map<PersonDto>(createdEntity);
            return Ok(createdView);
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
            var entity = await _personService.GetById(id);
            var view = _mapper.Map<PersonDto>(entity);
            return Ok(view);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonDto view)
        {
            var entity = _mapper.Map<Person>(view);
            var updatedEntity = await _personService.Update(id, entity);
            var updatedView = _mapper.Map<PersonDto>(updatedEntity);
            return Ok(updatedView);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return Ok();
        }
    }
}

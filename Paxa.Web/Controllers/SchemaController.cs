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
    [Route("api/schemas")]
    public class SchemaController : ControllerBase
    {

        private readonly ILogger<SchemaController> _logger;
        private readonly ISchemaService _schemaService;
        private readonly IMapper _mapper;

        public SchemaController(
            ILogger<SchemaController> logger,
            ISchemaService schemaService,
            IMapper mapper)
        {
            _logger = logger;
            _schemaService = schemaService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SchemaDto view)
        {
            var entity = _mapper.Map<Schema>(view);
            var createdEntity = await _schemaService.Create(entity);
            var createdView = _mapper.Map<SchemaDto>(createdEntity);
            return Ok(createdView);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _schemaService.GetAll();
            var views = _mapper.Map<SchemaDto[]>(entities);
            return Ok(views);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _schemaService.GetById(id);
            var view = _mapper.Map<SchemaDto>(entity);
            return Ok(view);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SchemaDto view)
        {
            var entity = _mapper.Map<Schema>(view);
            var createdEntity = await _schemaService.Update(id, entity);
            var updatedView = _mapper.Map<SchemaDto>(createdEntity);
            return Ok(updatedView);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _schemaService.Delete(id);
            return Ok();
        }



        [HttpPost("execute")]
        public async Task<IActionResult> Execute([FromBody] GenerateTimeslotsDto view)
        {
            var schema = await _schemaService.GetById(view.Id);
            var success = await _schemaService.GenerateTimeslots(schema, view.Year, view.Month, view.Day);
            return Ok();
        }

    }
}

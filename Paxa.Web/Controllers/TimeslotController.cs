using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Paxa.Common.Entities;
using Paxa.Common.Views;
using Paxa.Data.Services;

namespace Paxa.Web.Controllers
{
    [ApiController]
    [Route("api/timeslots")]
    public class TimeslotController : ControllerBase
    {

        private readonly ILogger<TimeslotController> _logger;
        private readonly ITimeslotService _timeslotService;
        private readonly IMapper _mapper;

        public TimeslotController(
            ILogger<TimeslotController> logger,
            ITimeslotService TimeslotService,
            IMapper mapper)
        {
            _logger = logger;
            _timeslotService = TimeslotService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTimeslotRequestDto view)
        {
            var entity = _mapper.Map<Timeslot>(view);
            var createdEntity = await _timeslotService.Create(entity);
            var createdView = _mapper.Map<TimeslotDto>(createdEntity);
            return Ok(createdView);
        }

        [HttpGet]
        public async Task<IActionResult> GetByQuery([FromQuery] int? organizationId)
        {
            var entities = await _timeslotService.GetByQuery(organizationId);
            var views = _mapper.Map<TimeslotDto[]>(entities);
            return Ok(views);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _timeslotService.GetById(id);
            var view = _mapper.Map<TimeslotDto>(entity);
            return Ok(view);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTimeslotRequestDto view)
        {
            var entity = _mapper.Map<Timeslot>(view);
            var updatedEntity = await _timeslotService.Update(id, entity);
            var updatedView = _mapper.Map<TimeslotDto>(updatedEntity);
            return Ok(updatedView);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _timeslotService.Delete(id);
            return Ok();
        }
    }
}

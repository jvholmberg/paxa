using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Paxa.Services;

namespace Paxa.Controllers
{
    [ApiController]
    [Route("api/resources")]
    public class ResourceController : ControllerBase
    {

        private readonly ILogger<ResourceController> _logger;
        private readonly IResourceService _ResourceService;
        private readonly IMapper _mapper;

        public ResourceController(
            ILogger<ResourceController> logger,
            IResourceService ResourceService,
            IMapper mapper)
        {
            _logger = logger;
            _ResourceService = ResourceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetByQuery(
            [FromQuery] int? organizationId)
        {
            var entities = await _ResourceService.GetByQuery(organizationId);
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _ResourceService.GetById(id);
            return Ok(entity);
        }
    }
}

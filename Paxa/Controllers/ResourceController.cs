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
        public async Task<IActionResult> GetAll()
        {
            var entities = await _ResourceService.GetAll();
            return Ok(entities);
        }

        [HttpGet("organization/{id}")]
        public async Task<IActionResult> GetByOrganizationId(int id)
        {
            var entities = await _ResourceService.GetByOrganizationId(id);
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

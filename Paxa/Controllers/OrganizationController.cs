using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Paxa.Services;

namespace Paxa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationController : ControllerBase
    {

        private readonly ILogger<OrganizationController> _logger;
        private readonly OrganizationService _organizationService;

        public OrganizationController(ILogger<OrganizationController> logger, OrganizationService OrganizationService)
        {
            _logger = logger;
            _organizationService = OrganizationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Views.Organization Organization)
        {
            var res = await _organizationService.Create(Organization);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _organizationService.GetAll();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _organizationService.GetById(id);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Views.Organization Organization)
        {
            var res = await _organizationService.Update(id, Organization);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _organizationService.Delete(id);
            return Ok(res);
        }
    }
}

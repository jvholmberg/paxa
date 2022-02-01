using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Paxa.Services;
using Paxa.Common.Entities;
using Paxa.Common.Views;

namespace Paxa.Web.Controllers
{
    [ApiController]
    [Route("api/organizations")]
    public class OrganizationController : ControllerBase
    {

        private readonly ILogger<OrganizationController> _logger;
        private readonly IOrganizationService _organizationService;
        private readonly IMapper _mapper;

        public OrganizationController(
            ILogger<OrganizationController> logger,
            IOrganizationService OrganizationService,
            IMapper mapper)
        {
            _logger = logger;
            _organizationService = OrganizationService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrganizationRequest view)
        {
            var entity = _mapper.Map<Organization>(view);
            var createdEntity = await _organizationService.Create(entity);
            var createdView = _mapper.Map<OrganizationDto>(createdEntity);
            return Ok(createdView);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _organizationService.GetAll();
            var views = _mapper.Map<OrganizationDto[]>(entities);
            return Ok(views);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _organizationService.GetById(id);
            var view = _mapper.Map<OrganizationDto>(entity);
            return Ok(view);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrganizationRequest view)
        {
            var entity = _mapper.Map<Organization>(view);
            var updatedEntity = await _organizationService.Update(id, entity);
            var updatedView = _mapper.Map<OrganizationDto>(updatedEntity);
            return Ok(updatedView);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _organizationService.Delete(id);
            return Ok();
        }
    }
}

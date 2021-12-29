﻿using System.Threading.Tasks;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Views.CreateResourceRequest view)
        {
            var entity = _mapper.Map<Entities.Resource>(view);
            var createdEntity = await _ResourceService.Create(entity);
            var createdView = _mapper.Map<Views.Resource>(createdEntity);
            return Ok(createdView);
        }

        [HttpGet]
        public async Task<IActionResult> GetByQuery([FromQuery] int? organizationId)
        {
            var entities = await _ResourceService.GetByQuery(organizationId);
            var views = _mapper.Map<Views.Resource[]>(entities);
            return Ok(views);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _ResourceService.GetById(id);
            var view = _mapper.Map<Views.Resource>(entity);
            return Ok(view);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            var entities = await _ResourceService.GetTypes();
            var views = _mapper.Map<Views.ResourceType[]>(entities);
            return Ok(views);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Views.UpdateResourceRequest view)
        {
            var entity = _mapper.Map<Entities.Resource>(view);
            var updatedEntity = await _ResourceService.Update(id, entity);
            var updatedView = _mapper.Map<Views.Resource>(updatedEntity);
            return Ok(updatedView);
        }
    }
}

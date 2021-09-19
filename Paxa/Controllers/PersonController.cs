﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Paxa.Authorization;
using Paxa.Services;

namespace Paxa.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private readonly PersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(
            ILogger<PersonController> logger,
            PersonService PersonService,
            IMapper mapper)
        {
            _logger = logger;
            _personService = PersonService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Views.Person Person)
        {
            var res = await _personService.Create(Person);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _personService.GetAll();
            var views = _mapper.Map<Views.Person[]>(entities);
            return Ok(views);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _personService.GetById(id);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Views.Person Person)
        {
            var res = await _personService.Update(id, Person);
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

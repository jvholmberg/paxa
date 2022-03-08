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
    [Route("api/lookups")]
    public class LookupController : ControllerBase
    {

        private readonly ILogger<LookupController> _logger;
        private readonly ILookupService _lookupService;
        private readonly IMapper _mapper;

        public LookupController(
            ILogger<LookupController> logger,
            ILookupService lookupService,
            IMapper mapper)
        {
            _logger = logger;
            _lookupService = lookupService;
            _mapper = mapper;
        }

        [HttpGet("weekdays")]
        public async Task<IActionResult> GetWeekdays()
        {
            var entities = await _lookupService.GetWeekdays();
            var views = _mapper.Map<WeekdayDto[]>(entities);
            return Ok(views);
        }
    }
}

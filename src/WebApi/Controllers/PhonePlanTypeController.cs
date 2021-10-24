using Microsoft.AspNetCore.Mvc;
using JBragon.Business.Interfaces;
using JBragon.Models.Filters;
using JBragon.Models;

namespace JBragon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonePlanTypeController : BaseController
    {
        private readonly IPhonePlanTypeService _phonePlanTypeService;

        public PhonePlanTypeController(IPhonePlanTypeService phonePlanTypeService)
        {
            _phonePlanTypeService = phonePlanTypeService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _phonePlanTypeService.GetById<PhonePlanTypeResponse>(id), 200, true);
        }

        [HttpGet()]
        public IActionResult Get([FromQuery] PhonePlanTypeFilter phonePlanTypeFilter)
        {
            return Execute(() => _phonePlanTypeService.Search<PhonePlanTypeResponse>(phonePlanTypeFilter), 200, true);
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using JBragon.Business.Interfaces;
using JBragon.Models.Mapper.Response;
using JBragon.Models.Filters;
using JBragon.Models.Mapper.Request;

namespace JBragon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonePlanController : BaseController
    {
        private readonly IPhonePlanService _phonePlanService;
        private readonly IMapper _mapper;

        public PhonePlanController(IPhonePlanService phonePlanService, IMapper mapper)
        {
            _phonePlanService = phonePlanService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _phonePlanService.GetById<PhonePlanResponse>(id), 200, true);
        }

        [HttpGet()]
        public IActionResult Get([FromQuery] PhonePlanFilter phonePlanFilter)
        {
            return Execute(() => _phonePlanService.Search<PhonePlanResponse>(phonePlanFilter), 200, true);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PhonePlanPost phonePlanPost)
        {
            return ExecuteCreate(() => _phonePlanService.Create<PhonePlanResponse>(phonePlanPost));
        }

        [HttpPut]
        public IActionResult Put([FromBody] PhonePlanPut entityBasePost)
        {
            return Execute(() => _phonePlanService.Update<PhonePlanResponse>(entityBasePost));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Execute(() => _phonePlanService.Delete(id));
        }

    }
}

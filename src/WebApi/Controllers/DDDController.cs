using Microsoft.AspNetCore.Mvc;
using JBragon.Business.Interfaces;
using JBragon.Models.Filters;
using JBragon.Models;

namespace JBragon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DDDController : BaseController
    {
        private readonly IDDDService _dddService;

        public DDDController(IDDDService dddService)
        {
            _dddService = dddService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _dddService.GetById<DDDResponse>(id), 200, true);
        }

        [HttpGet()]
        public IActionResult Get([FromQuery] DDDFilter dddFilter)
        {
            return Execute(() => _dddService.Search<DDDResponse>(dddFilter), 200, true);
        }

    }
}

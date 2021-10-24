using Microsoft.AspNetCore.Mvc;
using JBragon.Business.Interfaces;
using JBragon.Models.Filters;
using JBragon.Models;

namespace JBragon.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelephoneOperatorController : BaseController
    {
        private readonly ITelephoneOperatorService _telephoneOperatorService;

        public TelephoneOperatorController(ITelephoneOperatorService TelephoneOperatorService)
        {
            _telephoneOperatorService = TelephoneOperatorService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Execute(() => _telephoneOperatorService.GetById<TelephoneOperatorResponse>(id), 200, true);
        }

        [HttpGet()]
        public IActionResult Get([FromQuery] TelephoneOperatorFilter TelephoneOperatorFilter)
        {
            return Execute(() => _telephoneOperatorService.Search<TelephoneOperatorResponse>(TelephoneOperatorFilter), 200, true);
        }

    }
}

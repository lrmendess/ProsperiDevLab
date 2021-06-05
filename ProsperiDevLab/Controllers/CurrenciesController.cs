using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProsperiDevLab.Controllers.Contracts.Response;
using ProsperiDevLab.Services.Interfaces;
using System.Collections.Generic;

namespace ProsperiDevLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IMapper _mapper;

        public CurrenciesController(ICurrencyService currencyService, IMapper mapper)
        {
            _currencyService = currencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CurrencyResponse>> Get()
        {
            var currencies = _currencyService.GetAll();
            var response = _mapper.Map<IEnumerable<CurrencyResponse>>(currencies);

            return Ok(response);
        }
    }
}

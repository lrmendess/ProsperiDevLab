using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProsperiDevLab.Controllers.Contracts.Response;
using ProsperiDevLab.Services.Interfaces;
using System.Collections.Generic;

namespace ProsperiDevLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerResponse>> Get()
        {
            var customers = _customerService.GetAll();
            var response = _mapper.Map<IEnumerable<CustomerResponse>>(customers);

            return Ok(response);
        }
    }
}

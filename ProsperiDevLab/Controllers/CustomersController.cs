using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProsperiDevLab.Controllers.Contracts.Request;
using ProsperiDevLab.Controllers.Contracts.Response;
using ProsperiDevLab.Models;
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

        [HttpPost]
        public ActionResult<CustomerResponse> Post([FromBody] CustomerRequest request)
        {
            var customer = _mapper.Map<Customer>(request);

            _customerService.Create(customer);

            var response = _mapper.Map<CustomerResponse>(customer);

            return Created($"api/Customers/{customer.Id}", response);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] long id)
        {
            _customerService.Remove(id);

            return NoContent();
        }
    }
}

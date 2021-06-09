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

        [HttpGet("{id:long}")]
        public ActionResult<CustomerResponse> Get(long id)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<CustomerResponse>(customer);

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<CustomerResponse> Post([FromBody] CustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = _mapper.Map<Customer>(request);

            _customerService.Create(customer);

            var response = _mapper.Map<CustomerResponse>(customer);

            return Created($"api/Customers/{customer.Id}", response);
        }

        [HttpPut("{id:long}")]
        public ActionResult<CustomerResponse> Put([FromRoute] long id, [FromBody] CustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (request?.Id != id)
            {
                return NotFound();
            }

            var customer = _mapper.Map<Customer>(request);

            _customerService.Update(customer);

            var response = _mapper.Map<CustomerResponse>(customer);

            return Ok(response);
        }

        [HttpDelete("{id:long}")]
        public ActionResult Delete([FromRoute] long id)
        {
            _customerService.Remove(id);

            return NoContent();
        }
    }
}

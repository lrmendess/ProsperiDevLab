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
    public class ServiceOrdersController : ControllerBase
    {
        private readonly IServiceOrderService _serviceOrderService;
        private readonly IMapper _mapper;

        public ServiceOrdersController(IServiceOrderService serviceOrderService, IMapper mapper)
        {
            _serviceOrderService = serviceOrderService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServiceOrderResponse>> Get()
        {
            var serviceOrders = _serviceOrderService.GetAll();
            var response = _mapper.Map<IEnumerable<ServiceOrderResponse>>(serviceOrders);
            
            return Ok(response);
        }

        [HttpGet("{id:long}")]
        public ActionResult<IEnumerable<ServiceOrderResponse>> Get(long id)
        {
            var serviceOrder = _serviceOrderService.Get(id);

            if (serviceOrder == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<ServiceOrderResponse>(serviceOrder);

            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ServiceOrderResponse> Post([FromBody] ServiceOrderRequest request)
        {
            ModelState.Remove("PriceId");
            ModelState.Remove("Price.Id");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceOrder = _mapper.Map<ServiceOrder>(request);

            _serviceOrderService.Create(serviceOrder);

            var response = _mapper.Map<ServiceOrderResponse>(serviceOrder);

            return Created($"api/ServiceOrders/{serviceOrder.Id}", response);
        }

        [HttpPut("{id:long}")]
        public ActionResult<ServiceOrderResponse> Put([FromRoute] long id, [FromBody] ServiceOrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (request?.Id != id)
            {
                return NotFound();
            }

            var serviceOrder = _mapper.Map<ServiceOrder>(request);

            _serviceOrderService.Update(serviceOrder);

            var response = _mapper.Map<ServiceOrderResponse>(serviceOrder);

            return Ok(response);
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete([FromRoute] long id)
        {
            _serviceOrderService.Remove(id);

            return NoContent();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProsperiDevLab.Controllers.Contracts.Request;
using ProsperiDevLab.Controllers.Contracts.Response;
using ProsperiDevLab.Models;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Notificator;
using System.Collections.Generic;

namespace ProsperiDevLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceOrdersController : ControllerBase
    {
        private readonly IServiceOrderService _serviceOrderService;
        private readonly INotificator _notificator;
        private readonly IMapper _mapper;

        public ServiceOrdersController(IServiceOrderService serviceOrderService, INotificator notificator, IMapper mapper)
        {
            _serviceOrderService = serviceOrderService;
            _notificator = notificator;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ServiceOrderResponse>> Get()
        {
            var serviceOrders = _serviceOrderService.GetAll();
            var response = _mapper.Map<IEnumerable<ServiceOrderResponse>>(serviceOrders);
            
            return Ok(response);
        }

        [HttpGet("{id}")]
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
            var serviceOrder = _mapper.Map<ServiceOrder>(request);

            _serviceOrderService.Create(serviceOrder);

            if (_notificator.HasErrors())
            {
                // TODO
            }

            var response = _mapper.Map<ServiceOrderResponse>(serviceOrder);

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public ActionResult<ServiceOrderResponse> Put([FromRoute] long id, [FromBody] ServiceOrderRequest request)
        {
            if (request.Id != id)
            {
                return NotFound();
            }

            var serviceOrder = _mapper.Map<ServiceOrder>(request);

            _serviceOrderService.Update(serviceOrder);

            if (_notificator.HasErrors())
            {
                // TODO
            }

            var response = _mapper.Map<ServiceOrderResponse>(serviceOrder);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            _serviceOrderService.Remove(id);

            if (_notificator.HasErrors())
            {
                // TODO
            }

            return NoContent();
        }
    }
}

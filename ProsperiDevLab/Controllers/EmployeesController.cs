using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProsperiDevLab.Controllers.Contracts.Response;
using ProsperiDevLab.Services.Interfaces;
using System.Collections.Generic;

namespace ProsperiDevLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeResponse>> Get()
        {
            var employees = _employeeService.GetAll();
            var response = _mapper.Map<IEnumerable<EmployeeResponse>>(employees);

            return Ok(response);
        }
    }
}

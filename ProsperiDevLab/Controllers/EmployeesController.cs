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

        [HttpPost]
        public ActionResult<EmployeeResponse> Post([FromBody] EmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);

            _employeeService.Create(employee);

            var response = _mapper.Map<EmployeeResponse>(employee);

            return Created($"api/Employees/{employee.Id}", response);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] long id)
        {
            _employeeService.Remove(id);

            return NoContent();

        }
    }
}
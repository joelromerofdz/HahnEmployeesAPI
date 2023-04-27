using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.DTOs.EmployeeDTOs;
using HahnEmployeesAPI.Services.Employees;
using Microsoft.AspNetCore.Mvc;

namespace HahnEmployeesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeGetDto>>> Get()
        {
            return await _employeeService.GetAllEmployees();
        }
    }
}
using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.DTOs.EmployeeDTOs;
using HahnEmployeesAPI.DTOs.RoleDTOs;
using HahnEmployeesAPI.Services.Employees;
using HahnEmployeesAPI.Services.Roles;
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
        public async Task<ActionResult<List<EmployeeResponseDto>>> Get()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponseDto?>> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Post(EmployeeRequestDto employeeRequestDto)
        {
            try
            {
                await _employeeService.AddEmployee(employeeRequestDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, EmployeeRequestDto employeeRequestDto)
        {
            try
            {
                var updatedEmployee = await _employeeService.UpdateEmployee(id, employeeRequestDto);

                if (!updatedEmployee)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deletedEmployee = await _employeeService.DeleteEmployee(id);

                if (!deletedEmployee)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
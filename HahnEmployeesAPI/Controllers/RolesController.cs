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
    public class RolesController : ControllerBase
    {
        private RoleService _roleService;
        public RolesController(RoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleResponseDto>>> Get()
        {
            return await _roleService.GetAllRoles();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleResponseDto?>> Get([FromRoute] int id)
        {
            var role = await _roleService.GetRoleById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleRequestDto roleRequestDto)
        {
            try
            {
                await _roleService.AddRole(roleRequestDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromBody] RoleRequestDto roleRequestDto)
        {
            try
            {
                var updatedRole = await _roleService.UpdateRole(id, roleRequestDto);

                if (!updatedRole)
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
                var deletedRole = await _roleService.DeleteRole(id);

                if (!deletedRole)
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
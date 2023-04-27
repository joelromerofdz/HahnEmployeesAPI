using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.DTOs.RoleDTOs;
using HahnEmployeesAPI.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        public async Task<ActionResult<List<RoleGetDto>>> Get()
        {
            return await _roleService.GetAllRoles();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleGetDto?>> Get([FromRoute] int? id)
        {
            var role = await _roleService.GetRoleById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Role role)
        {
            await _roleService.Add(role);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int? id, [FromBody] Role role)
        {
            if (id == null)
            {
                return BadRequest("This role id does not exist.");
            }

            var existRole = await _roleService.GetRoleExist(id);

            if (!existRole)
            {
                return NotFound();
            }

            var getRole = await _roleService
                .GetByExpression(r => r.Id == id);

            Role roleValue = (Role)getRole;
            roleValue.Description = role.Description;
            roleValue.Title = role.Title;
            roleValue.Updated = DateTime.Now;

            await _roleService.Update(roleValue);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int? id)
        {
            if (id == null)
            {
                return BadRequest("This role id does not exist.");
            }

            var existRole = await _roleService.GetRoleExist(id);

            if (!existRole)
            {
                return NotFound();
            }

            var getRole = await _roleService
                .GetByExpression(r => r.Id == id);

            Role roleValue = (Role)getRole;

            _roleService.Delete(roleValue);

            return Ok();
        }
    }
}

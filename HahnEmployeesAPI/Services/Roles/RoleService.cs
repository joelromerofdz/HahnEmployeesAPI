using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.Domain.Repository;
using HahnEmployeesAPI.DTOs.RoleDTOs;
using HahnEmployeesAPI.Infrastructure.Data;
using HahnEmployeesAPI.Services.Base;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HahnEmployeesAPI.Services.Roles
{
    public class RoleService : ServiceBase<Role>
    {
        private AppDbContext _dbContext;
        public RoleService(IRepository<Role> repository,
            AppDbContext _dbContext) : base(repository)
        {
            this._dbContext = _dbContext;
        }

        public async Task<List<RoleResponseDto>> GetAllRoles()
        {
            var data = await this.GetAll();
            var roles = data.Select(r => new RoleResponseDto()
            {
                Description = r.Description,
                Title = r.Title
            })
            .ToList();

            return roles;

        }

        public async Task<RoleResponseDto?> GetRoleById(int id)
        {
            var data = await this.GetByExpression(r => r.Id == id);

            var role = new RoleResponseDto();
            role.Title = data.Title;
            role.Description = data.Description;

            return role;
        }

        public async Task<bool> GetRoleExist(int id)
        {
            return await _dbContext.Roles
                .AnyAsync(r => r.Id == id);
        }

        public async Task AddRole(RoleRequestDto RoleRequestDto)
        {
            var role = new Role();
            role.Title = RoleRequestDto.Title;
            role.Description = RoleRequestDto.Description;

            await this.Add(role);
        }

        public async Task<bool> UpdateRole(int id, RoleRequestDto roleRequestDto)
        {
            var getRole = await this.GetByExpression(e => e.Id == id);

            if (getRole == null)
            {
                return false;
            }

            var role = (Role)getRole;
            role.Description = roleRequestDto.Description;
            role.Title = roleRequestDto.Title;
            role.Updated = DateTime.Now;

            await this.Update(role);

            return true;
        }

        public async Task<bool> DeleteRole(int id)
        {
            var getRole = await this.GetByExpression(e => e.Id == id);

            if (getRole == null)
            {
                return false;
            }

            Role role = (Role)getRole;

            await this.Delete(role);

            return true;

        }
    }
}
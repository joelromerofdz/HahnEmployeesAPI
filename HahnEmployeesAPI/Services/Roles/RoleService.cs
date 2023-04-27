using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.Domain.Repository;
using HahnEmployeesAPI.DTOs.RoleDTOs;
using HahnEmployeesAPI.Infrastructure.Data;
using HahnEmployeesAPI.Services.Base;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<RoleGetDto>> GetAllRoles()
        {
            return await _dbContext.Roles
                .Select(r => new RoleGetDto()
                {
                    Title = r.Title,
                    Description = r.Description
                })
                .ToListAsync();
        }

        public async Task<RoleGetDto?> GetRoleById(int? id)
        {
            return await _dbContext.Roles
                .Where(r => r.Id == id)
                .Select(r => new RoleGetDto()
                {
                    Title = r.Title,
                    Description = r.Description
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> GetRoleExist(int? id)
        {
            return await _dbContext.Roles
                .AnyAsync(r => r.Id == id);
        }
    }
}

using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.Domain.Repository;
using HahnEmployeesAPI.Infrastructure.Data;
using HahnEmployeesAPI.Services.Base;

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
    }
}

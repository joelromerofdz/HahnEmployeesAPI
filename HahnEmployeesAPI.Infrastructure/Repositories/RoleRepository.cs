using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.Infrastructure.Base;
using HahnEmployeesAPI.Infrastructure.Data;

namespace HahnEmployeesAPI.Infrastructure.Repositories
{
    public class RoleRepository : RepositoryBase<Role>
    {
        public RoleRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}

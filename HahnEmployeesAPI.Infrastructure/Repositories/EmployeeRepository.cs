using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.Infrastructure.Base;
using HahnEmployeesAPI.Infrastructure.Data;

namespace HahnEmployeesAPI.Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}

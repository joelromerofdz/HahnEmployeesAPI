using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.Domain.Repository;
using HahnEmployeesAPI.Infrastructure.Data;
using HahnEmployeesAPI.Services.Base;

namespace HahnEmployeesAPI.Services.Employees
{
    public class EmployeeService : ServiceBase<Employee>
    {
        private AppDbContext _dbContext;
        public EmployeeService(IRepository<Employee> repository, AppDbContext dbContext) : base(repository)
        {
            this._dbContext = dbContext;
        }
    }
}

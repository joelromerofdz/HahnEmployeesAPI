using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.Infrastructure.Base;
using HahnEmployeesAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnEmployeesAPI.Infrastructure.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}

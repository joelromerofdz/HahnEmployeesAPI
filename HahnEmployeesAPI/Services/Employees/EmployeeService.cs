using HahnEmployeesAPI.Domain.Base;
using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.Domain.Repository;
using HahnEmployeesAPI.DTOs.EmployeeDTOs;
using HahnEmployeesAPI.Infrastructure.Data;
using HahnEmployeesAPI.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace HahnEmployeesAPI.Services.Employees
{
    public class EmployeeService : ServiceBase<Employee>
    {
        private AppDbContext _dbContext;

        public EmployeeService(IRepository<Employee> repository,
            AppDbContext dbContext) : base(repository)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<EmployeeGetDto>> GetAllEmployees()
        {
            return await _dbContext.Employees
                .Select(e => new EmployeeGetDto()
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                    RoleTitle  = e.Role.Title,
                    Email = e.Email,
                    Phone = e.Phone,
                    Birthdate = e.Birthdate,
                    DateHired = e.DateHired
                })
                .ToListAsync();
        }
    }
}



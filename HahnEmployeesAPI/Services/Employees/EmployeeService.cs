using HahnEmployeesAPI.Domain.Base;
using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.Domain.Repository;
using HahnEmployeesAPI.DTOs.EmployeeDTOs;
using HahnEmployeesAPI.DTOs.RoleDTOs;
using HahnEmployeesAPI.Infrastructure.Data;
using HahnEmployeesAPI.Services.Base;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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

        public async Task<List<EmployeeResponseDto>> GetAllEmployees()
        {
            var employees = await _dbContext.Employees
                .Select(e => new EmployeeResponseDto()
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                    RoleTitle = e.Role.Title,
                    Email = e.Email,
                    Phone = e.Phone,
                    Birthdate = e.Birthdate,
                    DateHired = e.DateHired
                })
                .ToListAsync();

            return employees;
        }

        public async Task<EmployeeResponseDto?> GetEmployeeById(int id)
        {
            var employee = await _dbContext.Employees
                .Where(e => e.Id == id)
                .Select(e => new EmployeeResponseDto()
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                    RoleTitle = e.Role.Title,
                    Email = e.Email,
                    Phone = e.Phone,
                    Birthdate = e.Birthdate,
                    DateHired = e.DateHired
                })
                .FirstOrDefaultAsync();

            return employee;
        }

        public async Task<bool> GetEmployeeExist(int id)
        {
            return await _dbContext.Employees
                .AnyAsync(r => r.Id == id);
        }

        public async Task AddEmployee(EmployeeRequestDto employeeRequestDto)
        {
            var employee = new Employee();
            employee.FirstName = employeeRequestDto.FirstName;
            employee.LastName = employeeRequestDto.LastName;
            employee.Salary = employeeRequestDto.Salary;
            employee.Email = employeeRequestDto.Email;
            employee.Phone = employeeRequestDto.Phone;
            employee.Birthdate = employeeRequestDto.Birthdate;
            employee.DateHired = employeeRequestDto.DateHired;
            employee.RoleId = employeeRequestDto.RoleId;

            await this.Add(employee);
        }

        public async Task<bool> UpdateEmployee(int id, EmployeeRequestDto employeeRequestDto)
        {
            var getEmployee = await this.GetByExpression(e => e.Id == id);

            if (getEmployee == null)
            {
                return false;
            }

            Employee employee = (Employee)getEmployee;
            employee.FirstName = employeeRequestDto.FirstName;
            employee.LastName = employeeRequestDto.LastName;
            employee.Salary = employeeRequestDto.Salary;
            employee.Email = employeeRequestDto.Email;
            employee.Phone = employeeRequestDto.Phone;
            employee.Birthdate = employeeRequestDto.Birthdate;
            employee.DateHired = employeeRequestDto.DateHired;
            employee.RoleId = employeeRequestDto.RoleId;
            employee.Updated = DateTime.Now;

            await this.Update(employee);

            return true;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var getEmployee = await this.GetByExpression(e => e.Id == id);

            if (getEmployee == null)
            {
                return false;
            }

            Employee employee = (Employee)getEmployee;

            await this.Delete(employee);

            return true;
        }
    }
}



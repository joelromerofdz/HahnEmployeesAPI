using HahnEmployeesAPI.Domain.Entities;
using HahnEmployeesAPI.Domain.Repository;
using HahnEmployeesAPI.Infrastructure.Base;
using HahnEmployeesAPI.Infrastructure.Data;
using HahnEmployeesAPI.Services.Employees;
using HahnEmployeesAPI.Services.Roles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//Employee
builder.Services.AddScoped<IRepository<Employee>, RepositoryBase<Employee>>();
builder.Services.AddScoped<EmployeeService>();

//Role
builder.Services.AddScoped<IRepository<Role>, RepositoryBase<Role>>();
builder.Services.AddScoped<RoleService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

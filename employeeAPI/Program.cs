using employeeAPI.Application.Interfaces;
using employeeAPI.Application.Services;
using employeeAPI.Domain;
using employeeAPI.Infrastructure;
using employeeAPI.Infrastructure.Services;
using EmployeeAPI.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add DbContext in DI Container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add Generic Repository in DI Container
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddScoped<IEmployeeProjectService, EmployeeProjectService>();

builder.Services.AddScoped<IGenericRepository<Project>, GenericRepository<Project>>();



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

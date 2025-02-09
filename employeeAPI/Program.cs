using employeeAPI.Application.Interfaces;
using employeeAPI.Application.Services;
using employeeAPI.Infrastructure;
using employeeAPI.Infrastructure.Services;
using EmployeeAPI.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add DbContext إلى DI Container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add Generic Repository إلى DI Container
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// add  IEmployeeService و EmployeeService إلى DI Container
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IProjectService, ProjectService>();


// خدمات أخرى
builder.Services.AddScoped<IEmployeeProjectService, EmployeeProjectService>();



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

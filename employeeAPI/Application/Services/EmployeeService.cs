using employeeAPI.Application.DTOs;
using employeeAPI.Application.Interfaces;
using employeeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.Infrastructure.Repositories;

namespace employeeAPI.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(e => new EmployeeDTO
            {
                Name = e.Name,
                Email = e.Email,
                Phone = e.Phone,
                DepartmentId = e.DepartmentId
            }).ToList();
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return null;

            return new EmployeeDTO
            {
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                DepartmentId = employee.DepartmentId
            };
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                DepartmentId = employeeDto.DepartmentId
            };

            await _employeeRepository.AddAsync(employee);
            return employeeDto;
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(Guid id, EmployeeDTO employeeDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return null;

            employee.Name = employeeDto.Name;
            employee.Email = employeeDto.Email;
            employee.Phone = employeeDto.Phone;
            employee.DepartmentId = employeeDto.DepartmentId;

            await _employeeRepository.UpdateAsync(employee);
            return employeeDto;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return false;

            await _employeeRepository.DeleteAsync(id);
            return true;
        }
    }
}

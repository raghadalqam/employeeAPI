using employeeAPI.Application.DTOs;
using employeeAPI.Application.Interfaces;
using employeeAPI.Domain;
using EmployeeAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeAPI.Infrastructure.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _departmentRepository;

        public DepartmentService(IGenericRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        //get all department
        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return departments.Select(d => new DepartmentDTO
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
        }
        //get department by id 
        public async Task<DepartmentDTO> GetDepartmentByIdAsync(Guid id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null) return null;

            return new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name
            };
        }
        //add new department 
        public async Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO departmentDto)
        {
            var department = new Department
            {
                Id = Guid.NewGuid(),
                Name = departmentDto.Name
            };

            await _departmentRepository.AddAsync(department);
            return departmentDto with { Id = department.Id }; // تحديث `Id` بعد الإضافة
        }
        //update  department
        public async Task<DepartmentDTO> UpdateDepartmentAsync(Guid id, DepartmentDTO departmentDto)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null) return null;

            department.Name = departmentDto.Name;
            await _departmentRepository.UpdateAsync(department);

            return new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name
            };
        }
        //delete department
        public async Task<bool> DeleteDepartmentAsync(Guid id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null) return false;

            await _departmentRepository.DeleteAsync( department);
            return true;
        }
    }
}

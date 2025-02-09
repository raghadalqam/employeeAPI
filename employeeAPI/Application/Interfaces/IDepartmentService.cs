using employeeAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employeeAPI.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();
        Task<DepartmentDTO> GetDepartmentByIdAsync(Guid id);
        Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO departmentDto);
        Task<DepartmentDTO> UpdateDepartmentAsync(Guid id, DepartmentDTO departmentDto);
        Task<bool> DeleteDepartmentAsync(Guid id);
    }
}

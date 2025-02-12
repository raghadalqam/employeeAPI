using employeeAPI.Application.DTOs; // لنقل البيانات بين الطبقات 
using employeeAPI.Domain; // to access the entites in domain 

namespace employeeAPI.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO employeeDto);
        Task<EmployeeDTO> UpdateEmployeeAsync(Guid id, EmployeeDTO employeeDto);
        Task<bool> DeleteEmployeeAsync(Guid id);
    }
}

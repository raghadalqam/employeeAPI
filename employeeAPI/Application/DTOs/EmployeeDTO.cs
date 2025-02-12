using System;

namespace employeeAPI.Application.DTOs
{
    public class EmployeeDTO
    {
       public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public Guid DepartmentId { get; set; }

    }
}

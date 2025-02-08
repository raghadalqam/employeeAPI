using System;
using System.Collections.Generic;

namespace employeeAPI.Domain
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}

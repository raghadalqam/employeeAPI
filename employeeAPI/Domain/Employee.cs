using System;
using System.Collections.Generic;

namespace employeeAPI.Domain
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }  // the phone number is optional 
        public Guid DepartmentId { get; set; } //Foreign Key
        public Department Department { get; set; } //Navigation Property
        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>(); //many to many 
    }
}

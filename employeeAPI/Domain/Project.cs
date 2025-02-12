using System;
using System.Collections.Generic;

namespace employeeAPI.Domain
{
    public class Project
    {
        public Guid Id { get; set; }  // Primary Key
        public string Title { get; set; } = string.Empty; // Project Title
        public List<EmployeeProject>? EmployeeProjects { get; set; } // Many-to-Many Relationship
    }
}
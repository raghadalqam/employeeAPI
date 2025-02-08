using System;
using System.Collections.Generic;

namespace employeeAPI.Domain
{
    public class Department
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}

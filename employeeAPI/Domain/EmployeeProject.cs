using System;

namespace employeeAPI.Domain
{
    public class EmployeeProject  //join table
    {
        public Guid EmployeeId { get; set; } //Foreign Key
        public Employee Employee { get; set; }
        public Guid ProjectId { get; set; }  //Foreign Key
        public Project Project { get; set; }
    }
}

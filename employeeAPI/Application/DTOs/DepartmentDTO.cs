using System;

namespace employeeAPI.Application.DTOs
{
    public record DepartmentDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}

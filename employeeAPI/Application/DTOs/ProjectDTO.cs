using System;

namespace employeeAPI.Application.DTOs
{
    public record ProjectDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}

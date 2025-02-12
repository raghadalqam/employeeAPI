using employeeAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employeeAPI.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync();
        Task<ProjectDTO> GetProjectByIdAsync(Guid id);
        Task<ProjectDTO> CreateProjectAsync(ProjectDTO projectDto);
        Task<ProjectDTO> UpdateProjectAsync(Guid id, ProjectDTO projectDto);
        Task<bool> DeleteProjectAsync(Guid id);

       
    }
}

using employeeAPI.Application.DTOs;
using employeeAPI.Application.Interfaces;
using employeeAPI.Domain;
using EmployeeAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeAPI.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGenericRepository<Project> _projectRepository;

        public ProjectService(IGenericRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return projects.Select(p => new ProjectDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            }).ToList();
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return null;

            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }

        public async Task<ProjectDTO> CreateProjectAsync(ProjectDTO projectDto)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = projectDto.Name,
                Description = projectDto.Description
            };

            await _projectRepository.AddAsync(project);
            return projectDto with { Id = project.Id };
        }

        public async Task<ProjectDTO> UpdateProjectAsync(Guid id, ProjectDTO projectDto)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return null;

            project.Name = projectDto.Name;
            project.Description = projectDto.Description;
            await _projectRepository.UpdateAsync(project);

            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }

        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return false;

            await _projectRepository.DeleteAsync(project);
            return true;
        }
    }
}

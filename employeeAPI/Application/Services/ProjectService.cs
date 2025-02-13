using employeeAPI.Application.DTOs;
using employeeAPI.Application.Interfaces;
using employeeAPI.Domain;
using EmployeeAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeAPI.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IGenericRepository<Project> _projectRepository;

        // Constructor
        public ProjectService(IGenericRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // Get all projects
        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllAsync();

            //check empty fields
            return projects.Select(p => new ProjectDTO
            {
                Id = p.Id,
                Title = p.Title ?? "Default Title"
            });                                         //use defulte value if is it empty
        }
        

        // Get a project by its ID
        public async Task<ProjectDTO> GetProjectByIdAsync(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return null;

            return new ProjectDTO
            {
                Id = project.Id,
                Title = project.Title
            };
        }

        // Create a new project
        public async Task<ProjectDTO> CreateProjectAsync(ProjectDTO projectDto)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(), 
                Title = projectDto.Title
            };

            await _projectRepository.AddAsync(project);

            return new ProjectDTO
            {
                Id = project.Id,
                Title = project.Title
            };
        }

        // Update an existing project
        public async Task<ProjectDTO> UpdateProjectAsync(Guid id, ProjectDTO projectDto)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return null;

            project.Title = projectDto.Title;

            await _projectRepository.UpdateAsync(project);
            return new ProjectDTO
            {
                Id = project.Id,
                Title = project.Title
            };
        }

        // Delete a project
        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null) return false;

            await _projectRepository.DeleteAsync(project);
            return true;
        }
    }
}

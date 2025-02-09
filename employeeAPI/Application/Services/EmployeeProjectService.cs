using employeeAPI.Application.Interfaces;
using employeeAPI.Domain;
using EmployeeAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeAPI.Infrastructure.Services
{
    public class EmployeeProjectService : IEmployeeProjectService
    {
        private readonly IGenericRepository<EmployeeProject> _employeeProjectRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Project> _projectRepository;

        public EmployeeProjectService(
            IGenericRepository<EmployeeProject> employeeProjectRepository,
            IGenericRepository<Employee> employeeRepository,
            IGenericRepository<Project> projectRepository)
        {
            _employeeProjectRepository = employeeProjectRepository;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
        }

        // تعيين موظف لمشاريع متعددة
        public async Task<bool> AssignEmployeeToProjectsAsync(Guid employeeId, List<Guid> projectIds)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null) return false;

            var projects = await _projectRepository.GetAllAsync();
            var validProjects = projects.Where(p => projectIds.Contains(p.Id)).ToList();

            if (validProjects.Count != projectIds.Count) return false;

            var employeeProjects = validProjects.Select(p => new EmployeeProject
            {
                EmployeeId = employeeId,
                ProjectId = p.Id
            }).ToList();

            foreach (var empProj in employeeProjects)
            {
                await _employeeProjectRepository.AddAsync(empProj);
            }

            return true;
        }

        // إزالة موظف من مشروع
        public async Task<bool> RemoveEmployeeFromProjectAsync(Guid employeeId, Guid projectId)
        {
            var employeeProject = await _employeeProjectRepository.GetAllAsync();
            var empProj = employeeProject.FirstOrDefault(ep => ep.EmployeeId == employeeId && ep.ProjectId == projectId);

            if (empProj == null) return false;

            await _employeeProjectRepository.DeleteAsync(empProj);
            return true;
        }
    }
}

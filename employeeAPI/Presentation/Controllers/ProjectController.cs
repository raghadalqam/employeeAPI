using Microsoft.AspNetCore.Mvc;
using employeeAPI.Application.DTOs;
using employeeAPI.Application.Services;
using System;
using System.Threading.Tasks;
using employeeAPI.Application.Interfaces;

namespace employeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET api/projects
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        // GET api/projects/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        // POST api/projects
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectDTO projectDto)
        {
            var createdProject = await _projectService.CreateProjectAsync(projectDto);
            return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);
        }

        // PUT api/projects/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectDTO projectDto)
        {
            if (id != projectDto.Id)
                return BadRequest();

            var updatedProject = await _projectService.UpdateProjectAsync(id, projectDto);
            if (updatedProject == null)
                return NotFound();

            return NoContent();
        }

        // DELETE api/projects/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var result = await _projectService.DeleteProjectAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}

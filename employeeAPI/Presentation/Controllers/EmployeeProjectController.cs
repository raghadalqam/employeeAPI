using employeeAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace employeeAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectController : ControllerBase
    {
        private readonly IEmployeeProjectService _employeeProjectService;

        public EmployeeProjectController(IEmployeeProjectService employeeProjectService)
        {
            _employeeProjectService = employeeProjectService;
        }

        // تعيين موظف لمشاريع متعددة
        [HttpPost("assign/{employeeId}")]
        public async Task<IActionResult> AssignEmployeeToProjects(Guid employeeId, [FromBody] List<Guid> projectIds)
        {
            var result = await _employeeProjectService.AssignEmployeeToProjectsAsync(employeeId, projectIds);
            if (!result) return BadRequest("Unable to assign employee to projects.");
            return Ok("Employee assigned to projects successfully.");
        }

        // إزالة موظف من مشروع
        [HttpDelete("remove/{employeeId}/{projectId}")]
        public async Task<IActionResult> RemoveEmployeeFromProject(Guid employeeId, Guid projectId)
        {
            var result = await _employeeProjectService.RemoveEmployeeFromProjectAsync(employeeId, projectId);
            if (!result) return BadRequest("Unable to remove employee from project.");
            return Ok("Employee removed from project successfully.");
        }
    }
}

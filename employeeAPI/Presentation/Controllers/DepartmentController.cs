using employeeAPI.Application.DTOs;
using employeeAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace employeeAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // إنشاء قسم جديد
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDTO departmentDto)
        {
            if (departmentDto == null) return BadRequest("Invalid department data");

            var createdDepartment = await _departmentService.CreateDepartmentAsync(departmentDto);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = createdDepartment.Id }, createdDepartment);
        }

        // جلب جميع الأقسام
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        // جلب قسم معين حسب ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null) return NotFound();
            return Ok(department);
        }

        // تحديث بيانات القسم
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(Guid id, [FromBody] DepartmentDTO departmentDto)
        {
            var updatedDepartment = await _departmentService.UpdateDepartmentAsync(id, departmentDto);
            if (updatedDepartment == null) return NotFound();
            return Ok(updatedDepartment);
        }

        // حذف قسم معين
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}

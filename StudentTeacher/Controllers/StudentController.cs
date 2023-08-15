using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTeacher.Core.DTOs;
using StudentTeacher.Core.Interfaces.Core;
using StudentTeacher.Core.Models;
using StudentTeacher.ValidationFilters;
using System.ComponentModel.DataAnnotations;

namespace StudentTeacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IStudentService _studentService;
        public StudentController(IStudentService studentService) {
            _studentService = studentService;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PagedList<StudentToReturn>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStudents(
           [Required][Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")] int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await _studentService.GetStudentsAsync(pageNumber, pageSize));
        }

        [HttpPost("")]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddNewStudent(NewStudent model)
        {
             await _studentService.AddStudentAsync(model);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using StudentTeacher.Core.Interfaces.Core;
using StudentTeacher.Core.Models;
using StudentTeacher.Core.DTOs;
using StudentTeacher.ValidationFilters;

namespace TeacherTeacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PagedList<TeacherToReturn>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTeachers(
           [Required][Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")] int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await _teacherService.GetTeachersAsync(pageNumber, pageSize));
        }

        [HttpPost("")]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddNewTeacher(NewTeacher model)
        {
            await _teacherService.AddTeacherAsync(model);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}

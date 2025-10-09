using Application.Dto;
using Application.Interface;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _studentService.CreateAsync(studentDto);
            return CreatedAtAction(nameof(Get), new { id = studentDto.StudentId }, studentDto);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _studentService.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, StudentDto student)
        {
            if (id != student.StudentId)
                return BadRequest();

            await _studentService.UpdateAsync(id,student);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}

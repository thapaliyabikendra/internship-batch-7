using Assisment.Contract;
using Assisment.Contract.Dto;
using Assisment.Contract.DTOs;
using Assisment.Contract.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Student.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[ApiKey]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;//private
    public StudentController(IStudentService service)
    {
        _service = service;
    }

    /// <summary>
    /// Creates a new student.
    /// Expects a StudentDTO in the request body.
    /// Returns a ResponseData containing the created StudentDTO, success status, and message.
    /// </summary>

    [HttpPost]
    //[Authorize]
    public async Task<ActionResult<ResponseData<StudentDTO>>> CreateAsync([FromBody] CreateStudentDto dto)
    {
        ResponseData<StudentDTO> result = await _service.CreateAsync(dto);

        if (result.Success)
            return StatusCode(StatusCodes.Status201Created, result); // 201 Created

        return BadRequest(result);
    }

    /// <summary>
    /// Deletes an existing student by ID.
    /// Expects the student ID as a route parameter.
    /// Returns a ResponseData with success status and message.
    /// </summary>

    [HttpDelete("{id}")]
    //[Authorize]
    public async Task<ActionResult<ResponseData>> DeleteAsync(int id)
    {
        ResponseData result = await _service.DeleteAsync(id);

        if (result.Success)
            return Ok(result);      

        return BadRequest(result);
       
    }


    /// <summary>
    /// Retrieves a paginated list of students.
    /// Accepts pageNumber as a query parameter to fetch the corresponding page.
    /// Returns a ResponseData containing a list of StudentDTOs, success status, and message.
    /// </summary>
    
    [HttpGet]
    //[Authorize]
    public async Task<ActionResult<ResponseData<List<StudentDTO>>>> GetAsync()
    {
        ResponseData<List<StudentDTO>> result =await _service.GetAsync();
        if (result.Success)
            return Ok(result);      // 200

        return BadRequest(result);
    }


    /// <summary>
    /// Retrieves a student by its ID.
    /// Expects the student ID as a route parameter.
    /// Returns a ResponseData containing the StudentDTO, success status, and message.
    /// </summary>

    [HttpGet("{id}")]
    //[Authorize]
    public async Task<ActionResult<ResponseData<StudentDTO>>> GetStudentByIdAsync(int id)
    {
        ResponseData<StudentDTO> result = await _service.GetStudentByIdAsync(id);

        if (result.Success)
            return Ok(result);   

        return NotFound(result);
    }

    /// <summary>
    /// Updates an existing student by ID.
    /// Expects the student ID as a route parameter and a StudentDTO in the request body.
    /// Returns a ResponseData containing the updated StudentDTO, success status, and message.
    /// </summary>

    [HttpPut("{id}")]
   // [Authorize]
    public async Task<ActionResult<ResponseData<StudentDTO>>> UpdateAsync(int id, [FromBody] StudentDTO dto)
    {
        ResponseData<StudentDTO> result= await _service.UpdateAsync(id, dto);
        if (result.Success)
            return Ok(result);     

        return BadRequest(result);
    }

    [HttpGet("paginated")]
    
    public async Task<ActionResult<PaginatedResponse<StudentDTO>>> GetPaginatedAsync(
    [FromQuery] int pageNumber = 1,
    [FromQuery] int pageSize = 10)
    {
        var result = await _service.GetPaginatedAsync(pageNumber, pageSize);

        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }
}

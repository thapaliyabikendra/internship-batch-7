using Assisment.Contract;
using Assisment.Contract.DTOs;
using Assisment.Contract.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.Student.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    public readonly IStudentService Service;
    public StudentController(IStudentService service)
    {
        Service = service;
    }

    /// <summary>
    /// Creates a new student.
    /// Expects a StudentDTO in the request body.
    /// Returns a ResponseData containing the created StudentDTO, success status, and message.
    /// </summary>

    [HttpPost]
    public async Task<ResponseData<StudentDTO>> CreateAsync([FromBody] StudentDTO dto)
    {
        ResponseData<StudentDTO> data = await Service.CreateAsync(dto);

        return data;
    }

    /// <summary>
    /// Deletes an existing student by ID.
    /// Expects the student ID as a route parameter.
    /// Returns a ResponseData with success status and message.
    /// </summary>

    [HttpDelete("{id}")]
    public async Task<ResponseData> DeleteAsync(int id)
    {
        ResponseData data = await Service.DeleteAsync(id);

        return data;
    }


    /// <summary>
    /// Retrieves a paginated list of students.
    /// Accepts pageNumber as a query parameter to fetch the corresponding page.
    /// Returns a ResponseData containing a list of StudentDTOs, success status, and message.
    /// </summary>
    
    [HttpGet]
    public async Task<ResponseData<List<StudentDTO>>> GetAsync(int pageNumber)
    {
        ResponseData<List<StudentDTO>> data =await Service.GetAsync(pageNumber);
        return data;
    }


    /// <summary>
    /// Retrieves a student by its ID.
    /// Expects the student ID as a route parameter.
    /// Returns a ResponseData containing the StudentDTO, success status, and message.
    /// </summary>

    [HttpGet("{id}")]
    public async Task<ResponseData<StudentDTO>> GetStudentByIdAsync(int id)
    {
        ResponseData<StudentDTO> data = await Service.GetStudentByIdAsync(id);

        return data;
    }

    /// <summary>
    /// Updates an existing student by ID.
    /// Expects the student ID as a route parameter and a StudentDTO in the request body.
    /// Returns a ResponseData containing the updated StudentDTO, success status, and message.
    /// </summary>

    [HttpPut("{id}")]
    public async Task<ResponseData<StudentDTO>> UpdateAsync(int id, [FromBody] StudentDTO dto)
    {
        ResponseData<StudentDTO> data= await Service.UpdateAsync(id, dto);
        return data;
    }
}

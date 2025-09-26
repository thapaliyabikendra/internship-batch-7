using Assisment.Contract;
using Assisment.Contract.DTOs;
using Assisment.Contract.Interface.Repo;
using Assisment.Contract.Interface.Service;
using Assisment.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Application.Service;

public class StudentService : IStudentService
{
    public readonly IStudentRepo _repo;

    public StudentService(IStudentRepo repo)
    {
        _repo = repo;
    }

    /// <summary>
    /// Validates the StudentDTO object to ensure all required fields are present.
    /// Returns a ResponseData of string indicating success or the validation message.
    /// </summary>
    private static ResponseData<string> ValidateStudentDto(StudentDTO dto)
    {
        if (dto == null)
        {
            return new ResponseData<string> { Success = false, Message = "Student data is missing" };
        }
            

        if (string.IsNullOrEmpty(dto.Name))
        {
            return new ResponseData<string> { Success = false, Message = "Name is missing" };

        }
           

        if (string.IsNullOrEmpty(dto.Gender))
        {
            return new ResponseData<string> { Success = false, Message = "Gender is missing" };
        }


        if (string.IsNullOrEmpty(dto.Email)) 
        { 
            return new ResponseData<string> { Success = false, Message = "Email is missing" };
        }


        if (string.IsNullOrEmpty(dto.Address))
        {
            return new ResponseData<string> { Success = false, Message = "Address is missing" };
        }
 
        return new ResponseData<string> { Success = true };
    }


    /// <summary>
    /// Creates a new student in the database.
    /// Validates the input DTO and calls the repository to persist the student.
    /// Returns a ResponseData containing the success status and message.
    /// </summary>
    public async Task<ResponseData<StudentDTO>> CreateAsync(StudentDTO dto)
    {
        ResponseData < StudentDTO > response=new ResponseData<StudentDTO> ();
        var validation = ValidateStudentDto(dto);

        if ( !validation.Success)
        {
            response.Success = validation.Success;
            response.Message = validation.Message;
            return response;
        }

        var student = new Student
        {
            Name = dto.Name!.Trim(),
            Gender = dto.Gender!.Trim(),
            Email = dto.Email!.Trim(),
            Address = dto.Address!.Trim(),
            CreateDate = DateTime.Now,
            IsActive = true
        };


        var result=await _repo.CreateAsync(student);


        return new ResponseData<StudentDTO>
        {
            Success = result.Success,
            Message = result.Message,
            
        };
    }

    /// <summary>
    /// Deletes an existing student by ID.
    /// Checks if the ID is provided and calls the repository to delete the student.
    /// Returns a ResponseData indicating the success status and message.
    /// </summary>
    public async Task<ResponseData> DeleteAsync(int id)
    {
        ResponseData response=new ResponseData();
        if (id == 0)
        {
            response.Success = false;
            response.Message = "The id is not given";
            return response;
        }

        var result = await _repo.DeleteAsync(id);
        return result;
    }

    /// <summary>
    /// Retrieves a paginated list of students from the database.
    /// Accepts a page number and fetches the corresponding page of students.
    /// Returns a ResponseData containing a list of StudentDTOs, success status, and message.
    /// </summary>
    public async Task<ResponseData<List<StudentDTO>>> GetAsync(int pageNumber = 1)
    {
        int pageSize = 2;

        ResponseData<List<StudentDTO>> response= new ResponseData<List<StudentDTO>>();

        ResponseData<List<Student>> data=await _repo.GetAsync();

        if (data.Data == null)
        {
            response.Success=data.Success;
            response.Message = data.Message;
            return response;
        }
        
            var totalRecords = data.Data.Count;
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            response.Success = data.Success;
            response.Message = data.Message;

            response.Data = data.Data.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(s => new StudentDTO
                {
                    Name = s.Name,
                    Gender = s.Gender,
                    Email = s.Email,
                    Address = s.Address,

                }).ToList();
        
        

        return response;

    }

    /// <summary>
    /// Retrieves a single student by ID.
    /// Calls the repository to fetch the student details.
    /// Returns a ResponseData containing the StudentDTO, success status, and message.
    /// </summary>
    public async Task<ResponseData<StudentDTO>> GetStudentByIdAsync(int id)
    {
        ResponseData<StudentDTO> response = new ResponseData<StudentDTO>();
        var data=await _repo.GetStudentByIdAsync(id);

        if(data.Data==null)
        {
            response.Success = data.Success;
            response.Message = data.Message;
            return response;
        }

        response.Success = data.Success;
        response.Message = data.Message;
        response.Data =  new StudentDTO
        {
            Name = data.Data.Name,
            Gender = data.Data.Gender,
            Email = data.Data.Email,
            Address = data.Data.Address,
        };

        return response;
    }

    /// <summary>
    /// Updates an existing student by ID.
    /// Validates the input DTO and calls the repository to update the student details.
    /// Returns a ResponseData containing the success status and message.
    /// </summary>
    public async Task<ResponseData<StudentDTO>> UpdateAsync(int id, StudentDTO dto)
    {
        ResponseData<StudentDTO> response = new ResponseData<StudentDTO>();
        if (id == 0)
        {
            response.Success=false;
            response.Message = "Id is not given for update";
            return response;
        }

        var validation = ValidateStudentDto(dto);

        if (!validation.Success)
        {
            response.Success = validation.Success;
            response.Message = validation.Message;
            return response;
        }

        var student = new Student
        {
            Name = dto.Name!.Trim(),
            Gender = dto.Gender!.Trim(),
            Email = dto.Email!.Trim(),
            Address = dto.Address!.Trim(),
        };

        var repoResponse = await _repo.UpdateAsync(id, student);

        if (!repoResponse.Success)
        {
            response.Success=repoResponse.Success;
            response.Message = repoResponse.Message;
            return response;
        }

        response.Success = true;
        response.Message = repoResponse.Message;
       

        return response;

    }
}

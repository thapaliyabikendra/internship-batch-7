using Assisment.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Contract.Interface.Service;

public interface IStudentService
{
    Task<ResponseData<StudentDTO>> CreateAsync(StudentDTO dto);

  
    Task<ResponseData> DeleteAsync(int id);

   
    Task<ResponseData<StudentDTO>> GetStudentByIdAsync(int id);

   
    Task<ResponseData<List<StudentDTO>>> GetAsync(int pageNumber);

    
    Task<ResponseData<StudentDTO>> UpdateAsync(int id, StudentDTO dto);
}

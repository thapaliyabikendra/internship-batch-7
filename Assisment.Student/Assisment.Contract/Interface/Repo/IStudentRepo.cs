using Assisment.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Contract.Interface.Repo;

public interface IStudentRepo
{
    Task<ResponseData> CreateAsync(Student stucent);

    Task<ResponseData> DeleteAsync(int id);

    Task<ResponseData<Student>> GetStudentByIdAsync(int id);

    Task<ResponseData<List<Student>>> GetAsync();

    Task<ResponseData> UpdateAsync(int id, Student author);
}

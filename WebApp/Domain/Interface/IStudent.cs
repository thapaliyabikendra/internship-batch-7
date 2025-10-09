using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IStudent
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task CreateAsync(Student student);
        Task<Student> UpdateAsync(int id,Student student);
        Task<bool> DeleteAsync(int id);
    }
}

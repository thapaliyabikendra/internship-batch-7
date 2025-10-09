using Domain.Entity;
using Domain.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class StudentRepo : IStudent
    {
        private readonly AppDbContext _context;

        public StudentRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var studentData = await _context.Students.FindAsync(id);
            if (studentData == null) return false;
                
            _context.Students.Remove(studentData);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> UpdateAsync(int id,Student student)
        {
            var studentData = await _context.Students.FindAsync(id);
            if (studentData == null) return null;

            studentData.FirstName = student.FirstName;
            studentData.LastName = student.LastName;
            studentData.RollNumber = student.RollNumber;
            studentData.Gender = student.Gender;
            studentData.Grade = student.Grade;

            await _context.SaveChangesAsync();
            return studentData;
        }
    }
}

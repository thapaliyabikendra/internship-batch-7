using Application.Dto;
using Application.Interface;
using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudent _student;

        public StudentService(IStudent student)
        {
            _student = student;
        }
        public async Task CreateAsync(StudentDto student)
        {
            await _student.CreateAsync(new Student 
            { 
                FirstName = student.FirstName, 
                LastName = student.LastName,
                Gender = student.Gender,
                RollNumber = student.RollNumber,
                Grade = student.Grade               
            });

        }

        public async Task DeleteAsync(int id)
        {
            await _student.DeleteAsync(id);
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var studentList = await _student.GetAllAsync();
            return studentList.Select(s => new StudentDto 
            {
                StudentId= s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Gender = s.Gender,
                RollNumber = s.RollNumber,
                Grade = s.Grade
            }).ToList();
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var studentData = await _student.GetByIdAsync(id);
            return studentData == null ? null : new StudentDto 
            {
                StudentId = studentData.Id,
                FirstName = studentData.FirstName,
                LastName = studentData.LastName,
                Gender = studentData.Gender,
                RollNumber = studentData.RollNumber,
                Grade = studentData.Grade
            };
        }

        public async Task UpdateAsync(int id, StudentDto student)
        {
            await _student.UpdateAsync(id,new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Gender = student.Gender,
                RollNumber = student.RollNumber,
                Grade = student.Grade
            });
        }
    }
}

using Assisment.Contract;
using Assisment.Contract.Interface.Repo;
using Assisment.Entity.Entity;
using Assisment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Infrastructure.Repo;

public class StudentRepo: IStudentRepo
{
    public readonly ApplicationDbContext _context;
    
    public StudentRepo(ApplicationDbContext context)
    {
        _context = context;
       
    }


    public async Task<ResponseData> CreateAsync(Student student)
    {

        ResponseData response = new ResponseData();
        await _context.AddAsync(student);
        await _context.SaveChangesAsync();

        response.Success = true;
        response.Message = "Data Saved Sucessfullg";

        return response;
    }

    public async Task<ResponseData> DeleteAsync(int id)
    {
        ResponseData response=new ResponseData();
        var data = await _context.Students.Where(a => a.Id == id && a.IsActive==true).FirstOrDefaultAsync();

        if (data == null)
        {

            response.Success = false;
            response.Message = "Data not found";
            return response;

        }

        _context.Students.Remove(data);
        await _context.SaveChangesAsync();
        response.Success = true;
        response.Message = "Data Sucessfullt Deleted";
        return response;
    }

    public async Task<ResponseData<List<Student>>> GetAsync()
    {
        List<Student> data = await _context.Students.ToListAsync();

        ResponseData<List<Student>> response = new ResponseData<List<Student>>();

        if (data == null || data.Count == 0)
        {

            response.Success = false;
            response.Message = "Data not Fetched ";


            return response;
        }
        response.Data = data;
        response.Success = true;
        response.Message = "Data Fetched Sucessfully";


        return response;
    }

    public async Task<ResponseData<Student>> GetStudentByIdAsync(int id)
    {
        var data = await _context.Students.Where(a => a.Id == id && a.IsActive==true).FirstOrDefaultAsync();

        ResponseData<Student> response = new ResponseData<Student>();

        if (data == null)
        {
            response.Success = false;
            response.Message = "Data not found";
            

            return response;

        }
        response.Success = true;
        response.Data = data;
        return response;
    }


    public async Task<ResponseData> UpdateAsync(int id, Student student)
    {
        ResponseData response=new ResponseData();
        var existing = await _context.Students.FirstOrDefaultAsync(a => a.Id == id);

        if (existing == null)
        {
            response.Message = "Data not found";
            response.Success = false;
            return response;
        }

        existing.Name=student.Name;
        existing.IsActive=student.IsActive;
        existing.ModifiedDate=DateTime.Now;
        existing.Email=student.Email;
        existing.Address=student.Address;
        existing.Gender=student.Gender;

        await _context.SaveChangesAsync();

        response.Success = true;
        response.Message = "Data Updated Successfully";
        return response;

    }

}

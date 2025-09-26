using Contract.ResponceData;
using Library.management.Data;
using Library.management.Models;
using Library.management.Repo.Interface;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Library.management.Repo;

public class AuthorRepo:IAuthorRepo
{
    public readonly ApplicationDbContext _context;
    public readonly ResponseData _result;
    public AuthorRepo(ApplicationDbContext context)
    {
        _context = context;
        _result= new ResponseData();
    }
  

    public async Task<ResponseData> CreateAsync(Author author)
    {
        

        await _context.AddAsync(author);
        await _context.SaveChangesAsync();

        _result.Success = true;
        _result.Message = "Data Saved Sucessfullg";

        return _result;
    }

    public async Task<ResponseData> DeleteAsync(int id)
    {
        
        var data = await _context.Authors.Where(a => a.AuthorId == id).FirstOrDefaultAsync();

        if (data != null) 
        {
            _context.Authors.Remove(data);
            await _context.SaveChangesAsync();
            _result.Success = true;
            _result.Message = "Data Sucessfullt Deleted";

        }
        else
        {
            _result.Success = false;
            _result.Message = "Data not found";
        }
        return _result;
    }

    public async Task<ResponseData<List<Author>>> GetAllAuthor()
    {
        List<Author> data = await _context.Authors.ToListAsync();

        ResponseData<List<Author>> _response = new ResponseData<List<Author>>();

        if (data != null && data.Count > 0)
        {
            _response.Data = data;
            _response.Success = true;
            _response.Message = "Data Fetched Sucessfully";


        }
        else
        {
            _response.Success = false;
            _response.Message = "Data not Fetched ";
        }


            return _response;
    }

    public async Task<ResponseData<Author>> GetAuthorById(int id)
    {
        var data= await _context.Authors.Where(a => a.AuthorId == id).FirstOrDefaultAsync();

        ResponseData<Author> response= new ResponseData<Author>();

        if (data != null) 
        { 
            response.Success = true;
            response.Data = data;

        }
        else
        {
            response.Success = false;
            response.Message = "Data not found";
        }
        return response;
    }


    public async Task<ResponseData> UpdateAsync(Author author)
    {
        var existing = await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == author.AuthorId);

        if (existing != null)
        {
            existing.Name = author.Name;   
            existing.Country = author.Country;
            

            _context.Authors.Update(existing);
            await _context.SaveChangesAsync();

            _result.Success = true;
            _result.Message = "Data Updated Successfully";
        }
        else
        {
            _result.Success = false;
            _result.Message = "Author not found";
        }

        return _result;
    }
}

using Contract.ResponceData;
using Library.management.Data;
using Library.management.Models;
using Library.management.Repo.Interface;
using Library.management.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Library.management.Repo;

public class BorrowerRepo:IBorrowerRepo
{
    ApplicationDbContext _context;
    ResponseData _result;
    public BorrowerRepo(ApplicationDbContext context)
    {
        _context = context;
        _result = new ResponseData();
    }


    public async Task<ResponseData> CreateAsync(Borrower b)
    {


        _context.AddAsync(b);
        _context.SaveChangesAsync();

        _result.Success = true;
        _result.Message = "Data Saved Sucessfullg";

        return _result;
    }

    public async Task<ResponseData> DeleteAsync(int id)
    {

        var data = await _context.borrowers.Where(a => a.Id == id).FirstOrDefaultAsync();

        if (data != null)
        {
            _context.borrowers.Remove(data);
            _context.SaveChangesAsync();
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

    public async Task<ResponseData<List<Borrower>>> GetAllBorrower()
    {
        List<Borrower> data = await _context.borrowers.ToListAsync();

        ResponseData<List<Borrower>> _response = new ResponseData<List<Borrower>>();

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

    public async Task<ResponseData<Borrower>> GetBorrowerById(int id)
    {
        var data = await _context.borrowers.Where(a => a.Id == id).FirstOrDefaultAsync();

        ResponseData<Borrower> response = new ResponseData<Borrower>();

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


    public async Task<ResponseData> UpdateAsync(Borrower b)
    {
        var existing = await _context.borrowers.FirstOrDefaultAsync(a => a.Id == b.Id);

        if (existing != null)
        {
            existing.Name = b.Name;
            existing.Email = b.Email;


            _context.borrowers.Update(existing);
            await _context.SaveChangesAsync();

            _result.Success = true;
            _result.Message = "Data Updated Successfully";
        }
        else
        {
            _result.Success = false;
            _result.Message = "Borrower not found";
        }

        return _result;
    }
}

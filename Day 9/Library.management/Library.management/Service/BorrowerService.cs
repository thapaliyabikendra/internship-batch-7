using Contract.Interfaces.Repo_Interface;
using Contract.ResponceData;
using Library.management.Data;
using Library.management.Models;
using Library.management.Repo.Interface;
using Library.management.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Library.management.Service;

public class BorrowerService : IBorrowerService
{
    IBorrowerRepo _repo;
    ResponseData _result;
    public BorrowerService(IBorrowerRepo repo)
    {
        _repo = repo;
        _result = new ResponseData();
    }

    public async Task<ResponseData> CreateAsync(Borrower b)
    {


        if (b == null)
        {
            _result.Message = "Invalid Data";
        }
        else if (string.IsNullOrEmpty(b.Name))
        {
            _result.Message = "Borrower Name is required";
        }
        else if (string.IsNullOrEmpty(b.Email))
        {
            _result.Message = "BOrrower email is required";
        }
        
        else
        {
            b.Name = b.Name.Trim();
            b.Email = b.Email.Trim();

            _result = await _repo.CreateAsync(b);

        }

        return _result;

    }

    public async Task<ResponseData> DeleteAsync(int id)
    {
        if (id == 0)
        {
            _result.Message = "Id is needed for delete";
        }
        else
        {
            _result = await _repo.DeleteAsync(id);
        }
        return _result;
    }

    public async Task<ResponseData<List<Borrower>>> GetAllBorrower()
    {
        var data = await _repo.GetAllBorrower();
        return data;
    }

    public async Task<ResponseData<Borrower>> GetBorrowerById(int id)
    {
        ResponseData<Borrower> response = new ResponseData<Borrower>();
        if (id == 0)
        {
            response.Message = "Id not found";
        }
        else
        {
            response = await _repo.GetBorrowerById(id);
        }
        return response;
    }

    public async Task<ResponseData> UpdateAsync(Borrower b)
    {
        if (b == null)
        {
            _result.Message = "Invalid Data";
        }
        else if (b.Id == 0)
        {
            _result.Message = "Borrower ID is required for Update";
        }
        else if (string.IsNullOrEmpty(b.Name))
        {
            _result.Message = "Borrower Name is required";
        }
        else if (string.IsNullOrEmpty(b.Email))
        {
            _result.Message = "Book ISBN is required";
        }
        
        else
        {

            b.Name = b.Name.Trim();
            b.Email = b.Email.Trim();
            _result = await _repo.UpdateAsync(b);

        }

        return _result;
    }
}

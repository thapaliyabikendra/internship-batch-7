using Library.management.Data;
using Library.management.Models;
using Library.management.Repo.Interface;
using Library.management.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Library.management.Service.Implementation;

public class BorrowerService : IBorrowerService
{
     IBorrowerRepo _repo;
    public BorrowerService(IBorrowerRepo repo) 
    {

        _repo = repo;
    
    }

    public async Task<IEnumerable<Borrower>> GetAllBorrowerAsync()
    {
        var data=await _repo.GetAllBorrowerAsync();
        return data;
       
    }

    public async Task<Borrower> DeleteBorrowerByIDAsync(int id)
    {
        var data= await _repo.DeleteBorrowerByIDAsync(id);

        return data;
        

    }
}

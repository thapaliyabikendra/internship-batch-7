using Library.management.Data;
using Library.management.Models;
using Library.management.Models.DTO;

using Library.management.Repo.Interface;
using Library.management.Service.Interface;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Library.management.Service;

public class AdvanceQueryService : IAdvanceQueryService
{
    IAdvanceQueryRepo _repo;
    public AdvanceQueryService(IAdvanceQueryRepo repo)
    {
        _repo = repo;
    }

   

    public async Task<List<TopBook>> GetTop3BorrowedAsync ()
    {
        List<TopBook> tb=await _repo.GetTop3BorrowedAsync();
        return tb;
        
    }

    public async Task<List<CountBook>> GetAuthorBookCountAsync()
    {
        List<CountBook> authorCount = await _repo.GetAuthorBookCountAsync();
        return authorCount;
       
    }

    public async Task<List<BorrowerCount>> GetBorrowerCountAsync() 
    {
        List<BorrowerCount> borrowerCount = await _repo.GetBorrowerCountAsync();
        return borrowerCount;

       
    }
}

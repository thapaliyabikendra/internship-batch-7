using Library.management.Models;
using Library.management.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.management.Controllers;

public class BorrowerController:ControllerBase
{
    private readonly IBorrowerService _borrowerService;
    public BorrowerController(IBorrowerService borrowerService)
    {
        _borrowerService = borrowerService;
    }

    [HttpGet]
    public async Task<IEnumerable<Borrower>> GetAllBorrowerAsync()
    {
        return await _borrowerService.GetAllBorrowerAsync();
    }


    [HttpGet]
    public async Task<Borrower> DeleteBorrowerByID(int Id)
    {
        return await _borrowerService.DeleteBorrowerByIDAsync( Id);
    }
}

using Library.management.Models;
using Library.management.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.management.Controllers;
[ApiController]
[Route("api/[controller]")]
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


    [HttpDelete("{id}")]
    public async Task<Borrower> DeleteBorrowerByID(int Id)
    {
        return await _borrowerService.DeleteBorrowerByIDAsync( Id);
    }
}

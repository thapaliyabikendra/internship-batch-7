using Contract.ResponceData;
using Library.management.Models;
using Library.management.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.management.Controllers;
[ApiController]
[Route("api/[controller]")]

public class BorrowerController : ControllerBase
{
    private readonly IBorrowerService _service;
    public BorrowerController(IBorrowerService service)
    {
        _service = service;
    }

    [HttpPost]

    public async Task<ResponseData> CreateAsync([FromBody] Borrower b)
    {
        var data = await _service.CreateAsync(b);
        return data;
    }

    [HttpDelete("{id}")]
    public async Task<ResponseData> DeleteAsync(int id)
    {

        var _result = await _service.DeleteAsync(id);

        return _result;
    }

    [HttpGet]
    public async Task<ResponseData<List<Borrower>>> GetAllBorrower()
    {
        var data = await _service.GetAllBorrower();
        return data;
    }

    [HttpGet("{id}")]
    public async Task<ResponseData<Borrower>> GetAuthorById(int id)
    {


        var response = await _service.GetBorrowerById(id);

        return response;

    }

    [HttpGet("update")]
    public async Task<ResponseData> UpdateAsync(Borrower b)
    {


        var result = await _service.UpdateAsync(b);


        return result;
    }
}
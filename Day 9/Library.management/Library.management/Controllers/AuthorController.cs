using Contract.ResponceData;
using Library.management.Models;
using Library.management.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.management.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthurService _authurService;
    public AuthorController(IAuthurService AuthorService)
    {
        _authurService = AuthorService;
    }

    [HttpPost]

    public async Task<ResponseData> CreateAsync([FromBody] Author author)
    {
        var data = await _authurService.CreateAsync(author);
        return data;
    }

    [HttpDelete("{id}")]
    public async Task<ResponseData> DeleteAsync(int id)
    {
        
        var _result = await _authurService.DeleteAsync(id);
        
        return _result;
    }
    [HttpGet]
    public async Task<ResponseData<List<Author>>> GetAllAuthor()
    {
        var data = await _authurService.GetAllAuthor();
        return data;
    }

    [HttpGet("{id}")]
    public async Task<ResponseData<Author>> GetAuthorById(int id)
    {
       
        
        var response = await _authurService.GetAuthorById(id);

        return response;
        
    }

    [HttpGet("update")]
    public async Task<ResponseData> UpdateAsync(Author author)
    {
        

       var  result = await _authurService.UpdateAsync(author);


        return result;
    }
}

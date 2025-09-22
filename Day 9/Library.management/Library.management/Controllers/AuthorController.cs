using Library.management.Models;
using Library.management.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.management.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthorController: ControllerBase
{
    private readonly IAuthurService _authurService;
    public AuthorController(IAuthurService AuthorService)
    {
        _authurService= AuthorService;
    }

    [HttpPost]

    public async Task<Author> AddAuthorAsync([FromBody] Author author)
    {
        var data= await _authurService.AddAuthorAsync(author);
        return data;
    }
}

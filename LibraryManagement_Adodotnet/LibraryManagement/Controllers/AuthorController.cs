using Contract.Interface.Services;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorsController(IAuthorService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(AddAuthorDto dto)
    {
        _service.CreateAuthor(dto);
        return Ok("Author created");
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var authors = _service.GetAllAuthors();
        return Ok(authors);
    }
}
using Contract.Interface.Services;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;

    public BooksController(IBookService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(AddBookDto dto)
    {
        _service.CreateBook(dto);
        return Ok("Book created");
    }

    [HttpPut]
    public IActionResult Update(UpdateBookDto dto)
    {
        _service.UpdateBook(dto);
        return Ok("Book updated");
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var books = _service.GetAllBooks();
        return Ok(books);
    }
}
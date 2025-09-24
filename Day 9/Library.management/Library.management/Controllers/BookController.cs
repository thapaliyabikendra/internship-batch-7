using Contract.Interfaces.Service_Interface;
using Contract.ResponceData;
using Library.management.Models;
using Library.management.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Library.management.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService BookService)
    {
        _bookService = BookService;
    }

    [HttpPost]

    public async Task<ResponseData> CreateAsync([FromBody] Book book)
    {
        var data = await _bookService.CreateAsync(book);
        return data;
    }

    [HttpDelete("{id}")]
    public async Task<ResponseData> DeleteAsync(int id)
    {

        var _result = await _bookService.DeleteAsync(id);

        return _result;
    }

    [HttpGet]
    public async Task<ResponseData<List<Book>>> GetAllBook()
    {
        var data = await _bookService.GetAllBook();
        return data;
    }

    [HttpGet("{id}")]
    public async Task<ResponseData<Book>> GetBookById(int id)
    {


        var response = await _bookService.GetBookById(id);

        return response;

    }

    [HttpGet("update")]
    public async Task<ResponseData> UpdateAsync(Book book)
    {


        var result = await _bookService.UpdateAsync(book);


        return result;
    }
}

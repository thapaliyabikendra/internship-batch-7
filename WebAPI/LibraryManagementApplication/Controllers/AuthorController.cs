using Contract.Interfaces.Author;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApplication.Controllers;

/// <summary>
/// Author API Controller demonstrating CRUD operations
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    ///// <summary>
    ///// Create a new Author
    ///// </summary>
    //[HttpPost]
    //public async Task<ActionResult<Author>> CreateUser(AuthorCreateDto authorModel)
    //{
    //    if (!ModelState.IsValid)
    //        return BadRequest(ModelState);

    //    var createdAuthor = await _authorService.CreateAuthorAsync(authorModel);
    //    return StatusCode(StatusCodes.Status201Created, createdAuthor);
    //}
    [HttpGet("all")]
    public async Task<ActionResult<ServiceResponseDto<IEnumerable<GetAuthorDto>>>> GetAll()
    {
        var result = await _authorService.GetAllAsync();
        if (result.IsSuccess)
            return Ok(result);

        return BadRequest(result);
    }
}

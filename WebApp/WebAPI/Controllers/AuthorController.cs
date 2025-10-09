using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorServices _authorServices;

        public AuthorController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var authorResult = await _authorServices.GetByIdAsync(id);
            return authorResult == null ? NotFound() : Ok(authorResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _authorServices.CreateAsync(authorDto);
            return CreatedAtAction(nameof(Get), new { id = authorDto.AuthorId }, authorDto);
        }
    }
}

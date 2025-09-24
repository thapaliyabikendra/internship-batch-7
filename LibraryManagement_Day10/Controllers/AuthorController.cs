using LibraryManagement_Day10.Contract.Interface.IServices;
using LibraryManagement_Day10.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement_Day10.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: /Author/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Looks for Views/Author/Create.cshtml
        }

        // POST: /Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorDto authorDto)
        {
            if (ModelState.IsValid)
            {
                await _authorService.CreateAuthor(authorDto);
                return RedirectToAction("Index"); // Or wherever you want to redirect
            }

            return View(authorDto); // Redisplay form with validation errors
        }

        // Optional: GET /Author/Index to list authors
        public IActionResult Index()
        {
            // You can implement a method like GetAllAuthors() in your service
            return View(); // Placeholder for author list view
        }
    }
}
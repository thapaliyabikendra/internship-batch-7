using LibraryManagement_Day10.Contract.Interface.IServices;
using LibraryManagement_Day10.Domain.Dtos;
using LibraryManagement_Day10.LibraryManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement_Day10.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices _bookService;

        public BookController(IBookServices bookService)
        {
            _bookService = bookService;
        }

        // GET: Book/Details
        public async Task<IActionResult> Details()
        {
            try
            {
                var book = await _bookService.GetBookAsync();
                return View(book);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        // GET: Book/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var book = await _bookService.GetBookAsync(); // You may want to fetch by ID instead
            var dto = new BookDto
            {
                Title = book.Name,
                ISBN = book.ISBN,
                PublishedYear = book.PublishedYear,
                AuthorID = book.AuthorId
            };
            return View(dto);
        }

        // POST: Book/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return View(bookDto);

            try
            {
                var updatedBook = await _bookService.UpdateBook(id, bookDto);
                return RedirectToAction("Details");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(bookDto);
            }
        }
    }
}
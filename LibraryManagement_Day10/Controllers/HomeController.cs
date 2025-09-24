//using LibraryManagement_Day10.LibraryManagement.Core.Dtos;
//using LibraryManagement_Day10.LibraryManagement.Core.Interface.IRepository;
//using LibraryManagement_Day10.LibraryManagement.Core.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace LibraryManagement_Day10.LibraryManagement.Api.Controllers
//{
//    public class HomeController : Controller
//    {

//        // GET: HomeController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: HomeController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }


//    }
//}
using LibraryManagement_Day10.Contract.Interface.IRepository;
using LibraryManagement_Day10.Domain.Dtos;
using LibraryManagement_Day10.LibraryManagement.Core.Interface.IServices;
using LibraryManagement_Day10.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement_Day10.Controllers;

public class HomeController : Controller
{
    public readonly IAuthorRepo _authorRepo;
    public HomeController(IAuthorRepo authorRepo)
    {
        _authorRepo = authorRepo;
    }
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<Author>> CreateAuthor(AuthorDto authorModel)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        Author author = new Author();
        author.Name = authorModel.Name;
        author.Country = authorModel.Country;
        var createdAuthor = await _authorRepo.AddAuthorAsync(author);
        return StatusCode(StatusCodes.Status201Created, createdAuthor);
    }



}
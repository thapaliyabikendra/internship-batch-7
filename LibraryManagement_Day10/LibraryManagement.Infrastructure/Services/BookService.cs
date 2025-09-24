using LibraryManagement_Day10.Contract.Interface.IRepository;
using LibraryManagement_Day10.Contract.Interface.IServices;
using LibraryManagement_Day10.Domain.Dtos;
using LibraryManagement_Day10.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement_Day10.LibraryManagement.Infrastructure.Services
{
    public class BookService:IBookServices
    {
        public readonly IBookRepo _bookRepo;
        public BookService(IBookRepo bookRepo)
        {  _bookRepo = bookRepo; }
        public async Task<Book> GetBookAsync()
        {
            var books = await _bookRepo.GetAllBooksAsync();
            var book = books.FirstOrDefault();

            if (book == null)
                throw new Exception("No books found");

            return book;
        }
        public async Task<Book> UpdateBook(Guid bookId, BookDto bookdto)
        {
            Book book = await _bookRepo.BookAvailableAsync(bookId);
            book.AuthorId = bookdto.AuthorID;
            book.ISBN = bookdto.ISBN;
            book.PublishedYear = bookdto.PublishedYear;
            book.Name=bookdto.Title;
            await _bookRepo.UpdateBooksAsync(bookId, book);
            return book;

            
        }
        //public async Task<Book> UpdateBookAsync(Guid bookId, BookDto bookDto)
        //{
        //    var book = await _bookRepo.Books.FindAsync(bookId);

        //    if (book == null)
        //    {
        //        throw new Exception("Book not found");
        //    }

        //    // Update fields
        //    book.Name = bookDto.Title;
        //    book.ISBN = bookDto.ISBN;
        //    book.PublishedYear = bookDto.PublishedYear ?? DateTime.Now.Year;

        //    if (bookDto.AuthorID.HasValue)
        //    {
        //        book.AuthorId = bookDto.AuthorID.Value;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("AuthorID is required");
        //    }

        //    await _context.SaveChangesAsync();
        //    return book;
        //}
    }
}

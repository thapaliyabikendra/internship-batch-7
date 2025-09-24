using LibraryManagement_Day10.Contract.Interface.IRepository;
using LibraryManagement_Day10.LibraryManagement.Core.Dtos;
using LibraryManagement_Day10.LibraryManagement.Infrastructure.Data;
using LibraryManagement_Day10.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace LibraryManagement_Day10.LibraryManagement.Infrastructure.Repository;

public class BookReps:IBookRepo
{
    ApplicationDbContext
        _context;
    public BookReps( ApplicationDbContext context )
    {
        _context = context;
    }
    public async Task<Book> BookAvailableAsync(Guid bookId)
    {
        var book= await _context.Books.FindAsync(bookId);
        if (book == null)
        {
            throw new Exception("No book found with id");
        }
        return book;
    }
    public async Task<Book> UpdateBooksAsync(Guid Id,Book books)
    {
        var book = await _context.Books.FindAsync(Id);
        if (book == null)
        {
            throw new Exception("Empty dto");
        }
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
       
        
        //else
        //{
        //    // Handle the null case appropriately, e.g. throw, log, or assign a default
        //    throw new ArgumentException("AuthorID cannot be null");
        //}
        return book;
    }
    public async Task<List<Book>> GetAllBooksAsync()
    {
        var books = await _context.Books.ToListAsync();

        if (books == null || books.Count == 0)
        {
            throw new Exception("No books found");
        }

        return books;
    }


}

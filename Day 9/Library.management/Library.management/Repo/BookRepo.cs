using Contract.Interfaces.Repo_Interface;
using Contract.ResponceData;
using Library.management.Data;
using Library.management.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.management.Repo;

public class BookRepo:IBookRepo
{
    ApplicationDbContext _context;
    ResponseData _result;
    public BookRepo(ApplicationDbContext context)
    {
        _context = context;
        _result = new ResponseData();
    }


    public async Task<ResponseData> CreateAsync(Book book)
    {


        _context.AddAsync(book);
        _context.SaveChangesAsync();

        _result.Success = true;
        _result.Message = "Data Saved Sucessfullg";

        return _result;
    }

    public async Task<ResponseData> DeleteAsync(int id)
    {

        var data = await _context.Books.Where(a => a.AuthorId == id).FirstOrDefaultAsync();

        if (data != null)
        {
            _context.Books.Remove(data);
            _context.SaveChangesAsync();
            _result.Success = true;
            _result.Message = "Data Sucessfullt Deleted";

        }
        else
        {
            _result.Success = false;
            _result.Message = "Data not found";
        }
        return _result;
    }

    public async Task<ResponseData<List<Book>>> GetAllBook()
    {
        List<Book> data = await _context.Books.ToListAsync();

        ResponseData<List<Book>> _response = new ResponseData<List<Book>>();

        if (data != null && data.Count > 0)
        {
            _response.Data = data;
            _response.Success = true;
            _response.Message = "Data Fetched Sucessfully";


        }
        else
        {
            _response.Success = false;
            _response.Message = "Data not Fetched ";
        }


        return _response;
    }

    public async Task<ResponseData<Book>> GetBookById(int id)
    {
        var data = await _context.Books.Where(a => a.AuthorId == id).FirstOrDefaultAsync();

        ResponseData<Book> response = new ResponseData<Book>();

        if (data != null)
        {
            response.Success = true;
            response.Data = data;

        }
        else
        {
            response.Success = false;
            response.Message = "Data not found";
        }
        return response;
    }


    public async Task<ResponseData> UpdateAsync(Book book)
    {
        var existing = await _context.Books.FirstOrDefaultAsync(a => a.Id == book.Id);

        if (existing != null)
        {
            existing.Title = book.Title;
            existing.ISBN = book.ISBN;
            existing.PublishedYear= book.PublishedYear;
            existing.AuthorId = book.AuthorId;


            _context.Books.Update(existing);
            await _context.SaveChangesAsync();

            _result.Success = true;
            _result.Message = "Data Updated Successfully";
        }
        else
        {
            _result.Success = false;
            _result.Message = "Book not found";
        }

        return _result;
    }
}

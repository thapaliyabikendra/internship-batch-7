using Contract.Interfaces.Repo_Interface;
using Contract.Interfaces.Service_Interface;
using Contract.ResponceData;
using Library.management.Models;
using Library.management.Repo.Interface;

namespace Library.management.Service;

public class BookService: IBookService
{
    public readonly IBookRepo _repo;
    ResponseData _result;
    public BookService(IBookRepo repo)
    {
        _repo = repo;
        _result = new ResponseData();
    }

    public async Task<ResponseData> CreateAsync(Book book)
    {


        if (book == null)
        {
            _result.Message = "Invalid Data";
        }
        else if (string.IsNullOrEmpty(book.Title))
        {
            _result.Message = "Book Title is required";
        }
        else if (string.IsNullOrEmpty(book.ISBN))
        {
            _result.Message = "BOOK IABN is required";
        }
        else if (book.PublishedYear==0)
        {
            _result.Message = "publish year is required";
        }
        else
        {
            book.Title = book.Title.Trim();
            book.ISBN = book.ISBN.Trim();

            _result = await _repo.CreateAsync(book);

        }

        return _result;

    }

    public async Task<ResponseData> DeleteAsync(int id)
    {
        if (id == 0)
        {
            _result.Message = "Id is needed for delete";
        }
        else
        {
            _result = await _repo.DeleteAsync(id);
        }
        return _result;
    }

    public async Task<ResponseData<List<Book>>> GetAllBook()
    {
        var data = await _repo.GetAllBook();
        return data;
    }

    public async Task<ResponseData<Book>> GetBookById(int id)
    {
        ResponseData<Book> response = new ResponseData<Book>();
        if (id == 0)
        {
            response.Message = "Id not found";
        }
        else
        {
            response = await _repo.GetBookById(id);
        }
        return response;
    }

    public async Task<ResponseData> UpdateAsync(Book book)
    {
        if (book == null)
        {
            _result.Message = "Invalid Data";
        }
        else if (book.Id == 0)
        {
            _result.Message = "Book ID is required for Update";
        }
        else if (string.IsNullOrEmpty(book.Title))
        {
            _result.Message = "Bookhor Name is required";
        }
        else if (string.IsNullOrEmpty(book.ISBN))
        {
            _result.Message = "Book ISBN is required";
        }
        else if (book.PublishedYear==0)
        {
            _result.Message = "Book PublishYear is required";
        }
        else if (book.AuthorId == 0)
        {
            _result.Message = "Book Authorid is required";
        }
        else
        {

            book.Title = book.Title.Trim();
            book.ISBN = book.ISBN.Trim();
            _result = await _repo.UpdateAsync(book);

        }

        return _result;
    }
}

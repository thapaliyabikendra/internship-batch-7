using Domain.Dto;
using Domain.Entities;
using LibraryManagement.DataAccess;
using LibraryManagement.Models;

public class BookService
{
    private readonly BookRepository _repo;

    public BookService(BookRepository repo)
    {
        _repo = repo;
    }

    public void AddBook(AddBookDto dto)
    {
        var book = new BookEntity
        {
            Id = dto.Id,
            Title = dto.Name,
            ISBN = dto.ISBN,
            AuthorId = dto.AuthorId
        };

        _repo.CreateBook(book);
    }

    public void UpdateBook(UpdateBookDto dto)
    {
        var book = new BookEntity
        {
            Id = dto.Id,
            Title = dto.Title
        };

        _repo.UpdateBook(book);
    }

    public List<BookEntity> GetAllBooks()
    {
        var books = _repo.ReadAllBooks();

        return books.Select(b => new ReadAllBookDto
        {
            Name = b.Title,
            ISBN = b.ISBN,
        }).ToList();
    }
}
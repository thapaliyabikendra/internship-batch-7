using Contract.Interface.Repositroy;
using Contract.Interface.Services;
using Domain.Dto;
using Domain.Entities;
using Microsoft.Extensions.Logging;

public class BookService : IBookService
{
    private readonly IBookRepo _repo;
    private readonly ILogger<BookService> _logger;

    public BookService(IBookRepo repo, ILogger<BookService> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public void CreateBook(AddBookDto dto)
    {
        var book = new BookEntity
        {
            Id = dto.Id,
            Title = dto.Name,
            ISBN = dto.ISBN,
            AuthorId = dto.AuthorId,
            PublishedYear = DateTime.Now.Year // or dto.PublishedYear if available
        };

        _logger.LogInformation("Creating book: {Title}", book.Title);
        _repo.CreateBook(book);
    }

    public void UpdateBook(UpdateBookDto dto)
    {
        var book = new BookEntity
        {
            Id = dto.Id,
            Title = dto.Title
        };

        _logger.LogWarning("Updating book with ID: {Id}", book.Id);
        _repo.UpdateBook(book);
    }

    public List<ReadAllBookDto> GetAllBooks()
    {
        var books = _repo.ReadAllBooks();
        _logger.LogDebug("Fetched {Count} books", books.Count);

        return books.Select(b => new ReadAllBookDto
        {
            Name = b.Title,
            ISBN = b.ISBN
        }).ToList();
    }
}
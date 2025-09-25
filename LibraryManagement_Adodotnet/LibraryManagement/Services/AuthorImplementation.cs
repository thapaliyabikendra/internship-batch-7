using Domain.Dto;
using LibraryManagement.DataAccess;
using LibraryManagement.Models;

public class AuthorService
{
    private readonly AuthorRepository _repo;

    public AuthorService(AuthorRepository repo)
    {
        _repo = repo;
    }

    public void AddAuthor(AddAuthorDto dto)
    {
        var author = new Author
        {
            Id = Guid.Parse(dto.Id),
            Name = dto.Name,
            Country = dto.Country
        };

        _repo.CreateAuthor(author.Country, author.Name);
    }

    public List<ReadAllAuthor> GetAllAuthors()
    {
        var authors = _repo.ReadAllAuthor();

        return authors.Select(a => new ReadAllAuthor
        {
            Name = a.Name,
            Country = a.Country
        }).ToList();
    }
}
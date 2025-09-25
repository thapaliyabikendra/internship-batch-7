using Contract.Interface.Repositroy;
using Contract.Interface.Services;
using Domain.Dto;
using Domain.Entities;
using Microsoft.Extensions.Logging;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepo _repo;
    private readonly ILogger<AuthorService> _logger;

    public AuthorService(IAuthorRepo repo, ILogger<AuthorService> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    public void CreateAuthor(AddAuthorDto dto)
    {
        _logger.LogInformation("Creating author: {Name}", dto.Name);
        _repo.CreateAuthor(dto.Name, dto.Country);
    }

    public List<ReadAllAuthorDto> GetAllAuthors()
    {
        var authors = _repo.ReadAllAuthor();
        _logger.LogDebug("Fetched {Count} authors", authors.Count);

        return authors.Select(a => new ReadAllAuthorDto
        {
            Name = a.Name,
            Country = a.Country
        }).ToList();
    }
}
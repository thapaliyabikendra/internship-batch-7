using LibraryManagement_Day10.Contract.Interface.IRepository;
using LibraryManagement_Day10.Contract.Interface.IServices;
using LibraryManagement_Day10.Domain.Dtos;
using LibraryManagement_Day10.Models;

namespace LibraryManagement_Day10.LibraryManagement.Infrastructure.Services;

public class AuthorService:IAuthorService
{
    public readonly IAuthorRepo _authorRepo;
    public AuthorService(IAuthorRepo authorRepo)
    {
        _authorRepo = authorRepo;
    }
    public async Task<Author> CreateAuthor(AuthorDto authorDto)
    {
        Author author = new Author()
        {
            Name = authorDto.Name,
            Country = authorDto.Country
        };
        await _authorRepo.AddAuthorAsync(author);
        return author;
    }
}

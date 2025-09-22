using Library.management.Models;

namespace Library.management.Service.Interface;

public interface IAuthurService
{
    Task<Author> AddAuthorAsync(Author author);
}

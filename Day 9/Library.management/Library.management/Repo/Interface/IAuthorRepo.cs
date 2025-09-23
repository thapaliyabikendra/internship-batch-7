using Library.management.Models;

namespace Library.management.Repo.Interface;

public interface IAuthorRepo
{
    Task<Author> AddAuthorAsync(Author author);//create
}

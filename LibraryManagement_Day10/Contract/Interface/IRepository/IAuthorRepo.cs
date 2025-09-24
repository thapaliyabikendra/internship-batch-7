using LibraryManagement_Day10.LibraryManagement.Infrastructure.Data;
using LibraryManagement_Day10.Models;

namespace LibraryManagement_Day10.Contract.Interface.IRepository;

public interface IAuthorRepo
{
    Task<Author> AddAuthorAsync(Author author);

}

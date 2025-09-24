using LibraryManagement_Day10.Domain.Dtos;
using LibraryManagement_Day10.Models;

namespace LibraryManagement_Day10.Contract.Interface.IServices;

public interface IAuthorService
{
    public Task<Author> CreateAuthor(AuthorDto authordot);
}

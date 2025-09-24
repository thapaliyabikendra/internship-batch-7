using LibraryManagement_Day10.LibraryManagement.Core.Dtos;
using LibraryManagement_Day10.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement_Day10.Contract.Interface.IRepository
{
    public interface IBookRepo
    {
        Task<Book> UpdateBooksAsync(Guid Id,Book book);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> BookAvailableAsync(Guid bookId);


    }
}

using LibraryManagement_Day10.Domain.Dtos;
using LibraryManagement_Day10.Models;

namespace LibraryManagement_Day10.Contract.Interface.IServices
{
    public interface IBookServices
    {
        public Task<Book> GetBookAsync();
        public Task<Book> UpdateBook(Guid id,BookDto book);
    }
}

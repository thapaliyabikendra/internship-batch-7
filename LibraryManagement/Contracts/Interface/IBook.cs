using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface
{
    public interface IBook
    {
        Task<Book> Insert(Book book);
        Task<Book> getbyId(int id);
        Task<Book> Update(int id, Book book);
        Task<IEnumerable<Book>> getAll();
    }
}

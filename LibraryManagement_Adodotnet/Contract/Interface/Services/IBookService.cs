using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Interface.Services
{
    public interface IBookService
    {
        void AddBook(AddBookDto dto);
        void UpdateBook(UpdateBookDto dto);
        List<BookEntity> GetAllBooks();

    }
}

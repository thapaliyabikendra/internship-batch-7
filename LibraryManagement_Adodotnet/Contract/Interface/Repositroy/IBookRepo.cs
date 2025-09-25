using Domain.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Interface.Repositroy;

public interface IBookRepo
{
    void CreateBook(BookEntity bookentity);
    List<BookEntity> ReadAllBooks();
    void UpdateBook(BookEntity bookentity);
}

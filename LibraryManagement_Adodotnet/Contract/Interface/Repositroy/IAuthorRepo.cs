using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Interface.Repositroy;

public interface IAuthorRepo
{
    public void CreateAuthor(string name,string country);
    public List<AuthorEntity> ReadAllAuthor();
}
//namespace LibraryManagement.Repositories
//{
//    using LibraryManagement.Models;

//    public interface IAuthorRepository
//    {
//        void Create(Author author);
//        List<Author> GetAll();
//    }

//    public interface IBookRepository
//    {
//        void Create(Book book);
//        List<Book> GetAll();
//        void Update(Book book);
//    }
//}


using Contract.ResponceData;
using Library.management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Interfaces.Repo_Interface;

public interface IBookRepo
{
    Task<ResponseData> CreateAsync(Book book);

    Task<ResponseData> DeleteAsync(int id);

    Task<ResponseData<Book>> GetBookById(int id);

    Task<ResponseData<List<Book>>> GetAllBook();

    Task<ResponseData> UpdateAsync(Book book);
}

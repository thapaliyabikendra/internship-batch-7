using Contract.ResponceData;
using Library.management.Models;

namespace Library.management.Repo.Interface;

public interface IAuthorRepo
{

    Task<ResponseData> CreateAsync(Author author);

    Task<ResponseData> DeleteAsync(int id);

    Task<ResponseData<Author>> GetAuthorById(int id);

    Task<ResponseData<List<Author>>> GetAllAuthor();

    Task<ResponseData> UpdateAsync(Author author);
}


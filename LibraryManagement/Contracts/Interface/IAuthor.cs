using Domain.Entities;

namespace Contracts.Interface
{
    public interface IAuthor
    {
        Task<Author> Insert(Author author);
        Task<Author> getbyId(int id);
        Task<Author> Update(int id,Author author);
        Task<IEnumerable<Author>> getAll();
    }
}

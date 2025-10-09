using Application.Dto;
using Domain.Entity;

namespace Application.Interface
{
    public interface IAuthorServices
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(int id);
        Task CreateAsync(AuthorDto author);
    }
}

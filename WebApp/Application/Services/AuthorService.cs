using Application.Dto;
using Application.Interface;
using Domain.Entity;
using Domain.Interface;

namespace Application.Services
{
    public class AuthorService : IAuthorServices
    {
        private readonly IAuthor _author;

        public AuthorService(IAuthor author)
        {
            _author = author;
        }
        public async Task CreateAsync(AuthorDto author)
        {
           await _author.CreateAsync(new Author { Name = author.Name, Country = author.Country});
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            var authorList = await _author.GetAllAsync();
            return authorList.Select(s => new AuthorDto { AuthorId = s.Id, Name = s.Name, Country = s.Country }).ToList();
        }

        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            var authorData = await _author.GetByIdAsync(id);
            return authorData == null ? null : new AuthorDto { AuthorId = authorData.Id, Name = authorData.Name, Country = authorData.Country};
        }
    }
}

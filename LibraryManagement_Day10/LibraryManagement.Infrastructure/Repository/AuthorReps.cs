using LibraryManagement_Day10.Contract.Interface.IRepository;
using LibraryManagement_Day10.LibraryManagement.Infrastructure.Data;
using LibraryManagement_Day10.Models;

namespace LibraryManagement_Day10.LibraryManagement.Infrastructure.Repository
{
    public class AuthorReps:IAuthorRepo
    {
        ApplicationDbContext _context;
        public AuthorReps(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Author> AddAuthorAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }
    }
}

using Library.management.Data;
using Library.management.Models;
using Library.management.Repo.Interface;

namespace Library.management.Repo.Implementation;

public class AuthorRepo:IAuthorRepo
{
    ApplicationDbContext _context;
    public AuthorRepo(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Author> AddAuthorAsync(Author author)
    {

        _context.AddAsync(author);
        _context.SaveChangesAsync();

        return author;
    }
}

using Library.management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SQLitePCL;

namespace Library.management.Data;

public class ApplicationDbContext : DbContext
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {



    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    public DbSet<Book_Borrower> book_Borrowers { get; set; }

    public DbSet<Borrower> borrowers { get; set; }
    
}

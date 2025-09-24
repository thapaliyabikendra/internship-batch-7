
using LibraryManagement_Day10.Domain.Constraints;
using LibraryManagement_Day10.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement_Day10.LibraryManagement.Infrastructure.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }
    public DbSet<Author>Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Borrower>Borrowers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var author = modelBuilder.Entity<Author>();
        author.HasKey(a => a.Id);
        author.HasIndex(a => a.Name).IsUnique();
        author.Property(a=>a.Name).IsRequired().HasMaxLength(AuthorConst.Name.MaxLength);
        author.Property(a=>a.Country).HasMaxLength(AuthorConst.Country.MaxLength);
        author.HasMany(a => a.Books).WithOne(b => b.Author).HasForeignKey(b=>b.AuthorId).OnDelete(DeleteBehavior.Cascade);

        var book = modelBuilder.Entity<Book>();
        book.HasKey(a => a.Id);
        book.HasIndex(a => a.Name).IsUnique();
        book.Property(a => a.Name).IsRequired().HasMaxLength(50);
        book.HasIndex(b => b.ISBN).IsUnique();
        book.Property(a=>a.PublishedYear).HasDefaultValue(DateTime.Now.Year);
        book.HasMany(a=>a.BooksBorrowers).WithOne(b=>b.Book).HasForeignKey(b=>b.BookID);

        var borrower=modelBuilder.Entity<Borrower>();
        borrower.HasKey(a => a.Id);
        borrower.Property(a => a.Name).IsRequired().HasMaxLength(50);
        borrower.HasIndex(a=>a.Email).IsUnique();
        borrower.HasMany(b => b.BooksBorrowers).WithOne(bk => bk.Borrower).HasForeignKey(bk => bk.BorrowerId);

        var borrowerbook=modelBuilder.Entity<BooksBorrowers>();
        borrowerbook.HasKey(a => a.Id);
        //borrowerbook.HasOne(b=>b.Book).WithMany(bk=>bk.BooksBorrowers).HasForeignKey(b=>b.Id);
        //borrowerbook.HasOne(b => b.Borrower).WithMany(bk => bk.BooksBorrowers).HasForeignKey(b => b.Id);


    }
}

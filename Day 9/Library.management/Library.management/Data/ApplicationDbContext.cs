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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Country).IsRequired().HasMaxLength(255); // Unique constraint

            // Configure one-to-many relationship with Orders
            entity.HasMany(e => e.Books)
                  .WithOne(e => e.Author)
                  .HasForeignKey(e => e.AuthorId)
                  .OnDelete(DeleteBehavior.Cascade);
        });


        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(255);
            entity.Property(e => e.ISBN); // Unique constraint
            entity.HasIndex(e => e.PublishedYear); // Unique constraint
            // Configure one-to-many relationship with Orders
            entity.HasMany(e => e.Book_Borrowers)
                  .WithOne(e => e.Book)
                  .HasForeignKey(e => e.BookId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Borrower>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Email); // Unique constraint
            entity.Property(e => e.IsActive); // Unique constraint
            // Configure one-to-many relationship with Orders
            entity.HasMany(e => e.Book_Borrowers)
                  .WithOne(e => e.Borrower)
                  .HasForeignKey(e => e.BorrowerId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Book_Borrower>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Book)
                  .WithMany(e => e.Book_Borrowers)
                  .HasForeignKey(e => e.BookId);

            entity.HasOne(e => e.Borrower)
                  .WithMany(e => e.Book_Borrowers)
                  .HasForeignKey(e => e.BorrowerId);

            entity.Property(e => e.BorrowDate)
                  .IsRequired();
        });
    }
}





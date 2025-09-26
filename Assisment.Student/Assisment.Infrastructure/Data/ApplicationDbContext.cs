using Assisment.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Infrastructure.Data;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {



    }

    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // -------------------- Student --------------------
    modelBuilder.Entity<Student>(entity =>
    {
        entity.HasKey(e => e.Id); // Primary Key

        entity.Property(e => e.Name)
              .IsRequired()
              .HasMaxLength(255);

        entity.Property(e => e.Gender)
              .IsRequired()
              .HasMaxLength(50);

        entity.Property(e => e.Email)
              .IsRequired()
              .HasMaxLength(255);

        // Email should be unique
        entity.HasIndex(e => e.Email)
              .IsUnique();

        entity.Property(e => e.Address)
              .HasMaxLength(500);

        // From BaseModel
        entity.Property(e => e.CreateDate); 

        entity.Property(e => e.ModifiedDate);
        entity.Property(e => e.IsActive)
              .HasDefaultValue(true);

        entity.Property(e => e.CreatedBy)
              .IsRequired();

        entity.Property(e => e.ModifiedBy);
    });

    // keep your existing Author, Book, Borrower configs here...
}
}

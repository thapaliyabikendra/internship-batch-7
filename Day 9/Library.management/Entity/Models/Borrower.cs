using System.ComponentModel.DataAnnotations;

namespace Library.management.Models;

public class Borrower
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation property for many-to-many with Book
    public virtual ICollection<Book_Borrower> Book_Borrowers { get; set; }
}

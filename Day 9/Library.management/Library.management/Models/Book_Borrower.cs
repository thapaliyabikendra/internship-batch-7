using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.management.Models;

public class Book_Borrower
{
    [Key]
    public int Id { get; set; }

    // Foreign keys
    public int BookId { get; set; }
    public int BorrowerId { get; set; }

    // Navigation properties
    [ForeignKey("BookId")]
    public Book Book { get; set; }

    [ForeignKey("BorrowerId")]
    public Borrower Borrower { get; set; }

    public DateTime BorrowDate { get; set; } = DateTime.Now;
    public DateTime? ReturnDate { get; set; }
}

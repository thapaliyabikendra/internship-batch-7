using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement_Day10.Models;

public class BooksBorrowers
{
    public int Id { get; set; }
    public Guid BookID { get; set; }
    public int BorrowerId { get; set; }
    [ForeignKey("BookID")]
    public virtual Book? Book { get; set; } = null;
    [ForeignKey("BorrowerId")]
    public virtual Borrower? Borrower { get; set; } = null;
}

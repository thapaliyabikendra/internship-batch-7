namespace LibraryManagement_Day10.Models;

public class Borrower:BaseEntity<int>
{
    public string? Email {  get; set; }
    public virtual ICollection<BooksBorrowers> BooksBorrowers { get; set; } = new List<BooksBorrowers>();
}

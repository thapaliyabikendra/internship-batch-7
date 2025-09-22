using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Library.management.Models;

public class Book
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }
    public string ISBN { get; set; }

    public int PublishedYear { get; set; } = DateTime.Now.Year;

    // Foreign key property must match exactly
   
    public int AuthorId { get; set; }   

    [ForeignKey("AuthorId")]
    
    public Author Author { get; set; }

    
    public ICollection<Book_Borrower> Book_Borrowers { get; set; }


}

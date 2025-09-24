using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement_Day10.Models
{
    public class Book:BaseEntity<Guid>
    {
        public Guid AuthorId { get; set; }
        public int PublishedYear { get; set; }
        public required string ISBN { get; set; }
        [ForeignKey("AuthorId")]
        public virtual required Author Author {  get; set; }
        public virtual ICollection <BooksBorrowers> BooksBorrowers { get; set; } = new List<BooksBorrowers>();
    }
}

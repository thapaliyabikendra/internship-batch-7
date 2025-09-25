using Contract.EntityBase;

namespace LibraryManagement.Models
{
    public class Book:EntityBase
    {
        public Guid AuthorId { get; set; }
        public int PublishedYear =DateTime.Now.Year;
        public string? ISBN { get; set; }
    }
}

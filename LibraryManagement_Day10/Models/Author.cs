using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryManagement_Day10.Models
{
    public class Author:BaseEntity<Guid>
    {
        public string? Country { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}

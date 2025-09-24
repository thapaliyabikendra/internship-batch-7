using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int PublishedYear { get; set; }

        // navigation property from Author  
        //public virtual Author Author { get; set; }

        // many-to-many relationship
        //public ICollection<Borrower> Borrowers { get; set; }
    }
}

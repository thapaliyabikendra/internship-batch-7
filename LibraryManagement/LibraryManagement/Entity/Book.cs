using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public int PublishedYear { get; set; }

        // navigation property from Author  
        public virtual Author AuthorL { get; set; }

        // many-to-many relationship
        public ICollection<Borrower> Borrowers { get; set; }
    }
}

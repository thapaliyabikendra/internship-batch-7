using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Entity
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // many-to-many relationship
        public virtual ICollection<Book> BookL { get; set; }
    }
}

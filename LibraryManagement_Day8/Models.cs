using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement_Day8_
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get;set; }
        [NotNull]
        public string Country { get; set; } 
        public Author(int id, string? name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
        public List<Books>?Books { get; set; }
    }
    public class Books
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int AuthorID { get;set;}
        public DateTime DateTime { get; set; }
        public Books() { }
        public Books(int id, string title, int isbn, int authorid, DateTime time)
        {
            Id = id;
            Title = title;
            ISBN = isbn;
            AuthorID = authorid;
            DateTime = time;
        }
        public required Author Author { get; set; }
        public List<Borrowers> ?Borrowers { get; set; }
    }
    public class Borrowers
    {
        [Key, NotNull]
        public int _id { get; set; }
        [NotNull]
        public string Name { get;set; }

        public string Email { get; set; }
        
        public Borrowers(int id, string name, string email)
        {
            _id = id;
            Name = name;
            Email = email;
        }
        
        public required List<Books> Books { get; set; }
    }
}

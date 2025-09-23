using LibraryManagement.Data;
using LibraryManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.LibraryRepo
{
    public class BookRepo
    {
        public static void Insert(Book b)
        {
            using var context = new LibraryContext();
            var book = new Book 
            { 
                Title = b.Title, 
                ISBN = b.ISBN,
                AuthorId = b.AuthorId,
                PublishedYear= b.PublishedYear
            };
            context.Books.Add(book);
            context.SaveChanges();
            Console.WriteLine("Book Add successfully!");

        }

        public static void UpdateBook(int bookId,string title)
        {
            using var context = new LibraryContext();
            var book = context.Books.Find(bookId);
            if (book != null)
            {
                book.Title = title;
                context.SaveChanges();
                Console.WriteLine("Book Update successfully!");

            }
        }

    }
}

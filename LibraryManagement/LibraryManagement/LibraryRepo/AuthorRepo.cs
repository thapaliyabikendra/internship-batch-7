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
    public class AuthorRepo
    {
        public static void Insert(string name, string country)
        {
            using var context = new LibraryContext();
            var author = new Author { Name = name, Country = country };
            context.Authors.Add(author);
            context.SaveChanges();
            Console.WriteLine("Author added successfully!");
        }


    }
}

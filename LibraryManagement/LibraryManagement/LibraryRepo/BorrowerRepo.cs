using LibraryManagement.Data;
using LibraryManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.LibraryRepo
{
    public class BorrowerRepo
    {
        public static void Insert(string name, string email)
        {
            using var context = new LibraryContext();
            var borrower = new Borrower { Name= name, Email = email};
            context.Borrowers.Add(borrower);
            context.SaveChanges();
            Console.WriteLine("Borrower added successfully!");
        }
        public static void GetAllBorrowers()
        {
            using var context = new LibraryContext();
            var borrowers = context.Borrowers.ToList();
            foreach (var b in borrowers)
            {
                Console.WriteLine($"ID: {b.Id}, Name: {b.Name}, Email : {b.Email}");
            }
        }

        public static void Delete(int borrowerId)
        {
            using var context = new LibraryContext();
            var borrower = context.Borrowers.Find(borrowerId);
            if (borrower != null)
            {
                context.Borrowers.Remove(borrower);
                context.SaveChanges();
                Console.WriteLine("Delete Borrower data successfully!");

            }

        }
    }
}

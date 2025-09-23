
using LibraryManagement.Data;
using LibraryManagement.LibraryRepo;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main()
        {
            using var context = new LibraryContext();

            // Automatically applies migrations at startup
            context.Database.Migrate();

            // Author
            AuthorRepo.Insert("Ram", "Nepal");

            // Book
            BookRepo.Insert(new Entity.Book
            {
              Title = "Test",
              ISBN = "12-34",
              AuthorId = 1,
              PublishedYear =2000

            });

            BookRepo.UpdateBook(1, "Farm");

            // Borrower
            BorrowerRepo.Insert("Sita", "sita@gmail.com");
            BorrowerRepo.Insert("Shyam", "shyam@gmail.com");
            BorrowerRepo.Insert("hari", "hari@gmail.com");
            BorrowerRepo.GetAllBorrowers();
            BorrowerRepo.Delete(1);
         

        }

    }
}

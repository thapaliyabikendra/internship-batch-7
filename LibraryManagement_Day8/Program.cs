using LibraryManagement_Day8_;
using System.Net.Http.Headers;

DbConfiguration db = new DbConfiguration();
//Author author1 = new(1, "JK ROWLING", "UK") { Books = new List<Books>() };
//Author author2 = new(2, "Kennay D ROvelt", "USa") { Books = new List<Books>() };

//Books book1 = new Books(1, "HarryPotter", 1, author1.Id, DateTime.Parse("1949-06-08"))
//{
//    Author = author1,
//    Borrowers = new List<Borrowers>()
//};

//Books book2 = new(2, "ToyStory", 2, author2.Id, DateTime.Parse("1999-06-08"))
//{
//Author = author2,
//    Borrowers = new List<Borrowers>()
//};
//author1.Books.Add(book1);
//author2.Books.Add(book2);
//Borrowers borrower1 = new(1, "Subesh", "Subeshguamnju@gmail.com")
//{
//    Books = new List<Books> { book1 }
//};

//book1.Borrowers.Add(borrower1);

//db.Authors.Add(author1);
//db.Authors.Add(author2);
//db.Books.Add(book1);
//db.Books.Add(book2);
//db.Borrowers.Add(borrower1);
//db.SaveChanges();
Console.WriteLine("CRUD operation");
bool exit=false;
while (!exit)
{
    Console.WriteLine("\t\t1.For Creating Author\n\t\t2.For retriving Books\n\t\t3.For updation of book details\n\t\t4.For Deletion of Borrowed books\n\t\t5.For exiting");
    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Creation of new Author");
            Console.WriteLine("Enter Id:");
            if(!int.TryParse(Console.ReadLine(),out int id)){
                Console.WriteLine("Enter a valid input");
            }
                if (db.Authors.Any(i => i.Id == id))
                {
                    Console.WriteLine("Id already exist");
                    return;
                }

            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("invalid country name");
            }
            string? country=Console.ReadLine() ;
            if (string.IsNullOrWhiteSpace(country))
            {
                Console.WriteLine("invalid country name");
            }
            Author newauthor = new(id, name, country) { Books = new List<Books>() };
            db.Authors.Add(newauthor);
            db.SaveChanges();
            Console.WriteLine("Successfully added new author");
            break;
            
        case "2":
            Console.WriteLine("\t\t\tBooks");
            foreach(var book in db.Books)
            {
                Console.WriteLine($"Book Id:{book.Id}\nBook Name{book.Title}\nBook AuthorID:{book.AuthorID}\nBook Published{book.DateTime}\nBook ISBN{book.ISBN}\n\n");
                
            }
            break;
        case "3":
            Console.WriteLine("Updation of book detail by id:");
            if (!int.TryParse(Console.ReadLine(), out int bookid))
            {
                Console.WriteLine("Enter a valid input");
            }
            Books? books=db.Books.Find(bookid);
            if (books==null)
            {
                Console.WriteLine("Book with such id doesnot exist");
                break;
            }
            Console.WriteLine("\t\t\tChange with");
            Console.WriteLine("Book published date:");
            if(!DateTime.TryParse(Console.ReadLine(),out DateTime userinputdate))
            {
                Console.WriteLine("\t\t\t\t\t\t\tInput datetime");

            }
            Console.WriteLine("Book ISNB:");
            if (!int.TryParse(Console.ReadLine(), out int userinputisnb))
            {
                Console.WriteLine("\t\t\t\t\t\t\tInput isnb");

            }
            Console.WriteLine("Book AuthorID:");
            if (!int.TryParse(Console.ReadLine(), out int userinputauthorid))
            {
                Console.WriteLine("\t\t\t\t\t\t\tInput authorid");

            }
            if (!db.Authors.Any(i => i.Id == userinputauthorid))
            {
                Console.WriteLine("Invalid author id");
            }
            string? userinputidtitle=Console.ReadLine();
            Console.WriteLine("Book Title:");
            if (string.IsNullOrWhiteSpace(userinputidtitle))
            {
                Console.WriteLine("Input book title");
            }
            books.Title = userinputidtitle;
            books.ISBN = userinputisnb;
            books.AuthorID=userinputauthorid;
            books.DateTime = userinputdate;
            
            db.SaveChanges();
            Console.WriteLine("Update of book successfull");
            break;
        case "4":
            Console.WriteLine("Deletion \nID for diletion");
            if (!int.TryParse(Console.ReadLine(), out int idfordel))
            {
                Console.WriteLine("Enter a valid input");
            }
            Books?delbook = db.Books.Find(idfordel);
            if (delbook == null)
            {
                Console.WriteLine("Book with such id doesnot exist");
                break;
            }
            db.Books.Remove(delbook);
            db.SaveChanges();
            Console.WriteLine("Deletion successful");
            break;
        case "5":
            exit = true;
            Console.WriteLine("Exit");
            break;

    }
}



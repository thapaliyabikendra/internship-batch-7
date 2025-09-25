using LibraryManagement.Models;
using System.Data.SQLite;
using System.Xml.Linq;

namespace LibraryManagement.DataAccess;

public class Operation
{
    private readonly string _connectionString = "Data Source=library.db";
    public void CreateAuthor(string country, string name)
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        string insertQuery = @"
            INSERT INTO Authors (Name,Country)
            VALUES ( @name,@country);";

        using var command = new SQLiteCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@country", country);
        command.Parameters.AddWithValue("@name", name);

        command.ExecuteNonQuery();
    }
    public List<Author> ReadAllAuthor ()
    {
        var author= new List<Author>();
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id,Name,Country FROM Authors";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            author.Add(new Author
            {
                Id = Guid.Parse(reader.GetString(0)),
                Name = reader.GetString(1),
                Country=reader.GetString(2)
            });
        }
        return author;
    }
    public void CreateBook(Book book)
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();

        string insertQuery = @"
            INSERT INTO Books (Name,AuthorId,PublishedYear)
            VALUES ( @name,@authorId,@publishedYear);";

        using var command = new SQLiteCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@name",book.Name);
        command.Parameters.AddWithValue("@publishedYear", book.PublishedYear);
        command.Parameters.AddWithValue("@authorId", book.AuthorId);

        command.ExecuteNonQuery();
    }
    public List<Book>ReadAllBooks()
    {
        var book=new List<Book>();
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT Id,Name,AuthorId,PublishedYear FROM Books";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            book.Add(new Book
            {
                Id = Guid.Parse(reader.GetString(0)),
                Name = reader.GetString(1),
                AuthorId = Guid.Parse(reader.GetString(2)),
                PublishedYear = reader.GetInt32(3)
            });
        }
        return book;
    }
    public void UpdateBook(Book book)
    {
        using var connection=new SQLiteConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = @"UPDATE Books SET Name=@Name,PublishedYear=@PublishedYear,AuthorId=@AuthorId Where Id=@Id";
        command.Parameters.AddWithValue("@Name", book.Name);
        command.Parameters.AddWithValue("@PublishedYear", book.PublishedYear);
        command.Parameters.AddWithValue("@AuthorId", book.AuthorId);
        command.Parameters.AddWithValue("@Id", book.Id);

        command.ExecuteNonQuery();

    }
}



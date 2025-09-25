using Contract.Interface.Repositroy;
using Domain.Dto;
using Domain.Entities;
using LibraryManagement.Models;
using System.Data.SQLite;

namespace LibraryManagement.DataAccess
{
    public class AuthorRepository : IAuthorRepo
    {
        private readonly string _connectionString = "Data Source=library.db";

        public void CreateAuthor (string name,string country)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string insertQuery = @"INSERT INTO Authors (Id, Name, Country) VALUES (@id, @name, @country);";
            using var command = new SQLiteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@country",country);
            command.ExecuteNonQuery();
        }

        public List<AuthorEntity> ReadAllAuthor()
        {
            var authors = new List<AuthorEntity>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            using var command = new SQLiteCommand("SELECT Id, Name, Country FROM Authors", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                authors.Add(new AuthorEntity
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    Country = reader.GetString(2)
                });
            }

            return authors;
        }
    }

    public class BookRepository : IBookRepo
    {
        private readonly string _connectionString = "Data Source=library.db";

        public void CreateBook(BookEntity bookEntity)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string insertQuery = @"INSERT INTO Books (Id, Name, AuthorId, PublishedYear) VALUES (@id, @name, @authorId, @published)";
            using var command = new SQLiteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@id", bookEntity.Id);
            command.Parameters.AddWithValue("@name", bookEntity.Title);
            command.Parameters.AddWithValue("@published", bookEntity.PublishedYear);
            command.Parameters.AddWithValue("@authorId", bookEntity.AuthorId);
            command.ExecuteNonQuery();
        }

        //public void Create(BookEntity bookentity)
        //{
        //    throw new NotImplementedException();
        //}

        public List<BookEntity> ReadAllBooks()
        {
            var books = new List<BookEntity>();
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var command = new SQLiteCommand("SELECT Id, Name, AuthorId, PublishedYear FROM Books", connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                books.Add(new BookEntity
                {
                    Id =reader.GetString(0),
                    Title = reader.GetString(1),
                    AuthorId = reader.GetString(2),
                    PublishedYear = reader.GetInt32(3)
                });
            }

            return books;
        }

        public void UpdateBook(BookEntity book)
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            string updateQuery = @"UPDATE Books SET Name=@name, PublishedYear=@published, AuthorId=@auth WHERE Id=@id";
            using var command = new SQLiteCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@id", book.Id);
            command.Parameters.AddWithValue("@name", book.Title);
            command.Parameters.AddWithValue("@published", book.PublishedYear);
            command.Parameters.AddWithValue("@auth", book.AuthorId);
            command.ExecuteNonQuery();
        }


        //List<BookEntity> IBookRepo.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

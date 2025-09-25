using System.Data.SQLite;

namespace LibraryManagement.DataAccess;

public class CreateTable
{
    string createAuthorsTable = @"
    CREATE TABLE IF NOT EXISTS Authors (
        Id INTEGER PRIMARY KEY,
        Name TEXT NOT NULL,
        Country TEXT
    );";

    string createBooksTable = @"
    CREATE TABLE IF NOT EXISTS Books (
        Id TEXT PRIMARY KEY,
        Name TEXT NOT NULL,
        AuthorId INTEGER NOT NULL,
        FOREIGN KEY (AuthorId) REFERENCES Authors(Id) ON DELETE CASCADE
    );";
    string createBorrowerTable = @"
        CREATE TABLE IF NOT EXISTS Borrowers(
        Id  TEXT PRIMARY KEY,
        Name TEXT NOT NULL,
        Email TEXT UNIQUE NOT NULL);";
    private readonly string _connectionString = "Data Source=library.db";
    public CreateTable() 
    {
        using var connection = new SQLiteConnection(_connectionString);
        connection.Open();
        using var authorCreationCmd=new SQLiteCommand(createAuthorsTable, connection);
        authorCreationCmd.ExecuteNonQuery();
        using var bookCreationCmd=new SQLiteCommand(createBooksTable, connection);
        bookCreationCmd.ExecuteNonQuery();

    }    

}

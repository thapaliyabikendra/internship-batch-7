using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_seven.StudentCrud
{
    public class StudentDatabaseManger
    {
        private static SqlConnection cn = new SqlConnection("Data Source=DESKTOP-OFDB3MH;Initial Catalog=amnil;Persist Security Info=True;User ID=nirajan;Password=nir@j@n17");

        public void SimpleSql()
        {
            try
            {
                cn.Open();
                // 1. Create table
                string createTableQuery = @"
                IF OBJECT_ID('Students', 'U') IS NULL
                CREATE TABLE Students (
                    Id INT PRIMARY KEY,
                    FirstName NVARCHAR(50),
                    LastName NVARCHAR(50),
                    Email NVARCHAR(100)
                );";
                new SqlCommand(createTableQuery, cn).ExecuteNonQuery();

                // 2. Insert data (check for duplicates to avoid primary key errors)
                string insertQuery = @"
                IF NOT EXISTS (SELECT 1 FROM Students WHERE Id = 1)
                    INSERT INTO Students VALUES (1, 'John', 'Doe', 'john@example.com');
                IF NOT EXISTS (SELECT 1 FROM Students WHERE Id = 2)
                    INSERT INTO Students VALUES (2, 'Jane', 'Smith', 'jane@example.com');
                IF NOT EXISTS (SELECT 1 FROM Students WHERE Id = 3)
                    INSERT INTO Students VALUES (3, 'Alice', 'Johnson', 'alice@example.com');";
                new SqlCommand(insertQuery, cn).ExecuteNonQuery();

                // 3. Query all students
                Console.WriteLine("All Students:");
                string selectQuery = "SELECT * FROM Students;";
                using (SqlCommand cmd = new SqlCommand(selectQuery, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Email: {reader["Email"]}");
                    }
                }

                // 4. Update one email
                string updateQuery = "UPDATE Students SET Email='john.doe@example.com' WHERE Id=1;";
                new SqlCommand(updateQuery, cn).ExecuteNonQuery();

                // 5. Delete one student
                string deleteQuery = "DELETE FROM Students WHERE Id=2;";
                new SqlCommand(deleteQuery, cn).ExecuteNonQuery();

                // 6. Show final state
                Console.WriteLine("\nAfter Update & Delete:");
                using (SqlCommand cmd = new SqlCommand(selectQuery, cn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["FirstName"]} {reader["LastName"]}, Email: {reader["Email"]}");
                    }
                }

                cn.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

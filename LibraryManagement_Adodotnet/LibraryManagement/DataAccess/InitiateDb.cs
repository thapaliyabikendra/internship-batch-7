using System;

namespace LibraryManagement.DataAccess
{
    public class InitiateDb
    {
        public void Initialize()
        {
            try
            {
                var tableCreator = new CreateTable();
                Console.WriteLine("Database initialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database initialization failed: {ex.Message}");
            }
        }
    }
}
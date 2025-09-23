using assignment_seven.CSVAndJSON;
using assignment_seven.LoggingHelper;
using assignment_seven.StudentCrud;
using assignment_seven.TextFileProcessor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace assignment_seven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //common path name
            string folderNameCommon = @"G:\Amnil_Intern\project\internship-batch-7\assignment_seven\assignment_seven\";

            #region Task 1 - Text File Processor

            //string folderName12 = "TextFileProcessor";
            string folderName1 = $"{folderNameCommon}TextFileProcessor";
            string fileName1 = "sample.txt";

            // create file
            FileCreator.CreateFile(folderName1, fileName1);

            // ask user for word to search
            Console.Write("Enter word to search :");
            string wordToSearch = Console.ReadLine();

            // process the file
            FileProcessor.ProcessFile(folderName1, fileName1,wordToSearch);

            #endregion

            #region Task 2 - Logging Helper

            Console.WriteLine();

            // folder making
            string folderName2 = $"{folderNameCommon}LoggingHelper";
            string fileNameOfLogging = "app.log";

            Logger.LogFolder(folderName2,fileNameOfLogging);

            //passing string message and level to Logger class
            Logger.Log("File Processed Successfully.", "INFO");
            Logger.Log("Word not found in file.", "WARN");
            Logger.Log("Failed to open file.", "ERROR");

            Console.WriteLine("Logs is written successfully to app.log.");
            #endregion

            #region Task 3 - CSV And Json Basic

            Console.WriteLine();

            string csvPath = "students.csv";
            string jsonPath = "student.json";
            
            // create CSV file 
            StudentCsv.CreateCsv(csvPath);

            //Read Csv and parse students
            List<Student> students = StudentCsv.ReadStudentsFromCsv(csvPath);

            // convert to Json
            string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true});

            // save Json to file
            File.WriteAllText(jsonPath, jsonString);

            Console.WriteLine($"Student from CSV to Json saved to {jsonPath}.");

            #endregion

            #region Task 4 - Simple SQL Queries

            Console.WriteLine();
            StudentDatabaseManger sdm = new StudentDatabaseManger();
            sdm.SimpleSql();

            #endregion
        }
    }
}

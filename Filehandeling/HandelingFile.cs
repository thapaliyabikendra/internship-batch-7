using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Filehandeling;

 public class InfoAboutText
{
    public void TextProcessing()
    {
        string file;
        try
        {

            file = File.ReadAllText(@"C:\Users\Subes\OneDrive\Desktop\Subesh\internship-batch-7\Filehandeling\text.txt").ToString();
        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("FilePath Wroung");
            return;
        }
        int charCount = file.Length;
        Console.WriteLine($"Character :{charCount.ToString()}");
        var wordCount = file.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine($"Words:{wordCount.Count().ToString()}");
        var lineCount = file.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine($"Lines:{lineCount.Count()}");
        string wordToSearch = "intern";
        Console.WriteLine("WordFound at index:");
        for (int i = 0; i < wordCount.Length; i++)
        {
            if (wordCount[i] == wordToSearch)
            {
                Console.WriteLine(i+1);
            }
        }
        Console.WriteLine("Word found at line:");
        for (int i = 0; i < lineCount.Length; i++)
        {
            var wordInLine=lineCount[i].Split(" ",StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < wordInLine.Length; j++)
            {
                if(wordInLine[j] == wordToSearch)
                    Console.WriteLine(i);
            }
        }





    }

}
public class LogingHelper
{
    public void Logger(string message,string level)
    {
        string path = @"C:\Users\Subes\OneDrive\Desktop\Subesh\internship-batch-7\Filehandeling\logrecorder.txt";
        string fullMessage = $"{DateTime.Now} :[{level}] {message}";
        File.WriteAllText(path, fullMessage);
    }
}
class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
}

public class CsvToJsonConverter
{
    public void Convert()
    {
        string csvPath = @"C:\Users\Subes\OneDrive\Desktop\Subesh\internship-batch-7\Filehandeling\demo.csv";
        string jsonPath = @"C:\Users\Subes\OneDrive\Desktop\Subesh\internship-batch-7\Filehandeling\dem.json";

        var lines = File.ReadAllLines(csvPath).Skip(1);
        var students = new List<Student>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            students.Add(new Student
            {
                Id = int.Parse(parts[0]),
                FirstName = parts[1],
                LastName = parts[2],
                Email = parts[3]
            });
        }

        var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(jsonPath, json);
        string jsonContent=File.ReadAllText(jsonPath);
        List<Student>?studentList = JsonSerializer.Deserialize<List<Student>>(jsonContent);
        if (studentList == null)
        {
            Console.WriteLine("No Student list avilable in json file");
            return;
        }
        var studentsearch = studentList.Where(s => s.Email == "aarav.shrestha@example.com");
        foreach (var student in studentsearch)
        {
            Console.WriteLine($"ID: {student.Id}");
            Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
        }


    }
}

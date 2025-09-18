using System.Text.Json;

namespace Consoleapp.WorkwithJson;

public class Program
{
    static void Main(string[] args)
    {
        string csvFile = "student.csv";
        string[] lines = File.ReadAllLines(csvFile);

        List<Student> students = new List<Student>();

        for (int i = 1; i < lines.Length; i++) // skip header row
        {
            string[] parts = lines[i].Split(','); // split by comma

            Student s = new Student
            {
                Id = int.Parse(parts[0]),
                FirstName = parts[1],
                LastName = parts[2],
                Email = parts[3]
            };

            students.Add(s);
        }

        string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("students.json", jsonString);

        Console.WriteLine("JSON file created successfully!");

        JsonTask();


    }

    public static void JsonTask()
    {
        
        string jsonString = File.ReadAllText("students.json");

        // Deserialize JSON into List<Student>
        List<Student> students = JsonSerializer.Deserialize<List<Student>>(jsonString);

        string searchEmail = "jane@example.com";
        Student foundStudent = students.Find(s => s.Email.ToLower() == searchEmail.ToLower());

        if (foundStudent != null)
        {
            Console.WriteLine($"Student found: {foundStudent.FirstName} {foundStudent.LastName}, Email: {foundStudent.Email}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

        char startingLetter = 'J';
        int count = students.Count(s => s.FirstName.ToUpper().StartsWith(startingLetter));

        Console.WriteLine($"Number of students whose first name starts with '{startingLetter}': {count}");
    }
}

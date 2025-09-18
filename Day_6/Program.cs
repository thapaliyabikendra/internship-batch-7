using Day_6;

List<Student> students = new List<Student>
{
    new Student { Id = 1, Name = "Alice", Age = 20, Gender = "Female", Marks = 85, City = "New York" },
    new Student { Id = 2, Name = "Bob", Age = 22, Gender = "Male", Marks = 78, City = "Chicago" },
    new Student { Id = 3, Name = "Charlie", Age = 19, Gender = "Male", Marks = 92, City = "New York" },
    new Student { Id = 4, Name = "Diana", Age = 21, Gender = "Female", Marks = 88, City = "Los Angeles" },
    new Student { Id = 5, Name = "Ethan", Age = 20, Gender = "Male", Marks = 65, City = "Chicago" },
};
List<Student> student = new List<Student>
{
    new Student { Id = 3, Name = "Alice", Age = 20, Gender = "Female", Marks = 85, City = "New York" },
    new Student { Id = 4, Name = "Bob", Age = 22, Gender = "Male", Marks = 78, City = "Chicago" },
    new Student { Id = 5, Name = "Charlie", Age = 19, Gender = "Male", Marks = 92, City = "New York" },
    new Student { Id = 6, Name = "Diana leo", Age = 21, Gender = "Female", Marks = 88, City = "Los Angeles" },
    new Student { Id = 7, Name = "Ethan Christ", Age = 20, Gender = "Male", Marks = 65, City = "Chicago" },
};
/*
 * 1. Select all student names from the list.
2. Find students who scored more than 80 marks.
3. Retrieve the first student whose name starts with "C".
4. Sort students by marks in descending order.
5. Count the number of male and female students.
6. Group students by city and display the total number of students in each city.
7. Calculate the average marks of all students.
8. Find the student(s) with the highest marks.
9. Check if any student has marks less than 50.
10. Create a list of students containing only `Name` and `City`.
### **Optional Challenge:**
11. Find the top 3 students with the highest marks.
12. Display students aged between 20 and 22, ordered by age.
13. Combine two lists of students and remove duplicates based on `Id`.
 */
var listStudent=students.Select(student => student.Name).ToList();
var listStudentusingQuary = from s in students select s.Name;


var studentScoredMoreThan80 = students.Where(s => s.Marks > 80).ToList();
var studentScoredMoreThan80UsingQuary = from s in students where s.Marks > 80 select s;



//var studentWithCAsStarting = students.Where(s => (s.Name[0] == 'C'));
var studentWithCAsStarting = students.Where(s => s.Name.StartsWith("C")).ToList();
var studentWithCAsStartingUsingQuary = from s in students where s.Name.StartsWith("C") select s;



var studentInDescAccordingToMark=students.OrderByDescending(s => s.Marks).ToList();
var studentInDescAccordingToMarkUsinQuary=from s in student orderby s.Marks select s;



//var femaleStudent = students.CountBy(s => s.Gender == "Female");
//var maleStudent = students.CountBy(s => s.Gender == "Male");
var groupByGender = students.GroupBy(s => s.Gender).Select(group => new {Gender = group.Key,Count = group.Count()}).ToList();
var groupByGenderUsingQuary=from s in students group s by s.Gender;


var groupByCity = students.GroupBy(s => s.City).Select(group => new
{
    City = group.Key,
    Count = group.Count()
});
var groupByCityUsingQuary = from s in student group s by s.City into cityGroup select new{ City = cityGroup.Key,Count = cityGroup.Count() };



var averageMark=students.Average(s => s.Marks);
var averageMarkUsingQuery = (from s in students select s.Marks).Average();


var studentWithMarkLessThan50=students.Where(s => s.Marks <50).ToList();
var studentWithMarkLessThan50UsingQuery = from s in students where s.Marks < 50 select s;


var studentWithNameAndCity=students.Select(s => $"{s.Name} from {s.City}").ToList();
var studentWithNameAndCityUsingQuary = from s in students select new { s.Name, s.City };



var top3Student=students.OrderByDescending(s=>s.Marks).Take(3).ToList();
var studentsBetween20And22 = students.Where(s => s.Age >= 20 && s.Age <= 22).OrderBy(s => s.Age).ToList();

var combinedList =students.Concat(student).GroupBy(s => s.Id).Select(g => g.First()).ToList();

var methodSyntaxResults = new List<(string Name, List<Student> Students)>
{
    ("studentScoredMoreThan80", studentScoredMoreThan80),
    ("studentWithCAsStarting", studentWithCAsStarting),
    ("studentInDescAccordingToMark", studentInDescAccordingToMark),
    ("studentWithMarkLessThan50", studentWithMarkLessThan50),
    ("top3Student", top3Student),
    ("studentsBetween20And22", studentsBetween20And22),
    ("combinedList", combinedList)
};
Console.WriteLine("Group Based On City");
foreach (var item in groupByCity)
{
    Console.WriteLine($"City: {item.City}, Count: {item.Count}");
}
Console.WriteLine("\nGroup Based on Gender");
foreach (var item in groupByGender)
{
    Console.WriteLine($"City: {item.Gender}, Count: {item.Count}");
}
Console.WriteLine("\nName Of Student");
foreach (var sName in listStudent)
{
    Console.WriteLine($"Name Of Student are:{sName}");
}
Console.WriteLine("\nName of Student with City Name");
foreach (var item in studentWithNameAndCity)
{
    Console.WriteLine(item);
}
foreach (var result in methodSyntaxResults)
{
    Console.WriteLine($"\n\t\t\t{result.Name}");

    foreach (var studentList in result.Students)
    {
        Console.WriteLine($"Id: {studentList.Id}, Name: {studentList.Name}, Age: {studentList.Age}, Gender: {studentList.Gender}, Marks: {studentList.Marks}, City: {studentList.City}");
    }

    Console.WriteLine();
}
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Student.linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
        new Student { Id = 1, Name = "Alice", Age = 20, Gender = "Female", Marks = 85, City = "New York" },
        new Student { Id = 2, Name = "Bob", Age = 22, Gender = "Male", Marks = 78, City = "Chicago" },
        new Student { Id = 3, Name = "Charlie", Age = 19, Gender = "Male", Marks = 92, City = "New York" },
        new Student { Id = 4, Name = "Diana", Age = 21, Gender = "Female", Marks = 88, City = "Los Angeles" },
        new Student { Id = 5, Name = "Ethan", Age = 20, Gender = "Male", Marks = 65, City = "Chicago" },
        };

        //select all students name from list
        var names=students
                          .Select(student => student.Name)
                          .ToList();

        Console.WriteLine("The name of students in the list are: ");
            
            foreach (var name in names)
            {
                Console.WriteLine($"{name}");
            }
            

        //Find the student who scored more than 80 marks
        var studentWhoScoredMoreThanEighty=students
                                                   .Where(m=>m.Marks>80)
                                                   .ToList();

        Console.WriteLine("\nThe students who scored more than 80 are: ");

        foreach (var student in studentWhoScoredMoreThanEighty)
        {
            Console.WriteLine($"{student.Name} scored : {student.Marks}");
        }


        //Retrieve the first student whose name starts with "C".
        var studentWhoseNameStartWithC = students
                                                 .Where(s => s.Name[0] == 'C')
                                                 .FirstOrDefault();

        Console.WriteLine("\nThe first student whose name stary with C is " + studentWhoseNameStartWithC.Name);

        //Sort students by marks in descending order.
        var studentMarksInDescendingOrder = students
                                                    .OrderByDescending(m => m.Marks)
                                                    .ToList();

        Console.WriteLine("\nThe student marks in descending order");
        foreach (var student in studentMarksInDescendingOrder)
        {
            Console.WriteLine($"{student.Name} scored : {student.Marks}");
        }

        //Count the number of male and female students.

        var countMaleStudents = students.Where(g => g.Gender.ToLower() == "male").Count();
        Console.WriteLine("\nThe count of male students is: "+countMaleStudents);

        var countFemaleStudents = students.Where(g => g.Gender.ToLower() == "female").Count();
        Console.WriteLine("\nThe count of female students is: " + countFemaleStudents);



        //Group students by city and display the total number of students in each city.

        var studentCountByCity= from s in students
                                group s by s.City into cityGroup
                                select new
                                {
                                    City = cityGroup.Key,
                                    Count = cityGroup.Count()
                                };

        foreach (var student in studentCountByCity)
        {
            Console.WriteLine($"{student.City} has count : {student.Count}");
        }


        //Calculate the average marks of all students.

        var studentMarksAverage = students.Average(s => s.Marks);

        Console.WriteLine($"Average marks of all students: {studentMarksAverage}");


        //Find the student(s) with the highest marks.

        var studentWithHighestMarks = students
                                              .OrderByDescending(m => m.Marks)
                                              .FirstOrDefault();

        Console.WriteLine($"\nThe student with highest marks is: {studentWithHighestMarks.Name} with marks {studentWithHighestMarks.Marks}");


        //Check if any student has marks less than 50.

        var countStudentWithMarksLessThanFifty = students
                                              .Where(m => m.Marks<50)
                                              .Any();
        if (countStudentWithMarksLessThanFifty)
        {
            Console.WriteLine("\nThere is student with marks less than 50");
        }
        if (!countStudentWithMarksLessThanFifty)
        {
            Console.WriteLine("\nAll students has marks greater than 50");
        }



        //Create a list of students containing only `Name` and `City`.

        

        List<Student> newStudents = new List<Student>();


        foreach (var student in students)
        {
            newStudents.Add(new Student
            {
                Name = student.Name,
                City = student.City
            });
        }
        Console.WriteLine("\n");
        foreach (var s in newStudents)
        {
            Console.WriteLine($"The student name is {s.Name} and the city is {s.City}");
        }


        //Find the top 3 students with the highest marks.
        var top3Students = students
                                    .OrderByDescending(s => s.Marks)
                                    .Take(3)
                                    .ToList();

        foreach (var student in top3Students)
        {
            Console.WriteLine($"{student.Name} - {student.Marks}");
        }



        //Display students aged between 20 and 22, ordered by age.

        var studentsBetween20And22 = students
                                        .Where(s => s.Age >= 20 && s.Age <= 22)
                                        .OrderBy(s => s.Age)
                                        .ToList();//orderby by default is ascending

        foreach (var student in studentsBetween20And22)
        {
            Console.WriteLine($"{student.Name} has age  {student.Age}");
        }

        //Combine two lists of students and remove duplicates based on `Id`.

        List<Student> students2 = new List<Student>
            {
                new Student { Id = 3, Name = "Charlie", Age = 19, Gender = "Male", Marks = 92, City = "New York" }, // duplicate Id
                new Student { Id = 6, Name = "Fiona", Age = 23, Gender = "Female", Marks = 81, City = "Boston" },
                new Student { Id = 7, Name = "George", Age = 21, Gender = "Male", Marks = 74, City = "Seattle" }
            };

        var combinedStudents = students
                                .Concat(students2)
                                .GroupBy(s => s.Id)
                                .Select(g => g.First())   // keep first student with that Id
                                .ToList();

                                    Console.WriteLine("\nCombined list without duplicates:");
                                    foreach (var student in combinedStudents)
                                    {
                                        Console.WriteLine($"{student.Id} - {student.Name} - {student.City}");
                                    }
                                }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_three
{
    public class student
    {
        //max input
        const int maxStudents = 100;
        const int maxGrade = 12;
        
        //input student name and number of class like class 1, class 2 
        static string[] studentName = new string[maxStudents];
        static int[] classesNumber= new int[maxGrade];

        static double[,] studentGrades = new double[maxStudents,maxGrade];

        //store in local variable
        static int countStudent = 0;
        static int countClass = 0;

        public static void AddStudent()
        {
            if (countStudent >= maxStudents)
            {
                Console.WriteLine("Student cannot be added");
                return;
            }
            else
            {
                Console.Write("Enter the Student Name :");
                string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Please insert Student Name !");
                    return;
                }
                else
                {
                    studentName[countStudent] = name;
                    countStudent++;
                    Console.WriteLine($"Student {name} added successfully.");
                }

            }
        }
        public static void AddGrade()
        {
            if (countClass >= maxGrade)
            {
                Console.WriteLine("Student Study Class cannot be added !");
                return ;
            }
            else
            {
                Console.Write("Enter Class Number :");
                string classInput=Console.ReadLine();

                if (int.TryParse(classInput, out int classno))
                {
                    if (classno >= 12)
                    {
                        Console.WriteLine("Class number must be between 1 to 12 !");
                        return;
                    }
                    else
                    {
                        classesNumber[countClass] = classno;
                        countClass++;
                        Console.WriteLine($"Class {classno} added successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter number only 1 to 12 only");
                }

                
            }

        }

        // validation the marks
        static double gradeValidation(string classNumber) 
        {
            double grade;
            while (true)
            {
                Console.Write(classNumber);
                if (double.TryParse(Console.ReadLine(),out grade) && grade >=0 && grade <= 100)
                {
                    return grade;
                }
                else
                {
                    Console.WriteLine("Grade must be between 0 to 100 !");
                }
            }
        }
        public static void EnterGrades()
        {
            if (countStudent == 0 || countClass == 0)
            { 
                Console.WriteLine("Add student First and Add Class First !");
                return;
            }
            else
            {
                for (int i = 0; i < countStudent; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($" Student Name : {studentName[i]} ");
                    for (int j = 0; j < countClass; j++)
                    {
                        studentGrades[i, j] = gradeValidation($" Enter Student Class {classesNumber[j]} marks :");
                    }
                }
            }
            
        }

        //for letter grades
        static string letterGrade(double average)
        {
            if (average >= 90)
            {
                return "A";
            }
            else if (average >= 80)
            {
                return "B";
            }
            else if (average >= 70)
            {
                return "C";
            }
            else if (average >= 60)
            {
                return "D";
            }
            else return "Failed";
            
        }
        public static void ViewReport()
        {
            if (countStudent == 0 || countClass == 0)
            {
                Console.WriteLine("------- No data available -----");
                return;
            }
            else
            {
                Console.WriteLine("Student Report");
                Console.WriteLine("---------------");

                double classTotal = 0;
                double[] averageList= new double [countStudent];
                int topStudent = 0;
                int bottomStudent = 0;

                for (int i = 0; i < countStudent; i++)
                {
                    double total = 0;
                    for (int j = 0; j < countClass; j++)
                    {
                        total = total + studentGrades[i, j];
                    }

                    double average = total / countClass;
                    averageList[i] = average;
                    classTotal = classTotal + average;

                    Console.WriteLine($"Student Name : {studentName[i]}");
                    Console.WriteLine($"Average: {average}");
                    Console.WriteLine($"Letter Grades : {letterGrade(average)}");
                    Console.WriteLine();
                    //top student and button student 
                    if (average > averageList[topStudent])
                    {
                        topStudent = i;
                    }
                    if (average < averageList[bottomStudent])
                    {
                        bottomStudent = i;
                    }
                }
                    //class statistics
                    double classAverage = classTotal / countStudent;

                    Console.WriteLine();
                    Console.WriteLine("Class Statistics");
                    Console.WriteLine("------------------");
                    Console.WriteLine($"Class Average : {classAverage}");
                    Console.WriteLine($"Top Student : {studentName[topStudent]} = {averageList[topStudent]}");
                    Console.WriteLine($"Bottom Student : {studentName[bottomStudent]} = {averageList[bottomStudent]}");
                }


        }

    }
}

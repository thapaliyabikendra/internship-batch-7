using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_3;

public class Students
{

    static string[] studentNames = new string[100];
    static int[][] studentGrade = new int[100][];
    static int studentCount = 0;
    static void Main(string[] args)
    {
        bool Exit = false;
        while (!Exit)
        {
            Console.WriteLine("Student Recorde\n");
            Console.WriteLine("1.Add students");
            Console.WriteLine("2.Enter Grade");
            Console.WriteLine("3.View Reports");
            Console.WriteLine("4.Exit");
            switch (Console.ReadLine())
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    EnterGrade();
                    break;
                case "3":
                    ViewReport();
                    break;
                case "4":
                    Exit=true;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;

            }
        }
    }
    static void AddStudent()
    {
        Console.WriteLine("Enter name of student:");
        string ?name;
        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()))
        {
            Console.WriteLine("Invalid input, please enter a non-empty string:");
        }

        studentNames[studentCount] = name;
        studentGrade[studentCount] = new int[0];
        studentCount++;
        Console.WriteLine($"Student {name} is added");
    }
    static void EnterGrade()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("No student avilable");
            return;
        }
        for(int i = 0;i < studentCount; i++)
        {
            Console.WriteLine($"Enter Grade for:{studentNames[i]}");
            Console.WriteLine("No of Grade for a students");
            int gradecount;
            while (!int.TryParse(Console.ReadLine(), out gradecount)||gradecount<=0)
            {
                Console.WriteLine("Invalid input, please enter a number:");
            }
            int[] grades = new int[gradecount];
            for(int j = 0; j < gradecount; j++)
            {
                int grade;
                Console.WriteLine($"For Grade {j + 1}");
                while (!int.TryParse(Console.ReadLine(), out grade)|| grade < 0||grade > 100)
                {
                    Console.WriteLine("Invalid input, please enter a number between 0 and 100:");
                }
                grades[j]=grade;

            }
            studentGrade[i]=grades;


        }

    }
    static void ViewReport()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("No Students");
            return;
        }
        double classTotal = 0;
        double classGradeCount = 0;
        double higestAvg = 0;
        double lowestAvg = 0;
        string topStudent = "";
        string bottomStudent = "";
        Console.WriteLine("Report");
        for (int i = 0; i < studentCount; i++)
        {
            int[] grade = studentGrade[i];
            if (grade.Length == 0)
            {
                Console.WriteLine($"{studentNames[i]}: No grades entered.");
                continue;
            }
            double avg=CalculateAverage(grade);
            string letter = GetLetterGrade(avg);
            Console.WriteLine($"{studentNames[i]}\n Avg:{avg:F2},Grade:{letter}");
            classTotal += avg;
            if (avg > higestAvg)
            {
                higestAvg= avg;
                topStudent=studentNames[i];
            }
            if (avg < lowestAvg) { 
            
                lowestAvg= avg;
                bottomStudent=studentNames[i];
            }
        }
        if (classGradeCount > 0)
        {
            double classAvg = classTotal / classGradeCount;
            Console.WriteLine("\n--- Class Statistics ---");
            Console.WriteLine($"Class Average: {classAvg:F2}");
            Console.WriteLine($"Top Performer: {topStudent} ({higestAvg:F2})");
            Console.WriteLine($"Lowest Performer: {bottomStudent} ({lowestAvg:F2})");
        }
    }
    static double CalculateAverage(int[] grades)
    {
        double sum = 0;
        foreach (int g in grades)
            sum += g;
        return sum / grades.Length;
    }
    static string GetLetterGrade(double avg)
    {
        if (avg >= 90) return "A";
        if (avg >= 80) return "B";
        if (avg >= 70) return "C";
        if (avg >= 60) return "D";
        return "F";
    }
}

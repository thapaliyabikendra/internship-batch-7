using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2;

     class Students 
{
    private string studentName;
    private int studentId;
    private int studentAge;
    private double studentGpa;
    private bool enrolled;
    private char studentGrade;
    public Students(string name,int id,int age,double gpa,bool enroll,char grade) {
    studentName = name;
    studentId = id;
    studentAge = age;
    studentGpa = gpa;
    enrolled = enroll;
    studentGrade= grade;
    }
    public int AgeInDays() 

    {
        int leapYear = studentAge /4;
        return studentAge * 365+leapYear;
    }
    public void DisplayStudentInformation()
    {
        Console.WriteLine("The Name Of Student is:"+studentName);
        Console.WriteLine($"With StudentID:{studentId}");
        Console.WriteLine($"With age of:{studentAge}");
        Console.WriteLine($"having Gpa {studentGpa}");
        Console.WriteLine("in grade"+studentGrade);
        Console.WriteLine("is found Enrolled to be"+enrolled);
          
    }
    public void AgeInMinutesAndHours()
    {
        int days=AgeInDays();
        Console.WriteLine($"Age in Hours:{days*24} \nAge in Minutes:{days*24*60}");
    }

}


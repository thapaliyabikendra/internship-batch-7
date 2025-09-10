using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student infomation");
            Console.WriteLine("-------------------");

            student_details();
        }

        static void student_details()
        {
       
            //declare variable for student info
            string studentName; //

            int studentAge;
            string studentAgeInput;

            double gpa;
            string gpaInput;

            bool isEnrolled;
            string isEnrolledInput;

            char gradeLevel = ' ';
            string gradeInput;

            DateTime birthDate;
            string birthInput;

            Console.WriteLine("Student Entry");
            Console.WriteLine("------------------");

            #region => Q1

            //for name
            Console.Write("Enter your name :");
            studentName = Console.ReadLine();

            //age
            Console.Write("Enter your age (only numbers) :");
            studentAgeInput =Console.ReadLine();
            if (int.TryParse(studentAgeInput, out studentAge))
            {
                Console.WriteLine($"{studentAge}");
            }
            else
            {
                Console.WriteLine("Invalid age !");
            }

            //gpa
            Console.Write("Enter your gpa (only numbers) :");
            gpaInput = Console.ReadLine();
            if (double.TryParse(gpaInput, NumberStyles.Any, CultureInfo.InvariantCulture, out gpa))
            {
                Console.WriteLine($"{gpa}");
            }
            else
            {
                Console.WriteLine("Invalid gpa !");
            }
            
            // enrolled
            Console.Write("Enter your isEnrolled (only True and False) :");
            isEnrolledInput = Console.ReadLine();

            if (bool.TryParse(isEnrolledInput, out isEnrolled))
            {
                Console.WriteLine($"{isEnrolled}");
            }
            else
            {
                Console.WriteLine("Invalid Enrolle ! Take only True and False !");
            }

            //grade
            Console.Write("Enter your grade (Only [A-Z]) :");
            gradeInput = Console.ReadLine();
            if (gradeInput != null && gradeInput.Length == 1 && char.IsLetter(gradeInput[0]))
            {
                gradeLevel = gradeInput[0];
                Console.WriteLine($"{gradeLevel}");
            }
            else { 
                Console.WriteLine("Invalid grade. Grade level should be [A-Z]");
            }
            #endregion

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Student Age Calculation in days");
            Console.WriteLine("-------------------------------------");

            #region => Q3 answer
            Console.Write("Enter your date of birth (yyyy-MM-dd): ");
            birthInput = Console.ReadLine();

            //check condition
            bool dateAgeFormat = DateTime.TryParse(birthInput, out birthDate);

            if (dateAgeFormat)
            {
                DateTime currentDate = DateTime.Today;
                TimeSpan ageTimeSpan = currentDate - birthDate;
                studentAge = (int)ageTimeSpan.TotalDays;

                Console.WriteLine($"your are {studentAge} days old.");
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
            #endregion

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Student All Information");
            Console.WriteLine("---------------------------");

            #region => Q4 answer
            Console.WriteLine($"Student Name : {studentName}");
            Console.WriteLine($"Student age : {studentAge} days");
            Console.WriteLine($"Student gpa : {gpa}");
            Console.WriteLine($"Student Enrolled Status : {isEnrolled}");
            Console.WriteLine($"Student Grade Level : {gradeLevel}");
            #endregion

            #region => Q5
            //string studentName; //
            //int studentAge;
            //double gpa;
            //bool isEnrolled;
            //char gradeLevel = ' ';
            // => I used for hold the value in local variable with their respectively datatype.

            //DateTime birthDate;
            //string birthInput;

            //string studentAgeInput;
            //string gpaInput;
            //string isEnrolledInput;
            //string gradeInput;
            // => I used for store raw input value. Mainly this is for validation. 

            // I use if statement for validation with respective cast(int,double, boolean) and i used out keyword to set the value if condition is meet.

            #endregion

        }

    }
}

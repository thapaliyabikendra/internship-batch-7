using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace assignment_three
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool status = true;

            while (status)
            {
                Console.WriteLine("select menu options :\n1. Add Student\n2. Add Class\n3. Enter Grades(marks)\n4. View Reports\n5. Exit");
                Console.WriteLine();
                Console.WriteLine("----------------------------");

                int choose = int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        student.AddStudent();
                        break;

                    case 2:
                        student.AddGrade();
                        break;

                    case 3:
                        student.EnterGrades();
                        break;

                    case 4:
                        student.ViewReport();
                        break;

                    case 5:
                        status = false;
                        Console.WriteLine("Exit");
                        break;

                    default:
                        Console.WriteLine("Please choice  1 to 5 number !");
                        break;
                }

                Console.WriteLine("----------------------------");
                Console.WriteLine();


            }

        }
    }
}

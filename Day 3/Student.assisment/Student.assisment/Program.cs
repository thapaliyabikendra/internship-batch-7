using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace Student.assisment;

internal class Program
{
    static void Main(string[] args)
    {
        bool continueLoop = true;
        List<string> studentName = new List<string>();
        List<double[]> allMarks = new List<double[]>();
        do
        {
            try
            {
                Console.WriteLine("=========================Select From the Options========================== ");
                Console.WriteLine("1.Add Students");
                Console.WriteLine("2.Enter Grades");
                Console.WriteLine("3.View Student Report");
                Console.WriteLine("4.View Class Report");
                Console.WriteLine("5.Exit");

                Console.WriteLine("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent(studentName, allMarks);
                        break;

                    case 2:

                        AddGrade(studentName, allMarks);
                        break;


                    case 3:
                        ViewIndividualReport(studentName, allMarks);
                        break;
                    case 4:

                        ViewClassReport(studentName, allMarks);
                        break;

                    case 5:
                        Console.WriteLine("Thankyou for using our system");
                        continueLoop = false;
                        break;

                    default:
                        Console.WriteLine("choose the correct option");
                        break;

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("the error occured: " + ex.Message);

            }

        } while (continueLoop);

    }


    public static void AddStudent(List<string> studentName, List<double[]> allMarks)
    {
        while (true)
        {

            Console.WriteLine("Enter the new student name ");
            string name = Console.ReadLine();

            bool isPresent = false;
            foreach (var Student in studentName)
            {
                if (Student == name)
                {
                    isPresent = true;
                }
            }

            if (!isPresent)
            {
                studentName.Add(name);
                allMarks.Add(new double[3]);
                Console.WriteLine("Student Added");
                break;
            }
            else
            {
                Console.WriteLine("The student is already present in database");
            }
        }
    }


    public static void AddGrade(List<string> studentName, List<double[]> allMarks)
    {
        while (true)
        {
            Console.WriteLine("Enter the student name of which grade you want to add");
            string name = Console.ReadLine();
            string[] subjectsList = { "Maths", "Science", "English" };
            int studentIndex = -1;

            for (int i = 0; i < studentName.Count; i++)
            {
                if (studentName[i].ToLower() == name.ToLower())
                {
                    studentIndex = i;
                    break;
                }
            }

            if (studentIndex == -1)
            {
                Console.WriteLine("Stuent not found");
                break;
            }
            else
            {

                double[] grades = new double[3];
                for (int i = 0; i < subjectsList.Length; i++)
                {
                    while (true)
                    {

                        try
                        {

                            Console.WriteLine($"Enter the grade of student in {subjectsList[i]}");
                            double marks = double.Parse(Console.ReadLine());

                            if (marks <= 100 && marks >= 0)
                            {
                                grades[i] = marks;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("the marks must be in between 0 and 100");

                            }
                        }
                        catch
                        {
                            Console.WriteLine("Enter the valid input ");


                        }

                    }
                }

                allMarks[studentIndex] = grades;
                break;
            }
        }

        Console.WriteLine("grades added");
    }


    public static void ViewIndividualReport(List<string> studentName, List<double[]> allMarks)
    {
        while (true)
        {
            Console.WriteLine("Enter the student name of which grade you want to view");
            string name = Console.ReadLine();
            string[] subjectsList = { "Maths", "Science", "English" };
            int studentIndex = -1;

            for (int i = 0; i < studentName.Count; i++)
            {
                if (studentName[i].ToLower() == name.ToLower())
                {
                    studentIndex = i;
                    break;
                }
            }

            if (studentIndex == -1)
            {
                Console.WriteLine("Stuent not found!!!!!");
                break;
            }
            else
            {
                Console.WriteLine("====================Student Report============================");
                Console.WriteLine($"Student Name: {studentName[studentIndex]}");
                Console.WriteLine($"Grade in Maths: {allMarks[studentIndex][0]}");
                Console.WriteLine($"Grade in Science: {allMarks[studentIndex][1]}");
                Console.WriteLine($"Grade in English: {allMarks[studentIndex][2]}");
                double avg = (allMarks[studentIndex][0] + allMarks[studentIndex][1] + allMarks[studentIndex][2]) / 3;
                Console.WriteLine($"Average Marks is: {avg}");


                string finalGrade;

                if (avg >= 90)
                    finalGrade = "A+";
                else if (avg >= 80)
                    finalGrade = "A";
                else if (avg >= 70)
                    finalGrade = "B";
                else if (avg >= 60)
                    finalGrade = "C";
                else if (avg >= 50)
                    finalGrade = "D";
                else
                    finalGrade = "F";

                Console.WriteLine($"Grade: {finalGrade}");
                break;
            }
        }

    }

    public static void ViewClassReport(List<string> studentName, List<double[]> allMarks)
    {
        List<double> allMarksavg = new List<double>();
        foreach (var gradelist in allMarks)
        {
            double averageGrade = (gradelist[0] + gradelist[1] + gradelist[2]) / 3;

            allMarksavg.Add(averageGrade);

        }

        double total = 0;
        double minGrade = allMarksavg[0];
        double maxGrade = allMarksavg[0];
        int minStudentIndex = 0;
        int maxStudentIndex = 0;

        for (int i = 0; i < allMarksavg.Count; i++)
        {
            total = total + allMarksavg[i];

            if (allMarksavg[i] > maxGrade)
            {
                maxGrade = allMarksavg[i];
                maxStudentIndex = i;
            }

            if (allMarksavg[i] < minGrade)
            {
                minGrade = allMarksavg[i];
                minStudentIndex = i;
            }
        }

        double classAvg = total / allMarksavg.Count;
        string studentWithMaxGrade = studentName[maxStudentIndex];
        string studentWithMinGrade = studentName[minStudentIndex];

        Console.WriteLine("=================Class Result======================");
        Console.WriteLine($"The class average is: {classAvg}");
        Console.WriteLine($"The First Student is: {studentWithMaxGrade} and Grade obtained is {maxGrade}");
        Console.WriteLine($"The last Student is: {studentWithMinGrade} and Grade obtained is{minGrade}");
        Console.WriteLine("====================================================");
    }
}

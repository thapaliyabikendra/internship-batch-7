namespace Student.Information;

internal class Program
{
    /// <summary>
    /// This program displays basic information about a student,
    /// including their name, age, GPA, enrollment status, grade level,
    /// and using the age in years the age in days is calculated
    /// simalary the age in hours and minute is also calcualted
    /// </summary>
    static void Main(string[] args)
    {
        string studentName="shambhavi adhikari";// Declare and initialize a string variable which stores full name
        int studentAge=17;// Declare and initialize an integer variable for student's age in years
        double gpa=3.95;// Declare and initialize a double variable for the student's GPA
        bool isEnrolled=true;// Declare and initialize a boolean variable
        char gradeLevel='A'; // Declare and initialize a character variable to represent the student's grade level

        int ageInDays = (studentAge * 365);// Calculate the student's age in days using the age in years


        Console.WriteLine("=====================Student Information=======================");
        Console.WriteLine($"Student Name: {studentName}");
        Console.WriteLine($"Student Age: {studentAge}");
        Console.WriteLine($"Student Age (in days): {ageInDays}");
        Console.WriteLine($"Student GPA: {gpa}");
        Console.WriteLine($"Enrollment Status: {isEnrolled}");
        Console.WriteLine($"Studnet Grade: {gradeLevel}");

        Console.WriteLine("================================================================");




        //bonus task

        int ageInHours = studentAge * 365 * 24;
        int ageInMinutes = studentAge*365*24 * 60;


        string studentName2 = "ram adhikari";// Declare and initialize a string variable which stores full name
        int studentAge2 = 20;// Declare and initialize an integer variable for student's age in years
        double gpa2 = 3.9;// Declare and initialize a double variable for the student's GPA
        bool isEnrolled2 = true;// Declare and initialize a boolean variable
        char gradeLevel2 = 'A'; // Declare and initialize a character variable to represent the student's grade level

        int ageInDays2 = (studentAge2 * 365);// Calculate the student's age in days using the age in years


        Console.WriteLine("=====================Student Information=======================");
        Console.WriteLine($"Student Name: {studentName2}");
        Console.WriteLine($"Student Age: {studentAge2}");
        Console.WriteLine($"Student Age (in days): {ageInDays2}");
        Console.WriteLine($"Student GPA: {gpa2}");
        Console.WriteLine($"Enrollment Status: {isEnrolled2}");
        Console.WriteLine($"Studnet Grade: {gradeLevel2}");

        Console.WriteLine("================================================================");




        //bonus task

        int ageInHours2 = studentAge2 * 365 * 24;
        int ageInMinutes2 = studentAge2 * 365 * 24 * 60;

        data();//calling the function so that it exicutes
    }

    public static void data()//this function does the same instead of using variables individually for wach data it uses array
    {
        string[] studentName = { "sita adhikari" ,"ram koirala"};// Array of type string storing student names
        int[] studentAge = {17,17};// Array of type int storing student age in years
        double[] gpa = { 3.95, 3.6 };// Array of type double storing student gpa
        bool[] isEnrolled = { true,true };// Array of type bool storing enrollmentstatus
        char[] gradeLevel = { 'A', 'A' };// Array of type char storing student grade



        for (int i = 0; i < studentName.Length; i++)//since the length of all array is same the for loop is exixuted using studentName and i acts as the index whose iitial value is 0
        {
            Console.WriteLine("=====================Student Information=======================");
            Console.WriteLine($"Student Name: {studentName[i]}");
            Console.WriteLine($"Student Age: {studentAge[i]}");
            Console.WriteLine($"Student Age (in days): {studentAge[i]*365}");//calculating age in years
            Console.WriteLine($"Student GPA: {gpa[i]}");
            Console.WriteLine($"Enrollment Status: {isEnrolled[i]}");
            Console.WriteLine($"Studnet Grade: {gradeLevel[i]}");

            Console.WriteLine("================================================================");
        }
    }
}

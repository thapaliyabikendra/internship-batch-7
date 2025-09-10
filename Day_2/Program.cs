//First Student Information
using Day_2;

string studentName = "Subesh Gumanju"; // Full name of the student
int studentAge = 25;   // Current age in years
double gpa = 3.5; // Gpa
bool isEnrolled = true;  // Enrollment status
char gradeLevel = 'A'; // Grade level

//Added Variable
string favoriteSubject = "Computer Science"; // Favorite academic subject
int studentId = 1001; // Unique student ID

// Age Calculations
int ageInDays = studentAge * 365;
int ageInHours = ageInDays * 24;
int ageInMinutes = ageInHours * 60;
//Displaying Information About First Student
Console.WriteLine($"Name: {studentName}");
Console.WriteLine($"Age (Years): {studentAge}");
Console.WriteLine($"Age (Days): {ageInDays}");
Console.WriteLine($"Age (Hours): {ageInHours}");
Console.WriteLine($"Age (Minutes) : {ageInMinutes}");
Console.WriteLine($"GPA: {gpa:F2}");
Console.WriteLine($"Enrolled : {isEnrolled}");
Console.WriteLine($"Grade : {gradeLevel}");
Console.WriteLine($"Student ID : {studentId}");
Console.WriteLine($"Favorite Subject: {favoriteSubject}");
Console.WriteLine();

// Second Student Information
string studentName2 = "Aarav Sharma";
int studentAge2 = 22;
double gpa2 = 3.8;
bool isEnrolled2 = true;
char gradeLevel2 = 'B';
string favoriteSubject2 = "Mathematics";
int studentId2 = 1002;

int ageInDays2 = studentAge2 * 365;
int ageInHours2 = ageInDays2 * 24;
int ageInMinutes2 = ageInHours2 * 60;

Students students = new Students("Subesh", 1, 22, 3.2, true,'A');
students.DisplayStudentInformation();
students.AgeInDays();
students.AgeInMinutesAndHours();


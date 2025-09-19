

using Day_7;

using var db = new Dbconfiguration();
Console.WriteLine($"Using DB at: {Path.GetFullPath(db.Dbpath)}");

db.Student.Add(new Student() {Name ="Subesh",Age=23} );
db.SaveChanges();
Console.WriteLine("1");
Console.WriteLine("Initial value");
foreach (var s in db.Student.ToList())
{
    Console.WriteLine($"ID: {s.StudentId}, Name: {s.Name}, Age: {s.Age}\n");
}


var students =db.Student.Where(s=>s.Age>18).ToList();
Console.WriteLine("2");
foreach (var s in db.Student.ToList())
{
    Console.WriteLine($"ID: {s.StudentId}, Name: {s.Name}, Age: {s.Age}\n");
}


var student = db.Student.FirstOrDefault(s => s.Name == "Subesh");
if (student == null)
    throw new Exception("Their is no value");
student.Name = "Laxman";
Console.WriteLine("3");
db.SaveChanges();
foreach (var s in db.Student.ToList())
{
    Console.WriteLine($"ID: {s.StudentId}, Name: {s.Name}, Age: {s.Age}\n");
}


var student2 = db.Student.FirstOrDefault(s => s.Name == "Laxman");
Console.WriteLine("4");
db.SaveChanges();
if (student2 == null)
{
    throw new Exception("No Student with name laxman\n");
}
db.Student.Remove(student2);

db.SaveChanges();
Console.WriteLine("5");
foreach (var s in db.Student.ToList())
{
    Console.WriteLine($"ID: {s.StudentId}, Name: {s.Name}, Age: {s.Age} \n");
}


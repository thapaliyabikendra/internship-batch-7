using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Day_7;
public class Student
{
    public int StudentId { get; set; }
    public string ? Name { get; set; }
    public int Age { get; set; }
}
public class Dbconfiguration:DbContext
{
    public DbSet<Student> Student { get; set; }
    public string Dbpath { get; }
    public Dbconfiguration()
    {
        Dbpath = Dbpath = Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\student.db"); ;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={Dbpath}");
    
}

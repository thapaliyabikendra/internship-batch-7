using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment_six
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            var studentName1 = from s in StudentDataStore.Students 
                               select s._name;
            var studentName2 = StudentDataStore.Students.Select(s => s._name).ToList();

            //2
            var highScoringStudents1 = from hss in StudentDataStore.Students 
                                       where hss._marks > 80 
                                       select hss;
            var highScoringStudnets2 = StudentDataStore.Students.Where(s => s._marks > 80).ToList();

            //3
            var getFirstStudent1 = (from gfs in StudentDataStore.Students where gfs._name.StartsWith("C") select gfs).FirstOrDefault();
            var getFirstStudent2 = StudentDataStore.Students.Where(s => s._name.StartsWith("C")).FirstOrDefault();

            //4
            var sortStudent1 = from ss in StudentDataStore.Students 
                               orderby ss._marks descending 
                               select ss;
            var sortStudent2 = StudentDataStore.Students.OrderByDescending(s => s._marks);

            //5
            var countMaleFemale1 = from cmf in StudentDataStore.Students 
                                   group cmf by cmf._gender into g
                                   select new { Gender =g.Key, Count= g.Count() };
            var countMaleFemale2 = StudentDataStore.Students.GroupBy(s => s._gender).Select( g => new { Gender = g.Key, Count = g.Count()});

            //6
            var studentByCity1 = from sbc in StudentDataStore.Students
                                 group sbc by sbc._city into g
                                 select new { City = g.Key, Count = g.Count()};
            var studentByCity2 = StudentDataStore.Students.GroupBy(s => s._city).Select(g => new{ City = g.Key, countMaleFemale1 = g.Count() } );

            //7
            var avarageMarks1 = (from am in StudentDataStore.Students
                                select am._marks).Average();
            var avarageMarks2 = StudentDataStore.Students.Average(s => s._marks);

            //8
            var highestMarks1 = (from hm in StudentDataStore.Students
                                select hm._marks).Max();
            var highestMarks2 = StudentDataStore.Students.Max(s => s._marks);

            //9
            var lowMarks1 = (from lm in StudentDataStore.Students
                             where lm._marks < 50
                             select lm).Any();
            var lowMarks2 = StudentDataStore.Students.Where(s => s._marks < 50);

            //10
            var nameAndCityList1 = from ncl in StudentDataStore.Students
                                  select new { ncl._name, ncl._city};
            var nameAndCityList2 = StudentDataStore.Students.Select(s => new { s._name, s._city});

            //Bonus
            //11
            var topThreeStudents1 = (from ts in StudentDataStore.Students
                                    orderby ts._marks descending
                                    select ts).Take(3);
            var topThreeStudents2 = StudentDataStore.Students.OrderByDescending(s => s._marks).Take(3);

            //12
            var ageRangeStudent1 = from ars in StudentDataStore.Students
                                   where ars._age >= 20 && ars._age <= 22
                                   orderby ars._age
                                   select ars;
            var ageRangeStudent2 = StudentDataStore.Students.Where(s => s._age >= 20 && s._age <= 22).OrderBy(s => s._age);

            //13
            List<Student> student1= new List<Student>();
            List<Student> student2 = new List<Student>();

            var combinedList = student1.Concat(student2)
                               .GroupBy(s => s._id)
                               .Select(g => g.First())
                               .ToList();

            // output
            Console.WriteLine("Student Names : ");
            foreach (var name in studentName1)
            {
                Console.WriteLine(name);
            }
        }
    }
}

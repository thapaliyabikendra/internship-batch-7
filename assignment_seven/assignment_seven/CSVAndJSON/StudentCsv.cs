using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_seven.CSVAndJSON
{
    public  class StudentCsv
    {
        #region create CSV file first with a data
        public static void CreateCsv(string path)
        {
            if (!File.Exists(path))
            {
                string[] lines = {
                    "Id,FirstName,LastName,Email",
                    "1,John,Doe,John@example.com",
                    "2,Jane,Smith,jane@example.com"
                };
                File.WriteAllLines(path, lines);
            }

        }
        #endregion

        #region read CSV and parse Students
        public static List<Student> ReadStudentsFromCsv(string path)
        {
            var students = new List<Student>();

            string[] lines = File.ReadAllLines(path);

            //skip header line
            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length == 4)
                {
                    students.Add(new Student
                    {
                        Id = int.Parse(parts[0]),
                        FirstName = parts[1],
                        LastName = parts[2],
                        Email = parts[3]
                    });
                }
            }
            return students;
        }
        #endregion

    }
}

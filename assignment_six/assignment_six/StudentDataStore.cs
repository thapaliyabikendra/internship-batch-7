using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_six
{
    public static class StudentDataStore
    {
        public static List<Student> Students = new List<Student>
        {

            new Student { _id = 1, _name = "Alice", _age = 20, _gender = "Female", _marks = 85, _city = "New York" },
            new Student { _id = 2, _name = "Bob", _age = 22, _gender = "Male", _marks = 78, _city = "Chicago" },
            new Student { _id = 3, _name = "Charlie", _age = 19, _gender = "Male", _marks = 92, _city = "New York" },
            new Student { _id = 4, _name = "Diana", _age = 21, _gender = "Female", _marks = 88, _city = "Los Angeles" },
            new Student { _id = 5, _name = "Ethan", _age = 20, _gender = "Male", _marks = 65, _city = "Chicago" },

        };
    }
}

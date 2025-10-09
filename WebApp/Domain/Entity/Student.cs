using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string RollNumber { get; set; }
        public string Grade { get; set; }
    }
}

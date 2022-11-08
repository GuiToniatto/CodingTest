using System.ComponentModel.DataAnnotations;

namespace CodingTest.Models
{
    public class Student
    {
        public Student()
        {
        }

        public Student(string name, string lastname, string email, string phone)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Phone = phone;
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

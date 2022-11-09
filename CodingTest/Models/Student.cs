using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Sobrenome")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Telefone")]
        public string Phone { get; set; }
        [DisplayName("Cursos")]
        public virtual List<StudentCourse>? StudentCourses { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

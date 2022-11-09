using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTest.Models
{
    public class Course
    {
        public Course()
        {
        }

        public Course(string name, string? description, int duration)
        {
            Name = name;
            Description = description;
            Duration = duration;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório.")]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório.")]
        [DisplayName("Descrição")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Campo {0} obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Insira um número maior ou igual a {1}")]
        [DisplayName("Duração")]
        public int Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

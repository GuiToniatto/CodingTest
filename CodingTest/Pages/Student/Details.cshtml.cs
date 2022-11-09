using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentModel = CodingTest.Models.Student;
using CodingTest.Repositories.Student;
using CodingTest.Models;
using CodingTest.Repositories.StudentCourse;

namespace CodingTest.Pages.Student
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IStudentCourseRepository _studentCourseRepository;

        public DetailsModel(IStudentRepository repository, IStudentCourseRepository studentCourseRepository)
        {
            _repository = repository;
            _studentCourseRepository = studentCourseRepository;
        }

        public StudentModel Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _repository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
                Student.StudentCourses = await _studentCourseRepository.GetAllCoursesFromStudentId(student.Id);
            }
            return Page();
        }
    }
}

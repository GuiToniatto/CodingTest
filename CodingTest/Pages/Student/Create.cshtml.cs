using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentModel = CodingTest.Models.Student;
using CodingTest.Repositories.Student;
using CodingTest.Repositories.StudentCourse;
using CourseModel = CodingTest.Models.Course;
using CodingTest.Repositories.Course;
using CodingTest.Models;

namespace CodingTest.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;

        public CreateModel(IStudentRepository repository, ICourseRepository courseRepository, IStudentCourseRepository studentCourseRepository)
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _studentCourseRepository = studentCourseRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Courses = await _courseRepository.GetAllCourses();

            return Page();
        }

        [BindProperty]
        public StudentModel Student { get; set; }
        [BindProperty]
        public List<CourseModel> Courses { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Student.CreatedAt = DateTime.Now;
            Student.UpdatedAt = DateTime.Now;

            var student = await _repository.CreateStudentAsync(Student);

            var courses = Request.Form["Student.StudentCourses"];
            if (courses != String.Empty && courses.Count > 0)
            {
                var studentCoursesList = new List<StudentCourse>();
                foreach (var c in courses)
                {
                    var studentCourse = new StudentCourse(student.Id, int.Parse(c));
                    studentCoursesList.Add(studentCourse);
                }

                await _studentCourseRepository.CreateRangeStudentCourseAsync(studentCoursesList);
            }

            return RedirectToPage("./Index");
        }
    }
}

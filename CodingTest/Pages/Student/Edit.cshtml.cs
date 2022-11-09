using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentModel = CodingTest.Models.Student;
using CodingTest.Repositories.Student;
using CodingTest.Repositories.Course;
using CodingTest.Repositories.StudentCourse;
using CourseModel = CodingTest.Models.Course;
using CodingTest.Models;

namespace CodingTest.Pages.Student
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;

        public EditModel(IStudentRepository repository, ICourseRepository courseRepository, IStudentCourseRepository studentCourseRepository)
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _studentCourseRepository = studentCourseRepository;
        }

        [BindProperty]
        public StudentModel Student { get; set; } = default!;
        [BindProperty]
        public List<CourseModel> Courses { get; set; }

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
            Student = student;
            Student.StudentCourses = await _studentCourseRepository.GetAllCoursesFromStudentId(Student.Id);
            Courses = await _courseRepository.GetAllCourses();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Student.UpdatedAt = DateTime.Now;

            try
            {
                await _repository.UpdateStudentAsync(Student);

                var studentCourses = await _studentCourseRepository.GetAllCoursesFromStudentId(Student.Id);
                await _studentCourseRepository.DeleteRangeStudentCourseAsync(studentCourses);

                var courses = Request.Form["Student.StudentCourses"];
                if (courses != String.Empty && courses.Count > 0)
                {
                    var studentCoursesList = new List<StudentCourse>();
                    foreach (var c in courses)
                    {
                        var studentCourse = new StudentCourse(Student.Id, int.Parse(c));
                        studentCoursesList.Add(studentCourse);
                    }

                    await _studentCourseRepository.CreateRangeStudentCourseAsync(studentCoursesList);
                }
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (_repository.GetStudentById(Student.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}

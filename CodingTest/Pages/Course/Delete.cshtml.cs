using CodingTest.Repositories.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelCourse = CodingTest.Models.Course;

namespace CodingTest.Pages.Course
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseRepository _repository;

        public DeleteModel(ICourseRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public ModelCourse Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _repository.GetCourseById(id);

            if (course == null)
            {
                return NotFound();
            }
            else 
            {
                Course = course;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _repository.GetCourseById(id);

            if (course != null)
            {
                Course = course;
                await _repository.DeleteCourseAsync(Course);
            }

            return RedirectToPage("./Index");
        }
    }
}

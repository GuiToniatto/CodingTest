using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModelCourse = CodingTest.Models.Course;
using CodingTest.Repositories.Course;

namespace CodingTest.Pages.Course
{
    public class DetailsModel : PageModel
    {
        private readonly ICourseRepository _repository;

        public DetailsModel(ICourseRepository repository)
        {
            _repository = repository;
        }

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
    }
}

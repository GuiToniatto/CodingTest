using CodingTest.Repositories.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModelCourse = CodingTest.Models.Course;

namespace CodingTest.Pages.Course
{
    public class EditModel : PageModel
    {
        private readonly ICourseRepository _repository;

        public EditModel(ICourseRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public ModelCourse Course { get; set; } = default!;

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

            Course = course;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Course.UpdatedAt = DateTime.Now;

            try
            {
                await _repository.UpdateCourseAsync(Course);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_repository.GetCourseById(Course.Id) == null)
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

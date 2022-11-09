using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentModel = CodingTest.Models.Student;
using CodingTest.Repositories.Student;

namespace CodingTest.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly IStudentRepository _repository;

        public CreateModel(IStudentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentModel Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Student.CreatedAt = DateTime.Now;
            Student.UpdatedAt = DateTime.Now;

            await _repository.CreateStudentAsync(Student);

            return RedirectToPage("./Index");
        }
    }
}

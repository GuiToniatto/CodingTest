using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentModel = CodingTest.Models.Student;
using CodingTest.Repositories.Student;

namespace CodingTest.Pages.Student
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentRepository _repository;

        public DeleteModel(IStudentRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
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
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _repository.GetStudentById(id);

            if (student != null)
            {
                Student = student;
                await _repository.DeleteStudentAsync(Student);
            }

            return RedirectToPage("./Index");
        }
    }
}

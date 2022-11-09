using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentModel = CodingTest.Models.Student;
using CodingTest.Repositories.Student;

namespace CodingTest.Pages.Student
{
    public class EditModel : PageModel
    {
        private readonly IStudentRepository _repository;

        public EditModel(IStudentRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public StudentModel Student { get; set; } = default!;

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

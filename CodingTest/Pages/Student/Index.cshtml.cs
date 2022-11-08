using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentModel = CodingTest.Models.Student;
using CodingTest.Repositories.Student;

namespace CodingTest.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly IStudentRepository _repository;

        public IndexModel(IStudentRepository repository)
        {
            _repository = repository;
        }

        public IList<StudentModel> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _repository.GetAllStudents();
        }
    }
}

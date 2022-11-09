using CodingTest.Repositories.Course;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CourseModel = CodingTest.Models.Course;

namespace CodingTest.Pages.Course
{
    public class IndexModel : PageModel
    {
        private readonly ICourseRepository _repository;

        public IndexModel(ICourseRepository repository)
        {
            _repository = repository;
        }

        public IList<CourseModel> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Course = await _repository.GetAllCourses();
        }
    }
}

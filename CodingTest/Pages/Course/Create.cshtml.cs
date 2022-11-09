using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CodingTest.Data;
using ModelCourse = CodingTest.Models.Course;
using CodingTest.Repositories.Course;
using NuGet.Protocol.Core.Types;

namespace CodingTest.Pages.Course
{
    public class CreateModel : PageModel
    {
        private readonly ICourseRepository _repository;

        public CreateModel(ICourseRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ModelCourse Course { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Course.CreatedAt = DateTime.Now;
            Course.UpdatedAt = DateTime.Now;

            await _repository.CreateCourseAsync(Course);

            return RedirectToPage("./Index");
        }
    }
}

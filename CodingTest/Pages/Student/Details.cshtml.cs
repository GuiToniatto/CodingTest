using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodingTest.Data;
using StudentModel = CodingTest.Models.Student;
using CodingTest.Repositories.Student;

namespace CodingTest.Pages.Student
{
    public class DetailsModel : PageModel
    {
        private readonly IStudentRepository _repository;

        public DetailsModel(IStudentRepository repository)
        {
            _repository = repository;
        }

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
    }
}

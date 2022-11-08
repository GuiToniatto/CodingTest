using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodingTest.Data;
using StudentModel = CodingTest.Models.Student;

namespace CodingTest.Pages.Student
{
    public class DetailsModel : PageModel
    {
        private readonly CodingTest.Data.CodingTestContext _context;

        public DetailsModel(CodingTest.Data.CodingTestContext context)
        {
            _context = context;
        }

      public StudentModel Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
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

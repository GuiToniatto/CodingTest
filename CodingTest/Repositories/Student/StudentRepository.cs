using CodingTest.Data;
using Microsoft.EntityFrameworkCore;

namespace CodingTest.Repositories.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CodingTestContext _context;

        public StudentRepository(CodingTestContext context)
        {
            _context = context;
        }

        public async Task CreateStudentAsync(Models.Student student)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteStudentAsync(Models.Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Models.Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task UpdateStudentAsync(Models.Student student)
        {
            throw new NotImplementedException();
        }
    }
}

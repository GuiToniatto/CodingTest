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
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(Models.Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Models.Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Models.Student?> GetStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateStudentAsync(Models.Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}

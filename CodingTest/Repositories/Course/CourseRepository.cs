using CodingTest.Data;
using Microsoft.EntityFrameworkCore;

namespace CodingTest.Repositories.Course
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CodingTestContext _context;

        public CourseRepository(CodingTestContext context)
        {
            _context = context;
        }

        public async Task CreateCourseAsync(Models.Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(Models.Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Models.Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Models.Course> GetCourseById(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCourseAsync(Models.Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}

using CodingTest.Data;
using StudentCourseModel = CodingTest.Models.StudentCourse;
using Microsoft.EntityFrameworkCore;

namespace CodingTest.Repositories.StudentCourse
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly CodingTestContext _context;

        public StudentCourseRepository(CodingTestContext context)
        {
            _context = context;
        }

        public async Task CreateRangeStudentCourseAsync(List<StudentCourseModel> modelStudentCourse)
        {
            _context.StudentCourses.AddRange(modelStudentCourse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeStudentCourseAsync(List<StudentCourseModel> modelStudentCourse)
        {
            _context.StudentCourses.RemoveRange(modelStudentCourse);
            await _context.SaveChangesAsync();
        }

        public Task<List<StudentCourseModel>> GetAllCoursesFromStudentId(int id)
        {
            return _context.StudentCourses.Where(sc => sc.StudentId == id)
                .Include(sc => sc.Course)
                .ToListAsync();
        }
    }
}

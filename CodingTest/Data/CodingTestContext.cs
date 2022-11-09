using Microsoft.EntityFrameworkCore;
using CodingTest.Models;
using Microsoft.Extensions.Hosting;

namespace CodingTest.Data
{
    public class CodingTestContext : DbContext
    {
        public CodingTestContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}

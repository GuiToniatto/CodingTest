using Microsoft.EntityFrameworkCore;
using CodingTest.Models;

namespace CodingTest.Data
{
    public class CodingTestContext : DbContext
    {
        public CodingTestContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}

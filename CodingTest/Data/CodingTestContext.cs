using Microsoft.EntityFrameworkCore;

namespace CodingTest.Data
{
    public class CodingTestContext : DbContext
    {
        public CodingTestContext(DbContextOptions options) : base(options)
        {
        }
    }
}

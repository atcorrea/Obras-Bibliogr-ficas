using GuideTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GuideTest.Data
{
    public class GuideTestContext : DbContext
    {
        public GuideTestContext(DbContextOptions<GuideTestContext> options) : base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace task2.Models.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }

        
    }
}

using Microsoft.EntityFrameworkCore;

namespace task2.Models.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Type> types { get; set; }  
        public DbSet<Blog> blogs { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id=1, Name="Niki" },
                new Company { Id=2, Name="Addidas" }
                );

            modelBuilder.Entity<Type>().HasData(
                new Type { Id = 1, Name = "action" },
                new Type { Id = 2, Name = "comidy" }
                );
        }


    }
}

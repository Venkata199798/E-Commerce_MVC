using E_Commerce_Housing.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Housing.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }

        public DbSet<Category> Categories  { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Action", DisplayOrder = 1 },
                new Category { CategoryID = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { CategoryID = 3, Name = "History", DisplayOrder = 3 }
            );
        }
    }




}

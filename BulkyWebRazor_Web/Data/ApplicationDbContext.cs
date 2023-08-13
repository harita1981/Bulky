using BulkyWebRazor_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor_Web.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
                
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Mobiles", DisplayOrder = 2 },
                new Category { Id = 2, Name = "Computers", DisplayOrder = 3 },
                new Category { Id = 3, Name = "Sports", DisplayOrder = 1 });
        }
    }
}

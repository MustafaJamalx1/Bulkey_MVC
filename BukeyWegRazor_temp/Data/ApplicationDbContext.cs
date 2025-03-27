using BukeyWegRazor_temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BukeyWegRazor_temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>().HasData(
                new Catagory { CatagoreyId = 1, Name = "Science", DisplayOrder = 3 },
                new Catagory { CatagoreyId = 2, Name = "History", DisplayOrder = 2 },
                new Catagory { CatagoreyId = 3, Name = "SciFi", DisplayOrder = 1 }
                );
        }
        public DbSet<Catagory> Catagories { get; set; }
    }
}

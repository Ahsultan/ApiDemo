using Microsoft.EntityFrameworkCore;
using WebApiDemo.Models;

namespace WebApiDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //data seeding
            modelBuilder.Entity<Shirt>().HasData(
            new() { ShirtId = 1, Brand = "Puma", Color = "Green", Gender = "Men", Size = 9, Price = 900 },
            new() { ShirtId = 2, Brand = "Nike", Color = "Blue", Gender = "Women", Size = 6, Price = 700 },
            new() { ShirtId = 3, Brand = "Sketchers", Color = "White", Gender = "Men", Size = 9, Price = 1900 },
            new() { ShirtId = 4, Brand = "Apple", Color = "Black", Gender = "Men", Size = 7, Price = 9000 },
            new() { ShirtId = 5, Brand = "Google", Color = "Black White", Gender = "Men", Size = 8, Price = 800 }
            );
        }
    }
}

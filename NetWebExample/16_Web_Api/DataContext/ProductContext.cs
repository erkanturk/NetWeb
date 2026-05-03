using _16_Web_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace _16_Web_Api.DataContext
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Tags)
                .HasConversion(
                   v => string.Join(',', v),
                   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                );
            modelBuilder.Entity<Product>()
               .Property(p => p.Images)
               .HasConversion(
                  v => string.Join(',', v),
                  v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
               );
            //{"a","b"} bu yapıyı birleştir 

        }
    }
}

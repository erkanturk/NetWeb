using _19_RestorantUygulamasi.Models;
using Microsoft.EntityFrameworkCore;

namespace _19_RestorantUygulamasi.DataContext
{
    public class RestorantContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=204-HOCAPC1;Database=RestorantDb;uid=sa;pwd=1;TrustServerCertificate=true");
        }
        public DbSet<Masa> Masalar {  get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<LogTablosu> LogTablosu { get; set; }
    }
}

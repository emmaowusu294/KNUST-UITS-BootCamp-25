using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class MyAppContext : DbContext
    {

        // Constructor to initialize the DbContext with options
        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the Item entity
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 4, Name = "microphone", Price = 40, SerialNumberId = 10 }
            );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 10, Name = "MIC150", ItemId = 4 }
            );
        }

        // Create a DbSet for each entity type
        public DbSet<Item> Item { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
    }
}

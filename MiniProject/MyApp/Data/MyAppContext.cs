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
            // Configure the composite primary key for the join entity
            modelBuilder.Entity<ItemClient>()
                .HasKey(ic => new { ic.ItemId, ic.ClientId });
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between Item and Client through ItemClient
            modelBuilder.Entity<ItemClient>()
                .HasOne(ic => ic.Item)
                .WithMany(i => i.ItemClients)
                .HasForeignKey(ic => ic.ItemId);

            modelBuilder.Entity<ItemClient>()
                .HasOne(ic => ic.Client)
                .WithMany(c => c.ItemClients)
                .HasForeignKey(ic => ic.ClientId);

            // Configure the Item entity
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 4, Name = "microphone", Price = 40, SerialNumberId = 10 }
            );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber { Id = 10, Name = "MIC150", ItemId = 4 }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" }
            );
        }

        // Create a DbSet for each entity type
        public DbSet<Item> Item { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ItemClient> ItemClients { get; set; }
    }
}

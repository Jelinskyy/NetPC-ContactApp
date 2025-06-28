using ContactApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BusinessSubcategory> Subcategories { get; set; }
        
        // Seeding data for initial categories and subcategories
        // This is useful for testing and initial setup
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial categories and subcategories
            // do not change the order or the IDs, they are used in validation

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Prywatny" }, // Private
                new Category { Id = 2, Name = "Służbowy" }, // Business
                new Category { Id = 3, Name = "Inny" } // Other
            );

            // Business Subcategories
            // These are only relevant if the Category is "Służbowy" (Business)
            // They are optional, so they can be null
            modelBuilder.Entity<BusinessSubcategory>().HasData(
                new BusinessSubcategory { Id = 1, Name = "Szef" }, // Boss
                new BusinessSubcategory { Id = 2, Name = "Klient" }, // Client
                new BusinessSubcategory { Id = 3, Name = "Współpracownik" }, // Colleague
                new BusinessSubcategory { Id = 4, Name = "Pracownik" }, // Employee
                new BusinessSubcategory { Id = 5, Name = "Dostawca" }, // Supplier
                new BusinessSubcategory { Id = 6, Name = "Partner" } // Partner
            );
        }   
    }
}
using Microsoft.EntityFrameworkCore;
using NeoStore.Models;

namespace NeoStore.Data
{
    public class EshopContext : DbContext
    {

        public EshopContext(DbContextOptions<EshopContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<CategoryToProduct> CategoryToProducts { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CategoryToProduct>().HasKey(t => new { t.ProductID, t.CategoryID });


            modelBuilder.Entity<Item>(c =>
            {
                c.Property(w => w.Price).HasColumnType("Money");
                c.HasKey(w => w.ID);
            });


            #region Seed data

            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Transportation", Description = "Category 1" },
                                                    new Category { Id = 2, Name = "Digital Products", Description = "Category 2" },
                                                    new Category { Id = 3, Name = "Educational", Description = "Category 3" });


            modelBuilder.Entity<Item>().HasData(new Item { ID = 1, Price = 12, QuantityInStock = 10 },
                                                new Item { ID = 2, Price = 12, QuantityInStock = 10 },
                                                new Item { ID = 3, Price = 12, QuantityInStock = 10 },
                                                new Item { ID = 4, Price = 12, QuantityInStock = 10 },
                                                new Item { ID = 5, Price = 12, QuantityInStock = 10 },
                                                new Item { ID = 6, Price = 12, QuantityInStock = 10 },
                                                new Item { ID = 7, Price = 12, QuantityInStock = 10 },
                                                new Item { ID = 8, Price = 12, QuantityInStock = 10 });


            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, ItemId = 1, Name = "Car 1", Description = "Safe and Effordable" },
                                                   new Product { Id = 2, ItemId = 2, Name = "Car 2", Description = "Classic" },
                                                   new Product { Id = 3, ItemId = 3, Name = "Car 3", Description = "Fast" },
                                                   new Product { Id = 4, ItemId = 4, Name = "Phone 1", Description = "Last Generation" },
                                                   new Product { Id = 5, ItemId = 5, Name = "Phone 2", Description = "Last Generation" },
                                                   new Product { Id = 6, ItemId = 6, Name = "Phone 3", Description = "Last Generation" },
                                                   new Product { Id = 7, ItemId = 7, Name = "Book 1", Description = "Differential Equations" },
                                                   new Product { Id = 8, ItemId = 8, Name = "Book 2", Description = "Physics" });


            modelBuilder.Entity<CategoryToProduct>().HasData(new CategoryToProduct { CategoryID = 1, ProductID = 1 },
                                                             new CategoryToProduct { CategoryID = 1, ProductID = 2 },
                                                             new CategoryToProduct { CategoryID = 1, ProductID = 3 },
                                                             new CategoryToProduct { CategoryID = 2, ProductID = 4 },
                                                             new CategoryToProduct { CategoryID = 2, ProductID = 5 },
                                                             new CategoryToProduct { CategoryID = 2, ProductID = 6 },
                                                             new CategoryToProduct { CategoryID = 3, ProductID = 7 },
                                                             new CategoryToProduct { CategoryID = 3, ProductID = 8 });



            #endregion


            base.OnModelCreating(modelBuilder);
        }
    }
}

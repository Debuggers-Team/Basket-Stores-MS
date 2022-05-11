using Basket_Store_MS.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket_Store_MS.Data
{
    public class BasketStoreDBContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Products> Products { get; set; }
        public BasketStoreDBContext(DbContextOptions options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>().HasData(
              new Cart { Id = 1, TotalCost = 50.60 , State = "Delivered" },
              new Cart { Id = 2, TotalCost = 40.22 , State = "Open" }
            );

            modelBuilder.Entity<Category>().HasData(
              new Category { Id = 1, Name = "Beauty" },
              new Category { Id = 2, Name = "Clothes" }
            );
            modelBuilder.Entity<FeedBack>().HasData(
            new FeedBack { Id = 1, FeedBackDescription = "Beauty",   Rating = 40.3  },
            new FeedBack { Id = 2, FeedBackDescription = "Clothes" , Rating = 150.4 }
            
            );
            modelBuilder.Entity<PaymentType>().HasData(
            new PaymentType { Id = 1, PaymentTypes = "Visa"},
            new PaymentType { Id = 2, PaymentTypes = "Master Card"}

            );
            modelBuilder.Entity<Products>().HasData(
            new Products { Id = 1, Name = "Eyeliner" , Price = 10, InStock = 150 , ProductDescription = "Test" ,Discount = true },
            new Products { Id = 2, Name = "Trousers", Price = 20, InStock = 100, ProductDescription = "Test2", Discount = false }

     );
        }

    }

}

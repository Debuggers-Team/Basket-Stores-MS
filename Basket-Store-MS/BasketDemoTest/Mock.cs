using Basket_Store_MS.Data;
using Basket_Store_MS.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BasketDemoTest
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly BasketStoreDBContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new BasketStoreDBContext(
                new DbContextOptionsBuilder<BasketStoreDBContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }


        protected async Task<Cart> CreateAndSaveTestCart()
        {
            var cart = new Cart { TotalCost = 500, State = "open", Quantity = 20 };
            _db.Carts.Add(cart);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, cart.Id); // Sanity check
            return cart;
        }

        protected async Task<Products> CreateAndSaveTestProduct()
        {
            var product = new Products { Name = "Iphone", Price = 20, InStock = 2, ProductDescription = "Iphone 13 pro", Discount = true, CategoryId = 1 };
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, product.Id); // Sanity check
            return product;
        }
    }
}

using Basket_Store_MS.Data;
using Basket_Store_MS.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Services
{
    public class ProuductRepo : IProuduct
    {
        
            private readonly BasketStoreDBContext _context;

            public ProuductRepo(BasketStoreDBContext context)
            {
                _context = context;
            }
            public async Task<Products> Create(Products products)
        {
            _context.Entry(products).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return products;
        }

        public async Task Delete(int id)
        {
            Products products = await GetProduct(id);
            _context.Entry(products).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Products> GetProduct(int Id)
        {
            Products product = await _context.Products.FindAsync(Id);
            return product;     
         }

        public async Task<List<Products>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Products> UpdateProduct(int Id, Products products)
        {
            _context.Entry(products).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return products;
        }
    }
}

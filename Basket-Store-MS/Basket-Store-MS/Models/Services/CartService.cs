using Basket_Store_MS.Data;
using Basket_Store_MS.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Services
{
    public class CartService : ICart
    {
        private readonly BasketStoreDBContext _context;
        public CartService(BasketStoreDBContext context)
        {
            _context = context;
        }
        public async Task<Cart> Create(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return cart;
        }
     

        public async Task Delete(int id)
        {
            Cart cart = await GetCart(id);
            _context.Entry(cart).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
   
        public async Task<Cart> GetCart(int id)
        {
            Cart cart = await _context.Carts.FindAsync(id);
            return cart;
        }
      
        public async Task<List<Cart>> GetCarts()
        {
            var cart = await _context.Carts.ToListAsync();
            return cart;
        }

        public async Task<Cart> UpdateCart(int id, Cart cart)
        {
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cart;
        }
    }
}

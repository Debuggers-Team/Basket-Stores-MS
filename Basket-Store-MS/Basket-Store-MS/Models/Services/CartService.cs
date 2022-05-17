using Basket_Store_MS.Data;
using Basket_Store_MS.Models.DTO;
using Basket_Store_MS.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<CartDto> Create(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Added;
            await _context.SaveChangesAsync();
            CartDto newCart = new CartDto
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                State = cart.State,
                TotalQuantity = cart.TotalQuantity
            };

            return newCart;
        }

        public async Task<List<CartDto>> GetCarts()
        {
            return await _context.Carts.Select(cart => new CartDto
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                State = cart.State,
                TotalQuantity = cart.TotalQuantity,
                Products = cart.CartProducts.Select(cp => new ProductDto
                {
                    Id = cp.Products.Id,
                    Name = cp.Products.Name,
                    Price = cp.Products.Price,
                    ProductDescription = cp.Products.ProductDescription,
                    Discount = cp.Products.Discount,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == cp.Products.CategoryId).Name
                }).ToList()
            }).ToListAsync();
        }

        public async Task<CartDto> GetCart(int id)
        {
            return await _context.Carts.Select(cart => new CartDto
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                State = cart.State,
                TotalQuantity = cart.TotalQuantity,
                Products = cart.CartProducts.Select(cp => new ProductDto
                {
                    Id = cp.Products.Id,
                    Name = cp.Products.Name,
                    Price = cp.Products.Price,
                    ProductDescription = cp.Products.ProductDescription,
                    Discount = cp.Products.Discount,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == cp.Products.CategoryId).Name
                }).ToList()
            }).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CartDto> UpdateCart(int id, Cart cart)
        {
            CartDto cartDto = new CartDto
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                State = cart.State,
                TotalQuantity = cart.TotalQuantity
            };
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return cartDto;
        }

        public async Task Delete(int id)
        {
            Cart cart = await _context.Carts.FindAsync(id);
            _context.Entry(cart).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddProductToCart(int productId, int cartId)
        {
            CartProduct cartProduct = new CartProduct()
            {
                ProductId = productId,
                CartId = cartId
            };
            _context.Entry(cartProduct).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task RemoveProductFromCart(int productId, int cartId)
        {
            var removeProduct = await _context.CartProduct.Where(x => x.ProductId == productId && x.CartId == cartId).FirstAsync();
            _context.Entry(removeProduct).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

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
            List<CartDto> carts = await _context.Carts.Select(cart => new CartDto
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                State = cart.State,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId,
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

            foreach (var item in carts)
            {
                item.TotalCost = ReturnTotalCost(item);
            }
            foreach (var item in carts)
            {
                item.TotalQuantity = GetProductQuantity(item);
            }

            await _context.SaveChangesAsync();

            return carts;
        }

        public async Task<CartDto> GetCart(int id)
        {
            CartDto cart = await _context.Carts.Select(cart => new CartDto
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                State = cart.State,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId,
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

            cart.TotalCost = ReturnTotalCost(cart);
            cart.TotalQuantity = GetProductQuantity(cart);

            await _context.SaveChangesAsync();

            return cart;
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

        public async Task AddProductToCart(int cartId, int productId)
        {
            var existsCartProduct = _context.CartProduct.Any(cp => cp.ProductId == productId && cp.CartId == cartId);
            var existsCart = _context.Carts.Any(c => c.Id == cartId);
            Products productStock = await _context.Products.FindAsync(productId);

            if (existsCart)
            {
                if (productStock.InStock > 0)
                {
                    if (existsCartProduct)
                    {
                        CartProduct cartProduct = await _context.CartProduct.Where(x => x.ProductId == productId && x.CartId == cartId).FirstAsync();
                        cartProduct.Quantity += 1;
                        productStock.InStock -= 1;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        CartProduct cartProduct = new CartProduct()
                        {
                            ProductId = productId,
                            CartId = cartId,
                            Quantity = 1
                        };

                        productStock.InStock -= 1;
                        _context.Entry(cartProduct).State = EntityState.Added;
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }
        public async Task RemoveProductFromCart(int cartId, int productId)
        {
            var existsCartProduct = _context.CartProduct.Any(cp => cp.ProductId == productId && cp.CartId == cartId);
            if (existsCartProduct)
            {
                CartProduct removeProduct = await _context.CartProduct.Where(x => x.ProductId == productId && x.CartId == cartId).FirstAsync();
                Products productStock = await _context.Products.FindAsync(productId);
                if (removeProduct.Quantity > 1)
                {
                    removeProduct.Quantity -= 1;
                    productStock.InStock += 1;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    productStock.InStock += 1;
                    _context.Entry(removeProduct).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                }
            }
        }

        private double ReturnTotalCost(CartDto cart)
        {

            double Total = 0;
            foreach (var item in cart.Products)
            {
                Total += item.Price;
            }

            return TotalCostAfterDiscount(Total);
        }
        private double TotalCostAfterDiscount(double TotalCost)
        {
            if (TotalCost >= 100)
            {
                TotalCost -= (TotalCost * .10);

                return TotalCost;
            }
            else
            {
                return TotalCost;
            }
        }

        private int GetProductQuantity(CartDto cart)
        {
            int TotalQuantity = 0;

            List<int> cartProduct = _context.CartProduct.Where(cp => cp.CartId == cart.Id).Select(q => q.Quantity).ToList();
            foreach (var item in cartProduct)
            {
                TotalQuantity += item;
            }
            return TotalQuantity;
        }

        public async Task<BillDto> GetBill(int id)
        {
            CartDto cart = await GetCart(id);

            string UserName = await _context.Users.Where(ur => ur.Id == cart.UserId).Select(u => u.UserName).FirstOrDefaultAsync();
            string Email = await _context.Users.Where(ur => ur.Id == cart.UserId).Select(u => u.Email).FirstOrDefaultAsync();

            string products = "";
            int count = 0;
            foreach (var item in cart.Products)
            {
                count++;
                products += $" {count} . {item.Name} --- Price : {item.Price} ---";
            }

            BillDto bill = new BillDto
            {
                UserName = UserName,
                TotalCost = cart.TotalCost,
                TotalQuantity =cart.TotalQuantity,
                Products = products
            };

            return bill;
        }
    }
}

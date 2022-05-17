using Basket_Store_MS.Data;
using Basket_Store_MS.Models.DTO;
using Basket_Store_MS.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Services
{
    public class FavouriteService : IFavourite
    {
        private readonly BasketStoreDBContext _context;
        public FavouriteService(BasketStoreDBContext context)
        {
            _context = context;
        }
        public async Task<FavouriteDto> Create(Favourite favourite)
        {
            _context.Entry(favourite).State = EntityState.Added;

            await _context.SaveChangesAsync();

            FavouriteDto favouritedto = new FavouriteDto()
            {
                Id = favourite.Id,
                UserId = favourite.UserId
                
            };

            return favouritedto;
        }
        public async Task<FavouriteDto> GetFavourite(int id)
        {
           return await _context.Favourite.Select(favourite => new FavouriteDto
           {
               Id=favourite.Id,
               UserId=favourite.UserId,
               Products = favourite.FavouriteProducts.Select(fav => new ProductDto
               {
                   Id = fav.Products.Id,
                   Name = fav.Products.Name,
                   Price = fav.Products.Price,
                   ProductDescription = fav.Products.ProductDescription,
                   Discount = fav.Products.Discount,
                   CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == fav.Products.CategoryId).Name
               }).ToList()
           }).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<FavouriteDto>> GetFavourites()
        {
            return await _context.Favourite.Select(favourite => new FavouriteDto
            {
                Id = favourite.Id,
                UserId = favourite.UserId,
                Products = favourite.FavouriteProducts.Select(fav => new ProductDto
                {
                    Id = fav.Products.Id,
                    Name = fav.Products.Name,
                    Price = fav.Products.Price,
                    ProductDescription = fav.Products.ProductDescription,
                    Discount = fav.Products.Discount,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == fav.Products.CategoryId).Name
                }).ToList()
            }).ToListAsync();
        }

        public async Task<FavouriteDto> UpdateFavourite(int id, Favourite newProduct)
        {
            FavouriteDto favourite = new FavouriteDto
            {
                Id=newProduct.Id,
                UserId = newProduct.UserId,
            };
            _context.Entry(newProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return favourite;
        }
        public async Task Delete(int id)
        {
            Favourite favourite = await _context.Favourite.FindAsync(id);
            _context.Entry(favourite).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddProductToFavourite(int favouriteId , int productId)
        {
            FavouriteProduct FavProduct = new FavouriteProduct()
            {
                ProductId = productId,
                FavouriteId = favouriteId
            };
            _context.Entry(FavProduct).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductFromFavourite(int favouriteId, int productId)
        {
            var removeProduct = await _context.FavouriteProduct.Where(fav => fav.ProductId == productId && fav.FavouriteId == favouriteId).FirstAsync();
            _context.Entry(removeProduct).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

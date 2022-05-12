using Basket_Store_MS.Data;
using Basket_Store_MS.Models.DTO;
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

        public async Task AddFeedBackToProduct(int productId, int feedBackId)
        {
            ProductFeedBack productFeedBack = new ProductFeedBack()
            {
                ProductId = productId,
                FeedBackId = feedBackId
            };
            _context.Entry(productFeedBack).State = EntityState.Added;

            await _context.SaveChangesAsync();

        }

        public async Task<ProductDto> Create(ProductDto products)
        {
            _context.Entry(products).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return products;
        }

        public async Task Delete(int id)
        {
            Products product = await _context.Products.FindAsync(id);
                _context.Entry(product).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }

        public async Task <ProductDto> GetProduct(int Id)
        {
            return await _context.Products.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                ProductDescription = X.ProductDescription,
                Discount = X.Discount,
                feedBacks = X.feedBack
                             .Select(Y => new FeedBack
                             {
                                 Id = Y.Id,
                                 FeedBackDescription = Y.FeedBackDescription,
                                 Rating = Y.Rating
                                 
                             }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public Task<List<ProductDto>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task RemoveFeedBackFromProduct(int ProductId, int FeedBackId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> UpdateProduct(int Id, ProductDto products)
        {
            throw new NotImplementedException();
        }
    }
}

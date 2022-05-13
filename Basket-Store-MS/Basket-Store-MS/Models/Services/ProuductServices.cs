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
    public class ProuductServices : IProuduct
    {
            private readonly BasketStoreDBContext _context;

            public ProuductServices(BasketStoreDBContext context)
            {
                _context = context;
            }

        public async Task<ProductDto> Create(Products products)
        {
            _context.Entry(products).State = EntityState.Added;
            await _context.SaveChangesAsync();
            ProductDto productDto = new ProductDto
            {
                Id = products.Id,
                Name = products.Name,
                Price = products.Price,
                ProductDescription = products.ProductDescription,
                Discount = products.Discount,
                CategoryId = products.CategoryId
            };

            return productDto;
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
                CategoryId = X.CategoryId,
                category = new CategoryDto
                {
                    Name = X.Category.Name.ToString()
                },
                feedBacks = X.FeedBack
                              .Select(Y => new FeedBackDto
                              {
                                  Id = Y.Id,
                                  FeedBackDescription = Y.FeedBackDescription,
                                  Rating = Y.Rating,
                                  ProductsId = Y.ProductsId
                              }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await _context.Products.Select(X => new ProductDto
            {
                Id = X.Id,
                Name = X.Name,
                Price = X.Price,
                ProductDescription = X.ProductDescription,
                Discount = X.Discount,
                CategoryId = X.CategoryId,
                category = new CategoryDto
                {
                    Name = X.Category.Name.ToString()
                },
                feedBacks = X.FeedBack
                              .Select(Y => new FeedBackDto
                              {   Id = Y.Id,
                                  FeedBackDescription = Y.FeedBackDescription,
                                  Rating = Y.Rating,
                                  ProductsId = Y.ProductsId
                              }).ToList()
            }).ToListAsync();
        }

        public async Task<ProductDto> UpdateProduct(int Id, ProductDto products)
        {
            Products product = new Products
            {
                Id = products.Id,
                Name = products.Name,
                Discount = products.Discount,
                ProductDescription = products.ProductDescription,
                Price = products.Price
            };
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return products;
        }
    }
}

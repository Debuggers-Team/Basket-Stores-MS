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
    public class CategoryServiece : ICategory
    {
        private readonly BasketStoreDBContext _context;
        public CategoryServiece(BasketStoreDBContext context)
        {
            _context = context;
        }
        public async Task<CategoryDto> Create(Category category)
        {
            _context.Entry(category).State = EntityState.Added;

            await _context.SaveChangesAsync();

            CategoryDto categorydto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };

            return categorydto;
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            return await _context.Categories
                    .Select(category => new CategoryDto
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Products = category.Products.Select(p => new ProductDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Price = p.Price,
                            ProductDescription = p.ProductDescription,
                            FeedBacks = p.FeedBack
                              .Select(f => new FeedBackDto
                              {
                                  Id = f.Id,
                                  FeedBackDescription = f.FeedBackDescription,
                                  Rating = f.Rating,
                                  ProductsName = p.Name
                              }).ToList()
                        }).ToList()
                    }).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<List<CategoryDto>> GetCategories()
        {
            return await _context.Categories
                      .Select(category => new CategoryDto
                      {
                          Id = category.Id,
                          Name = category.Name.ToString(),
                          Products = category.Products.Select(p => new ProductDto
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Price = p.Price,
                              ProductDescription = p.ProductDescription,
                              Discount = p.Discount,
                              CategoryName = category.Name,
                              FeedBacks = p.FeedBack
                              .Select(f => new FeedBackDto
                              {
                                  Id = f.Id,
                                  FeedBackDescription = f.FeedBackDescription,
                                  Rating = f.Rating,
                                  ProductsName = p.Name
                              }).ToList()
                          }).ToList()
                          }).ToListAsync();
        }

        public async Task<CategoryDto> UpdateCategory(int id, Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            CategoryDto categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return categoryDto;
        }
        public async Task Delete(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            _context.Entry(category).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

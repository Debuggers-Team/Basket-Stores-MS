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
        public async Task<CategoryDto> Create(CategoryDto categorydto)
        {
            Category category = new Category
            {
                Id = categorydto.Id,
                Name = (Name)Enum.Parse(typeof(Name), categorydto.Name.ToString())
            };
            _context.Entry(category).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return categorydto;
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            return await _context.Categories
                    .Select(category => new CategoryDto
                    {
                        Id = id,
                        Name = category.Name.ToString(),
                        Products = category.Products.Select(p => new ProductDto
                        {
                            Id = p.Id,
                            Name = p.Name.ToString(),
                            feedBacks = p.FeedBack
                              .Select(f => new FeedBackDto
                              {
                                  Id = f.Id,
                                  FeedBackDescription = f.FeedBackDescription,
                                  Rating = f.Rating,
                                  ProductsId = f.ProductsId
                              }).ToList(),
                            category = new CategoryDto
                            {

                                Name = p.Category.Name.ToString()

                            }

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
                              Name = p.Name.ToString(),
                              feedBacks = p.FeedBack
                              .Select(f => new FeedBackDto
                              {
                                  Id = f.Id,
                                  FeedBackDescription = f.FeedBackDescription,
                                  Rating = f.Rating,
                                  ProductsId = f.ProductsId
                              }).ToList(),
                              category = new CategoryDto
                              {
                                  Name = p.Category.Name.ToString()
                              }
                             
                          }).ToList()
                          }).ToListAsync();
        }

        public async Task<CategoryDto> UpdateCategory(int id, CategoryDto category)
        {

            Category category1 = new Category
            {
                Id = category.Id,
                Name = (Name)Enum.Parse(typeof(Name), category.Name)
            };
            _context.Entry(category1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task Delete(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            _context.Entry(category).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

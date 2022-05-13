using Basket_Store_MS.Data;
using Basket_Store_MS.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<Category> Create(Category category)
        {
            _context.Entry(category).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetCategory(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            return category;
        }
        public async Task<List<Category>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task Delete(int id)
        {
            Category category = await GetCategory(id);
            _context.Entry(category).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

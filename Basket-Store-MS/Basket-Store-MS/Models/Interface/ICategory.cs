using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface ICategory
    {
        Task<Category> Create(Category category);
        Task<List<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> UpdateCategory(int id, Category category);
        Task Delete(int id);
    }
}

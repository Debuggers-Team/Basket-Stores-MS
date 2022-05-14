using Basket_Store_MS.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface ICategory
    {
        Task<CategoryDto> Create(Category category);
        Task<List<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategory(int id);
        Task<CategoryDto> UpdateCategory(int id, Category category);
        Task Delete(int id);
    }
}

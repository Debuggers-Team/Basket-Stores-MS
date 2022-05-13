using Basket_Store_MS.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface ICategory
    {
        Task<CategoryDto> Create(CategoryDto category);
        Task<List<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategory(int id);
        Task<CategoryDto> UpdateCategory(int id, CategoryDto category);
        Task Delete(int id);
    }
}

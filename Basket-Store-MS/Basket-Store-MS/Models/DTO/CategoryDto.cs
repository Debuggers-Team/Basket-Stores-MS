using System.Collections.Generic;

namespace Basket_Store_MS.Models.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ProductDescription { get; set; }
        public bool Discount { get; set; }
        public int CategoryId { get; set; }

        public List<FeedBackDto> feedBacks { get; set; }
        public CategoryDto category { get; set; }
    }
}

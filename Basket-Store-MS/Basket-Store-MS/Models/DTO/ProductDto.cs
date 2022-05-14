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
        public string CategoryName { get; set; }

        public List<FeedBackDto> FeedBacks { get; set; }
    }
}


using Basket_Store_MS.Models.DTO;
using System.Collections.Generic;

namespace Basket_Store_MS.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
        public string ProductDescription { get; set; }
        public bool Discount { get; set; }
        //Foreign key
        public int CategoryId { get; set; }

        public List<FeedBack> FeedBack { get; set; }
    }
}

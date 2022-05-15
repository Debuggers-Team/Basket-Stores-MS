
using Basket_Store_MS.Models.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Category Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        //Navigation properties
        public List<CartProduct> CartProducts { get; set; }
        public List<FeedBack> FeedBack { get; set; }
    }
}

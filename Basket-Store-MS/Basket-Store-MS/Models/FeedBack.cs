using System.ComponentModel.DataAnnotations.Schema;

namespace Basket_Store_MS.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string FeedBackDescription { get; set; }
        public double Rating { get; set; }
        //ForeignKey
        public Products Products { get; set; }
        [ForeignKey("Products")]
        public int ProductsId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Basket_Store_MS.Models
{
    public class CartProduct
    {
        public Cart Cart { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }

        public Products Products { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }
    }
}

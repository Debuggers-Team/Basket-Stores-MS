using System.ComponentModel.DataAnnotations.Schema;

namespace Basket_Store_MS.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string PaymentTypes { get; set; }

        //ForeignKey
        public Cart Cart { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
    }
}
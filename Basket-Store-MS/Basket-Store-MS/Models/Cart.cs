using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket_Store_MS.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public string State { get; set; }
        public int TotalQuantity { get; set; }

        //ForeignKey
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        //Navigation properties
        public List<CartProduct> CartProducts { get; set; }
    }
}

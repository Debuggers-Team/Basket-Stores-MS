using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket_Store_MS.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public string State { get; set; }
        public int Quantity { get; set; }

        //Navigation properties
        public List<CartProduct> CartProducts { get; set; }
    }
}

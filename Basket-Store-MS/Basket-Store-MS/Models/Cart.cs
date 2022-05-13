using System.Collections.Generic;

namespace Basket_Store_MS.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public string State { get; set; }
        public int PaymentType { get; set; }
        public PaymentType PaymentTypes { get; set; }
    }
}

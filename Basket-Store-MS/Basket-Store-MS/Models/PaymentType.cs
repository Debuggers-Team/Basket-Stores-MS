namespace Basket_Store_MS.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string PaymentTypes { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
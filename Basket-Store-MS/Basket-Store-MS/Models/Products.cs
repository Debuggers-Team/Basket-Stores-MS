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
    }
}

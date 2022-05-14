namespace Basket_Store_MS.Models.DTO
{
    public class FeedBackDto
    {
        public int Id { get; set; }
        public string FeedBackDescription { get; set; }
        public double Rating { get; set; }
        //FK
        public string ProductsName { get; set; }
    }
}

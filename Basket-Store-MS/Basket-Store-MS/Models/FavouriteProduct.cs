using System.ComponentModel.DataAnnotations.Schema;

namespace Basket_Store_MS.Models
{
    public class FavouriteProduct
    {
        public Favourite Favourite { get; set; }
        [ForeignKey("Favourite")]
        public int FavouriteId { get; set; }

        public Products Products { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }
    }
}

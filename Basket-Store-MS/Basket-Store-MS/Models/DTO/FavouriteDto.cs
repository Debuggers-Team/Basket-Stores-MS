using System.Collections.Generic;

namespace Basket_Store_MS.Models.DTO
{
    public class FavouriteDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        //Many to many Relation between Favourite And Product
        public List<ProductDto> Products { get; set; }
    }
}

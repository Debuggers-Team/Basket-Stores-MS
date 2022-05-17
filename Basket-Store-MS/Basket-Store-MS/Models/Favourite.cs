using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket_Store_MS.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        //ForeignKey
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        //Navigation properties
        public List<FavouriteProduct> FavouriteProducts { get; set; }
    }
}

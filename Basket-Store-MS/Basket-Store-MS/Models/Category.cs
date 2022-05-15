using System.Collections.Generic;

namespace Basket_Store_MS.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation properties
        public List<Products> Products { get; set; }
    }
}

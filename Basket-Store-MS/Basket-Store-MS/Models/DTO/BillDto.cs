using System.Collections.Generic;

namespace Basket_Store_MS.Models.DTO
{
    public class BillDto
    {
        public string UserName { get; set; }
        public double TotalCost { get; set; }
        public double TotalCostDicount { get; set; }
        public int TotalQuantity { get; set; }
        public string Email { get; set; }
        public List<ProductDto> Products { get; set; }
        public List<int> Quantity { get; set; }
    }
}

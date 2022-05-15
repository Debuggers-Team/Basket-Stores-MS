﻿using System.Collections.Generic;

namespace Basket_Store_MS.Models.DTO
{
    public class CartDto
    {
        public int Id { get; set; }
        public double TotalCost { get; set; }
        public string State { get; set; }
        public int Quantity { get; set; }
        // To Many to many Relation between Cart And Product
        public List<ProductDto> Products { get; set; }
    }
}

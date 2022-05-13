using Basket_Store_MS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface IProuduct
    {
        Task<ProductDto> Create(Products products);
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int Id);
        Task<ProductDto> UpdateProduct(int Id, ProductDto products);
        Task Delete(int id);
    }
}


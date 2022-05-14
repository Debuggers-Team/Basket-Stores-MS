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
        //Order By Descending
        Task<List<ProductDto>> GetProductsDes();
        //Order By Ascending
        Task<List<ProductDto>> GetProductsAsc();
        //Order By Max to min
        Task<List<ProductDto>> GetProductsMaxToMin();
        //Order By Min to Max
        Task<List<ProductDto>> GetProductsMinToMax();
        //Get Prouducts From To Price
        Task<List<ProductDto>> GetProductsFromTo(int from , int to);

        Task<ProductDto> UpdateProduct(int Id, ProductDto products);
        Task Delete(int id);
    }
}


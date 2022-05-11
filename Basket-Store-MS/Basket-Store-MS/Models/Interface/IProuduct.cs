using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface IProuduct
    {
        Task<Products> Create(Products products);
        Task<List<Products>> GetProducts();
        Task<Products> GetProduct(int Id);
        Task<Products> UpdateProduct(int Id, Products products);
        Task Delete(int id);
      }
}


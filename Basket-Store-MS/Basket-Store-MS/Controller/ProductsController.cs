using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Basket_Store_MS.Data;
using Basket_Store_MS.Models;
using Basket_Store_MS.Models.Interface;
using Basket_Store_MS.Models.DTO;

namespace Basket_Store_MS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProuduct _prouduct;

        public ProductsController(IProuduct prouduct)
        {
            _prouduct = prouduct;
        }
        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var prouducts = await _prouduct.GetProducts();
            return Ok(prouducts);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProducts(int id)
        {
            var product = await _prouduct.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // Order By Descending
        // GET: api/Products/Des
        [HttpGet("Des")]
        public async Task<ActionResult<ProductDto>> GetProductsDes()
        {
            var result = await _prouduct.GetProductsDes();

            return Ok(result);
        }

        // Order By Ascending
        // GET: api/Products/Asc
        [HttpGet("Asc")]
        public async Task<ActionResult<ProductDto>> GetProductsAsc()
        {
            var result = await _prouduct.GetProductsAsc();

            return Ok(result);
        }

        // Order By Min To Max
        // GET: api/Products/MinToMax
        [HttpGet("MinToMax")]
        public async Task<ActionResult<ProductDto>> GetProductsMinToMax()
        {
            var result = await _prouduct.GetProductsMinToMax();

            return Ok(result);
        }

        // Order By Max To Min
        // GET: api/Products/MinToMax
        [HttpGet("MaxToMin")]
        public async Task<ActionResult<ProductDto>> GetProductsMaxToMin()
        {
            var result = await _prouduct.GetProductsMaxToMin();

            return Ok(result);
        }

        // Get data from to price 
        // GET: api/Products/FromTo/10/100
        [HttpGet("FromTo/{from}/{to}")]
        public async Task<ActionResult<ProductDto>> GetProductsFromTo(int from , int to)
        {
            var result = await _prouduct.GetProductsFromTo(from , to);

            return Ok(result);
        }

        // Search for a specific product by name or  
        // GET: api/Products/Search/Iphone
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<ProductDto>> SearchForProduct(string name)
        {
            var result = await _prouduct.SearchForProduct(name);

            if (result.Count == 0)
            {
                return Content("No result found");
            }
            return Ok(result);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var modifiedproduct = await _prouduct.UpdateProduct(id, product);

            return Ok(modifiedproduct);
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProducts(Products products)
        {
            ProductDto Product = await _prouduct.Create(products);

            return Ok(Product);

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            await _prouduct.Delete(id);


            return NoContent();
        }
    }
}
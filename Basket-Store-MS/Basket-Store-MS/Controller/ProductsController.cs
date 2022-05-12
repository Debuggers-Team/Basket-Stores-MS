//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Basket_Store_MS.Data;
//using Basket_Store_MS.Models;
//using Basket_Store_MS.Models.Interface;

//namespace Basket_Store_MS.Controller
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductsController : ControllerBase
//    {
//        private readonly IProuduct _prouduct;

//        public ProductsController(IProuduct prouduct)
//        {
//            _prouduct = prouduct;
//        }

//        // GET: api/Products
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
//        {
//            return await _prouduct.GetProducts();
//        }

//        // GET: api/Products/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Products>> GetProducts(int id)
//        {
//            var products = await _prouduct.GetProduct(id);

//            if (products == null)
//            {
//                return NotFound();
//            }

//            return products;
//        }

//        // PUT: api/Products/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutProducts(int id, Products products)
//        {
//            if (id != products.Id)
//            {
//                return BadRequest();
//            }
//            var modifiedproduct = await _prouduct.UpdateProduct(id, products);

//            return Ok(modifiedproduct);
//        }

//        // POST: api/Products
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Products>> PostProducts(Products products)
//        {
//            var Product = await _prouduct.Create(products);

//            return Ok(Product);

//        }

//        // DELETE: api/Products/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProducts(int id)
//        {
//            await _prouduct.Delete(id);


//            return NoContent();
//        }

//        //private bool ProductsExists(int id)
//        //{
//        //    return _context.Products.Any(e => e.Id == id);
//        //}
//    }
//}

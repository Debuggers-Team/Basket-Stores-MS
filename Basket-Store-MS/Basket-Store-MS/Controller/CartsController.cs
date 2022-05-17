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
    public class CartsController : ControllerBase
    {
        private readonly ICart _cart;

        public CartsController(ICart cart)
        {
            _cart = cart;
        }

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            var cart = await _cart.GetCarts();
            return Ok(cart);
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDto>> GetCart(int id)
        {
            var cart = await _cart.GetCart(id);
            return Ok(cart);
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCart(int id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }
            var modifiedCart= await _cart.UpdateCart(id, cart);
            return Ok(modifiedCart);
        }

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            var newCart = await _cart.Create(cart);
            return Ok(newCart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            await _cart.Delete(id);
            return NoContent();
        }
        //Add Product to cart
        //api/Carts/3/2
        [HttpPost("{cartId}/{productId}")]
        public async Task<IActionResult> AddProductToCart(int cartId, int productId)
        {
            await _cart.AddProductToCart(cartId, productId);
            return NoContent();
        }

        // Delete Product
        //api/Carts/5/1
        [HttpDelete("{cartId}/{productId}")]
        public async Task<IActionResult> RemoveProductFromCart(int cartId, int productId)
        {
            await _cart.RemoveProductFromCart(cartId, productId);
            return NoContent();
        }
    }
}

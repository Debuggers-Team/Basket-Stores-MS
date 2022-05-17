using Basket_Store_MS.Models;
using Basket_Store_MS.Models.DTO;
using Basket_Store_MS.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavourite _favourite;

        public FavouritesController(IFavourite favourite)
        {
            _favourite = favourite;
        }

        // GET: api/Favourites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavouriteDto>>> GetFavourites()
        {
            var favourite = await _favourite.GetFavourites();
            return Ok(favourite);
        }

        // GET: api/Favourites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavouriteDto>> GetFavourite(int id)
        {
            var favourite = await _favourite.GetFavourite(id);
            return Ok(favourite);
        }


        // PUT: api/Favourites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavourite(int id, Favourite favourite)
        {
            if (id != favourite.Id)
            {
                return BadRequest();
            }

            var modifiedFavourite = await _favourite.UpdateFavourite(id, favourite);
            return Ok(modifiedFavourite);
        }

        // POST: api/Favourites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FavouriteDto>> PostFavourite(Favourite favourite)
        {
            var newFavourite = await _favourite.Create(favourite);
            return Ok(newFavourite);
        }
        //Add Product to cart
        //api/Carts/3/2
        [HttpPost("{favouriteId}/{productId}")]
        public async Task<IActionResult> AddProductToCart(int favouriteId, int productId)
        {
            await _favourite.AddProductToFavourite(favouriteId, productId);
            return NoContent();
        }

        // Delete Product
        //api/Carts/5/1
        [HttpDelete("{favouriteId}/{productId}")]
        public async Task<IActionResult> RemoveProductFromCart(int favouriteId, int productId)
        {
            await _favourite.RemoveProductFromFavourite(favouriteId, productId);
            return NoContent();
        }
        // DELETE: api/Favourites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourite(int id)
        {
            await _favourite.Delete(id);
            return NoContent();
        }
    }

}
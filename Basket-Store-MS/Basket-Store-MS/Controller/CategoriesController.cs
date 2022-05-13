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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoriesController(ICategory category)
        {
            _category = category;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _category.GetCategories();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            CategoryDto categorydto = await _category.GetCategory(id);
            return Ok(categorydto);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto category)
        {

            if (id != category.Id)
            {
                return BadRequest();
            }
            var modifiedCategory = await _category.UpdateCategory(id, category);
            return Ok(modifiedCategory);
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> PostCategory(CategoryDto category)
        {
            CategoryDto newCategory = await _category.Create(category);
            return Ok(newCategory);

        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _category.Delete(id);
            return NoContent();
        }
    }
}

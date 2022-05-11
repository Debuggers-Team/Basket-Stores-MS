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

namespace Basket_Store_MS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBacksController : ControllerBase
    {
        private readonly IFeedBack _feedback;

        public FeedBacksController(IFeedBack feedback)
        {
            _feedback = feedback;
        }

        // GET: api/FeedBacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedBack>>> GetFeedBacks()
        {
            var feedback = await _feedback.GetFeedBacks();
            return Ok(feedback);
        }

        // GET: api/FeedBacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedBack>> GetFeedBack(int id)
        {
            FeedBack feedback = await _feedback.GetFeedBack(id);
            return Ok(feedback);
        }

        // PUT: api/FeedBacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedBack(int id, FeedBack feedBack)
        {
            if (id != feedBack.Id)
            {
                return BadRequest();
            }

            var modifiedFeedBack = await _feedback.UpdateFeedBack(id, feedBack);

            return Ok(modifiedFeedBack);
        }

        // POST: api/FeedBacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedBack>> PostFeedBack(FeedBack feedBack)
        {
            FeedBack newFeedBack = await _feedback.Create(feedBack);
            return Ok(newFeedBack);
        }

        // DELETE: api/FeedBacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedBack(int id)
        {
            await _feedback.Delete(id);

            return NoContent();
        }

       
    }
}

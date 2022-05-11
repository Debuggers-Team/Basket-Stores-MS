using Basket_Store_MS.Data;
using Basket_Store_MS.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Services
{
    public class FeedBackServices : IFeedBack
    {
        private readonly BasketStoreDBContext _context;

        public FeedBackServices(BasketStoreDBContext context)
        {
            _context = context;
        }

        public async Task<FeedBack> Create(FeedBack feedBack)
        {
            _context.Entry(feedBack).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return feedBack;
        }
        public async Task<FeedBack> GetFeedBack(int id)
        {
            FeedBack feedBack = await _context.FeedBacks.FindAsync(id);

            return feedBack;
        }

        public async Task<List<FeedBack>> GetFeedBacks()
        {
            var feedBack = await _context.FeedBacks.ToListAsync();
            return feedBack;
        }

        public async Task<FeedBack> UpdateFeedBack(int id, FeedBack feedBack)
        {
            _context.Entry(feedBack).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return feedBack;
        }
        public async Task Delete(int id)
        {
            FeedBack feedBack = await GetFeedBack(id);

            _context.Entry(feedBack).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
    }
}

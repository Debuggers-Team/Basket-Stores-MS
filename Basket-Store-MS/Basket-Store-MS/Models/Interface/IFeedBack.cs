using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface IFeedBack
    {
        Task<FeedBack> Create(FeedBack feedBack);
        Task<List<FeedBack>> GetFeedBacks();
        Task<FeedBack> GetFeedBack(int id);
        Task<FeedBack> UpdateFeedBack(int id, FeedBack feedBack);
        Task Delete(int id);
    }
}

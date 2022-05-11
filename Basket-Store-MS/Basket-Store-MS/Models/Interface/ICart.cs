using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface ICart
    {
        Task<Cart> Create(Cart cart);
        Task<List<Cart>> GetCarts();
        Task<Cart> GetCart(int id);
        Task<Cart> UpdateCart(int id, Cart cart);
        Task Delete(int id);


    }
}

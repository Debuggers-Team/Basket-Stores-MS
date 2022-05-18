using Basket_Store_MS.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface ICart
    {
        Task<CartDto> Create(Cart cart);
        Task<List<CartDto>> GetCarts();
        Task<CartDto> GetCart(int id);
        Task<CartDto> UpdateCart(int id, Cart newCart);
        Task Delete(int id);
        Task AddProductToCart(int productId, int cartId);
        Task RemoveProductFromCart(int productId, int cartId);
        Task<BillDto> GetBill(int id);

    }
}

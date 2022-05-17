using Basket_Store_MS.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface IFavourite
    {
        Task<FavouriteDto> Create(Favourite cart);
        Task<List<FavouriteDto>> GetFavourites();
        Task<FavouriteDto> GetFavourite(int id);
        Task<FavouriteDto> UpdateFavourite(int id, Favourite newCart);
        Task AddProductToFavourite(int productId, int favouriteId);
        Task RemoveProductFromFavourite(int productId, int favouriteId);

        Task Delete(int id);
    }
}

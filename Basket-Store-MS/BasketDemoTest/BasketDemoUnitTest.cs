using System;
using Xunit;
using Basket_Store_MS;
using System.Threading.Tasks;
using Basket_Store_MS.Models.Services;
using BasketDemoTest;

namespace Basket_Store_Test
{
    public class BasketDemoUnitTest : Mock
    {
        [Fact]
        public async Task Test1()
        {
            var cart = await CreateAndSaveTestCart();
            var product = await CreateAndSaveTestProduct();

            var cartProduct = new CartService(_db);

            // Act
            await cartProduct.AddProductToCart(cart.Id, product.Id);

            // Assert
            var actualCart = await cartProduct.GetCart(cart.Id);

            Assert.Contains(actualCart.Products, a => a.Id == product.Id);

            // Act
            await cartProduct.RemoveProductFromCart(cart.Id, product.Id);

            // Assert
            actualCart = await cartProduct.GetCart(cart.Id);

            Assert.DoesNotContain(actualCart.Products, a => a.Id == product.Id);
        }
        [Fact]
        public async Task AddandRemoveFavourite()
        {
            var fav = await CreateAndSaveTestFavourite();
            var product = await CreateAndSaveTestProduct();


            var favourite = new FavouriteService(_db);

            // Act
            await favourite.AddProductToFavourite(fav.Id, product.Id);

            // Assert
            var actualFav = await favourite.GetFavourite(fav.Id);

            Assert.Contains(actualFav.Products, a => a.Id == product.Id);

            // Act
            await favourite.RemoveProductFromFavourite(fav.Id,product.Id);

            // Assert
            actualFav = await favourite.GetFavourite(fav.Id);

            Assert.DoesNotContain(actualFav.Products, a => a.Id == product.Id);
        }
    }
}
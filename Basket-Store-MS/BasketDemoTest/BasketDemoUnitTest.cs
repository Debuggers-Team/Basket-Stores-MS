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
            await cartProduct.AddProductToCart(product.Id, cart.Id);

            // Assert
            var actualCart = await cartProduct.GetCart(cart.Id);

            Assert.Contains(actualCart.Products, a => a.Id == product.Id);

            // Act
            await cartProduct.RemoveProductFromCart(product.Id, cart.Id);

            // Assert
            actualCart = await cartProduct.GetCart(cart.Id);

            Assert.DoesNotContain(actualCart.Products, a => a.Id == product.Id);
        }
    }
}
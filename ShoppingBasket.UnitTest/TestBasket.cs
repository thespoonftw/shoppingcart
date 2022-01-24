using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestBasket
    {
        private IBasketService basketService;

        public TestBasket(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        [TestMethod]
        public void Empty_Basket()
        {
            var basket = basketService.CalculateBasket("");
            Assert.AreEqual(basket.SubTotal, "£0.00");
        }
    }
}

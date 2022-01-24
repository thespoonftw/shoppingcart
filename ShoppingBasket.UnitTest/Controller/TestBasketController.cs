using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingBasket;
using ShoppingBasket.Controllers;
using System.Collections.Generic;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestBasketController
    {
        private BasketController sut;
        private Basket testBasket;

        [TestInitialize]
        public void TestInitialise()
        {
            testBasket = new Basket();
            var mockBasket = new Mock<IBasketService>();
            mockBasket.Setup(p => p.CalculateBasket(It.IsAny<string>())).Returns(testBasket);
            sut = new BasketController(mockBasket.Object);
        }

        [TestMethod]
        public void Basket_Get_Is_Equal()
        {
            Assert.AreEqual(testBasket, sut.Get(""));
        }
    }
}

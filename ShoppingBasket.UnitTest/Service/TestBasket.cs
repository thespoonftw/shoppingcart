using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestBasket
    {
        private BasketService sut;

        [TestInitialize]
        public void TestInitialise()
        {
            var mockDatabase = new Mock<IDatabaseService>();
            var productA = new Product() { ProductId = 0, Price = 100 };
            var productB = new Product() { ProductId = 1, Price = 50 };
            mockDatabase.Setup(p => p.GetProduct(0)).Returns(productA);
            mockDatabase.Setup(p => p.GetProduct(1)).Returns(productB);

            sut = new BasketService(mockDatabase.Object, new Mock<IDiscountService>().Object);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("1x3")]
        public void Basket_Is_Empty(string basketString)
        {
            var basket = sut.CalculateBasket(basketString);
            Assert.AreEqual(basket.Products.Length, 0);
            Assert.AreEqual(basket.Discounts.Length, 0);
            Assert.AreEqual(basket.SubTotal, 0);
            Assert.AreEqual(basket.Total, 0);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow("1x4_2xh")]
        [DataRow("1x")]
        [DataRow("2_1")]
        [DataRow("_")]
        [DataRow("x")]
        [DataRow("-1x5")]
        public void Basket_Throws_ArguementException(string basketString)
        {
            Assert.ThrowsException<System.ArgumentException>(() => sut.CalculateBasket(basketString));
        }

        [DataTestMethod]
        [DataRow("1x0", 1, 100)]
        [DataRow("2x0_3x1", 2, 350)]
        [DataRow("2x0_3x1_1x2", 2, 350)]
        public void Basket_Values_Correct(string basketString, int productCount, int totalPrice)
        {
            var basket = sut.CalculateBasket(basketString);
            Assert.AreEqual(basket.SubTotal, totalPrice);
            Assert.AreEqual(basket.Total, totalPrice);
            Assert.AreEqual(basket.Discounts.Length, 0);
            Assert.AreEqual(basket.Products.Length, productCount);
        }
    }

    [TestClass]
    public class TestBasketWithDiscount
    {
        private BasketService sut;

        [TestInitialize]
        public void TestInitialise()
        {
            var mockDatabase = new Mock<IDatabaseService>();
            var productA = new Product() { ProductId = 0, Price = 100 };
            var productB = new Product() { ProductId = 1, Price = 50 };
            mockDatabase.Setup(p => p.GetProduct(0)).Returns(productA);
            mockDatabase.Setup(p => p.GetProduct(1)).Returns(productB);

            var mockDiscount = new Mock<IDiscountService>();
            var discountA = new BasketItem[] { new BasketItem() { Amount = 1, Price = 50 } };
            mockDiscount.Setup(p => p.GetDiscounts(It.IsAny<Dictionary<int, int>>())).Returns(discountA);

            sut = new BasketService(mockDatabase.Object, mockDiscount.Object);
        }

        [DataTestMethod]
        [DataRow("1x0", 100, 50)]
        [DataRow("2x0_3x1", 350, 300)]
        public void Basket_With_Discount_Values_Correct(string basketString, int subtotal, int total)
        {
            var basket = sut.CalculateBasket(basketString);
            Assert.AreEqual(basket.SubTotal, subtotal);
            Assert.AreEqual(basket.Total, total);
            Assert.AreEqual(basket.Discounts.Length, 1);
        }
    }
}

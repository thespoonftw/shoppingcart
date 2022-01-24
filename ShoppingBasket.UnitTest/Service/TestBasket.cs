using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestBasket
    {
        private BasketService sut;

        [TestInitialize]
        public void TestInitialise()
        {
            var data = new DatabaseService();
            var disc = new DiscountService(data);
            sut = new BasketService(data, disc);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("1x9999")] // 9999 does not exist in database currently
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
        [DataRow("1x0", 110, 110)]
        [DataRow("5x0", 550, 550)]
        // scenario 1: soup and 2 bread
        [DataRow("1x3_2x0", 280, 225)]
        // scenario 2: 3 cheeses
        [DataRow("3x2", 270, 180)]
        // scenario 3: 4 cheeses
        [DataRow("4x2", 360, 180)]
        // scenario 4: butter alone
        [DataRow("1x4", 120, 80)]
        // scenario 5: butter with milk
        [DataRow("1x4_1x1", 170, 130)]
        // scenario 6: 1 bread, 2 milk, 3 cheeses, 4 soup, 5 butter
        [DataRow("1x0_2x1_3x2_4x3_5x4", 1320, 975)]  
        public void Basket_Scenarios(string basketString, int subTotal, int total)
        {
            var basket = sut.CalculateBasket(basketString);
            Assert.AreEqual(basket.SubTotal, subTotal);
            Assert.AreEqual(basket.Total, total);
        }

    }
}

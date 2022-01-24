using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestDiscount
    {
        private DiscountService sut;

        [TestInitialize]
        public void TestInitialise()
        {
            // ideally would be using mock values here, but will just use the database values this time
            sut = new DiscountService(new DatabaseService());
        }

        [TestMethod]
        public void GetDiscounts_Is_Empty()
        {
            Assert.AreEqual(sut.GetDiscounts(null).Length, 0);
            Assert.AreEqual(sut.GetDiscounts(new Dictionary<int, int>()).Length, 0);

            var dict = new Dictionary<int, int> {
                { 0, 2 } // two bread
            };
            Assert.AreEqual(sut.GetDiscounts(dict).Length, 0);
        }

        [TestMethod]
        public void Discount_3_Bogof()
        {
            var dict = new Dictionary<int, int> {
                { 2, 3 } // three cheeses
            };
            var resultArray = sut.GetDiscounts(dict);
            Assert.AreEqual(resultArray.Length, 1);
            Assert.AreEqual(resultArray[0].Amount, 1);
            Assert.AreEqual(resultArray[0].Price, 90);
        }

        [TestMethod]
        public void Discount_4_Bogof()
        {
            var dict = new Dictionary<int, int> {
                { 2, 4 } // four cheeses
            };
            var resultArray = sut.GetDiscounts(dict);
            Assert.AreEqual(resultArray.Length, 1);
            Assert.AreEqual(resultArray[0].Amount, 2);
            Assert.AreEqual(resultArray[0].Price, 90);
        }

        [TestMethod]
        public void Discount_Third_Off()
        {
            var dict = new Dictionary<int, int> {
                { 4, 2 } // two butters
            };
            var resultArray = sut.GetDiscounts(dict);
            Assert.AreEqual(resultArray.Length, 1);
            Assert.AreEqual(resultArray[0].Amount, 2);
            Assert.AreEqual(resultArray[0].Price, 40);
        }


        [TestMethod]
        public void Discount_Buy_One_Get_One_Half_Price()
        {
            var dict = new Dictionary<int, int> {
                { 0, 2 }, { 3, 1 } // one soup, two bread
            };
            var resultArray = sut.GetDiscounts(dict);
            Assert.AreEqual(resultArray.Length, 1);
            Assert.AreEqual(resultArray[0].Amount, 1);
            Assert.AreEqual(resultArray[0].Price, 55);
        }

    }

}

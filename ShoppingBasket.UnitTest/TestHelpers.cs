using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket;
using System.Collections.Generic;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestHelpers
    {
        [TestMethod]
        public void ToPriceString_Validation()
        {
            Assert.AreEqual("£0.00", 0.ToPriceString());
            Assert.AreEqual("£0.55", 55.ToPriceString());
            Assert.AreEqual("£2.00", 200.ToPriceString());
            Assert.AreEqual("£1234.56", 123456.ToPriceString());
            Assert.AreEqual("-£1.01", (-101).ToPriceString());
        }

        [TestMethod]
        public void BasketStringToDictionary_Validation()
        {
            var emptyDictionary = new Dictionary<int, int>();
            Assert.AreEqual(emptyDictionary, UriConverter.BasketStringToDictionary(""));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestHelpers
    {
        [TestMethod]
        public void Verify_ToPriceString()
        {
            Assert.AreEqual("£0.00", 0.ToPriceString());
            Assert.AreEqual("£0.01", 1.ToPriceString());
            Assert.AreEqual("£0.55", 55.ToPriceString());
            Assert.AreEqual("£2.00", 200.ToPriceString());
            Assert.AreEqual("£1234.56", 123456.ToPriceString());
            Assert.AreEqual("-£0.30", (-30).ToPriceString());
            Assert.AreEqual("-£1.01", (-101).ToPriceString());
        }
    }
}

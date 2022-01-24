using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket;
using System.Collections.Generic;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestHelpers
    {
        [DataTestMethod]
        [DataRow(0, "£0.00")]
        [DataRow(55, "£0.55")]
        [DataRow(200, "£2.00")]
        [DataRow(123456, "£1234.56")]
        [DataRow(-101, "-£1.01")]
        public void ToPriceString_Validation(int input, string output)
        {
            Assert.AreEqual(input.ToPriceString(), output);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingBasket;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestDatabase
    {
        [TestMethod]
        public void Negative_Index_OutOfRange()
        {
            var service = new DatabaseService();
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => service.GetProduct(-1));
        }

        [TestMethod]
        public void Large_Index_Is_Null()
        {
            var service = new DatabaseService();
            Assert.AreEqual(service.GetProduct(1000000), null);
        }

        [TestMethod]
        public void Database_Not_Empty()
        {
            var service = new DatabaseService();
            Assert.IsNotNull(service.GetProduct(0));

        }
    }
}

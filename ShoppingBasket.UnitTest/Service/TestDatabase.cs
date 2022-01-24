using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestDatabase
    {
        private DatabaseService sut;

        [TestInitialize]
        public void TestInitialise()
        {
            sut = new DatabaseService();
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(9999)] // assumed to be higher than max product id
        public void GetProduct_Is_Null(int productId)
        {
            Assert.IsNull(sut.GetProduct(productId));
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void GetProduct_Is_Not_Null(int productId)
        {
            Assert.IsNotNull(sut.GetProduct(productId));
        }

        [TestMethod]
        public void GetProducts_Is_Not_Zero()
        {
            Assert.IsTrue(sut.GetAllProducts().Length > 0);
        }
    }
}

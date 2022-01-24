using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingBasket;
using ShoppingBasket.Controllers;
using System.Collections.Generic;

namespace ShoppingBasket.UnitTest
{
    [TestClass]
    public class TestProductController
    {
        private ProductController sut;
        private Product[] testArray;

        [TestInitialize]
        public void TestInitialise()
        {
            testArray = new Product[] { new Product() };
            var mockDatabase = new Mock<IDatabaseService>();
            mockDatabase.Setup(p => p.GetAllProducts()).Returns(testArray);
            sut = new ProductController(mockDatabase.Object);
        }

        [TestMethod]
        public void Product_Get_Is_Equal()
        {
            Assert.AreEqual(testArray, sut.Get());
        }
    }
}

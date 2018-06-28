using Amalay.Business;
using Amalay.Model;
using Amalay.MvcApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Amalay.MvcApp.Tests.Controllers
{
    [TestClass]
    public class TestProductController
    {
        private Mock<IProductManager> manager = null;
        private ProductController controller = null;
        private List<ProductViewModel> products = null;

        [TestInitialize]
        public void Initialize()
        {
            this.manager = new Mock<IProductManager>();
            this.controller = new ProductController(this.manager.Object);
            this.products = TestData.Instance.ProductList;
        }

        [TestMethod]
        public void Test_ProductController_Index()
        {
            //Arrange 
            this.manager.Setup(x => x.GetAllProducts()).Returns(this.products);

            //Act 
            var result = ((controller.Index() as ViewResult).Model) as List<ProductViewModel>;

            //Assert 
            Assert.AreEqual(this.products.Count, result.Count);            
        }

        [TestMethod]
        public void Test_ProductController_AddItem()
        {
            //Arrange 
            this.manager.Setup(x => x.GetProduct(1)).Returns((ProductViewModel p) => p);

            //Act 
            var result = controller.AddItem(1) as ViewResult;
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Model);
            var cartItems = result.Model as List<CartModel>;

            Assert.IsNotNull(cartItems);            
            Assert.IsTrue(cartItems.Count > 0);
        }
    }
}

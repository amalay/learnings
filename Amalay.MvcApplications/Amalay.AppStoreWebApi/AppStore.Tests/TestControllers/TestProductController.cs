using AppStore.Controllers;
using AppStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace AppStore.Tests
{
    [TestClass]
    public class TestProductController
    {
        private TestAppStoreContext context = null;
        private ProductsController controller = null;
        private int totalProduct = 5;
        public TestProductController()
        {
            this.context = new TestAppStoreContext() { Products = Utility.Instance.LoadTestProducts(totalProduct) };
            this.controller = new ProductsController(this.context);
        }

        [TestMethod]
        public void GetProducts_ShouldReturnAllProducts()
        {            
            var result = this.controller.GetProducts() as TestProductDbSet;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), totalProduct);
        }

        [TestMethod]
        public void GetProduct_ShouldReturnProductWithSameId()
        {
            var result = this.controller.GetProduct(3) as OkNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id, 3);
        }
        
        [TestMethod]
        public void PostProduct_ShouldReturnSameProduct()
        {
            var product = Utility.Instance.CreateProduct(6);
            var result = this.controller.PostProduct(product) as CreatedAtRouteNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Name, product.Name);
        }

        [TestMethod]
        public void PutProduct_ShouldReturnStatusCode()
        {
            var product = Utility.Instance.CreateProduct(3);
            var result = this.controller.PutProduct(product.Id, product) as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void PutProduct_ShouldFail_WhenDifferentID()
        {
            var product = Utility.Instance.CreateProduct(3);
            var badresult = this.controller.PutProduct(9, product);

            Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
        }
        

        [TestMethod]
        public void DeleteProduct_ShouldReturnOK()
        {
            var result = this.controller.DeleteProduct(3) as OkNegotiatedContentResult<Product>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id, 3);
        }
    }
}

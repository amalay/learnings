using Amalay.Business;
using Amalay.Model;
using Amalay.Repository;
using Amalay.Repository.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.MvcApp.Tests.Businesses
{
    [TestClass]
    public class TestProductManager
    {
        private Mock<IProductRepository> repository;
        private IProductManager manager;
        private Mock<IUnitOfWork> unitWork;
        private List<Product> products = null;
        private List<OfferRule> offerRules = null;
        private List<ProductOfferRule> productOfferRules = null;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Mock<IProductRepository>();
            unitWork = new Mock<IUnitOfWork>();
            manager = new ProductManager(unitWork.Object, repository.Object);

            this.products = SeedingData.Instance.Products.ToList();
            this.offerRules = SeedingData.Instance.OfferRules.ToList();
            this.productOfferRules = SeedingData.Instance.ProductOfferRules.ToList();
        }

        [TestMethod]
        public void Test_ProductManager_GetAll()
        {
            //Arrange 
            repository.Setup(x => x.GetAll()).Returns(this.products);

            //Act 
            var result = manager.GetAll();

            //Assert
            Assert.IsNotNull(result);

            var products = result as List<Product>;

            Assert.IsNotNull(products);
            Assert.AreEqual(this.products.Count, products.Count);
        }

        [TestMethod]
        public void Test_ProductManager_GetById()
        {
            //Arrange 
            repository.Setup(x => x.GetById(It.IsAny<int>())).Returns((Product p) => p);

            //Act 
            var result = manager.GetById(5);

            //Assert 
            Assert.IsNotNull(result);

            var product = result as Product;
            Assert.IsNotNull(product);
            Assert.AreEqual("Product 5", product.Name);
        }
        

        [TestMethod]
        public void Test_ProductManager_GetAllProducts()
        {
            //Arrange 
            //repository.Setup(x => x.GetAllProducts()).Returns((this.products));

            //Act 
            var result = manager.GetAllProducts();
            Assert.IsNotNull(result);

            //Assert 
            var products = result as List<ProductViewModel>;
            Assert.IsNotNull(products);
            Assert.AreEqual(this.products.Count, products.Count);
        }

        [TestMethod]
        public void Test_ProductManager_Create()
        {
            //Arrange 
            int Id = 14;
            var product = new Product() { Name = "Product 14", MRP = 140, SellingPrice = 120 };

            repository.Setup(x => x.Add(product)).Returns((Product p) =>
            {
                p.Id = Id;
                return p;
            });
            
            //Act 
            manager.Create(product);

            //Assert 
            Assert.AreEqual(Id, product.Id);
            unitWork.Verify(m => m.Commit(), Times.Once);
        }

        #region "Sample Test Flow Example"

        public void Test()
        {
            //Arrange            
            Mock<IObject> _mockObj = new Mock<IObject>();

            var dummyVal = new RetObj();
            _mockObj.Setup(x => x.AnotherMethod()).Returns(dummyVal);

            //Act 
            var result = MyMethod(_mockObj.Object);

            //Assert 
            Assert.Equals(dummyVal, result);
        }

        public class RetObj
        {

        }

        public interface IObject
        {
            RetObj AnotherMethod();
        }

        public RetObj MyMethod(IObject obj)
        {
            var ret = obj.AnotherMethod();

            return ret;
        }

        #endregion
    }
}

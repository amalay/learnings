using Amalay.Model;
using Amalay.Repository;
using Amalay.Repository.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.MvcApp.Tests.Repositories
{
    [TestClass]
    public class TestProductRepository
    {
        DbConnection connection;
        AmalayTestDbContext context;
        ProductRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            context = new AmalayTestDbContext(connection);
            repository = new ProductRepository(context);
        }

        [TestMethod]
        public void Test_ProductRepository_GetAll()
        {
            //Act 
            var result = repository.GetAll().ToList();

            //Assert
            Assert.IsNotNull(result);

            var products = result as List<Product>;
            Assert.IsNotNull(products);
            Assert.AreEqual(SeedingData.Instance.Products.Count(), products.Count);
        }        

        [TestMethod]
        public void Test_ProductRepository_GetById()
        {
            //Act 
            var result = repository.GetById(5);

            //Assert
            Assert.IsNotNull(result);

            var product = result as Product;
            Assert.IsNotNull(product);
            Assert.AreEqual(product.Name, "Product 5");
        }

        [TestMethod]
        public void Test_ProductRepository_GetAllProducts()
        {
            //Act 
            var result = repository.GetAllProducts().ToList();

            //Assert 
            Assert.IsNotNull(result);

            var productViewModels = result as List<ProductViewModel>;
            Assert.IsNotNull(productViewModels);
            Assert.IsTrue(result.Count > 0);
        }
    }
}

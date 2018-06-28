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
    public class TestProductOfferRuleRepository
    {
        DbConnection connection;
        AmalayTestDbContext context;
        ProductOfferRuleRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            context = new AmalayTestDbContext(connection);
            repository = new ProductOfferRuleRepository(context);
        }

        [TestMethod]
        public void Test_ProductOfferRuleRepository_GetAll()
        {
            //Act 
            var result = repository.GetAll().ToList();

            //Assert
            Assert.IsNotNull(result);

            var productOfferRules = result as List<ProductOfferRule>;
            Assert.IsNotNull(productOfferRules);
            Assert.AreEqual(SeedingData.Instance.ProductOfferRules.Count(), productOfferRules.Count);
        }

        [TestMethod]
        public void Test_ProductOfferRuleRepository_GetById()
        {
            //Act 
            var result = repository.GetById(5);

            //Assert
            Assert.IsNotNull(result);

            var productOfferRule = result as ProductOfferRule;
            Assert.IsNotNull(productOfferRule);
            Assert.AreEqual(productOfferRule.ProductId, 3);
            Assert.AreEqual(productOfferRule.OfferRuleId, 1);
        }
    }
}

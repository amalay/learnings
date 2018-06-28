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
    public class TestOfferRuleRepository
    {
        DbConnection connection;
        AmalayTestDbContext context;
        OfferRuleRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            connection = Effort.DbConnectionFactory.CreateTransient();
            context = new AmalayTestDbContext(connection);
            repository = new OfferRuleRepository(context);
        }

        [TestMethod]
        public void Test_OfferRuleRepository_GetAll()
        {
            //Act 
            var result = repository.GetAll().ToList();

            //Assert
            Assert.IsNotNull(result);

            var offerRules = result as List<OfferRule>;
            Assert.IsNotNull(offerRules);
            Assert.AreEqual(SeedingData.Instance.OfferRules.Count(), offerRules.Count);
        }

        [TestMethod]
        public void Test_OfferRuleRepository_GetById()
        {
            //Act 
            var result = repository.GetById(5);

            //Assert
            Assert.IsNotNull(result);

            var offerRule = result as OfferRule;
            Assert.IsNotNull(offerRule);
            Assert.AreEqual(offerRule.Name, "Buy 5 get 3 free");
        }
    }
}

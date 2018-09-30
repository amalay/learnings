﻿using Amalay.Model;
using Amalay.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.MvcApp.Tests.Repositories
{
    [TestClass]
    public class CountryRepositoryTestWithDB
    {

        AmalayTestDbContext databaseContext;
        CountryRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {
            databaseContext = new AmalayTestDbContext();
            objRepo = new CountryRepository(databaseContext);
        }

        [TestMethod]
        public void Country_Repository_Get_ALL()
        {
            //Act 
            var result = objRepo.GetAll().ToList();

            //Assert 

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);
        }

        [TestMethod]
        public void Country_Repository_Create()
        {
            //Arrange 
            Country c = new Country() { Name = "UK" };

            //Act 
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert 

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("UK", lst.Last().Name);
        }
    }
}

using Amalay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.MvcApp.Tests
{
    public class TestData
    {
        private List<ProductViewModel> productList = null;

        #region "Singleton Intance"

        private static readonly TestData _Instance = new TestData();

        private TestData()
        {
            this.productList = new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    Id = 1,
                    Name = "Product 1",
                    MRP = 10,
                    SellingPrice = 8,
                    OfferRules = new List<OfferRule>()
                    {
                        new OfferRule()
                        {
                            Id = 1,
                            Name = "Buy 1 get 1",
                            MinimumProductCount = 1,
                            FreeProductCount = 1,
                            DiscountPrecentage =0
                        }
                    }
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Product 2",
                    MRP = 20,
                    SellingPrice = 18,
                    OfferRules = new List<OfferRule>()
                    {
                        new OfferRule()
                        {
                            Id = 1,
                            Name = "Buy 3 get 1",
                            MinimumProductCount = 3,
                            FreeProductCount = 1,
                            DiscountPrecentage =0
                        }
                    }
                },
                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Product 3",
                    MRP = 30,
                    SellingPrice = 25,
                    OfferRules = new List<OfferRule>()
                    {
                        new OfferRule()
                        {
                            Id = 1,
                            Name = "Buy 3 get 1",
                            MinimumProductCount = 3,
                            FreeProductCount = 1,
                            DiscountPrecentage =0
                        },
                        new OfferRule()
                        {
                            Id = 2,
                            Name = "Buy 5 get 2",
                            MinimumProductCount = 5,
                            FreeProductCount = 2,
                            DiscountPrecentage =0
                        }
                    }
                }
            };
        }

        public static TestData Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public List<ProductViewModel> ProductList
        {
            get
            {
                return this.productList;
            }
        }
    }
}

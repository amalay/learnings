using Amalay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Repository.Migrations
{
    public class SeedingData
    {
        #region "Singleton Intance"

        private static readonly SeedingData _Instance = new SeedingData();

        private SeedingData()
        {
            this._Products = Enumerable.Range(1, 6).Select(i => new Product { Id = i, Name = $"Product {i}", MRP = i * 10, SellingPrice = (i * 10) - i });

            this._OfferRules = new List<OfferRule>()
            {
                new OfferRule(){ Id = 1, Name = "Buy 2 get 1 free", MinimumProductCount = 2, FreeProductCount = 1, DiscountPrecentage = 0},
                new OfferRule(){ Id = 2, Name = "Buy 3 get 1 free", MinimumProductCount = 3, FreeProductCount = 1, DiscountPrecentage = 0},
                new OfferRule(){ Id = 3, Name = "Buy 5 get 2 free", MinimumProductCount = 5, FreeProductCount = 2, DiscountPrecentage = 0},
                new OfferRule(){ Id = 4, Name = "Buy 1 get 1 free", MinimumProductCount = 1, FreeProductCount = 1, DiscountPrecentage = 0},
                new OfferRule(){ Id = 5, Name = "Buy 5 get 3 free", MinimumProductCount = 5, FreeProductCount = 3, DiscountPrecentage = 0}
            };

            this._ProductOfferRules = new List<ProductOfferRule>()
            {
                new ProductOfferRule(){ Id = 1, ProductId = 1, OfferRuleId = 4 },
                new ProductOfferRule(){ Id = 2, ProductId = 2, OfferRuleId = 1 },
                new ProductOfferRule(){ Id = 3, ProductId = 5, OfferRuleId = 2 },
                new ProductOfferRule(){ Id = 4, ProductId = 5, OfferRuleId = 3 },
                new ProductOfferRule(){ Id = 5, ProductId = 3, OfferRuleId = 1 },
                new ProductOfferRule(){ Id = 6, ProductId = 3, OfferRuleId = 5 }
            };
        }

        public static SeedingData Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        private IEnumerable<Product> _Products = null;
        private IEnumerable<OfferRule> _OfferRules = null;
        private IEnumerable<ProductOfferRule> _ProductOfferRules = null;        
        
        public IEnumerable<Product> Products
        {
            get
            {
                return this._Products;
            }
        }

        public IEnumerable<OfferRule> OfferRules
        {
            get
            {
                return this._OfferRules;
            }
        }

        public IEnumerable<ProductOfferRule> ProductOfferRules
        {
            get
            {
                return this._ProductOfferRules;
            }
        }
    }
}

using Amalay.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {

        }
        
        public Product GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }

        public List<ProductViewModel> GetAllProducts()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();

            var data = (
                        from p in context.Set<Product>()
                        join e in context.Set<ProductOfferRule>() on p.Id equals e.ProductId into ps
                        from e in ps.DefaultIfEmpty()
                        join o in context.Set<OfferRule>() on e.OfferRuleId equals o.Id into po
                        from o in po.DefaultIfEmpty()

                        select new
                        {
                            Id = p.Id,
                            Name = p.Name,
                            MRP = p.MRP,
                            SellingPrice = p.SellingPrice,
                            OfferRuleName = o.Name,
                            MinimumProductCount = (int?)o.MinimumProductCount ?? 0,
                            FreeProductCount = (int?)o.FreeProductCount ?? 0,
                            DiscountPrecentage = (int?)o.DiscountPrecentage ?? 0
                        }).ToList();

            if (data != null)
            {
                foreach (var item in data)
                {
                    var product = products.SingleOrDefault(p => p.Id == item.Id);

                    if (product == null)
                    {
                        product = new ProductViewModel()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            MRP = item.MRP,
                            SellingPrice = item.SellingPrice,
                            OfferRules = new List<OfferRule>()
                        };

                        products.Add(product);
                    }
                    else
                    {
                        goto AddOfferRule;
                    }

                    AddOfferRule:
                    if (!string.IsNullOrEmpty(item.OfferRuleName))
                    {
                        product.OfferRules.Add(new OfferRule()
                        {
                            Name = item.OfferRuleName,
                            MinimumProductCount = item.MinimumProductCount,
                            FreeProductCount = item.FreeProductCount,
                            DiscountPrecentage = item.DiscountPrecentage
                        });
                    }
                }
            }

            return products;
        }
    }
}

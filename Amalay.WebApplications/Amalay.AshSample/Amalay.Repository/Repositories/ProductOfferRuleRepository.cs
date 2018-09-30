using Amalay.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Repository
{
    public class ProductOfferRuleRepository : GenericRepository<ProductOfferRule>, IProductOfferRuleRepository
    {
        public ProductOfferRuleRepository(DbContext context) : base(context)
        {

        }

        public override IEnumerable<ProductOfferRule> GetAll()
        {
            return context.Set<ProductOfferRule>().Include(x => x.Product).Include(x => x.OfferRule).AsEnumerable();
        }

        //public ProductOfferRule GetById(long id)
        //{
        //    return _dbset.Include(x => x.Product).Include(x => x.OfferRule).Where(x => x.Id == id).FirstOrDefault();
        //}

        public ProductOfferRule GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}

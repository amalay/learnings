using Amalay.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Repository
{
    public class OfferRuleRepository : GenericRepository<OfferRule>, IOfferRuleRepository
    {
        public OfferRuleRepository(DbContext context) : base(context)
        {

        }

        public OfferRule GetById(long id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}

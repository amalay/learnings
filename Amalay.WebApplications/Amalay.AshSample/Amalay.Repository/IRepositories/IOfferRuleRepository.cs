using Amalay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Repository
{
    public interface IOfferRuleRepository : IGenericRepository<OfferRule>
    {
        OfferRule GetById(long id);
    }
}

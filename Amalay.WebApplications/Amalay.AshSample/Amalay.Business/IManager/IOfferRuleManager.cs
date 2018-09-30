using Amalay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Business
{
    public interface IOfferRuleManager : IEntityManager<OfferRule>
    {
        OfferRule GetById(long Id);
    }
}

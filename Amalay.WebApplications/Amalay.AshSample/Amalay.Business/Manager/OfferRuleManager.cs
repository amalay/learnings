using Amalay.Model;
using Amalay.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Business
{
    public class OfferRuleManager : EntityManager<OfferRule>, IOfferRuleManager
    {
        IUnitOfWork unitOfWork;
        IOfferRuleRepository repository;

        public OfferRuleManager(IUnitOfWork unitOfWork, IOfferRuleRepository repository) : base(unitOfWork, repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }


        public OfferRule GetById(long Id)
        {
            return this.repository.GetById(Id);
        }
    }
}

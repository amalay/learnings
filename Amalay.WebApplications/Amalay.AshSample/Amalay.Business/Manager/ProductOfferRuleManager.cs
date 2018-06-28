using Amalay.Model;
using Amalay.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Business
{
    public class ProductOfferRuleManager : EntityManager<ProductOfferRule>, IProductOfferRuleManager
    {
        IUnitOfWork unitOfWork;
        IProductOfferRuleRepository repository;

        public ProductOfferRuleManager(IUnitOfWork unitOfWork, IProductOfferRuleRepository repository) : base(unitOfWork, repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }


        public ProductOfferRule GetById(long Id)
        {
            return this.repository.GetById(Id);
        }
    }
}

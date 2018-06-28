using Amalay.Model;
using Amalay.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Business
{
    public class ProductManager : EntityManager<Product>, IProductManager
    {
        IUnitOfWork unitOfWork;
        IProductRepository repository;

        public ProductManager(IUnitOfWork unitOfWork, IProductRepository repository) : base(unitOfWork, repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        public Product GetById(long Id)
        {
            return this.repository.GetById(Id);
        }

        public List<ProductViewModel> GetAllProducts()
        {
            return this.repository.GetAllProducts();
        }

        public ProductViewModel GetProduct(int id)
        {
            ProductViewModel product = null;

            var products = this.GetAllProducts();

            if (products != null)
            {
                product = products.SingleOrDefault(p => p.Id == id);
            }

            return product;
        }
    }
}

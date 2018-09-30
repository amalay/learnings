using Amalay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.Business
{
    public interface IProductManager : IEntityManager<Product>
    {
        Product GetById(long Id);

        List<ProductViewModel> GetAllProducts();

        ProductViewModel GetProduct(int id);
    }
}

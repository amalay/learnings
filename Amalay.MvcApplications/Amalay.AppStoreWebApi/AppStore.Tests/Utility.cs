using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Tests
{
    public class Utility
    {
        #region "Singleton Intance"

        private static readonly Utility _Instance = new Utility();

        private Utility()
        {

        }

        public static Utility Instance
        {
            get
            {
                return _Instance;
            }
        }

        #endregion

        public TestProductDbSet LoadTestProducts(int totalProduct)
        {
            TestProductDbSet products = new TestProductDbSet();

            for(int i = 1; i<= totalProduct; i++)
            {
                products.Add(this.CreateProduct(i));
            }

            return products;
        }

        public Product CreateProduct(int id)
        {
            return new Product() { Id = id, Name = "Product " + id, Price = id * 10 };
        }
    }
}

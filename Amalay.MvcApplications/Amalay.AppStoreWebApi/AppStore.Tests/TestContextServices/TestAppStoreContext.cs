using AppStore.ContextServices;
using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Tests
{
    public class TestAppStoreContext : IAppStoreContext
    {
        public TestAppStoreContext()
        {
            this.Products = new TestProductDbSet();
        }

        public DbSet<Product> Products { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Product item) { }

        public void Dispose() { }
    }
}

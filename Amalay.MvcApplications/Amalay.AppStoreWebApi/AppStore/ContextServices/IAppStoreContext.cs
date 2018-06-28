using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.ContextServices
{
    public interface IAppStoreContext : IDisposable
    {
        DbSet<Product> Products { get; }

        int SaveChanges();

        void MarkAsModified(Product item);
    }
}

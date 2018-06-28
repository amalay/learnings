using AppStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppStore.ContextServices
{
    public class AppStoreContext : DbContext, IAppStoreContext
    {      
    
        public AppStoreContext() : base("name=AppStoreContext")
        {
        }

        public DbSet<Product> Products { get; set; }

        public void MarkAsModified(Product item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}

using Amalay.Model;
using Amalay.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.MvcApp.Tests
{
    public class AmalayTestDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<OfferRule> OfferRules { get; set; }

        public DbSet<ProductOfferRule> ProductOfferRules { get; set; }


        public AmalayTestDbContext() : base("Name=AmalayTestDbContext")
        {

        }
        public AmalayTestDbContext(bool enableLazyLoading, bool enableProxyCreation) : base("Name=AmalayTestDbContext")
        {
            Configuration.ProxyCreationEnabled = enableProxyCreation;
            Configuration.LazyLoadingEnabled = enableLazyLoading;
        }

        public AmalayTestDbContext(DbConnection connection) : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check           
            Database.SetInitializer<AmalayTestDbContext>(new AlwaysCreateInitializer());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<AmalayTestDbContext>
        {
            protected override void Seed(AmalayTestDbContext context)
            {
                context.SeedTestData(context);
                base.Seed(context);
            }
        }

        public class CreateInitializer : CreateDatabaseIfNotExists<AmalayTestDbContext>
        {
            protected override void Seed(AmalayTestDbContext context)
            {
                context.SeedTestData(context);
                base.Seed(context);
            }
        }

        public class AlwaysCreateInitializer : DropCreateDatabaseAlways<AmalayTestDbContext>
        {
            protected override void Seed(AmalayTestDbContext context)
            {
                context.SeedTestData(context);
                base.Seed(context);
            }
        }

        public void SeedTestData(AmalayTestDbContext Context)
        {
            Context.Products.AddRange(SeedingData.Instance.Products);
            Context.SaveChanges();

            Context.OfferRules.AddRange(SeedingData.Instance.OfferRules);
            Context.SaveChanges();

            Context.ProductOfferRules.AddRange(SeedingData.Instance.ProductOfferRules);
            Context.SaveChanges();
        }
    }
}

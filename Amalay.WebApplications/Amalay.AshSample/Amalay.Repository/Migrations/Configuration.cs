namespace Amalay.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Amalay.Repository.AmalayDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Amalay.Repository.AmalayDbContext context)
        {
            context.Products.AddRange(SeedingData.Instance.Products);
            context.SaveChanges();

            context.OfferRules.AddRange(SeedingData.Instance.OfferRules);
            context.SaveChanges();

            context.ProductOfferRules.AddRange(SeedingData.Instance.ProductOfferRules);
            context.SaveChanges();
        }
    }
}

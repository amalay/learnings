namespace Amalay.Repository.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Amalay.Repository.AmalayDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Amalay.Repository.AmalayDbContext context)
        {
            var countries = new List<Country>()
            {
                new Country() { Id = 1, Name = "India" },
                new Country() { Id = 2, Name = "USA" },
                new Country() { Id = 3, Name = "UK" }
            };

            context.Countries.AddRange(countries);
            context.SaveChanges();
        }
    }
}

namespace Amalay.TicketBooking.Migrations
{
    using EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //Seed plane informations.
            context.Planes.AddRange(SeedingData.Instance.Planes);
            context.SaveChanges();

            //Seed seating informations.
            context.Seatings.AddRange(SeedingData.Instance.Seatings);
            context.SaveChanges();
        }
    }
}

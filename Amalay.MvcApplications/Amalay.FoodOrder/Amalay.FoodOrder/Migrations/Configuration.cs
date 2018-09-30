namespace Amalay.FoodOrder.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Amalay.FoodOrder.DbContexts.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Amalay.FoodOrder.DbContexts.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var admin = new ApplicationUser { UserName = "admin@admin.com" };

            userManager.Create(admin, "Admin@123");

            roleManager.Create(new IdentityRole { Name = "Admin" });
            userManager.AddToRole(admin.Id, "Admin");

            //================================================
            var categories = new List<Category>()
            {
                new Category() { ID = 1, Name = "Category 1" },
                new Category() { ID = 2, Name = "Category 2" },
                new Category() { ID = 3, Name = "Category 3" }
            };

            context.Catagories.AddRange(categories);
            context.SaveChanges();

            var items = new List<Item>()
            {
                new Item() { ID = 1, CategoryId = 1, Name = "Item 1", Price = 10, ItemPictureUrl = "/Content/Images/Burger_01.jpg" },
                new Item() { ID = 2, CategoryId = 2, Name = "Item 2", Price = 20, ItemPictureUrl = "/Content/Images/Chicken65_01.jpg" },
                new Item() { ID = 3, CategoryId = 2, Name = "Item 3", Price = 30, ItemPictureUrl = "/Content/Images/EggBowl_01.jpg" },
                new Item() { ID = 4, CategoryId = 1, Name = "Item 4", Price = 40, ItemPictureUrl = "/Content/Images/MacD_01.jpg" },
                new Item() { ID = 5, CategoryId = 3, Name = "Item 5", Price = 50, ItemPictureUrl = "/Content/Images/PotatoChips_01.jpg" }
            };

            context.Items.AddRange(items);
            context.SaveChanges();

            //================================================
        }
    }
}
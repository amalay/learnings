using Amalay.FoodOrder.DbContexts;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using RestSharp;


namespace Amalay.FoodOrder.Models
{
    public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        private static IdentityRole ReturnNull()
        {
            return null;
        }
        
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
                        
            const string adminRoleName = "Admin";

            const string adminUserName = "admin@admin.com";
            const string adminUserPassword = "admin";

            const string guestUserName = "guest@guest.com";
            const string guestUserPassword = "guest";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(adminRoleName);

            if (role == null)
            {
                role = new IdentityRole(adminRoleName);
                var roleresult = roleManager.Create(role);
            }
            
            var adminUser = userManager.FindByName(adminUserName);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
                var result = userManager.Create(adminUser, adminUserPassword);
                result = userManager.SetLockoutEnabled(adminUser.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(adminUser.Id);

            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(adminUser.Id, role.Name);
            }

            var guestUser = userManager.FindByName(guestUserName);

            if (guestUser == null)
            {
                guestUser = new ApplicationUser { UserName = guestUserName, Email = guestUserName };
                var result = userManager.Create(guestUser, guestUserPassword);
                result = userManager.SetLockoutEnabled(guestUser.Id, false);
            }            
        }
    }
}
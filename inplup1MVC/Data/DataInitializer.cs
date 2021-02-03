using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace inplup1MVC.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.Migrate();
            
            SeedProductCategory(dbContext);
            SeedRoles(dbContext);

            SeedUsers(userManager);

        }

       

        private static void SeedProductCategory(ApplicationDbContext dbContext)
        {
            var productCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Kablar");
            if (productCategory == null)
                dbContext.ProductCategories.Add(new ProductCategory { Namn = "Kablar" });

            productCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Datorer");
            if(productCategory == null)
                dbContext.ProductCategories.Add(new ProductCategory { Namn = "Datorer" });
            
            productCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Skärmar");
            if (productCategory == null)
                dbContext.ProductCategories.Add(new ProductCategory { Namn = "Skärmar" });

            productCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Möss");
            if (productCategory == null)
                dbContext.ProductCategories.Add(new ProductCategory { Namn = "Möss" });

            productCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Laddare");
            if (productCategory == null)
                dbContext.ProductCategories.Add(new ProductCategory { Namn = "Laddare" });

            dbContext.SaveChanges();
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            AddUserIfNotExists(userManager, "stefan@superduper.se",
                "Hejsan123#", new[] { "Admin" });

            AddUserIfNotExists(userManager, "kalle@superduper.se",
                "Hejsan123#", new[] { "PlayerAdmin" });

            AddUserIfNotExists(userManager, "lisa@superduper.se",
                "Hejsan123#", new[] { "RefAdmin" });

            AddUserIfNotExists(userManager, "maja@superduper.se",
                "Hejsan123#", new[] { "RefAdmin", "PlayerAdmin" });

        }

        private static void AddUserIfNotExists(UserManager<IdentityUser> userManager,
            string userName, string password, string[] roles)
        {
            if (userManager.FindByEmailAsync(userName).Result != null)
                return;
            var identityUser = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            var result = userManager.CreateAsync(identityUser, password).Result;
            var r = userManager.AddToRolesAsync(identityUser, roles).Result;
        }

        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (role == null)
                dbContext.Roles.Add(new IdentityRole { Name = "Admin", NormalizedName = "Admin" });
            role = dbContext.Roles.FirstOrDefault(r => r.Name == "PlayerAdmin");
            if (role == null)
                dbContext.Roles.Add(new IdentityRole { Name = "PlayerAdmin", NormalizedName = "PlayerAdmin" });
            role = dbContext.Roles.FirstOrDefault(r => r.Name == "RefAdmin");
            if (role == null)
                dbContext.Roles.Add(new IdentityRole { Name = "RefAdmin", NormalizedName = "RefAdmin" });

            dbContext.SaveChanges();
        }

    }
}

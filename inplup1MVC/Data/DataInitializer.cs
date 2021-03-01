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
            SeedRoles(dbContext);
            SeedUsers(userManager);
        
            SeedProductCategory(dbContext);
            SeedProducts(dbContext);
           


        }


        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            AddUserIfNotExists(userManager, "stefan.holmberg@systementor.se",
                "Hejsan123#", new[] {"Admin"});

            AddUserIfNotExists(userManager, "stefan.holmbergmanager@systementor.se",
                "Hejsan123#", new[] { "ProductManager" });

            

        }

        private static void AddUserIfNotExists(UserManager<IdentityUser> userManager,
            string userName, string password, string[] roles)
        {
            if (userManager.FindByEmailAsync(userName).Result != null)
                return;
            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            var result = userManager.CreateAsync(user, password).Result;
            var r = userManager.AddToRolesAsync(user, roles).Result;
            //var r = userManager.AddToRolesAsync(identityUser, roles).Result;
        }

        private static void SeedRoles(ApplicationDbContext dbContext)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (role == null)
            { 
                dbContext.Roles.Add(new IdentityRole { Name = "Admin", NormalizedName = "Admin" });
            }
            role = dbContext.Roles.FirstOrDefault(r => r.Name == "ProductManager");
            if (role == null)
            { 
                dbContext.Roles.Add(new IdentityRole { Name = "ProductManager", NormalizedName = "ProductManager" });
            }
            dbContext.SaveChanges();
        }

        private static void SeedProductCategory(ApplicationDbContext dbContext)
        {
            var productCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Kablar");
            if (productCategory == null)
                dbContext.ProductCategories.Add(new ProductCategory { Namn = "Kablar" });

            productCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Datorer");
            if (productCategory == null)
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

        private static void SeedProducts(ApplicationDbContext dbContext)
        {
            var product = dbContext.Produkter.FirstOrDefault(r => r.Name == "Huawei MateBook 13");
            if (product == null)
                dbContext.Produkter.Add(new Product
                {
                    
                    Name = "Huawei MateBook 13",
                    Description = "En stark och kraftfull dator för dig som programerar",
                    Price = 11900,
                    ProductCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Datorer")


                });
            else
            {
                product.ProductCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Datorer");
            }

            product = dbContext.Produkter.FirstOrDefault(r => r.Name == "USB-C 2M");
            if (product == null)
                dbContext.Produkter.Add(new Product
                {
                    ProductCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Kablar"),
                    Name = "USB-C 2M",
                    Description = "USB-C i båda ändarna 2 meter ",
                    Price = 400

                });
            else
            {
                product.ProductCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Kablar");

            }

            product = dbContext.Produkter.FirstOrDefault(r => r.Name == "Lenovo 23 tum");
            if (product == null)
                dbContext.Produkter.Add(new Product
                {
                    ProductCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Skärmar"),
                    Name = "Lenovo 23 tum",
                    Description = "Full HD, HDMI, USB-C",
                    Price = 3200
                });
            else
            {
                product.ProductCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Skärmar");
            }

            product = dbContext.Produkter.FirstOrDefault(r => r.Name == "Trådlös spelmus");
            if (product == null)
                dbContext.Produkter.Add(new Product
                {
                    ProductCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Möss"),
                    Name = "Trådlös spelmus",
                    Description = "Denna mus har ett ergonimiskt handgrepp för dig som spelar mycket.",
                    Price = 1400
                });
            else
            {
                product.ProductCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Möss");
            }          

            product = dbContext.Produkter.FirstOrDefault(r => r.Name == "Iphone laddare");
            if (product == null)
                dbContext.Produkter.Add(new Product
                {
                    ProductCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Laddare"),
                    Name = "Iphone laddare",
                    Description = "Passar serie 6, 7, 8, 11",
                    Price = 250
                    
                });
            else
            {
                product.ProductCategory = dbContext.ProductCategories.FirstOrDefault(r => r.Namn == "Laddare");
            }

            dbContext.SaveChanges();

        }

    }
}

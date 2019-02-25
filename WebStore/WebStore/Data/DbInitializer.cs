using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.Context;
using WebStore.DomainEntities.Entities;

namespace WebStore.Data
{
    internal static class DbInitializer
    {
        internal static void Initialize(this WebStoreContext context)
        {
            context.Database.EnsureCreated();
            if (context.Products.Any())
                return;
            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var section in TestData.Sections)
                    context.Sections.Add(section);
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Sections] OFF");
                transaction.Commit();
            }
            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var brand in TestData.Brands)
                    context.Brands.Add(brand);
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Brands] OFF");
                transaction.Commit();
            }
            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var product in TestData.Products)
                    context.Products.Add(product);
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Products] OFF");
                transaction.Commit();
            }
        }
        internal static async Task InitializeIdentityAsync(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            if (!await roleManager.RoleExistsAsync(User.UserRole))
            {
                await roleManager.CreateAsync(new IdentityRole(User.UserRole));
            }
            if (! await roleManager.RoleExistsAsync(User.AdminUser))
            {
                await roleManager.CreateAsync(new IdentityRole(User.AdminUser));
            }
            var userManager = serviceProvider.GetService<UserManager<User>>();
            var userStore = serviceProvider.GetService<IUserStore<User>>();
            if (await userStore.FindByNameAsync(User.AdminUser, CancellationToken.None) is null)
            {
                var admin = new User
                {
                    UserName = User.AdminUser,
                    Email = $"{User.AdminUser}@server.ru"
                };
                if ((await userManager.CreateAsync(admin, "admin123")).Succeeded)
                    await userManager.AddToRoleAsync(admin, User.AdminRole);

            }
            if (await userStore.FindByNameAsync(User.TestUser, CancellationToken.None) is null)
            {
                var user = new User
                {
                    UserName = User.TestUser,
                    Email = $"{User.TestUser}@server.ru"
                };
                if ((await userManager.CreateAsync(user, "123")).Succeeded)
                    await userManager.AddToRoleAsync(user, User.UserRole);

            }


        }
    }
}

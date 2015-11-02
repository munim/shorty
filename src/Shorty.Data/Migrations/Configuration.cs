using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shorty.Data.DataObjects;
using Shorty.Data.Managers;

namespace Shorty.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shorty.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Shorty.Data.AppDbContext context)
        {
            CreateUsersAndRoles(context);
        }

        private void CreateUsersAndRoles(AppDbContext context)
        {
            CreateUsers(context);
            CreateRoles(context);
            AddUsersToRoles(context);

            CreateUrlEntry(context);
        }

        private void CreateUrlEntry(AppDbContext context)
        {
            context.Urls.AddOrUpdate(p=>p.ShortUrl, new Url()
            {
                ShortUrl = "g",
                FullUrl = "http://google.com/",
                CreatedDate = DateTimeOffset.UtcNow,
                OwnedBy = new AppUserManager(context).FindByName("anonymous"),
            });
        }

        private void AddUsersToRoles(AppDbContext context)
        {
            var roleManager = new AppRoleManager(context);
            var userManager = new AppUserManager(context);

            var adminUser = userManager.FindByName("admin");
            var anonUser = userManager.FindByName("anonymous");

            var adminRole = roleManager.FindByName("Administrator");
            var funcRole = roleManager.FindByName("Functional");


            if (adminUser != null && adminRole != null)
            {
                userManager.AddToRole(adminUser.Id, adminRole.Name);
            }

            if (anonUser != null && funcRole != null)
            {
                userManager.AddToRole(anonUser.Id, funcRole.Name);
            }
        }

        private void CreateRoles(AppDbContext context)
        {
            var roleManager = new AppRoleManager(context);

            if (roleManager.FindByName("Administrator") == null)
            {
                roleManager.Create(new IdentityRole("Administrator"));
            }

            if (roleManager.FindByName("Functional") == null)
            {
                roleManager.Create(new IdentityRole("Functional"));
            }
        }

        private void CreateUsers(AppDbContext context)
        {
            var userManager = new AppUserManager(context);

            if (userManager.FindByName("admin") == null)
            {
                userManager.Create(new AppUser
                {
                    UserName = "admin",
                    TimeZone = TimeZoneInfo.Utc.Id,
                    CreatedOn = DateTimeOffset.UtcNow,
                    Email = "admin@shorty.github.com"
                }, "P@ssw0rd");
            }
            if (userManager.FindByName("anonymous") == null)
            {
                userManager.Create(new AppUser
                {
                    UserName = "anonymous",
                    TimeZone = TimeZoneInfo.Utc.Id,
                    CreatedOn = DateTimeOffset.UtcNow,
                    Email = "anonymous@shorty.github.com",
                    EmailConfirmed = false
                });
            }
        }
    }
}

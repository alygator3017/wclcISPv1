namespace wclc.DataContexts.IdentityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using wclc.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<wclc.Models.IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\IdentityMigrations";
        }

        protected override void Seed(wclc.Models.IdentityDb context)
        {
            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppAdmin" };

                manager.Create(role);
            }
            if (!context.Users.Any(u => u.UserName == "mvcmanager@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "mvcmanager@gmail.com" };

                manager.Create(user, "B@nanas1");
                manager.AddToRole(user.Id, "AppAdmin");

            }
            if (!context.Users.Any(u => u.UserName == "alygator3017@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "alygator3017@gmail.com" };

                manager.Create(user, "z98S4@xy");
                manager.AddToRole(user.Id, "AppAdmin");

            }
            if (!context.Roles.Any(r => r.Name == "canEdit"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "canEdit" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "IT"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "IT" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "user"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "user" };
                manager.Create(role);
            }
        }
    }
}

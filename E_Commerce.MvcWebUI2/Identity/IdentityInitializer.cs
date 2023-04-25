using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Commerce.MvcWebUI2.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Rolleri
            if (!context.Roles.Any(i=> i.Name=="admin"))
            {
                var store=new RoleStore<ApplicationRole>(context);
                var manager=new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name="admin",Description="admin rolü"};
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name= "user", Description= "user rolü" };
                manager.Create(role);
            }
            if (!context.Users.Any(i => i.Name == "cptmfs"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Ferit", Surname = "Kaptan", UserName = "cptmfs", Email = "cpt.mfs@gmail.com" };
                manager.Create(user,"133441");
                manager.AddToRole(user.Id,"admin");
                manager.AddToRole(user.Id,"user");

            }
            if (!context.Users.Any(i => i.Name == "seysimsek"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Şeyma", Surname = "Şimşek", UserName = "seysimsek", Email = "sey@gmail.com" };
                manager.Create(user, "133441");
                manager.AddToRole(user.Id, "user");

            }
            base.Seed(context);
        }
    }
}
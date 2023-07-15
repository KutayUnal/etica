using E_ticaret_Uygulaması.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_ticaret_Uygulaması.Identity
{
    public class IdentityInitializer :CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Rolleri oluşturucam
            if(!context.Roles.Any(i=> i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager =new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin rolü" };
                manager.Create(role);
            }



            //User oluşturucam
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user",Description="user rolü" };
                manager.Create(role);
            }

            if (!context.Users.Any(i => i.Name == "ali"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                ApplicationUser user = new ApplicationUser() { Name = "ali", Surname = "sahin", UserName = "alisahin", Email = "alisahin@gmail.com" };


                manager.Create(user,"1");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(i => i.Name == "kutay"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "kutay", Surname = "unal", UserName = "ktyunl", Email = "ktyunal@gmail.com" };


                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
            }




            base.Seed(context);
        }

    }
}
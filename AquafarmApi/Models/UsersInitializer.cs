using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AquafarmApi.Models
{
    public class UsersInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var admin = new ApplicationUser { Email = "admin@unclespace.ru", UserName = "administrator" };
            string password = "Uncleadmin72!";
            var result = userManager.CreateAsync(admin, password);
            base.Seed(context);
        }
    }
}
using AquafarmApi.Models;
using AquafarmApi.Models.Purchase;
using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace AquafarmApi.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        public async Task<ActionResult> Initial()
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            var admin = new ApplicationUser { Email = "admin@unclespace.ru", UserName = "administrator" };
            string password = "Uncleadmin72!";
            IdentityResult result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                return View("Index");
            }
            else
            {
                return View("error", result.Errors);
            }
        }
        //public ActionResult TestDb()
        //{
        //        Context db = new Context();
        //        IEnumerable<Purchase> purchases = db.Purchases.ToList();
        //        return View(purchases);
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

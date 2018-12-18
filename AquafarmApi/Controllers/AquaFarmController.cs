using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using AquafarmApi.Models.Purchase;
using System.Web.Http.Cors;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace AquafarmApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AquaFarmController : ApiController
    {
        Context db = new Context();
        public HttpResponseMessage Get()
        {
            try
            {
                var response = db.Purchases;
                var json = JsonConvert.SerializeObject(response);
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
            catch
            {
                db.Dispose();
                var json = "Ничего";
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
        }
        [Authorize]
        public Purchase Get(string id)
        {
            try
            {
                Purchase purchase = db.Purchases.Find(id);
                db.Dispose();
                return purchase;
            }
            catch
            {
                db.Dispose();
                return null;
            }
        }

        [HttpPost]
        public void Post(Purchase purchase)
        {
            try
            {
                if (!ModelState.IsValid || purchase == null)
                {
                    return;
                }
                db.Purchases.Add(purchase);
                db.SaveChanges();
                db.Dispose();
            }
            catch
            {
                db.Dispose();
                return;
            }
        }

        public void Edit(int id, Purchase purchase)
        {
            if (id == purchase.id)
            {
                db.Entry(purchase).State = EntityState.Modified;
                db.SaveChanges();
            }
            db.Dispose();
        }
        public void Delete(int id)
        {
            Purchase purchase = db.Purchases.Find(id);
            if (purchase != null)
            {
                db.Purchases.Remove(purchase);
                db.SaveChanges();
            }
            db.Dispose();
        }
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

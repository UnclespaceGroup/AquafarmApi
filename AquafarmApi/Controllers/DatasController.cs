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
    [Authorize]
    public class DatasController : ApiController
    {
        Context db = new Context();

        public HttpResponseMessage Get()
        {
            try
            {
                var response = db.Datas;
                var json = JsonConvert.SerializeObject(response);
                db.Dispose();
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
            catch (Exception e)
            {
                db.Dispose();
                return Request.CreateResponse(HttpStatusCode.OK, e);
            }
        }

        public Data Get(string id)
        {
            try
            {
                Data data = db.Datas.Find(id);
                db.Dispose();
                return data;
            }
            catch
            {
                db.Dispose();
                return null;
            }
        }

        [HttpPost]
        public void Post(Data data)
        {
            try
            {
                if (!ModelState.IsValid || data == null)
                {
                    db.Dispose();
                    return;
                }
                db.Datas.Add(data);
                db.SaveChanges();
                db.Dispose();
            }
            catch
            {
                db.Dispose();
                return;
            }
        }

        public void Edit(int id, Data data)
        {
            if (id == data.id)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
            }
            db.Dispose();
        }
        public void Delete(int id)
        {
            Data data = db.Datas.Find(id);
            if (data != null)
            {
                db.Datas.Remove(data);
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
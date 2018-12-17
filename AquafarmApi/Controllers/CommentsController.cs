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
    public class CommentsController : ApiController
    {
        Context db = new Context();

        public HttpResponseMessage Get()
        {
            try
            {
                var response = db.Comments;
                db.Dispose();
                var json = JsonConvert.SerializeObject(response);
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.OK,e);
            }
        }

        public Comment Get(string id)
        {
            try
            {
                Comment comment = db.Comments.Find(id);
                db.Dispose();
                return comment;
            }
            catch
            {
                db.Dispose();
                return null;
            }
        }

        [HttpPost]
        public void Post(Comment comment)
        {
            try
            {
                if (!ModelState.IsValid || comment == null)
                {
                    db.Dispose();
                    return;
                }
                db.Comments.Add(comment);
                db.SaveChanges();
                db.Dispose();
            }
            catch
            {
                db.Dispose();
                return;
            }
        }

        public void Edit(int id, Comment comment)
        {
            if (id == comment.id)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
            }
            db.Dispose();
        }
        public void Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment != null)
            {
                db.Comments.Remove(comment);
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

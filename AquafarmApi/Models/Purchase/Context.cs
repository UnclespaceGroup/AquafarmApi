using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AquafarmApi.Models.Purchase
{
    public class Context : DbContext
    {
        public Context() : base("Context")
        {

        }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Data> Datas { get; set; }
    }
}
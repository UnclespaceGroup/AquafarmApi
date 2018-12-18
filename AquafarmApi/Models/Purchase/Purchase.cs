using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace AquafarmApi.Models.Purchase
{
    public class Purchase
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string date { get; set; }
        public string Email { get; set; }
        public string text { get; set; }
        public string active { get; set; }
    }
    public class Comment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string text { get; set; }
    }
    public class Data
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string text { get; set; }
    }
}
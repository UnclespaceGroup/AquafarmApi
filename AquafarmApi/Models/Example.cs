using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquafarmApi.Models
{
    public static class Example
    {
        static List<string> Store = new List<string>();

        public static void Add(string file)
        {
            Store.Add(file);
        }

        public static List<string> Get()
        {
            return Store;
        }
    }
}
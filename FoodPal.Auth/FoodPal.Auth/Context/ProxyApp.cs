using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPal.Auth.Context
{
    public class ProxyApp
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public string AppDescription { get; set; }
        public string AppUrl { get; set; }
    }
}

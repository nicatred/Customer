using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Data.Entities
{
    public class Customers
    {
      
        public int Id { get; set; }
      
        public string Name { get; set; }
     
        public string SureName { get; set; }
     
        public DateTime date { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonControll.Models
{
    public class ResPerson
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Person> persons { get; set; }
    }
}
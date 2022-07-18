using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonControll.Models
{
    public class PersonList
    {
        public int total { get; set; }
        public List<Person> newPerson { get; set; }
    }
}
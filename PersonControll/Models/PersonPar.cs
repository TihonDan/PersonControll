using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonControll.Models
{
    public class PersonPar
    {
        public  int id_person { get; set; }
        public string surname  { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime birthday { get; set; }
    }
}
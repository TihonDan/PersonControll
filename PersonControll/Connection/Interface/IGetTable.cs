using PersonControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonControll.Connection.Interface
{
    public interface IGetTable
    {
        List<Person> GetDataTable(string sql);
    }
}
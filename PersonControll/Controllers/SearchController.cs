using Castle.Windsor;
using PersonControll.CastleWind;
using PersonControll.Connection.Interface;
using PersonControll.Connection.SQL;
using PersonControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonControll.Controllers
{
    public class SearchController : Controller
    {
        ///GET: Search
        public ActionResult GetData(string surname, string firstname, string lastname, string firstBirthday, string lastBirthday)
        {
            
            var cont = new WindsorContainer();
            cont.Install(new CastleWindConf());
            IGetTable connect = cont.Resolve<IGetTable>();
            ISQL sql = cont.Resolve<ISQL>();
            List<Person> newCitizens = connect.GetDataTable(sql.GetAllColumn(surname, firstname, lastname, DateTime.Parse(firstBirthday), DateTime.Parse(lastBirthday)));
            ResPerson resResponse = new ResPerson();
            if (newCitizens.Count > 0)
            {
                resResponse.success = true;
                resResponse.message = "Операция выполнена";
                resResponse.persons = newCitizens;
            }
            else
            {
                resResponse.success = false;
                resResponse.message = "Ошибка!";
                resResponse.persons = newCitizens;
            }
            return Json(resResponse, JsonRequestBehavior.AllowGet);
        }
    }
}
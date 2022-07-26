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
    public class EditTableColumnController : Controller
    {
        public ActionResult AddColumn(string surname, string firstname, string lastname, string birthday)
        {
            var cont = new WindsorContainer();
            cont.Install(new CastleWindConf());
            IEditTable EditTable = cont.Resolve<IEditTable>();
            ISQL sql = cont.Resolve<ISQL>();
            ResPerson resResponse = EditTable.EditDataTable(sql.CreateColumn(surname, firstname, lastname, DateTime.Parse(birthday)));

            return Json(resResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateColumn(int id, string surname, string firstname, string lastname, string birthday)
        {
            var cont = new WindsorContainer();
            cont.Install(new CastleWindConf());
            IEditTable EditTable = cont.Resolve<IEditTable>();
            ISQL sql = cont.Resolve<ISQL>();
            ResPerson resResponse = EditTable.EditDataTable(sql.UpdateColumn(id, surname, firstname, lastname, DateTime.Parse(birthday)));

            return Json(resResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteColumn(int id)
        {
            var cont = new WindsorContainer();
            cont.Install(new CastleWindConf());
            IEditTable EditTable = cont.Resolve<IEditTable>();
            ISQL sql = cont.Resolve<ISQL>();
            ResPerson resResponse = EditTable.EditDataTable(sql.DeleteColumn(id));

            return Json(resResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPersonAll()
        {
            var cont = new WindsorContainer();
            cont.Install(new CastleWindConf());
            IGetTable connect = cont.Resolve<IGetTable>();
            ISQL sql = cont.Resolve<ISQL>();
            List<Person> newCitizens = connect.GetDataTable(sql.GetPersonAll());
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

            return Json(resResponse.persons, JsonRequestBehavior.AllowGet);
        }

    }
}
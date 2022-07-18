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
        public ActionResult AddColumn(string surname, string firstname, string fathername, DateTime birthday)
        {
            var cont = new WindsorContainer();
            cont.Install(new CastleWindConf());
            IEditTable EditTable = cont.Resolve<IEditTable>();
            ISQL sql = cont.Resolve<ISQL>();
            ResPerson resResponse = EditTable.EditDataTable(sql.CreateColumn(surname, firstname, fathername, birthday));

            return Json(resResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateColumn(int id, string surname, string firstname, string fathername, DateTime birthday)
        {
            var cont = new WindsorContainer();
            cont.Install(new CastleWindConf());
            IEditTable EditTable = cont.Resolve<IEditTable>();
            ISQL sql = cont.Resolve<ISQL>();
            ResPerson resResponse = EditTable.EditDataTable(sql.UpdateColumn(id, surname, firstname, fathername, birthday));

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

        public string Index()
        {
            return "Yesyyyy";
        }
    }
}
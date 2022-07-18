using Castle.Windsor;
using FastReport.Web;
using PersonControll.Connection.Interface;
using PersonControll.Connection.SQL;
using PersonControll.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastReport;
using PersonControll.CastleWind;

namespace PersonControll.Controllers
{
    public class FastReportController : Controller
    {
        //public FileResult GetReport(string surname, string firstname, string fathername, string firstBirthday, string lastBirthday)
        //{
        //    DateTime first = Convert.ToDateTime(firstBirthday);
        //    DateTime last = Convert.ToDateTime(lastBirthday);
        //    var cont = new WindsorContainer();
        //    cont.Install(new CastleWindConf());
        //    IGetTable connect = cont.Resolve<IGetTable>();
        //    ISQL sql = cont.Resolve<ISQL>();
        //    List<Person> citizens = connect.GetDataTable(sql.GetAllColumn(surname, firstname, fathername, first, last));

        //    Stream stream = new MemoryStream();
        //    WebReport webReport = new WebReport();
        //    webReport.Report.Load(this.Server.MapPath("~/FastRep/CitizensFastReport.frx"));
        //    TableObject table = webReport.Report.FindObject("Table2") as TableObject;
        //    table.ColumnCount = 5;
        //    table.RowCount = citizens.Count;
        //    if (table != null)
        //    {
        //        for (int row = 0; row < citizens.Count; row++)
        //        {
        //            table[0, row].Text = citizens[row].id_person;
        //            table[1, row].Text = citizens[row].surname;
        //            table[2, row].Text = citizens[row].firstname;
        //            table[3, row].Text = citizens[row].lastname;
        //            table[4, row].Text = citizens[row].birthday;

        //            table[0, row].Border.Lines = BorderLines.All;
        //            table[1, row].Border.Lines = BorderLines.All;
        //            table[2, row].Border.Lines = BorderLines.All;
        //            table[3, row].Border.Lines = BorderLines.All;
        //            table[4, row].Border.Lines = BorderLines.All;
        //        }
        //        webReport.Report.Prepare();
        //        webReport.Report.Export(new PDFExport(), stream);
        //        stream.Position = 0;
        //    }

        //    return File(stream, "application/zip", "Report.pdf");
        //}
    }
}
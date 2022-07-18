using PersonControll.Connection.IBMConnect.Interface;
using PersonControll.Connection.Interface;
using PersonControll.Connection.ParsConfig.Interface;
using PersonControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonControll.Connection
{
    public class Connect : IGetTable, IEditTable
    {
        IParsConfig configuration;
        IIfxConnectGetData connectionInformix;
        IIfxConnectEditTable connectionInformixEditTable;
        List<Person> persons = new List<Person>();
        IList<List<string>> listcolumn;

        public Connect(IIfxConnectGetData connectionInformix, IParsConfig configuration, IIfxConnectEditTable connectionInfmxEditTable)
        {

            this.connectionInformix = connectionInformix;
            this.configuration = configuration;
            this.connectionInformixEditTable = connectionInfmxEditTable;
        }

        public List<Person> GetDataTable(string sql)
        {
            configuration.ParseConfiguration();
            connectionInformix.CreateConnection(configuration.configurationConnect, sql);
            connectionInformix.OpenConnection();

            listcolumn = connectionInformix.GetDataReader();
            foreach (var column in listcolumn)
            {
                Person citizen = new Person();
                citizen.id_person = column[0];
                citizen.surname = column[1];
                citizen.firstname = column[2];
                citizen.lastname = column[3];
                citizen.birthday = column[4].Substring(0, 10);
                persons.Add(citizen);
            }
            connectionInformix.CloseConnection();

            return persons;
        }

        public ResPerson EditDataTable(SqlRes sqlRes)
        {
            configuration.ParseConfiguration();
            connectionInformixEditTable.CreateConnection(configuration.configurationConnect, sqlRes.sql);
            connectionInformixEditTable.OpenConnection();

            ResPerson result = connectionInformixEditTable.EditTable(sqlRes);

            connectionInformixEditTable.CloseConnection();
            return result;
        }

    }
}
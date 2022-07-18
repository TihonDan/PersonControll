using IBM.Data.Informix;
using PersonControll.Connection.IBMConnect.Interface;
using PersonControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonControll.Connection.IBMConnect
{
    public class ConnectionIBM : IIfxConnectGetData, IIfxConnectEditTable
    {
        IIfxCommandPar commandIfxParams;
        IfxConnection myConnection;
        IfxCommand ifxCommand;
        IfxDataReader ifxDataReader;
        ResPerson resResponse = new ResPerson();

        IList<List<string>> listcolumn = new List<List<string>>();

        string sql = "";

        public ConnectionIBM(IIfxCommandPar commandIfxParams)
        {
            this.commandIfxParams = commandIfxParams;
        }

        public void CloseConnection()
        {
            myConnection.Close();
        }

        public void CreateConnection(string configuration, string sql)
        {
            this.sql = sql;
            myConnection = new IfxConnection(configuration);
        }

        public ResPerson EditTable(SqlRes sqlRes)
        {
            ifxCommand = new IfxCommand(sql, myConnection);

            commandIfxParams.CreateParams(ifxCommand, sqlRes);

            int res = ifxCommand.ExecuteNonQuery();
            if (res == 1)
            {
                resResponse.success = true;
                resResponse.message = "Операция выполнена";
                return resResponse;
            }
            else
            {
                resResponse.success = false;
                resResponse.message = "Ошибка!";
                return resResponse;
            }
        }

        public IList<List<string>> GetDataReader()
        {
            ifxCommand = new IfxCommand(sql, myConnection);
            ifxDataReader = ifxCommand.ExecuteReader();


            while (ifxDataReader.Read())
            {
                List<string> column = new List<string>();
                column.Add(ifxDataReader["id_person"].ToString());
                column.Add(ifxDataReader["surname"].ToString());
                column.Add(ifxDataReader["firstname"].ToString());
                column.Add(ifxDataReader["lastname"].ToString());
                column.Add(ifxDataReader["birthday"].ToString());
                listcolumn.Add(column);
            }
            return listcolumn;
        }

        public void OpenConnection()
        {
            myConnection.Open();
        }
    }
}
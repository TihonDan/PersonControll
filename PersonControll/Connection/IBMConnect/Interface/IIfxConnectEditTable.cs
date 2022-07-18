using PersonControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonControll.Connection.IBMConnect.Interface
{
    public interface IIfxConnectEditTable
    {
        void CreateConnection(string configuration, string sql);
        ResPerson EditTable(SqlRes sqlRes);
        void OpenConnection();
        void CloseConnection();
    }
}

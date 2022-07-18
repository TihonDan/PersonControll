﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonControll.Connection.IBMConnect.Interface
{
    public interface IIfxConnectGetData
    {
        void CreateConnection(string configuration, string sql);
        IList<List<string>> GetDataReader();
        void OpenConnection();
        void CloseConnection();
    }
}

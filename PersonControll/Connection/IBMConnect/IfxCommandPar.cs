using IBM.Data.Informix;
using PersonControll.Connection.IBMConnect.Interface;
using PersonControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonControll.Connection.IBMConnect
{
    public class IfxCommandPar : IIfxCommandPar
    {
        IfxCommand ifxCommand;
        SqlRes sqlRes;

        public void CreateParams(IfxCommand ifxCommand, SqlRes sqlRes)
        {
            this.ifxCommand = ifxCommand;
            this.sqlRes = sqlRes;

            string[] sql = sqlRes.sql.Split(new char[] { ' ' });

            if (sql[0] == "INSERT")
            {
                CreateColumnCreateParams();
            }
            if (sql[0] == "UPDATE")
            {
                UpdateColumnCreateParams();
            }
            if (sql[0] == "DELETE")
            {
                DeleteColumnCreateParams();
            }
        }

        void CreateColumnCreateParams()
        {
            ifxCommand.Parameters.Add(new IfxParameter("surname", sqlRes.personPar.surname));
            ifxCommand.Parameters.Add(new IfxParameter("firstname", sqlRes.personPar.firstname));
            ifxCommand.Parameters.Add(new IfxParameter("lastname", sqlRes.personPar.lastname));
            ifxCommand.Parameters.Add(new IfxParameter("birthday", sqlRes.personPar.birthday));
        }

        void UpdateColumnCreateParams()
        {
            ifxCommand.Parameters.Add(new IfxParameter("surname", sqlRes.personPar.surname));
            ifxCommand.Parameters.Add(new IfxParameter("firstname", sqlRes.personPar.firstname));
            ifxCommand.Parameters.Add(new IfxParameter("lastname", sqlRes.personPar.lastname));
            ifxCommand.Parameters.Add(new IfxParameter("birthday", sqlRes.personPar.birthday));
        }

        void DeleteColumnCreateParams()
        {
            ifxCommand.Parameters.Add(new IfxParameter("id", sqlRes.personPar.id_person));
        }
    }
}
using IBM.Data.Informix;
using PersonControll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonControll.Connection.IBMConnect.Interface
{
    public interface IIfxCommandPar
    {
        void CreateParams(IfxCommand ifxCommand, SqlRes sqlRes);
    }
}

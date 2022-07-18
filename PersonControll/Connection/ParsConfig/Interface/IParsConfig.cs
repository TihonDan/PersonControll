using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonControll.Connection.ParsConfig.Interface
{
    public interface IParsConfig
    {
        string configurationConnect { get; }
        void ParseConfiguration();
    }
}

using PersonControll.Connection.ParsConfig.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonControll.Connection.ParsConfig
{
    public class ParsConfig : IParsConfig
    {
        private string ConfigurationConnect = null;
        /// <summary>
        /// Получение и возврат строки подключени
        /// </summary>
        public string configurationConnect
        {
            get
            {
                return ConfigurationConnect;
            }
        }
        /// <summary>
        /// Строка подключения
        /// </summary>
        public void ParseConfiguration()
        {
            ConfigurationConnect = "Database=barstest; Host=192.168.224.27; Server=ol_test; Service=1527;CLIENT_LOCALE=ru_RU.CP1251; DB_LOCALE=ru_RU.915; Protocol=olsoctcp; UID=informix;Password=info;";
        }
    }
}
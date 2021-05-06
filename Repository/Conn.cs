using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapi.util;

namespace Repository
{
    public abstract class Conn
    {
        public static string ConnString { get; private set; }

        public Conn()
        {
            var config = new JsonUtil().ReadTokensAppsettings();
            ConnString = config.GetSection("Conn:DB").Value;
        }
    }
}

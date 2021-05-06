using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Webapi.util
{
    public class JsonUtil
    {
        public IConfigurationRoot ReadTokensAppsettings()
        {
            var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"appsettings.json");

            var config = builder.Build();

            return config;
        }
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.AspNetCore
{
    public class ConfigManager
    {
        public static IConfigurationRoot GetConfig()
        {
            return new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();
        }
    }
}

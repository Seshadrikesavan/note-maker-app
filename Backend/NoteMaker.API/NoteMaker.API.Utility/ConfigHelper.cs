using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace NoteMaker.API.Utility
{
    public static class ConfigHelper
    {
        public static string GetConnectionString(string key)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
            return configuration.GetConnectionString(key);
        }
    }
}

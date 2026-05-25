using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterTestProject.BDD.TestAutomation.Features.Utils
{
    public static class Helpers
    {
        public static string Get(string key)
        {
            var value = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("appsettings")[key];
            return value;
        }
    }
}

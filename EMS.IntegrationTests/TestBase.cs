using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.IntegrationTests
{
    public abstract class TestBase
    {
        protected IConfiguration Configuration { get; set; }

        protected TestBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            Configuration = builder;
        }
    }
}

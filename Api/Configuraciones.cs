using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class Configuraciones : IConfiguraciones
    {
        public string ConnectionString_chapi { get; set; }
        public string Error_log_file { get; set; }
        public string WebBuilder_URL { get; set; }

        public Configuraciones()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json"), optional: false)
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), optional: false)
                .Build();

            ConnectionString_chapi = configuration.GetConnectionString("ConnectionString_chapi");
            Error_log_file = configuration.GetConnectionString("Error_log_file");
            WebBuilder_URL = configuration.GetSection("WebBuilder_URL").Value;
        }
    }
}
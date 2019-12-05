using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CityInfo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ////the below code is almost equivalent to this
            //var host = new WebHostBuilder()
            //    .UseKestrel() //type of server
            //    .UseContentRoot(Directory.GetCurrentDirectory()) //content directory
            //    .UseIISIntegration() //iis integration/ reverse proxy
            //    .UseStartup<Startup>() //startup class
            //    .Build(); //build with basics
            //host.Run(); //finally run

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

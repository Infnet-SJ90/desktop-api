using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SJ90.DesktopAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(config)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls("http://0.0.0.0:1997/")
                .Build();

            host.Run();

            //if (Debugger.IsAttached || args.Contains("--debug"))
            //{
            //    host.Run();
            //}
            //else
            //{
            //    host.RunAsService();
            //}
        }
    }
}

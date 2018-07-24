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
            var exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            var directoryPath = Path.GetDirectoryName(exePath);
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseIISIntegration()
                .UseContentRoot(directoryPath)
                .UseStartup<Startup>()
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

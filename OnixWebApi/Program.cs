using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Its.Onix.WebApi
{
    public static class Program
    {
        private static Type startUpClass = typeof(Startup);

        private static int portNum = 5001;
        private static string listenUrl = "http://{0}:{1}";

        public static void Main(string[] args)
        {
            string port = Environment.GetEnvironmentVariable("PORT");
            if (port != null)
            {
                portNum = Int32.Parse(port);
            }

            CreateHostBuilder(args, startUpClass).Build().Run();
        }

        public static Type StartupClass
        {
            set 
            {
                startUpClass = value;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args, Type startUpClass)
        {
            IHostBuilder host = Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup(startUpClass);
                    webBuilder.UseUrls(String.Format(listenUrl, "0.0.0.0", portNum));
                });

            return host;                
        }
    }
}

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using NLog.Web;

using Sharpdev.SDK.API;

namespace Prosolve.MicroService.Identification.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                          .ConfigureLogging(Configuration.ConfigurationLogging)
                          .UseNLog()
                          .UseStartup<Startup>();
        }
    }
}

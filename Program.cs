using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    class Program
    {
        //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration?tabs=basicconfiguration

        //https://joonasw.net/view/aspnet-core-2-configuration-changes

        static void Main(string[] args)
        {
            
                
            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    IHostingEnvironment env = builderContext.HostingEnvironment;

                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    
                })
                .Build();
 
            host.Run();
        }

    }
}

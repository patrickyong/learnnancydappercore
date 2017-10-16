
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.TinyIoc;
using HelloWorld.Repository;
using Nancy.Configuration;

namespace HelloWorld
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        public IConfiguration Configuration;
        public CustomBootstrapper()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(RootPathProvider.GetRootPath())
                            .AddJsonFile("appsettings.json")
                            .AddEnvironmentVariables();

            
            Configuration = builder.Build();

        }
        public override void Configure(INancyEnvironment environment)
        {
            var config = new Nancy.TraceConfiguration(enabled: true, displayErrorTraces: true);
            environment.AddValue(config);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            container.Register<IGreeterService, GreeterService>();
            container.Register<IRepository<Models.System>, SystemRepository>();
            container.Register(Configuration);
        }

        
    }
}
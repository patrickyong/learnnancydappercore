using Nancy;
namespace HelloWorld
{
        public class HomeModule : NancyModule
    {
        public HomeModule(IGreeterService greeter)
        {
            //https://blog.nandotech.com/post/2016-10-25-nancyfx-webapi-dapper/


            Get("/", args =>
            {
                
                return greeter.GetGreeting();
            });
            
            Get("/test", args => greeter.GetGreeting());

            Get("/os", x =>
            {
                return System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            });
        }
    }
}
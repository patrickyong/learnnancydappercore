using Microsoft.Extensions.Configuration;
namespace HelloWorld
{
public class GreeterService : IGreeterService
    {
        private string _greeting;

        public GreeterService(IConfiguration config)
        {
            _greeting = config["Greeting"];
        }

        public string GetGreeting()
        {
            return _greeting;
        }
    }
}
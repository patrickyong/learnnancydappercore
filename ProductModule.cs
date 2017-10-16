using Nancy;
namespace HelloWorld
{
    public class ProductModule : NancyModule
    {
        public ProductModule() : base("/products")
        {
            // would capture routes to /products/list sent as a synchronous GET request
            Get(path: "/list", action: args => "Hello World, it's Nancy on .NET Core");

        }
    }

}
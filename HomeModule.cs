using Nancy;
namespace NancyApplication
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Hello World. This is pretty cool!");
        }
    }
}

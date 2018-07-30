using System;
using Nancy;

namespace NancyApplication
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            var r = new Random();
            Get("/", args => "Hello World. This is pretty cool!");

            Get("/test",  args => {

                // incur a random delay
                var sleep_ms = r.Next(2500);
                System.Threading.Thread.Sleep(sleep_ms);

                // Choose a random return status code
                var statuses = new int[] {200,200,200,200,200,200,400,400,500};
                var status = statuses[r.Next(statuses.Length)];

                return Negotiate
                    .WithStatusCode(status)
                    .WithModel(new {
                        message = "Test action",
                        status = status,
                        sleep_time_ms = sleep_ms
                    });
            });
        }
    }
}

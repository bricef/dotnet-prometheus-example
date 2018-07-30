using Microsoft.AspNetCore.Builder;
using Nancy.Owin;
using Prometheus;

namespace NancyApplication
{
   public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseOwin(x => x.UseNancy());
            // app.UseMetricServer();
        }
   }
}

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
            app.UseMetricServer(); // make sure this middleware comes before Nancy to intercept /metrics requests.
            app.UseOwin(x => x.UseNancy());
        }
   }
}

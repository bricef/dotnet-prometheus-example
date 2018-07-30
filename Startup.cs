using System;
using Microsoft.AspNetCore.Builder;
using Nancy.Owin;
using Prometheus;

namespace NancyApplication
{
   public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {

            var http_request_histogram = Metrics.CreateHistogram("http_request_duration_seconds", "HTTP Request latency", new HistogramConfiguration{
                LabelNames = new[] {"method", "status"},
            });



            app.UseDeveloperExceptionPage();
            app.UseMetricServer(); // make sure this middleware comes before Nancy to intercept /metrics requests.
            app.Use(async (context, next) => {
                // start timer
                var start = DateTime.Now;

                await  next.Invoke();
                
                // work out duration
                var duration_s = (DateTime.Now - start).TotalMilliseconds / 1000.0;
                
                // Add to histogram
                http_request_histogram
                    .WithLabels(context.Request.Method, context.Response.StatusCode.ToString())
                    .Observe(duration_s);
            });
            app.UseOwin(x => x.UseNancy());
        }
   }
}

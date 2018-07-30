using System;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.Diagnostics;
using Nancy.Configuration;

public class CustomBootstrapper : DefaultNancyBootstrapper
{
    public override void Configure(INancyEnvironment environment)
    {
        environment.Diagnostics(true, "password");
        base.Configure(environment);
    }

    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    {

        pipelines.OnError.AddItemToEndOfPipeline((ctx, ex) => {
            Console.WriteLine(ex);
            return null;
        });
    }
}
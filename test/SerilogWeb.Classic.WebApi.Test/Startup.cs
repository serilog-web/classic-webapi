using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;
using SerilogWeb.Classic.WebApi.Enrichers;

[assembly: OwinStartup(typeof(SerilogWeb.Classic.WebApi.Test.Startup))]

namespace SerilogWeb.Classic.WebApi.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SelfLog.Out = Console.Out;
            Serilog.Log.Logger = new LoggerConfiguration()
                .Enrich.With<WebApiRouteTemplateEnricher>()
                .Enrich.With<WebApiControllerNameEnricher>()
                .Enrich.With<WebApiRouteDataEnricher>()
                .Enrich.With<WebApiActionNameEnricher>()
                .WriteTo.Observers(
                    observable => { observable.Subscribe(new DummyLogger()); }
                    , LogEventLevel.Error)
                .WriteTo.Logger(l=> l
                    .Filter.ByIncludingOnly(e=> e.Properties.ContainsKey("WebApiUrlTemplate"))
                    .WriteTo.Trace(outputTemplate: "Has WebApiUrlTemplate ! {Message}{NewLine}WebApiUrlTemplate = {WebApiUrlTemplate}")
                   )
                .WriteTo.Trace()
                .CreateLogger();
        }
    }
}

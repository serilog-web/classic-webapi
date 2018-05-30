using Microsoft.Owin;
using Owin;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using SerilogWeb.Classic.WebApi.Enrichers;

[assembly: OwinStartup(typeof(SerilogWeb.Classic.WebApi.Test.Startup))]

namespace SerilogWeb.Classic.WebApi.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .WriteTo.Observers(
                    observable => { observable.Subscribe(new DummyLogger()); }
                    , LogEventLevel.Error)
                .WriteTo.Trace(new JsonFormatter())
                .CreateLogger();
        }
    }
}

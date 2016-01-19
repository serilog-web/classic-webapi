using System;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Serilog;
using Serilog.Events;

[assembly: OwinStartup(typeof(SerilogWeb.Classic.WebApi.Test.Startup))]

namespace SerilogWeb.Classic.WebApi.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.Observers(
                    observable => { observable.Subscribe(new DummyLogger()); }
                    , LogEventLevel.Error)
                .CreateLogger();
        }
    }
}

using Microsoft.Owin;
using Owin;
using Serilog;

[assembly: OwinStartup(typeof(SerilogWeb.Classic.WebApi.Test.Startup))]

namespace SerilogWeb.Classic.WebApi.Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .WriteTo.Trace()
                .CreateLogger();
        }
    }
}

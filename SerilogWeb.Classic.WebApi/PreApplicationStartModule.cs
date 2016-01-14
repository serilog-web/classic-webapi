using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace SerilogWeb.Classic.WebApi
{
    class PreApplicationStartModule
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger),
                new WebApiExceptionLogger());
        }
    }
}

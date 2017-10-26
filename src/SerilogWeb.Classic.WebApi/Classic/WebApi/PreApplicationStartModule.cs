using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace SerilogWeb.Classic.WebApi
{
    public class PreApplicationStartModule
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration.Services.Add(typeof(IExceptionLogger),
                new WebApiExceptionLogger());
            GlobalConfiguration.Configuration.Filters.Add(new StoreWebApInfoInHttpContextActionFilter());
        }
    }
}

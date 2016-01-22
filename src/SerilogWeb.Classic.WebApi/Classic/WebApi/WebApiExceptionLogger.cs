using System.Web;
using System.Web.Http.ExceptionHandling;

namespace SerilogWeb.Classic.WebApi
{
    public class WebApiExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            HttpContext.Current.AddError(context.Exception);
        }
    }
}
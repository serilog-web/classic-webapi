using System.Web;
using System.Web.Http.ExceptionHandling;
using SerilogWeb.Classic.Extensions;

namespace SerilogWeb.Classic.WebApi
{
    public class WebApiExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            if (context.Exception != null)
            {
                HttpContext.Current.AddSerilogWebError(context.Exception);
            }
        }
    }
}
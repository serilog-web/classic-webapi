using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using SerilogWeb.Classic.WebApi.Enrichers;

namespace SerilogWeb.Classic.WebApi
{
    public class StoreWebApInfoInHttpContext : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var urlTemplate = actionContext.RequestContext.RouteData.Route.RouteTemplate;
            //HttpContextCurrent.Request[]

            var contextualInfo = new Dictionary<WebApiRequestInfoKey, object>();
            contextualInfo[WebApiRequestInfoKey.UrlTemplate] = urlTemplate;

            var currentHttpContext = HttpContext.Current;
            currentHttpContext.Items[Constants.WebApiContextInfoKey] = contextualInfo;


            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }
}
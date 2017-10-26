using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SerilogWeb.Classic.WebApi
{
    public class StoreWebApInfoInHttpContextActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            StoreWebApInfoInHttpContext(actionContext);
            base.OnActionExecuting(actionContext);
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            StoreWebApInfoInHttpContext(actionContext);
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }

        private static void StoreWebApInfoInHttpContext(HttpActionContext actionContext)
        {
            var actionName = actionContext.ActionDescriptor.ActionName;
            var controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var urlTemplate = actionContext.RequestContext.RouteData.Route.RouteTemplate;

            var contextualInfo =
                new Dictionary<WebApiRequestInfoKey, object>
                {
                    [WebApiRequestInfoKey.UrlTemplate] = urlTemplate,
                    [WebApiRequestInfoKey.ActionName] = actionName,
                    [WebApiRequestInfoKey.ControllerName] = controllerName
                };

            var currentHttpContext = HttpContext.Current;
            currentHttpContext.Items[Constants.WebApiContextInfoKey] = contextualInfo;

        }
    }
}
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


        private static void StoreWebApInfoInHttpContext(HttpActionContext actionContext)
        {
            var actionDescriptor = actionContext.ActionDescriptor;
            var routeData = actionContext.RequestContext.RouteData;

            var actionName = actionDescriptor.ActionName;
            var controllerName = actionDescriptor.ControllerDescriptor.ControllerName;

            var routeTemplate = routeData.Route.RouteTemplate;
            var routeDataDictionary = new Dictionary<string, object>( routeData.Values);

            var contextualInfo =
                new Dictionary<WebApiRequestInfoKey, object>
                {
                    [WebApiRequestInfoKey.RouteUrlTemplate] = routeTemplate,
                    [WebApiRequestInfoKey.RouteData] = routeDataDictionary,
                    [WebApiRequestInfoKey.ActionName] = actionName,
                    [WebApiRequestInfoKey.ControllerName] = controllerName
                };

            var currentHttpContext = HttpContext.Current;
            if (currentHttpContext != null)
            {
                currentHttpContext.Items[Constants.WebApiContextInfoKey] = contextualInfo;
            }
            
        }
    }
}
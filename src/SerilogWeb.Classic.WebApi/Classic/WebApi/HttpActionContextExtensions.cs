using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace SerilogWeb.Classic.WebApi
{
    internal static class HttpActionContextExtensions
    {
        public static void StoreWebApInfoInHttpContext(this HttpActionContext actionContext)
        {
            var currentHttpContext = HttpContext.Current;
            if (currentHttpContext == null)
                return;

            var actionDescriptor = actionContext.ActionDescriptor;
            var routeData = actionContext.RequestContext.RouteData;

            var actionName = actionDescriptor.ActionName;
            var controllerName = actionDescriptor.ControllerDescriptor.ControllerName;

            var routeTemplate = routeData.Route.RouteTemplate;
            var routeDataDictionary = new Dictionary<string, object>(routeData.Values);

            var contextualInfo =
                new Dictionary<WebApiRequestInfoKey, object>
                {
                    [WebApiRequestInfoKey.RouteUrlTemplate] = routeTemplate,
                    [WebApiRequestInfoKey.RouteData] = routeDataDictionary,
                    [WebApiRequestInfoKey.ActionName] = actionName,
                    [WebApiRequestInfoKey.ControllerName] = controllerName
                };

            currentHttpContext.Items[Constants.WebApiContextInfoKey] = contextualInfo;
        }
    }
}

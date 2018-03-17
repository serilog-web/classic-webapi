using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SerilogWeb.Classic.WebApi
{
    internal class StoreWebApInfoInHttpContextActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            actionContext.StoreWebApInfoInHttpContext();
            base.OnActionExecuting(actionContext);
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            actionContext.StoreWebApInfoInHttpContext();
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}
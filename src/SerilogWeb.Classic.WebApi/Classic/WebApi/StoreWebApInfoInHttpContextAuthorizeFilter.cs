using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SerilogWeb.Classic.WebApi
{
    public class StoreWebApInfoInHttpContextAuthorizeFilter : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.StoreWebApInfoInHttpContext();
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
}
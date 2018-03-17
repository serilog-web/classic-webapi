using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SerilogWeb.Classic.WebApi
{
    public class StoreWebApInfoInHttpContextAuthenticationFilter : IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            context.ActionContext.StoreWebApInfoInHttpContext();
            await Task.FromResult(0);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            await Task.FromResult(0);
        }
    }
}
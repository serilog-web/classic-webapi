using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace SerilogWeb.Classic.WebApi.Test.Controllers
{
    [RoutePrefix("widgetapi/v1")]
    public class WidgetsController : ApiController
    {
        // GET: widgetapi/widgets[?name=xx]
        [HttpGet]
        [Route("widgets")]
        public async Task<string[]> ListAsync(string name="")
        {
            return new[] { "value1", "value2" };
        }

        // GET: widgetapi/widgets/5
        [Route("widgets/{id}")]
        [ActionName("OverridenActionName")]
        public async Task<string> GetAsync(int id)
        {
            return "value";
        }

        // GET: widgetapi/widgets/5/foos[?active=true]
        [Route("widgets/{id}/foos")]
        public async Task<string[]> GetFoosByWidgetAsync(int id, bool? active = null)
        {
            return new [] {$"foo1 of {id}", $"foo2 of {id}"};
        }

        // GET: widgetapi/widgets/5/foos/6
        [Route("widgets/{id}/foos/{fooId}")]
        public async Task<string> GetFooByWidgetAsync(int id, int fooId)
        {
            return $"foo {fooId} of widget {id}";
        }
    }
}

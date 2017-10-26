namespace SerilogWeb.Classic.WebApi.Enrichers
{
    /// <summary>
    /// An enricher that adds the route template for the current Web API action to the log event properties
    /// </summary>
    public class WebApiRouteTemplateEnricher : BaseWebApiContextInfoEnricher
    {
        public WebApiRouteTemplateEnricher()
            : this("WebApiRouteTemplate")
        {
        }

        public WebApiRouteTemplateEnricher(string propertyName, bool destructureObjects = false)
            :base(WebApiRequestInfoKey.RouteUrlTemplate, propertyName, destructureObjects)
        {
        }
    }
}

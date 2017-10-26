namespace SerilogWeb.Classic.WebApi.Enrichers
{
    /// <summary>
    /// An enricher that adds the route data for the current Web API action to the log event properties
    /// </summary>
    public class WebApiRouteDataEnricher : BaseWebApiContextInfoEnricher
    {
        public WebApiRouteDataEnricher()
            : this("WebApiRouteData")
        {
        }

        public WebApiRouteDataEnricher(string propertyName, bool destructureObjects = false)
            : base(WebApiRequestInfoKey.RouteUrlTemplate, propertyName, destructureObjects)
        {
        }
    }
}
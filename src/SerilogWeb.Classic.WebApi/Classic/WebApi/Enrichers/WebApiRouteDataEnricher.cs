namespace SerilogWeb.Classic.WebApi.Enrichers
{
    /// <summary>
    /// An enricher that adds the route data for the current Web API action to the log event properties
    /// </summary>
    public class WebApiRouteDataEnricher : BaseWebApiContextInfoEnricher
    {
        public const string WebApiRouteDataPropertyName = "WebApiRouteData";

        public WebApiRouteDataEnricher()
            : this(WebApiRouteDataPropertyName)
        {
        }

        public WebApiRouteDataEnricher(string propertyName, bool destructureObjects = false)
            : base(WebApiRequestInfoKey.RouteData, propertyName, destructureObjects)
        {
        }
    }
}
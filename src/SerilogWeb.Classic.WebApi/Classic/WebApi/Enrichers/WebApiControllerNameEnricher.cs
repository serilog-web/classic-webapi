namespace SerilogWeb.Classic.WebApi.Enrichers
{
    /// <summary>
    /// An enricher that adds the name of the controller for the current Web API action to the log event properties
    /// </summary>
    public class WebApiControllerNameEnricher : BaseWebApiContextInfoEnricher
    {
        public WebApiControllerNameEnricher()
            : this("WebApiController")
        {
        }

        public WebApiControllerNameEnricher(string propertyName, bool destructureObjects = false)
            : base(WebApiRequestInfoKey.ControllerName, propertyName, destructureObjects)
        {
        }
    }
}
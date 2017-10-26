namespace SerilogWeb.Classic.WebApi.Enrichers
{
    /// <summary>
    /// An enricher that adds the name of the current Web API action to the log event properties
    /// </summary>
    public class WebApiActionNameEnricher : BaseWebApiContextInfoEnricher
    {
        public WebApiActionNameEnricher()
            : this("WebApiAction")
        {
        }

        public WebApiActionNameEnricher(string propertyName, bool destructureObjects = false)
            :base(WebApiRequestInfoKey.ActionName, propertyName, destructureObjects)
        {
        }
    }
}
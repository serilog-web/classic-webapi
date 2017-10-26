using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace SerilogWeb.Classic.WebApi.Enrichers
{
    public class WebApiUrlTemplateEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

            if (HttpContext.Current == null)
                return;

            if (HttpContext.Current.Items.Contains(Constants.WebApiContextInfoKey))
            {
                var enrichmentItems = (Dictionary<WebApiRequestInfoKey, object>) HttpContext.Current.Items[Constants.WebApiContextInfoKey];
                var urlTemplate = enrichmentItems[WebApiRequestInfoKey.UrlTemplate];
                var urlTemplateProperty = new LogEventProperty("WebApiUrlTemplate", new ScalarValue(urlTemplate));
                logEvent.AddOrUpdateProperty(urlTemplateProperty);
            }


            //var requestUrl = HttpContextCurrent.Request..Url.ToString();
            //var httpRequestUrlProperty = new LogEventProperty(HttpRequestUrlPropertyName, new ScalarValue(requestUrl));
            //logEvent.AddPropertyIfAbsent(httpRequestUrlProperty);

        }
    }
}

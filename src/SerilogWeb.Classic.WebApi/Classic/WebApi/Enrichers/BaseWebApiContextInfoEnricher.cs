using System;
using System.Collections.Generic;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace SerilogWeb.Classic.WebApi.Enrichers
{
    /// <summary>
    /// Base class for WebAPI enrichers that access Web API specific contextual information stored temporarily in HttpContext
    /// </summary>
    public abstract class BaseWebApiContextInfoEnricher : ILogEventEnricher
    {
        private readonly WebApiRequestInfoKey _infoItemKey;
        private readonly bool _destructureObjects;
        private readonly string _logPropertyName;

        internal BaseWebApiContextInfoEnricher(WebApiRequestInfoKey infoItemKey, string logPropertyName, bool destructureObjects = false)
        {
            _infoItemKey = infoItemKey;
            _destructureObjects = destructureObjects;
            _logPropertyName = logPropertyName ?? throw new ArgumentNullException(nameof(logPropertyName));
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

            var httpContext = HttpContext.Current;
            if (httpContext == null)
                return;

            var webApiInfo = httpContext.Items[Constants.WebApiContextInfoKey] as IReadOnlyDictionary<WebApiRequestInfoKey, object>;

            if (webApiInfo != null)
            {
                var propertyValue = webApiInfo[_infoItemKey];

                var logEventProperty = propertyFactory.CreateProperty(_logPropertyName, propertyValue, _destructureObjects);

                logEvent.AddOrUpdateProperty(logEventProperty);
            }
        }
    }
}
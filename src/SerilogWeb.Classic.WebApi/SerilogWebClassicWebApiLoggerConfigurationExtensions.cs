using Serilog.Configuration;
using SerilogWeb.Classic.WebApi.Enrichers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serilog
{
    /// <summary>
    /// Extends <see cref="LoggerConfiguration"/> to add enrichers for SerilogWeb.Classic.WebApi logging module 
    /// </summary>
    public static class SerilogWebClassicWebApiLoggerConfigurationExtensions
    {
        /// <summary>
        /// Enrich log events with the name of the current Web API action.
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="propertyName">Name of the property to log.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithWebApiActionName(
            this LoggerEnrichmentConfiguration enrichmentConfiguration,
            string propertyName = WebApiActionNameEnricher.WebApiActionPropertyName)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new WebApiActionNameEnricher(propertyName));
        }

        /// <summary>
        /// Enrich log events with the controller name for the current Web API action.
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="propertyName">Name of the property to log.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithWebApiControllerName(
            this LoggerEnrichmentConfiguration enrichmentConfiguration,
            string propertyName = WebApiControllerNameEnricher.WebApiControllerPropertyName)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new WebApiControllerNameEnricher(propertyName));
        }

        /// <summary>
        /// Enrich log events with the route data for the current Web API action.
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="propertyName">Name of the property to log.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithWebApiRouteData(
            this LoggerEnrichmentConfiguration enrichmentConfiguration,
            string propertyName = WebApiRouteDataEnricher.WebApiRouteDataPropertyName)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new WebApiRouteDataEnricher(propertyName));
        }

        /// <summary>
        /// Enrich log events with the template for the current Web API action.
        /// </summary>
        /// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
        /// <param name="propertyName">Name of the property to log.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration WithWebApiRouteTemplate(
            this LoggerEnrichmentConfiguration enrichmentConfiguration,
            string propertyName = WebApiRouteTemplateEnricher.WebApiRouteTemplatePropertyName)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With(new WebApiRouteTemplateEnricher(propertyName));
        }
    }
}
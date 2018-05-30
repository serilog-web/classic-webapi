# SerilogWeb.Classic.WebApi [![Build status](https://ci.appveyor.com/api/projects/status/np8pc8rde1kvj0h2/branch/master?svg=true)](https://ci.appveyor.com/project/serilog-web/classic-webapi/branch/master)


ASP.NET WebAPI support for [SerilogWeb.Classic](https://github.com/serilog-web/classic).

*Package* - <a href="https://www.nuget.org/packages/serilogweb.classic.webapi">SerilogWeb.Classic.WebApi</a> | Platforms - .NET 4.5

_This package is designed for full framework ASP.NET applications. For ASP.NET Core, have a look at [Serilog.AspNetCore](https://github.com/serilog/serilog-aspnetcore)_

This package is used in conjunction with _SerilogWeb.Classic_ and adds : 
- support for logging WebAPI exceptions with [Serilog](http://serilog.net)
- Web API specific enrichers

## Enrichers
The following enrichers are available as extension methods from the `LoggerConfiguration.Enrich` API:
- **WithWebApiActionName** : adds a property `WebApiAction` containing the name of the *Action* being executed in the *Web API Controller*
- **WithWebApiControllerName** : adds a property `WebApiController` containing the name of the *Controller* in which a *Web API Action* has executed
- **WithWebApiRouteData** : adds a property `WebApiRouteData` containing the dictionary of the *RouteData*
- **WithWebApiRouteTemplate** : adds a property `WebApiRouteTemplate` containing the *route template* selected by Web API routing


Usage : 

```csharp
var log = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.WithWebApiRouteTemplate()
    .Enrich.WithWebApiActionName()
    .CreateLogger();
```

To override the property name of the added property:

```csharp
var log = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.WithWebApiRouteTemplate("RouteTemplate")
    .CreateLogger();
```

Enrichers can also be defined in a configuration file by using Serilog.Settings.AppSettings as follows:

```xml
<appSettings>
    <add key="serilog:using:SerilogWeb.Classic.WebApi" value="SerilogWeb.Classic.WebApi"/>
    <add key="serilog:enrich:WithWebApiActionName" />
    <add key="serilog:enrich:WithWebApiControllerName" />
    <add key="serilog:enrich:WithWebApiRouteData" />
    <add key="serilog:enrich:WithWebApiRouteTemplate" />
</appSettings>
```

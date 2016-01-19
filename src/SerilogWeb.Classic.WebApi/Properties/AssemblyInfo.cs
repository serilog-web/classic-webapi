using System.Reflection;
using System.Web;
using SerilogWeb.Classic.WebApi;

[assembly: AssemblyTitle("SerilogWeb.Classic.WebApi")]
[assembly: PreApplicationStartMethod(typeof(PreApplicationStartModule), "Register")]

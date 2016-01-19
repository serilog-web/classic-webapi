using System;
using System.Diagnostics;
using Serilog.Events;

namespace SerilogWeb.Classic.WebApi.Test
{
    public class DummyLogger : IObserver<LogEvent>
    {
        public void OnNext(LogEvent value)
        {
            // error was logged. Hurray.
            Debug.Print(value.Exception.StackTrace);
            Debugger.Break();
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnCompleted()
        {
            
        }
    }
}
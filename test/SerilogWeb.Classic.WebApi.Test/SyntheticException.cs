using System;

namespace SerilogWeb.Classic.WebApi.Test
{
    public class SyntheticException : Exception
    {
        public SyntheticException(string message) : base(message)
        {
            
        }
    }
}
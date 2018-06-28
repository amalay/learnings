using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Amalay.WebApp
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
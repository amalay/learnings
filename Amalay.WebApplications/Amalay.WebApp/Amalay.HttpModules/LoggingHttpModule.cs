using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Amalay.HttpModules
{
    public class LoggingHttpModule : IHttpModule
    {
        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.LogRequest += Application_LogRequest;
        }

        private void Application_LogRequest(object sender, EventArgs e)
        {
            HttpApplication httpApp = sender as HttpApplication;
            HttpContext httpContext = httpApp.Context;

            string requestPath = httpContext.Request.Path;

            Trace.WriteLine(string.Format("Request Path: {0}", requestPath));
        }
    }
}

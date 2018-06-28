using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Amalay.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected DateTime requestStartTime;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new AmalayControllerFactory());

            DependencyResolver.SetResolver(new AmalayDependencyResolver());

            Application["ApplicationStartDateTime"] = DateTime.Now;
        }

        protected void Application_End()
        {
            Application.Clear();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            requestStartTime = DateTime.Now;

            Trace.WriteLine(string.Format("Request start time: {0}", requestStartTime));
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            TimeSpan totalRequestTime = DateTime.Now - requestStartTime;

            Trace.WriteLine(string.Format("Total request time: {0} ms", totalRequestTime.Milliseconds));
        }
    }
}

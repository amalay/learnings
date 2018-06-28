using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Amalay.WebApp
{
    public class AmalayControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type controllerType = null;
            ILogger logger = new Logger();

            if(controllerName == "Home")
            {
                controllerType = typeof(Controllers.HomeController);
            }

            IController controller = Activator.CreateInstance(controllerType, logger) as IController;

            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            
        }
    }
}
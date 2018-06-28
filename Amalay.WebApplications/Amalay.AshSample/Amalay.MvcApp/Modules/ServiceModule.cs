using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Amalay.MvcApp
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Amalay.Business")).Where(t => t.Name.EndsWith("Manager")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
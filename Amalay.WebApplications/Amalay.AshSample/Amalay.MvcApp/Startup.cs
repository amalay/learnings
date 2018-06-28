using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Amalay.MvcApp.Startup))]
namespace Amalay.MvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

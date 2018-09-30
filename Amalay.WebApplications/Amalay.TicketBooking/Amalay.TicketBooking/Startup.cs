using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Amalay.TicketBooking.Startup))]
namespace Amalay.TicketBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

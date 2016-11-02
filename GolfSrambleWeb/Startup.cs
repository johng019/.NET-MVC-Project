using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GolfSrambleWeb.Startup))]
namespace GolfSrambleWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

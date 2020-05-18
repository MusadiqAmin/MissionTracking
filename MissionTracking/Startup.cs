using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MissionTracking.Startup))]
namespace MissionTracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

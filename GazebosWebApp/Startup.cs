using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GazebosWebApp.Startup))]
namespace GazebosWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

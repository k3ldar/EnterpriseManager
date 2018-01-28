using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shifoo.Systems.Web.Startup))]
namespace Shifoo.Systems.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

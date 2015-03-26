using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sibelius.Web.Startup))]
namespace Sibelius.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

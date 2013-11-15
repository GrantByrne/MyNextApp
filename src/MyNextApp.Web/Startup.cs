using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyNextApp.Web.Startup))]
namespace MyNextApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppsCore.Ancestry.Web.Startup))]
namespace AppsCore.Ancestry.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

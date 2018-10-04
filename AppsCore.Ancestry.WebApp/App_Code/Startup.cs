using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppsCore.Ancestry.WebApp.Startup))]
namespace AppsCore.Ancestry.WebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

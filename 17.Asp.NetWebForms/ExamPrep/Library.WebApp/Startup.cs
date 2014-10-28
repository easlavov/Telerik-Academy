using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Library.WebApp.Startup))]
namespace Library.WebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

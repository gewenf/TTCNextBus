using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalGroupProject.Startup))]
namespace FinalGroupProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

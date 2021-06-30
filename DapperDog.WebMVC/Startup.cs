using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DapperDog.WebMVC.Startup))]
namespace DapperDog.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

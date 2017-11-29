using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCodefirst.Startup))]
namespace MVCCodefirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

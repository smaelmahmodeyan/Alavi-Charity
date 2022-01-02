using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(alavi.Startup))]
namespace alavi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

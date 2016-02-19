using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wclc.Startup))]
namespace wclc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Which.Startup))]
namespace Which
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

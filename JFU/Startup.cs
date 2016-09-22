using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JFU.Startup))]
namespace JFU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArchitectureFrame.Web.Startup))]
namespace ArchitectureFrame.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DelfinASP.NET.Startup))]
namespace DelfinASP.NET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

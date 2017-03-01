using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Leaf.Web.Startup))]
namespace Leaf.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MunkeyIssues.Web.Startup))]
namespace MunkeyIssues.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

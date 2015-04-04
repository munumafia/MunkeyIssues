using Microsoft.Owin;
using Owin;
using StructureMap;

[assembly: OwinStartupAttribute(typeof(MunkeyIssues.Web.Startup))]
namespace MunkeyIssues.Web
{
    public partial class Startup
    {
        protected IContainer Container { get; set; }

        public void Configuration(IAppBuilder app)
        {
            ConfigureContainer();
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using MunkeyIssues.Api;
using Owin;
using StructureMap;

[assembly: OwinStartup(typeof(Startup))]
namespace MunkeyIssues.Api
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

using System.Web.Http;
using System.Web.Http.Dispatcher;
using MunkeyIssues.Web.StructureMap;

namespace MunkeyIssues.Web
{
    public partial class Startup
    {
        public void ConfigureContainer()
        {
            Container = ContainerBuilder.Build();
            GlobalConfiguration.Configuration.Services.Replace(
                typeof (IHttpControllerActivator),
                new StructureMapHttpControllerActivator(Container));

            MvcApplication.Container = Container;
        }
    }
}
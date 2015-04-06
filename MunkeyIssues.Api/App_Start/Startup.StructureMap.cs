using System.Web.Http;
using System.Web.Http.Dispatcher;
using MunkeyIssues.Api.StructureMap;

namespace MunkeyIssues.Api
{
    public partial class Startup
    {
        public void ConfigureContainer()
        {
            Container = ContainerBuilder.Build();
            //GlobalConfiguration.Configuration.Services.Replace(
            //    typeof (IHttpControllerActivator),
            //    new StructureMapHttpControllerActivator(Container));

            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(Container);
            MvcApplication.Container = Container;
        }
    }
}
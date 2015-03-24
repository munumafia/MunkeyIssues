using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MassTransit;
using MunkeyIssues.Web.AutoMapper;
using MunkeyIssues.Web.StructureMap;
using StructureMap;

namespace MunkeyIssues.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IContainer _Container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfiguration.Configure();
            SetupContainer();
        }

        protected void Application_End()
        {
            var serviceBus = _Container.GetInstance<IServiceBus>();
            serviceBus.Dispose();
        }

        private void SetupContainer()
        {
            _Container = ContainerBuilder.Build();
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator), 
                new StructureMapHttpControllerActivator(_Container));
        }
    }
}
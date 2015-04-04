using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MassTransit;
using MunkeyIssues.Api.AutoMapper;
using StructureMap;

namespace MunkeyIssues.Api
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IContainer Container { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfiguration.Configure();
        }

        protected void Application_End()
        {
            var serviceBus = Container.GetInstance<IServiceBus>();
            serviceBus.Dispose();
        }
    }
}
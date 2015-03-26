using System;
using System.Web.Configuration;
using Magnum.Extensions;
using MunkeyIssues.Web.ResponseMappers;
using MunkeyIssues.Web.Services;
using MunkeyIssues.Web.Services.Categories;
using MunkeyIssues.Web.Services.Statuses;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.Web.StructureMap.Registries
{
    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            var serviceTimeout = GetServiceRequestTimeout();

            For<IServiceBusService>().Use<ServiceBusService>().Ctor<TimeSpan>().Is(serviceTimeout);
            For<ICategoryService>().Use<CategoryService>();
            For<IStatusService>().Use<StatusService>();
            
            For<IResponseMapper>().Use<ResponseMapper>();
        }

        private static TimeSpan GetServiceRequestTimeout()
        {
            var timeout = WebConfigurationManager.AppSettings["ServiceRequestTimeoutInSeconds"];
            return timeout != null
                ? Convert.ToInt32(timeout).Seconds()
                : 10.Seconds();
        }
    }
}

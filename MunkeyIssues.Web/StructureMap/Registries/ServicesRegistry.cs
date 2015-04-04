using System;
using System.Web.Configuration;
using Magnum.Extensions;
using MunkeyIssues.Api.ResponseMappers;
using MunkeyIssues.Api.Services;
using MunkeyIssues.Api.Services.Categories;
using MunkeyIssues.Api.Services.Statuses;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.Api.StructureMap.Registries
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

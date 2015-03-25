using System;
using System.Web.Configuration;
using Magnum.Extensions;
using MunkeyIssues.Web.Services.Categories;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.Web.StructureMap.Registries
{
    public class ServicesRegistry : Registry
    {
        public ServicesRegistry()
        {
            var serviceTimeout = GetServiceRequestTimeout();

            For<ICategoryService>().Use<CategoryService>().Ctor<TimeSpan>().Is(serviceTimeout);
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

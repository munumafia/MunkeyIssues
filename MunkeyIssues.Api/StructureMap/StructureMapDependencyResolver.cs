using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using StructureMap;


namespace MunkeyIssues.Api.StructureMap
{
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _Container;

        public StructureMapDependencyResolver(IContainer container)
        {
            _Container = container;
        }

        public void Dispose()
        {
            _Container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return _Container.TryGetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var services = _Container.GetAllInstances(serviceType);
            return services.Cast<object>();
        }

        public IDependencyScope BeginScope()
        {
            var container = _Container.GetNestedContainer();
            return new StructureMapDependencyResolver(container);
        }
    }
}
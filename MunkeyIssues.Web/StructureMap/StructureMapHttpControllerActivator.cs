using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace MunkeyIssues.Api.StructureMap
{
    public class StructureMapHttpControllerActivator : IHttpControllerActivator
    {
        private readonly IContainer _Container;

        public StructureMapHttpControllerActivator(IContainer container)
        {
            _Container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return _Container.GetInstance(controllerType) as IHttpController;
        }
    }
}

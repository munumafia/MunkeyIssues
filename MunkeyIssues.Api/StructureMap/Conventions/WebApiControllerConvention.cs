using System;
using System.Web.Http.Controllers;
using Magnum.Extensions;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using StructureMap.TypeRules;

namespace MunkeyIssues.Api.StructureMap.Conventions
{
    public class WebApiControllerConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (!type.IsConcrete() || type.IsGenericType) return;

            if (type.Implements<IHttpController>())
            {
                registry.For(type);
            }
        }
    }
}

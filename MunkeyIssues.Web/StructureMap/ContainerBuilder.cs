using MunkeyIssues.Web.StructureMap.Registries;
using StructureMap;

namespace MunkeyIssues.Web.StructureMap
{
    public class ContainerBuilder
    {
        public static IContainer Build()
        {
            return new Container(x =>
            {
                x.AddRegistry(new AutoMapperRegistry());
                x.AddRegistry(new MassTransitRegistry());
                x.AddRegistry(new WebApiControllerRegistry());
            });
        }
    }
}
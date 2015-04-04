using AutoMapper;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.Api.StructureMap.Registries
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            For<IMappingEngine>().Use(Mapper.Engine);
        }
    }
}

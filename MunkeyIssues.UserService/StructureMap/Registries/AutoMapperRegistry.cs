using AutoMapper;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.UserService.StructureMap.Registries
{
    internal class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            For<IMappingEngine>().Use(Mapper.Engine);
        }
    }
}

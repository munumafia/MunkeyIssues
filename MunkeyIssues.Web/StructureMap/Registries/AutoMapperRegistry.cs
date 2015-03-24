using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.Web.StructureMap.Registries
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            For<IMappingEngine>().Use(Mapper.Engine);
        }
    }
}

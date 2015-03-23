using MunkeyIssues.IssueService.Persistence;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.IssueService.StructureMap.Registries
{
    public class PersistenceRegistry : Registry
    {
        public PersistenceRegistry()
        {
            For<IIssueContext>().Use<IssueContext>();
        }
    }
}
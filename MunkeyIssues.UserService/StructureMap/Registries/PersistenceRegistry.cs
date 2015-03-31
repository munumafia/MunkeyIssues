using MunkeyIssues.UserService.Persistence;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.UserService.StructureMap.Registries
{
    public class PersistenceRegistry : Registry
    {
        public PersistenceRegistry()
        {
            For<IUserContext>().Use<UserContext>();
        }
    }
}

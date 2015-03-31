using StructureMap;

namespace MunkeyIssues.UserService.StructureMap
{
    public class ContainerBuilder
    {
        public static IContainer Build()
        {
            return new Container(x => x.Scan(scanner => scanner.LookForRegistries()));
        }
    }
}

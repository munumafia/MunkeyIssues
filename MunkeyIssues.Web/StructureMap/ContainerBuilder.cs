using StructureMap;
using StructureMap.Graph;

namespace MunkeyIssues.Web.StructureMap
{
    public class ContainerBuilder
    {
        public static IContainer Build()
        {
            return new Container(x => x.Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.LookForRegistries();
            }));
        }
    }
}
using Microsoft.Owin.Security.OAuth;
using MunkeyIssues.Web.Providers;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.Web.StructureMap.Registries
{
    public class OAuthRegistry : Registry
    {
        public OAuthRegistry()
        {
            For<OAuthAuthorizationServerProvider>().Use<UserServiceAuthorizationServerProvider>();
        }
    }
}
using Microsoft.Owin.Security.OAuth;
using MunkeyIssues.Api.Providers;
using StructureMap.Configuration.DSL;

namespace MunkeyIssues.Api.StructureMap.Registries
{
    public class OAuthRegistry : Registry
    {
        public OAuthRegistry()
        {
            For<OAuthAuthorizationServerProvider>().Use<UserServiceAuthorizationServerProvider>();
        }
    }
}
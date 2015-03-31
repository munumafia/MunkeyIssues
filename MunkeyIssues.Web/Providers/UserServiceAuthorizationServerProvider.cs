using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace MunkeyIssues.Web.Providers
{
    public class UserServiceAuthorizationServerProvider : OAuthAuthorizationServerProvider 
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return base.GrantResourceOwnerCredentials(context);
        }
    }
}
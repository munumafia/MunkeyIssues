using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using MunkeyIssues.Core.Messaging.Users.Auth;
using MunkeyIssues.Web.Services.Users;

namespace MunkeyIssues.Web.Providers
{
    public class UserServiceAuthorizationServerProvider : OAuthAuthorizationServerProvider 
    {
        private readonly IUserService _UserService;

        public UserServiceAuthorizationServerProvider(IUserService userService)
        {
            _UserService = userService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var authResponse = await _UserService.Authenticate(new AuthenticateRequest
            {
                EmailAddress = context.UserName,
                Password = context.Password
            });

            if (!authResponse.Authenticated)
            {
                context.SetError("invalid_grant", "The username or password is incorrect");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));

            context.Validated(identity);
        }
    }
}
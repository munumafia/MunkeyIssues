using System.Threading.Tasks;
using MunkeyIssues.Core.Messaging.Users.Auth;
using MunkeyIssues.Core.Messaging.Users.Register;

namespace MunkeyIssues.Api.Services.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="request">The authentication request</param>
        /// <returns>The authentication response</returns>
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="request">The registration request message</param>
        /// <returns>The response to the registration request</returns>
        Task<RegisterUserResponse> Register(RegisterUserRequest request);
    }
}
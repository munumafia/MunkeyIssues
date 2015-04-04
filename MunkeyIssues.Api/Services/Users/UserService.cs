using System.Threading.Tasks;
using MunkeyIssues.Core.Messaging.Users.Auth;
using MunkeyIssues.Core.Messaging.Users.Register;
using MunkeyIssues.Core.Services.Cryptography;

namespace MunkeyIssues.Api.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IEncryptionService _CryptoService;
        private readonly string _PublicKey;
        private readonly IServiceBusService _ServiceBusService;

        public UserService(IEncryptionService cryptoService, string publicKey, IServiceBusService serviceBusService)
        {
            _CryptoService = cryptoService;
            _PublicKey = publicKey;
            _ServiceBusService = serviceBusService;
        }

        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="request">The authentication request</param>
        /// <returns>The authentication response</returns>
        public Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            // Encrypt the user's password before sending it across the service bus
            request.Password = _CryptoService.EncryptString(request.Password, _PublicKey);

            return _ServiceBusService.ExecuteRequestAsync<AuthenticateRequest, AuthenticateResponse>(request);
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        /// <param name="request">The registration request message</param>
        /// <returns>The response to the registration request</returns>
        public Task<RegisterUserResponse> Register(RegisterUserRequest request)
        {
            // Encrypt the user's password before sending it across the service bus
            request.Password = _CryptoService.EncryptString(request.Password, _PublicKey);

            return _ServiceBusService.ExecuteRequestAsync<RegisterUserRequest, RegisterUserResponse>(request);
        }
    }
}
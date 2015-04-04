using AutoMapper;
using MunkeyIssues.Core.Messaging.Users.Auth;
using MunkeyIssues.Core.Services.Cryptography;

namespace MunkeyIssues.UserService.Mappers.User
{
    public class AuthenticateRequestToUserMapper : IMapper<AuthenticateRequest, Domain.User>
    {
        private readonly IEncryptionService _CryptoService;
        private readonly IMappingEngine _Mapper;
        private readonly string _PrivateKey;

        public AuthenticateRequestToUserMapper(IEncryptionService cryptoService, IMappingEngine mapper, string privateKey)
        {
            _CryptoService = cryptoService;
            _Mapper = mapper;
            _PrivateKey = privateKey;
        }

        public Domain.User Map(AuthenticateRequest request)
        {
            var user = _Mapper.Map<Domain.User>(request);
            user.Password = _CryptoService.DecryptString(request.Password, _PrivateKey);

            return user;
        }
    }
}

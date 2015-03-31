using AutoMapper;
using MunkeyIssues.Core.Messaging.Users.Register;
using MunkeyIssues.Core.Services.Cryptography;

namespace MunkeyIssues.UserService.Mappers.User
{
    public class RegisterUserRequestToUserMapper : IMapper<RegisterUserRequest, Domain.User>
    {
        private readonly IEncryptionService _CryptoService;
        private readonly IMappingEngine _Mapper;
        private readonly string _PrivateKey;

        public RegisterUserRequestToUserMapper(IEncryptionService cryptoService, IMappingEngine mapper, string privateKey)
        {
            _CryptoService = cryptoService;
            _Mapper = mapper;
            _PrivateKey = privateKey;
        }

        public Domain.User Map(RegisterUserRequest request)
        {
            var user = _Mapper.Map<Domain.User>(request);
            user.Password = _CryptoService.DecryptString(request.Password, _PrivateKey);

            return user;
        }
    }
}

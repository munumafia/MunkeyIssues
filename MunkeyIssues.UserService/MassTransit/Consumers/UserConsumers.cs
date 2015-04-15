using System.Linq;
using AutoMapper;
using MassTransit;
using MunkeyIssues.Core.Messaging.Users.Auth;
using MunkeyIssues.Core.Messaging.Users.Register;
using MunkeyIssues.UserService.Domain;
using MunkeyIssues.UserService.Mappers;
using MunkeyIssues.UserService.Service.User;

namespace MunkeyIssues.UserService.MassTransit.Consumers
{
    public class UserConsumers : Consumes<RegisterUserRequest>.Context, Consumes<AuthenticateRequest>.Context
    {
        private readonly IMapper<RegisterUserRequest, User> _RegisterUserRequestToUserMapper;
        private readonly IMapper<AuthenticateRequest, User> _AuthenticateUserRequestToUserMapper;
        private readonly IMappingEngine _Mapper;
        private readonly IUserService _UserService;

        public UserConsumers(IMapper<RegisterUserRequest, User> registerUserRequestToUserMapper, 
            IMapper<AuthenticateRequest, User> authenticateUserRequestToUserMapper, IMappingEngine mapper, 
            IUserService userService)
        {
            _RegisterUserRequestToUserMapper = registerUserRequestToUserMapper;
            _AuthenticateUserRequestToUserMapper = authenticateUserRequestToUserMapper;
            _Mapper = mapper;
            _UserService = userService;
        }

        public void Consume(IConsumeContext<RegisterUserRequest> context)
        {
            var user = _RegisterUserRequestToUserMapper.Map(context.Message);
            var result = _UserService.Register(user);

            var response = _Mapper.Map<RegisterUserResponse>(result);
            response.Registered = !result.ValidationErrors.Any();
            response.UserId = result.Entity.Id;
            response.CorrelationId = context.Message.CorrelationId;

            context.Respond(response);
        }

        public void Consume(IConsumeContext<AuthenticateRequest> context)
        {
            var user = _AuthenticateUserRequestToUserMapper.Map(context.Message);
            var response = new AuthenticateResponse
            {
                Authenticated = _UserService.Authenticate(user),
                CorrelationId = context.Message.CorrelationId
            };
            
            context.Respond(response);
        }
    }
}

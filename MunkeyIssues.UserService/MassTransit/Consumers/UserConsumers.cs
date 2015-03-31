using AutoMapper;
using MassTransit;
using MunkeyIssues.Core.Messaging.Users.Register;
using MunkeyIssues.UserService.Domain;
using MunkeyIssues.UserService.Mappers;
using MunkeyIssues.UserService.Service.User;

namespace MunkeyIssues.UserService.MassTransit.Consumers
{
    public class UserConsumers : Consumes<RegisterUserRequest>.Context
    {
        private readonly IMapper<RegisterUserRequest, User> _RegisterUserRequestToUserMapper;
        private readonly IMappingEngine _Mapper;
        private readonly IUserService _UserService;

        public UserConsumers(IMapper<RegisterUserRequest, User> registerUserRequestToUserMapper, IMappingEngine mapper, 
            IUserService userService)
        {
            _RegisterUserRequestToUserMapper = registerUserRequestToUserMapper;
            _Mapper = mapper;
            _UserService = userService;
        }

        public void Consume(IConsumeContext<RegisterUserRequest> context)
        {
            var user = _RegisterUserRequestToUserMapper.Map(context.Message);
            var result = _UserService.Register(user);

            var response = _Mapper.Map<RegisterUserResponse>(result);
            response.CorrelationId = context.Message.CorrelationId;

            context.Respond(response);
        }
    }
}

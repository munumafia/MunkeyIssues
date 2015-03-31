using AutoMapper;
using MunkeyIssues.Core.Messaging.Users.Register;
using MunkeyIssues.UserService.Domain;
using MunkeyIssues.UserService.Service.Shared;

namespace MunkeyIssues.UserService.AutoMapper
{
    public class AutoMapperBuilder
    {
        public static void Build()
        {
            Mapper.CreateMap<RegisterUserRequest, User>();
            Mapper.CreateMap<CommandResult<User>, RegisterUserResponse>();
        }
    }
}

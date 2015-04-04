using MunkeyIssues.UserService.Service.Shared;

namespace MunkeyIssues.UserService.Service.User
{
    public interface IUserService
    {
        bool Authenticate(Domain.User user);
        CommandResult<Domain.User> Register(Domain.User user);
    }
}
using MunkeyIssues.UserService.Service.Shared;

namespace MunkeyIssues.UserService.Service.User
{
    public interface IUserService
    {
        CommandResult<Domain.User> Register(Domain.User user);
    }
}
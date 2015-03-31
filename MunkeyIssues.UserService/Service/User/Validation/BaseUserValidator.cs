using FluentValidation;

namespace MunkeyIssues.UserService.Service.User.Validation
{
    public class BaseUserValidator : AbstractValidator<Domain.User>
    {
        protected BaseUserValidator()
        {
            RuleFor(user => user.FirstName).NotNull().NotEmpty();
            RuleFor(user => user.LastName).NotNull().NotEmpty();
            RuleFor(user => user.EmailAddress).NotNull().NotEmpty();
            RuleFor(user => user.Password).NotNull().NotEmpty();
        }
    }
}

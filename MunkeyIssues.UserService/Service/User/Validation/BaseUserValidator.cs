using FluentValidation;

namespace MunkeyIssues.UserService.Service.User.Validation
{
    public class BaseUserValidator : AbstractValidator<Domain.User>
    {
        /// <summary>
        /// Constructs a new BaseUserValidator and adds all the base rules
        /// for validating a user
        /// </summary>
        protected BaseUserValidator()
        {
            RuleFor(user => user.FirstName).Must(NotBeNullOrWhiteSpace)
                .WithMessage("The FirstName property is required");

            RuleFor(user => user.LastName).Must(NotBeNullOrWhiteSpace)
                .WithMessage("The LastName property is required");

            RuleFor(user => user.EmailAddress).Must(NotBeNullOrWhiteSpace)
                .WithMessage("The EmailAddress property is required");

            RuleFor(user => user.Password).Must(NotBeNullOrWhiteSpace)
                .WithMessage("The Password property is required");
        }

        /// <summary>
        /// Verifies that the value is not null or contain only whitespace.
        /// </summary>
        /// <param name="value">The value to test</param>
        /// <returns>True if the value isn't null or whitespace only, false otherwise</returns>
        protected bool NotBeNullOrWhiteSpace(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}

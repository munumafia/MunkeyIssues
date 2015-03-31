using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using MunkeyIssues.UserService.Persistence;
using MunkeyIssues.UserService.Service.Validation;

namespace MunkeyIssues.UserService.Service.User.Validation
{
    public class UserAddValidator : BaseUserValidator, IValidateAdd<Domain.User>
    {
        private readonly IUserContext _DbContext;

        /// <summary>
        /// Creates a new UserAddValidator
        /// </summary>
        /// <param name="dbContext">The database context to use</param>
        public UserAddValidator(IUserContext dbContext)
        {
            _DbContext = dbContext;
        }

        /// <summary>
        /// Validates that a user with the email address doesn't already exist in the 
        /// database
        /// </summary>
        /// <param name="emailAddress">The email address to check if already exists in the database</param>
        /// <returns></returns>
        private bool NotExist(string emailAddress)
        {
            return !_DbContext.Users.Any(u => u.EmailAddress == emailAddress);
        }

        /// <summary>
        /// Validates that the user can be added to the database
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IList<string> ValidateAdd(Domain.User type)
        {
            RuleFor(user => user.EmailAddress).Must(NotExist).WithMessage("A user with this email address already exists");
            var result = Validate(type);

            return result.Errors.Select(e => e.ErrorMessage).ToList();
        }
    }
}
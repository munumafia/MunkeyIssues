using System.Collections.Generic;
using System.Linq;
using MunkeyIssues.Core.Services.Cryptography;
using MunkeyIssues.UserService.Persistence;
using MunkeyIssues.UserService.Service.Shared;
using MunkeyIssues.UserService.Service.Validation;

namespace MunkeyIssues.UserService.Service.User
{
    public class UserService : IUserService
    {
        private readonly IUserContext _DbContext;
        private readonly IHashService _HashService;
        private readonly IValidateAdd<Domain.User> _AddValidator;

        public UserService(IUserContext dbContext, IHashService hashService, IValidateAdd<Domain.User> addValidator)
        {
            _DbContext = dbContext;
            _HashService = hashService;
            _AddValidator = addValidator;
        }

        public CommandResult<Domain.User> Register(Domain.User user)
        {
            var errors = _AddValidator.ValidateAdd(user);
            if (errors.Any())
            {
                return new CommandResult<Domain.User>
                {
                    Entity = null,
                    RowsAffected = 0,
                    ValidationErrors = errors
                };
            }

            user.Salt = _HashService.GenerateSalt();
            user.Password = _HashService.HashString(user.Password, user.Salt);
            
            _DbContext.Users.Add(user);
            _DbContext.SaveChanges();

            return new CommandResult<Domain.User>
            {
                Entity = user,
                RowsAffected = 1,
                ValidationErrors = new List<string>()
            };
        }
    }
}

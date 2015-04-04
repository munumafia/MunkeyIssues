using FakeItEasy;
using MunkeyIssues.UserService.Persistence;
using MunkeyIssues.UserService.UnitTests.Util;

namespace MunkeyIssues.UserService.UnitTests.Service.User.Validation
{
    public class UserAddValidatorFixture
    {
        /// <summary>
        /// Creates a UserContext stub that contains the specified user
        /// </summary>
        /// <param name="user">The user that the UserContext should contain</param>
        /// <returns>The UserContext stub</returns>
        public IUserContext CreateUserContextStub(Domain.User user)
        {
            var dbContextStub = A.Fake<IUserContext>();
            dbContextStub.Users = StubbedDbSetFactory.Create(user);

            return dbContextStub;
        }

        /// <summary>
        /// Creates a UserContext stub
        /// </summary>
        /// <returns>The UserContext stub</returns>
        public IUserContext CreateUserContextStub()
        {
            var dbContextStub = A.Fake<IUserContext>();
            dbContextStub.Users = StubbedDbSetFactory.Create<Domain.User>();

            return dbContextStub;
        }

        /// <summary>
        /// Creates a User where all properties have valid values
        /// </summary>
        /// <returns>A valid User instance</returns>
        public Domain.User CreateValidUser()
        {
            return new Domain.User
            {
                EmailAddress = "test@example.com",
                FirstName = "Test",
                LastName = "User",
                IsDisabled = false,
                Password = "hunter2"
            };
        }
    }
}
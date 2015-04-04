using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using MunkeyIssues.UserService.Service.User.Validation;
using Xunit;
using UserServiceUser = MunkeyIssues.UserService.Domain.User;

namespace MunkeyIssues.UserService.UnitTests.Service.User.Validation
{
    public class UserAddValidatorFacts
    {
        public class ValidationShouldFail : IClassFixture<UserAddValidatorFixture>
        {
            private readonly UserAddValidatorFixture _Fixture;
            private readonly UserServiceUser _TestUser;

            /// <summary>
            /// Creates a new ValidationShouldFail instance
            /// </summary>
            /// <param name="fixture">The test fixture to use</param>
            public ValidationShouldFail(UserAddValidatorFixture fixture)
            {
                _Fixture = fixture;
                _TestUser = fixture.CreateValidUser();
            }

            /// <summary>
            /// Tests that validation fails when a second user with the same email address
            /// is being added to the database
            /// </summary>
            [Fact]
            public void WhenUserWithTheSameEmailExists()
            {
                // Arrange
                var dbContextStub = _Fixture.CreateUserContextStub(_TestUser);
                var validator = new UserAddValidator(dbContextStub);

                // Act
                var errors = validator.ValidateAdd(_TestUser);

                // Assert
                Assert.True(errors.Any(e => e.Contains("email address already exists")));
            }

            /// <summary>
            /// Tests that email address validation fails when the email address is null, 
            /// an empty string, or whitespace
            /// </summary>
            /// <param name="value">The particular value to test with</param>
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("   ")]
            public void WhenEmailAddressIsNullOrEmptyString(string value)
            {
                ValidationFailsForPropertyWithValue(u => _TestUser.EmailAddress, value);
            }

            /// <summary>
            /// Tests that the user's first name fails validation when the property is null, 
            /// an empty string, or whitespace
            /// </summary>
            /// <param name="value">The particular value to test with</param>
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("   ")]
            public void WhenFirstNameIsNullOrEmptyString(string value)
            {
                ValidationFailsForPropertyWithValue(u => _TestUser.FirstName, value);
            }

            /// <summary>
            /// Tests that the user's last name fails validation when the property is null, 
            /// an empty string, or whitespace
            /// </summary>
            /// <param name="value">The particular value to test with</param>
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("   ")]
            public void WhenLastNameIsNullOrEmptyString(string value)
            {
                ValidationFailsForPropertyWithValue(u => _TestUser.LastName, value);
            }

            /// <summary>
            /// Tests that the user's password fails validation when the property is null, 
            /// an empty string, or whitespace
            /// </summary>
            /// <param name="value">The particular value to test with</param>
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("   ")]
            public void WhenPasswordIsNullOrEmptyString(string value)
            {
                ValidationFailsForPropertyWithValue(u => _TestUser.Password, value);
            }

            /// <summary>
            /// Sets the specified property to the specified value and tests that validation
            /// fails
            /// </summary>
            /// <param name="propertyToTest">The property to test</param>
            /// <param name="propertyValue">The property value to test with</param>
            private void ValidationFailsForPropertyWithValue(Expression<Func<UserServiceUser, string>> propertyToTest, 
                string propertyValue)
            {
                // Arrange
                var propertyName = GetPropertyNameFromExpression(propertyToTest);
                var user = GetUserFromExpression(propertyToTest);
                var dbContextStub = _Fixture.CreateUserContextStub();
                var validator = new UserAddValidator(dbContextStub);
                
                // Act
                SetPropertyValue(user, propertyName, propertyValue);
                var errors = validator.ValidateAdd(user);
                
                // Assert
                var expectedError = string.Format("{0} property is required", propertyName.ToLower());
                Assert.True(errors.Any(e => e.ToLower().Contains(expectedError)));
            }

            /// <summary>
            /// Retrieves the name of the property invoked from an expression
            /// </summary>
            /// <param name="expr">The expression to get the name of the property from</param>
            /// <returns>The name of the property</returns>
            private static string GetPropertyNameFromExpression(Expression<Func<UserServiceUser, string>> expr)
            {
                var body = expr.Body as MemberExpression;
                if (body == null)
                {
                    throw new ArgumentException("Expected member expression");
                }

                return body.Member.Name;
            }

            /// <summary>
            /// Gets the User instance from a MemberExpression
            /// </summary>
            /// <param name="expr">The expression to get the User from</param>
            /// <returns>The User instance</returns>
            private static UserServiceUser GetUserFromExpression(Expression<Func<UserServiceUser, string>> expr)
            {
                var body = expr.Body as MemberExpression;
                if (body == null)
                {
                    throw new ArgumentException("Expected member expression");
                }

                var testUserExpr = body.Expression as MemberExpression;
                if (testUserExpr == null)
                {
                    throw new ArgumentException("Expected a MemberExpression");
                }

                var testClass = testUserExpr.Expression as ConstantExpression;
                if (testClass == null)
                {
                    throw new Exception("Expected a ConstantExpression");
                }

                const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                var userFieldInfo = testClass.Value.GetType().GetField(testUserExpr.Member.Name, bindingFlags);
                if (userFieldInfo == null)
                {
                    throw new Exception("Couldn't retrieve the test user from the test class");
                }

                return (UserServiceUser) userFieldInfo.GetValue(testClass.Value);
            }

            /// <summary>
            /// Sets the value of the specified property to the specified value
            /// </summary>
            /// <param name="user">The object instance to set the property value on</param>
            /// <param name="propertyName">The name of the property</param>
            /// <param name="propertyValue">The value of the property</param>
            private static void SetPropertyValue(UserServiceUser user, string propertyName, string propertyValue)
            {
                var property = user.GetType().GetProperty(propertyName);
                if (property.PropertyType != typeof(string))
                {
                    throw new ArgumentException("Property isn't a string");
                }

                if (!property.CanWrite)
                {
                    throw new ArgumentException("The value of the property can't be set");
                }

                property.SetValue(user, propertyValue);
            }
        }

        public class ValidationShouldSucceed : IClassFixture<UserAddValidatorFixture>
        {
            private readonly UserAddValidatorFixture _Fixture;
            private readonly UserServiceUser _TestUser;

            /// <summary>
            /// Creates a new ValidationShouldSucceed instance
            /// </summary>
            /// <param name="fixture">The test fixture to use</param>
            public ValidationShouldSucceed(UserAddValidatorFixture fixture)
            {
                _Fixture = fixture;
                _TestUser = fixture.CreateValidUser();
            }

            /// <summary>
            /// Tests that validation succeeds for valid users
            /// </summary>
            [Fact]
            public void WhenAllPropertiesAreValid()
            {
                // Arrange
                var dbContextStub = _Fixture.CreateUserContextStub();
                var validator = new UserAddValidator(dbContextStub);

                // Act
                var errors = validator.ValidateAdd(_TestUser);

                // Assert
                Assert.Empty(errors);
            }
        }
    }
}
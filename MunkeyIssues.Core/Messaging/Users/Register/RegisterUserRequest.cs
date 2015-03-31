using System;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Users.Register
{
    public class RegisterUserRequest : CorrelatedBy<Guid>
    {
        /// <summary>
        /// The request correlation ID
        /// </summary>
        public Guid CorrelationId { get; private set; }

        /// <summary>
        /// The first name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The email address of the user
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The password of the user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Constructs a new RegisterUserRequest
        /// </summary>
        public RegisterUserRequest()
        {
            CorrelationId = Guid.NewGuid();
        }
    }
}

using System;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Users.Auth
{
    public class AuthenticateRequest : CorrelatedBy<Guid>
    {
        /// <summary>
        /// The correlation ID for the request
        /// </summary>
        public Guid CorrelationId { get; private set; }

        /// <summary>
        /// The email address of the user
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The password of the user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Creates a new AuthenticateRequest
        /// </summary>
        public AuthenticateRequest()
        {
            CorrelationId = Guid.NewGuid();
        }
    }
}

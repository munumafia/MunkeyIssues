using System;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Users.Auth
{
    public class AuthenticateResponse : CorrelatedBy<Guid>
    {
        /// <summary>
        /// Whether or not the user was authenticated
        /// </summary>
        public bool Authenticated { get; set; }

        /// <summary>
        /// The correlation ID of the request
        /// </summary>
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// The first name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The user id of the user
        /// </summary>
        public int UserId { get; set; }
    }
}

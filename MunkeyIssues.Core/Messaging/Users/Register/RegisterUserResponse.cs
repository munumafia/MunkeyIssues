using System;
using System.Collections.Generic;
using MassTransit;

namespace MunkeyIssues.Core.Messaging.Users.Register
{
    public class RegisterUserResponse : CorrelatedBy<Guid>
    {
        /// <summary>
        /// The correlation ID for the request
        /// </summary>
        public Guid CorrelationId { get; set; }

        /// <summary>
        /// Whether or not the user was registered
        /// </summary>
        public bool Registered { get; set; }

        /// <summary>
        /// Any OAuth scopes associated with the user
        /// </summary>
        public IList<string> Scopes { get; set; } 

        /// <summary>
        /// The user id of the user created
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Any validation errors that were encountered
        /// </summary>
        public IList<string> ValidationErrors { get; set; }
    }
}

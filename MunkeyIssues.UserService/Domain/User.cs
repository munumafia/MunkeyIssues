using MunkeyIssues.Core.Domain;

namespace MunkeyIssues.UserService.Domain
{
    public class User : IEntity
    {
        /// <summary>
        /// The ID of the user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The email address of the user
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The first name of the user
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Whether or not the user is disabled
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// The last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The password of the user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The salt used when hashing the user's password
        /// </summary>
        public string Salt { get; set; }
    }
}

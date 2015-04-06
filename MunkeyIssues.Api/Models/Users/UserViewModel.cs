using System.Collections.Generic;

namespace MunkeyIssues.Api.Models.Users
{
    public class UserViewModel
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
        /// The last name of the user
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The list of OAuth2 scopes that the user has access to
        /// </summary>
        public IList<string> Scopes { get; set; }

        /// <summary>
        /// Constructs a new UserViewModel
        /// </summary>
        public UserViewModel()
        {
            Scopes = new List<string>();
        }
    }
}
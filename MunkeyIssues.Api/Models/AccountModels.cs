namespace MunkeyIssues.Api.Models
{
    public class RegisterViewModel
    {
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
    }
}
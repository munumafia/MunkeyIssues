namespace MunkeyIssues.Api.Models.Users
{
    public class RegisterUserViewModel
    {
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
        /// The password for the user
        /// </summary>
        public string Password { get; set; }
    }
}
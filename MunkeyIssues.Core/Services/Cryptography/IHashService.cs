namespace MunkeyIssues.Core.Services.Cryptography
{
    public interface IHashService
    {
        /// <summary>
        /// Generate a random salt to be used for hashing
        /// </summary>
        /// <returns>The generated salt</returns>
        string GenerateSalt();

        /// <summary>
        /// Compute the hash of the data
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <returns>The hash of the data</returns>
        byte[] Hash(byte[] data);

        /// <summary>
        /// Compute the hash of a string
        /// </summary>
        /// <param name="data">The string to hash</param>
        /// <returns>The Base64 encoded hash of the data</returns>
        string HashString(string data);

        /// <summary>
        /// Compute the hash of a string with the given salt
        /// </summary>
        /// <param name="data">The data to hash</param>
        /// <param name="salt">The salt to use</param>
        /// <returns>The hash of the data with the given salt</returns>
        string HashString(string data, string salt);
    }
}

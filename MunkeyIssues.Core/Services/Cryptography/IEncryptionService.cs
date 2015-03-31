using Microsoft.SqlServer.Server;

namespace MunkeyIssues.Core.Services.Cryptography
{
    public interface IEncryptionService
    {
        /// <summary>
        /// Encrypt the provided data
        /// </summary>
        /// <param name="data">The data to encrypt</param>
        /// <param name="publicKey">The public key to use for encryption</param>
        /// <returns>The encrypted data</returns>
        byte[] Encrypt(byte[] data, string publicKey);

        /// <summary>
        /// Encrypt the provided data
        /// </summary>
        /// <param name="data">The data to encrypt</param>
        /// <param name="publicKey">The public key to use for encryption</param>
        /// <returns>Base64 encoded string containing the encrypted data</returns>
        string EncryptString(string data, string publicKey);

        /// <summary>
        /// Decrypt the provided data
        /// </summary>
        /// <param name="data">The data to decrypt</param>
        /// <param name="privateKey">The private key to use for decryption</param>
        /// <returns>The decrypted data</returns>
        byte[] Decrypt(byte[] data, string privateKey);

        /// <summary>
        /// Decrypt the provided data
        /// </summary>
        /// <param name="data">The Base64 encoded data to decrypt</param>
        /// <param name="privateKey">The private key to use for decryption</param>
        /// <returns>The decrypted string</returns>
        string DecryptString(string data, string privateKey);
    }
}

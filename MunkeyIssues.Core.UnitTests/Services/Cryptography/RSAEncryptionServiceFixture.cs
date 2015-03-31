using System.Configuration;

namespace MunkeyIssues.Core.UnitTests.Services.Cryptography
{
    /// <summary>
    /// Contains test data for the various RSAEncryptionService
    /// unit tests
    /// </summary>
    public class RSAEncryptionServiceFixture
    {
        /// <summary>
        /// The public key used for encryption
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// The private key used for decryption
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// Constructs a new RSAEncryptionServiceFixture
        /// </summary>
        public RSAEncryptionServiceFixture()
        {
            PublicKey = ConfigurationManager.AppSettings["PublicKey"];
            PrivateKey = ConfigurationManager.AppSettings["PrivateKey"];
        }
    }
}

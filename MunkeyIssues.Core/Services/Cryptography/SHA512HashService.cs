using System;
using System.Security.Cryptography;
using System.Text;

namespace MunkeyIssues.Core.Services.Cryptography
{
    public class SHA512HashService : IHashService
    {
        private readonly int _SaltLength;

        public SHA512HashService(int saltLength = 16)
        {
            if (saltLength < 16)
            {
                var message = string.Format("Salt length of {0} is invalid, must be 16 or greater", saltLength);
                throw new ArgumentException(message, "saltLength");
            }

            _SaltLength = saltLength;
        }

        public string GenerateSalt()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            var saltBytes = new byte[_SaltLength];
            random.NextBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public byte[] Hash(byte[] data)
        {
            using (var sha512 = new SHA512CryptoServiceProvider())
            {
                return sha512.ComputeHash(data);
            }
        }

        public string HashString(string data)
        {
            using (var sha512 = new SHA512CryptoServiceProvider())
            {
                var bytes = Encoding.UTF8.GetBytes(data);
                var hash = sha512.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

        public string HashString(string data, string salt)
        {
            var salty = string.Format("{0};{1}", salt, data);
            return HashString(salty);
        }
    }
}

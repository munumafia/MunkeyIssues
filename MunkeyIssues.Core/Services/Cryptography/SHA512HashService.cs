using System;
using System.Security.Cryptography;
using System.Text;

namespace MunkeyIssues.Core.Services.Cryptography
{
    public class SHA512HashService : IHashService
    {
        private readonly int _SaltLength;

        public SHA512HashService(int saltLength = 15)
        {
            _SaltLength = saltLength;
        }

        public string GenerateSalt()
        {
            var random = new Random(unchecked((int)DateTime.Now.Ticks));
            var saltBytes = new byte[_SaltLength];
            random.NextBytes(saltBytes);

            return Encoding.UTF8.GetString(saltBytes);
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

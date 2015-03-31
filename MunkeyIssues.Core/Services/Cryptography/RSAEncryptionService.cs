using System;
using System.Security.Cryptography;
using System.Text;

namespace MunkeyIssues.Core.Services.Cryptography
{
    public class RSAEncryptionService : IEncryptionService
    {
        public byte[] Encrypt(byte[] data, string publicKey)
        {            
            using (var rsa = new RSACryptoServiceProvider())
            {
                var key = DecodeString(publicKey);
                rsa.FromXmlString(key);
                
                return rsa.Encrypt(data, true);
            }
        }

        public string EncryptString(string data, string publicKey)
        {
            using (var rsa = new RSACryptoServiceProvider())
            {
                var key = DecodeString(publicKey);
                rsa.FromXmlString(key);

                var bytes = Encoding.UTF8.GetBytes(data);
                var encrypted = rsa.Encrypt(bytes, true);

                return Convert.ToBase64String(encrypted);
            }
        }

        public byte[] Decrypt(byte[] data, string privateKey)
        {   
            using (var rsa = new RSACryptoServiceProvider())
            {
                var key = DecodeString(privateKey);
                rsa.FromXmlString(key);
                
                return rsa.Decrypt(data, true);
            }
        }

        public string DecryptString(string data, string privateKey)
        {
            throw new NotImplementedException();
        }

        private static string EncodeString(byte[] bytes)
        {
            return string.Empty;
        }

        private static string DecodeString(string str)
        {
            var decoded = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(decoded);
        }
    }
}

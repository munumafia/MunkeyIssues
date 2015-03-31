using System;
using MunkeyIssues.Core.Services.Cryptography;
using Xunit;

namespace MunkeyIssues.Core.UnitTests.Services.Cryptography
{
    public class RSAEncryptionServiceFacts
    {
        public class TheEncryptStringMethod : IClassFixture<RSAEncryptionServiceFixture>
        {
            private readonly RSAEncryptionServiceFixture _TestData;

            public TheEncryptStringMethod(RSAEncryptionServiceFixture testData)
            {
                _TestData = testData;
            }

            [Fact]
            public void ShouldSuccessfullyEncryptData()
            {
                // Arrange
                const string testData = "This is a test";
                var service = new RSAEncryptionService();

                // Act
                var cipherText = service.EncryptString(testData, _TestData.PublicKey);

                // Assert
                Assert.True(!string.IsNullOrWhiteSpace(cipherText));
            }

            [Fact]
            public void ShouldReturnBase64EncodedString()
            {
                // Arrange
                const string testData = "This is a test";
                var service = new RSAEncryptionService();
                var cipherText = service.EncryptString(testData, _TestData.PublicKey);

                // Act
                var bytes = Convert.FromBase64String(cipherText);

                // Assert
                Assert.True(bytes.Length > 0);
            }
        }

        public class TheDecryptStringMethod : IClassFixture<RSAEncryptionServiceFixture>
        {
            private readonly RSAEncryptionServiceFixture _TestData;

            public TheDecryptStringMethod(RSAEncryptionServiceFixture testData)
            {
                _TestData = testData;
            }

            [Fact]
            public void ShouldSuccessfullyDecryptData()
            {
                // Arrange
                const string testData = "This is a test";
                var service = new RSAEncryptionService();
                var cipherText = service.EncryptString(testData, _TestData.PublicKey);

                // Act
                var plainText = service.DecryptString(cipherText, _TestData.PrivateKey);

                // Assert
                Assert.Equal(testData, plainText);
            }
        }
    }
}

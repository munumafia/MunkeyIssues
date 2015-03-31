using System;
using System.Text;
using MunkeyIssues.Core.Services.Cryptography;
using Xunit;

namespace MunkeyIssues.Core.UnitTests.Services.Cryptography
{
    public class SHA512HashServiceFacts
    {
        public class TheGenerateSaltMethod
        {
            [Fact]
            public void ShouldNotGenerateTheSameSaltTwice()
            {
                // Arrange
                var service = new SHA512HashService();

                // Act
                var hash1 = service.GenerateSalt();
                var hash2 = service.GenerateSalt();

                // Assert
                Assert.NotEqual(hash1, hash2);
            }

            [Fact]
            public void ShouldGenerateAtLeast16ByteSalt()
            {
                // Arrange
                var service = new SHA512HashService();

                // Act
                var hash = service.GenerateSalt();
                var bytes = Convert.FromBase64String(hash);

                // Assert
                Assert.True(bytes.Length >= 16);
            }
        }

        public class TheHashMethod
        {
            [Fact]
            public void ShouldAlwaysGenerateTheSameHashForTheSameInput()
            {
                // Arrange
                var testData = Encoding.UTF8.GetBytes("This is a test");
                var service = new SHA512HashService();

                // Act
                var hash1 = service.Hash(testData);
                var hash2 = service.Hash(testData);

                // Assert
                Assert.Equal(hash1, hash2);
            }
        }

        public class TheHashStringMethod
        {
            [Fact]
            public void ShouldAlwaysGenerateTheSameHashForTheSameInput()
            {
                // Arrange
                const string testData = "This is a test";
                var service = new SHA512HashService();

                // Act
                var hash1 = service.HashString(testData);
                var hash2 = service.HashString(testData);

                // Assert
                Assert.Equal(hash1, hash2);
            }

            [Fact]
            public void ShouldAlwaysGenerateTheSameHashForTheSameInputAndSalt()
            {
                // Arrange
                const string testData = "This is a test";
                var service = new SHA512HashService();
                var salt = service.GenerateSalt();

                // Act
                var hash1 = service.HashString(testData, salt);
                var hash2 = service.HashString(testData, salt);

                // Assert
                Assert.Equal(hash1, hash2);
            }
        }

        public class TheConstructor
        {
            [Fact]
            public void ShouldThrowIfConstructedWithSaltLengthLessThan16Bytes()
            {
                // Arrange/Act/Assert
                Assert.Throws<ArgumentException>(() => new SHA512HashService(10));
            }
        }
    }
}

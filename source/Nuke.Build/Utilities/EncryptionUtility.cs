// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Nuke.Common.Utilities
{
    public static partial class EncryptionUtility
    {
        public static string Decrypt(string cipherText, string password, string name)
        {
            try
            {
                var cipherBytes = Convert.FromBase64String(cipherText.Remove(startIndex: 0, count: 3));
                var passwordBytes = Encoding.UTF8.GetBytes(password);

                using var memoryStream = new MemoryStream();
                using var cryptoStream = GetCryptoStream(memoryStream, passwordBytes, x => x.CreateDecryptor());
                cryptoStream.Write(cipherBytes, offset: 0, cipherBytes.Length);
                cryptoStream.Close();

                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch
            {
                Assert.Fail($"Could not decrypt '{name}' with provided password");
                return null;
            }
        }

        public static string Encrypt(string clearText, string password)
        {
            var clearBytes = Encoding.UTF8.GetBytes(clearText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            using var memoryStream = new MemoryStream();
            using var cryptoStream = GetCryptoStream(memoryStream, passwordBytes, x => x.CreateEncryptor());
            cryptoStream.Write(clearBytes, offset: 0, clearBytes.Length);
            cryptoStream.Close();

            return $"v1:{Convert.ToBase64String(memoryStream.ToArray())}";
        }

        private static Stream GetCryptoStream(Stream stream, byte[] password, Func<SymmetricAlgorithm, ICryptoTransform> transformSelector)
        {
            var salt = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
            var pdb = new Rfc2898DeriveBytes(password, salt, iterations: 10_000, HashAlgorithmName.SHA256);
            using var symmetricAlgorithm = Aes.Create().NotNull();
            symmetricAlgorithm.Key = pdb.GetBytes(32);
            symmetricAlgorithm.IV = pdb.GetBytes(16);

            return new CryptoStream(stream, transformSelector(symmetricAlgorithm), CryptoStreamMode.Write);
        }

        public static string GetGeneratedPassword(int bits)
        {
            var randomNumberGenerator = RandomNumberGenerator.Create();
            var password = new byte[bits / 8];
            randomNumberGenerator.GetBytes(password);
            return Convert.ToBase64String(password);
        }
    }
}

// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Utilities
{
    public static class EncryptionUtility
    {
        public static string Decrypt(string cipherText, byte[] password, string name)
        {
            try
            {
                var cipherBytes = Convert.FromBase64String(cipherText.Remove(startIndex: 0, count: 3));

                using var ms = new MemoryStream();
                using var cs = GetCryptoStream(ms, password, x => x.CreateDecryptor());
                cs.Write(cipherBytes, offset: 0, cipherBytes.Length);
                cs.Close();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch
            {
                ControlFlow.Fail($"Could not decrypt '{name}' with provided password.");
                return null;
            }
        }

        public static string Encrypt(string clearText, byte[] password)
        {
            var clearBytes = Encoding.UTF8.GetBytes(clearText);

            using var ms = new MemoryStream();
            using var cs = GetCryptoStream(ms, password, x => x.CreateEncryptor());
            cs.Write(clearBytes, offset: 0, clearBytes.Length);
            cs.Close();

            return $"v1:{Convert.ToBase64String(ms.ToArray())}";
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

        public static void DeletePasswordFromCredentialStore(string name)
        {
            switch (EnvironmentInfo.Platform)
            {
                case PlatformFamily.OSX:
                    ProcessTasks.StartProcess(
                        Security,
                        $"delete-generic-password -a {EnvironmentInfo.Variables["LOGNAME"]} -s {name.DoubleQuoteIfNeeded()}",
                        logInvocation: false,
                        logOutput: false).AssertZeroExitCode();
                    break;
                default:
                    throw new NotSupportedException(EnvironmentInfo.Platform.ToString());
            }
        }

        public static void SavePasswordToCredentialStore(string name, string password)
        {
            switch (EnvironmentInfo.Platform)
            {
                case PlatformFamily.OSX:
                    ProcessTasks.StartProcess(
                        Security,
                        $"add-generic-password -T \"\" -a {EnvironmentInfo.Variables["LOGNAME"]} -s {name.DoubleQuoteIfNeeded()} -w {password}",
                        logInvocation: false,
                        logOutput: false).AssertZeroExitCode();
                    break;
                default:
                    throw new NotSupportedException(EnvironmentInfo.Platform.ToString());
            }
        }

        [CanBeNull]
        public static string TryGetPasswordFromCredentialStore(string name)
        {
            switch (EnvironmentInfo.Platform)
            {
                case PlatformFamily.OSX:
                    var process = ProcessTasks.StartProcess(
                        Security,
                        $"find-generic-password -w -a {EnvironmentInfo.Variables["LOGNAME"]} -s {name.DoubleQuoteIfNeeded()}",
                        logInvocation: false,
                        logOutput: false);
                    process.WaitForExit();
                    return process.ExitCode == 0
                        ? process.Output.Single().Text
                        : null;
                default:
                    throw new NotSupportedException(EnvironmentInfo.Platform.ToString());
            }
        }

        private static string Security => ToolPathResolver.GetPathExecutable("security");

        public static string GetPassword(string profile)
        {
            string PromptForPassword()
            {
                Logger.Info($"Enter password for {profile} parameters:");
                return ConsoleUtility.ReadSecret();
            }

            var credentialStoreName = Constants.GetCredentialStoreName(NukeBuild.RootDirectory, profile);
            return TryGetPasswordFromCredentialStore(credentialStoreName) ??
                   EnvironmentInfo.GetParameter<string>(Constants.GetProfilePasswordEnvironmentVariableName(profile)) ??
                   PromptForPassword();
        }

        public static string CreateNewPassword(out bool generated)
        {
            while (true)
            {
                Logger.Info(
                    EnvironmentInfo.IsOsx
                        ? "Enter a minimum 10 character password (leave empty for auto-generated stored in macOS keychain):"
                        : "Enter a minimum 10 character password:");

                var password = ConsoleUtility.ReadSecret();
                if (password.IsNullOrEmpty() && EnvironmentInfo.IsOsx)
                {
                    generated = true;
                    return GetGeneratedPassword();
                }

                if (!password.IsNullOrEmpty() && password.Length >= 10)
                {
                    generated = false;
                    return password;
                }
            }
        }

        private static string GetGeneratedPassword()
        {
            var randomNumberGenerator = RandomNumberGenerator.Create();
            var password = new byte[256];
            randomNumberGenerator.GetBytes(password);
            return Convert.ToBase64String(password);
        }
    }
}

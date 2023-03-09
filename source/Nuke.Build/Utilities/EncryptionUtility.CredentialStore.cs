// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Utilities
{
    public static partial class EncryptionUtility
    {
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
                    return null;
            }
        }

        private static string Security => ToolPathResolver.GetPathExecutable("security");

        public static string GetPassword(string profile, string rootDirectory)
        {
            string PromptForPassword()
            {
                Host.Information($"Enter password for {Constants.GetParametersFileName(profile)}:");
                return ConsoleUtility.ReadSecret();
            }

            var credentialStoreName = Constants.GetCredentialStoreName(rootDirectory, profile);
            var passwordParameterName = Constants.GetProfilePasswordParameterName(profile);
            return TryGetPasswordFromCredentialStore(credentialStoreName) ??
                   ParameterService.GetParameter<string>(passwordParameterName) ??
                   PromptForPassword();
        }

        public static string CreateNewPassword(out bool generated)
        {
            while (true)
            {
                Host.Information(
                    EnvironmentInfo.IsOsx
                        ? "Enter a minimum 10 character password (leave empty for auto-generated stored in macOS keychain):"
                        : "Enter a minimum 10 character password:");

                var password = ConsoleUtility.ReadSecret();
                if (password.IsNullOrEmpty() && EnvironmentInfo.IsOsx)
                {
                    generated = true;
                    return GetGeneratedPassword(bits: 256);
                }

                if (!password.IsNullOrEmpty() && password.Length >= 10)
                {
                    generated = false;
                    return password;
                }
            }
        }
    }
}

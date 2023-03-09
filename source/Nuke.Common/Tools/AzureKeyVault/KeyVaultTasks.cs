// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.AzureKeyVault
{
    [PublicAPI]
    public static class KeyVaultTasks
    {
        /// <summary><p>Load an Azure Key Vault to obtain secrets.</p></summary>
        public static KeyVault LoadVault (KeyVaultTaskSettings settings)
        {
            AssertTaskSettings(settings);
            return CreateVault(settings);
        }

        /// <summary><p>Get a secret.</p></summary>
        public static string GetSecret (KeyVaultTaskSettings settings)
        {
            AssertTaskSettings(settings);
            return GetTaskResult(CreateVault(settings).GetSecret(settings.SecretName));
        }

        /// <summary><p>>Get a certificate.</p></summary>
        public static KeyVaultKey GetKeyBundle (KeyVaultTaskSettings settings)
        {
            AssertTaskSettings(settings);
            return GetTaskResult(CreateVault(settings).GetKey(settings.SecretName));
        }

        /// <summary><p>Get a certificate bundle.</p></summary>
        public static KeyVaultCertificate GetCertificateBundle (KeyVaultTaskSettings settings, bool includeKey = true)
        {
            AssertTaskSettings(settings);
            return GetTaskResult(CreateVault(settings).GetCertificate(settings.SecretName, includeKey));
        }

        private static KeyVault CreateVault (KeyVaultTaskSettings settings)
        {
            return new KeyVault(settings.ClientId, settings.ClientSecret, settings.VaultBaseUrl);
        }

        [AssertionMethod]
        private static void AssertTaskSettings (KeyVaultTaskSettings settings)
        {
            Assert.NotNull(settings.VaultBaseUrl);
            Assert.NotNull(settings.SecretName);
            Assert.NotNull(settings.ClientSecret);
            Assert.NotNull(settings.ClientId);
        }

        private static T GetTaskResult<T> ([NotNull] Task<T> task)
        {
            try
            {
                task.Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Could not retrieve KeyVault value: {ex.Message}");
            }

            return task.Result;
        }
    }
}

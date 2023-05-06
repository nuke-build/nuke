// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.AzureKeyVault
{
    [PublicAPI]
    public static class AzureKeyVaultTasks
    {
        /// <summary><p>Load an Azure Key Vault to obtain secrets.</p></summary>
        public static AzureKeyVault LoadVault(AzureKeyVaultConfiguration configuration)
        {
            return CreateVault(configuration);
        }

        /// <summary><p>>Get a key bundle.</p></summary>
        public static AzureKeyVaultKey GetKeyBundle(AzureKeyVaultConfiguration configuration, string keyName)
        {
            return CreateVault(configuration).GetKey(keyName).Result;
        }

        /// <summary><p>Get a secret.</p></summary>
        public static string GetSecret(AzureKeyVaultConfiguration configuration, string secretName)
        {
            return CreateVault(configuration).GetSecret(secretName).Result;
        }

        /// <summary><p>Get a certificate bundle.</p></summary>
        public static AzureKeyVaultCertificate GetCertificateBundle(
            AzureKeyVaultConfiguration configuration,
            string certificateName,
            bool includeKey = true,
            bool includeSecret = true)
        {
            return CreateVault(configuration).GetCertificate(certificateName, includeKey, includeSecret).Result;
        }

        private static AzureKeyVault CreateVault(AzureKeyVaultConfiguration configuration)
        {
            return new AzureKeyVault(
                configuration.TenantId.NotNull("configuration.TenantId != null"),
                configuration.ClientId.NotNull("configuration.ClientId != null"),
                configuration.ClientSecret.NotNull("configuration.ClientSecret != null"),
                configuration.BaseUrl.NotNull("configuration.BaseUrl != null"));
        }
    }
}

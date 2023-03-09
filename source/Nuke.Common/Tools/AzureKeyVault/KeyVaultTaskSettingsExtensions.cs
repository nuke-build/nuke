// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.AzureKeyVault.Attributes;

namespace Nuke.Common.Tools.AzureKeyVault
{
    [PublicAPI]
    public static class KeyVaultTaskSettingsExtensions
    {
        /// <summary><p><em>Sets <see cref="KeyVaultTaskSettings.ClientId"/>.</em></p><p>The client id of an AzureAd application with permissions for the required operations.</p></summary>
        [Pure]
        public static KeyVaultTaskSettings SetClientId (this KeyVaultTaskSettings keyVaultSettings, string clientId)
        {
            keyVaultSettings = keyVaultSettings.NewInstance();
            keyVaultSettings.ClientId = clientId;
            return keyVaultSettings;
        }

        /// <summary><p><em>Sets <see cref="KeyVaultTaskSettings.ClientSecret"/>.</em></p><p>The secret of the AzureAd application.</p></summary>
        [Pure]
        public static KeyVaultTaskSettings SetClientSecret (this KeyVaultTaskSettings keyVaultSettings, string clientSecret)
        {
            keyVaultSettings = keyVaultSettings.NewInstance();
            keyVaultSettings.ClientSecret = clientSecret;
            return keyVaultSettings;
        }

        /// <summary><p><em>Sets <see cref="KeyVaultTaskSettings.SecretName"/>.</em></p><p>The name of the secret to obtain.</p></summary>
        [Pure]
        public static KeyVaultTaskSettings SetSecretName (this KeyVaultTaskSettings keyVaultSettings, string secretName)
        {
            keyVaultSettings = keyVaultSettings.NewInstance();
            keyVaultSettings.SecretName = secretName;
            return keyVaultSettings;
        }

        /// <summary><p><em>Sets <see cref="KeyVaultTaskSettings.VaultBaseUrl"/>.</em></p><p>The base url of the Azure Key Vault.</p></summary>
        [Pure]
        public static KeyVaultTaskSettings SetVaultBaseUrl (this KeyVaultTaskSettings keyVaultSettings, string vaultBaseUrl)
        {
            keyVaultSettings = keyVaultSettings.NewInstance();
            keyVaultSettings.VaultBaseUrl = vaultBaseUrl;
            return keyVaultSettings;
        }

        /// <summary><p><em>Sets <see cref="KeyVaultTaskSettings.VaultBaseUrl"/>, <see cref="KeyVaultTaskSettings.ClientSecret"/> and <see cref="KeyVaultTaskSettings.ClientId"/>.</em></p></summary>
        [Pure]
        public static KeyVaultTaskSettings Set (this KeyVaultTaskSettings keyVaultTaskSettings, KeyVaultSettings settings)
        {
            keyVaultTaskSettings = keyVaultTaskSettings.NewInstance();
            keyVaultTaskSettings.ClientId = settings.ClientId;
            keyVaultTaskSettings.ClientSecret = settings.Secret;
            keyVaultTaskSettings.VaultBaseUrl = settings.BaseUrl;
            return keyVaultTaskSettings;
        }
    }
}

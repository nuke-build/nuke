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
    [Serializable]
    [PublicAPI]
    public class KeyVaultTaskSettings : ISettingsEntity
    {
        /// <summary><p>The client id of an AzureAd application with permissions for the required operations.</p></summary>
        public string ClientId { get; internal set; }

        /// <summary><p>The secret of the AzureAd application.</p></summary>
        public string ClientSecret { get; internal set; }

        /// <summary><p>The name of the secret to obtain.</p></summary>
        public string SecretName { get; internal set; }

        /// <summary><p>The base url of the Azure Key Vault.</p></summary>
        public string VaultBaseUrl { get; internal set; }

        public KeyVaultTaskSettings ()
        {
        }

        public KeyVaultTaskSettings (KeyVaultSettings keyVaultSettings)
        {
            ClientId = keyVaultSettings.ClientId;
            ClientSecret = keyVaultSettings.Secret;
            VaultBaseUrl = keyVaultSettings.BaseUrl;
        }
    }
}

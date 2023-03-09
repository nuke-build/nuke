// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Nuke.Common.Tools.AzureKeyVault
{
    [PublicAPI]
    public class KeyVault
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        [CanBeNull] private readonly string _baseUrl;
        public readonly KeyVaultClient Client;

        internal KeyVault (string clientId, string clientSecret, string baseUrl = null)
        {
            _baseUrl = baseUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;
            Client = new KeyVaultClient(GetAccessToken);
        }

        private async Task<string> GetAccessToken (string authority, string resource, string scope)
        {
            var authenticationContext = new AuthenticationContext(authority);
            var credential = new ClientCredential(_clientId, _clientSecret);
            var result = await authenticationContext.AcquireTokenAsync(resource, credential);
            return result.NotNull("Could not obtain Azure KeyVault JWT token").AccessToken;
        }

        public async Task<KeyVaultCertificate> GetCertificate (string certificateName, bool includeKey = true)
        {
            var certificateBundle = await Client.GetCertificateAsync(_baseUrl, certificateName);
            certificateBundle.Validate();
            var keyVaultCertificate = new KeyVaultCertificate { Cer = certificateBundle.Cer, X509Thumbprint = certificateBundle.X509Thumbprint };
            if (includeKey && certificateBundle.KeyIdentifier == null)
                keyVaultCertificate.Key = await GetKeyVaultKey(certificateBundle.Kid, certificateBundle.Sid);
            return keyVaultCertificate;
        }

        public async Task<KeyVaultKey> GetKey (string keyName)
        {
            var keyBundle = await Client.GetKeyAsync(keyName);
            return new KeyVaultKey { Key = keyBundle.Key };
        }

        public async Task<string> GetSecret (string secretName)
        {
            return (await Client.GetSecretAsync(_baseUrl, secretName)).Value;
        }

        private async Task<KeyVaultKey> GetKeyVaultKey (string keyIdentifier, string secretIdentifier = null)
        {
            Task<SecretBundle> secretTask = null;
            if (secretIdentifier != null)
                secretTask = Client.GetSecretAsync(secretIdentifier);
            var keyBundle = await Client.GetKeyAsync(keyIdentifier);
            var keyVaultKey = new KeyVaultKey { Key = keyBundle.Key };
            if (secretTask != null)
                keyVaultKey.Secret = (await secretTask).Value;
            return keyVaultKey;
        }
    }
}

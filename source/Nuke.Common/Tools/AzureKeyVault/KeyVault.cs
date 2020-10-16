// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Secrets;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.AzureKeyVault
{
    [PublicAPI]
    public class KeyVault
    {
        private readonly Lazy<CertificateClient> _certificateClient;
        private readonly Lazy<KeyClient> _keyClient;
        private readonly Lazy<SecretClient> _secretClient;
        
        internal KeyVault(string tenantId, string clientId, string clientSecret, string baseUrl)
        {
            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var uri = new Uri(baseUrl);

            _certificateClient = new Lazy<CertificateClient>(() => new CertificateClient(uri, credential));
            _keyClient = new Lazy<KeyClient>(() => new KeyClient(uri, credential));
            _secretClient = new Lazy<SecretClient>(() => new SecretClient(uri, credential));
        }

        public CertificateClient CertificateClient => _certificateClient.Value;
        public KeyClient KeyClient => _keyClient.Value;
        public SecretClient SecretClient => _secretClient.Value;

        public async Task<KeyVaultCertificate> GetCertificate(string certificateName, bool includeKey = true, bool includeSecret = true)
        {
            var certificateBundleResponse = await _certificateClient.Value.GetCertificateAsync(certificateName);
            var certificateBundle = certificateBundleResponse.Value;

            Task<KeyVaultKey> keyRequest = null;
            if (includeKey && certificateBundle.KeyId != null)
                keyRequest = GetKey(ParseKeyName(certificateBundle.KeyId));

            Task<string> secretRequest = null;
            if (includeSecret && certificateBundle.SecretId != null)
                secretRequest = GetSecret(ParseSecretName(certificateBundle.SecretId));

            return new KeyVaultCertificate
                   {
                       Cer = certificateBundle.Cer,
                       KeySecret = secretRequest == null ? null : await secretRequest,
                       Key = keyRequest == null ? null : await keyRequest,
                       X509Thumbprint = certificateBundle.Properties.X509Thumbprint,
                   };
        }

        public async Task<KeyVaultKey> GetKey(string keyName)
        {
            var keyBundle = (await _keyClient.Value.GetKeyAsync(keyName)).Value;
            return new KeyVaultKey { Key = keyBundle.Key };
        }

        public async Task<string> GetSecret(string secretName)
        {
            return (await _secretClient.Value.GetSecretAsync(secretName)).Value.Value;
        }
        
        private async Task<KeyVaultKey> GetKeyVaultKey(string keyIdentifier, string secretIdentifier = null)
        {
            Task<Response<KeyVaultSecret>> secretTask = null;
            if (secretIdentifier != null)
                secretTask = SecretClient.GetSecretAsync(secretIdentifier);
            var keyBundle = await KeyClient.GetKeyAsync(keyIdentifier);
            var keyVaultKey = new KeyVaultKey { Key = keyBundle.Value.Key };
            if (secretTask != null)
                keyVaultKey.Secret = (await secretTask).Value.Value;
            return keyVaultKey;
        }
        
        private static string ParseSecretName(Uri secretId)
        {
            if (secretId.Segments.Length < 3)
                throw new InvalidOperationException($@"The secret ""{secretId}"" does not contain a valid name.");

            return secretId.Segments[2].TrimEnd('/');
        }

        private static string ParseKeyName(Uri keyId)
        {
            if (keyId.Segments.Length < 3)
                throw new InvalidOperationException($@"The key ""{keyId}"" does not contain a valid name.");

            return keyId.Segments[2].TrimEnd('/');
        }
    }
}

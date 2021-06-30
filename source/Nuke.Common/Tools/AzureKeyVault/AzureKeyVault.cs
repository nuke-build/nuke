// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Secrets;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.AzureKeyVault
{
    [PublicAPI]
    public class AzureKeyVault
    {
        private readonly Lazy<CertificateClient> _certificateClient;
        private readonly Lazy<KeyClient> _keyClient;
        private readonly Lazy<SecretClient> _secretClient;
        
        internal AzureKeyVault(string tenantId, string clientId, string clientSecret, string baseUrl)
        {
            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
            var uri = new Uri(baseUrl);

            _keyClient = new Lazy<KeyClient>(() => new KeyClient(uri, credential));
            _secretClient = new Lazy<SecretClient>(() => new SecretClient(uri, credential));
            _certificateClient = new Lazy<CertificateClient>(() => new CertificateClient(uri, credential));
        }

        public CertificateClient CertificateClient => _certificateClient.Value;
        public KeyClient KeyClient => _keyClient.Value;
        public SecretClient SecretClient => _secretClient.Value;

        public async Task<AzureKeyVaultKey> GetKey(string keyName, string secretName = null)
        {
            return new AzureKeyVaultKey
                   {
                       Key = (await KeyClient.GetKeyAsync(keyName)).Value.Key,
                       Secret = secretName != null ? await GetSecret(secretName) : null
                   };
        }

        public async Task<string> GetSecret(string secretName)
        {
            return (await SecretClient.GetSecretAsync(secretName)).Value.Value;
        }

        public async Task<AzureKeyVaultCertificate> GetCertificate(string certificateName, bool includeKey = true, bool includeSecret = true)
        {
            var certificateBundleResponse = await CertificateClient.GetCertificateAsync(certificateName);
            var certificateBundle = certificateBundleResponse.Value;

            string Parse(Uri id)
            {
                ControlFlow.Assert(id.Segments.Length < 3, $"The key/secret id {id.ToString().DoubleQuote()} does not contain a valid name.");
                return id.Segments[2].TrimEnd('/');
            }

            return new AzureKeyVaultCertificate
                   {
                       Cer = certificateBundle.Cer,
                       X509Thumbprint = certificateBundle.Properties.X509Thumbprint,
                       Key = includeKey && certificateBundle.KeyId != null
                           ? await GetKey(Parse(certificateBundle.KeyId))
                           : null,
                       Secret = includeSecret && certificateBundle.SecretId != null
                           ? await GetSecret(Parse(certificateBundle.SecretId))
                           : null
                   };
        }
    }
}

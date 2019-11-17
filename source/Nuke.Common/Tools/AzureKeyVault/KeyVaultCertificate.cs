// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/azure-keyvault/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.AzureKeyVault
{
    public class KeyVaultCertificate
    {
        public byte[] Cer { get; internal set; }
        public byte[] X509Thumbprint { get; internal set; }
        public KeyVaultKey Key { get; internal set; }
    }
}

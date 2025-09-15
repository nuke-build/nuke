// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.AzureKeyVault
{
    public class AzureKeyVaultCertificate
    {
        public byte[] Cer { get; internal set; }
        public byte[] X509Thumbprint { get; internal set; }
        public AzureKeyVaultKey Key { get; internal set; }
        public string Secret { get; internal set; }
    }
}

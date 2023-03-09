// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

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

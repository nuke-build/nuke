// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Microsoft.Azure.KeyVault.WebKey;

namespace Nuke.Common.Tools.AzureKeyVault
{
    public class KeyVaultKey
    {
        public string Secret { get; internal set; }
        public JsonWebKey Key { get; internal set; }
    }
}

// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/azure-keyvault/blob/master/LICENSE

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

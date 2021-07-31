// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.AzureKeyVault
{
    /// <summary>Attribute to obtain a key from from the Azure KeyVault defined by <see cref="AzureKeyVaultConfigurationAttribute"/>.</summary>
    [PublicAPI]
    public class AzureKeyVaultKeyAttribute : AzureKeyVaultAttributeBase
    {
        private readonly string _keyName;

        public AzureKeyVaultKeyAttribute(string keyName = null)
        {
            _keyName = keyName;
        }

        protected override object GetValue(AzureKeyVaultConfiguration configuration, MemberInfo member)
        {
            return AzureKeyVaultTasks.GetKeyBundle(configuration, _keyName ?? member.Name);
        }
    }
}

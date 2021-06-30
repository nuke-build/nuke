// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.AzureKeyVault
{
    /// <summary>Attribute to obtain a secret from the Azure KeyVault defined by <see cref="AzureKeyVaultConfigurationAttribute"/>.</summary>
    [PublicAPI]
    public class AzureKeyVaultSecretAttribute : AzureKeyVaultAttributeBase
    {
        private readonly string _secretName;

        public AzureKeyVaultSecretAttribute(string secretName = null)
        {
            _secretName = secretName;
        }

        protected override object GetValue(AzureKeyVaultConfiguration configuration, MemberInfo member)
        {
            return AzureKeyVaultTasks.GetSecret(configuration, _secretName ?? member.Name);
        }
    }
}

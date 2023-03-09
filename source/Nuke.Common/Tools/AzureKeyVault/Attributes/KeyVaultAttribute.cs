// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.AzureKeyVault.Attributes
{
    /// <summary>Attribute to obtain the KeyVault defined by <see cref="KeyVaultSettingsAttribute"/> to retrieve multiple items.</summary>
    [PublicAPI]
    public class KeyVaultAttribute : KeyVaultSecretAttribute
    {
        public override object GetValue (MemberInfo member, object instance)
        {
            if (member.GetMemberType() != typeof(KeyVault))
                throw new NotSupportedException();
            return base.GetValue(member, instance);
        }
    }
}

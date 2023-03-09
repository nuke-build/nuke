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
    /// <summary> Attribute to obtain a certificates from from the Azure KeyVault defined by <see cref="KeyVaultSettingsAttribute"/>.</summary>
    [PublicAPI]
    public class KeyVaultCertificateAttribute : KeyVaultSecretAttribute
    {
        /// <summary> Attribute to obtain certificates from from the Azure KeyVault defined by <see cref="KeyVaultSettingsAttribute"/>.</summary>
        /// <param name="certificateName">The name of the certificate to obtain.</param>
        /// <param name="includeKey">If set to <c>true</c> the key of the certificate is also obtained.</param>
        public KeyVaultCertificateAttribute (string certificateName = null, bool includeKey = true)
                : base(certificateName)
        {
            IncludeKey = includeKey;
        }

        /// <summary>If set to true the key of the certificate is also obtained.</summary>
        public bool IncludeKey { get; set; }

        [CanBeNull]
        public override object GetValue (MemberInfo member, object instance)
        {
            if (member.GetMemberType() != typeof(KeyVaultCertificate))
                throw new NotSupportedException();
            return base.GetValue(member, instance);
        }
    }
}

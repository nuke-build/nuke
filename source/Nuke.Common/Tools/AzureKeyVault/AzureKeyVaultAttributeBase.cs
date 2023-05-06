// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tools.AzureKeyVault
{
    public abstract class AzureKeyVaultAttributeBase : ValueInjectionAttributeBase
    {
        public string ConfigurationMemberName { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            var configuration = GetConfiguration(instance);
            return GetValue(configuration, member);
        }

        protected abstract object GetValue(AzureKeyVaultConfiguration configuration, MemberInfo member);

        private AzureKeyVaultConfiguration GetConfiguration(object instance)
        {
            var membersWithAttributes = ValueInjectionUtility.GetInjectionMembers(instance.GetType())
                .Where(x => x.Attribute is AzureKeyVaultConfigurationAttribute)
                .ToArray();

            Assert.NotEmpty(membersWithAttributes,
                $"Member of the type {nameof(AzureKeyVaultConfiguration)} with {nameof(AzureKeyVaultConfigurationAttribute)} must be defined when using {GetType().Name}");
            Assert.True(membersWithAttributes.Length == 1 || ConfigurationMemberName != null,
                $"Property {nameof(ConfigurationMemberName)} must be defined when providing more than one {nameof(AzureKeyVaultConfiguration)} member");

            var memberWithAttribute = membersWithAttributes.Length == 1
                ? membersWithAttributes.Single()
                : membersWithAttributes.SingleOrDefault(x => x.Member.Name == ConfigurationMemberName);
            Assert.True(memberWithAttribute is not (null, null), $"No field with the name '{ConfigurationMemberName}' exists");

            return (AzureKeyVaultConfiguration) memberWithAttribute.Attribute.GetValue(memberWithAttribute.Member, instance);
        }
    }
}

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
    /// <summary>Attribute to obtain a secret from the Azure KeyVault defined by <see cref="KeyVaultSettingsAttribute"/>.</summary>
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Field)]
    [MeansImplicitUse(ImplicitUseKindFlags.Assign)]
    public class KeyVaultSecretAttribute : ParameterAttribute
    {
        protected static KeyVaultTaskSettings CreateSettings(string secretName, KeyVaultSettings keyVaultSettings)
        {
            return new KeyVaultTaskSettings()
                .SetClientId(keyVaultSettings.ClientId)
                .SetVaultBaseUrl(keyVaultSettings.BaseUrl)
                .SetClientSecret(keyVaultSettings.Secret)
                .SetSecretName(secretName);
        }

        /// <summary>Obtain the secret with the given name from the KeyVault defined by <see cref="KeyVaultSettingsAttribute"/></summary>
        public KeyVaultSecretAttribute()
        {
        }

        /// <summary>Obtain the secret with the given name from the KeyVault defined by <see cref="KeyVaultSettingsAttribute"/></summary>
        /// <param name="secretName">The name of the secret to obtain. If the name is null the name of the property is used.</param>
        public KeyVaultSecretAttribute(string secretName)
        {
            SecretName = secretName;
        }

        /// <summary><p>The name of the secret to obtain.</p></summary>
        [CanBeNull]
        public string SecretName { get; set; }

        [CanBeNull]
        public string SettingFieldName { get; set; }

        [CanBeNull]
        public override object GetValue(MemberInfo member, object instance)
        {
            var settings = GetSettings(instance);
            if (!settings.IsValid(out _))
                return null;

            var secretName = SecretName ?? member.Name;
            var memberType = member.GetMemberType();

            if (memberType == typeof(string))
                return ParameterService.GetParameter<string>(secretName) ?? KeyVaultTasks.GetSecret(CreateSettings(secretName, settings));
            if (memberType == typeof(KeyVaultKey))
                return KeyVaultTasks.GetKeyBundle(CreateSettings(secretName, settings));
            if (memberType == typeof(KeyVaultCertificate))
                return KeyVaultTasks.GetCertificateBundle(CreateSettings(secretName, settings));
            if (memberType == typeof(KeyVault))
                return KeyVaultTasks.LoadVault(CreateSettings(secretName, settings));

            var baseValue = base.GetValue(member, instance);
            if (baseValue != null)
                return baseValue;

            throw new NotSupportedException();
        }

        protected KeyVaultSettings GetSettings(object instance)
        {
            var fieldsWithAttributes = instance.GetType().GetFields(ReflectionUtility.Instance)
                .Select(x => new { Field = x, Attribute = x.GetCustomAttribute<KeyVaultSettingsAttribute>() })
                .Where(x => x.Attribute != null)
                .ToArray();

            Assert.NotEmpty(fieldsWithAttributes,
                "A field of the type KeyVaultSettings with the KeyVaultSettingsAttribute has to be defined in the build class when using Azure KeyVault");
            Assert.True(fieldsWithAttributes.Length == 1 || SettingFieldName != null,
                $"More than one KeyVaultSettings field defined. Specify explicitly via SettingFieldName");

            var fieldWithAttribute = fieldsWithAttributes.Length == 1
                ? fieldsWithAttributes.Single()
                : fieldsWithAttributes.SingleOrDefault(x => x.Field.Name == SettingFieldName)
                    .NotNull($"No field with the name '{SettingFieldName}' exists");

            return (KeyVaultSettings)fieldWithAttribute.Attribute.GetValue(fieldWithAttribute.Field, instance);
        }
    }
}

// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tools.AzureKeyVault
{
    /// <summary>Defines where the KeyVault login details can be found.</summary>
    [PublicAPI]
    public class AzureKeyVaultConfigurationAttribute : ValueInjectionAttributeBase
    {
        /// <summary><p>The base url of the Azure Key Vault. Either <see cref="BaseUrl"/> or <see cref="BaseUrlParameterName"/> must be set.</p></summary>
        public string BaseUrl { get; set; }

        /// <summary><p>Azure Tenant id.</p></summary>
        public string TenantId { get; set; }

        /// <summary><p>The client id of an AzureAd application with permissions for the required operations. Either <see cref="ClientId"/> or <see cref="ClientIdParameterName"/> must be set.</p></summary>
        public string ClientId { get; set; }

        /// <summary><p>The name of the parameter or environment variable which contains the base url to the Azure Key Vault. Either <see cref='BaseUrl'/> or  <see cref='BaseUrlParameterName'/> must be set.</p></summary>
        public string BaseUrlParameterName { get; set; }

        /// <summary><p>The name of the parameter or environment variable which contains the Azure Tenant id.</p></summary>
        public string TenantIdParameterName { get; set; }

        /// <summary><p>The name of the parameter or environment variable which contains the id of an AzureAd application with permissions for the required operations. Either <see cref='ClientId'/> or <see cref='ClientIdParameterName'/> must be set.</p></summary>
        public string ClientIdParameterName { get; set; }

        /// <summary><p>The name of the parameter or environment variable which contains the secret of the AzureAd application.</p></summary>
        public string ClientSecretParameterName { get; set; }

        [NotNull]
        public override object GetValue(MemberInfo member, object instance)
        {
            return new AzureKeyVaultConfiguration
                   {
                       BaseUrl = BaseUrl ?? EnvironmentInfo.GetParameter<string>(BaseUrlParameterName.NotNull("BaseUrlParameterName != null")),
                       TenantId = TenantId ?? EnvironmentInfo.GetParameter<string>(TenantIdParameterName.NotNull("TenantIdParameterName != null")),
                       ClientId = ClientId ?? EnvironmentInfo.GetParameter<string>(ClientIdParameterName.NotNull("ClientIdParameterName != null")),
                       ClientSecret = EnvironmentInfo.GetParameter<string>(ClientSecretParameterName.NotNull("ClientSecretParameterName != null"))
                   };
        }

        public AzureKeyVaultConfiguration GetValue(object instance)
        {
            return (AzureKeyVaultConfiguration) GetValue(member: null, instance);
        }
    }
}

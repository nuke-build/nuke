// Generated from https://github.com/arodus/nuke/blob/master/build/specifications/AzureKeyVault.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.AzureKeyVault
{
    #region AzureKeyVaultConfiguration
    /// <summary>
    ///   Used within <see cref="AzureKeyVaultTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class AzureKeyVaultConfiguration : ISettingsEntity
    {
        public virtual string TenantId { get; internal set; }
        public virtual string ClientId { get; internal set; }
        public virtual string ClientSecret { get; internal set; }
        public virtual string BaseUrl { get; internal set; }
    }
    #endregion
    #region AzureKeyVaultConfigurationExtensions
    /// <summary>
    ///   Used within <see cref="AzureKeyVaultTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class AzureKeyVaultConfigurationExtensions
    {
        #region TenantId
        /// <summary>
        ///   <p><em>Sets <see cref="AzureKeyVaultConfiguration.TenantId"/></em></p>
        /// </summary>
        [Pure]
        public static T SetTenantId<T>(this T toolSettings, string tenantId) where T : AzureKeyVaultConfiguration
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TenantId = tenantId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureKeyVaultConfiguration.TenantId"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetTenantId<T>(this T toolSettings) where T : AzureKeyVaultConfiguration
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TenantId = null;
            return toolSettings;
        }
        #endregion
        #region ClientId
        /// <summary>
        ///   <p><em>Sets <see cref="AzureKeyVaultConfiguration.ClientId"/></em></p>
        /// </summary>
        [Pure]
        public static T SetClientId<T>(this T toolSettings, string clientId) where T : AzureKeyVaultConfiguration
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientId = clientId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureKeyVaultConfiguration.ClientId"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetClientId<T>(this T toolSettings) where T : AzureKeyVaultConfiguration
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientId = null;
            return toolSettings;
        }
        #endregion
        #region ClientSecret
        /// <summary>
        ///   <p><em>Sets <see cref="AzureKeyVaultConfiguration.ClientSecret"/></em></p>
        /// </summary>
        [Pure]
        public static T SetClientSecret<T>(this T toolSettings, string clientSecret) where T : AzureKeyVaultConfiguration
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientSecret = clientSecret;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureKeyVaultConfiguration.ClientSecret"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetClientSecret<T>(this T toolSettings) where T : AzureKeyVaultConfiguration
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientSecret = null;
            return toolSettings;
        }
        #endregion
        #region BaseUrl
        /// <summary>
        ///   <p><em>Sets <see cref="AzureKeyVaultConfiguration.BaseUrl"/></em></p>
        /// </summary>
        [Pure]
        public static T SetBaseUrl<T>(this T toolSettings, string baseUrl) where T : AzureKeyVaultConfiguration
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseUrl = baseUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="AzureKeyVaultConfiguration.BaseUrl"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetBaseUrl<T>(this T toolSettings) where T : AzureKeyVaultConfiguration
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseUrl = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}

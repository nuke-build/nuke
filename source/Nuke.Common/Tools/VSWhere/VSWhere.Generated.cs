// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, Version: Local.
// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/VSWhere.json.

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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.VSWhere
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class VSWhereTasks
    {
        /// <summary><p>Path to the VSWhere executable.</p></summary>
        public static string VSWherePath => ToolPathResolver.GetPackageExecutable("vswhere", "vswhere.exe");
        /// <summary><p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p></summary>
        public static IReadOnlyCollection<Output> VSWhere(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(VSWherePath, arguments, workingDirectory, environmentVariables, timeout, logOutput, null, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p><p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p></summary>
        public static (List<VSWhereResult> Result, IReadOnlyCollection<Output> Output) VSWhere(Configure<VSWhereSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new VSWhereSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return (GetResult(process, toolSettings), process.Output);
        }
    }
    #region VSWhereSettings
    /// <summary><p>Used within <see cref="VSWhereTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class VSWhereSettings : ToolSettings
    {
        /// <summary><p>Path to the VSWhere executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? VSWhereTasks.VSWherePath;
        /// <summary><p> Return only the newest version and last installed.</p></summary>
        public virtual bool? Latest { get; internal set; }
        /// <summary><p>A version range for instances to find. Example: <c>[15.0,16.0)</c> will find versions <em>15.*</em>.</p></summary>
        public virtual VSWhereFormat Format { get; internal set; }
        /// <summary><p>Do not show logo information.</p></summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary><p>Use UTF-8 encoding (recommended for JSON).</p></summary>
        public virtual bool? UTF8 { get; internal set; }
        /// <summary><p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p></summary>
        public virtual bool? Legacy { get; internal set; }
        /// <summary><p>Finds all instances even if they are incomplete and may not launch.</p></summary>
        public virtual bool? All { get; internal set; }
        /// <summary><p>Also searches prereleases. By default, only releases are searched.</p></summary>
        public virtual bool? Prerelease { get; internal set; }
        /// <summary><p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p></summary>
        public virtual IReadOnlyList<string> Products => ProductsInternal.AsReadOnly();
        internal List<string> ProductsInternal { get; set; } = new List<string>();
        /// <summary><p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p></summary>
        public virtual IReadOnlyList<string> Requires => RequiresInternal.AsReadOnly();
        internal List<string> RequiresInternal { get; set; } = new List<string>();
        /// <summary><p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p></summary>
        public virtual bool? RequiresAny { get; internal set; }
        /// <summary><p>A version range for instances to find. Example: <c>[15.0,16.0)</c> will find versions <em>15.*</em>.</p></summary>
        public virtual string Version { get; internal set; }
        /// <summary><p>The name of a property to return. Use delimiters <c>'.'</c>, <c>'/'</c>, or <c>'_'</c> to separate object and property names. Example: <c>properties.nickname</c> will return the <em>nickname</em> property under <em>properties</em>.</p></summary>
        public virtual string Property { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-latest", Latest)
              .Add("-format {value}", Format)
              .Add("-nologo", NoLogo)
              .Add("-utf8", UTF8)
              .Add("-legacy", Legacy)
              .Add("-all", All)
              .Add("-prerelease", Prerelease)
              .Add("-products {value}", Products, separator: ' ')
              .Add("-requires {value}", Requires, separator: ' ')
              .Add("-requiresAny", RequiresAny)
              .Add("-version {value}", Version)
              .Add("-property {value}", Property);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region VSWhereCatalog
    /// <summary><p>Used within <see cref="VSWhereTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class VSWhereCatalog : ISettingsEntity
    {
        public virtual string BuildBranch { get; internal set; }
        public virtual string BuildVersion { get; internal set; }
        public virtual string Id { get; internal set; }
        public virtual string LocalBuild { get; internal set; }
        public virtual string ManifestName { get; internal set; }
        public virtual string ManifestType { get; internal set; }
        public virtual string ProductDisplayVersion { get; internal set; }
        public virtual string ProductLine { get; internal set; }
        public virtual string ProductLineVersion { get; internal set; }
        public virtual string ProductMilestone { get; internal set; }
        public virtual string ProductMilestoneIsPreRelease { get; internal set; }
        public virtual string ProductName { get; internal set; }
        public virtual string ProductPatchVersion { get; internal set; }
        public virtual string ProductPreReleaseMilestoneSuffix { get; internal set; }
        public virtual string ProductRelease { get; internal set; }
        public virtual string ProductSemanticVersion { get; internal set; }
        public virtual string RequiredEngineVersion { get; internal set; }
    }
    #endregion
    #region VSWhereResult
    /// <summary><p>Used within <see cref="VSWhereTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class VSWhereResult : ISettingsEntity
    {
        public virtual string InstanceId { get; internal set; }
        public virtual DateTime InstallDate { get; internal set; }
        public virtual string InstallationName { get; internal set; }
        public virtual string InstallationPath { get; internal set; }
        public virtual string InstallationVersion { get; internal set; }
        public virtual string ProductId { get; internal set; }
        public virtual string ProductPath { get; internal set; }
        public virtual bool? IsPreRelease { get; internal set; }
        public virtual string DisplayName { get; internal set; }
        public virtual string Description { get; internal set; }
        public virtual string ChannelId { get; internal set; }
        public virtual string ChannelUri { get; internal set; }
        public virtual string EnginePath { get; internal set; }
        public virtual string ReleaseNotes { get; internal set; }
        public virtual string ThirdPartyNotices { get; internal set; }
        public virtual DateTime UpdateDate { get; internal set; }
        public virtual VSWhereCatalog Catalog { get; internal set; }
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    }
    #endregion
    #region VSWhereSettingsExtensions
    /// <summary><p>Used within <see cref="VSWhereTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class VSWhereSettingsExtensions
    {
        #region Latest
        /// <summary><p><em>Sets <see cref="VSWhereSettings.Latest"/>.</em></p><p> Return only the newest version and last installed.</p></summary>
        [Pure]
        public static VSWhereSettings SetLatest(this VSWhereSettings toolSettings, bool? latest)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Latest = latest;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="VSWhereSettings.Latest"/>.</em></p><p> Return only the newest version and last installed.</p></summary>
        [Pure]
        public static VSWhereSettings ResetLatest(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Latest = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="VSWhereSettings.Latest"/>.</em></p><p> Return only the newest version and last installed.</p></summary>
        [Pure]
        public static VSWhereSettings EnableLatest(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Latest = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="VSWhereSettings.Latest"/>.</em></p><p> Return only the newest version and last installed.</p></summary>
        [Pure]
        public static VSWhereSettings DisableLatest(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Latest = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="VSWhereSettings.Latest"/>.</em></p><p> Return only the newest version and last installed.</p></summary>
        [Pure]
        public static VSWhereSettings ToggleLatest(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Latest = !toolSettings.Latest;
            return toolSettings;
        }
        #endregion
        #region Format
        /// <summary><p><em>Sets <see cref="VSWhereSettings.Format"/>.</em></p><p>A version range for instances to find. Example: <c>[15.0,16.0)</c> will find versions <em>15.*</em>.</p></summary>
        [Pure]
        public static VSWhereSettings SetFormat(this VSWhereSettings toolSettings, VSWhereFormat format)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = format;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="VSWhereSettings.Format"/>.</em></p><p>A version range for instances to find. Example: <c>[15.0,16.0)</c> will find versions <em>15.*</em>.</p></summary>
        [Pure]
        public static VSWhereSettings ResetFormat(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = null;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary><p><em>Sets <see cref="VSWhereSettings.NoLogo"/>.</em></p><p>Do not show logo information.</p></summary>
        [Pure]
        public static VSWhereSettings SetNoLogo(this VSWhereSettings toolSettings, bool? noLogo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="VSWhereSettings.NoLogo"/>.</em></p><p>Do not show logo information.</p></summary>
        [Pure]
        public static VSWhereSettings ResetNoLogo(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="VSWhereSettings.NoLogo"/>.</em></p><p>Do not show logo information.</p></summary>
        [Pure]
        public static VSWhereSettings EnableNoLogo(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="VSWhereSettings.NoLogo"/>.</em></p><p>Do not show logo information.</p></summary>
        [Pure]
        public static VSWhereSettings DisableNoLogo(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="VSWhereSettings.NoLogo"/>.</em></p><p>Do not show logo information.</p></summary>
        [Pure]
        public static VSWhereSettings ToggleNoLogo(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region UTF8
        /// <summary><p><em>Sets <see cref="VSWhereSettings.UTF8"/>.</em></p><p>Use UTF-8 encoding (recommended for JSON).</p></summary>
        [Pure]
        public static VSWhereSettings SetUTF8(this VSWhereSettings toolSettings, bool? utf8)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UTF8 = utf8;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="VSWhereSettings.UTF8"/>.</em></p><p>Use UTF-8 encoding (recommended for JSON).</p></summary>
        [Pure]
        public static VSWhereSettings ResetUTF8(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UTF8 = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="VSWhereSettings.UTF8"/>.</em></p><p>Use UTF-8 encoding (recommended for JSON).</p></summary>
        [Pure]
        public static VSWhereSettings EnableUTF8(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UTF8 = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="VSWhereSettings.UTF8"/>.</em></p><p>Use UTF-8 encoding (recommended for JSON).</p></summary>
        [Pure]
        public static VSWhereSettings DisableUTF8(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UTF8 = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="VSWhereSettings.UTF8"/>.</em></p><p>Use UTF-8 encoding (recommended for JSON).</p></summary>
        [Pure]
        public static VSWhereSettings ToggleUTF8(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UTF8 = !toolSettings.UTF8;
            return toolSettings;
        }
        #endregion
        #region Legacy
        /// <summary><p><em>Sets <see cref="VSWhereSettings.Legacy"/>.</em></p><p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p></summary>
        [Pure]
        public static VSWhereSettings SetLegacy(this VSWhereSettings toolSettings, bool? legacy)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Legacy = legacy;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="VSWhereSettings.Legacy"/>.</em></p><p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p></summary>
        [Pure]
        public static VSWhereSettings ResetLegacy(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Legacy = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="VSWhereSettings.Legacy"/>.</em></p><p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p></summary>
        [Pure]
        public static VSWhereSettings EnableLegacy(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Legacy = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="VSWhereSettings.Legacy"/>.</em></p><p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p></summary>
        [Pure]
        public static VSWhereSettings DisableLegacy(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Legacy = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="VSWhereSettings.Legacy"/>.</em></p><p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p></summary>
        [Pure]
        public static VSWhereSettings ToggleLegacy(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Legacy = !toolSettings.Legacy;
            return toolSettings;
        }
        #endregion
        #region All
        /// <summary><p><em>Sets <see cref="VSWhereSettings.All"/>.</em></p><p>Finds all instances even if they are incomplete and may not launch.</p></summary>
        [Pure]
        public static VSWhereSettings SetAll(this VSWhereSettings toolSettings, bool? all)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = all;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="VSWhereSettings.All"/>.</em></p><p>Finds all instances even if they are incomplete and may not launch.</p></summary>
        [Pure]
        public static VSWhereSettings ResetAll(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="VSWhereSettings.All"/>.</em></p><p>Finds all instances even if they are incomplete and may not launch.</p></summary>
        [Pure]
        public static VSWhereSettings EnableAll(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="VSWhereSettings.All"/>.</em></p><p>Finds all instances even if they are incomplete and may not launch.</p></summary>
        [Pure]
        public static VSWhereSettings DisableAll(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="VSWhereSettings.All"/>.</em></p><p>Finds all instances even if they are incomplete and may not launch.</p></summary>
        [Pure]
        public static VSWhereSettings ToggleAll(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = !toolSettings.All;
            return toolSettings;
        }
        #endregion
        #region Prerelease
        /// <summary><p><em>Sets <see cref="VSWhereSettings.Prerelease"/>.</em></p><p>Also searches prereleases. By default, only releases are searched.</p></summary>
        [Pure]
        public static VSWhereSettings SetPrerelease(this VSWhereSettings toolSettings, bool? prerelease)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = prerelease;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="VSWhereSettings.Prerelease"/>.</em></p><p>Also searches prereleases. By default, only releases are searched.</p></summary>
        [Pure]
        public static VSWhereSettings ResetPrerelease(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="VSWhereSettings.Prerelease"/>.</em></p><p>Also searches prereleases. By default, only releases are searched.</p></summary>
        [Pure]
        public static VSWhereSettings EnablePrerelease(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="VSWhereSettings.Prerelease"/>.</em></p><p>Also searches prereleases. By default, only releases are searched.</p></summary>
        [Pure]
        public static VSWhereSettings DisablePrerelease(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="VSWhereSettings.Prerelease"/>.</em></p><p>Also searches prereleases. By default, only releases are searched.</p></summary>
        [Pure]
        public static VSWhereSettings TogglePrerelease(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = !toolSettings.Prerelease;
            return toolSettings;
        }
        #endregion
        #region Products
        /// <summary><p><em>Sets <see cref="VSWhereSettings.Products"/> to a new list.</em></p><p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p></summary>
        [Pure]
        public static VSWhereSettings SetProducts(this VSWhereSettings toolSettings, params string[] products)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductsInternal = products.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="VSWhereSettings.Products"/> to a new list.</em></p><p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p></summary>
        [Pure]
        public static VSWhereSettings SetProducts(this VSWhereSettings toolSettings, IEnumerable<string> products)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductsInternal = products.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="VSWhereSettings.Products"/>.</em></p><p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p></summary>
        [Pure]
        public static VSWhereSettings AddProducts(this VSWhereSettings toolSettings, params string[] products)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductsInternal.AddRange(products);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="VSWhereSettings.Products"/>.</em></p><p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p></summary>
        [Pure]
        public static VSWhereSettings AddProducts(this VSWhereSettings toolSettings, IEnumerable<string> products)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductsInternal.AddRange(products);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="VSWhereSettings.Products"/>.</em></p><p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p></summary>
        [Pure]
        public static VSWhereSettings ClearProducts(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="VSWhereSettings.Products"/>.</em></p><p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p></summary>
        [Pure]
        public static VSWhereSettings RemoveProducts(this VSWhereSettings toolSettings, params string[] products)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(products);
            toolSettings.ProductsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="VSWhereSettings.Products"/>.</em></p><p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p></summary>
        [Pure]
        public static VSWhereSettings RemoveProducts(this VSWhereSettings toolSettings, IEnumerable<string> products)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(products);
            toolSettings.ProductsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Requires
        /// <summary><p><em>Sets <see cref="VSWhereSettings.Requires"/> to a new list.</em></p><p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p></summary>
        [Pure]
        public static VSWhereSettings SetRequires(this VSWhereSettings toolSettings, params string[] requires)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresInternal = requires.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="VSWhereSettings.Requires"/> to a new list.</em></p><p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p></summary>
        [Pure]
        public static VSWhereSettings SetRequires(this VSWhereSettings toolSettings, IEnumerable<string> requires)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresInternal = requires.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="VSWhereSettings.Requires"/>.</em></p><p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p></summary>
        [Pure]
        public static VSWhereSettings AddRequires(this VSWhereSettings toolSettings, params string[] requires)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresInternal.AddRange(requires);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="VSWhereSettings.Requires"/>.</em></p><p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p></summary>
        [Pure]
        public static VSWhereSettings AddRequires(this VSWhereSettings toolSettings, IEnumerable<string> requires)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresInternal.AddRange(requires);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="VSWhereSettings.Requires"/>.</em></p><p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p></summary>
        [Pure]
        public static VSWhereSettings ClearRequires(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="VSWhereSettings.Requires"/>.</em></p><p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p></summary>
        [Pure]
        public static VSWhereSettings RemoveRequires(this VSWhereSettings toolSettings, params string[] requires)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(requires);
            toolSettings.RequiresInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="VSWhereSettings.Requires"/>.</em></p><p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p></summary>
        [Pure]
        public static VSWhereSettings RemoveRequires(this VSWhereSettings toolSettings, IEnumerable<string> requires)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(requires);
            toolSettings.RequiresInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region RequiresAny
        /// <summary><p><em>Sets <see cref="VSWhereSettings.RequiresAny"/>.</em></p><p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p></summary>
        [Pure]
        public static VSWhereSettings SetRequiresAny(this VSWhereSettings toolSettings, bool? requiresAny)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresAny = requiresAny;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="VSWhereSettings.RequiresAny"/>.</em></p><p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p></summary>
        [Pure]
        public static VSWhereSettings ResetRequiresAny(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresAny = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="VSWhereSettings.RequiresAny"/>.</em></p><p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p></summary>
        [Pure]
        public static VSWhereSettings EnableRequiresAny(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresAny = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="VSWhereSettings.RequiresAny"/>.</em></p><p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p></summary>
        [Pure]
        public static VSWhereSettings DisableRequiresAny(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresAny = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="VSWhereSettings.RequiresAny"/>.</em></p><p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p></summary>
        [Pure]
        public static VSWhereSettings ToggleRequiresAny(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresAny = !toolSettings.RequiresAny;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary><p><em>Sets <see cref="VSWhereSettings.Version"/>.</em></p><p>A version range for instances to find. Example: <c>[15.0,16.0)</c> will find versions <em>15.*</em>.</p></summary>
        [Pure]
        public static VSWhereSettings SetVersion(this VSWhereSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="VSWhereSettings.Version"/>.</em></p><p>A version range for instances to find. Example: <c>[15.0,16.0)</c> will find versions <em>15.*</em>.</p></summary>
        [Pure]
        public static VSWhereSettings ResetVersion(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Property
        /// <summary><p><em>Sets <see cref="VSWhereSettings.Property"/>.</em></p><p>The name of a property to return. Use delimiters <c>'.'</c>, <c>'/'</c>, or <c>'_'</c> to separate object and property names. Example: <c>properties.nickname</c> will return the <em>nickname</em> property under <em>properties</em>.</p></summary>
        [Pure]
        public static VSWhereSettings SetProperty(this VSWhereSettings toolSettings, string property)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Property = property;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="VSWhereSettings.Property"/>.</em></p><p>The name of a property to return. Use delimiters <c>'.'</c>, <c>'/'</c>, or <c>'_'</c> to separate object and property names. Example: <c>properties.nickname</c> will return the <em>nickname</em> property under <em>properties</em>.</p></summary>
        [Pure]
        public static VSWhereSettings ResetProperty(this VSWhereSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Property = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region VSWhereFormat
    /// <summary><p>Used within <see cref="VSWhereTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public partial class VSWhereFormat : Enumeration
    {
        public static VSWhereFormat json = new VSWhereFormat { Value = "json" };
        public static VSWhereFormat text = new VSWhereFormat { Value = "text" };
        public static VSWhereFormat value = new VSWhereFormat { Value = "value" };
        public static VSWhereFormat xml = new VSWhereFormat { Value = "xml" };
    }
    #endregion
}

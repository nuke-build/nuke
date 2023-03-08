// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/VSWhere/VSWhere.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
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

namespace Nuke.Common.Tools.VSWhere
{
    /// <summary>
    ///   <p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p>
    ///   <p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(VSWherePackageId)]
    public partial class VSWhereTasks
        : IRequireNuGetPackage
    {
        public const string VSWherePackageId = "vswhere";
        /// <summary>
        ///   Path to the VSWhere executable.
        /// </summary>
        public static string VSWherePath =>
            ToolPathResolver.TryGetEnvironmentExecutable("VSWHERE_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("vswhere", "vswhere.exe");
        public static Action<OutputType, string> VSWhereLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> VSWhere(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(VSWherePath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? VSWhereLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-all</c> via <see cref="VSWhereSettings.All"/></li>
        ///     <li><c>-format</c> via <see cref="VSWhereSettings.Format"/></li>
        ///     <li><c>-latest</c> via <see cref="VSWhereSettings.Latest"/></li>
        ///     <li><c>-legacy</c> via <see cref="VSWhereSettings.Legacy"/></li>
        ///     <li><c>-nologo</c> via <see cref="VSWhereSettings.NoLogo"/></li>
        ///     <li><c>-prerelease</c> via <see cref="VSWhereSettings.Prerelease"/></li>
        ///     <li><c>-products</c> via <see cref="VSWhereSettings.Products"/></li>
        ///     <li><c>-property</c> via <see cref="VSWhereSettings.Property"/></li>
        ///     <li><c>-requires</c> via <see cref="VSWhereSettings.Requires"/></li>
        ///     <li><c>-requiresAny</c> via <see cref="VSWhereSettings.RequiresAny"/></li>
        ///     <li><c>-utf8</c> via <see cref="VSWhereSettings.UTF8"/></li>
        ///     <li><c>-version</c> via <see cref="VSWhereSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static (List<VSWhereResult> Result, IReadOnlyCollection<Output> Output) VSWhere(VSWhereSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new VSWhereSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return (GetResult(process, toolSettings), process.Output);
        }
        /// <summary>
        ///   <p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-all</c> via <see cref="VSWhereSettings.All"/></li>
        ///     <li><c>-format</c> via <see cref="VSWhereSettings.Format"/></li>
        ///     <li><c>-latest</c> via <see cref="VSWhereSettings.Latest"/></li>
        ///     <li><c>-legacy</c> via <see cref="VSWhereSettings.Legacy"/></li>
        ///     <li><c>-nologo</c> via <see cref="VSWhereSettings.NoLogo"/></li>
        ///     <li><c>-prerelease</c> via <see cref="VSWhereSettings.Prerelease"/></li>
        ///     <li><c>-products</c> via <see cref="VSWhereSettings.Products"/></li>
        ///     <li><c>-property</c> via <see cref="VSWhereSettings.Property"/></li>
        ///     <li><c>-requires</c> via <see cref="VSWhereSettings.Requires"/></li>
        ///     <li><c>-requiresAny</c> via <see cref="VSWhereSettings.RequiresAny"/></li>
        ///     <li><c>-utf8</c> via <see cref="VSWhereSettings.UTF8"/></li>
        ///     <li><c>-version</c> via <see cref="VSWhereSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static (List<VSWhereResult> Result, IReadOnlyCollection<Output> Output) VSWhere(Configure<VSWhereSettings> configurator)
        {
            return VSWhere(configurator(new VSWhereSettings()));
        }
        /// <summary>
        ///   <p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p>
        ///   <p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-all</c> via <see cref="VSWhereSettings.All"/></li>
        ///     <li><c>-format</c> via <see cref="VSWhereSettings.Format"/></li>
        ///     <li><c>-latest</c> via <see cref="VSWhereSettings.Latest"/></li>
        ///     <li><c>-legacy</c> via <see cref="VSWhereSettings.Legacy"/></li>
        ///     <li><c>-nologo</c> via <see cref="VSWhereSettings.NoLogo"/></li>
        ///     <li><c>-prerelease</c> via <see cref="VSWhereSettings.Prerelease"/></li>
        ///     <li><c>-products</c> via <see cref="VSWhereSettings.Products"/></li>
        ///     <li><c>-property</c> via <see cref="VSWhereSettings.Property"/></li>
        ///     <li><c>-requires</c> via <see cref="VSWhereSettings.Requires"/></li>
        ///     <li><c>-requiresAny</c> via <see cref="VSWhereSettings.RequiresAny"/></li>
        ///     <li><c>-utf8</c> via <see cref="VSWhereSettings.UTF8"/></li>
        ///     <li><c>-version</c> via <see cref="VSWhereSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(VSWhereSettings Settings, List<VSWhereResult> Result, IReadOnlyCollection<Output> Output)> VSWhere(CombinatorialConfigure<VSWhereSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(VSWhere, VSWhereLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region VSWhereSettings
    /// <summary>
    ///   Used within <see cref="VSWhereTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class VSWhereSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the VSWhere executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? VSWhereTasks.VSWherePath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? VSWhereTasks.VSWhereLogger;
        /// <summary>
        ///    Return only the newest version and last installed.
        /// </summary>
        public virtual bool? Latest { get; internal set; }
        /// <summary>
        ///   Return information about instances found in a format described below:<ul><li><c>text</c>: Colon-delimited properties in separate blocks for each instance (default).</li><li><c>json</c>: An array of JSON objects for each instance (no logo).</li><li><c>value</c>: A single property specified by the -property parameter (no logo).</li><li><c>xml</c>: An XML data set containing instances (no logo).</li></ul>
        /// </summary>
        public virtual VSWhereFormat Format { get; internal set; }
        /// <summary>
        ///   Do not show logo information.
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   Use UTF-8 encoding (recommended for JSON).
        /// </summary>
        public virtual bool? UTF8 { get; internal set; }
        /// <summary>
        ///   Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.
        /// </summary>
        public virtual bool? Legacy { get; internal set; }
        /// <summary>
        ///   Finds all instances even if they are incomplete and may not launch.
        /// </summary>
        public virtual bool? All { get; internal set; }
        /// <summary>
        ///   Also searches prereleases. By default, only releases are searched.
        /// </summary>
        public virtual bool? Prerelease { get; internal set; }
        /// <summary>
        ///   One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.
        /// </summary>
        public virtual IReadOnlyList<string> Products => ProductsInternal.AsReadOnly();
        internal List<string> ProductsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.
        /// </summary>
        public virtual IReadOnlyList<string> Requires => RequiresInternal.AsReadOnly();
        internal List<string> RequiresInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Find instances with any one or more workload or components IDs passed to <c>-requires</c>.
        /// </summary>
        public virtual bool? RequiresAny { get; internal set; }
        /// <summary>
        ///   A version range for instances to find. Example: <c>[15.0,16.0)</c> will find versions <em>15.*</em>.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The name of a property to return. Use delimiters <c>'.'</c>, <c>'/'</c>, or <c>'_'</c> to separate object and property names. Example: <c>properties.nickname</c> will return the <em>nickname</em> property under <em>properties</em>.
        /// </summary>
        public virtual string Property { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
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
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region VSWhereCatalog
    /// <summary>
    ///   Used within <see cref="VSWhereTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="VSWhereTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="VSWhereTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class VSWhereSettingsExtensions
    {
        #region Latest
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.Latest"/></em></p>
        ///   <p> Return only the newest version and last installed.</p>
        /// </summary>
        [Pure]
        public static T SetLatest<T>(this T toolSettings, bool? latest) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Latest = latest;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="VSWhereSettings.Latest"/></em></p>
        ///   <p> Return only the newest version and last installed.</p>
        /// </summary>
        [Pure]
        public static T ResetLatest<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Latest = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="VSWhereSettings.Latest"/></em></p>
        ///   <p> Return only the newest version and last installed.</p>
        /// </summary>
        [Pure]
        public static T EnableLatest<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Latest = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="VSWhereSettings.Latest"/></em></p>
        ///   <p> Return only the newest version and last installed.</p>
        /// </summary>
        [Pure]
        public static T DisableLatest<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Latest = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="VSWhereSettings.Latest"/></em></p>
        ///   <p> Return only the newest version and last installed.</p>
        /// </summary>
        [Pure]
        public static T ToggleLatest<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Latest = !toolSettings.Latest;
            return toolSettings;
        }
        #endregion
        #region Format
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.Format"/></em></p>
        ///   <p>Return information about instances found in a format described below:<ul><li><c>text</c>: Colon-delimited properties in separate blocks for each instance (default).</li><li><c>json</c>: An array of JSON objects for each instance (no logo).</li><li><c>value</c>: A single property specified by the -property parameter (no logo).</li><li><c>xml</c>: An XML data set containing instances (no logo).</li></ul></p>
        /// </summary>
        [Pure]
        public static T SetFormat<T>(this T toolSettings, VSWhereFormat format) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = format;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="VSWhereSettings.Format"/></em></p>
        ///   <p>Return information about instances found in a format described below:<ul><li><c>text</c>: Colon-delimited properties in separate blocks for each instance (default).</li><li><c>json</c>: An array of JSON objects for each instance (no logo).</li><li><c>value</c>: A single property specified by the -property parameter (no logo).</li><li><c>xml</c>: An XML data set containing instances (no logo).</li></ul></p>
        /// </summary>
        [Pure]
        public static T ResetFormat<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = null;
            return toolSettings;
        }
        #endregion
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.NoLogo"/></em></p>
        ///   <p>Do not show logo information.</p>
        /// </summary>
        [Pure]
        public static T SetNoLogo<T>(this T toolSettings, bool? noLogo) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="VSWhereSettings.NoLogo"/></em></p>
        ///   <p>Do not show logo information.</p>
        /// </summary>
        [Pure]
        public static T ResetNoLogo<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="VSWhereSettings.NoLogo"/></em></p>
        ///   <p>Do not show logo information.</p>
        /// </summary>
        [Pure]
        public static T EnableNoLogo<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="VSWhereSettings.NoLogo"/></em></p>
        ///   <p>Do not show logo information.</p>
        /// </summary>
        [Pure]
        public static T DisableNoLogo<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="VSWhereSettings.NoLogo"/></em></p>
        ///   <p>Do not show logo information.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoLogo<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region UTF8
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.UTF8"/></em></p>
        ///   <p>Use UTF-8 encoding (recommended for JSON).</p>
        /// </summary>
        [Pure]
        public static T SetUTF8<T>(this T toolSettings, bool? utf8) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UTF8 = utf8;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="VSWhereSettings.UTF8"/></em></p>
        ///   <p>Use UTF-8 encoding (recommended for JSON).</p>
        /// </summary>
        [Pure]
        public static T ResetUTF8<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UTF8 = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="VSWhereSettings.UTF8"/></em></p>
        ///   <p>Use UTF-8 encoding (recommended for JSON).</p>
        /// </summary>
        [Pure]
        public static T EnableUTF8<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UTF8 = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="VSWhereSettings.UTF8"/></em></p>
        ///   <p>Use UTF-8 encoding (recommended for JSON).</p>
        /// </summary>
        [Pure]
        public static T DisableUTF8<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UTF8 = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="VSWhereSettings.UTF8"/></em></p>
        ///   <p>Use UTF-8 encoding (recommended for JSON).</p>
        /// </summary>
        [Pure]
        public static T ToggleUTF8<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UTF8 = !toolSettings.UTF8;
            return toolSettings;
        }
        #endregion
        #region Legacy
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.Legacy"/></em></p>
        ///   <p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p>
        /// </summary>
        [Pure]
        public static T SetLegacy<T>(this T toolSettings, bool? legacy) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Legacy = legacy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="VSWhereSettings.Legacy"/></em></p>
        ///   <p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetLegacy<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Legacy = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="VSWhereSettings.Legacy"/></em></p>
        ///   <p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableLegacy<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Legacy = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="VSWhereSettings.Legacy"/></em></p>
        ///   <p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableLegacy<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Legacy = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="VSWhereSettings.Legacy"/></em></p>
        ///   <p>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleLegacy<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Legacy = !toolSettings.Legacy;
            return toolSettings;
        }
        #endregion
        #region All
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.All"/></em></p>
        ///   <p>Finds all instances even if they are incomplete and may not launch.</p>
        /// </summary>
        [Pure]
        public static T SetAll<T>(this T toolSettings, bool? all) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = all;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="VSWhereSettings.All"/></em></p>
        ///   <p>Finds all instances even if they are incomplete and may not launch.</p>
        /// </summary>
        [Pure]
        public static T ResetAll<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="VSWhereSettings.All"/></em></p>
        ///   <p>Finds all instances even if they are incomplete and may not launch.</p>
        /// </summary>
        [Pure]
        public static T EnableAll<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="VSWhereSettings.All"/></em></p>
        ///   <p>Finds all instances even if they are incomplete and may not launch.</p>
        /// </summary>
        [Pure]
        public static T DisableAll<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="VSWhereSettings.All"/></em></p>
        ///   <p>Finds all instances even if they are incomplete and may not launch.</p>
        /// </summary>
        [Pure]
        public static T ToggleAll<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = !toolSettings.All;
            return toolSettings;
        }
        #endregion
        #region Prerelease
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.Prerelease"/></em></p>
        ///   <p>Also searches prereleases. By default, only releases are searched.</p>
        /// </summary>
        [Pure]
        public static T SetPrerelease<T>(this T toolSettings, bool? prerelease) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = prerelease;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="VSWhereSettings.Prerelease"/></em></p>
        ///   <p>Also searches prereleases. By default, only releases are searched.</p>
        /// </summary>
        [Pure]
        public static T ResetPrerelease<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="VSWhereSettings.Prerelease"/></em></p>
        ///   <p>Also searches prereleases. By default, only releases are searched.</p>
        /// </summary>
        [Pure]
        public static T EnablePrerelease<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="VSWhereSettings.Prerelease"/></em></p>
        ///   <p>Also searches prereleases. By default, only releases are searched.</p>
        /// </summary>
        [Pure]
        public static T DisablePrerelease<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="VSWhereSettings.Prerelease"/></em></p>
        ///   <p>Also searches prereleases. By default, only releases are searched.</p>
        /// </summary>
        [Pure]
        public static T TogglePrerelease<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prerelease = !toolSettings.Prerelease;
            return toolSettings;
        }
        #endregion
        #region Products
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.Products"/> to a new list</em></p>
        ///   <p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p>
        /// </summary>
        [Pure]
        public static T SetProducts<T>(this T toolSettings, params string[] products) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductsInternal = products.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.Products"/> to a new list</em></p>
        ///   <p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p>
        /// </summary>
        [Pure]
        public static T SetProducts<T>(this T toolSettings, IEnumerable<string> products) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductsInternal = products.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="VSWhereSettings.Products"/></em></p>
        ///   <p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p>
        /// </summary>
        [Pure]
        public static T AddProducts<T>(this T toolSettings, params string[] products) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductsInternal.AddRange(products);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="VSWhereSettings.Products"/></em></p>
        ///   <p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p>
        /// </summary>
        [Pure]
        public static T AddProducts<T>(this T toolSettings, IEnumerable<string> products) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductsInternal.AddRange(products);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="VSWhereSettings.Products"/></em></p>
        ///   <p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p>
        /// </summary>
        [Pure]
        public static T ClearProducts<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProductsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="VSWhereSettings.Products"/></em></p>
        ///   <p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p>
        /// </summary>
        [Pure]
        public static T RemoveProducts<T>(this T toolSettings, params string[] products) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(products);
            toolSettings.ProductsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="VSWhereSettings.Products"/></em></p>
        ///   <p>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</p>
        /// </summary>
        [Pure]
        public static T RemoveProducts<T>(this T toolSettings, IEnumerable<string> products) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(products);
            toolSettings.ProductsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Requires
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.Requires"/> to a new list</em></p>
        ///   <p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p>
        /// </summary>
        [Pure]
        public static T SetRequires<T>(this T toolSettings, params string[] requires) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresInternal = requires.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.Requires"/> to a new list</em></p>
        ///   <p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p>
        /// </summary>
        [Pure]
        public static T SetRequires<T>(this T toolSettings, IEnumerable<string> requires) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresInternal = requires.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="VSWhereSettings.Requires"/></em></p>
        ///   <p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p>
        /// </summary>
        [Pure]
        public static T AddRequires<T>(this T toolSettings, params string[] requires) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresInternal.AddRange(requires);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="VSWhereSettings.Requires"/></em></p>
        ///   <p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p>
        /// </summary>
        [Pure]
        public static T AddRequires<T>(this T toolSettings, IEnumerable<string> requires) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresInternal.AddRange(requires);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="VSWhereSettings.Requires"/></em></p>
        ///   <p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p>
        /// </summary>
        [Pure]
        public static T ClearRequires<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="VSWhereSettings.Requires"/></em></p>
        ///   <p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p>
        /// </summary>
        [Pure]
        public static T RemoveRequires<T>(this T toolSettings, params string[] requires) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(requires);
            toolSettings.RequiresInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="VSWhereSettings.Requires"/></em></p>
        ///   <p>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</p>
        /// </summary>
        [Pure]
        public static T RemoveRequires<T>(this T toolSettings, IEnumerable<string> requires) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(requires);
            toolSettings.RequiresInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region RequiresAny
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.RequiresAny"/></em></p>
        ///   <p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p>
        /// </summary>
        [Pure]
        public static T SetRequiresAny<T>(this T toolSettings, bool? requiresAny) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresAny = requiresAny;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="VSWhereSettings.RequiresAny"/></em></p>
        ///   <p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetRequiresAny<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresAny = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="VSWhereSettings.RequiresAny"/></em></p>
        ///   <p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableRequiresAny<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresAny = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="VSWhereSettings.RequiresAny"/></em></p>
        ///   <p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableRequiresAny<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresAny = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="VSWhereSettings.RequiresAny"/></em></p>
        ///   <p>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleRequiresAny<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequiresAny = !toolSettings.RequiresAny;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.Version"/></em></p>
        ///   <p>A version range for instances to find. Example: <c>[15.0,16.0)</c> will find versions <em>15.*</em>.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="VSWhereSettings.Version"/></em></p>
        ///   <p>A version range for instances to find. Example: <c>[15.0,16.0)</c> will find versions <em>15.*</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Property
        /// <summary>
        ///   <p><em>Sets <see cref="VSWhereSettings.Property"/></em></p>
        ///   <p>The name of a property to return. Use delimiters <c>'.'</c>, <c>'/'</c>, or <c>'_'</c> to separate object and property names. Example: <c>properties.nickname</c> will return the <em>nickname</em> property under <em>properties</em>.</p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string property) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Property = property;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="VSWhereSettings.Property"/></em></p>
        ///   <p>The name of a property to return. Use delimiters <c>'.'</c>, <c>'/'</c>, or <c>'_'</c> to separate object and property names. Example: <c>properties.nickname</c> will return the <em>nickname</em> property under <em>properties</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetProperty<T>(this T toolSettings) where T : VSWhereSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Property = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region VSWhereFormat
    /// <summary>
    ///   Used within <see cref="VSWhereTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<VSWhereFormat>))]
    public partial class VSWhereFormat : Enumeration
    {
        public static VSWhereFormat json = (VSWhereFormat) "json";
        public static VSWhereFormat text = (VSWhereFormat) "text";
        public static VSWhereFormat value = (VSWhereFormat) "value";
        public static VSWhereFormat xml = (VSWhereFormat) "xml";
        public static implicit operator VSWhereFormat(string value)
        {
            return new VSWhereFormat { Value = value };
        }
    }
    #endregion
}

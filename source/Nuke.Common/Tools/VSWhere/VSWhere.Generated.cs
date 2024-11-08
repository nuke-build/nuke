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

namespace Nuke.Common.Tools.VSWhere;

/// <summary><p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p><p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class VSWhereTasks : ToolTasks, IRequireNuGetPackage
{
    public static string VSWherePath => new VSWhereTasks().GetToolPath();
    public const string PackageId = "vswhere";
    public const string PackageExecutable = "vswhere.exe";
    /// <summary><p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p><p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> VSWhere(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new VSWhereTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p><p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-all</c> via <see cref="VSWhereSettings.All"/></li><li><c>-format</c> via <see cref="VSWhereSettings.Format"/></li><li><c>-latest</c> via <see cref="VSWhereSettings.Latest"/></li><li><c>-legacy</c> via <see cref="VSWhereSettings.Legacy"/></li><li><c>-nologo</c> via <see cref="VSWhereSettings.NoLogo"/></li><li><c>-prerelease</c> via <see cref="VSWhereSettings.Prerelease"/></li><li><c>-products</c> via <see cref="VSWhereSettings.Products"/></li><li><c>-property</c> via <see cref="VSWhereSettings.Property"/></li><li><c>-requires</c> via <see cref="VSWhereSettings.Requires"/></li><li><c>-requiresAny</c> via <see cref="VSWhereSettings.RequiresAny"/></li><li><c>-utf8</c> via <see cref="VSWhereSettings.UTF8"/></li><li><c>-version</c> via <see cref="VSWhereSettings.Version"/></li></ul></remarks>
    public static (List<VSWhereResult> Result, IReadOnlyCollection<Output> Output) VSWhere(VSWhereSettings options = null) => new VSWhereTasks().Run<List<VSWhereResult>>(options);
    /// <summary><p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p><p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-all</c> via <see cref="VSWhereSettings.All"/></li><li><c>-format</c> via <see cref="VSWhereSettings.Format"/></li><li><c>-latest</c> via <see cref="VSWhereSettings.Latest"/></li><li><c>-legacy</c> via <see cref="VSWhereSettings.Legacy"/></li><li><c>-nologo</c> via <see cref="VSWhereSettings.NoLogo"/></li><li><c>-prerelease</c> via <see cref="VSWhereSettings.Prerelease"/></li><li><c>-products</c> via <see cref="VSWhereSettings.Products"/></li><li><c>-property</c> via <see cref="VSWhereSettings.Property"/></li><li><c>-requires</c> via <see cref="VSWhereSettings.Requires"/></li><li><c>-requiresAny</c> via <see cref="VSWhereSettings.RequiresAny"/></li><li><c>-utf8</c> via <see cref="VSWhereSettings.UTF8"/></li><li><c>-version</c> via <see cref="VSWhereSettings.Version"/></li></ul></remarks>
    public static (List<VSWhereResult> Result, IReadOnlyCollection<Output> Output) VSWhere(Configure<VSWhereSettings> configurator) => new VSWhereTasks().Run<List<VSWhereResult>>(configurator.Invoke(new VSWhereSettings()));
    /// <summary><p>VSWhere is designed to be a redistributable, single-file executable that can be used in build or deployment scripts to find where Visual Studio - or other products in the Visual Studio family - is located.</p><p>For more details, visit the <a href="https://github.com/Microsoft/vswhere">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-all</c> via <see cref="VSWhereSettings.All"/></li><li><c>-format</c> via <see cref="VSWhereSettings.Format"/></li><li><c>-latest</c> via <see cref="VSWhereSettings.Latest"/></li><li><c>-legacy</c> via <see cref="VSWhereSettings.Legacy"/></li><li><c>-nologo</c> via <see cref="VSWhereSettings.NoLogo"/></li><li><c>-prerelease</c> via <see cref="VSWhereSettings.Prerelease"/></li><li><c>-products</c> via <see cref="VSWhereSettings.Products"/></li><li><c>-property</c> via <see cref="VSWhereSettings.Property"/></li><li><c>-requires</c> via <see cref="VSWhereSettings.Requires"/></li><li><c>-requiresAny</c> via <see cref="VSWhereSettings.RequiresAny"/></li><li><c>-utf8</c> via <see cref="VSWhereSettings.UTF8"/></li><li><c>-version</c> via <see cref="VSWhereSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(VSWhereSettings Settings, List<VSWhereResult> Result, IReadOnlyCollection<Output> Output)> VSWhere(CombinatorialConfigure<VSWhereSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(VSWhere, degreeOfParallelism, completeOnFailure);
}
#region VSWhereSettings
/// <summary>Used within <see cref="VSWhereTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<VSWhereSettings>))]
[Command(Type = typeof(VSWhereTasks), Command = nameof(VSWhereTasks.VSWhere))]
public partial class VSWhereSettings : ToolOptions
{
    /// <summary> Return only the newest version and last installed.</summary>
    [Argument(Format = "-latest")] public bool? Latest => Get<bool?>(() => Latest);
    /// <summary>Return information about instances found in a format described below:<ul><li><c>text</c>: Colon-delimited properties in separate blocks for each instance (default).</li><li><c>json</c>: An array of JSON objects for each instance (no logo).</li><li><c>value</c>: A single property specified by the -property parameter (no logo).</li><li><c>xml</c>: An XML data set containing instances (no logo).</li></ul></summary>
    [Argument(Format = "-format {value}")] public VSWhereFormat Format => Get<VSWhereFormat>(() => Format);
    /// <summary>Do not show logo information.</summary>
    [Argument(Format = "-nologo")] public bool? NoLogo => Get<bool?>(() => NoLogo);
    /// <summary>Use UTF-8 encoding (recommended for JSON).</summary>
    [Argument(Format = "-utf8")] public bool? UTF8 => Get<bool?>(() => UTF8);
    /// <summary>Also searches Visual Studio 2015 and older products. Information is limited. This option cannot be used with either <c>-products</c> or <c>-requires</c>.</summary>
    [Argument(Format = "-legacy")] public bool? Legacy => Get<bool?>(() => Legacy);
    /// <summary>Finds all instances even if they are incomplete and may not launch.</summary>
    [Argument(Format = "-all")] public bool? All => Get<bool?>(() => All);
    /// <summary>Also searches prereleases. By default, only releases are searched.</summary>
    [Argument(Format = "-prerelease")] public bool? Prerelease => Get<bool?>(() => Prerelease);
    /// <summary>One or more product IDs to find. Defaults to Community, Professional, and Enterprise. Specify <em>*</em> by itself to search all product instances installed.</summary>
    [Argument(Format = "-products {value}", Separator = " ")] public IReadOnlyList<string> Products => Get<List<string>>(() => Products);
    /// <summary>One or more workload or component IDs required when finding instances. All specified IDs must be installed unless -requiresAny is specified. See <a href="https://aka.ms/vs/workloads"/> for a list of workload and component IDs.</summary>
    [Argument(Format = "-requires {value}", Separator = " ")] public IReadOnlyList<string> Requires => Get<List<string>>(() => Requires);
    /// <summary>Find instances with any one or more workload or components IDs passed to <c>-requires</c>.</summary>
    [Argument(Format = "-requiresAny")] public bool? RequiresAny => Get<bool?>(() => RequiresAny);
    /// <summary>A version range for instances to find. Example: <c>[15.0,16.0)</c> will find versions <em>15.*</em>.</summary>
    [Argument(Format = "-version {value}")] public string Version => Get<string>(() => Version);
    /// <summary>The name of a property to return. Use delimiters <c>'.'</c>, <c>'/'</c>, or <c>'_'</c> to separate object and property names. Example: <c>properties.nickname</c> will return the <em>nickname</em> property under <em>properties</em>.</summary>
    [Argument(Format = "-property {value}")] public string Property => Get<string>(() => Property);
}
#endregion
#region VSWhereCatalog
/// <summary>Used within <see cref="VSWhereTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<VSWhereCatalog>))]
public partial class VSWhereCatalog : Options
{
    /// <summary></summary>
    public string BuildBranch => Get<string>(() => BuildBranch);
    /// <summary></summary>
    public string BuildVersion => Get<string>(() => BuildVersion);
    /// <summary></summary>
    public string Id => Get<string>(() => Id);
    /// <summary></summary>
    public string LocalBuild => Get<string>(() => LocalBuild);
    /// <summary></summary>
    public string ManifestName => Get<string>(() => ManifestName);
    /// <summary></summary>
    public string ManifestType => Get<string>(() => ManifestType);
    /// <summary></summary>
    public string ProductDisplayVersion => Get<string>(() => ProductDisplayVersion);
    /// <summary></summary>
    public string ProductLine => Get<string>(() => ProductLine);
    /// <summary></summary>
    public string ProductLineVersion => Get<string>(() => ProductLineVersion);
    /// <summary></summary>
    public string ProductMilestone => Get<string>(() => ProductMilestone);
    /// <summary></summary>
    public string ProductMilestoneIsPreRelease => Get<string>(() => ProductMilestoneIsPreRelease);
    /// <summary></summary>
    public string ProductName => Get<string>(() => ProductName);
    /// <summary></summary>
    public string ProductPatchVersion => Get<string>(() => ProductPatchVersion);
    /// <summary></summary>
    public string ProductPreReleaseMilestoneSuffix => Get<string>(() => ProductPreReleaseMilestoneSuffix);
    /// <summary></summary>
    public string ProductRelease => Get<string>(() => ProductRelease);
    /// <summary></summary>
    public string ProductSemanticVersion => Get<string>(() => ProductSemanticVersion);
    /// <summary></summary>
    public string RequiredEngineVersion => Get<string>(() => RequiredEngineVersion);
}
#endregion
#region VSWhereResult
/// <summary>Used within <see cref="VSWhereTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<VSWhereResult>))]
public partial class VSWhereResult : Options
{
    /// <summary></summary>
    public string InstanceId => Get<string>(() => InstanceId);
    /// <summary></summary>
    public DateTime InstallDate => Get<DateTime>(() => InstallDate);
    /// <summary></summary>
    public string InstallationName => Get<string>(() => InstallationName);
    /// <summary></summary>
    public string InstallationPath => Get<string>(() => InstallationPath);
    /// <summary></summary>
    public string InstallationVersion => Get<string>(() => InstallationVersion);
    /// <summary></summary>
    public string ProductId => Get<string>(() => ProductId);
    /// <summary></summary>
    public string ProductPath => Get<string>(() => ProductPath);
    /// <summary></summary>
    public bool? IsPreRelease => Get<bool?>(() => IsPreRelease);
    /// <summary></summary>
    public string DisplayName => Get<string>(() => DisplayName);
    /// <summary></summary>
    public string Description => Get<string>(() => Description);
    /// <summary></summary>
    public string ChannelId => Get<string>(() => ChannelId);
    /// <summary></summary>
    public string ChannelUri => Get<string>(() => ChannelUri);
    /// <summary></summary>
    public string EnginePath => Get<string>(() => EnginePath);
    /// <summary></summary>
    public string ReleaseNotes => Get<string>(() => ReleaseNotes);
    /// <summary></summary>
    public string ThirdPartyNotices => Get<string>(() => ThirdPartyNotices);
    /// <summary></summary>
    public DateTime UpdateDate => Get<DateTime>(() => UpdateDate);
    /// <summary></summary>
    public VSWhereCatalog Catalog => Get<VSWhereCatalog>(() => Catalog);
    /// <summary></summary>
    public IReadOnlyDictionary<string, object> Properties => Get<Dictionary<string, object>>(() => Properties);
}
#endregion
#region VSWhereSettingsExtensions
/// <summary>Used within <see cref="VSWhereTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class VSWhereSettingsExtensions
{
    #region Latest
    /// <inheritdoc cref="VSWhereSettings.Latest"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Latest))]
    public static T SetLatest<T>(this T o, bool? v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Latest, v));
    /// <inheritdoc cref="VSWhereSettings.Latest"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Latest))]
    public static T ResetLatest<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Remove(() => o.Latest));
    /// <inheritdoc cref="VSWhereSettings.Latest"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Latest))]
    public static T EnableLatest<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Latest, true));
    /// <inheritdoc cref="VSWhereSettings.Latest"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Latest))]
    public static T DisableLatest<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Latest, false));
    /// <inheritdoc cref="VSWhereSettings.Latest"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Latest))]
    public static T ToggleLatest<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Latest, !o.Latest));
    #endregion
    #region Format
    /// <inheritdoc cref="VSWhereSettings.Format"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Format))]
    public static T SetFormat<T>(this T o, VSWhereFormat v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Format, v));
    /// <inheritdoc cref="VSWhereSettings.Format"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Format))]
    public static T ResetFormat<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Remove(() => o.Format));
    #endregion
    #region NoLogo
    /// <inheritdoc cref="VSWhereSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.NoLogo))]
    public static T SetNoLogo<T>(this T o, bool? v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.NoLogo, v));
    /// <inheritdoc cref="VSWhereSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.NoLogo))]
    public static T ResetNoLogo<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Remove(() => o.NoLogo));
    /// <inheritdoc cref="VSWhereSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.NoLogo))]
    public static T EnableNoLogo<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.NoLogo, true));
    /// <inheritdoc cref="VSWhereSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.NoLogo))]
    public static T DisableNoLogo<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.NoLogo, false));
    /// <inheritdoc cref="VSWhereSettings.NoLogo"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.NoLogo))]
    public static T ToggleNoLogo<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.NoLogo, !o.NoLogo));
    #endregion
    #region UTF8
    /// <inheritdoc cref="VSWhereSettings.UTF8"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.UTF8))]
    public static T SetUTF8<T>(this T o, bool? v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.UTF8, v));
    /// <inheritdoc cref="VSWhereSettings.UTF8"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.UTF8))]
    public static T ResetUTF8<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Remove(() => o.UTF8));
    /// <inheritdoc cref="VSWhereSettings.UTF8"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.UTF8))]
    public static T EnableUTF8<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.UTF8, true));
    /// <inheritdoc cref="VSWhereSettings.UTF8"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.UTF8))]
    public static T DisableUTF8<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.UTF8, false));
    /// <inheritdoc cref="VSWhereSettings.UTF8"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.UTF8))]
    public static T ToggleUTF8<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.UTF8, !o.UTF8));
    #endregion
    #region Legacy
    /// <inheritdoc cref="VSWhereSettings.Legacy"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Legacy))]
    public static T SetLegacy<T>(this T o, bool? v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Legacy, v));
    /// <inheritdoc cref="VSWhereSettings.Legacy"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Legacy))]
    public static T ResetLegacy<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Remove(() => o.Legacy));
    /// <inheritdoc cref="VSWhereSettings.Legacy"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Legacy))]
    public static T EnableLegacy<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Legacy, true));
    /// <inheritdoc cref="VSWhereSettings.Legacy"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Legacy))]
    public static T DisableLegacy<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Legacy, false));
    /// <inheritdoc cref="VSWhereSettings.Legacy"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Legacy))]
    public static T ToggleLegacy<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Legacy, !o.Legacy));
    #endregion
    #region All
    /// <inheritdoc cref="VSWhereSettings.All"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.All))]
    public static T SetAll<T>(this T o, bool? v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.All, v));
    /// <inheritdoc cref="VSWhereSettings.All"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.All))]
    public static T ResetAll<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Remove(() => o.All));
    /// <inheritdoc cref="VSWhereSettings.All"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.All))]
    public static T EnableAll<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.All, true));
    /// <inheritdoc cref="VSWhereSettings.All"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.All))]
    public static T DisableAll<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.All, false));
    /// <inheritdoc cref="VSWhereSettings.All"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.All))]
    public static T ToggleAll<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.All, !o.All));
    #endregion
    #region Prerelease
    /// <inheritdoc cref="VSWhereSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Prerelease))]
    public static T SetPrerelease<T>(this T o, bool? v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Prerelease, v));
    /// <inheritdoc cref="VSWhereSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Prerelease))]
    public static T ResetPrerelease<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Remove(() => o.Prerelease));
    /// <inheritdoc cref="VSWhereSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Prerelease))]
    public static T EnablePrerelease<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Prerelease, true));
    /// <inheritdoc cref="VSWhereSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Prerelease))]
    public static T DisablePrerelease<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Prerelease, false));
    /// <inheritdoc cref="VSWhereSettings.Prerelease"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Prerelease))]
    public static T TogglePrerelease<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Prerelease, !o.Prerelease));
    #endregion
    #region Products
    /// <inheritdoc cref="VSWhereSettings.Products"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Products))]
    public static T SetProducts<T>(this T o, params string[] v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Products, v));
    /// <inheritdoc cref="VSWhereSettings.Products"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Products))]
    public static T SetProducts<T>(this T o, IEnumerable<string> v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Products, v));
    /// <inheritdoc cref="VSWhereSettings.Products"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Products))]
    public static T AddProducts<T>(this T o, params string[] v) where T : VSWhereSettings => o.Modify(b => b.AddCollection(() => o.Products, v));
    /// <inheritdoc cref="VSWhereSettings.Products"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Products))]
    public static T AddProducts<T>(this T o, IEnumerable<string> v) where T : VSWhereSettings => o.Modify(b => b.AddCollection(() => o.Products, v));
    /// <inheritdoc cref="VSWhereSettings.Products"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Products))]
    public static T RemoveProducts<T>(this T o, params string[] v) where T : VSWhereSettings => o.Modify(b => b.RemoveCollection(() => o.Products, v));
    /// <inheritdoc cref="VSWhereSettings.Products"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Products))]
    public static T RemoveProducts<T>(this T o, IEnumerable<string> v) where T : VSWhereSettings => o.Modify(b => b.RemoveCollection(() => o.Products, v));
    /// <inheritdoc cref="VSWhereSettings.Products"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Products))]
    public static T ClearProducts<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.ClearCollection(() => o.Products));
    #endregion
    #region Requires
    /// <inheritdoc cref="VSWhereSettings.Requires"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Requires))]
    public static T SetRequires<T>(this T o, params string[] v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Requires, v));
    /// <inheritdoc cref="VSWhereSettings.Requires"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Requires))]
    public static T SetRequires<T>(this T o, IEnumerable<string> v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Requires, v));
    /// <inheritdoc cref="VSWhereSettings.Requires"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Requires))]
    public static T AddRequires<T>(this T o, params string[] v) where T : VSWhereSettings => o.Modify(b => b.AddCollection(() => o.Requires, v));
    /// <inheritdoc cref="VSWhereSettings.Requires"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Requires))]
    public static T AddRequires<T>(this T o, IEnumerable<string> v) where T : VSWhereSettings => o.Modify(b => b.AddCollection(() => o.Requires, v));
    /// <inheritdoc cref="VSWhereSettings.Requires"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Requires))]
    public static T RemoveRequires<T>(this T o, params string[] v) where T : VSWhereSettings => o.Modify(b => b.RemoveCollection(() => o.Requires, v));
    /// <inheritdoc cref="VSWhereSettings.Requires"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Requires))]
    public static T RemoveRequires<T>(this T o, IEnumerable<string> v) where T : VSWhereSettings => o.Modify(b => b.RemoveCollection(() => o.Requires, v));
    /// <inheritdoc cref="VSWhereSettings.Requires"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Requires))]
    public static T ClearRequires<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.ClearCollection(() => o.Requires));
    #endregion
    #region RequiresAny
    /// <inheritdoc cref="VSWhereSettings.RequiresAny"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.RequiresAny))]
    public static T SetRequiresAny<T>(this T o, bool? v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.RequiresAny, v));
    /// <inheritdoc cref="VSWhereSettings.RequiresAny"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.RequiresAny))]
    public static T ResetRequiresAny<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Remove(() => o.RequiresAny));
    /// <inheritdoc cref="VSWhereSettings.RequiresAny"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.RequiresAny))]
    public static T EnableRequiresAny<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.RequiresAny, true));
    /// <inheritdoc cref="VSWhereSettings.RequiresAny"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.RequiresAny))]
    public static T DisableRequiresAny<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.RequiresAny, false));
    /// <inheritdoc cref="VSWhereSettings.RequiresAny"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.RequiresAny))]
    public static T ToggleRequiresAny<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.RequiresAny, !o.RequiresAny));
    #endregion
    #region Version
    /// <inheritdoc cref="VSWhereSettings.Version"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="VSWhereSettings.Version"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Property
    /// <inheritdoc cref="VSWhereSettings.Property"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Property))]
    public static T SetProperty<T>(this T o, string v) where T : VSWhereSettings => o.Modify(b => b.Set(() => o.Property, v));
    /// <inheritdoc cref="VSWhereSettings.Property"/>
    [Pure] [Builder(Type = typeof(VSWhereSettings), Property = nameof(VSWhereSettings.Property))]
    public static T ResetProperty<T>(this T o) where T : VSWhereSettings => o.Modify(b => b.Remove(() => o.Property));
    #endregion
}
#endregion
#region VSWhereFormat
/// <summary>Used within <see cref="VSWhereTasks"/>.</summary>
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

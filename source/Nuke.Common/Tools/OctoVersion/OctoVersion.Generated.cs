// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/OctoVersion/OctoVersion.json

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

namespace Nuke.Common.Tools.OctoVersion;

/// <summary><p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class OctoVersionTasks : ToolTasks, IRequireNuGetPackage
{
    public static string OctoVersionPath => new OctoVersionTasks().GetToolPath();
    public const string PackageId = "OctoVersion.Tool";
    public const string PackageExecutable = "OctoVersion.Tool.dll";
    /// <summary><p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> OctoVersion(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new OctoVersionTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Gets the version information for a project.</p><p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--BuildMetadata</c> via <see cref="OctoVersionGetVersionSettings.BuildMetadata"/></li><li><c>--CurrentBranch</c> via <see cref="OctoVersionGetVersionSettings.CurrentBranch"/></li><li><c>--DetectEnvironment</c> via <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></li><li><c>--FullSemVer</c> via <see cref="OctoVersionGetVersionSettings.FullSemVer"/></li><li><c>--Major</c> via <see cref="OctoVersionGetVersionSettings.Major"/></li><li><c>--Minor</c> via <see cref="OctoVersionGetVersionSettings.Minor"/></li><li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></li><li><c>--OutputFormats</c> via <see cref="OctoVersionGetVersionSettings.OutputFormats"/></li><li><c>--OutputJsonFile</c> via <see cref="OctoVersionGetVersionSettings.OutputJsonFile"/></li><li><c>--Patch</c> via <see cref="OctoVersionGetVersionSettings.Patch"/></li><li><c>--PreReleaseTag</c> via <see cref="OctoVersionGetVersionSettings.PreReleaseTag"/></li><li><c>--RepositoryPath</c> via <see cref="OctoVersionGetVersionSettings.RepositoryPath"/></li></ul></remarks>
    public static (OctoVersionInfo Result, IReadOnlyCollection<Output> Output) OctoVersionGetVersion(OctoVersionGetVersionSettings options = null) => new OctoVersionTasks().Run<OctoVersionInfo>(options);
    /// <summary><p>Gets the version information for a project.</p><p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--BuildMetadata</c> via <see cref="OctoVersionGetVersionSettings.BuildMetadata"/></li><li><c>--CurrentBranch</c> via <see cref="OctoVersionGetVersionSettings.CurrentBranch"/></li><li><c>--DetectEnvironment</c> via <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></li><li><c>--FullSemVer</c> via <see cref="OctoVersionGetVersionSettings.FullSemVer"/></li><li><c>--Major</c> via <see cref="OctoVersionGetVersionSettings.Major"/></li><li><c>--Minor</c> via <see cref="OctoVersionGetVersionSettings.Minor"/></li><li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></li><li><c>--OutputFormats</c> via <see cref="OctoVersionGetVersionSettings.OutputFormats"/></li><li><c>--OutputJsonFile</c> via <see cref="OctoVersionGetVersionSettings.OutputJsonFile"/></li><li><c>--Patch</c> via <see cref="OctoVersionGetVersionSettings.Patch"/></li><li><c>--PreReleaseTag</c> via <see cref="OctoVersionGetVersionSettings.PreReleaseTag"/></li><li><c>--RepositoryPath</c> via <see cref="OctoVersionGetVersionSettings.RepositoryPath"/></li></ul></remarks>
    public static (OctoVersionInfo Result, IReadOnlyCollection<Output> Output) OctoVersionGetVersion(Configure<OctoVersionGetVersionSettings> configurator) => new OctoVersionTasks().Run<OctoVersionInfo>(configurator.Invoke(new OctoVersionGetVersionSettings()));
    /// <summary><p>Gets the version information for a project.</p><p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--BuildMetadata</c> via <see cref="OctoVersionGetVersionSettings.BuildMetadata"/></li><li><c>--CurrentBranch</c> via <see cref="OctoVersionGetVersionSettings.CurrentBranch"/></li><li><c>--DetectEnvironment</c> via <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></li><li><c>--FullSemVer</c> via <see cref="OctoVersionGetVersionSettings.FullSemVer"/></li><li><c>--Major</c> via <see cref="OctoVersionGetVersionSettings.Major"/></li><li><c>--Minor</c> via <see cref="OctoVersionGetVersionSettings.Minor"/></li><li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></li><li><c>--OutputFormats</c> via <see cref="OctoVersionGetVersionSettings.OutputFormats"/></li><li><c>--OutputJsonFile</c> via <see cref="OctoVersionGetVersionSettings.OutputJsonFile"/></li><li><c>--Patch</c> via <see cref="OctoVersionGetVersionSettings.Patch"/></li><li><c>--PreReleaseTag</c> via <see cref="OctoVersionGetVersionSettings.PreReleaseTag"/></li><li><c>--RepositoryPath</c> via <see cref="OctoVersionGetVersionSettings.RepositoryPath"/></li></ul></remarks>
    public static IEnumerable<(OctoVersionGetVersionSettings Settings, OctoVersionInfo Result, IReadOnlyCollection<Output> Output)> OctoVersionGetVersion(CombinatorialConfigure<OctoVersionGetVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(OctoVersionGetVersion, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Executes OctoVersion information for a project, without trying to parse the output.</p><p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--BuildMetadata</c> via <see cref="OctoVersionExecuteSettings.BuildMetadata"/></li><li><c>--CurrentBranch</c> via <see cref="OctoVersionExecuteSettings.CurrentBranch"/></li><li><c>--DetectEnvironment</c> via <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></li><li><c>--FullSemVer</c> via <see cref="OctoVersionExecuteSettings.FullSemVer"/></li><li><c>--Major</c> via <see cref="OctoVersionExecuteSettings.Major"/></li><li><c>--Minor</c> via <see cref="OctoVersionExecuteSettings.Minor"/></li><li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></li><li><c>--OutputFormats</c> via <see cref="OctoVersionExecuteSettings.OutputFormats"/></li><li><c>--OutputJsonFile</c> via <see cref="OctoVersionExecuteSettings.OutputJsonFile"/></li><li><c>--Patch</c> via <see cref="OctoVersionExecuteSettings.Patch"/></li><li><c>--PreReleaseTag</c> via <see cref="OctoVersionExecuteSettings.PreReleaseTag"/></li><li><c>--RepositoryPath</c> via <see cref="OctoVersionExecuteSettings.RepositoryPath"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctoVersionExecute(OctoVersionExecuteSettings options = null) => new OctoVersionTasks().Run(options);
    /// <summary><p>Executes OctoVersion information for a project, without trying to parse the output.</p><p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--BuildMetadata</c> via <see cref="OctoVersionExecuteSettings.BuildMetadata"/></li><li><c>--CurrentBranch</c> via <see cref="OctoVersionExecuteSettings.CurrentBranch"/></li><li><c>--DetectEnvironment</c> via <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></li><li><c>--FullSemVer</c> via <see cref="OctoVersionExecuteSettings.FullSemVer"/></li><li><c>--Major</c> via <see cref="OctoVersionExecuteSettings.Major"/></li><li><c>--Minor</c> via <see cref="OctoVersionExecuteSettings.Minor"/></li><li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></li><li><c>--OutputFormats</c> via <see cref="OctoVersionExecuteSettings.OutputFormats"/></li><li><c>--OutputJsonFile</c> via <see cref="OctoVersionExecuteSettings.OutputJsonFile"/></li><li><c>--Patch</c> via <see cref="OctoVersionExecuteSettings.Patch"/></li><li><c>--PreReleaseTag</c> via <see cref="OctoVersionExecuteSettings.PreReleaseTag"/></li><li><c>--RepositoryPath</c> via <see cref="OctoVersionExecuteSettings.RepositoryPath"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> OctoVersionExecute(Configure<OctoVersionExecuteSettings> configurator) => new OctoVersionTasks().Run(configurator.Invoke(new OctoVersionExecuteSettings()));
    /// <summary><p>Executes OctoVersion information for a project, without trying to parse the output.</p><p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--BuildMetadata</c> via <see cref="OctoVersionExecuteSettings.BuildMetadata"/></li><li><c>--CurrentBranch</c> via <see cref="OctoVersionExecuteSettings.CurrentBranch"/></li><li><c>--DetectEnvironment</c> via <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></li><li><c>--FullSemVer</c> via <see cref="OctoVersionExecuteSettings.FullSemVer"/></li><li><c>--Major</c> via <see cref="OctoVersionExecuteSettings.Major"/></li><li><c>--Minor</c> via <see cref="OctoVersionExecuteSettings.Minor"/></li><li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></li><li><c>--OutputFormats</c> via <see cref="OctoVersionExecuteSettings.OutputFormats"/></li><li><c>--OutputJsonFile</c> via <see cref="OctoVersionExecuteSettings.OutputJsonFile"/></li><li><c>--Patch</c> via <see cref="OctoVersionExecuteSettings.Patch"/></li><li><c>--PreReleaseTag</c> via <see cref="OctoVersionExecuteSettings.PreReleaseTag"/></li><li><c>--RepositoryPath</c> via <see cref="OctoVersionExecuteSettings.RepositoryPath"/></li></ul></remarks>
    public static IEnumerable<(OctoVersionExecuteSettings Settings, IReadOnlyCollection<Output> Output)> OctoVersionExecute(CombinatorialConfigure<OctoVersionExecuteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(OctoVersionExecute, degreeOfParallelism, completeOnFailure);
}
#region OctoVersionGetVersionSettings
/// <summary>Used within <see cref="OctoVersionTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OctoVersionGetVersionSettings>))]
[Command(Type = typeof(OctoVersionTasks), Command = nameof(OctoVersionTasks.OctoVersionGetVersion), Arguments = "octoversion")]
public partial class OctoVersionGetVersionSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>Pass in the name of the branch. If not set, OctoVersion will attempt to derive it, but this may lead to incorrect values.</summary>
    [Argument(Format = "--CurrentBranch {value}")] public string CurrentBranch => Get<string>(() => CurrentBranch);
    /// <summary>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</summary>
    [Argument(Format = "--NonPreReleaseTags {value}", Separator = " ")] public IReadOnlyList<string> NonPreReleaseTags => Get<List<string>>(() => NonPreReleaseTags);
    /// <summary>Path to the Git repository. If not set, assumes that the current working folder is the root of the repository</summary>
    [Argument(Format = "--RepositoryPath {value}")] public string RepositoryPath => Get<string>(() => RepositoryPath);
    /// <summary>Override the calculated Major with a specific value.</summary>
    [Argument(Format = "--Major {value}")] public int? Major => Get<int?>(() => Major);
    /// <summary>Override the calculated Minor with a specific value.</summary>
    [Argument(Format = "--Minor {value}")] public int? Minor => Get<int?>(() => Minor);
    /// <summary>Override the calculated Patch with a specific value.</summary>
    [Argument(Format = "--Patch {value}")] public int? Patch => Get<int?>(() => Patch);
    /// <summary>Override the calculated PreReleaseTag with a specific value.</summary>
    [Argument(Format = "--PreReleaseTag {value}")] public string PreReleaseTag => Get<string>(() => PreReleaseTag);
    /// <summary>Override the calculated build metadata with a specific value.</summary>
    [Argument(Format = "--BuildMetadata {value}")] public string BuildMetadata => Get<string>(() => BuildMetadata);
    /// <summary>If set, this version number will override all of the other values and OctoVersion will just adopt it wholesale.</summary>
    [Argument(Format = "--FullSemVer {value}")] public string FullSemVer => Get<string>(() => FullSemVer);
    /// <summary>How to format the output. Defaults to Console.</summary>
    [Argument(Format = "--OutputFormats {value}")] public IReadOnlyList<OctoVersionOutputFormatter> OutputFormats => Get<List<OctoVersionOutputFormatter>>(() => OutputFormats);
    /// <summary>Detect the output format from the runtime environment (usually the CI environment).</summary>
    [Argument(Format = "--DetectEnvironment {value}")] public bool? DetectEnvironment => Get<bool?>(() => DetectEnvironment);
    /// <summary>Emit json to the specified file. Ensure that either the `JsonFile` output formatter is added, or that `DetectEnvironment` is `true`.</summary>
    [Argument(Format = "--OutputJsonFile {value}")] public string OutputJsonFile => Get<string>(() => OutputJsonFile);
}
#endregion
#region OctoVersionExecuteSettings
/// <summary>Used within <see cref="OctoVersionTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OctoVersionExecuteSettings>))]
[Command(Type = typeof(OctoVersionTasks), Command = nameof(OctoVersionTasks.OctoVersionExecute), Arguments = "octoversion")]
public partial class OctoVersionExecuteSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>Pass in the name of the branch. If not set, OctoVersion will attempt to derive it, but this may lead to incorrect values.</summary>
    [Argument(Format = "--CurrentBranch {value}")] public string CurrentBranch => Get<string>(() => CurrentBranch);
    /// <summary>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</summary>
    [Argument(Format = "--NonPreReleaseTags {value}", Separator = " ")] public IReadOnlyList<string> NonPreReleaseTags => Get<List<string>>(() => NonPreReleaseTags);
    /// <summary>Path to the Git repository. If not set, assumes that the current working folder is the root of the repository</summary>
    [Argument(Format = "--RepositoryPath {value}")] public string RepositoryPath => Get<string>(() => RepositoryPath);
    /// <summary>Override the calculated Major with a specific value.</summary>
    [Argument(Format = "--Major {value}")] public int? Major => Get<int?>(() => Major);
    /// <summary>Override the calculated Minor with a specific value.</summary>
    [Argument(Format = "--Minor {value}")] public int? Minor => Get<int?>(() => Minor);
    /// <summary>Override the calculated Patch with a specific value.</summary>
    [Argument(Format = "--Patch {value}")] public int? Patch => Get<int?>(() => Patch);
    /// <summary>Override the calculated PreReleaseTag with a specific value.</summary>
    [Argument(Format = "--PreReleaseTag {value}")] public string PreReleaseTag => Get<string>(() => PreReleaseTag);
    /// <summary>Override the calculated build metadata with a specific value.</summary>
    [Argument(Format = "--BuildMetadata {value}")] public string BuildMetadata => Get<string>(() => BuildMetadata);
    /// <summary>If set, this version number will override all of the other values and OctoVersion will just adopt it wholesale.</summary>
    [Argument(Format = "--FullSemVer {value}")] public string FullSemVer => Get<string>(() => FullSemVer);
    /// <summary>How to format the output. Defaults to Console.</summary>
    [Argument(Format = "--OutputFormats {value}")] public IReadOnlyList<OctoVersionOutputFormatter> OutputFormats => Get<List<OctoVersionOutputFormatter>>(() => OutputFormats);
    /// <summary>Detect the output format from the runtime environment (usually the CI environment).</summary>
    [Argument(Format = "--DetectEnvironment {value}")] public bool? DetectEnvironment => Get<bool?>(() => DetectEnvironment);
    /// <summary>Emit json to the specified file. Ensure that either the `JsonFile` output formatter is added, or that `DetectEnvironment` is `true`.</summary>
    [Argument(Format = "--OutputJsonFile {value}")] public string OutputJsonFile => Get<string>(() => OutputJsonFile);
}
#endregion
#region OctoVersionGetVersionSettingsExtensions
/// <summary>Used within <see cref="OctoVersionTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class OctoVersionGetVersionSettingsExtensions
{
    #region CurrentBranch
    /// <inheritdoc cref="OctoVersionGetVersionSettings.CurrentBranch"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.CurrentBranch))]
    public static T SetCurrentBranch<T>(this T o, string v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.CurrentBranch, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.CurrentBranch"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.CurrentBranch))]
    public static T ResetCurrentBranch<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Remove(() => o.CurrentBranch));
    #endregion
    #region NonPreReleaseTags
    /// <inheritdoc cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.NonPreReleaseTags))]
    public static T SetNonPreReleaseTags<T>(this T o, params string[] v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.NonPreReleaseTags))]
    public static T SetNonPreReleaseTags<T>(this T o, IEnumerable<string> v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.NonPreReleaseTags))]
    public static T AddNonPreReleaseTags<T>(this T o, params string[] v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.AddCollection(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.NonPreReleaseTags))]
    public static T AddNonPreReleaseTags<T>(this T o, IEnumerable<string> v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.AddCollection(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.NonPreReleaseTags))]
    public static T RemoveNonPreReleaseTags<T>(this T o, params string[] v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.RemoveCollection(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.NonPreReleaseTags))]
    public static T RemoveNonPreReleaseTags<T>(this T o, IEnumerable<string> v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.RemoveCollection(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.NonPreReleaseTags))]
    public static T ClearNonPreReleaseTags<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.ClearCollection(() => o.NonPreReleaseTags));
    #endregion
    #region RepositoryPath
    /// <inheritdoc cref="OctoVersionGetVersionSettings.RepositoryPath"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.RepositoryPath))]
    public static T SetRepositoryPath<T>(this T o, string v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.RepositoryPath, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.RepositoryPath"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.RepositoryPath))]
    public static T ResetRepositoryPath<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Remove(() => o.RepositoryPath));
    #endregion
    #region Major
    /// <inheritdoc cref="OctoVersionGetVersionSettings.Major"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.Major))]
    public static T SetMajor<T>(this T o, int? v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.Major, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.Major"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.Major))]
    public static T ResetMajor<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Remove(() => o.Major));
    #endregion
    #region Minor
    /// <inheritdoc cref="OctoVersionGetVersionSettings.Minor"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.Minor))]
    public static T SetMinor<T>(this T o, int? v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.Minor, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.Minor"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.Minor))]
    public static T ResetMinor<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Remove(() => o.Minor));
    #endregion
    #region Patch
    /// <inheritdoc cref="OctoVersionGetVersionSettings.Patch"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.Patch))]
    public static T SetPatch<T>(this T o, int? v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.Patch, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.Patch"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.Patch))]
    public static T ResetPatch<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Remove(() => o.Patch));
    #endregion
    #region PreReleaseTag
    /// <inheritdoc cref="OctoVersionGetVersionSettings.PreReleaseTag"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.PreReleaseTag))]
    public static T SetPreReleaseTag<T>(this T o, string v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.PreReleaseTag, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.PreReleaseTag"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.PreReleaseTag))]
    public static T ResetPreReleaseTag<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Remove(() => o.PreReleaseTag));
    #endregion
    #region BuildMetadata
    /// <inheritdoc cref="OctoVersionGetVersionSettings.BuildMetadata"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.BuildMetadata))]
    public static T SetBuildMetadata<T>(this T o, string v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.BuildMetadata, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.BuildMetadata"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.BuildMetadata))]
    public static T ResetBuildMetadata<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Remove(() => o.BuildMetadata));
    #endregion
    #region FullSemVer
    /// <inheritdoc cref="OctoVersionGetVersionSettings.FullSemVer"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.FullSemVer))]
    public static T SetFullSemVer<T>(this T o, string v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.FullSemVer, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.FullSemVer"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.FullSemVer))]
    public static T ResetFullSemVer<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Remove(() => o.FullSemVer));
    #endregion
    #region OutputFormats
    /// <inheritdoc cref="OctoVersionGetVersionSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.OutputFormats))]
    public static T SetOutputFormats<T>(this T o, params OctoVersionOutputFormatter[] v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.OutputFormats))]
    public static T SetOutputFormats<T>(this T o, IEnumerable<OctoVersionOutputFormatter> v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.OutputFormats))]
    public static T AddOutputFormats<T>(this T o, params OctoVersionOutputFormatter[] v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.AddCollection(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.OutputFormats))]
    public static T AddOutputFormats<T>(this T o, IEnumerable<OctoVersionOutputFormatter> v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.AddCollection(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.OutputFormats))]
    public static T RemoveOutputFormats<T>(this T o, params OctoVersionOutputFormatter[] v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.RemoveCollection(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.OutputFormats))]
    public static T RemoveOutputFormats<T>(this T o, IEnumerable<OctoVersionOutputFormatter> v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.RemoveCollection(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.OutputFormats))]
    public static T ClearOutputFormats<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.ClearCollection(() => o.OutputFormats));
    #endregion
    #region DetectEnvironment
    /// <inheritdoc cref="OctoVersionGetVersionSettings.DetectEnvironment"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.DetectEnvironment))]
    public static T SetDetectEnvironment<T>(this T o, bool? v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.DetectEnvironment, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.DetectEnvironment"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.DetectEnvironment))]
    public static T ResetDetectEnvironment<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Remove(() => o.DetectEnvironment));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.DetectEnvironment"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.DetectEnvironment))]
    public static T EnableDetectEnvironment<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.DetectEnvironment, true));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.DetectEnvironment"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.DetectEnvironment))]
    public static T DisableDetectEnvironment<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.DetectEnvironment, false));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.DetectEnvironment"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.DetectEnvironment))]
    public static T ToggleDetectEnvironment<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.DetectEnvironment, !o.DetectEnvironment));
    #endregion
    #region OutputJsonFile
    /// <inheritdoc cref="OctoVersionGetVersionSettings.OutputJsonFile"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.OutputJsonFile))]
    public static T SetOutputJsonFile<T>(this T o, string v) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Set(() => o.OutputJsonFile, v));
    /// <inheritdoc cref="OctoVersionGetVersionSettings.OutputJsonFile"/>
    [Pure] [Builder(Type = typeof(OctoVersionGetVersionSettings), Property = nameof(OctoVersionGetVersionSettings.OutputJsonFile))]
    public static T ResetOutputJsonFile<T>(this T o) where T : OctoVersionGetVersionSettings => o.Modify(b => b.Remove(() => o.OutputJsonFile));
    #endregion
}
#endregion
#region OctoVersionExecuteSettingsExtensions
/// <summary>Used within <see cref="OctoVersionTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class OctoVersionExecuteSettingsExtensions
{
    #region CurrentBranch
    /// <inheritdoc cref="OctoVersionExecuteSettings.CurrentBranch"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.CurrentBranch))]
    public static T SetCurrentBranch<T>(this T o, string v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.CurrentBranch, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.CurrentBranch"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.CurrentBranch))]
    public static T ResetCurrentBranch<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Remove(() => o.CurrentBranch));
    #endregion
    #region NonPreReleaseTags
    /// <inheritdoc cref="OctoVersionExecuteSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.NonPreReleaseTags))]
    public static T SetNonPreReleaseTags<T>(this T o, params string[] v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.NonPreReleaseTags))]
    public static T SetNonPreReleaseTags<T>(this T o, IEnumerable<string> v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.NonPreReleaseTags))]
    public static T AddNonPreReleaseTags<T>(this T o, params string[] v) where T : OctoVersionExecuteSettings => o.Modify(b => b.AddCollection(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.NonPreReleaseTags))]
    public static T AddNonPreReleaseTags<T>(this T o, IEnumerable<string> v) where T : OctoVersionExecuteSettings => o.Modify(b => b.AddCollection(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.NonPreReleaseTags))]
    public static T RemoveNonPreReleaseTags<T>(this T o, params string[] v) where T : OctoVersionExecuteSettings => o.Modify(b => b.RemoveCollection(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.NonPreReleaseTags))]
    public static T RemoveNonPreReleaseTags<T>(this T o, IEnumerable<string> v) where T : OctoVersionExecuteSettings => o.Modify(b => b.RemoveCollection(() => o.NonPreReleaseTags, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.NonPreReleaseTags"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.NonPreReleaseTags))]
    public static T ClearNonPreReleaseTags<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.ClearCollection(() => o.NonPreReleaseTags));
    #endregion
    #region RepositoryPath
    /// <inheritdoc cref="OctoVersionExecuteSettings.RepositoryPath"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.RepositoryPath))]
    public static T SetRepositoryPath<T>(this T o, string v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.RepositoryPath, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.RepositoryPath"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.RepositoryPath))]
    public static T ResetRepositoryPath<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Remove(() => o.RepositoryPath));
    #endregion
    #region Major
    /// <inheritdoc cref="OctoVersionExecuteSettings.Major"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.Major))]
    public static T SetMajor<T>(this T o, int? v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.Major, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.Major"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.Major))]
    public static T ResetMajor<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Remove(() => o.Major));
    #endregion
    #region Minor
    /// <inheritdoc cref="OctoVersionExecuteSettings.Minor"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.Minor))]
    public static T SetMinor<T>(this T o, int? v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.Minor, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.Minor"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.Minor))]
    public static T ResetMinor<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Remove(() => o.Minor));
    #endregion
    #region Patch
    /// <inheritdoc cref="OctoVersionExecuteSettings.Patch"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.Patch))]
    public static T SetPatch<T>(this T o, int? v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.Patch, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.Patch"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.Patch))]
    public static T ResetPatch<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Remove(() => o.Patch));
    #endregion
    #region PreReleaseTag
    /// <inheritdoc cref="OctoVersionExecuteSettings.PreReleaseTag"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.PreReleaseTag))]
    public static T SetPreReleaseTag<T>(this T o, string v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.PreReleaseTag, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.PreReleaseTag"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.PreReleaseTag))]
    public static T ResetPreReleaseTag<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Remove(() => o.PreReleaseTag));
    #endregion
    #region BuildMetadata
    /// <inheritdoc cref="OctoVersionExecuteSettings.BuildMetadata"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.BuildMetadata))]
    public static T SetBuildMetadata<T>(this T o, string v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.BuildMetadata, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.BuildMetadata"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.BuildMetadata))]
    public static T ResetBuildMetadata<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Remove(() => o.BuildMetadata));
    #endregion
    #region FullSemVer
    /// <inheritdoc cref="OctoVersionExecuteSettings.FullSemVer"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.FullSemVer))]
    public static T SetFullSemVer<T>(this T o, string v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.FullSemVer, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.FullSemVer"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.FullSemVer))]
    public static T ResetFullSemVer<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Remove(() => o.FullSemVer));
    #endregion
    #region OutputFormats
    /// <inheritdoc cref="OctoVersionExecuteSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.OutputFormats))]
    public static T SetOutputFormats<T>(this T o, params OctoVersionOutputFormatter[] v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.OutputFormats))]
    public static T SetOutputFormats<T>(this T o, IEnumerable<OctoVersionOutputFormatter> v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.OutputFormats))]
    public static T AddOutputFormats<T>(this T o, params OctoVersionOutputFormatter[] v) where T : OctoVersionExecuteSettings => o.Modify(b => b.AddCollection(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.OutputFormats))]
    public static T AddOutputFormats<T>(this T o, IEnumerable<OctoVersionOutputFormatter> v) where T : OctoVersionExecuteSettings => o.Modify(b => b.AddCollection(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.OutputFormats))]
    public static T RemoveOutputFormats<T>(this T o, params OctoVersionOutputFormatter[] v) where T : OctoVersionExecuteSettings => o.Modify(b => b.RemoveCollection(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.OutputFormats))]
    public static T RemoveOutputFormats<T>(this T o, IEnumerable<OctoVersionOutputFormatter> v) where T : OctoVersionExecuteSettings => o.Modify(b => b.RemoveCollection(() => o.OutputFormats, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.OutputFormats"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.OutputFormats))]
    public static T ClearOutputFormats<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.ClearCollection(() => o.OutputFormats));
    #endregion
    #region DetectEnvironment
    /// <inheritdoc cref="OctoVersionExecuteSettings.DetectEnvironment"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.DetectEnvironment))]
    public static T SetDetectEnvironment<T>(this T o, bool? v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.DetectEnvironment, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.DetectEnvironment"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.DetectEnvironment))]
    public static T ResetDetectEnvironment<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Remove(() => o.DetectEnvironment));
    /// <inheritdoc cref="OctoVersionExecuteSettings.DetectEnvironment"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.DetectEnvironment))]
    public static T EnableDetectEnvironment<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.DetectEnvironment, true));
    /// <inheritdoc cref="OctoVersionExecuteSettings.DetectEnvironment"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.DetectEnvironment))]
    public static T DisableDetectEnvironment<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.DetectEnvironment, false));
    /// <inheritdoc cref="OctoVersionExecuteSettings.DetectEnvironment"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.DetectEnvironment))]
    public static T ToggleDetectEnvironment<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.DetectEnvironment, !o.DetectEnvironment));
    #endregion
    #region OutputJsonFile
    /// <inheritdoc cref="OctoVersionExecuteSettings.OutputJsonFile"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.OutputJsonFile))]
    public static T SetOutputJsonFile<T>(this T o, string v) where T : OctoVersionExecuteSettings => o.Modify(b => b.Set(() => o.OutputJsonFile, v));
    /// <inheritdoc cref="OctoVersionExecuteSettings.OutputJsonFile"/>
    [Pure] [Builder(Type = typeof(OctoVersionExecuteSettings), Property = nameof(OctoVersionExecuteSettings.OutputJsonFile))]
    public static T ResetOutputJsonFile<T>(this T o) where T : OctoVersionExecuteSettings => o.Modify(b => b.Remove(() => o.OutputJsonFile));
    #endregion
}
#endregion
#region OctoVersionOutputFormatter
/// <summary>Used within <see cref="OctoVersionTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<OctoVersionOutputFormatter>))]
public partial class OctoVersionOutputFormatter : Enumeration
{
    public static OctoVersionOutputFormatter Nuke = (OctoVersionOutputFormatter) "Nuke";
    public static OctoVersionOutputFormatter Cake = (OctoVersionOutputFormatter) "Cake";
    public static OctoVersionOutputFormatter Console = (OctoVersionOutputFormatter) "Console";
    public static OctoVersionOutputFormatter QuietConsole = (OctoVersionOutputFormatter) "QuietConsole";
    public static OctoVersionOutputFormatter Environment = (OctoVersionOutputFormatter) "Environment";
    public static OctoVersionOutputFormatter Json = (OctoVersionOutputFormatter) "Json";
    public static OctoVersionOutputFormatter TeamCity = (OctoVersionOutputFormatter) "TeamCity";
    public static implicit operator OctoVersionOutputFormatter(string value)
    {
        return new OctoVersionOutputFormatter { Value = value };
    }
}
#endregion

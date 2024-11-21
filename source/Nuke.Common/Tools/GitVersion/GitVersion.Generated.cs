// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/GitVersion/GitVersion.json

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

namespace Nuke.Common.Tools.GitVersion;

/// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p><p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class GitVersionTasks : ToolTasks, IRequireNuGetPackage
{
    public static string GitVersionPath => new GitVersionTasks().GetToolPath();
    public const string PackageId = "GitVersion.Tool";
    public const string PackageExecutable = "GitVersion.dll|GitVersion.exe";
    /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p><p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> GitVersion(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new GitVersionTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p><p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="GitVersionSettings.TargetPath"/></li><li><c>/b</c> via <see cref="GitVersionSettings.Branch"/></li><li><c>/c</c> via <see cref="GitVersionSettings.Commit"/></li><li><c>/diag</c> via <see cref="GitVersionSettings.Diagnostics"/></li><li><c>/dynamicRepoLocation</c> via <see cref="GitVersionSettings.DynamicRepositoryLocation"/></li><li><c>/ensureassemblyinfo</c> via <see cref="GitVersionSettings.EnsureAssemblyInfo"/></li><li><c>/exec</c> via <see cref="GitVersionSettings.Executable"/></li><li><c>/execargs</c> via <see cref="GitVersionSettings.ExecutableArguments"/></li><li><c>/l</c> via <see cref="GitVersionSettings.LogFile"/></li><li><c>/nocache</c> via <see cref="GitVersionSettings.NoCache"/></li><li><c>/nofetch</c> via <see cref="GitVersionSettings.NoFetch"/></li><li><c>/output</c> via <see cref="GitVersionSettings.Output"/></li><li><c>/overrideconfig</c> via <see cref="GitVersionSettings.ConfigurationOverride"/></li><li><c>/p</c> via <see cref="GitVersionSettings.Password"/></li><li><c>/proj</c> via <see cref="GitVersionSettings.MSBuildProject"/></li><li><c>/projargs</c> via <see cref="GitVersionSettings.MSBuildProjectArguments"/></li><li><c>/showconfig</c> via <see cref="GitVersionSettings.ShowConfig"/></li><li><c>/showvariable</c> via <see cref="GitVersionSettings.ShowVariable"/></li><li><c>/u</c> via <see cref="GitVersionSettings.Username"/></li><li><c>/updateassemblyinfo</c> via <see cref="GitVersionSettings.UpdateAssemblyInfo"/></li><li><c>/updateassemblyinfofilename</c> via <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></li><li><c>/url</c> via <see cref="GitVersionSettings.Url"/></li><li><c>/verbosity</c> via <see cref="GitVersionSettings.Verbosity"/></li><li><c>/version</c> via <see cref="GitVersionSettings.Version"/></li></ul></remarks>
    public static (GitVersion Result, IReadOnlyCollection<Output> Output) GitVersion(GitVersionSettings options = null) => new GitVersionTasks().Run<GitVersion>(options);
    /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p><p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="GitVersionSettings.TargetPath"/></li><li><c>/b</c> via <see cref="GitVersionSettings.Branch"/></li><li><c>/c</c> via <see cref="GitVersionSettings.Commit"/></li><li><c>/diag</c> via <see cref="GitVersionSettings.Diagnostics"/></li><li><c>/dynamicRepoLocation</c> via <see cref="GitVersionSettings.DynamicRepositoryLocation"/></li><li><c>/ensureassemblyinfo</c> via <see cref="GitVersionSettings.EnsureAssemblyInfo"/></li><li><c>/exec</c> via <see cref="GitVersionSettings.Executable"/></li><li><c>/execargs</c> via <see cref="GitVersionSettings.ExecutableArguments"/></li><li><c>/l</c> via <see cref="GitVersionSettings.LogFile"/></li><li><c>/nocache</c> via <see cref="GitVersionSettings.NoCache"/></li><li><c>/nofetch</c> via <see cref="GitVersionSettings.NoFetch"/></li><li><c>/output</c> via <see cref="GitVersionSettings.Output"/></li><li><c>/overrideconfig</c> via <see cref="GitVersionSettings.ConfigurationOverride"/></li><li><c>/p</c> via <see cref="GitVersionSettings.Password"/></li><li><c>/proj</c> via <see cref="GitVersionSettings.MSBuildProject"/></li><li><c>/projargs</c> via <see cref="GitVersionSettings.MSBuildProjectArguments"/></li><li><c>/showconfig</c> via <see cref="GitVersionSettings.ShowConfig"/></li><li><c>/showvariable</c> via <see cref="GitVersionSettings.ShowVariable"/></li><li><c>/u</c> via <see cref="GitVersionSettings.Username"/></li><li><c>/updateassemblyinfo</c> via <see cref="GitVersionSettings.UpdateAssemblyInfo"/></li><li><c>/updateassemblyinfofilename</c> via <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></li><li><c>/url</c> via <see cref="GitVersionSettings.Url"/></li><li><c>/verbosity</c> via <see cref="GitVersionSettings.Verbosity"/></li><li><c>/version</c> via <see cref="GitVersionSettings.Version"/></li></ul></remarks>
    public static (GitVersion Result, IReadOnlyCollection<Output> Output) GitVersion(Configure<GitVersionSettings> configurator) => new GitVersionTasks().Run<GitVersion>(configurator.Invoke(new GitVersionSettings()));
    /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p><p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="GitVersionSettings.TargetPath"/></li><li><c>/b</c> via <see cref="GitVersionSettings.Branch"/></li><li><c>/c</c> via <see cref="GitVersionSettings.Commit"/></li><li><c>/diag</c> via <see cref="GitVersionSettings.Diagnostics"/></li><li><c>/dynamicRepoLocation</c> via <see cref="GitVersionSettings.DynamicRepositoryLocation"/></li><li><c>/ensureassemblyinfo</c> via <see cref="GitVersionSettings.EnsureAssemblyInfo"/></li><li><c>/exec</c> via <see cref="GitVersionSettings.Executable"/></li><li><c>/execargs</c> via <see cref="GitVersionSettings.ExecutableArguments"/></li><li><c>/l</c> via <see cref="GitVersionSettings.LogFile"/></li><li><c>/nocache</c> via <see cref="GitVersionSettings.NoCache"/></li><li><c>/nofetch</c> via <see cref="GitVersionSettings.NoFetch"/></li><li><c>/output</c> via <see cref="GitVersionSettings.Output"/></li><li><c>/overrideconfig</c> via <see cref="GitVersionSettings.ConfigurationOverride"/></li><li><c>/p</c> via <see cref="GitVersionSettings.Password"/></li><li><c>/proj</c> via <see cref="GitVersionSettings.MSBuildProject"/></li><li><c>/projargs</c> via <see cref="GitVersionSettings.MSBuildProjectArguments"/></li><li><c>/showconfig</c> via <see cref="GitVersionSettings.ShowConfig"/></li><li><c>/showvariable</c> via <see cref="GitVersionSettings.ShowVariable"/></li><li><c>/u</c> via <see cref="GitVersionSettings.Username"/></li><li><c>/updateassemblyinfo</c> via <see cref="GitVersionSettings.UpdateAssemblyInfo"/></li><li><c>/updateassemblyinfofilename</c> via <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></li><li><c>/url</c> via <see cref="GitVersionSettings.Url"/></li><li><c>/verbosity</c> via <see cref="GitVersionSettings.Verbosity"/></li><li><c>/version</c> via <see cref="GitVersionSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(GitVersionSettings Settings, GitVersion Result, IReadOnlyCollection<Output> Output)> GitVersion(CombinatorialConfigure<GitVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(GitVersion, degreeOfParallelism, completeOnFailure);
}
#region GitVersionSettings
/// <summary>Used within <see cref="GitVersionTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitVersionSettings>))]
[Command(Type = typeof(GitVersionTasks), Command = nameof(GitVersionTasks.GitVersion))]
public partial class GitVersionSettings : ToolOptions, IToolOptionsWithFramework
{
    /// <summary>The directory containing .git. If not defined current directory is used. (Must be first argument).</summary>
    [Argument(Format = "{value}", Position = 1)] public string TargetPath => Get<string>(() => TargetPath);
    /// <summary>Displays the version of GitVersion.</summary>
    [Argument(Format = "/version")] public bool? Version => Get<bool?>(() => Version);
    /// <summary>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</summary>
    [Argument(Format = "/diag")] public bool? Diagnostics => Get<bool?>(() => Diagnostics);
    /// <summary>Determines the output to the console. Can be either <em>json</em> or <em>buildserver</em>, will default to <em>json</em>.</summary>
    [Argument(Format = "/output {value}")] public GitVersionOutput Output => Get<GitVersionOutput>(() => Output);
    /// <summary>Used in conjuntion with <c>/output</c> json, will output just a particular variable. E.g., <c>/output json /showvariable SemVer</c> - will output <c>1.2.3+beta.4</c>.</summary>
    [Argument(Format = "/showvariable {value}")] public string ShowVariable => Get<string>(() => ShowVariable);
    /// <summary>Path to logfile.</summary>
    [Argument(Format = "/l {value}")] public string LogFile => Get<string>(() => LogFile);
    /// <summary>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</summary>
    [Argument(Format = "/showconfig")] public bool? ShowConfig => Get<bool?>(() => ShowConfig);
    /// <summary>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</summary>
    [Argument(Format = "/overrideconfig {key}={value}")] public IReadOnlyDictionary<string, object> ConfigurationOverride => Get<Dictionary<string, object>>(() => ConfigurationOverride);
    /// <summary>Bypasses the cache, result will not be written to the cache.</summary>
    [Argument(Format = "/nocache")] public bool? NoCache => Get<bool?>(() => NoCache);
    /// <summary>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</summary>
    [Argument(Format = "/updateassemblyinfo")] public bool? UpdateAssemblyInfo => Get<bool?>(() => UpdateAssemblyInfo);
    /// <summary>Specify name of AssemblyInfo files to update.</summary>
    [Argument(Format = "/updateassemblyinfofilename {value}", Separator = " ")] public IReadOnlyList<string> UpdateAssemblyInfoFileNames => Get<List<string>>(() => UpdateAssemblyInfoFileNames);
    /// <summary>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</summary>
    [Argument(Format = "/ensureassemblyinfo")] public bool? EnsureAssemblyInfo => Get<bool?>(() => EnsureAssemblyInfo);
    /// <summary>Url to remote git repository.</summary>
    [Argument(Format = "/url {value}")] public string Url => Get<string>(() => Url);
    /// <summary>Name of the branch to use on the remote repository, must be used in combination with <c>/url</c>.</summary>
    [Argument(Format = "/b {value}")] public string Branch => Get<string>(() => Branch);
    /// <summary>Username in case authentication is required.</summary>
    [Argument(Format = "/u {value}")] public string Username => Get<string>(() => Username);
    /// <summary>Password in case authentication is required.</summary>
    [Argument(Format = "/p {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>The commit id to check. If not specified, the latest available commit on the specified branch will be used.</summary>
    [Argument(Format = "/c {value}")] public string Commit => Get<string>(() => Commit);
    /// <summary>By default dynamic repositories will be cloned to %tmp%. Use this switch to override.</summary>
    [Argument(Format = "/dynamicRepoLocation {value}")] public string DynamicRepositoryLocation => Get<string>(() => DynamicRepositoryLocation);
    /// <summary>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</summary>
    [Argument(Format = "/nofetch")] public bool? NoFetch => Get<bool?>(() => NoFetch);
    /// <summary>Executes target executable making GitVersion variables available as environmental variables.</summary>
    [Argument(Format = "/exec {value}")] public string Executable => Get<string>(() => Executable);
    /// <summary>Arguments for the executable specified by <c>/exec</c>.</summary>
    [Argument(Format = "/execargs {value}")] public string ExecutableArguments => Get<string>(() => ExecutableArguments);
    /// <summary>Build an MSBuild file, GitVersion variables will be passed as MSBuild properties.</summary>
    [Argument(Format = "/proj {value}")] public string MSBuildProject => Get<string>(() => MSBuildProject);
    /// <summary>Additional arguments to pass to MSBuild.</summary>
    [Argument(Format = "/projargs {value}")] public string MSBuildProjectArguments => Get<string>(() => MSBuildProjectArguments);
    /// <summary>Set Verbosity level (<c>debug</c>, <c>info</c>, <c>warn</c>, <c>error</c>, <c>none</c>). Default is <c>info</c>.</summary>
    [Argument(Format = "/verbosity {value}")] public GitVersionVerbosity Verbosity => Get<GitVersionVerbosity>(() => Verbosity);
}
#endregion
#region GitVersionSettingsExtensions
/// <summary>Used within <see cref="GitVersionTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class GitVersionSettingsExtensions
{
    #region TargetPath
    /// <inheritdoc cref="GitVersionSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.TargetPath))]
    public static T SetTargetPath<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.TargetPath, v));
    /// <inheritdoc cref="GitVersionSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.TargetPath))]
    public static T ResetTargetPath<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.TargetPath));
    #endregion
    #region Version
    /// <inheritdoc cref="GitVersionSettings.Version"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Version))]
    public static T SetVersion<T>(this T o, bool? v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="GitVersionSettings.Version"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.Version));
    /// <inheritdoc cref="GitVersionSettings.Version"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Version))]
    public static T EnableVersion<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Version, true));
    /// <inheritdoc cref="GitVersionSettings.Version"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Version))]
    public static T DisableVersion<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Version, false));
    /// <inheritdoc cref="GitVersionSettings.Version"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Version))]
    public static T ToggleVersion<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Version, !o.Version));
    #endregion
    #region Diagnostics
    /// <inheritdoc cref="GitVersionSettings.Diagnostics"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Diagnostics))]
    public static T SetDiagnostics<T>(this T o, bool? v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Diagnostics, v));
    /// <inheritdoc cref="GitVersionSettings.Diagnostics"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Diagnostics))]
    public static T ResetDiagnostics<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.Diagnostics));
    /// <inheritdoc cref="GitVersionSettings.Diagnostics"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Diagnostics))]
    public static T EnableDiagnostics<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Diagnostics, true));
    /// <inheritdoc cref="GitVersionSettings.Diagnostics"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Diagnostics))]
    public static T DisableDiagnostics<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Diagnostics, false));
    /// <inheritdoc cref="GitVersionSettings.Diagnostics"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Diagnostics))]
    public static T ToggleDiagnostics<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Diagnostics, !o.Diagnostics));
    #endregion
    #region Output
    /// <inheritdoc cref="GitVersionSettings.Output"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Output))]
    public static T SetOutput<T>(this T o, GitVersionOutput v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="GitVersionSettings.Output"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region ShowVariable
    /// <inheritdoc cref="GitVersionSettings.ShowVariable"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ShowVariable))]
    public static T SetShowVariable<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.ShowVariable, v));
    /// <inheritdoc cref="GitVersionSettings.ShowVariable"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ShowVariable))]
    public static T ResetShowVariable<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.ShowVariable));
    #endregion
    #region LogFile
    /// <inheritdoc cref="GitVersionSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="GitVersionSettings.LogFile"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
    #region ShowConfig
    /// <inheritdoc cref="GitVersionSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ShowConfig))]
    public static T SetShowConfig<T>(this T o, bool? v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.ShowConfig, v));
    /// <inheritdoc cref="GitVersionSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ShowConfig))]
    public static T ResetShowConfig<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.ShowConfig));
    /// <inheritdoc cref="GitVersionSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ShowConfig))]
    public static T EnableShowConfig<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.ShowConfig, true));
    /// <inheritdoc cref="GitVersionSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ShowConfig))]
    public static T DisableShowConfig<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.ShowConfig, false));
    /// <inheritdoc cref="GitVersionSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ShowConfig))]
    public static T ToggleShowConfig<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.ShowConfig, !o.ShowConfig));
    #endregion
    #region ConfigurationOverride
    /// <inheritdoc cref="GitVersionSettings.ConfigurationOverride"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ConfigurationOverride))]
    public static T SetConfigurationOverride<T>(this T o, IDictionary<string, object> v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.ConfigurationOverride, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="GitVersionSettings.ConfigurationOverride"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ConfigurationOverride))]
    public static T SetConfigurationOverride<T>(this T o, string k, object v) where T : GitVersionSettings => o.Modify(b => b.SetDictionary(() => o.ConfigurationOverride, k, v));
    /// <inheritdoc cref="GitVersionSettings.ConfigurationOverride"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ConfigurationOverride))]
    public static T AddConfigurationOverride<T>(this T o, string k, object v) where T : GitVersionSettings => o.Modify(b => b.AddDictionary(() => o.ConfigurationOverride, k, v));
    /// <inheritdoc cref="GitVersionSettings.ConfigurationOverride"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ConfigurationOverride))]
    public static T RemoveConfigurationOverride<T>(this T o, string k) where T : GitVersionSettings => o.Modify(b => b.RemoveDictionary(() => o.ConfigurationOverride, k));
    /// <inheritdoc cref="GitVersionSettings.ConfigurationOverride"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ConfigurationOverride))]
    public static T ClearConfigurationOverride<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.ClearDictionary(() => o.ConfigurationOverride));
    #endregion
    #region NoCache
    /// <inheritdoc cref="GitVersionSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.NoCache))]
    public static T SetNoCache<T>(this T o, bool? v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.NoCache, v));
    /// <inheritdoc cref="GitVersionSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.NoCache))]
    public static T ResetNoCache<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.NoCache));
    /// <inheritdoc cref="GitVersionSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.NoCache))]
    public static T EnableNoCache<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.NoCache, true));
    /// <inheritdoc cref="GitVersionSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.NoCache))]
    public static T DisableNoCache<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.NoCache, false));
    /// <inheritdoc cref="GitVersionSettings.NoCache"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.NoCache))]
    public static T ToggleNoCache<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.NoCache, !o.NoCache));
    #endregion
    #region UpdateAssemblyInfo
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfo"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfo))]
    public static T SetUpdateAssemblyInfo<T>(this T o, bool? v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.UpdateAssemblyInfo, v));
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfo"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfo))]
    public static T ResetUpdateAssemblyInfo<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.UpdateAssemblyInfo));
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfo"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfo))]
    public static T EnableUpdateAssemblyInfo<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.UpdateAssemblyInfo, true));
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfo"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfo))]
    public static T DisableUpdateAssemblyInfo<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.UpdateAssemblyInfo, false));
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfo"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfo))]
    public static T ToggleUpdateAssemblyInfo<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.UpdateAssemblyInfo, !o.UpdateAssemblyInfo));
    #endregion
    #region UpdateAssemblyInfoFileNames
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfoFileNames))]
    public static T SetUpdateAssemblyInfoFileNames<T>(this T o, params string[] v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.UpdateAssemblyInfoFileNames, v));
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfoFileNames))]
    public static T SetUpdateAssemblyInfoFileNames<T>(this T o, IEnumerable<string> v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.UpdateAssemblyInfoFileNames, v));
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfoFileNames))]
    public static T AddUpdateAssemblyInfoFileNames<T>(this T o, params string[] v) where T : GitVersionSettings => o.Modify(b => b.AddCollection(() => o.UpdateAssemblyInfoFileNames, v));
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfoFileNames))]
    public static T AddUpdateAssemblyInfoFileNames<T>(this T o, IEnumerable<string> v) where T : GitVersionSettings => o.Modify(b => b.AddCollection(() => o.UpdateAssemblyInfoFileNames, v));
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfoFileNames))]
    public static T RemoveUpdateAssemblyInfoFileNames<T>(this T o, params string[] v) where T : GitVersionSettings => o.Modify(b => b.RemoveCollection(() => o.UpdateAssemblyInfoFileNames, v));
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfoFileNames))]
    public static T RemoveUpdateAssemblyInfoFileNames<T>(this T o, IEnumerable<string> v) where T : GitVersionSettings => o.Modify(b => b.RemoveCollection(() => o.UpdateAssemblyInfoFileNames, v));
    /// <inheritdoc cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.UpdateAssemblyInfoFileNames))]
    public static T ClearUpdateAssemblyInfoFileNames<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.ClearCollection(() => o.UpdateAssemblyInfoFileNames));
    #endregion
    #region EnsureAssemblyInfo
    /// <inheritdoc cref="GitVersionSettings.EnsureAssemblyInfo"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.EnsureAssemblyInfo))]
    public static T SetEnsureAssemblyInfo<T>(this T o, bool? v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.EnsureAssemblyInfo, v));
    /// <inheritdoc cref="GitVersionSettings.EnsureAssemblyInfo"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.EnsureAssemblyInfo))]
    public static T ResetEnsureAssemblyInfo<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.EnsureAssemblyInfo));
    /// <inheritdoc cref="GitVersionSettings.EnsureAssemblyInfo"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.EnsureAssemblyInfo))]
    public static T EnableEnsureAssemblyInfo<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.EnsureAssemblyInfo, true));
    /// <inheritdoc cref="GitVersionSettings.EnsureAssemblyInfo"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.EnsureAssemblyInfo))]
    public static T DisableEnsureAssemblyInfo<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.EnsureAssemblyInfo, false));
    /// <inheritdoc cref="GitVersionSettings.EnsureAssemblyInfo"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.EnsureAssemblyInfo))]
    public static T ToggleEnsureAssemblyInfo<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.EnsureAssemblyInfo, !o.EnsureAssemblyInfo));
    #endregion
    #region Url
    /// <inheritdoc cref="GitVersionSettings.Url"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Url))]
    public static T SetUrl<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="GitVersionSettings.Url"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Url))]
    public static T ResetUrl<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.Url));
    #endregion
    #region Branch
    /// <inheritdoc cref="GitVersionSettings.Branch"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Branch))]
    public static T SetBranch<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Branch, v));
    /// <inheritdoc cref="GitVersionSettings.Branch"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Branch))]
    public static T ResetBranch<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.Branch));
    #endregion
    #region Username
    /// <inheritdoc cref="GitVersionSettings.Username"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="GitVersionSettings.Username"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Password
    /// <inheritdoc cref="GitVersionSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="GitVersionSettings.Password"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Commit
    /// <inheritdoc cref="GitVersionSettings.Commit"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Commit))]
    public static T SetCommit<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Commit, v));
    /// <inheritdoc cref="GitVersionSettings.Commit"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Commit))]
    public static T ResetCommit<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.Commit));
    #endregion
    #region DynamicRepositoryLocation
    /// <inheritdoc cref="GitVersionSettings.DynamicRepositoryLocation"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.DynamicRepositoryLocation))]
    public static T SetDynamicRepositoryLocation<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.DynamicRepositoryLocation, v));
    /// <inheritdoc cref="GitVersionSettings.DynamicRepositoryLocation"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.DynamicRepositoryLocation))]
    public static T ResetDynamicRepositoryLocation<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.DynamicRepositoryLocation));
    #endregion
    #region NoFetch
    /// <inheritdoc cref="GitVersionSettings.NoFetch"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.NoFetch))]
    public static T SetNoFetch<T>(this T o, bool? v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.NoFetch, v));
    /// <inheritdoc cref="GitVersionSettings.NoFetch"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.NoFetch))]
    public static T ResetNoFetch<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.NoFetch));
    /// <inheritdoc cref="GitVersionSettings.NoFetch"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.NoFetch))]
    public static T EnableNoFetch<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.NoFetch, true));
    /// <inheritdoc cref="GitVersionSettings.NoFetch"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.NoFetch))]
    public static T DisableNoFetch<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.NoFetch, false));
    /// <inheritdoc cref="GitVersionSettings.NoFetch"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.NoFetch))]
    public static T ToggleNoFetch<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.NoFetch, !o.NoFetch));
    #endregion
    #region Executable
    /// <inheritdoc cref="GitVersionSettings.Executable"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Executable))]
    public static T SetExecutable<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Executable, v));
    /// <inheritdoc cref="GitVersionSettings.Executable"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Executable))]
    public static T ResetExecutable<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.Executable));
    #endregion
    #region ExecutableArguments
    /// <inheritdoc cref="GitVersionSettings.ExecutableArguments"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ExecutableArguments))]
    public static T SetExecutableArguments<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.ExecutableArguments, v));
    /// <inheritdoc cref="GitVersionSettings.ExecutableArguments"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.ExecutableArguments))]
    public static T ResetExecutableArguments<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.ExecutableArguments));
    #endregion
    #region MSBuildProject
    /// <inheritdoc cref="GitVersionSettings.MSBuildProject"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.MSBuildProject))]
    public static T SetMSBuildProject<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.MSBuildProject, v));
    /// <inheritdoc cref="GitVersionSettings.MSBuildProject"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.MSBuildProject))]
    public static T ResetMSBuildProject<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.MSBuildProject));
    #endregion
    #region MSBuildProjectArguments
    /// <inheritdoc cref="GitVersionSettings.MSBuildProjectArguments"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.MSBuildProjectArguments))]
    public static T SetMSBuildProjectArguments<T>(this T o, string v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.MSBuildProjectArguments, v));
    /// <inheritdoc cref="GitVersionSettings.MSBuildProjectArguments"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.MSBuildProjectArguments))]
    public static T ResetMSBuildProjectArguments<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.MSBuildProjectArguments));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="GitVersionSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, GitVersionVerbosity v) where T : GitVersionSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="GitVersionSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(GitVersionSettings), Property = nameof(GitVersionSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : GitVersionSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
}
#endregion
#region GitVersionOutput
/// <summary>Used within <see cref="GitVersionTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitVersionOutput>))]
public partial class GitVersionOutput : Enumeration
{
    public static GitVersionOutput json = (GitVersionOutput) "json";
    public static GitVersionOutput buildserver = (GitVersionOutput) "buildserver";
    public static implicit operator GitVersionOutput(string value)
    {
        return new GitVersionOutput { Value = value };
    }
}
#endregion
#region GitVersionVerbosity
/// <summary>Used within <see cref="GitVersionTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<GitVersionVerbosity>))]
public partial class GitVersionVerbosity : Enumeration
{
    public static GitVersionVerbosity debug = (GitVersionVerbosity) "debug";
    public static GitVersionVerbosity info = (GitVersionVerbosity) "info";
    public static GitVersionVerbosity warn = (GitVersionVerbosity) "warn";
    public static GitVersionVerbosity error = (GitVersionVerbosity) "error";
    public static GitVersionVerbosity none = (GitVersionVerbosity) "none";
    public static implicit operator GitVersionVerbosity(string value)
    {
        return new GitVersionVerbosity { Value = value };
    }
}
#endregion

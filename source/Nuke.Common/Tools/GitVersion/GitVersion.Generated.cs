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

namespace Nuke.Common.Tools.GitVersion
{
    /// <summary>
    ///   <p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p>
    ///   <p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(GitVersionPackageId)]
    public partial class GitVersionTasks
        : IRequireNuGetPackage
    {
        public const string GitVersionPackageId = "GitVersion.Tool";
        /// <summary>
        ///   Path to the GitVersion executable.
        /// </summary>
        public static string GitVersionPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("GITVERSION_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> GitVersionLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p>
        ///   <p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> GitVersion(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(GitVersionPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? GitVersionLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p>
        ///   <p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="GitVersionSettings.TargetPath"/></li>
        ///     <li><c>/b</c> via <see cref="GitVersionSettings.Branch"/></li>
        ///     <li><c>/c</c> via <see cref="GitVersionSettings.Commit"/></li>
        ///     <li><c>/diag</c> via <see cref="GitVersionSettings.Diagnostics"/></li>
        ///     <li><c>/dynamicRepoLocation</c> via <see cref="GitVersionSettings.DynamicRepositoryLocation"/></li>
        ///     <li><c>/ensureassemblyinfo</c> via <see cref="GitVersionSettings.EnsureAssemblyInfo"/></li>
        ///     <li><c>/exec</c> via <see cref="GitVersionSettings.Executable"/></li>
        ///     <li><c>/execargs</c> via <see cref="GitVersionSettings.ExecutableArguments"/></li>
        ///     <li><c>/l</c> via <see cref="GitVersionSettings.LogFile"/></li>
        ///     <li><c>/nocache</c> via <see cref="GitVersionSettings.NoCache"/></li>
        ///     <li><c>/nofetch</c> via <see cref="GitVersionSettings.NoFetch"/></li>
        ///     <li><c>/output</c> via <see cref="GitVersionSettings.Output"/></li>
        ///     <li><c>/overrideconfig</c> via <see cref="GitVersionSettings.ConfigurationOverride"/></li>
        ///     <li><c>/p</c> via <see cref="GitVersionSettings.Password"/></li>
        ///     <li><c>/proj</c> via <see cref="GitVersionSettings.MSBuildProject"/></li>
        ///     <li><c>/projargs</c> via <see cref="GitVersionSettings.MSBuildProjectArguments"/></li>
        ///     <li><c>/showconfig</c> via <see cref="GitVersionSettings.ShowConfig"/></li>
        ///     <li><c>/showvariable</c> via <see cref="GitVersionSettings.ShowVariable"/></li>
        ///     <li><c>/u</c> via <see cref="GitVersionSettings.Username"/></li>
        ///     <li><c>/updateassemblyinfo</c> via <see cref="GitVersionSettings.UpdateAssemblyInfo"/></li>
        ///     <li><c>/updateassemblyinfofilename</c> via <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></li>
        ///     <li><c>/url</c> via <see cref="GitVersionSettings.Url"/></li>
        ///     <li><c>/verbosity</c> via <see cref="GitVersionSettings.Verbosity"/></li>
        ///     <li><c>/version</c> via <see cref="GitVersionSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static (GitVersion Result, IReadOnlyCollection<Output> Output) GitVersion(GitVersionSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new GitVersionSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return (GetResult(process, toolSettings), process.Output);
        }
        /// <summary>
        ///   <p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p>
        ///   <p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="GitVersionSettings.TargetPath"/></li>
        ///     <li><c>/b</c> via <see cref="GitVersionSettings.Branch"/></li>
        ///     <li><c>/c</c> via <see cref="GitVersionSettings.Commit"/></li>
        ///     <li><c>/diag</c> via <see cref="GitVersionSettings.Diagnostics"/></li>
        ///     <li><c>/dynamicRepoLocation</c> via <see cref="GitVersionSettings.DynamicRepositoryLocation"/></li>
        ///     <li><c>/ensureassemblyinfo</c> via <see cref="GitVersionSettings.EnsureAssemblyInfo"/></li>
        ///     <li><c>/exec</c> via <see cref="GitVersionSettings.Executable"/></li>
        ///     <li><c>/execargs</c> via <see cref="GitVersionSettings.ExecutableArguments"/></li>
        ///     <li><c>/l</c> via <see cref="GitVersionSettings.LogFile"/></li>
        ///     <li><c>/nocache</c> via <see cref="GitVersionSettings.NoCache"/></li>
        ///     <li><c>/nofetch</c> via <see cref="GitVersionSettings.NoFetch"/></li>
        ///     <li><c>/output</c> via <see cref="GitVersionSettings.Output"/></li>
        ///     <li><c>/overrideconfig</c> via <see cref="GitVersionSettings.ConfigurationOverride"/></li>
        ///     <li><c>/p</c> via <see cref="GitVersionSettings.Password"/></li>
        ///     <li><c>/proj</c> via <see cref="GitVersionSettings.MSBuildProject"/></li>
        ///     <li><c>/projargs</c> via <see cref="GitVersionSettings.MSBuildProjectArguments"/></li>
        ///     <li><c>/showconfig</c> via <see cref="GitVersionSettings.ShowConfig"/></li>
        ///     <li><c>/showvariable</c> via <see cref="GitVersionSettings.ShowVariable"/></li>
        ///     <li><c>/u</c> via <see cref="GitVersionSettings.Username"/></li>
        ///     <li><c>/updateassemblyinfo</c> via <see cref="GitVersionSettings.UpdateAssemblyInfo"/></li>
        ///     <li><c>/updateassemblyinfofilename</c> via <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></li>
        ///     <li><c>/url</c> via <see cref="GitVersionSettings.Url"/></li>
        ///     <li><c>/verbosity</c> via <see cref="GitVersionSettings.Verbosity"/></li>
        ///     <li><c>/version</c> via <see cref="GitVersionSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static (GitVersion Result, IReadOnlyCollection<Output> Output) GitVersion(Configure<GitVersionSettings> configurator)
        {
            return GitVersion(configurator(new GitVersionSettings()));
        }
        /// <summary>
        ///   <p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p>
        ///   <p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="GitVersionSettings.TargetPath"/></li>
        ///     <li><c>/b</c> via <see cref="GitVersionSettings.Branch"/></li>
        ///     <li><c>/c</c> via <see cref="GitVersionSettings.Commit"/></li>
        ///     <li><c>/diag</c> via <see cref="GitVersionSettings.Diagnostics"/></li>
        ///     <li><c>/dynamicRepoLocation</c> via <see cref="GitVersionSettings.DynamicRepositoryLocation"/></li>
        ///     <li><c>/ensureassemblyinfo</c> via <see cref="GitVersionSettings.EnsureAssemblyInfo"/></li>
        ///     <li><c>/exec</c> via <see cref="GitVersionSettings.Executable"/></li>
        ///     <li><c>/execargs</c> via <see cref="GitVersionSettings.ExecutableArguments"/></li>
        ///     <li><c>/l</c> via <see cref="GitVersionSettings.LogFile"/></li>
        ///     <li><c>/nocache</c> via <see cref="GitVersionSettings.NoCache"/></li>
        ///     <li><c>/nofetch</c> via <see cref="GitVersionSettings.NoFetch"/></li>
        ///     <li><c>/output</c> via <see cref="GitVersionSettings.Output"/></li>
        ///     <li><c>/overrideconfig</c> via <see cref="GitVersionSettings.ConfigurationOverride"/></li>
        ///     <li><c>/p</c> via <see cref="GitVersionSettings.Password"/></li>
        ///     <li><c>/proj</c> via <see cref="GitVersionSettings.MSBuildProject"/></li>
        ///     <li><c>/projargs</c> via <see cref="GitVersionSettings.MSBuildProjectArguments"/></li>
        ///     <li><c>/showconfig</c> via <see cref="GitVersionSettings.ShowConfig"/></li>
        ///     <li><c>/showvariable</c> via <see cref="GitVersionSettings.ShowVariable"/></li>
        ///     <li><c>/u</c> via <see cref="GitVersionSettings.Username"/></li>
        ///     <li><c>/updateassemblyinfo</c> via <see cref="GitVersionSettings.UpdateAssemblyInfo"/></li>
        ///     <li><c>/updateassemblyinfofilename</c> via <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></li>
        ///     <li><c>/url</c> via <see cref="GitVersionSettings.Url"/></li>
        ///     <li><c>/verbosity</c> via <see cref="GitVersionSettings.Verbosity"/></li>
        ///     <li><c>/version</c> via <see cref="GitVersionSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(GitVersionSettings Settings, GitVersion Result, IReadOnlyCollection<Output> Output)> GitVersion(CombinatorialConfigure<GitVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(GitVersion, GitVersionLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region GitVersionSettings
    /// <summary>
    ///   Used within <see cref="GitVersionTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitVersionSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the GitVersion executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? GitVersionTasks.GitVersionLogger;
        /// <summary>
        ///   The directory containing .git. If not defined current directory is used. (Must be first argument).
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   Displays the version of GitVersion.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        /// <summary>
        ///   Runs GitVersion with additional diagnostic information (requires git.exe to be installed).
        /// </summary>
        public virtual bool? Diagnostics { get; internal set; }
        /// <summary>
        ///   Determines the output to the console. Can be either <em>json</em> or <em>buildserver</em>, will default to <em>json</em>.
        /// </summary>
        public virtual GitVersionOutput Output { get; internal set; }
        /// <summary>
        ///   Used in conjuntion with <c>/output</c> json, will output just a particular variable. E.g., <c>/output json /showvariable SemVer</c> - will output <c>1.2.3+beta.4</c>.
        /// </summary>
        public virtual string ShowVariable { get; internal set; }
        /// <summary>
        ///   Path to logfile.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        /// <summary>
        ///   Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.
        /// </summary>
        public virtual bool? ShowConfig { get; internal set; }
        /// <summary>
        ///   Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> ConfigurationOverride => ConfigurationOverrideInternal.AsReadOnly();
        internal Dictionary<string, object> ConfigurationOverrideInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Bypasses the cache, result will not be written to the cache.
        /// </summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary>
        ///   Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.
        /// </summary>
        public virtual bool? UpdateAssemblyInfo { get; internal set; }
        /// <summary>
        ///   Specify name of AssemblyInfo files to update.
        /// </summary>
        public virtual IReadOnlyList<string> UpdateAssemblyInfoFileNames => UpdateAssemblyInfoFileNamesInternal.AsReadOnly();
        internal List<string> UpdateAssemblyInfoFileNamesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.
        /// </summary>
        public virtual bool? EnsureAssemblyInfo { get; internal set; }
        /// <summary>
        ///   Url to remote git repository.
        /// </summary>
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   Name of the branch to use on the remote repository, must be used in combination with <c>/url</c>.
        /// </summary>
        public virtual string Branch { get; internal set; }
        /// <summary>
        ///   Username in case authentication is required.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Password in case authentication is required.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   The commit id to check. If not specified, the latest available commit on the specified branch will be used.
        /// </summary>
        public virtual string Commit { get; internal set; }
        /// <summary>
        ///   By default dynamic repositories will be cloned to %tmp%. Use this switch to override.
        /// </summary>
        public virtual string DynamicRepositoryLocation { get; internal set; }
        /// <summary>
        ///   Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.
        /// </summary>
        public virtual bool? NoFetch { get; internal set; }
        /// <summary>
        ///   Executes target executable making GitVersion variables available as environmental variables.
        /// </summary>
        public virtual string Executable { get; internal set; }
        /// <summary>
        ///   Arguments for the executable specified by <c>/exec</c>.
        /// </summary>
        public virtual string ExecutableArguments { get; internal set; }
        /// <summary>
        ///   Build an MSBuild file, GitVersion variables will be passed as MSBuild properties.
        /// </summary>
        public virtual string MSBuildProject { get; internal set; }
        /// <summary>
        ///   Additional arguments to pass to MSBuild.
        /// </summary>
        public virtual string MSBuildProjectArguments { get; internal set; }
        /// <summary>
        ///   Set Verbosity level (<c>debug</c>, <c>info</c>, <c>warn</c>, <c>error</c>, <c>none</c>). Default is <c>info</c>.
        /// </summary>
        public virtual GitVersionVerbosity Verbosity { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", TargetPath)
              .Add("/version", Version)
              .Add("/diag", Diagnostics)
              .Add("/output {value}", Output)
              .Add("/showvariable {value}", ShowVariable)
              .Add("/l {value}", LogFile)
              .Add("/showconfig", ShowConfig)
              .Add("/overrideconfig {value}", ConfigurationOverride, "{key}={value}")
              .Add("/nocache", NoCache)
              .Add("/updateassemblyinfo", UpdateAssemblyInfo)
              .Add("/updateassemblyinfofilename {value}", UpdateAssemblyInfoFileNames, separator: ' ')
              .Add("/ensureassemblyinfo", EnsureAssemblyInfo)
              .Add("/url {value}", Url)
              .Add("/b {value}", Branch)
              .Add("/u {value}", Username)
              .Add("/p {value}", Password, secret: true)
              .Add("/c {value}", Commit)
              .Add("/dynamicRepoLocation {value}", DynamicRepositoryLocation)
              .Add("/nofetch", NoFetch)
              .Add("/exec {value}", Executable)
              .Add("/execargs {value}", ExecutableArguments)
              .Add("/proj {value}", MSBuildProject)
              .Add("/projargs {value}", MSBuildProjectArguments)
              .Add("/verbosity {value}", Verbosity);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region GitVersion
    /// <summary>
    ///   Used within <see cref="GitVersionTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitVersion : ISettingsEntity
    {
        public virtual int Major { get; internal set; }
        public virtual int Minor { get; internal set; }
        public virtual int Patch { get; internal set; }
        public virtual string PreReleaseTag { get; internal set; }
        public virtual string PreReleaseTagWithDash { get; internal set; }
        public virtual string PreReleaseLabel { get; internal set; }
        public virtual string PreReleaseLabelWithDash { get; internal set; }
        public virtual string PreReleaseNumber { get; internal set; }
        public virtual string WeightedPreReleaseNumber { get; internal set; }
        public virtual string BuildMetaData { get; internal set; }
        public virtual string BuildMetaDataPadded { get; internal set; }
        public virtual string FullBuildMetaData { get; internal set; }
        public virtual string MajorMinorPatch { get; internal set; }
        public virtual string SemVer { get; internal set; }
        public virtual string LegacySemVer { get; internal set; }
        public virtual string LegacySemVerPadded { get; internal set; }
        public virtual string AssemblySemVer { get; internal set; }
        public virtual string AssemblySemFileVer { get; internal set; }
        public virtual string FullSemVer { get; internal set; }
        public virtual string InformationalVersion { get; internal set; }
        public virtual string BranchName { get; internal set; }
        public virtual string EscapedBranchName { get; internal set; }
        public virtual string Sha { get; internal set; }
        public virtual string ShortSha { get; internal set; }
        public virtual string NuGetVersionV2 { get; internal set; }
        public virtual string NuGetVersion { get; internal set; }
        public virtual string NuGetPreReleaseTagV2 { get; internal set; }
        public virtual string NuGetPreReleaseTag { get; internal set; }
        public virtual string VersionSourceSha { get; internal set; }
        public virtual string CommitsSinceVersionSource { get; internal set; }
        public virtual string CommitsSinceVersionSourcePadded { get; internal set; }
        public virtual int? UncommittedChanges { get; internal set; }
        public virtual string CommitDate { get; internal set; }
    }
    #endregion
    #region GitVersionSettingsExtensions
    /// <summary>
    ///   Used within <see cref="GitVersionTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitVersionSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.TargetPath"/></em></p>
        ///   <p>The directory containing .git. If not defined current directory is used. (Must be first argument).</p>
        /// </summary>
        [Pure]
        public static T SetTargetPath<T>(this T toolSettings, string targetPath) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.TargetPath"/></em></p>
        ///   <p>The directory containing .git. If not defined current directory is used. (Must be first argument).</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPath<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Version"/></em></p>
        ///   <p>Displays the version of GitVersion.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Version"/></em></p>
        ///   <p>Displays the version of GitVersion.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="GitVersionSettings.Version"/></em></p>
        ///   <p>Displays the version of GitVersion.</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="GitVersionSettings.Version"/></em></p>
        ///   <p>Displays the version of GitVersion.</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="GitVersionSettings.Version"/></em></p>
        ///   <p>Displays the version of GitVersion.</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
        #region Diagnostics
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Diagnostics"/></em></p>
        ///   <p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p>
        /// </summary>
        [Pure]
        public static T SetDiagnostics<T>(this T toolSettings, bool? diagnostics) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = diagnostics;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Diagnostics"/></em></p>
        ///   <p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p>
        /// </summary>
        [Pure]
        public static T ResetDiagnostics<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="GitVersionSettings.Diagnostics"/></em></p>
        ///   <p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p>
        /// </summary>
        [Pure]
        public static T EnableDiagnostics<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="GitVersionSettings.Diagnostics"/></em></p>
        ///   <p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p>
        /// </summary>
        [Pure]
        public static T DisableDiagnostics<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="GitVersionSettings.Diagnostics"/></em></p>
        ///   <p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p>
        /// </summary>
        [Pure]
        public static T ToggleDiagnostics<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = !toolSettings.Diagnostics;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Output"/></em></p>
        ///   <p>Determines the output to the console. Can be either <em>json</em> or <em>buildserver</em>, will default to <em>json</em>.</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, GitVersionOutput output) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Output"/></em></p>
        ///   <p>Determines the output to the console. Can be either <em>json</em> or <em>buildserver</em>, will default to <em>json</em>.</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region ShowVariable
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.ShowVariable"/></em></p>
        ///   <p>Used in conjuntion with <c>/output</c> json, will output just a particular variable. E.g., <c>/output json /showvariable SemVer</c> - will output <c>1.2.3+beta.4</c>.</p>
        /// </summary>
        [Pure]
        public static T SetShowVariable<T>(this T toolSettings, string showVariable) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowVariable = showVariable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.ShowVariable"/></em></p>
        ///   <p>Used in conjuntion with <c>/output</c> json, will output just a particular variable. E.g., <c>/output json /showvariable SemVer</c> - will output <c>1.2.3+beta.4</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetShowVariable<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowVariable = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.LogFile"/></em></p>
        ///   <p>Path to logfile.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.LogFile"/></em></p>
        ///   <p>Path to logfile.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region ShowConfig
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.ShowConfig"/></em></p>
        ///   <p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p>
        /// </summary>
        [Pure]
        public static T SetShowConfig<T>(this T toolSettings, bool? showConfig) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowConfig = showConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.ShowConfig"/></em></p>
        ///   <p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p>
        /// </summary>
        [Pure]
        public static T ResetShowConfig<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowConfig = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="GitVersionSettings.ShowConfig"/></em></p>
        ///   <p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p>
        /// </summary>
        [Pure]
        public static T EnableShowConfig<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowConfig = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="GitVersionSettings.ShowConfig"/></em></p>
        ///   <p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p>
        /// </summary>
        [Pure]
        public static T DisableShowConfig<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowConfig = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="GitVersionSettings.ShowConfig"/></em></p>
        ///   <p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p>
        /// </summary>
        [Pure]
        public static T ToggleShowConfig<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowConfig = !toolSettings.ShowConfig;
            return toolSettings;
        }
        #endregion
        #region ConfigurationOverride
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.ConfigurationOverride"/> to a new dictionary</em></p>
        ///   <p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p>
        /// </summary>
        [Pure]
        public static T SetConfigurationOverride<T>(this T toolSettings, IDictionary<string, object> configurationOverride) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationOverrideInternal = configurationOverride.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="GitVersionSettings.ConfigurationOverride"/></em></p>
        ///   <p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearConfigurationOverride<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationOverrideInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="GitVersionSettings.ConfigurationOverride"/></em></p>
        ///   <p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p>
        /// </summary>
        [Pure]
        public static T AddConfigurationOverride<T>(this T toolSettings, string configurationOverrideKey, object configurationOverrideValue) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationOverrideInternal.Add(configurationOverrideKey, configurationOverrideValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="GitVersionSettings.ConfigurationOverride"/></em></p>
        ///   <p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveConfigurationOverride<T>(this T toolSettings, string configurationOverrideKey) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationOverrideInternal.Remove(configurationOverrideKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="GitVersionSettings.ConfigurationOverride"/></em></p>
        ///   <p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p>
        /// </summary>
        [Pure]
        public static T SetConfigurationOverride<T>(this T toolSettings, string configurationOverrideKey, object configurationOverrideValue) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationOverrideInternal[configurationOverrideKey] = configurationOverrideValue;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.NoCache"/></em></p>
        ///   <p>Bypasses the cache, result will not be written to the cache.</p>
        /// </summary>
        [Pure]
        public static T SetNoCache<T>(this T toolSettings, bool? noCache) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.NoCache"/></em></p>
        ///   <p>Bypasses the cache, result will not be written to the cache.</p>
        /// </summary>
        [Pure]
        public static T ResetNoCache<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="GitVersionSettings.NoCache"/></em></p>
        ///   <p>Bypasses the cache, result will not be written to the cache.</p>
        /// </summary>
        [Pure]
        public static T EnableNoCache<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="GitVersionSettings.NoCache"/></em></p>
        ///   <p>Bypasses the cache, result will not be written to the cache.</p>
        /// </summary>
        [Pure]
        public static T DisableNoCache<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="GitVersionSettings.NoCache"/></em></p>
        ///   <p>Bypasses the cache, result will not be written to the cache.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoCache<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region UpdateAssemblyInfo
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.UpdateAssemblyInfo"/></em></p>
        ///   <p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p>
        /// </summary>
        [Pure]
        public static T SetUpdateAssemblyInfo<T>(this T toolSettings, bool? updateAssemblyInfo) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = updateAssemblyInfo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.UpdateAssemblyInfo"/></em></p>
        ///   <p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p>
        /// </summary>
        [Pure]
        public static T ResetUpdateAssemblyInfo<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="GitVersionSettings.UpdateAssemblyInfo"/></em></p>
        ///   <p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p>
        /// </summary>
        [Pure]
        public static T EnableUpdateAssemblyInfo<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="GitVersionSettings.UpdateAssemblyInfo"/></em></p>
        ///   <p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p>
        /// </summary>
        [Pure]
        public static T DisableUpdateAssemblyInfo<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="GitVersionSettings.UpdateAssemblyInfo"/></em></p>
        ///   <p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p>
        /// </summary>
        [Pure]
        public static T ToggleUpdateAssemblyInfo<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = !toolSettings.UpdateAssemblyInfo;
            return toolSettings;
        }
        #endregion
        #region UpdateAssemblyInfoFileNames
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/> to a new list</em></p>
        ///   <p>Specify name of AssemblyInfo files to update.</p>
        /// </summary>
        [Pure]
        public static T SetUpdateAssemblyInfoFileNames<T>(this T toolSettings, params string[] updateAssemblyInfoFileNames) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfoFileNamesInternal = updateAssemblyInfoFileNames.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/> to a new list</em></p>
        ///   <p>Specify name of AssemblyInfo files to update.</p>
        /// </summary>
        [Pure]
        public static T SetUpdateAssemblyInfoFileNames<T>(this T toolSettings, IEnumerable<string> updateAssemblyInfoFileNames) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfoFileNamesInternal = updateAssemblyInfoFileNames.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></em></p>
        ///   <p>Specify name of AssemblyInfo files to update.</p>
        /// </summary>
        [Pure]
        public static T AddUpdateAssemblyInfoFileNames<T>(this T toolSettings, params string[] updateAssemblyInfoFileNames) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfoFileNamesInternal.AddRange(updateAssemblyInfoFileNames);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></em></p>
        ///   <p>Specify name of AssemblyInfo files to update.</p>
        /// </summary>
        [Pure]
        public static T AddUpdateAssemblyInfoFileNames<T>(this T toolSettings, IEnumerable<string> updateAssemblyInfoFileNames) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfoFileNamesInternal.AddRange(updateAssemblyInfoFileNames);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></em></p>
        ///   <p>Specify name of AssemblyInfo files to update.</p>
        /// </summary>
        [Pure]
        public static T ClearUpdateAssemblyInfoFileNames<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfoFileNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></em></p>
        ///   <p>Specify name of AssemblyInfo files to update.</p>
        /// </summary>
        [Pure]
        public static T RemoveUpdateAssemblyInfoFileNames<T>(this T toolSettings, params string[] updateAssemblyInfoFileNames) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(updateAssemblyInfoFileNames);
            toolSettings.UpdateAssemblyInfoFileNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="GitVersionSettings.UpdateAssemblyInfoFileNames"/></em></p>
        ///   <p>Specify name of AssemblyInfo files to update.</p>
        /// </summary>
        [Pure]
        public static T RemoveUpdateAssemblyInfoFileNames<T>(this T toolSettings, IEnumerable<string> updateAssemblyInfoFileNames) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(updateAssemblyInfoFileNames);
            toolSettings.UpdateAssemblyInfoFileNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region EnsureAssemblyInfo
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.EnsureAssemblyInfo"/></em></p>
        ///   <p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p>
        /// </summary>
        [Pure]
        public static T SetEnsureAssemblyInfo<T>(this T toolSettings, bool? ensureAssemblyInfo) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnsureAssemblyInfo = ensureAssemblyInfo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.EnsureAssemblyInfo"/></em></p>
        ///   <p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p>
        /// </summary>
        [Pure]
        public static T ResetEnsureAssemblyInfo<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnsureAssemblyInfo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="GitVersionSettings.EnsureAssemblyInfo"/></em></p>
        ///   <p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p>
        /// </summary>
        [Pure]
        public static T EnableEnsureAssemblyInfo<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnsureAssemblyInfo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="GitVersionSettings.EnsureAssemblyInfo"/></em></p>
        ///   <p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p>
        /// </summary>
        [Pure]
        public static T DisableEnsureAssemblyInfo<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnsureAssemblyInfo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="GitVersionSettings.EnsureAssemblyInfo"/></em></p>
        ///   <p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p>
        /// </summary>
        [Pure]
        public static T ToggleEnsureAssemblyInfo<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnsureAssemblyInfo = !toolSettings.EnsureAssemblyInfo;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Url"/></em></p>
        ///   <p>Url to remote git repository.</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Url"/></em></p>
        ///   <p>Url to remote git repository.</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region Branch
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Branch"/></em></p>
        ///   <p>Name of the branch to use on the remote repository, must be used in combination with <c>/url</c>.</p>
        /// </summary>
        [Pure]
        public static T SetBranch<T>(this T toolSettings, string branch) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Branch = branch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Branch"/></em></p>
        ///   <p>Name of the branch to use on the remote repository, must be used in combination with <c>/url</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetBranch<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Branch = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Username"/></em></p>
        ///   <p>Username in case authentication is required.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Username"/></em></p>
        ///   <p>Username in case authentication is required.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Password"/></em></p>
        ///   <p>Password in case authentication is required.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, [Secret] string password) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Password"/></em></p>
        ///   <p>Password in case authentication is required.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Commit
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Commit"/></em></p>
        ///   <p>The commit id to check. If not specified, the latest available commit on the specified branch will be used.</p>
        /// </summary>
        [Pure]
        public static T SetCommit<T>(this T toolSettings, string commit) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Commit = commit;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Commit"/></em></p>
        ///   <p>The commit id to check. If not specified, the latest available commit on the specified branch will be used.</p>
        /// </summary>
        [Pure]
        public static T ResetCommit<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Commit = null;
            return toolSettings;
        }
        #endregion
        #region DynamicRepositoryLocation
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.DynamicRepositoryLocation"/></em></p>
        ///   <p>By default dynamic repositories will be cloned to %tmp%. Use this switch to override.</p>
        /// </summary>
        [Pure]
        public static T SetDynamicRepositoryLocation<T>(this T toolSettings, string dynamicRepositoryLocation) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicRepositoryLocation = dynamicRepositoryLocation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.DynamicRepositoryLocation"/></em></p>
        ///   <p>By default dynamic repositories will be cloned to %tmp%. Use this switch to override.</p>
        /// </summary>
        [Pure]
        public static T ResetDynamicRepositoryLocation<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicRepositoryLocation = null;
            return toolSettings;
        }
        #endregion
        #region NoFetch
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.NoFetch"/></em></p>
        ///   <p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p>
        /// </summary>
        [Pure]
        public static T SetNoFetch<T>(this T toolSettings, bool? noFetch) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoFetch = noFetch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.NoFetch"/></em></p>
        ///   <p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p>
        /// </summary>
        [Pure]
        public static T ResetNoFetch<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoFetch = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="GitVersionSettings.NoFetch"/></em></p>
        ///   <p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p>
        /// </summary>
        [Pure]
        public static T EnableNoFetch<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoFetch = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="GitVersionSettings.NoFetch"/></em></p>
        ///   <p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p>
        /// </summary>
        [Pure]
        public static T DisableNoFetch<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoFetch = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="GitVersionSettings.NoFetch"/></em></p>
        ///   <p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoFetch<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoFetch = !toolSettings.NoFetch;
            return toolSettings;
        }
        #endregion
        #region Executable
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Executable"/></em></p>
        ///   <p>Executes target executable making GitVersion variables available as environmental variables.</p>
        /// </summary>
        [Pure]
        public static T SetExecutable<T>(this T toolSettings, string executable) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Executable = executable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Executable"/></em></p>
        ///   <p>Executes target executable making GitVersion variables available as environmental variables.</p>
        /// </summary>
        [Pure]
        public static T ResetExecutable<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Executable = null;
            return toolSettings;
        }
        #endregion
        #region ExecutableArguments
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.ExecutableArguments"/></em></p>
        ///   <p>Arguments for the executable specified by <c>/exec</c>.</p>
        /// </summary>
        [Pure]
        public static T SetExecutableArguments<T>(this T toolSettings, string executableArguments) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExecutableArguments = executableArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.ExecutableArguments"/></em></p>
        ///   <p>Arguments for the executable specified by <c>/exec</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetExecutableArguments<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExecutableArguments = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildProject
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.MSBuildProject"/></em></p>
        ///   <p>Build an MSBuild file, GitVersion variables will be passed as MSBuild properties.</p>
        /// </summary>
        [Pure]
        public static T SetMSBuildProject<T>(this T toolSettings, string msbuildProject) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProject = msbuildProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.MSBuildProject"/></em></p>
        ///   <p>Build an MSBuild file, GitVersion variables will be passed as MSBuild properties.</p>
        /// </summary>
        [Pure]
        public static T ResetMSBuildProject<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProject = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildProjectArguments
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.MSBuildProjectArguments"/></em></p>
        ///   <p>Additional arguments to pass to MSBuild.</p>
        /// </summary>
        [Pure]
        public static T SetMSBuildProjectArguments<T>(this T toolSettings, string msbuildProjectArguments) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProjectArguments = msbuildProjectArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.MSBuildProjectArguments"/></em></p>
        ///   <p>Additional arguments to pass to MSBuild.</p>
        /// </summary>
        [Pure]
        public static T ResetMSBuildProjectArguments<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProjectArguments = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Verbosity"/></em></p>
        ///   <p>Set Verbosity level (<c>debug</c>, <c>info</c>, <c>warn</c>, <c>error</c>, <c>none</c>). Default is <c>info</c>.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, GitVersionVerbosity verbosity) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Verbosity"/></em></p>
        ///   <p>Set Verbosity level (<c>debug</c>, <c>info</c>, <c>warn</c>, <c>error</c>, <c>none</c>). Default is <c>info</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="GitVersionSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="GitVersionSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : GitVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region GitVersionOutput
    /// <summary>
    ///   Used within <see cref="GitVersionTasks"/>.
    /// </summary>
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
    /// <summary>
    ///   Used within <see cref="GitVersionTasks"/>.
    /// </summary>
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
}

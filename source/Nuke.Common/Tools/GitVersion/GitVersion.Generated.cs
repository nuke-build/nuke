// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/GitVersion.json
// Generated with Nuke.CodeGeneration version LOCAL (OSX,.NETStandard,Version=v2.0)

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

namespace Nuke.Common.Tools.GitVersion
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitVersionTasks
    {
        /// <summary><p>Path to the GitVersion executable.</p></summary>
        public static string GitVersionPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("GITVERSION_EXE") ??
            GetToolPath();
        /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p></summary>
        public static IReadOnlyCollection<Output> GitVersion(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(GitVersionPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, null, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>GitVersion is a tool to help you achieve Semantic Versioning on your project.</p><p>For more details, visit the <a href="http://gitversion.readthedocs.io/en/stable/">official website</a>.</p></summary>
        public static (GitVersion Result, IReadOnlyCollection<Output> Output) GitVersion(Configure<GitVersionSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new GitVersionSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return (GetResult(process, toolSettings), process.Output);
        }
    }
    #region GitVersionSettings
    /// <summary><p>Used within <see cref="GitVersionTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class GitVersionSettings : ToolSettings
    {
        /// <summary><p>Path to the GitVersion executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? GitVersionTasks.GitVersionPath;
        /// <summary><p>The directory containing .git. If not defined current directory is used. (Must be first argument).</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>Displays the version of GitVersion.</p></summary>
        public virtual bool? Version { get; internal set; }
        /// <summary><p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p></summary>
        public virtual bool? Diagnostics { get; internal set; }
        /// <summary><p>Determines the output to the console. Can be either <em>json</em> or <em>buildserver</em>, will default to <em>json</em>.</p></summary>
        public virtual GitVersionOutput Output { get; internal set; }
        /// <summary><p>Used in conjuntion with <c>/output</c> json, will output just a particular variable. E.g., <c>/output json /showvariable SemVer</c> - will output <c>1.2.3+beta.4</c>.</p></summary>
        public virtual string ShowVariable { get; internal set; }
        /// <summary><p>Path to logfile.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p></summary>
        public virtual bool? ShowConfig { get; internal set; }
        /// <summary><p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p></summary>
        public virtual IReadOnlyDictionary<string, object> ConfigurationOverride => ConfigurationOverrideInternal.AsReadOnly();
        internal Dictionary<string, object> ConfigurationOverrideInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Bypasses the cache, result will not be written to the cache.</p></summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary><p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p></summary>
        public virtual bool? UpdateAssemblyInfo { get; internal set; }
        /// <summary><p>Specify name of AssemblyInfo file.</p></summary>
        public virtual bool? UpdateAssemblyInfoFileName { get; internal set; }
        /// <summary><p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p></summary>
        public virtual bool? EnsureAssemblyInfo { get; internal set; }
        /// <summary><p>Url to remote git repository.</p></summary>
        public virtual string Url { get; internal set; }
        /// <summary><p>Name of the branch to use on the remote repository, must be used in combination with <c>/url</c>.</p></summary>
        public virtual string Branch { get; internal set; }
        /// <summary><p>Username in case authentication is required.</p></summary>
        public virtual string Username { get; internal set; }
        /// <summary><p>Password in case authentication is required.</p></summary>
        public virtual string Password { get; internal set; }
        /// <summary><p>The commit id to check. If not specified, the latest available commit on the specified branch will be used.</p></summary>
        public virtual string Commit { get; internal set; }
        /// <summary><p>By default dynamic repositories will be cloned to %tmp%. Use this switch to override.</p></summary>
        public virtual string DynamicRepositoryLocation { get; internal set; }
        /// <summary><p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p></summary>
        public virtual bool? NoFetch { get; internal set; }
        /// <summary><p>Executes target executable making GitVersion variables available as environmental variables.</p></summary>
        public virtual string Executable { get; internal set; }
        /// <summary><p>Arguments for the executable specified by <c>/exec</c>.</p></summary>
        public virtual string ExecutableArguments { get; internal set; }
        /// <summary><p>Build an MSBuild file, GitVersion variables will be passed as MSBuild properties.</p></summary>
        public virtual string MSBuildProject { get; internal set; }
        /// <summary><p>Additional arguments to pass to MSBuild.</p></summary>
        public virtual string MSBuildProjectArguments { get; internal set; }
        /// <summary><p>Set Verbosity level (<c>debug</c>, <c>info</c>, <c>warn</c>, <c>error</c>, <c>none</c>). Default is <c>info</c>.</p></summary>
        public virtual GitVersionVerbosity Verbosity { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
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
              .Add("/updateassemblyinfofilename {value}", UpdateAssemblyInfoFileName)
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
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region GitVersion
    /// <summary><p>Used within <see cref="GitVersionTasks"/>.</p></summary>
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
        public virtual string PreReleaseNumber { get; internal set; }
        public virtual string BuildMetaData { get; internal set; }
        public virtual string BuildMetaDataPadded { get; internal set; }
        public virtual string FullBuildMetaData { get; internal set; }
        public virtual string MajorMinorPatch { get; internal set; }
        public virtual string SemVer { get; internal set; }
        public virtual string LegacySemVer { get; internal set; }
        public virtual string LegacySemVerPadded { get; internal set; }
        public virtual string AssemblySemVer { get; internal set; }
        public virtual string FullSemVer { get; internal set; }
        public virtual string InformationalVersion { get; internal set; }
        public virtual string BranchName { get; internal set; }
        public virtual string Sha { get; internal set; }
        public virtual string NuGetVersionV2 { get; internal set; }
        public virtual string NuGetVersion { get; internal set; }
        public virtual string NuGetPreReleaseTagV2 { get; internal set; }
        public virtual string NuGetPreReleaseTag { get; internal set; }
        public virtual string CommitsSinceVersionSource { get; internal set; }
        public virtual string CommitsSinceVersionSourcePadded { get; internal set; }
        public virtual string CommitDate { get; internal set; }
    }
    #endregion
    #region GitVersionSettingsExtensions
    /// <summary><p>Used within <see cref="GitVersionTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitVersionSettingsExtensions
    {
        #region TargetPath
        /// <summary><p><em>Sets <see cref="GitVersionSettings.TargetPath"/>.</em></p><p>The directory containing .git. If not defined current directory is used. (Must be first argument).</p></summary>
        [Pure]
        public static GitVersionSettings SetTargetPath(this GitVersionSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.TargetPath"/>.</em></p><p>The directory containing .git. If not defined current directory is used. (Must be first argument).</p></summary>
        [Pure]
        public static GitVersionSettings ResetTargetPath(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary><p><em>Sets <see cref="GitVersionSettings.Version"/>.</em></p><p>Displays the version of GitVersion.</p></summary>
        [Pure]
        public static GitVersionSettings SetVersion(this GitVersionSettings toolSettings, bool? version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.Version"/>.</em></p><p>Displays the version of GitVersion.</p></summary>
        [Pure]
        public static GitVersionSettings ResetVersion(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitVersionSettings.Version"/>.</em></p><p>Displays the version of GitVersion.</p></summary>
        [Pure]
        public static GitVersionSettings EnableVersion(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitVersionSettings.Version"/>.</em></p><p>Displays the version of GitVersion.</p></summary>
        [Pure]
        public static GitVersionSettings DisableVersion(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitVersionSettings.Version"/>.</em></p><p>Displays the version of GitVersion.</p></summary>
        [Pure]
        public static GitVersionSettings ToggleVersion(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
        #region Diagnostics
        /// <summary><p><em>Sets <see cref="GitVersionSettings.Diagnostics"/>.</em></p><p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p></summary>
        [Pure]
        public static GitVersionSettings SetDiagnostics(this GitVersionSettings toolSettings, bool? diagnostics)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = diagnostics;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.Diagnostics"/>.</em></p><p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p></summary>
        [Pure]
        public static GitVersionSettings ResetDiagnostics(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitVersionSettings.Diagnostics"/>.</em></p><p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p></summary>
        [Pure]
        public static GitVersionSettings EnableDiagnostics(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitVersionSettings.Diagnostics"/>.</em></p><p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p></summary>
        [Pure]
        public static GitVersionSettings DisableDiagnostics(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitVersionSettings.Diagnostics"/>.</em></p><p>Runs GitVersion with additional diagnostic information (requires git.exe to be installed).</p></summary>
        [Pure]
        public static GitVersionSettings ToggleDiagnostics(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Diagnostics = !toolSettings.Diagnostics;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary><p><em>Sets <see cref="GitVersionSettings.Output"/>.</em></p><p>Determines the output to the console. Can be either <em>json</em> or <em>buildserver</em>, will default to <em>json</em>.</p></summary>
        [Pure]
        public static GitVersionSettings SetOutput(this GitVersionSettings toolSettings, GitVersionOutput output)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.Output"/>.</em></p><p>Determines the output to the console. Can be either <em>json</em> or <em>buildserver</em>, will default to <em>json</em>.</p></summary>
        [Pure]
        public static GitVersionSettings ResetOutput(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region ShowVariable
        /// <summary><p><em>Sets <see cref="GitVersionSettings.ShowVariable"/>.</em></p><p>Used in conjuntion with <c>/output</c> json, will output just a particular variable. E.g., <c>/output json /showvariable SemVer</c> - will output <c>1.2.3+beta.4</c>.</p></summary>
        [Pure]
        public static GitVersionSettings SetShowVariable(this GitVersionSettings toolSettings, string showVariable)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowVariable = showVariable;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.ShowVariable"/>.</em></p><p>Used in conjuntion with <c>/output</c> json, will output just a particular variable. E.g., <c>/output json /showvariable SemVer</c> - will output <c>1.2.3+beta.4</c>.</p></summary>
        [Pure]
        public static GitVersionSettings ResetShowVariable(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowVariable = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary><p><em>Sets <see cref="GitVersionSettings.LogFile"/>.</em></p><p>Path to logfile.</p></summary>
        [Pure]
        public static GitVersionSettings SetLogFile(this GitVersionSettings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.LogFile"/>.</em></p><p>Path to logfile.</p></summary>
        [Pure]
        public static GitVersionSettings ResetLogFile(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region ShowConfig
        /// <summary><p><em>Sets <see cref="GitVersionSettings.ShowConfig"/>.</em></p><p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p></summary>
        [Pure]
        public static GitVersionSettings SetShowConfig(this GitVersionSettings toolSettings, bool? showConfig)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowConfig = showConfig;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.ShowConfig"/>.</em></p><p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p></summary>
        [Pure]
        public static GitVersionSettings ResetShowConfig(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowConfig = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitVersionSettings.ShowConfig"/>.</em></p><p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p></summary>
        [Pure]
        public static GitVersionSettings EnableShowConfig(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowConfig = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitVersionSettings.ShowConfig"/>.</em></p><p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p></summary>
        [Pure]
        public static GitVersionSettings DisableShowConfig(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowConfig = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitVersionSettings.ShowConfig"/>.</em></p><p>Outputs the effective GitVersion config (defaults + custom from GitVersion.yml) in yaml format.</p></summary>
        [Pure]
        public static GitVersionSettings ToggleShowConfig(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowConfig = !toolSettings.ShowConfig;
            return toolSettings;
        }
        #endregion
        #region ConfigurationOverride
        /// <summary><p><em>Sets <see cref="GitVersionSettings.ConfigurationOverride"/> to a new dictionary.</em></p><p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p></summary>
        [Pure]
        public static GitVersionSettings SetConfigurationOverride(this GitVersionSettings toolSettings, IDictionary<string, object> configurationOverride)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationOverrideInternal = configurationOverride.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="GitVersionSettings.ConfigurationOverride"/>.</em></p><p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p></summary>
        [Pure]
        public static GitVersionSettings ClearConfigurationOverride(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationOverrideInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="GitVersionSettings.ConfigurationOverride"/>.</em></p><p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p></summary>
        [Pure]
        public static GitVersionSettings AddConfigurationOverride(this GitVersionSettings toolSettings, string configurationOverrideKey, object configurationOverrideValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationOverrideInternal.Add(configurationOverrideKey, configurationOverrideValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="GitVersionSettings.ConfigurationOverride"/>.</em></p><p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p></summary>
        [Pure]
        public static GitVersionSettings RemoveConfigurationOverride(this GitVersionSettings toolSettings, string configurationOverrideKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationOverrideInternal.Remove(configurationOverrideKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="GitVersionSettings.ConfigurationOverride"/>.</em></p><p>Overrides GitVersion config values inline (semicolon-separated key value pairs e.g. <c>/overrideconfig tag-prefix=Foo</c>). Currently supported config overrides: <c>tag-prefix</c>.</p></summary>
        [Pure]
        public static GitVersionSettings SetConfigurationOverride(this GitVersionSettings toolSettings, string configurationOverrideKey, object configurationOverrideValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationOverrideInternal[configurationOverrideKey] = configurationOverrideValue;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary><p><em>Sets <see cref="GitVersionSettings.NoCache"/>.</em></p><p>Bypasses the cache, result will not be written to the cache.</p></summary>
        [Pure]
        public static GitVersionSettings SetNoCache(this GitVersionSettings toolSettings, bool? noCache)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.NoCache"/>.</em></p><p>Bypasses the cache, result will not be written to the cache.</p></summary>
        [Pure]
        public static GitVersionSettings ResetNoCache(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitVersionSettings.NoCache"/>.</em></p><p>Bypasses the cache, result will not be written to the cache.</p></summary>
        [Pure]
        public static GitVersionSettings EnableNoCache(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitVersionSettings.NoCache"/>.</em></p><p>Bypasses the cache, result will not be written to the cache.</p></summary>
        [Pure]
        public static GitVersionSettings DisableNoCache(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitVersionSettings.NoCache"/>.</em></p><p>Bypasses the cache, result will not be written to the cache.</p></summary>
        [Pure]
        public static GitVersionSettings ToggleNoCache(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region UpdateAssemblyInfo
        /// <summary><p><em>Sets <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p><p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p></summary>
        [Pure]
        public static GitVersionSettings SetUpdateAssemblyInfo(this GitVersionSettings toolSettings, bool? updateAssemblyInfo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = updateAssemblyInfo;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p><p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p></summary>
        [Pure]
        public static GitVersionSettings ResetUpdateAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p><p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p></summary>
        [Pure]
        public static GitVersionSettings EnableUpdateAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p><p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p></summary>
        [Pure]
        public static GitVersionSettings DisableUpdateAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitVersionSettings.UpdateAssemblyInfo"/>.</em></p><p>Will recursively search for all 'AssemblyInfo.cs' files in the git repo and update them.</p></summary>
        [Pure]
        public static GitVersionSettings ToggleUpdateAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfo = !toolSettings.UpdateAssemblyInfo;
            return toolSettings;
        }
        #endregion
        #region UpdateAssemblyInfoFileName
        /// <summary><p><em>Sets <see cref="GitVersionSettings.UpdateAssemblyInfoFileName"/>.</em></p><p>Specify name of AssemblyInfo file.</p></summary>
        [Pure]
        public static GitVersionSettings SetUpdateAssemblyInfoFileName(this GitVersionSettings toolSettings, bool? updateAssemblyInfoFileName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfoFileName = updateAssemblyInfoFileName;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.UpdateAssemblyInfoFileName"/>.</em></p><p>Specify name of AssemblyInfo file.</p></summary>
        [Pure]
        public static GitVersionSettings ResetUpdateAssemblyInfoFileName(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfoFileName = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitVersionSettings.UpdateAssemblyInfoFileName"/>.</em></p><p>Specify name of AssemblyInfo file.</p></summary>
        [Pure]
        public static GitVersionSettings EnableUpdateAssemblyInfoFileName(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfoFileName = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitVersionSettings.UpdateAssemblyInfoFileName"/>.</em></p><p>Specify name of AssemblyInfo file.</p></summary>
        [Pure]
        public static GitVersionSettings DisableUpdateAssemblyInfoFileName(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfoFileName = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitVersionSettings.UpdateAssemblyInfoFileName"/>.</em></p><p>Specify name of AssemblyInfo file.</p></summary>
        [Pure]
        public static GitVersionSettings ToggleUpdateAssemblyInfoFileName(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateAssemblyInfoFileName = !toolSettings.UpdateAssemblyInfoFileName;
            return toolSettings;
        }
        #endregion
        #region EnsureAssemblyInfo
        /// <summary><p><em>Sets <see cref="GitVersionSettings.EnsureAssemblyInfo"/>.</em></p><p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p></summary>
        [Pure]
        public static GitVersionSettings SetEnsureAssemblyInfo(this GitVersionSettings toolSettings, bool? ensureAssemblyInfo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnsureAssemblyInfo = ensureAssemblyInfo;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.EnsureAssemblyInfo"/>.</em></p><p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p></summary>
        [Pure]
        public static GitVersionSettings ResetEnsureAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnsureAssemblyInfo = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitVersionSettings.EnsureAssemblyInfo"/>.</em></p><p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p></summary>
        [Pure]
        public static GitVersionSettings EnableEnsureAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnsureAssemblyInfo = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitVersionSettings.EnsureAssemblyInfo"/>.</em></p><p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p></summary>
        [Pure]
        public static GitVersionSettings DisableEnsureAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnsureAssemblyInfo = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitVersionSettings.EnsureAssemblyInfo"/>.</em></p><p>If the assembly info file specified with <c>/updateassemblyinfo</c> or <c>/updateassemblyinfofilename</c> is not found, it will be created with these attributes: AssemblyFileVersion, AssemblyVersion and AssemblyInformationalVersion.</p></summary>
        [Pure]
        public static GitVersionSettings ToggleEnsureAssemblyInfo(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnsureAssemblyInfo = !toolSettings.EnsureAssemblyInfo;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary><p><em>Sets <see cref="GitVersionSettings.Url"/>.</em></p><p>Url to remote git repository.</p></summary>
        [Pure]
        public static GitVersionSettings SetUrl(this GitVersionSettings toolSettings, string url)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.Url"/>.</em></p><p>Url to remote git repository.</p></summary>
        [Pure]
        public static GitVersionSettings ResetUrl(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region Branch
        /// <summary><p><em>Sets <see cref="GitVersionSettings.Branch"/>.</em></p><p>Name of the branch to use on the remote repository, must be used in combination with <c>/url</c>.</p></summary>
        [Pure]
        public static GitVersionSettings SetBranch(this GitVersionSettings toolSettings, string branch)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Branch = branch;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.Branch"/>.</em></p><p>Name of the branch to use on the remote repository, must be used in combination with <c>/url</c>.</p></summary>
        [Pure]
        public static GitVersionSettings ResetBranch(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Branch = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary><p><em>Sets <see cref="GitVersionSettings.Username"/>.</em></p><p>Username in case authentication is required.</p></summary>
        [Pure]
        public static GitVersionSettings SetUsername(this GitVersionSettings toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.Username"/>.</em></p><p>Username in case authentication is required.</p></summary>
        [Pure]
        public static GitVersionSettings ResetUsername(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary><p><em>Sets <see cref="GitVersionSettings.Password"/>.</em></p><p>Password in case authentication is required.</p></summary>
        [Pure]
        public static GitVersionSettings SetPassword(this GitVersionSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.Password"/>.</em></p><p>Password in case authentication is required.</p></summary>
        [Pure]
        public static GitVersionSettings ResetPassword(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Commit
        /// <summary><p><em>Sets <see cref="GitVersionSettings.Commit"/>.</em></p><p>The commit id to check. If not specified, the latest available commit on the specified branch will be used.</p></summary>
        [Pure]
        public static GitVersionSettings SetCommit(this GitVersionSettings toolSettings, string commit)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Commit = commit;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.Commit"/>.</em></p><p>The commit id to check. If not specified, the latest available commit on the specified branch will be used.</p></summary>
        [Pure]
        public static GitVersionSettings ResetCommit(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Commit = null;
            return toolSettings;
        }
        #endregion
        #region DynamicRepositoryLocation
        /// <summary><p><em>Sets <see cref="GitVersionSettings.DynamicRepositoryLocation"/>.</em></p><p>By default dynamic repositories will be cloned to %tmp%. Use this switch to override.</p></summary>
        [Pure]
        public static GitVersionSettings SetDynamicRepositoryLocation(this GitVersionSettings toolSettings, string dynamicRepositoryLocation)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicRepositoryLocation = dynamicRepositoryLocation;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.DynamicRepositoryLocation"/>.</em></p><p>By default dynamic repositories will be cloned to %tmp%. Use this switch to override.</p></summary>
        [Pure]
        public static GitVersionSettings ResetDynamicRepositoryLocation(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DynamicRepositoryLocation = null;
            return toolSettings;
        }
        #endregion
        #region NoFetch
        /// <summary><p><em>Sets <see cref="GitVersionSettings.NoFetch"/>.</em></p><p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p></summary>
        [Pure]
        public static GitVersionSettings SetNoFetch(this GitVersionSettings toolSettings, bool? noFetch)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoFetch = noFetch;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.NoFetch"/>.</em></p><p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p></summary>
        [Pure]
        public static GitVersionSettings ResetNoFetch(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoFetch = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="GitVersionSettings.NoFetch"/>.</em></p><p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p></summary>
        [Pure]
        public static GitVersionSettings EnableNoFetch(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoFetch = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="GitVersionSettings.NoFetch"/>.</em></p><p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p></summary>
        [Pure]
        public static GitVersionSettings DisableNoFetch(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoFetch = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="GitVersionSettings.NoFetch"/>.</em></p><p>Disables <c>git fetch</c> during version calculation. Might cause GitVersion to not calculate your version as expected.</p></summary>
        [Pure]
        public static GitVersionSettings ToggleNoFetch(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoFetch = !toolSettings.NoFetch;
            return toolSettings;
        }
        #endregion
        #region Executable
        /// <summary><p><em>Sets <see cref="GitVersionSettings.Executable"/>.</em></p><p>Executes target executable making GitVersion variables available as environmental variables.</p></summary>
        [Pure]
        public static GitVersionSettings SetExecutable(this GitVersionSettings toolSettings, string executable)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Executable = executable;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.Executable"/>.</em></p><p>Executes target executable making GitVersion variables available as environmental variables.</p></summary>
        [Pure]
        public static GitVersionSettings ResetExecutable(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Executable = null;
            return toolSettings;
        }
        #endregion
        #region ExecutableArguments
        /// <summary><p><em>Sets <see cref="GitVersionSettings.ExecutableArguments"/>.</em></p><p>Arguments for the executable specified by <c>/exec</c>.</p></summary>
        [Pure]
        public static GitVersionSettings SetExecutableArguments(this GitVersionSettings toolSettings, string executableArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExecutableArguments = executableArguments;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.ExecutableArguments"/>.</em></p><p>Arguments for the executable specified by <c>/exec</c>.</p></summary>
        [Pure]
        public static GitVersionSettings ResetExecutableArguments(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExecutableArguments = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildProject
        /// <summary><p><em>Sets <see cref="GitVersionSettings.MSBuildProject"/>.</em></p><p>Build an MSBuild file, GitVersion variables will be passed as MSBuild properties.</p></summary>
        [Pure]
        public static GitVersionSettings SetMSBuildProject(this GitVersionSettings toolSettings, string msbuildProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProject = msbuildProject;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.MSBuildProject"/>.</em></p><p>Build an MSBuild file, GitVersion variables will be passed as MSBuild properties.</p></summary>
        [Pure]
        public static GitVersionSettings ResetMSBuildProject(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProject = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildProjectArguments
        /// <summary><p><em>Sets <see cref="GitVersionSettings.MSBuildProjectArguments"/>.</em></p><p>Additional arguments to pass to MSBuild.</p></summary>
        [Pure]
        public static GitVersionSettings SetMSBuildProjectArguments(this GitVersionSettings toolSettings, string msbuildProjectArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProjectArguments = msbuildProjectArguments;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.MSBuildProjectArguments"/>.</em></p><p>Additional arguments to pass to MSBuild.</p></summary>
        [Pure]
        public static GitVersionSettings ResetMSBuildProjectArguments(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildProjectArguments = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary><p><em>Sets <see cref="GitVersionSettings.Verbosity"/>.</em></p><p>Set Verbosity level (<c>debug</c>, <c>info</c>, <c>warn</c>, <c>error</c>, <c>none</c>). Default is <c>info</c>.</p></summary>
        [Pure]
        public static GitVersionSettings SetVerbosity(this GitVersionSettings toolSettings, GitVersionVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="GitVersionSettings.Verbosity"/>.</em></p><p>Set Verbosity level (<c>debug</c>, <c>info</c>, <c>warn</c>, <c>error</c>, <c>none</c>). Default is <c>info</c>.</p></summary>
        [Pure]
        public static GitVersionSettings ResetVerbosity(this GitVersionSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region GitVersionOutput
    /// <summary><p>Used within <see cref="GitVersionTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<GitVersionOutput>))]
    public partial class GitVersionOutput : Enumeration
    {
        public static GitVersionOutput json = new GitVersionOutput { Value = "json" };
        public static GitVersionOutput buildserver = new GitVersionOutput { Value = "buildserver" };
    }
    #endregion
    #region GitVersionVerbosity
    /// <summary><p>Used within <see cref="GitVersionTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<GitVersionVerbosity>))]
    public partial class GitVersionVerbosity : Enumeration
    {
        public static GitVersionVerbosity debug = new GitVersionVerbosity { Value = "debug" };
        public static GitVersionVerbosity info = new GitVersionVerbosity { Value = "info" };
        public static GitVersionVerbosity warn = new GitVersionVerbosity { Value = "warn" };
        public static GitVersionVerbosity error = new GitVersionVerbosity { Value = "error" };
        public static GitVersionVerbosity none = new GitVersionVerbosity { Value = "none" };
    }
    #endregion
}

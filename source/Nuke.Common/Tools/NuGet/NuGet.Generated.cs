// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated with Nuke.CodeGeneration, LOCAL VERSION.
// Generated from https://github.com/nuke-build/tools/blob/master/metadata/NuGet.json.

using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.NuGet
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetTasks
    {
        /// <summary><p>Path to the NuGet executable.</p></summary>
        public static string NuGetPath => GetToolPath();
        static partial void PreProcess(NuGetPushSettings toolSettings);
        static partial void PostProcess(NuGetPushSettings toolSettings);
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetPush(Configure<NuGetPushSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NuGetPushSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess(NuGetPackSettings toolSettings);
        static partial void PostProcess(NuGetPackSettings toolSettings);
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetPack(Configure<NuGetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NuGetPackSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetPack(string targetPath, Configure<NuGetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            NuGetPack(x => configurator(x).SetTargetPath(targetPath));
        }
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetPack(string targetPath, string version, Configure<NuGetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            NuGetPack(targetPath, x => configurator(x).SetVersion(version));
        }
        static partial void PreProcess(NuGetRestoreSettings toolSettings);
        static partial void PostProcess(NuGetRestoreSettings toolSettings);
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetRestore(Configure<NuGetRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NuGetRestoreSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetRestore(string targetPath, Configure<NuGetRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            NuGetRestore(x => configurator(x).SetTargetPath(targetPath));
        }
    }
    #region NuGetPushSettings
    /// <summary><p>Used within <see cref="NuGetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetPushSettings : ToolSettings
    {
        /// <summary><p>Path to the NuGet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? NuGetTasks.NuGetPath;
        /// <summary><p>Path of the package to push.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>The API key for the target repository. If not present, the one specified in <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary><p>Specifies the server URL. NuGet identifies a UNC or local folder source and simply copies the file there instead of pushing it using HTTP.  Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <em>NuGet.Config</em> file specifies a <em>DefaultPushSource</em> value (see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>).</p></summary>
        public virtual string Source { get; internal set; }
        /// <summary><p><em>(3.5+)</em> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p></summary>
        public virtual string SymbolSource { get; internal set; }
        /// <summary><p><em>(3.5+)</em> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p></summary>
        public virtual string SymbolApiKey { get; internal set; }
        /// <summary><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        public virtual bool? NoSymbols { get; internal set; }
        /// <summary><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        public virtual bool? DisableBuffering { get; internal set; }
        /// <summary><p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        /// <summary><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary><p>Suppresses prompts for user input or confirmations.</p></summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary><p>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</p></summary>
        public virtual int? Timeout { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), "File.Exists(TargetPath)");
            ControlFlow.Assert(File.Exists(ConfigFile) || ConfigFile == null, "File.Exists(ConfigFile) || ConfigFile == null");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("push")
              .Add("{value}", TargetPath)
              .Add("-ApiKey {value}", ApiKey, secret: true)
              .Add("-Source {value}", Source)
              .Add("-SymbolSource {value}", SymbolSource)
              .Add("-SymbolApiKey {value}", SymbolApiKey, secret: true)
              .Add("-NoSymbols", NoSymbols)
              .Add("-DisableBuffering", DisableBuffering)
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-NonInteractive", NonInteractive)
              .Add("-Timeout {value}", Timeout);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NuGetPackSettings
    /// <summary><p>Used within <see cref="NuGetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetPackSettings : ToolSettings
    {
        /// <summary><p>Path to the NuGet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? NuGetTasks.NuGetPath;
        /// <summary><p>The <c>.nuspec</c> or <c>.csproj</c> file.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>Sets the base path of the files defined in the <c>.nuspec</c> file.</p></summary>
        public virtual string BasePath { get; internal set; }
        /// <summary><p>Specifies that the project should be built before building the package.</p></summary>
        public virtual bool? Build { get; internal set; }
        /// <summary><p>Specifies one or more wildcard patterns to exclude when creating a package. To specify more than one pattern, repeat the <c>-Exclude</c> flag.</p></summary>
        public virtual string Exclude { get; internal set; }
        /// <summary><p>Prevent inclusion of empty directories when building the package.</p></summary>
        public virtual bool? ExcludeEmptyDirectories { get; internal set; }
        /// <summary><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        public virtual bool? IncludeReferencedProjects { get; internal set; }
        /// <summary><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        public virtual bool? MinClientVersion { get; internal set; }
        /// <summary><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary><p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        public virtual string MSBuildPath { get; internal set; }
        /// <summary><p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        public virtual NuGetMSBuildVersion MSBuildVersion { get; internal set; }
        /// <summary><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        public virtual bool? NoDefaultExcludes { get; internal set; }
        /// <summary><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        public virtual bool? NoPackageAnalysis { get; internal set; }
        /// <summary><p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p></summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p><em>(3.4.4+)</em> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p></summary>
        public virtual string Suffix { get; internal set; }
        /// <summary><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        public virtual bool? Symbols { get; internal set; }
        /// <summary><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        public virtual bool? Tool { get; internal set; }
        /// <summary><p>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        /// <summary><p>Overrides the version number from the <c>.nuspec</c> file.</p></summary>
        public virtual string Version { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), "File.Exists(TargetPath)");
            ControlFlow.Assert(Directory.Exists(BasePath), "Directory.Exists(BasePath)");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("pack")
              .Add("{value}", TargetPath)
              .Add("-BasePath {value}", BasePath)
              .Add("-Build", Build)
              .Add("-Exclude {value}", Exclude)
              .Add("-ExcludeEmptyDirectories", ExcludeEmptyDirectories)
              .Add("-IncludeReferencedProjects", IncludeReferencedProjects)
              .Add("-MinClientVersion", MinClientVersion)
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-MSBuildPath {value}", MSBuildPath)
              .Add("-MSBuildVersion {value}", MSBuildVersion)
              .Add("-NoDefaultExcludes", NoDefaultExcludes)
              .Add("-NoPackageAnalysis", NoPackageAnalysis)
              .Add("-OutputDirectory {value}", OutputDirectory)
              .Add("-Properties {value}", Properties, "{key}={value}", separator: ';')
              .Add("-Suffix {value}", Suffix)
              .Add("-Symbols", Symbols)
              .Add("-Tool", Tool)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-Version {value}", Version);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NuGetRestoreSettings
    /// <summary><p>Used within <see cref="NuGetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetRestoreSettings : ToolSettings
    {
        /// <summary><p>Path to the NuGet executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? NuGetTasks.NuGetPath;
        /// <summary><p>Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        public virtual bool? DirectDownload { get; internal set; }
        /// <summary><p>Disables restoring multiple packages in parallel.</p></summary>
        public virtual bool? DisableParallelProcessing { get; internal set; }
        /// <summary><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        public virtual IReadOnlyList<string> FallbackSource => FallbackSourceInternal.AsReadOnly();
        internal List<string> FallbackSourceInternal { get; set; } = new List<string>();
        /// <summary><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        public virtual bool? ForceEnglishOutput { get; internal set; }
        /// <summary><p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        public virtual string MSBuildPath { get; internal set; }
        /// <summary><p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>, <em>15</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        public virtual NuGetMSBuildVersion MSBuildVersion { get; internal set; }
        /// <summary><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        public virtual bool? NoCache { get; internal set; }
        /// <summary><p>Suppresses prompts for user input or confirmations.</p></summary>
        public virtual bool? NonInteractive { get; internal set; }
        /// <summary><p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        public virtual IReadOnlyList<PackageSaveMode> PackageSaveMode => PackageSaveModeInternal.AsReadOnly();
        internal List<PackageSaveMode> PackageSaveModeInternal { get; set; } = new List<PackageSaveMode>();
        /// <summary><p>Same as <c>OutputDirectory</c>.</p></summary>
        public virtual string PackagesDirectory { get; internal set; }
        /// <summary><p>Timeout in seconds for resolving project-to-project references.</p></summary>
        public virtual int? Project2ProjectTimeOut { get; internal set; }
        /// <summary><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        public virtual bool? Recursive { get; internal set; }
        /// <summary><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        public virtual bool? RequireConsent { get; internal set; }
        /// <summary><p>Specifies the solution folder. Not valid when restoring packages for a solution.</p></summary>
        public virtual string SolutionDirectory { get; internal set; }
        /// <summary><p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p></summary>
        public virtual IReadOnlyList<string> Source => SourceInternal.AsReadOnly();
        internal List<string> SourceInternal { get; set; } = new List<string>();
        /// <summary><p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        public virtual NuGetVerbosity Verbosity { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("restore")
              .Add("{value}", TargetPath)
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-DirectDownload", DirectDownload)
              .Add("-DisableParallelProcessing", DisableParallelProcessing)
              .Add("-FallbackSource {value}", FallbackSource, separator: ';')
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-MSBuildPath {value}", MSBuildPath)
              .Add("-MSBuildVersion {value}", MSBuildVersion)
              .Add("-NoCache", NoCache)
              .Add("-NonInteractive", NonInteractive)
              .Add("-OutputDirectory {value}", OutputDirectory)
              .Add("-PackageSaveMode {value}", PackageSaveMode, separator: ';')
              .Add("-PackagesDirectory {value}", PackagesDirectory)
              .Add("-Project2ProjectTimeOut {value}", Project2ProjectTimeOut)
              .Add("-Recursive", Recursive)
              .Add("-RequireConsent", RequireConsent)
              .Add("-SolutionDirectory {value}", SolutionDirectory)
              .Add("-Source {value}", Source, separator: ';')
              .Add("-Verbosity {value}", Verbosity);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region NuGetPushSettingsExtensions
    /// <summary><p>Used within <see cref="NuGetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetPushSettingsExtensions
    {
        #region TargetPath
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.TargetPath"/>.</em></p><p>Path of the package to push.</p></summary>
        [Pure]
        public static NuGetPushSettings SetTargetPath(this NuGetPushSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.TargetPath"/>.</em></p><p>Path of the package to push.</p></summary>
        [Pure]
        public static NuGetPushSettings ResetTargetPath(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region ApiKey
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.ApiKey"/>.</em></p><p>The API key for the target repository. If not present, the one specified in <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        [Pure]
        public static NuGetPushSettings SetApiKey(this NuGetPushSettings toolSettings, string apiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.ApiKey"/>.</em></p><p>The API key for the target repository. If not present, the one specified in <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        [Pure]
        public static NuGetPushSettings ResetApiKey(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.Source"/>.</em></p><p>Specifies the server URL. NuGet identifies a UNC or local folder source and simply copies the file there instead of pushing it using HTTP.  Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <em>NuGet.Config</em> file specifies a <em>DefaultPushSource</em> value (see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>).</p></summary>
        [Pure]
        public static NuGetPushSettings SetSource(this NuGetPushSettings toolSettings, string source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.Source"/>.</em></p><p>Specifies the server URL. NuGet identifies a UNC or local folder source and simply copies the file there instead of pushing it using HTTP.  Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <em>NuGet.Config</em> file specifies a <em>DefaultPushSource</em> value (see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>).</p></summary>
        [Pure]
        public static NuGetPushSettings ResetSource(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region SymbolSource
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.SymbolSource"/>.</em></p><p><em>(3.5+)</em> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p></summary>
        [Pure]
        public static NuGetPushSettings SetSymbolSource(this NuGetPushSettings toolSettings, string symbolSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSource = symbolSource;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.SymbolSource"/>.</em></p><p><em>(3.5+)</em> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p></summary>
        [Pure]
        public static NuGetPushSettings ResetSymbolSource(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSource = null;
            return toolSettings;
        }
        #endregion
        #region SymbolApiKey
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.SymbolApiKey"/>.</em></p><p><em>(3.5+)</em> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p></summary>
        [Pure]
        public static NuGetPushSettings SetSymbolApiKey(this NuGetPushSettings toolSettings, string symbolApiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolApiKey = symbolApiKey;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.SymbolApiKey"/>.</em></p><p><em>(3.5+)</em> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p></summary>
        [Pure]
        public static NuGetPushSettings ResetSymbolApiKey(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolApiKey = null;
            return toolSettings;
        }
        #endregion
        #region NoSymbols
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.NoSymbols"/>.</em></p><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings SetNoSymbols(this NuGetPushSettings toolSettings, bool? noSymbols)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = noSymbols;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.NoSymbols"/>.</em></p><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings ResetNoSymbols(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPushSettings.NoSymbols"/>.</em></p><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableNoSymbols(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPushSettings.NoSymbols"/>.</em></p><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableNoSymbols(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPushSettings.NoSymbols"/>.</em></p><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleNoSymbols(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = !toolSettings.NoSymbols;
            return toolSettings;
        }
        #endregion
        #region DisableBuffering
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.DisableBuffering"/>.</em></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings SetDisableBuffering(this NuGetPushSettings toolSettings, bool? disableBuffering)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = disableBuffering;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.DisableBuffering"/>.</em></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings ResetDisableBuffering(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPushSettings.DisableBuffering"/>.</em></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableDisableBuffering(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPushSettings.DisableBuffering"/>.</em></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableDisableBuffering(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPushSettings.DisableBuffering"/>.</em></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleDisableBuffering(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = !toolSettings.DisableBuffering;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.ConfigFile"/>.</em></p><p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        [Pure]
        public static NuGetPushSettings SetConfigFile(this NuGetPushSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.ConfigFile"/>.</em></p><p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        [Pure]
        public static NuGetPushSettings ResetConfigFile(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.Verbosity"/>.</em></p><p>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        [Pure]
        public static NuGetPushSettings SetVerbosity(this NuGetPushSettings toolSettings, NuGetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.Verbosity"/>.</em></p><p>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        [Pure]
        public static NuGetPushSettings ResetVerbosity(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings SetForceEnglishOutput(this NuGetPushSettings toolSettings, bool? forceEnglishOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings ResetForceEnglishOutput(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableForceEnglishOutput(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableForceEnglishOutput(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleForceEnglishOutput(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.NonInteractive"/>.</em></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings SetNonInteractive(this NuGetPushSettings toolSettings, bool? nonInteractive)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.NonInteractive"/>.</em></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings ResetNonInteractive(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPushSettings.NonInteractive"/>.</em></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableNonInteractive(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPushSettings.NonInteractive"/>.</em></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableNonInteractive(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPushSettings.NonInteractive"/>.</em></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleNonInteractive(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary><p><em>Sets <see cref="NuGetPushSettings.Timeout"/>.</em></p><p>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</p></summary>
        [Pure]
        public static NuGetPushSettings SetTimeout(this NuGetPushSettings toolSettings, int? timeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPushSettings.Timeout"/>.</em></p><p>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</p></summary>
        [Pure]
        public static NuGetPushSettings ResetTimeout(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetPackSettingsExtensions
    /// <summary><p>Used within <see cref="NuGetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetPackSettingsExtensions
    {
        #region TargetPath
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.TargetPath"/>.</em></p><p>The <c>.nuspec</c> or <c>.csproj</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetTargetPath(this NuGetPackSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.TargetPath"/>.</em></p><p>The <c>.nuspec</c> or <c>.csproj</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetTargetPath(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region BasePath
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.BasePath"/>.</em></p><p>Sets the base path of the files defined in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetBasePath(this NuGetPackSettings toolSettings, string basePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = basePath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.BasePath"/>.</em></p><p>Sets the base path of the files defined in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetBasePath(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = null;
            return toolSettings;
        }
        #endregion
        #region Build
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.Build"/>.</em></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetBuild(this NuGetPackSettings toolSettings, bool? build)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = build;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.Build"/>.</em></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetBuild(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackSettings.Build"/>.</em></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableBuild(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackSettings.Build"/>.</em></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableBuild(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackSettings.Build"/>.</em></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleBuild(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = !toolSettings.Build;
            return toolSettings;
        }
        #endregion
        #region Exclude
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.Exclude"/>.</em></p><p>Specifies one or more wildcard patterns to exclude when creating a package. To specify more than one pattern, repeat the <c>-Exclude</c> flag.</p></summary>
        [Pure]
        public static NuGetPackSettings SetExclude(this NuGetPackSettings toolSettings, string exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exclude = exclude;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.Exclude"/>.</em></p><p>Specifies one or more wildcard patterns to exclude when creating a package. To specify more than one pattern, repeat the <c>-Exclude</c> flag.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetExclude(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exclude = null;
            return toolSettings;
        }
        #endregion
        #region ExcludeEmptyDirectories
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</em></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetExcludeEmptyDirectories(this NuGetPackSettings toolSettings, bool? excludeEmptyDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = excludeEmptyDirectories;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</em></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetExcludeEmptyDirectories(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</em></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableExcludeEmptyDirectories(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</em></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableExcludeEmptyDirectories(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</em></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleExcludeEmptyDirectories(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = !toolSettings.ExcludeEmptyDirectories;
            return toolSettings;
        }
        #endregion
        #region IncludeReferencedProjects
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</em></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetIncludeReferencedProjects(this NuGetPackSettings toolSettings, bool? includeReferencedProjects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = includeReferencedProjects;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</em></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetIncludeReferencedProjects(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</em></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableIncludeReferencedProjects(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</em></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableIncludeReferencedProjects(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</em></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleIncludeReferencedProjects(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = !toolSettings.IncludeReferencedProjects;
            return toolSettings;
        }
        #endregion
        #region MinClientVersion
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.MinClientVersion"/>.</em></p><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetMinClientVersion(this NuGetPackSettings toolSettings, bool? minClientVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = minClientVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.MinClientVersion"/>.</em></p><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetMinClientVersion(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackSettings.MinClientVersion"/>.</em></p><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableMinClientVersion(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackSettings.MinClientVersion"/>.</em></p><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableMinClientVersion(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackSettings.MinClientVersion"/>.</em></p><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleMinClientVersion(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = !toolSettings.MinClientVersion;
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings SetForceEnglishOutput(this NuGetPackSettings toolSettings, bool? forceEnglishOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetForceEnglishOutput(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableForceEnglishOutput(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableForceEnglishOutput(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleForceEnglishOutput(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region MSBuildPath
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.MSBuildPath"/>.</em></p><p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetMSBuildPath(this NuGetPackSettings toolSettings, string msbuildPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPath = msbuildPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.MSBuildPath"/>.</em></p><p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetMSBuildPath(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPath = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildVersion
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.MSBuildVersion"/>.</em></p><p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        [Pure]
        public static NuGetPackSettings SetMSBuildVersion(this NuGetPackSettings toolSettings, NuGetMSBuildVersion msbuildVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = msbuildVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.MSBuildVersion"/>.</em></p><p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetMSBuildVersion(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = null;
            return toolSettings;
        }
        #endregion
        #region NoDefaultExcludes
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</em></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetNoDefaultExcludes(this NuGetPackSettings toolSettings, bool? noDefaultExcludes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = noDefaultExcludes;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</em></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetNoDefaultExcludes(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</em></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableNoDefaultExcludes(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</em></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableNoDefaultExcludes(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</em></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleNoDefaultExcludes(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = !toolSettings.NoDefaultExcludes;
            return toolSettings;
        }
        #endregion
        #region NoPackageAnalysis
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</em></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetNoPackageAnalysis(this NuGetPackSettings toolSettings, bool? noPackageAnalysis)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = noPackageAnalysis;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</em></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetNoPackageAnalysis(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</em></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableNoPackageAnalysis(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</em></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableNoPackageAnalysis(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</em></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleNoPackageAnalysis(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = !toolSettings.NoPackageAnalysis;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.OutputDirectory"/>.</em></p><p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p></summary>
        [Pure]
        public static NuGetPackSettings SetOutputDirectory(this NuGetPackSettings toolSettings, string outputDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.OutputDirectory"/>.</em></p><p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetOutputDirectory(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.Properties"/> to a new dictionary.</em></p><p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetProperties(this NuGetPackSettings toolSettings, IDictionary<string, string> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NuGetPackSettings.Properties"/>.</em></p><p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings ClearProperties(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Adds a new key-value-pair <see cref="NuGetPackSettings.Properties"/>.</em></p><p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings AddProperty(this NuGetPackSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><em>Removes a key-value-pair from <see cref="NuGetPackSettings.Properties"/>.</em></p><p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings RemoveProperty(this NuGetPackSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><em>Sets a key-value-pair in <see cref="NuGetPackSettings.Properties"/>.</em></p><p>Specifies a list of properties that override values in the project file; see <a href="https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties">Common MSBuild Project Properties</a> for property names. The Properties argument here is a list of token=value pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks. Note that for the &quot;Configuration&quot; property, the default is &quot;Debug&quot;. To change to a Release configuration, use <c>-Properties Configuration=Release</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetProperty(this NuGetPackSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
        #region Suffix
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.Suffix"/>.</em></p><p><em>(3.4.4+)</em> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p></summary>
        [Pure]
        public static NuGetPackSettings SetSuffix(this NuGetPackSettings toolSettings, string suffix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Suffix = suffix;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.Suffix"/>.</em></p><p><em>(3.4.4+)</em> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetSuffix(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Suffix = null;
            return toolSettings;
        }
        #endregion
        #region Symbols
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.Symbols"/>.</em></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetSymbols(this NuGetPackSettings toolSettings, bool? symbols)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = symbols;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.Symbols"/>.</em></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetSymbols(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackSettings.Symbols"/>.</em></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableSymbols(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackSettings.Symbols"/>.</em></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableSymbols(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackSettings.Symbols"/>.</em></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleSymbols(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = !toolSettings.Symbols;
            return toolSettings;
        }
        #endregion
        #region Tool
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.Tool"/>.</em></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings SetTool(this NuGetPackSettings toolSettings, bool? tool)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = tool;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.Tool"/>.</em></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetTool(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetPackSettings.Tool"/>.</em></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableTool(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetPackSettings.Tool"/>.</em></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableTool(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetPackSettings.Tool"/>.</em></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleTool(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = !toolSettings.Tool;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.Verbosity"/>.</em></p><p>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetVerbosity(this NuGetPackSettings toolSettings, NuGetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.Verbosity"/>.</em></p><p>Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetVerbosity(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary><p><em>Sets <see cref="NuGetPackSettings.Version"/>.</em></p><p>Overrides the version number from the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetVersion(this NuGetPackSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetPackSettings.Version"/>.</em></p><p>Overrides the version number from the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings ResetVersion(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetRestoreSettingsExtensions
    /// <summary><p>Used within <see cref="NuGetTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetRestoreSettingsExtensions
    {
        #region TargetPath
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.TargetPath"/>.</em></p><p>Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetTargetPath(this NuGetRestoreSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.TargetPath"/>.</em></p><p>Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetTargetPath(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.ConfigFile"/>.</em></p><p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetConfigFile(this NuGetRestoreSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.ConfigFile"/>.</em></p><p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetConfigFile(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region DirectDownload
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.DirectDownload"/>.</em></p><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetDirectDownload(this NuGetRestoreSettings toolSettings, bool? directDownload)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = directDownload;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.DirectDownload"/>.</em></p><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetDirectDownload(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetRestoreSettings.DirectDownload"/>.</em></p><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableDirectDownload(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetRestoreSettings.DirectDownload"/>.</em></p><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableDirectDownload(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetRestoreSettings.DirectDownload"/>.</em></p><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleDirectDownload(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = !toolSettings.DirectDownload;
            return toolSettings;
        }
        #endregion
        #region DisableParallelProcessing
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</em></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetDisableParallelProcessing(this NuGetRestoreSettings toolSettings, bool? disableParallelProcessing)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = disableParallelProcessing;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</em></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetDisableParallelProcessing(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</em></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableDisableParallelProcessing(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</em></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableDisableParallelProcessing(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</em></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleDisableParallelProcessing(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = !toolSettings.DisableParallelProcessing;
            return toolSettings;
        }
        #endregion
        #region FallbackSource
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.FallbackSource"/> to a new list.</em></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetFallbackSource(this NuGetRestoreSettings toolSettings, params string[] fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal = fallbackSource.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.FallbackSource"/> to a new list.</em></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetFallbackSource(this NuGetRestoreSettings toolSettings, IEnumerable<string> fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal = fallbackSource.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NuGetRestoreSettings.FallbackSource"/>.</em></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings toolSettings, params string[] fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NuGetRestoreSettings.FallbackSource"/>.</em></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings toolSettings, IEnumerable<string> fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NuGetRestoreSettings.FallbackSource"/>.</em></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ClearFallbackSource(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NuGetRestoreSettings.FallbackSource"/>.</em></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings RemoveFallbackSource(this NuGetRestoreSettings toolSettings, params string[] fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fallbackSource);
            toolSettings.FallbackSourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NuGetRestoreSettings.FallbackSource"/>.</em></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings RemoveFallbackSource(this NuGetRestoreSettings toolSettings, IEnumerable<string> fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(fallbackSource);
            toolSettings.FallbackSourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ForceEnglishOutput
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetForceEnglishOutput(this NuGetRestoreSettings toolSettings, bool? forceEnglishOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetForceEnglishOutput(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableForceEnglishOutput(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableForceEnglishOutput(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</em></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleForceEnglishOutput(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        #endregion
        #region MSBuildPath
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.MSBuildPath"/>.</em></p><p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetMSBuildPath(this NuGetRestoreSettings toolSettings, string msbuildPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPath = msbuildPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.MSBuildPath"/>.</em></p><p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetMSBuildPath(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPath = null;
            return toolSettings;
        }
        #endregion
        #region MSBuildVersion
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.MSBuildVersion"/>.</em></p><p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>, <em>15</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetMSBuildVersion(this NuGetRestoreSettings toolSettings, NuGetMSBuildVersion msbuildVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = msbuildVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.MSBuildVersion"/>.</em></p><p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>, <em>15</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetMSBuildVersion(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = null;
            return toolSettings;
        }
        #endregion
        #region NoCache
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.NoCache"/>.</em></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetNoCache(this NuGetRestoreSettings toolSettings, bool? noCache)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.NoCache"/>.</em></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetNoCache(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetRestoreSettings.NoCache"/>.</em></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableNoCache(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetRestoreSettings.NoCache"/>.</em></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableNoCache(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetRestoreSettings.NoCache"/>.</em></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleNoCache(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        #endregion
        #region NonInteractive
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.NonInteractive"/>.</em></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetNonInteractive(this NuGetRestoreSettings toolSettings, bool? nonInteractive)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.NonInteractive"/>.</em></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetNonInteractive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetRestoreSettings.NonInteractive"/>.</em></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableNonInteractive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetRestoreSettings.NonInteractive"/>.</em></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableNonInteractive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetRestoreSettings.NonInteractive"/>.</em></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleNonInteractive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.OutputDirectory"/>.</em></p><p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetOutputDirectory(this NuGetRestoreSettings toolSettings, string outputDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.OutputDirectory"/>.</em></p><p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetOutputDirectory(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region PackageSaveMode
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.PackageSaveMode"/> to a new list.</em></p><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetPackageSaveMode(this NuGetRestoreSettings toolSettings, params PackageSaveMode[] packageSaveMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal = packageSaveMode.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.PackageSaveMode"/> to a new list.</em></p><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetPackageSaveMode(this NuGetRestoreSettings toolSettings, IEnumerable<PackageSaveMode> packageSaveMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal = packageSaveMode.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NuGetRestoreSettings.PackageSaveMode"/>.</em></p><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddPackageSaveMode(this NuGetRestoreSettings toolSettings, params PackageSaveMode[] packageSaveMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal.AddRange(packageSaveMode);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NuGetRestoreSettings.PackageSaveMode"/>.</em></p><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddPackageSaveMode(this NuGetRestoreSettings toolSettings, IEnumerable<PackageSaveMode> packageSaveMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal.AddRange(packageSaveMode);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NuGetRestoreSettings.PackageSaveMode"/>.</em></p><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ClearPackageSaveMode(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveModeInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NuGetRestoreSettings.PackageSaveMode"/>.</em></p><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings RemovePackageSaveMode(this NuGetRestoreSettings toolSettings, params PackageSaveMode[] packageSaveMode)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<PackageSaveMode>(packageSaveMode);
            toolSettings.PackageSaveModeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NuGetRestoreSettings.PackageSaveMode"/>.</em></p><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings RemovePackageSaveMode(this NuGetRestoreSettings toolSettings, IEnumerable<PackageSaveMode> packageSaveMode)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<PackageSaveMode>(packageSaveMode);
            toolSettings.PackageSaveModeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region PackagesDirectory
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.PackagesDirectory"/>.</em></p><p>Same as <c>OutputDirectory</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetPackagesDirectory(this NuGetRestoreSettings toolSettings, string packagesDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesDirectory = packagesDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.PackagesDirectory"/>.</em></p><p>Same as <c>OutputDirectory</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetPackagesDirectory(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Project2ProjectTimeOut
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/>.</em></p><p>Timeout in seconds for resolving project-to-project references.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetProject2ProjectTimeOut(this NuGetRestoreSettings toolSettings, int? project2ProjectTimeOut)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project2ProjectTimeOut = project2ProjectTimeOut;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/>.</em></p><p>Timeout in seconds for resolving project-to-project references.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetProject2ProjectTimeOut(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project2ProjectTimeOut = null;
            return toolSettings;
        }
        #endregion
        #region Recursive
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.Recursive"/>.</em></p><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetRecursive(this NuGetRestoreSettings toolSettings, bool? recursive)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = recursive;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.Recursive"/>.</em></p><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetRecursive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetRestoreSettings.Recursive"/>.</em></p><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableRecursive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetRestoreSettings.Recursive"/>.</em></p><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableRecursive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetRestoreSettings.Recursive"/>.</em></p><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleRecursive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = !toolSettings.Recursive;
            return toolSettings;
        }
        #endregion
        #region RequireConsent
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.RequireConsent"/>.</em></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetRequireConsent(this NuGetRestoreSettings toolSettings, bool? requireConsent)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = requireConsent;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.RequireConsent"/>.</em></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetRequireConsent(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="NuGetRestoreSettings.RequireConsent"/>.</em></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableRequireConsent(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="NuGetRestoreSettings.RequireConsent"/>.</em></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableRequireConsent(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="NuGetRestoreSettings.RequireConsent"/>.</em></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleRequireConsent(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = !toolSettings.RequireConsent;
            return toolSettings;
        }
        #endregion
        #region SolutionDirectory
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.SolutionDirectory"/>.</em></p><p>Specifies the solution folder. Not valid when restoring packages for a solution.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetSolutionDirectory(this NuGetRestoreSettings toolSettings, string solutionDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionDirectory = solutionDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.SolutionDirectory"/>.</em></p><p>Specifies the solution folder. Not valid when restoring packages for a solution.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetSolutionDirectory(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Source
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.Source"/> to a new list.</em></p><p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetSource(this NuGetRestoreSettings toolSettings, params string[] source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.Source"/> to a new list.</em></p><p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetSource(this NuGetRestoreSettings toolSettings, IEnumerable<string> source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NuGetRestoreSettings.Source"/>.</em></p><p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings toolSettings, params string[] source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="NuGetRestoreSettings.Source"/>.</em></p><p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings toolSettings, IEnumerable<string> source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="NuGetRestoreSettings.Source"/>.</em></p><p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ClearSource(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NuGetRestoreSettings.Source"/>.</em></p><p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings RemoveSource(this NuGetRestoreSettings toolSettings, params string[] source)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="NuGetRestoreSettings.Source"/>.</em></p><p>Specifies the list of package sources (as URLs) to use for the restore. If omitted, the command uses the sources provided in configuration files, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/configuring-nuget-behavior">Configuring NuGet behavior</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings RemoveSource(this NuGetRestoreSettings toolSettings, IEnumerable<string> source)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(source);
            toolSettings.SourceInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary><p><em>Sets <see cref="NuGetRestoreSettings.Verbosity"/>.</em></p><p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetVerbosity(this NuGetRestoreSettings toolSettings, NuGetVerbosity verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="NuGetRestoreSettings.Verbosity"/>.</em></p><p>Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ResetVerbosity(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region NuGetVerbosity
    /// <summary><p>Used within <see cref="NuGetTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class NuGetVerbosity : Enumeration
    {
        public static NuGetVerbosity Normal = new NuGetVerbosity { Value = "Normal" };
        public static NuGetVerbosity Quiet = new NuGetVerbosity { Value = "Quiet" };
        public static NuGetVerbosity Detailed = new NuGetVerbosity { Value = "Detailed" };
    }
    #endregion
    #region PackageSaveMode
    /// <summary><p>Used within <see cref="NuGetTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class PackageSaveMode : Enumeration
    {
        public static PackageSaveMode Nuspec = new PackageSaveMode { Value = "Nuspec" };
        public static PackageSaveMode Nupkg = new PackageSaveMode { Value = "Nupkg" };
    }
    #endregion
    #region NuGetMSBuildVersion
    /// <summary><p>Used within <see cref="NuGetTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class NuGetMSBuildVersion : Enumeration
    {
        public static NuGetMSBuildVersion _4 = new NuGetMSBuildVersion { Value = "4" };
        public static NuGetMSBuildVersion _12 = new NuGetMSBuildVersion { Value = "12" };
        public static NuGetMSBuildVersion _14 = new NuGetMSBuildVersion { Value = "14" };
    }
    #endregion
}

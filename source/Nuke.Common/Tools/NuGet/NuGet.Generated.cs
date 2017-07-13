// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Auto-generated with Nuke.ToolGenerator.

using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

[assembly: IconClass(typeof(Nuke.Common.Tools.NuGet.NuGetTasks), "box")]

namespace Nuke.Common.Tools.NuGet
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetTasks
    {
        static partial void PreProcess (NuGetPushSettings toolSettings);
        static partial void PostProcess (NuGetPushSettings toolSettings);
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetPush (Configure<NuGetPushSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NuGetPushSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        static partial void PreProcess (NuGetPackSettings toolSettings);
        static partial void PostProcess (NuGetPackSettings toolSettings);
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetPack (Configure<NuGetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NuGetPackSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetPack (string targetPath, Configure<NuGetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            NuGetPack(x => configurator(x).SetTargetPath(targetPath));
        }
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetPack (string targetPath, string version, Configure<NuGetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            NuGetPack(targetPath, x => configurator(x).SetVersion(version));
        }
        static partial void PreProcess (NuGetRestoreSettings toolSettings);
        static partial void PostProcess (NuGetRestoreSettings toolSettings);
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetRestore (Configure<NuGetRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new NuGetRestoreSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetRestore (string targetPath, Configure<NuGetRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            NuGetRestore(x => configurator(x).SetTargetPath(targetPath));
        }
    }
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetPushSettings : NuGetSettings
    {
        /// <summary><p>Path of the package to push.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>The API key for the target repository. If not present, the one specified in <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary><p>Specifies the server URL. With NuGet 2.5+, NuGet will identify a UNC or local folder source and simply copy the file there instead of pushing it using HTTP. Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <em>NuGet.Config</em> file specifies a <em>DefaultPushSource</em> value.</p></summary>
        public virtual string Source { get; internal set; }
        /// <summary><p><em>(3.5+)</em> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p></summary>
        public virtual string SymbolSource { get; internal set; }
        /// <summary><p><em>(3.5+)</em> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p></summary>
        public virtual string SymbolApiKey { get; internal set; }
        /// <summary><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        public virtual bool NoSymbols { get; internal set; }
        /// <summary><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        public virtual bool DisableBuffering { get; internal set; }
        /// <summary><p><em>(2.5+)</em> The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p><em>(2.5+)</em> Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        public virtual NuGetVerbosity? Verbosity { get; internal set; }
        /// <summary><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        public virtual bool ForceEnglishOutput { get; internal set; }
        /// <summary><p>Suppresses prompts for user input or confirmations.</p></summary>
        public virtual bool NonInteractive { get; internal set; }
        /// <summary><p>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</p></summary>
        public virtual int? Timeout { get; internal set; }
        /// <inheritdoc />
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), $"File.Exists(TargetPath)");
            ControlFlow.Assert(File.Exists(ConfigFile) || ConfigFile == null, $"File.Exists(ConfigFile) || ConfigFile == null");
        }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
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
        }
    }
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetPackSettings : NuGetSettings
    {
        /// <summary><p>The <c>.nuspec</c> or <c>.csproj</c> file.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>Sets the base path of the files defined in the <c>.nuspec</c> file.</p></summary>
        public virtual string BasePath { get; internal set; }
        /// <summary><p>Specifies that the project should be built before building the package.</p></summary>
        public virtual bool Build { get; internal set; }
        /// <summary><p>Specifies one or more wildcard patterns to exclude when creating a package.</p></summary>
        public virtual string Exclude { get; internal set; }
        /// <summary><p>Prevent inclusion of empty directories when building the package.</p></summary>
        public virtual bool ExcludeEmptyDirectories { get; internal set; }
        /// <summary><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        public virtual bool IncludeReferencedProjects { get; internal set; }
        /// <summary><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        public virtual bool MinClientVersion { get; internal set; }
        /// <summary><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        public virtual bool ForceEnglishOutput { get; internal set; }
        /// <summary><p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        public virtual string MSBuildPath { get; internal set; }
        /// <summary><p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        public virtual NuGetMSBuildVersion? MSBuildVersion { get; internal set; }
        /// <summary><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        public virtual bool NoDefaultExcludes { get; internal set; }
        /// <summary><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        public virtual bool NoPackageAnalysis { get; internal set; }
        /// <summary><p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p><em>(3.4.4+)</em> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p></summary>
        public virtual string Suffix { get; internal set; }
        /// <summary><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        public virtual bool Symbols { get; internal set; }
        /// <summary><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        public virtual bool Tool { get; internal set; }
        /// <summary><p><em>(2.5+)</em> Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        public virtual NuGetVerbosity? Verbosity { get; internal set; }
        /// <summary><p>Overrides the version number from the <c>.nuspec</c> file.</p></summary>
        public virtual string Version { get; internal set; }
        /// <inheritdoc />
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(TargetPath), $"File.Exists(TargetPath)");
            ControlFlow.Assert(Directory.Exists(BasePath), $"Directory.Exists(BasePath)");
        }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
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
              .Add("-Properties {value}", Properties, mainSeparator: $";", keyValueSeparator: $"=")
              .Add("-Suffix {value}", Suffix)
              .Add("-Symbols", Symbols)
              .Add("-Tool", Tool)
              .Add("-Verbosity {value}", Verbosity)
              .Add("-Version {value}", Version);
        }
    }
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class NuGetRestoreSettings : NuGetSettings
    {
        /// <summary><p>Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.</p></summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary><p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        public virtual bool DirectDownload { get; internal set; }
        /// <summary><p>Disables restoring multiple packages in parallel.</p></summary>
        public virtual bool DisableParallelProcessing { get; internal set; }
        /// <summary><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        public virtual IReadOnlyList<string> FallbackSource => FallbackSourceInternal.AsReadOnly();
        internal List<string> FallbackSourceInternal { get; set; } = new List<string>();
        /// <summary><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        public virtual bool ForceEnglishOutput { get; internal set; }
        /// <summary><p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        public virtual string MSBuildPath { get; internal set; }
        /// <summary><p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>, <em>15</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        public virtual Nuke.Common.Tools.MSBuild.MSBuildVersion? MSBuildVersion { get; internal set; }
        /// <summary><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        public virtual bool NoCache { get; internal set; }
        /// <summary><p>Suppresses prompts for user input or confirmations.</p></summary>
        public virtual bool NonInteractive { get; internal set; }
        /// <summary><p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        public virtual PackageSaveMode? PackageSaveMode { get; internal set; }
        /// <summary><p>Same as <c>OutputDirectory</c>.</p></summary>
        public virtual string PackagesDirectory { get; internal set; }
        /// <summary><p>Timeout in seconds for resolving project-to-project references.</p></summary>
        public virtual int? Project2ProjectTimeOut { get; internal set; }
        /// <summary><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        public virtual bool Recursive { get; internal set; }
        /// <summary><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        public virtual bool RequireConsent { get; internal set; }
        /// <summary><p>Specifies the solution folder. Not valid when restoring packages for a solution.</p></summary>
        public virtual string SolutionDirectory { get; internal set; }
        /// <summary><p>Specifies list of package sources to use for the restore.</p></summary>
        public virtual IReadOnlyList<string> Source => SourceInternal.AsReadOnly();
        internal List<string> SourceInternal { get; set; } = new List<string>();
        /// <summary><p><em>(2.5+)</em> Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        public virtual NuGetVerbosity? Verbosity { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("restore")
              .Add("{value}", TargetPath)
              .Add("-ConfigFile {value}", ConfigFile)
              .Add("-DirectDownload", DirectDownload)
              .Add("-DisableParallelProcessing", DisableParallelProcessing)
              .Add("-FallbackSource {value}", FallbackSource, mainSeparator: $";")
              .Add("-ForceEnglishOutput", ForceEnglishOutput)
              .Add("-MSBuildPath {value}", MSBuildPath)
              .Add("-MSBuildVersion {value}", MSBuildVersion)
              .Add("-NoCache", NoCache)
              .Add("-NonInteractive", NonInteractive)
              .Add("-OutputDirectory {value}", OutputDirectory)
              .Add("-PackageSaveMode {value}", GetPackageSaveMode())
              .Add("-PackagesDirectory {value}", PackagesDirectory)
              .Add("-Project2ProjectTimeOut {value}", Project2ProjectTimeOut)
              .Add("-Recursive", Recursive)
              .Add("-RequireConsent", RequireConsent)
              .Add("-SolutionDirectory {value}", SolutionDirectory)
              .Add("-Source {value}", Source, mainSeparator: $";")
              .Add("-Verbosity {value}", Verbosity);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetPushSettingsExtensions
    {
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.TargetPath"/>.</i></p><p>Path of the package to push.</p></summary>
        [Pure]
        public static NuGetPushSettings SetTargetPath(this NuGetPushSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.ApiKey"/>.</i></p><p>The API key for the target repository. If not present, the one specified in <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        [Pure]
        public static NuGetPushSettings SetApiKey(this NuGetPushSettings toolSettings, string apiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiKey = apiKey;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.Source"/>.</i></p><p>Specifies the server URL. With NuGet 2.5+, NuGet will identify a UNC or local folder source and simply copy the file there instead of pushing it using HTTP. Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <em>NuGet.Config</em> file specifies a <em>DefaultPushSource</em> value.</p></summary>
        [Pure]
        public static NuGetPushSettings SetSource(this NuGetPushSettings toolSettings, string source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.SymbolSource"/>.</i></p><p><em>(3.5+)</em> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p></summary>
        [Pure]
        public static NuGetPushSettings SetSymbolSource(this NuGetPushSettings toolSettings, string symbolSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolSource = symbolSource;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.SymbolApiKey"/>.</i></p><p><em>(3.5+)</em> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p></summary>
        [Pure]
        public static NuGetPushSettings SetSymbolApiKey(this NuGetPushSettings toolSettings, string symbolApiKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SymbolApiKey = symbolApiKey;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.NoSymbols"/>.</i></p><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings SetNoSymbols(this NuGetPushSettings toolSettings, bool noSymbols)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = noSymbols;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPushSettings.NoSymbols"/>.</i></p><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableNoSymbols(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPushSettings.NoSymbols"/>.</i></p><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableNoSymbols(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPushSettings.NoSymbols"/>.</i></p><p><em>(3.5+)</em> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleNoSymbols(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSymbols = !toolSettings.NoSymbols;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings SetDisableBuffering(this NuGetPushSettings toolSettings, bool disableBuffering)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = disableBuffering;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableDisableBuffering(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableDisableBuffering(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleDisableBuffering(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableBuffering = !toolSettings.DisableBuffering;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.ConfigFile"/>.</i></p><p><em>(2.5+)</em> The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        [Pure]
        public static NuGetPushSettings SetConfigFile(this NuGetPushSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.Verbosity"/>.</i></p><p><em>(2.5+)</em> Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        [Pure]
        public static NuGetPushSettings SetVerbosity(this NuGetPushSettings toolSettings, NuGetVerbosity? verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings SetForceEnglishOutput(this NuGetPushSettings toolSettings, bool forceEnglishOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableForceEnglishOutput(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableForceEnglishOutput(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleForceEnglishOutput(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings SetNonInteractive(this NuGetPushSettings toolSettings, bool nonInteractive)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPushSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableNonInteractive(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPushSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableNonInteractive(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPushSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleNonInteractive(this NuGetPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPushSettings.Timeout"/>.</i></p><p>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</p></summary>
        [Pure]
        public static NuGetPushSettings SetTimeout(this NuGetPushSettings toolSettings, int? timeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetPackSettingsExtensions
    {
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.TargetPath"/>.</i></p><p>The <c>.nuspec</c> or <c>.csproj</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetTargetPath(this NuGetPackSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.BasePath"/>.</i></p><p>Sets the base path of the files defined in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetBasePath(this NuGetPackSettings toolSettings, string basePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BasePath = basePath;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.Build"/>.</i></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetBuild(this NuGetPackSettings toolSettings, bool build)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = build;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPackSettings.Build"/>.</i></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableBuild(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPackSettings.Build"/>.</i></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableBuild(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPackSettings.Build"/>.</i></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleBuild(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = !toolSettings.Build;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.Exclude"/>.</i></p><p>Specifies one or more wildcard patterns to exclude when creating a package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetExclude(this NuGetPackSettings toolSettings, string exclude)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Exclude = exclude;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetExcludeEmptyDirectories(this NuGetPackSettings toolSettings, bool excludeEmptyDirectories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = excludeEmptyDirectories;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableExcludeEmptyDirectories(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableExcludeEmptyDirectories(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleExcludeEmptyDirectories(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeEmptyDirectories = !toolSettings.ExcludeEmptyDirectories;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetIncludeReferencedProjects(this NuGetPackSettings toolSettings, bool includeReferencedProjects)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = includeReferencedProjects;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableIncludeReferencedProjects(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableIncludeReferencedProjects(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleIncludeReferencedProjects(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeReferencedProjects = !toolSettings.IncludeReferencedProjects;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetMinClientVersion(this NuGetPackSettings toolSettings, bool minClientVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = minClientVersion;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableMinClientVersion(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableMinClientVersion(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p><p>Set the <em>minClientVersion</em> attribute for the created package. This value will override the value of the existing <em>minClientVersion</em> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleMinClientVersion(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinClientVersion = !toolSettings.MinClientVersion;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings SetForceEnglishOutput(this NuGetPackSettings toolSettings, bool forceEnglishOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableForceEnglishOutput(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableForceEnglishOutput(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleForceEnglishOutput(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.MSBuildPath"/>.</i></p><p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetMSBuildPath(this NuGetPackSettings toolSettings, string msbuildPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPath = msbuildPath;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.MSBuildVersion"/>.</i></p><p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        [Pure]
        public static NuGetPackSettings SetMSBuildVersion(this NuGetPackSettings toolSettings, NuGetMSBuildVersion? msbuildVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = msbuildVersion;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetNoDefaultExcludes(this NuGetPackSettings toolSettings, bool noDefaultExcludes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = noDefaultExcludes;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableNoDefaultExcludes(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableNoDefaultExcludes(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <em>.svn</em> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleNoDefaultExcludes(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDefaultExcludes = !toolSettings.NoDefaultExcludes;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetNoPackageAnalysis(this NuGetPackSettings toolSettings, bool noPackageAnalysis)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = noPackageAnalysis;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableNoPackageAnalysis(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableNoPackageAnalysis(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleNoPackageAnalysis(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPackageAnalysis = !toolSettings.NoPackageAnalysis;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.OutputDirectory"/>.</i></p><p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p></summary>
        [Pure]
        public static NuGetPackSettings SetOutputDirectory(this NuGetPackSettings toolSettings, string outputDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.Properties"/> to a new dictionary.</i></p><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        [Pure]
        public static NuGetPackSettings SetProperties(this NuGetPackSettings toolSettings, IDictionary<string, string> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="NuGetPackSettings.Properties"/>.</i></p><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        [Pure]
        public static NuGetPackSettings ClearProperties(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a property to the existing <see cref="NuGetPackSettings.Properties"/>.</i></p><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        [Pure]
        public static NuGetPackSettings AddProperty(this NuGetPackSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single property from <see cref="NuGetPackSettings.Properties"/>.</i></p><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        [Pure]
        public static NuGetPackSettings RemoveProperty(this NuGetPackSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><i>Sets a property in <see cref="NuGetPackSettings.Properties"/>.</i></p><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        [Pure]
        public static NuGetPackSettings SetProperty(this NuGetPackSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.Suffix"/>.</i></p><p><em>(3.4.4+)</em> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p></summary>
        [Pure]
        public static NuGetPackSettings SetSuffix(this NuGetPackSettings toolSettings, string suffix)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Suffix = suffix;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.Symbols"/>.</i></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetSymbols(this NuGetPackSettings toolSettings, bool symbols)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = symbols;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPackSettings.Symbols"/>.</i></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableSymbols(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPackSettings.Symbols"/>.</i></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableSymbols(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPackSettings.Symbols"/>.</i></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleSymbols(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Symbols = !toolSettings.Symbols;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.Tool"/>.</i></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings SetTool(this NuGetPackSettings toolSettings, bool tool)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = tool;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetPackSettings.Tool"/>.</i></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableTool(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetPackSettings.Tool"/>.</i></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableTool(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetPackSettings.Tool"/>.</i></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleTool(this NuGetPackSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tool = !toolSettings.Tool;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.Verbosity"/>.</i></p><p><em>(2.5+)</em> Specifies the amount of details displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetVerbosity(this NuGetPackSettings toolSettings, NuGetVerbosity? verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetPackSettings.Version"/>.</i></p><p>Overrides the version number from the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetVersion(this NuGetPackSettings toolSettings, string version)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetRestoreSettingsExtensions
    {
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.TargetPath"/>.</i></p><p>Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetTargetPath(this NuGetRestoreSettings toolSettings, string targetPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.ConfigFile"/>.</i></p><p>The NuGet configuration file to apply. If not specified, <em>%AppData%\NuGet\NuGet.Config</em> is used.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetConfigFile(this NuGetRestoreSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetDirectDownload(this NuGetRestoreSettings toolSettings, bool directDownload)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = directDownload;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableDirectDownload(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableDirectDownload(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p><p><em>(4.0+)</em> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleDirectDownload(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DirectDownload = !toolSettings.DirectDownload;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetDisableParallelProcessing(this NuGetRestoreSettings toolSettings, bool disableParallelProcessing)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = disableParallelProcessing;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableDisableParallelProcessing(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableDisableParallelProcessing(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleDisableParallelProcessing(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableParallelProcessing = !toolSettings.DisableParallelProcessing;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.FallbackSource"/> to a new list.</i></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetFallbackSource(this NuGetRestoreSettings toolSettings, params string[] fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal = fallbackSource.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.FallbackSource"/> to a new list.</i></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetFallbackSource(this NuGetRestoreSettings toolSettings, IEnumerable<string> fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal = fallbackSource.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Adds a fallbackSource to the existing <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings toolSettings, params string[] fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return toolSettings;
        }
        /// <summary><p><i>Adds a fallbackSource to the existing <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings toolSettings, IEnumerable<string> fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ClearFallbackSource(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a single fallbackSource to <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings toolSettings, string fallbackSource, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (fallbackSource != null || evenIfNull) toolSettings.FallbackSourceInternal.Add(fallbackSource);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single fallbackSource from <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p><p><em>(3.2+)</em> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings RemoveFallbackSource(this NuGetRestoreSettings toolSettings, string fallbackSource)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FallbackSourceInternal = toolSettings.FallbackSource.Where(x => x == fallbackSource).ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetForceEnglishOutput(this NuGetRestoreSettings toolSettings, bool forceEnglishOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = forceEnglishOutput;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableForceEnglishOutput(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableForceEnglishOutput(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p><p><em>(3.5+)</em> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleForceEnglishOutput(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceEnglishOutput = !toolSettings.ForceEnglishOutput;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.MSBuildPath"/>.</i></p><p><em>(4.0+)</em> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetMSBuildPath(this NuGetRestoreSettings toolSettings, string msbuildPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildPath = msbuildPath;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.MSBuildVersion"/>.</i></p><p><em>(3.2+)</em> Specifies the version of MSBuild to be used with this command. Supported values are <em>4</em>, <em>12</em>, <em>14</em>, <em>15</em>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetMSBuildVersion(this NuGetRestoreSettings toolSettings, Nuke.Common.Tools.MSBuild.MSBuildVersion? msbuildVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MSBuildVersion = msbuildVersion;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.NoCache"/>.</i></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetNoCache(this NuGetRestoreSettings toolSettings, bool noCache)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = noCache;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetRestoreSettings.NoCache"/>.</i></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableNoCache(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetRestoreSettings.NoCache"/>.</i></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableNoCache(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetRestoreSettings.NoCache"/>.</i></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleNoCache(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoCache = !toolSettings.NoCache;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetNonInteractive(this NuGetRestoreSettings toolSettings, bool nonInteractive)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = nonInteractive;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableNonInteractive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableNonInteractive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleNonInteractive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonInteractive = !toolSettings.NonInteractive;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.OutputDirectory"/>.</i></p><p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetOutputDirectory(this NuGetRestoreSettings toolSettings, string outputDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.PackageSaveMode"/>.</i></p><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetPackageSaveMode(this NuGetRestoreSettings toolSettings, PackageSaveMode? packageSaveMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackageSaveMode = packageSaveMode;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.PackagesDirectory"/>.</i></p><p>Same as <c>OutputDirectory</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetPackagesDirectory(this NuGetRestoreSettings toolSettings, string packagesDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesDirectory = packagesDirectory;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/>.</i></p><p>Timeout in seconds for resolving project-to-project references.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetProject2ProjectTimeOut(this NuGetRestoreSettings toolSettings, int? project2ProjectTimeOut)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project2ProjectTimeOut = project2ProjectTimeOut;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.Recursive"/>.</i></p><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetRecursive(this NuGetRestoreSettings toolSettings, bool recursive)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = recursive;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetRestoreSettings.Recursive"/>.</i></p><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableRecursive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetRestoreSettings.Recursive"/>.</i></p><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableRecursive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetRestoreSettings.Recursive"/>.</i></p><p><em>(4.0+)</em> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleRecursive(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Recursive = !toolSettings.Recursive;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetRequireConsent(this NuGetRestoreSettings toolSettings, bool requireConsent)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = requireConsent;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableRequireConsent(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableRequireConsent(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleRequireConsent(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RequireConsent = !toolSettings.RequireConsent;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.SolutionDirectory"/>.</i></p><p>Specifies the solution folder. Not valid when restoring packages for a solution.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetSolutionDirectory(this NuGetRestoreSettings toolSettings, string solutionDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SolutionDirectory = solutionDirectory;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.Source"/> to a new list.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetSource(this NuGetRestoreSettings toolSettings, params string[] source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.Source"/> to a new list.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetSource(this NuGetRestoreSettings toolSettings, IEnumerable<string> source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = source.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Adds a source to the existing <see cref="NuGetRestoreSettings.Source"/>.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings toolSettings, params string[] source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary><p><i>Adds a source to the existing <see cref="NuGetRestoreSettings.Source"/>.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings toolSettings, IEnumerable<string> source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.AddRange(source);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="NuGetRestoreSettings.Source"/>.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ClearSource(this NuGetRestoreSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a single source to <see cref="NuGetRestoreSettings.Source"/>.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings toolSettings, string source, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (source != null || evenIfNull) toolSettings.SourceInternal.Add(source);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single source from <see cref="NuGetRestoreSettings.Source"/>.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings RemoveSource(this NuGetRestoreSettings toolSettings, string source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SourceInternal = toolSettings.Source.Where(x => x == source).ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="NuGetRestoreSettings.Verbosity"/>.</i></p><p><em>(2.5+)</em> Specifies the amount of detail displayed in the output: <em>normal</em>, <em>quiet</em>, <em>detailed</em>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetVerbosity(this NuGetRestoreSettings toolSettings, NuGetVerbosity? verbosity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
    }
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p></summary>
    [PublicAPI]
    public enum NuGetVerbosity
    {
        Normal,
        Quiet,
        Detailed,
    }
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p></summary>
    [PublicAPI]
    public enum PackageSaveMode
    {
        Nuspec,
        Nupkg,
        NuspecAndNupkg,
    }
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p></summary>
    [PublicAPI]
    public enum NuGetMSBuildVersion
    {
        [FriendlyString("4")]
        _4,
        [FriendlyString("12")]
        _12,
        [FriendlyString("14")]
        _14,
    }
}

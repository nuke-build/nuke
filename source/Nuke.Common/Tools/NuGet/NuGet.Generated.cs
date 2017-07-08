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
        static partial void PreProcess (NuGetPushSettings nuGetPushSettings);
        static partial void PostProcess (NuGetPushSettings nuGetPushSettings);
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetPush (Configure<NuGetPushSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var nuGetPushSettings = new NuGetPushSettings();
            nuGetPushSettings = configurator(nuGetPushSettings);
            PreProcess(nuGetPushSettings);
            var process = ProcessTasks.StartProcess(nuGetPushSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(nuGetPushSettings);
        }
        static partial void PreProcess (NuGetPackSettings nuGetPackSettings);
        static partial void PostProcess (NuGetPackSettings nuGetPackSettings);
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetPack (Configure<NuGetPackSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var nuGetPackSettings = new NuGetPackSettings();
            nuGetPackSettings = configurator(nuGetPackSettings);
            PreProcess(nuGetPackSettings);
            var process = ProcessTasks.StartProcess(nuGetPackSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(nuGetPackSettings);
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
        static partial void PreProcess (NuGetRestoreSettings nuGetRestoreSettings);
        static partial void PostProcess (NuGetRestoreSettings nuGetRestoreSettings);
        /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p><p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p></summary>
        public static void NuGetRestore (Configure<NuGetRestoreSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var nuGetRestoreSettings = new NuGetRestoreSettings();
            nuGetRestoreSettings = configurator(nuGetRestoreSettings);
            PreProcess(nuGetRestoreSettings);
            var process = ProcessTasks.StartProcess(nuGetRestoreSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(nuGetRestoreSettings);
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
        /// <summary><p>The API key for the target repository. If not present, the one specified in <i>%AppData%\NuGet\NuGet.Config</i> is used.</p></summary>
        public virtual string ApiKey { get; internal set; }
        /// <summary><p>Specifies the server URL. With NuGet 2.5+, NuGet will identify a UNC or local folder source and simply copy the file there instead of pushing it using HTTP. Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <i>NuGet.Config</i> file specifies a <i>DefaultPushSource</i> value.</p></summary>
        public virtual string Source { get; internal set; }
        /// <summary><p><i>(3.5+)</i> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p></summary>
        public virtual string SymbolSource { get; internal set; }
        /// <summary><p><i>(3.5+)</i> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p></summary>
        public virtual string SymbolApiKey { get; internal set; }
        /// <summary><p><i>(3.5+)</i> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        public virtual bool NoSymbols { get; internal set; }
        /// <summary><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        public virtual bool DisableBuffering { get; internal set; }
        /// <summary><p><i>(2.5+)</i> The NuGet configuration file to apply. If not specified, <i>%AppData%\NuGet\NuGet.Config</i> is used.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p><i>(2.5+)</i> Specifies the amount of details displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p></summary>
        public virtual NuGetVerbosity? Verbosity { get; internal set; }
        /// <summary><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
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
        /// <summary><p>Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        public virtual bool MinClientVersion { get; internal set; }
        /// <summary><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        public virtual bool ForceEnglishOutput { get; internal set; }
        /// <summary><p><i>(4.0+)</i> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        public virtual string MSBuildPath { get; internal set; }
        /// <summary><p><i>(3.2+)</i> Specifies the version of MSBuild to be used with this command. Supported values are <i>4</i>, <i>12</i>, <i>14</i>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        public virtual Nuke.Common.Tools.MSBuild.MSBuildVersion? MSBuildVersion { get; internal set; }
        /// <summary><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>.</p></summary>
        public virtual bool NoDefaultExcludes { get; internal set; }
        /// <summary><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        public virtual bool NoPackageAnalysis { get; internal set; }
        /// <summary><p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p></summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p><i>(3.4.4+)</i> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p></summary>
        public virtual string Suffix { get; internal set; }
        /// <summary><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        public virtual bool Symbols { get; internal set; }
        /// <summary><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        public virtual bool Tool { get; internal set; }
        /// <summary><p><i>(2.5+)</i> Specifies the amount of details displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p></summary>
        public virtual NuGetVerbosity? Verbosity { get; internal set; }
        /// <summary><p>Overrides the version number from the <c>.nuspec</c> file.</p></summary>
        public virtual string Version { get; internal set; }
        public virtual string Configuration { get; internal set; }
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
              .Add("-MSBuildVersion {value}", GetMSBuildVersion())
              .Add("-NoDefaultExcludes", NoDefaultExcludes)
              .Add("-NoPackageAnalysis", NoPackageAnalysis)
              .Add("-OutputDirectory {value}", OutputDirectory)
              .Add("-Properties {value}", GetProperties())
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
        /// <summary><p>The NuGet configuration file to apply. If not specified, <i>%AppData%\NuGet\NuGet.Config</i> is used.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary><p><i>(4.0+)</i> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        public virtual bool DirectDownload { get; internal set; }
        /// <summary><p>Disables restoring multiple packages in parallel.</p></summary>
        public virtual bool DisableParallelProcessing { get; internal set; }
        /// <summary><p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        public virtual IReadOnlyList<string> FallbackSource => FallbackSourceInternal.AsReadOnly();
        internal List<string> FallbackSourceInternal { get; set; } = new List<string>();
        /// <summary><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        public virtual bool ForceEnglishOutput { get; internal set; }
        /// <summary><p><i>(4.0+)</i> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        public virtual string MSBuildPath { get; internal set; }
        /// <summary><p><i>(3.2+)</i> Specifies the version of MSBuild to be used with this command. Supported values are <i>4</i>, <i>12</i>, <i>14</i>, <i>15</i>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
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
        /// <summary><p><i>(4.0+)</i> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        public virtual bool Recursive { get; internal set; }
        /// <summary><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        public virtual bool RequireConsent { get; internal set; }
        /// <summary><p>Specifies the solution folder. Not valid when restoring packages for a solution.</p></summary>
        public virtual string SolutionDirectory { get; internal set; }
        /// <summary><p>Specifies list of package sources to use for the restore.</p></summary>
        public virtual IReadOnlyList<string> Source => SourceInternal.AsReadOnly();
        internal List<string> SourceInternal { get; set; } = new List<string>();
        /// <summary><p><i>(2.5+)</i> Specifies the amount of detail displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p></summary>
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
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.TargetPath"/>.</i></p><p>Path of the package to push.</p></summary>
        [Pure]
        public static NuGetPushSettings SetTargetPath(this NuGetPushSettings nuGetPushSettings, string targetPath)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.TargetPath = targetPath;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.ApiKey"/>.</i></p><p>The API key for the target repository. If not present, the one specified in <i>%AppData%\NuGet\NuGet.Config</i> is used.</p></summary>
        [Pure]
        public static NuGetPushSettings SetApiKey(this NuGetPushSettings nuGetPushSettings, string apiKey)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ApiKey = apiKey;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.Source"/>.</i></p><p>Specifies the server URL. With NuGet 2.5+, NuGet will identify a UNC or local folder source and simply copy the file there instead of pushing it using HTTP. Also, starting with NuGet 3.4.2, this is a mandatory parameter unless the <i>NuGet.Config</i> file specifies a <i>DefaultPushSource</i> value.</p></summary>
        [Pure]
        public static NuGetPushSettings SetSource(this NuGetPushSettings nuGetPushSettings, string source)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.Source = source;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.SymbolSource"/>.</i></p><p><i>(3.5+)</i> Specifies the symbol server URL; nuget.smbsrc.net is used when pushing to nuget.org</p></summary>
        [Pure]
        public static NuGetPushSettings SetSymbolSource(this NuGetPushSettings nuGetPushSettings, string symbolSource)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.SymbolSource = symbolSource;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.SymbolApiKey"/>.</i></p><p><i>(3.5+)</i> Specifies the API key for the URL specified in <c>-SymbolSource</c>.</p></summary>
        [Pure]
        public static NuGetPushSettings SetSymbolApiKey(this NuGetPushSettings nuGetPushSettings, string symbolApiKey)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.SymbolApiKey = symbolApiKey;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.NoSymbols"/>.</i></p><p><i>(3.5+)</i> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings SetNoSymbols(this NuGetPushSettings nuGetPushSettings, bool noSymbols)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NoSymbols = noSymbols;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPushSettings.NoSymbols"/>.</i></p><p><i>(3.5+)</i> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableNoSymbols(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NoSymbols = true;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPushSettings.NoSymbols"/>.</i></p><p><i>(3.5+)</i> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableNoSymbols(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NoSymbols = false;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPushSettings.NoSymbols"/>.</i></p><p><i>(3.5+)</i> If a symbols package exists, it will not be pushed to a symbol server.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleNoSymbols(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NoSymbols = !nuGetPushSettings.NoSymbols;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings SetDisableBuffering(this NuGetPushSettings nuGetPushSettings, bool disableBuffering)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.DisableBuffering = disableBuffering;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableDisableBuffering(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.DisableBuffering = true;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableDisableBuffering(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.DisableBuffering = false;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPushSettings.DisableBuffering"/>.</i></p><p>Disables buffering when pushing to an HTTP(s) server to decrease memory usages. Caution: when this option is used, integrated Windows authentication might not work.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleDisableBuffering(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.DisableBuffering = !nuGetPushSettings.DisableBuffering;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.ConfigFile"/>.</i></p><p><i>(2.5+)</i> The NuGet configuration file to apply. If not specified, <i>%AppData%\NuGet\NuGet.Config</i> is used.</p></summary>
        [Pure]
        public static NuGetPushSettings SetConfigFile(this NuGetPushSettings nuGetPushSettings, string configFile)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ConfigFile = configFile;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.Verbosity"/>.</i></p><p><i>(2.5+)</i> Specifies the amount of details displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p></summary>
        [Pure]
        public static NuGetPushSettings SetVerbosity(this NuGetPushSettings nuGetPushSettings, NuGetVerbosity? verbosity)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.Verbosity = verbosity;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings SetForceEnglishOutput(this NuGetPushSettings nuGetPushSettings, bool forceEnglishOutput)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ForceEnglishOutput = forceEnglishOutput;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableForceEnglishOutput(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ForceEnglishOutput = true;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableForceEnglishOutput(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ForceEnglishOutput = false;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPushSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleForceEnglishOutput(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.ForceEnglishOutput = !nuGetPushSettings.ForceEnglishOutput;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings SetNonInteractive(this NuGetPushSettings nuGetPushSettings, bool nonInteractive)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NonInteractive = nonInteractive;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPushSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings EnableNonInteractive(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NonInteractive = true;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPushSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings DisableNonInteractive(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NonInteractive = false;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPushSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetPushSettings ToggleNonInteractive(this NuGetPushSettings nuGetPushSettings)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.NonInteractive = !nuGetPushSettings.NonInteractive;
            return nuGetPushSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPushSettings.Timeout"/>.</i></p><p>Specifies the timeout, in seconds, for pushing to a server. The default is 300 seconds (5 minutes).</p></summary>
        [Pure]
        public static NuGetPushSettings SetTimeout(this NuGetPushSettings nuGetPushSettings, int? timeout)
        {
            nuGetPushSettings = nuGetPushSettings.NewInstance();
            nuGetPushSettings.Timeout = timeout;
            return nuGetPushSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetPackSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.TargetPath"/>.</i></p><p>The <c>.nuspec</c> or <c>.csproj</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetTargetPath(this NuGetPackSettings nuGetPackSettings, string targetPath)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.TargetPath = targetPath;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.BasePath"/>.</i></p><p>Sets the base path of the files defined in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetBasePath(this NuGetPackSettings nuGetPackSettings, string basePath)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.BasePath = basePath;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.Build"/>.</i></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetBuild(this NuGetPackSettings nuGetPackSettings, bool build)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Build = build;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPackSettings.Build"/>.</i></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableBuild(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Build = true;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPackSettings.Build"/>.</i></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableBuild(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Build = false;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPackSettings.Build"/>.</i></p><p>Specifies that the project should be built before building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleBuild(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Build = !nuGetPackSettings.Build;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.Exclude"/>.</i></p><p>Specifies one or more wildcard patterns to exclude when creating a package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetExclude(this NuGetPackSettings nuGetPackSettings, string exclude)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Exclude = exclude;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetExcludeEmptyDirectories(this NuGetPackSettings nuGetPackSettings, bool excludeEmptyDirectories)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ExcludeEmptyDirectories = excludeEmptyDirectories;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableExcludeEmptyDirectories(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ExcludeEmptyDirectories = true;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableExcludeEmptyDirectories(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ExcludeEmptyDirectories = false;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPackSettings.ExcludeEmptyDirectories"/>.</i></p><p>Prevent inclusion of empty directories when building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleExcludeEmptyDirectories(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ExcludeEmptyDirectories = !nuGetPackSettings.ExcludeEmptyDirectories;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetIncludeReferencedProjects(this NuGetPackSettings nuGetPackSettings, bool includeReferencedProjects)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.IncludeReferencedProjects = includeReferencedProjects;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableIncludeReferencedProjects(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.IncludeReferencedProjects = true;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableIncludeReferencedProjects(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.IncludeReferencedProjects = false;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPackSettings.IncludeReferencedProjects"/>.</i></p><p>Indicates that the built package should include referenced projects either as dependencies or as part of the package. If a referenced project has a corresponding <c>.nuspec</c> file that has the same name as the project, then that referenced project is added as a dependency. Otherwise, the referenced project is added as part of the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleIncludeReferencedProjects(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.IncludeReferencedProjects = !nuGetPackSettings.IncludeReferencedProjects;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p><p>Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetMinClientVersion(this NuGetPackSettings nuGetPackSettings, bool minClientVersion)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MinClientVersion = minClientVersion;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p><p>Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableMinClientVersion(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MinClientVersion = true;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p><p>Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableMinClientVersion(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MinClientVersion = false;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPackSettings.MinClientVersion"/>.</i></p><p>Set the <i>minClientVersion</i> attribute for the created package. This value will override the value of the existing <i>minClientVersion</i> attribute (if any) in the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleMinClientVersion(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MinClientVersion = !nuGetPackSettings.MinClientVersion;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings SetForceEnglishOutput(this NuGetPackSettings nuGetPackSettings, bool forceEnglishOutput)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ForceEnglishOutput = forceEnglishOutput;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableForceEnglishOutput(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ForceEnglishOutput = true;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableForceEnglishOutput(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ForceEnglishOutput = false;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPackSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleForceEnglishOutput(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.ForceEnglishOutput = !nuGetPackSettings.ForceEnglishOutput;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.MSBuildPath"/>.</i></p><p><i>(4.0+)</i> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetMSBuildPath(this NuGetPackSettings nuGetPackSettings, string msbuildPath)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MSBuildPath = msbuildPath;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.MSBuildVersion"/>.</i></p><p><i>(3.2+)</i> Specifies the version of MSBuild to be used with this command. Supported values are <i>4</i>, <i>12</i>, <i>14</i>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        [Pure]
        public static NuGetPackSettings SetMSBuildVersion(this NuGetPackSettings nuGetPackSettings, Nuke.Common.Tools.MSBuild.MSBuildVersion? msbuildVersion)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.MSBuildVersion = msbuildVersion;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetNoDefaultExcludes(this NuGetPackSettings nuGetPackSettings, bool noDefaultExcludes)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoDefaultExcludes = noDefaultExcludes;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableNoDefaultExcludes(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoDefaultExcludes = true;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableNoDefaultExcludes(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoDefaultExcludes = false;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPackSettings.NoDefaultExcludes"/>.</i></p><p>Prevents default exclusion of NuGet package files and files and folders starting with a dot, such as <i>.svn</i> and <c>.gitignore</c>.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleNoDefaultExcludes(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoDefaultExcludes = !nuGetPackSettings.NoDefaultExcludes;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetNoPackageAnalysis(this NuGetPackSettings nuGetPackSettings, bool noPackageAnalysis)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoPackageAnalysis = noPackageAnalysis;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableNoPackageAnalysis(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoPackageAnalysis = true;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableNoPackageAnalysis(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoPackageAnalysis = false;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPackSettings.NoPackageAnalysis"/>.</i></p><p>Specifies that pack should not run package analysis after building the package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleNoPackageAnalysis(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.NoPackageAnalysis = !nuGetPackSettings.NoPackageAnalysis;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.OutputDirectory"/>.</i></p><p>Specifies the folder in which the created package is stored. If no folder is specified, the current folder is used.</p></summary>
        [Pure]
        public static NuGetPackSettings SetOutputDirectory(this NuGetPackSettings nuGetPackSettings, string outputDirectory)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.OutputDirectory = outputDirectory;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.Properties"/> to a new dictionary.</i></p><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        [Pure]
        public static NuGetPackSettings SetProperties(this NuGetPackSettings nuGetPackSettings, IDictionary<string, string> properties)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="NuGetPackSettings.Properties"/>.</i></p><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        [Pure]
        public static NuGetPackSettings ClearProperties(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.PropertiesInternal.Clear();
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for adding a property to <see cref="NuGetPackSettings.Properties"/>.</i></p><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        [Pure]
        public static NuGetPackSettings AddProperty(this NuGetPackSettings nuGetPackSettings, string propertyKey, string propertyValue)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for removing a property from <see cref="NuGetPackSettings.Properties"/>.</i></p><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        [Pure]
        public static NuGetPackSettings RemoveProperty(this NuGetPackSettings nuGetPackSettings, string propertyKey)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.PropertiesInternal.Remove(propertyKey);
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting a property in <see cref="NuGetPackSettings.Properties"/>.</i></p><p>Specifies a list of <c>token=value</c> pairs, separated by semicolons, where each occurrence of <c>$token$</c> in the <c>.nuspec</c> file will be replaced with the given value. Values can be strings in quotation marks.</p></summary>
        [Pure]
        public static NuGetPackSettings SetProperty(this NuGetPackSettings nuGetPackSettings, string propertyKey, string propertyValue)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.PropertiesInternal[propertyKey] = propertyValue;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.Suffix"/>.</i></p><p><i>(3.4.4+)</i> Appends a suffix to the internally generated version number, typically used for appending build or other pre-release identifiers. For example, using <c>-suffix nightly</c> will create a package with a version number like <c>1.2.3-nightly</c>. Suffixes must start with a letter to avoid warnings, errors, and potential incompatibilities with different versions of NuGet and the NuGet Package Manager.</p></summary>
        [Pure]
        public static NuGetPackSettings SetSuffix(this NuGetPackSettings nuGetPackSettings, string suffix)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Suffix = suffix;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.Symbols"/>.</i></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings SetSymbols(this NuGetPackSettings nuGetPackSettings, bool symbols)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Symbols = symbols;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPackSettings.Symbols"/>.</i></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableSymbols(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Symbols = true;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPackSettings.Symbols"/>.</i></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableSymbols(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Symbols = false;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPackSettings.Symbols"/>.</i></p><p>Specifies that the package contains sources and symbols. When used with a <c>.nuspec</c> file, this creates a regular NuGet package file and the corresponding symbols package.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleSymbols(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Symbols = !nuGetPackSettings.Symbols;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.Tool"/>.</i></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings SetTool(this NuGetPackSettings nuGetPackSettings, bool tool)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Tool = tool;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetPackSettings.Tool"/>.</i></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings EnableTool(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Tool = true;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetPackSettings.Tool"/>.</i></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings DisableTool(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Tool = false;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetPackSettings.Tool"/>.</i></p><p>Specifies that the output files of the project should be placed in the <c>tool</c> folder.</p></summary>
        [Pure]
        public static NuGetPackSettings ToggleTool(this NuGetPackSettings nuGetPackSettings)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Tool = !nuGetPackSettings.Tool;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.Verbosity"/>.</i></p><p><i>(2.5+)</i> Specifies the amount of details displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p></summary>
        [Pure]
        public static NuGetPackSettings SetVerbosity(this NuGetPackSettings nuGetPackSettings, NuGetVerbosity? verbosity)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Verbosity = verbosity;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.Version"/>.</i></p><p>Overrides the version number from the <c>.nuspec</c> file.</p></summary>
        [Pure]
        public static NuGetPackSettings SetVersion(this NuGetPackSettings nuGetPackSettings, string version)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Version = version;
            return nuGetPackSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetPackSettings.Configuration"/>.</i></p></summary>
        [Pure]
        public static NuGetPackSettings SetConfiguration(this NuGetPackSettings nuGetPackSettings, string configuration)
        {
            nuGetPackSettings = nuGetPackSettings.NewInstance();
            nuGetPackSettings.Configuration = configuration;
            return nuGetPackSettings;
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class NuGetRestoreSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.TargetPath"/>.</i></p><p>Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetTargetPath(this NuGetRestoreSettings nuGetRestoreSettings, string targetPath)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.TargetPath = targetPath;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.ConfigFile"/>.</i></p><p>The NuGet configuration file to apply. If not specified, <i>%AppData%\NuGet\NuGet.Config</i> is used.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetConfigFile(this NuGetRestoreSettings nuGetRestoreSettings, string configFile)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.ConfigFile = configFile;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p><p><i>(4.0+)</i> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetDirectDownload(this NuGetRestoreSettings nuGetRestoreSettings, bool directDownload)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DirectDownload = directDownload;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p><p><i>(4.0+)</i> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableDirectDownload(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DirectDownload = true;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p><p><i>(4.0+)</i> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableDirectDownload(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DirectDownload = false;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p><p><i>(4.0+)</i> Downloads packages directly without populating caches with any binaries or metadata.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleDirectDownload(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DirectDownload = !nuGetRestoreSettings.DirectDownload;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetDisableParallelProcessing(this NuGetRestoreSettings nuGetRestoreSettings, bool disableParallelProcessing)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DisableParallelProcessing = disableParallelProcessing;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableDisableParallelProcessing(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DisableParallelProcessing = true;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableDisableParallelProcessing(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DisableParallelProcessing = false;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p><p>Disables restoring multiple packages in parallel.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleDisableParallelProcessing(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DisableParallelProcessing = !nuGetRestoreSettings.DisableParallelProcessing;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.FallbackSource"/> to a new list.</i></p><p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, params string[] fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal = fallbackSource.ToList();
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.FallbackSource"/> to a new list.</i></p><p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, IEnumerable<string> fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal = fallbackSource.ToList();
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding new fallbackSource to the existing <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p><p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, params string[] fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding new fallbackSource to the existing <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p><p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, IEnumerable<string> fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p><p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ClearFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal.Clear();
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding a single fallbackSource to <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p><p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, string fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal.Add(fallbackSource);
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for removing a single fallbackSource from <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p><p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p></summary>
        [Pure]
        public static NuGetRestoreSettings RemoveFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, string fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal.Remove(fallbackSource);
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetForceEnglishOutput(this NuGetRestoreSettings nuGetRestoreSettings, bool forceEnglishOutput)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.ForceEnglishOutput = forceEnglishOutput;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableForceEnglishOutput(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.ForceEnglishOutput = true;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableForceEnglishOutput(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.ForceEnglishOutput = false;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p><p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleForceEnglishOutput(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.ForceEnglishOutput = !nuGetRestoreSettings.ForceEnglishOutput;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.MSBuildPath"/>.</i></p><p><i>(4.0+)</i> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetMSBuildPath(this NuGetRestoreSettings nuGetRestoreSettings, string msbuildPath)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.MSBuildPath = msbuildPath;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.MSBuildVersion"/>.</i></p><p><i>(3.2+)</i> Specifies the version of MSBuild to be used with this command. Supported values are <i>4</i>, <i>12</i>, <i>14</i>, <i>15</i>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetMSBuildVersion(this NuGetRestoreSettings nuGetRestoreSettings, Nuke.Common.Tools.MSBuild.MSBuildVersion? msbuildVersion)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.MSBuildVersion = msbuildVersion;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.NoCache"/>.</i></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetNoCache(this NuGetRestoreSettings nuGetRestoreSettings, bool noCache)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NoCache = noCache;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetRestoreSettings.NoCache"/>.</i></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableNoCache(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NoCache = true;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetRestoreSettings.NoCache"/>.</i></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableNoCache(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NoCache = false;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetRestoreSettings.NoCache"/>.</i></p><p>Prevents NuGet from using packages from local machine caches.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleNoCache(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NoCache = !nuGetRestoreSettings.NoCache;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetNonInteractive(this NuGetRestoreSettings nuGetRestoreSettings, bool nonInteractive)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NonInteractive = nonInteractive;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableNonInteractive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NonInteractive = true;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableNonInteractive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NonInteractive = false;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p><p>Suppresses prompts for user input or confirmations.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleNonInteractive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NonInteractive = !nuGetRestoreSettings.NonInteractive;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.OutputDirectory"/>.</i></p><p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetOutputDirectory(this NuGetRestoreSettings nuGetRestoreSettings, string outputDirectory)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.OutputDirectory = outputDirectory;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.PackageSaveMode"/>.</i></p><p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetPackageSaveMode(this NuGetRestoreSettings nuGetRestoreSettings, PackageSaveMode? packageSaveMode)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.PackageSaveMode = packageSaveMode;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.PackagesDirectory"/>.</i></p><p>Same as <c>OutputDirectory</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetPackagesDirectory(this NuGetRestoreSettings nuGetRestoreSettings, string packagesDirectory)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.PackagesDirectory = packagesDirectory;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/>.</i></p><p>Timeout in seconds for resolving project-to-project references.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetProject2ProjectTimeOut(this NuGetRestoreSettings nuGetRestoreSettings, int? project2ProjectTimeOut)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Project2ProjectTimeOut = project2ProjectTimeOut;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.Recursive"/>.</i></p><p><i>(4.0+)</i> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetRecursive(this NuGetRestoreSettings nuGetRestoreSettings, bool recursive)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Recursive = recursive;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetRestoreSettings.Recursive"/>.</i></p><p><i>(4.0+)</i> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableRecursive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Recursive = true;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetRestoreSettings.Recursive"/>.</i></p><p><i>(4.0+)</i> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableRecursive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Recursive = false;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetRestoreSettings.Recursive"/>.</i></p><p><i>(4.0+)</i> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleRecursive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Recursive = !nuGetRestoreSettings.Recursive;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetRequireConsent(this NuGetRestoreSettings nuGetRestoreSettings, bool requireConsent)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.RequireConsent = requireConsent;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings EnableRequireConsent(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.RequireConsent = true;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings DisableRequireConsent(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.RequireConsent = false;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p><p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ToggleRequireConsent(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.RequireConsent = !nuGetRestoreSettings.RequireConsent;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.SolutionDirectory"/>.</i></p><p>Specifies the solution folder. Not valid when restoring packages for a solution.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetSolutionDirectory(this NuGetRestoreSettings nuGetRestoreSettings, string solutionDirectory)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SolutionDirectory = solutionDirectory;
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.Source"/> to a new list.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetSource(this NuGetRestoreSettings nuGetRestoreSettings, params string[] source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal = source.ToList();
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.Source"/> to a new list.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetSource(this NuGetRestoreSettings nuGetRestoreSettings, IEnumerable<string> source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal = source.ToList();
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding new source to the existing <see cref="NuGetRestoreSettings.Source"/>.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings nuGetRestoreSettings, params string[] source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal.AddRange(source);
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding new source to the existing <see cref="NuGetRestoreSettings.Source"/>.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings nuGetRestoreSettings, IEnumerable<string> source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal.AddRange(source);
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="NuGetRestoreSettings.Source"/>.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings ClearSource(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal.Clear();
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for adding a single source to <see cref="NuGetRestoreSettings.Source"/>.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings nuGetRestoreSettings, string source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal.Add(source);
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for removing a single source from <see cref="NuGetRestoreSettings.Source"/>.</i></p><p>Specifies list of package sources to use for the restore.</p></summary>
        [Pure]
        public static NuGetRestoreSettings RemoveSource(this NuGetRestoreSettings nuGetRestoreSettings, string source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal.Remove(source);
            return nuGetRestoreSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="NuGetRestoreSettings.Verbosity"/>.</i></p><p><i>(2.5+)</i> Specifies the amount of detail displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p></summary>
        [Pure]
        public static NuGetRestoreSettings SetVerbosity(this NuGetRestoreSettings nuGetRestoreSettings, NuGetVerbosity? verbosity)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Verbosity = verbosity;
            return nuGetRestoreSettings;
        }
    }
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p></summary>
    [PublicAPI]
    public enum NuGetVerbosity
    {
        Normal,
        Quiet,
        Detailed
    }
    /// <summary><p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p></summary>
    [PublicAPI]
    public enum PackageSaveMode
    {
        Nuspec,
        Nupkg,
        NuspecAndNupkg
    }
}

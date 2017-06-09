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

namespace Nuke.Common.Tools.NuGet
{
    public static partial class NuGetTasks
    {
        static partial void PreProcess (NuGetRestoreSettings nuGetRestoreSettings);
        static partial void PostProcess (NuGetRestoreSettings nuGetRestoreSettings);
        /// <summary>
        /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        public static void NuGetRestore (Configure<NuGetRestoreSettings> nuGetRestoreSettingsConfigure = null, ProcessSettings processSettings = null)
        {
            nuGetRestoreSettingsConfigure = nuGetRestoreSettingsConfigure ?? (x => x);
            var nuGetRestoreSettings = new NuGetRestoreSettings();
            nuGetRestoreSettings = nuGetRestoreSettingsConfigure(nuGetRestoreSettings);
            PreProcess(nuGetRestoreSettings);
            var process = ProcessManager.Instance.StartProcess(nuGetRestoreSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(nuGetRestoreSettings);
        }
        /// <summary>
        /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
        /// </summary>
        public static void NuGetRestore (string targetPath, Configure<NuGetRestoreSettings> nuGetRestoreSettingsConfigure = null, ProcessSettings processSettings = null)
        {
            nuGetRestoreSettingsConfigure = nuGetRestoreSettingsConfigure ?? (x => x);
            NuGetRestore(x => nuGetRestoreSettingsConfigure(x).SetTargetPath(targetPath));
        }
    }
    /// <summary>
    /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
    /// </summary>
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
              .Add($"restore")
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
    public static partial class NuGetRestoreSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.TargetPath"/>.</i></p>
        /// <p>Defines the project to restore. I.e., the location of a solution file, a <c>packages.config</c>, or a <c>project.json</c> file.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetTargetPath(this NuGetRestoreSettings nuGetRestoreSettings, string targetPath)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.TargetPath = targetPath;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.ConfigFile"/>.</i></p>
        /// <p>The NuGet configuration file to apply. If not specified, <i>%AppData%\NuGet\NuGet.Config</i> is used.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetConfigFile(this NuGetRestoreSettings nuGetRestoreSettings, string configFile)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.ConfigFile = configFile;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p>
        /// <p><i>(4.0+)</i> Downloads packages directly without populating caches with any binaries or metadata.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetDirectDownload(this NuGetRestoreSettings nuGetRestoreSettings, bool directDownload)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DirectDownload = directDownload;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p>
        /// <p><i>(4.0+)</i> Downloads packages directly without populating caches with any binaries or metadata.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings EnableDirectDownload(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DirectDownload = true;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p>
        /// <p><i>(4.0+)</i> Downloads packages directly without populating caches with any binaries or metadata.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings DisableDirectDownload(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DirectDownload = false;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetRestoreSettings.DirectDownload"/>.</i></p>
        /// <p><i>(4.0+)</i> Downloads packages directly without populating caches with any binaries or metadata.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings ToggleDirectDownload(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DirectDownload = !nuGetRestoreSettings.DirectDownload;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p>
        /// <p>Disables restoring multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetDisableParallelProcessing(this NuGetRestoreSettings nuGetRestoreSettings, bool disableParallelProcessing)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DisableParallelProcessing = disableParallelProcessing;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p>
        /// <p>Disables restoring multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings EnableDisableParallelProcessing(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DisableParallelProcessing = true;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p>
        /// <p>Disables restoring multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings DisableDisableParallelProcessing(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DisableParallelProcessing = false;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetRestoreSettings.DisableParallelProcessing"/>.</i></p>
        /// <p>Disables restoring multiple packages in parallel.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings ToggleDisableParallelProcessing(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.DisableParallelProcessing = !nuGetRestoreSettings.DisableParallelProcessing;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.FallbackSource"/> to a new list.</i></p>
        /// <p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, params string[] fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal = fallbackSource.ToList();
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.FallbackSource"/> to a new list.</i></p>
        /// <p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, IEnumerable<string> fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal = fallbackSource.ToList();
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new fallbackSource to the existing <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p>
        /// <p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, params string[] fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new fallbackSource to the existing <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p>
        /// <p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, IEnumerable<string> fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal.AddRange(fallbackSource);
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p>
        /// <p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings ClearFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal.Clear();
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single fallbackSource to <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p>
        /// <p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings AddFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, string fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal.Add(fallbackSource);
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single fallbackSource from <see cref="NuGetRestoreSettings.FallbackSource"/>.</i></p>
        /// <p><i>(3.2+)</i> A list of package sources to use as fallbacks in case the package isn't found in the primary or default source.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings RemoveFallbackSource(this NuGetRestoreSettings nuGetRestoreSettings, string fallbackSource)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.FallbackSourceInternal.Remove(fallbackSource);
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetForceEnglishOutput(this NuGetRestoreSettings nuGetRestoreSettings, bool forceEnglishOutput)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.ForceEnglishOutput = forceEnglishOutput;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings EnableForceEnglishOutput(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.ForceEnglishOutput = true;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings DisableForceEnglishOutput(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.ForceEnglishOutput = false;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetRestoreSettings.ForceEnglishOutput"/>.</i></p>
        /// <p><i>(3.5+)</i> Forces nuget.exe to run using an invariant, English-based culture.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings ToggleForceEnglishOutput(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.ForceEnglishOutput = !nuGetRestoreSettings.ForceEnglishOutput;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.MSBuildPath"/>.</i></p>
        /// <p><i>(4.0+)</i> Specifies the path of MSBuild to use with the command, taking precedence over <c>-MSBuildVersion</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetMSBuildPath(this NuGetRestoreSettings nuGetRestoreSettings, string msbuildPath)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.MSBuildPath = msbuildPath;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.MSBuildVersion"/>.</i></p>
        /// <p><i>(3.2+)</i> Specifies the version of MSBuild to be used with this command. Supported values are <i>4</i>, <i>12</i>, <i>14</i>, <i>15</i>. By default the MSBuild in your path is picked, otherwise it defaults to the highest installed version of MSBuild.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetMSBuildVersion(this NuGetRestoreSettings nuGetRestoreSettings, Nuke.Common.Tools.MSBuild.MSBuildVersion? msbuildVersion)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.MSBuildVersion = msbuildVersion;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.NoCache"/>.</i></p>
        /// <p>Prevents NuGet from using packages from local machine caches.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetNoCache(this NuGetRestoreSettings nuGetRestoreSettings, bool noCache)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NoCache = noCache;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetRestoreSettings.NoCache"/>.</i></p>
        /// <p>Prevents NuGet from using packages from local machine caches.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings EnableNoCache(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NoCache = true;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetRestoreSettings.NoCache"/>.</i></p>
        /// <p>Prevents NuGet from using packages from local machine caches.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings DisableNoCache(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NoCache = false;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetRestoreSettings.NoCache"/>.</i></p>
        /// <p>Prevents NuGet from using packages from local machine caches.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings ToggleNoCache(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NoCache = !nuGetRestoreSettings.NoCache;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p>
        /// <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetNonInteractive(this NuGetRestoreSettings nuGetRestoreSettings, bool nonInteractive)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NonInteractive = nonInteractive;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p>
        /// <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings EnableNonInteractive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NonInteractive = true;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p>
        /// <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings DisableNonInteractive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NonInteractive = false;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetRestoreSettings.NonInteractive"/>.</i></p>
        /// <p>Suppresses prompts for user input or confirmations.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings ToggleNonInteractive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.NonInteractive = !nuGetRestoreSettings.NonInteractive;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.OutputDirectory"/>.</i></p>
        /// <p>Specifies the folder in which packages are installed. If no folder is specified, the current folder is used.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetOutputDirectory(this NuGetRestoreSettings nuGetRestoreSettings, string outputDirectory)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.OutputDirectory = outputDirectory;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.PackageSaveMode"/>.</i></p>
        /// <p>Specifies the types of files to save after package installation: one of <c>nuspec</c>, <c>nupkg</c>, or <c>nuspec;nupkg</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetPackageSaveMode(this NuGetRestoreSettings nuGetRestoreSettings, PackageSaveMode? packageSaveMode)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.PackageSaveMode = packageSaveMode;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.PackagesDirectory"/>.</i></p>
        /// <p>Same as <c>OutputDirectory</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetPackagesDirectory(this NuGetRestoreSettings nuGetRestoreSettings, string packagesDirectory)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.PackagesDirectory = packagesDirectory;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.Project2ProjectTimeOut"/>.</i></p>
        /// <p>Timeout in seconds for resolving project-to-project references.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetProject2ProjectTimeOut(this NuGetRestoreSettings nuGetRestoreSettings, int? project2ProjectTimeOut)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Project2ProjectTimeOut = project2ProjectTimeOut;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.Recursive"/>.</i></p>
        /// <p><i>(4.0+)</i> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetRecursive(this NuGetRestoreSettings nuGetRestoreSettings, bool recursive)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Recursive = recursive;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetRestoreSettings.Recursive"/>.</i></p>
        /// <p><i>(4.0+)</i> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings EnableRecursive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Recursive = true;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetRestoreSettings.Recursive"/>.</i></p>
        /// <p><i>(4.0+)</i> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings DisableRecursive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Recursive = false;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetRestoreSettings.Recursive"/>.</i></p>
        /// <p><i>(4.0+)</i> Restores all references projects for UWP and .NET Core projects. Does not apply to projects using <c>packages.config</c>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings ToggleRecursive(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Recursive = !nuGetRestoreSettings.Recursive;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p>
        /// <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetRequireConsent(this NuGetRestoreSettings nuGetRestoreSettings, bool requireConsent)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.RequireConsent = requireConsent;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p>
        /// <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings EnableRequireConsent(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.RequireConsent = true;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p>
        /// <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings DisableRequireConsent(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.RequireConsent = false;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="NuGetRestoreSettings.RequireConsent"/>.</i></p>
        /// <p>Verifies that restoring packages is enabled before downloading and installing the packages. For details, see <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore">Package Restore</a>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings ToggleRequireConsent(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.RequireConsent = !nuGetRestoreSettings.RequireConsent;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.SolutionDirectory"/>.</i></p>
        /// <p>Specifies the solution folder. Not valid when restoring packages for a solution.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetSolutionDirectory(this NuGetRestoreSettings nuGetRestoreSettings, string solutionDirectory)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SolutionDirectory = solutionDirectory;
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.Source"/> to a new list.</i></p>
        /// <p>Specifies list of package sources to use for the restore.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetSource(this NuGetRestoreSettings nuGetRestoreSettings, params string[] source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal = source.ToList();
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.Source"/> to a new list.</i></p>
        /// <p>Specifies list of package sources to use for the restore.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetSource(this NuGetRestoreSettings nuGetRestoreSettings, IEnumerable<string> source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal = source.ToList();
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new source to the existing <see cref="NuGetRestoreSettings.Source"/>.</i></p>
        /// <p>Specifies list of package sources to use for the restore.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings nuGetRestoreSettings, params string[] source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal.AddRange(source);
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding new source to the existing <see cref="NuGetRestoreSettings.Source"/>.</i></p>
        /// <p>Specifies list of package sources to use for the restore.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings nuGetRestoreSettings, IEnumerable<string> source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal.AddRange(source);
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for clearing <see cref="NuGetRestoreSettings.Source"/>.</i></p>
        /// <p>Specifies list of package sources to use for the restore.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings ClearSource(this NuGetRestoreSettings nuGetRestoreSettings)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal.Clear();
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for adding a single source to <see cref="NuGetRestoreSettings.Source"/>.</i></p>
        /// <p>Specifies list of package sources to use for the restore.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings AddSource(this NuGetRestoreSettings nuGetRestoreSettings, string source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal.Add(source);
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for removing a single source from <see cref="NuGetRestoreSettings.Source"/>.</i></p>
        /// <p>Specifies list of package sources to use for the restore.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings RemoveSource(this NuGetRestoreSettings nuGetRestoreSettings, string source)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.SourceInternal.Remove(source);
            return nuGetRestoreSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="NuGetRestoreSettings.Verbosity"/>.</i></p>
        /// <p><i>(2.5+)</i> Specifies the amount of detail displayed in the output: <i>normal</i>, <i>quiet</i>, <i>detailed</i>.</p>
        /// </summary>
        [Pure]
        public static NuGetRestoreSettings SetVerbosity(this NuGetRestoreSettings nuGetRestoreSettings, NuGetVerbosity? verbosity)
        {
            nuGetRestoreSettings = nuGetRestoreSettings.NewInstance();
            nuGetRestoreSettings.Verbosity = verbosity;
            return nuGetRestoreSettings;
        }
    }
    /// <summary>
    /// <p>The NuGet Command Line Interface (CLI) provides the full extent of NuGet functionality to install, create, publish, and manage packages.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    public enum PackageSaveMode
    {
        Nuspec,
        Nupkg,
        NuspecAndNupkg
    }
}

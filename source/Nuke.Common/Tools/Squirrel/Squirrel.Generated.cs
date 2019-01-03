// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/Squirrel.json
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

namespace Nuke.Common.Tools.Squirrel
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SquirrelTasks
    {
        /// <summary><p>Path to the Squirrel executable.</p></summary>
        public static string SquirrelPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("SQUIRREL_EXE") ??
            ToolPathResolver.GetPackageExecutable("Squirrel.Windows", "Squirrel.exe");
        /// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p></summary>
        public static IReadOnlyCollection<Output> Squirrel(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(SquirrelPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, null, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p><p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> Squirrel(SquirrelSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new SquirrelSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p><p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> Squirrel(Configure<SquirrelSettings> configurator)
        {
            return Squirrel(configurator(new SquirrelSettings()));
        }
        /// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p><p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p></summary>
        public static IEnumerable<(SquirrelSettings Settings, IReadOnlyCollection<Output> Output)> Squirrel(MultiplexConfigure<SquirrelSettings> configurator)
        {
            return configurator(new SquirrelSettings())
                .Select(x => (ToolSettings: x, ReturnValue: Squirrel(x)))
                .Select(x => (x.ToolSettings, x.ReturnValue)).ToList();
        }
    }
    #region SquirrelSettings
    /// <summary><p>Used within <see cref="SquirrelTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SquirrelSettings : ToolSettings
    {
        /// <summary><p>Path to the Squirrel executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? SquirrelTasks.SquirrelPath;
        /// <summary><p>Install the app whose package is in the specified directory.</p></summary>
        public virtual string Install { get; internal set; }
        /// <summary><p>Uninstall the app the same dir as Update.exe.</p></summary>
        public virtual bool? Uninstall { get; internal set; }
        /// <summary><p>Download the releases specified by the URL and write new results to stdout as JSON.</p></summary>
        public virtual bool? Download { get; internal set; }
        /// <summary><p>Check for one available update and writes new results to stdout as JSON.</p></summary>
        public virtual bool? CheckForUpdate { get; internal set; }
        /// <summary><p>Update the application to the latest remote version specified by URL.</p></summary>
        public virtual string Update { get; internal set; }
        /// <summary><p>Update or generate a releases directory with a given NuGet package.</p></summary>
        public virtual string Releasify { get; internal set; }
        /// <summary><p>Create a shortcut for the given executable name.</p></summary>
        public virtual string CreateShortcut { get; internal set; }
        /// <summary><p>Remove a shortcut for the given executable name.</p></summary>
        public virtual string RemoveShortcut { get; internal set; }
        /// <summary><p>Copy the currently executing Update.exe into the default location.</p></summary>
        public virtual string UpdateSelf { get; internal set; }
        /// <summary><p>Start an executable in the latest version of the app package.</p></summary>
        public virtual string ProcessStart { get; internal set; }
        /// <summary><p>Start an executable in the latest version of the app package.</p></summary>
        public virtual string ProcessStartAndWait { get; internal set; }
        /// <summary><p>Path to a release directory to use with releasify.</p></summary>
        public virtual string ReleaseDirectory { get; internal set; }
        /// <summary><p>Path to the NuGet Packages directory for C# apps.</p></summary>
        public virtual string PackagesDirectory { get; internal set; }
        /// <summary><p>Path to the Setup.exe to use as a template.</p></summary>
        public virtual string BootstrapperExecutable { get; internal set; }
        /// <summary><p>Path to an animated GIF to be displayed during installation.</p></summary>
        public virtual string LoadingGif { get; internal set; }
        /// <summary><p>Path to an ICO file that will be used for icon shortcuts.</p></summary>
        public virtual string Icon { get; internal set; }
        /// <summary><p>Path to an ICO file that will be used for the Setup executable's icon.</p></summary>
        public virtual string SetupIcon { get; internal set; }
        /// <summary><p>Sign the installer via SignTool.exe with the parameters given.</p></summary>
        public virtual string SignWithParameters { get; internal set; }
        /// <summary><p>Provides a base URL to prefix the RELEASES file packages with.</p></summary>
        public virtual string BaseUrl { get; internal set; }
        /// <summary><p>Arguments that will be used when starting executable.</p></summary>
        public virtual string ProcessStartArguments { get; internal set; }
        /// <summary><p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p></summary>
        public virtual IReadOnlyList<string> ShortcutLocations => ShortcutLocationsInternal.AsReadOnly();
        internal List<string> ShortcutLocationsInternal { get; set; } = new List<string>();
        /// <summary><p>Don't generate an MSI package.</p></summary>
        public virtual bool? GenerateNoMsi { get; internal set; }
        /// <summary><p>Don't generate delta packages to save time</p></summary>
        public virtual bool? GenerateNoDelta { get; internal set; }
        /// <summary><p>Set the required .NET framework version, e.g. net461</p></summary>
        public virtual string FrameworkVersion { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(Directory.Exists(Install) || Install == null, $"Directory.Exists(Install) || Install == null [Install = {Install}]");
            ControlFlow.Assert(File.Exists(Releasify), $"File.Exists(Releasify) [Releasify = {Releasify}]");
            ControlFlow.Assert(File.Exists(BootstrapperExecutable) || BootstrapperExecutable == null, $"File.Exists(BootstrapperExecutable) || BootstrapperExecutable == null [BootstrapperExecutable = {BootstrapperExecutable}]");
            ControlFlow.Assert(File.Exists(LoadingGif) || LoadingGif == null, $"File.Exists(LoadingGif) || LoadingGif == null [LoadingGif = {LoadingGif}]");
            ControlFlow.Assert(File.Exists(Icon) || Icon == null, $"File.Exists(Icon) || Icon == null [Icon = {Icon}]");
            ControlFlow.Assert(File.Exists(SetupIcon) || SetupIcon == null, $"File.Exists(SetupIcon) || SetupIcon == null [SetupIcon = {SetupIcon}]");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("--install={value}", Install)
              .Add("--uninstall", Uninstall)
              .Add("--download", Download)
              .Add("--checkForUpdate", CheckForUpdate)
              .Add("--update={value}", Update)
              .Add("--releasify={value}", Releasify)
              .Add("--createShortcut={value}", CreateShortcut)
              .Add("--removeShortcut={value}", RemoveShortcut)
              .Add("--updateSelf={value}", UpdateSelf)
              .Add("--processStart={value}", ProcessStart)
              .Add("--processStartAndWait={value}", ProcessStartAndWait)
              .Add("--releaseDir={value}", ReleaseDirectory)
              .Add("--packagesDir={value}", PackagesDirectory)
              .Add("--bootstrapperExe={value}", BootstrapperExecutable)
              .Add("--loadingGif={value}", LoadingGif)
              .Add("--icon={value}", Icon)
              .Add("--setupIcon={value}", SetupIcon)
              .Add("--signWithParams={value}", SignWithParameters)
              .Add("--baseUrl={value}", BaseUrl)
              .Add("--process-start-args={value}", ProcessStartArguments)
              .Add("--shortcut-locations={value}", ShortcutLocations, separator: ',')
              .Add("--no-msi", GenerateNoMsi)
              .Add("--no-delta", GenerateNoDelta)
              .Add("--framework-version={value}", FrameworkVersion);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region SquirrelSettingsExtensions
    /// <summary><p>Used within <see cref="SquirrelTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SquirrelSettingsExtensions
    {
        #region Install
        /// <summary><p><em>Sets <see cref="SquirrelSettings.Install"/>.</em></p><p>Install the app whose package is in the specified directory.</p></summary>
        [Pure]
        public static SquirrelSettings SetInstall(this SquirrelSettings toolSettings, string install)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = install;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.Install"/>.</em></p><p>Install the app whose package is in the specified directory.</p></summary>
        [Pure]
        public static SquirrelSettings ResetInstall(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = null;
            return toolSettings;
        }
        #endregion
        #region Uninstall
        /// <summary><p><em>Sets <see cref="SquirrelSettings.Uninstall"/>.</em></p><p>Uninstall the app the same dir as Update.exe.</p></summary>
        [Pure]
        public static SquirrelSettings SetUninstall(this SquirrelSettings toolSettings, bool? uninstall)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstall = uninstall;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.Uninstall"/>.</em></p><p>Uninstall the app the same dir as Update.exe.</p></summary>
        [Pure]
        public static SquirrelSettings ResetUninstall(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstall = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SquirrelSettings.Uninstall"/>.</em></p><p>Uninstall the app the same dir as Update.exe.</p></summary>
        [Pure]
        public static SquirrelSettings EnableUninstall(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstall = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SquirrelSettings.Uninstall"/>.</em></p><p>Uninstall the app the same dir as Update.exe.</p></summary>
        [Pure]
        public static SquirrelSettings DisableUninstall(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstall = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SquirrelSettings.Uninstall"/>.</em></p><p>Uninstall the app the same dir as Update.exe.</p></summary>
        [Pure]
        public static SquirrelSettings ToggleUninstall(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstall = !toolSettings.Uninstall;
            return toolSettings;
        }
        #endregion
        #region Download
        /// <summary><p><em>Sets <see cref="SquirrelSettings.Download"/>.</em></p><p>Download the releases specified by the URL and write new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings SetDownload(this SquirrelSettings toolSettings, bool? download)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = download;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.Download"/>.</em></p><p>Download the releases specified by the URL and write new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings ResetDownload(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SquirrelSettings.Download"/>.</em></p><p>Download the releases specified by the URL and write new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings EnableDownload(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SquirrelSettings.Download"/>.</em></p><p>Download the releases specified by the URL and write new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings DisableDownload(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SquirrelSettings.Download"/>.</em></p><p>Download the releases specified by the URL and write new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings ToggleDownload(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = !toolSettings.Download;
            return toolSettings;
        }
        #endregion
        #region CheckForUpdate
        /// <summary><p><em>Sets <see cref="SquirrelSettings.CheckForUpdate"/>.</em></p><p>Check for one available update and writes new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings SetCheckForUpdate(this SquirrelSettings toolSettings, bool? checkForUpdate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = checkForUpdate;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.CheckForUpdate"/>.</em></p><p>Check for one available update and writes new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings ResetCheckForUpdate(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SquirrelSettings.CheckForUpdate"/>.</em></p><p>Check for one available update and writes new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings EnableCheckForUpdate(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SquirrelSettings.CheckForUpdate"/>.</em></p><p>Check for one available update and writes new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings DisableCheckForUpdate(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SquirrelSettings.CheckForUpdate"/>.</em></p><p>Check for one available update and writes new results to stdout as JSON.</p></summary>
        [Pure]
        public static SquirrelSettings ToggleCheckForUpdate(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = !toolSettings.CheckForUpdate;
            return toolSettings;
        }
        #endregion
        #region Update
        /// <summary><p><em>Sets <see cref="SquirrelSettings.Update"/>.</em></p><p>Update the application to the latest remote version specified by URL.</p></summary>
        [Pure]
        public static SquirrelSettings SetUpdate(this SquirrelSettings toolSettings, string update)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Update = update;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.Update"/>.</em></p><p>Update the application to the latest remote version specified by URL.</p></summary>
        [Pure]
        public static SquirrelSettings ResetUpdate(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Update = null;
            return toolSettings;
        }
        #endregion
        #region Releasify
        /// <summary><p><em>Sets <see cref="SquirrelSettings.Releasify"/>.</em></p><p>Update or generate a releases directory with a given NuGet package.</p></summary>
        [Pure]
        public static SquirrelSettings SetReleasify(this SquirrelSettings toolSettings, string releasify)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Releasify = releasify;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.Releasify"/>.</em></p><p>Update or generate a releases directory with a given NuGet package.</p></summary>
        [Pure]
        public static SquirrelSettings ResetReleasify(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Releasify = null;
            return toolSettings;
        }
        #endregion
        #region CreateShortcut
        /// <summary><p><em>Sets <see cref="SquirrelSettings.CreateShortcut"/>.</em></p><p>Create a shortcut for the given executable name.</p></summary>
        [Pure]
        public static SquirrelSettings SetCreateShortcut(this SquirrelSettings toolSettings, string createShortcut)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateShortcut = createShortcut;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.CreateShortcut"/>.</em></p><p>Create a shortcut for the given executable name.</p></summary>
        [Pure]
        public static SquirrelSettings ResetCreateShortcut(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateShortcut = null;
            return toolSettings;
        }
        #endregion
        #region RemoveShortcut
        /// <summary><p><em>Sets <see cref="SquirrelSettings.RemoveShortcut"/>.</em></p><p>Remove a shortcut for the given executable name.</p></summary>
        [Pure]
        public static SquirrelSettings SetRemoveShortcut(this SquirrelSettings toolSettings, string removeShortcut)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RemoveShortcut = removeShortcut;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.RemoveShortcut"/>.</em></p><p>Remove a shortcut for the given executable name.</p></summary>
        [Pure]
        public static SquirrelSettings ResetRemoveShortcut(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RemoveShortcut = null;
            return toolSettings;
        }
        #endregion
        #region UpdateSelf
        /// <summary><p><em>Sets <see cref="SquirrelSettings.UpdateSelf"/>.</em></p><p>Copy the currently executing Update.exe into the default location.</p></summary>
        [Pure]
        public static SquirrelSettings SetUpdateSelf(this SquirrelSettings toolSettings, string updateSelf)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateSelf = updateSelf;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.UpdateSelf"/>.</em></p><p>Copy the currently executing Update.exe into the default location.</p></summary>
        [Pure]
        public static SquirrelSettings ResetUpdateSelf(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateSelf = null;
            return toolSettings;
        }
        #endregion
        #region ProcessStart
        /// <summary><p><em>Sets <see cref="SquirrelSettings.ProcessStart"/>.</em></p><p>Start an executable in the latest version of the app package.</p></summary>
        [Pure]
        public static SquirrelSettings SetProcessStart(this SquirrelSettings toolSettings, string processStart)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStart = processStart;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.ProcessStart"/>.</em></p><p>Start an executable in the latest version of the app package.</p></summary>
        [Pure]
        public static SquirrelSettings ResetProcessStart(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStart = null;
            return toolSettings;
        }
        #endregion
        #region ProcessStartAndWait
        /// <summary><p><em>Sets <see cref="SquirrelSettings.ProcessStartAndWait"/>.</em></p><p>Start an executable in the latest version of the app package.</p></summary>
        [Pure]
        public static SquirrelSettings SetProcessStartAndWait(this SquirrelSettings toolSettings, string processStartAndWait)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStartAndWait = processStartAndWait;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.ProcessStartAndWait"/>.</em></p><p>Start an executable in the latest version of the app package.</p></summary>
        [Pure]
        public static SquirrelSettings ResetProcessStartAndWait(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStartAndWait = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseDirectory
        /// <summary><p><em>Sets <see cref="SquirrelSettings.ReleaseDirectory"/>.</em></p><p>Path to a release directory to use with releasify.</p></summary>
        [Pure]
        public static SquirrelSettings SetReleaseDirectory(this SquirrelSettings toolSettings, string releaseDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseDirectory = releaseDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.ReleaseDirectory"/>.</em></p><p>Path to a release directory to use with releasify.</p></summary>
        [Pure]
        public static SquirrelSettings ResetReleaseDirectory(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseDirectory = null;
            return toolSettings;
        }
        #endregion
        #region PackagesDirectory
        /// <summary><p><em>Sets <see cref="SquirrelSettings.PackagesDirectory"/>.</em></p><p>Path to the NuGet Packages directory for C# apps.</p></summary>
        [Pure]
        public static SquirrelSettings SetPackagesDirectory(this SquirrelSettings toolSettings, string packagesDirectory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesDirectory = packagesDirectory;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.PackagesDirectory"/>.</em></p><p>Path to the NuGet Packages directory for C# apps.</p></summary>
        [Pure]
        public static SquirrelSettings ResetPackagesDirectory(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesDirectory = null;
            return toolSettings;
        }
        #endregion
        #region BootstrapperExecutable
        /// <summary><p><em>Sets <see cref="SquirrelSettings.BootstrapperExecutable"/>.</em></p><p>Path to the Setup.exe to use as a template.</p></summary>
        [Pure]
        public static SquirrelSettings SetBootstrapperExecutable(this SquirrelSettings toolSettings, string bootstrapperExecutable)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BootstrapperExecutable = bootstrapperExecutable;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.BootstrapperExecutable"/>.</em></p><p>Path to the Setup.exe to use as a template.</p></summary>
        [Pure]
        public static SquirrelSettings ResetBootstrapperExecutable(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BootstrapperExecutable = null;
            return toolSettings;
        }
        #endregion
        #region LoadingGif
        /// <summary><p><em>Sets <see cref="SquirrelSettings.LoadingGif"/>.</em></p><p>Path to an animated GIF to be displayed during installation.</p></summary>
        [Pure]
        public static SquirrelSettings SetLoadingGif(this SquirrelSettings toolSettings, string loadingGif)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadingGif = loadingGif;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.LoadingGif"/>.</em></p><p>Path to an animated GIF to be displayed during installation.</p></summary>
        [Pure]
        public static SquirrelSettings ResetLoadingGif(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadingGif = null;
            return toolSettings;
        }
        #endregion
        #region Icon
        /// <summary><p><em>Sets <see cref="SquirrelSettings.Icon"/>.</em></p><p>Path to an ICO file that will be used for icon shortcuts.</p></summary>
        [Pure]
        public static SquirrelSettings SetIcon(this SquirrelSettings toolSettings, string icon)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Icon = icon;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.Icon"/>.</em></p><p>Path to an ICO file that will be used for icon shortcuts.</p></summary>
        [Pure]
        public static SquirrelSettings ResetIcon(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Icon = null;
            return toolSettings;
        }
        #endregion
        #region SetupIcon
        /// <summary><p><em>Sets <see cref="SquirrelSettings.SetupIcon"/>.</em></p><p>Path to an ICO file that will be used for the Setup executable's icon.</p></summary>
        [Pure]
        public static SquirrelSettings SetSetupIcon(this SquirrelSettings toolSettings, string setupIcon)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetupIcon = setupIcon;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.SetupIcon"/>.</em></p><p>Path to an ICO file that will be used for the Setup executable's icon.</p></summary>
        [Pure]
        public static SquirrelSettings ResetSetupIcon(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetupIcon = null;
            return toolSettings;
        }
        #endregion
        #region SignWithParameters
        /// <summary><p><em>Sets <see cref="SquirrelSettings.SignWithParameters"/>.</em></p><p>Sign the installer via SignTool.exe with the parameters given.</p></summary>
        [Pure]
        public static SquirrelSettings SetSignWithParameters(this SquirrelSettings toolSettings, string signWithParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignWithParameters = signWithParameters;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.SignWithParameters"/>.</em></p><p>Sign the installer via SignTool.exe with the parameters given.</p></summary>
        [Pure]
        public static SquirrelSettings ResetSignWithParameters(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignWithParameters = null;
            return toolSettings;
        }
        #endregion
        #region BaseUrl
        /// <summary><p><em>Sets <see cref="SquirrelSettings.BaseUrl"/>.</em></p><p>Provides a base URL to prefix the RELEASES file packages with.</p></summary>
        [Pure]
        public static SquirrelSettings SetBaseUrl(this SquirrelSettings toolSettings, string baseUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseUrl = baseUrl;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.BaseUrl"/>.</em></p><p>Provides a base URL to prefix the RELEASES file packages with.</p></summary>
        [Pure]
        public static SquirrelSettings ResetBaseUrl(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseUrl = null;
            return toolSettings;
        }
        #endregion
        #region ProcessStartArguments
        /// <summary><p><em>Sets <see cref="SquirrelSettings.ProcessStartArguments"/>.</em></p><p>Arguments that will be used when starting executable.</p></summary>
        [Pure]
        public static SquirrelSettings SetProcessStartArguments(this SquirrelSettings toolSettings, string processStartArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStartArguments = processStartArguments;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.ProcessStartArguments"/>.</em></p><p>Arguments that will be used when starting executable.</p></summary>
        [Pure]
        public static SquirrelSettings ResetProcessStartArguments(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStartArguments = null;
            return toolSettings;
        }
        #endregion
        #region ShortcutLocations
        /// <summary><p><em>Sets <see cref="SquirrelSettings.ShortcutLocations"/> to a new list.</em></p><p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p></summary>
        [Pure]
        public static SquirrelSettings SetShortcutLocations(this SquirrelSettings toolSettings, params string[] shortcutLocations)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShortcutLocationsInternal = shortcutLocations.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="SquirrelSettings.ShortcutLocations"/> to a new list.</em></p><p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p></summary>
        [Pure]
        public static SquirrelSettings SetShortcutLocations(this SquirrelSettings toolSettings, IEnumerable<string> shortcutLocations)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShortcutLocationsInternal = shortcutLocations.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="SquirrelSettings.ShortcutLocations"/>.</em></p><p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p></summary>
        [Pure]
        public static SquirrelSettings AddShortcutLocations(this SquirrelSettings toolSettings, params string[] shortcutLocations)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShortcutLocationsInternal.AddRange(shortcutLocations);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="SquirrelSettings.ShortcutLocations"/>.</em></p><p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p></summary>
        [Pure]
        public static SquirrelSettings AddShortcutLocations(this SquirrelSettings toolSettings, IEnumerable<string> shortcutLocations)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShortcutLocationsInternal.AddRange(shortcutLocations);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="SquirrelSettings.ShortcutLocations"/>.</em></p><p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p></summary>
        [Pure]
        public static SquirrelSettings ClearShortcutLocations(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShortcutLocationsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="SquirrelSettings.ShortcutLocations"/>.</em></p><p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p></summary>
        [Pure]
        public static SquirrelSettings RemoveShortcutLocations(this SquirrelSettings toolSettings, params string[] shortcutLocations)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(shortcutLocations);
            toolSettings.ShortcutLocationsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="SquirrelSettings.ShortcutLocations"/>.</em></p><p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p></summary>
        [Pure]
        public static SquirrelSettings RemoveShortcutLocations(this SquirrelSettings toolSettings, IEnumerable<string> shortcutLocations)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(shortcutLocations);
            toolSettings.ShortcutLocationsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenerateNoMsi
        /// <summary><p><em>Sets <see cref="SquirrelSettings.GenerateNoMsi"/>.</em></p><p>Don't generate an MSI package.</p></summary>
        [Pure]
        public static SquirrelSettings SetGenerateNoMsi(this SquirrelSettings toolSettings, bool? generateNoMsi)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoMsi = generateNoMsi;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.GenerateNoMsi"/>.</em></p><p>Don't generate an MSI package.</p></summary>
        [Pure]
        public static SquirrelSettings ResetGenerateNoMsi(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoMsi = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SquirrelSettings.GenerateNoMsi"/>.</em></p><p>Don't generate an MSI package.</p></summary>
        [Pure]
        public static SquirrelSettings EnableGenerateNoMsi(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoMsi = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SquirrelSettings.GenerateNoMsi"/>.</em></p><p>Don't generate an MSI package.</p></summary>
        [Pure]
        public static SquirrelSettings DisableGenerateNoMsi(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoMsi = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SquirrelSettings.GenerateNoMsi"/>.</em></p><p>Don't generate an MSI package.</p></summary>
        [Pure]
        public static SquirrelSettings ToggleGenerateNoMsi(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoMsi = !toolSettings.GenerateNoMsi;
            return toolSettings;
        }
        #endregion
        #region GenerateNoDelta
        /// <summary><p><em>Sets <see cref="SquirrelSettings.GenerateNoDelta"/>.</em></p><p>Don't generate delta packages to save time</p></summary>
        [Pure]
        public static SquirrelSettings SetGenerateNoDelta(this SquirrelSettings toolSettings, bool? generateNoDelta)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoDelta = generateNoDelta;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.GenerateNoDelta"/>.</em></p><p>Don't generate delta packages to save time</p></summary>
        [Pure]
        public static SquirrelSettings ResetGenerateNoDelta(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoDelta = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="SquirrelSettings.GenerateNoDelta"/>.</em></p><p>Don't generate delta packages to save time</p></summary>
        [Pure]
        public static SquirrelSettings EnableGenerateNoDelta(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoDelta = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="SquirrelSettings.GenerateNoDelta"/>.</em></p><p>Don't generate delta packages to save time</p></summary>
        [Pure]
        public static SquirrelSettings DisableGenerateNoDelta(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoDelta = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="SquirrelSettings.GenerateNoDelta"/>.</em></p><p>Don't generate delta packages to save time</p></summary>
        [Pure]
        public static SquirrelSettings ToggleGenerateNoDelta(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoDelta = !toolSettings.GenerateNoDelta;
            return toolSettings;
        }
        #endregion
        #region FrameworkVersion
        /// <summary><p><em>Sets <see cref="SquirrelSettings.FrameworkVersion"/>.</em></p><p>Set the required .NET framework version, e.g. net461</p></summary>
        [Pure]
        public static SquirrelSettings SetFrameworkVersion(this SquirrelSettings toolSettings, string frameworkVersion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FrameworkVersion = frameworkVersion;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="SquirrelSettings.FrameworkVersion"/>.</em></p><p>Set the required .NET framework version, e.g. net461</p></summary>
        [Pure]
        public static SquirrelSettings ResetFrameworkVersion(this SquirrelSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FrameworkVersion = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}

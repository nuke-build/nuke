// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Squirrel/Squirrel.json

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

namespace Nuke.Common.Tools.Squirrel
{
    /// <summary>
    ///   <p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p>
    ///   <p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(SquirrelPackageId)]
    public partial class SquirrelTasks
        : IRequireNuGetPackage
    {
        public const string SquirrelPackageId = "Squirrel.Windows";
        /// <summary>
        ///   Path to the Squirrel executable.
        /// </summary>
        public static string SquirrelPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("SQUIRREL_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("Squirrel.Windows", "Squirrel.exe");
        public static Action<OutputType, string> SquirrelLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p>
        ///   <p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Squirrel(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(SquirrelPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? SquirrelLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p>
        ///   <p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--baseUrl</c> via <see cref="SquirrelSettings.BaseUrl"/></li>
        ///     <li><c>--bootstrapperExe</c> via <see cref="SquirrelSettings.BootstrapperExecutable"/></li>
        ///     <li><c>--checkForUpdate</c> via <see cref="SquirrelSettings.CheckForUpdate"/></li>
        ///     <li><c>--createShortcut</c> via <see cref="SquirrelSettings.CreateShortcut"/></li>
        ///     <li><c>--download</c> via <see cref="SquirrelSettings.Download"/></li>
        ///     <li><c>--framework-version</c> via <see cref="SquirrelSettings.FrameworkVersion"/></li>
        ///     <li><c>--icon</c> via <see cref="SquirrelSettings.Icon"/></li>
        ///     <li><c>--install</c> via <see cref="SquirrelSettings.Install"/></li>
        ///     <li><c>--loadingGif</c> via <see cref="SquirrelSettings.LoadingGif"/></li>
        ///     <li><c>--no-delta</c> via <see cref="SquirrelSettings.GenerateNoDelta"/></li>
        ///     <li><c>--no-msi</c> via <see cref="SquirrelSettings.GenerateNoMsi"/></li>
        ///     <li><c>--packagesDir</c> via <see cref="SquirrelSettings.PackagesDirectory"/></li>
        ///     <li><c>--process-start-args</c> via <see cref="SquirrelSettings.ProcessStartArguments"/></li>
        ///     <li><c>--processStart</c> via <see cref="SquirrelSettings.ProcessStart"/></li>
        ///     <li><c>--processStartAndWait</c> via <see cref="SquirrelSettings.ProcessStartAndWait"/></li>
        ///     <li><c>--releaseDir</c> via <see cref="SquirrelSettings.ReleaseDirectory"/></li>
        ///     <li><c>--releasify</c> via <see cref="SquirrelSettings.Releasify"/></li>
        ///     <li><c>--removeShortcut</c> via <see cref="SquirrelSettings.RemoveShortcut"/></li>
        ///     <li><c>--setupIcon</c> via <see cref="SquirrelSettings.SetupIcon"/></li>
        ///     <li><c>--shortcut-locations</c> via <see cref="SquirrelSettings.ShortcutLocations"/></li>
        ///     <li><c>--signWithParams</c> via <see cref="SquirrelSettings.SignWithParameters"/></li>
        ///     <li><c>--uninstall</c> via <see cref="SquirrelSettings.Uninstall"/></li>
        ///     <li><c>--update</c> via <see cref="SquirrelSettings.Update"/></li>
        ///     <li><c>--updateSelf</c> via <see cref="SquirrelSettings.UpdateSelf"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Squirrel(SquirrelSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new SquirrelSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p>
        ///   <p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--baseUrl</c> via <see cref="SquirrelSettings.BaseUrl"/></li>
        ///     <li><c>--bootstrapperExe</c> via <see cref="SquirrelSettings.BootstrapperExecutable"/></li>
        ///     <li><c>--checkForUpdate</c> via <see cref="SquirrelSettings.CheckForUpdate"/></li>
        ///     <li><c>--createShortcut</c> via <see cref="SquirrelSettings.CreateShortcut"/></li>
        ///     <li><c>--download</c> via <see cref="SquirrelSettings.Download"/></li>
        ///     <li><c>--framework-version</c> via <see cref="SquirrelSettings.FrameworkVersion"/></li>
        ///     <li><c>--icon</c> via <see cref="SquirrelSettings.Icon"/></li>
        ///     <li><c>--install</c> via <see cref="SquirrelSettings.Install"/></li>
        ///     <li><c>--loadingGif</c> via <see cref="SquirrelSettings.LoadingGif"/></li>
        ///     <li><c>--no-delta</c> via <see cref="SquirrelSettings.GenerateNoDelta"/></li>
        ///     <li><c>--no-msi</c> via <see cref="SquirrelSettings.GenerateNoMsi"/></li>
        ///     <li><c>--packagesDir</c> via <see cref="SquirrelSettings.PackagesDirectory"/></li>
        ///     <li><c>--process-start-args</c> via <see cref="SquirrelSettings.ProcessStartArguments"/></li>
        ///     <li><c>--processStart</c> via <see cref="SquirrelSettings.ProcessStart"/></li>
        ///     <li><c>--processStartAndWait</c> via <see cref="SquirrelSettings.ProcessStartAndWait"/></li>
        ///     <li><c>--releaseDir</c> via <see cref="SquirrelSettings.ReleaseDirectory"/></li>
        ///     <li><c>--releasify</c> via <see cref="SquirrelSettings.Releasify"/></li>
        ///     <li><c>--removeShortcut</c> via <see cref="SquirrelSettings.RemoveShortcut"/></li>
        ///     <li><c>--setupIcon</c> via <see cref="SquirrelSettings.SetupIcon"/></li>
        ///     <li><c>--shortcut-locations</c> via <see cref="SquirrelSettings.ShortcutLocations"/></li>
        ///     <li><c>--signWithParams</c> via <see cref="SquirrelSettings.SignWithParameters"/></li>
        ///     <li><c>--uninstall</c> via <see cref="SquirrelSettings.Uninstall"/></li>
        ///     <li><c>--update</c> via <see cref="SquirrelSettings.Update"/></li>
        ///     <li><c>--updateSelf</c> via <see cref="SquirrelSettings.UpdateSelf"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Squirrel(Configure<SquirrelSettings> configurator)
        {
            return Squirrel(configurator(new SquirrelSettings()));
        }
        /// <summary>
        ///   <p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p>
        ///   <p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--baseUrl</c> via <see cref="SquirrelSettings.BaseUrl"/></li>
        ///     <li><c>--bootstrapperExe</c> via <see cref="SquirrelSettings.BootstrapperExecutable"/></li>
        ///     <li><c>--checkForUpdate</c> via <see cref="SquirrelSettings.CheckForUpdate"/></li>
        ///     <li><c>--createShortcut</c> via <see cref="SquirrelSettings.CreateShortcut"/></li>
        ///     <li><c>--download</c> via <see cref="SquirrelSettings.Download"/></li>
        ///     <li><c>--framework-version</c> via <see cref="SquirrelSettings.FrameworkVersion"/></li>
        ///     <li><c>--icon</c> via <see cref="SquirrelSettings.Icon"/></li>
        ///     <li><c>--install</c> via <see cref="SquirrelSettings.Install"/></li>
        ///     <li><c>--loadingGif</c> via <see cref="SquirrelSettings.LoadingGif"/></li>
        ///     <li><c>--no-delta</c> via <see cref="SquirrelSettings.GenerateNoDelta"/></li>
        ///     <li><c>--no-msi</c> via <see cref="SquirrelSettings.GenerateNoMsi"/></li>
        ///     <li><c>--packagesDir</c> via <see cref="SquirrelSettings.PackagesDirectory"/></li>
        ///     <li><c>--process-start-args</c> via <see cref="SquirrelSettings.ProcessStartArguments"/></li>
        ///     <li><c>--processStart</c> via <see cref="SquirrelSettings.ProcessStart"/></li>
        ///     <li><c>--processStartAndWait</c> via <see cref="SquirrelSettings.ProcessStartAndWait"/></li>
        ///     <li><c>--releaseDir</c> via <see cref="SquirrelSettings.ReleaseDirectory"/></li>
        ///     <li><c>--releasify</c> via <see cref="SquirrelSettings.Releasify"/></li>
        ///     <li><c>--removeShortcut</c> via <see cref="SquirrelSettings.RemoveShortcut"/></li>
        ///     <li><c>--setupIcon</c> via <see cref="SquirrelSettings.SetupIcon"/></li>
        ///     <li><c>--shortcut-locations</c> via <see cref="SquirrelSettings.ShortcutLocations"/></li>
        ///     <li><c>--signWithParams</c> via <see cref="SquirrelSettings.SignWithParameters"/></li>
        ///     <li><c>--uninstall</c> via <see cref="SquirrelSettings.Uninstall"/></li>
        ///     <li><c>--update</c> via <see cref="SquirrelSettings.Update"/></li>
        ///     <li><c>--updateSelf</c> via <see cref="SquirrelSettings.UpdateSelf"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(SquirrelSettings Settings, IReadOnlyCollection<Output> Output)> Squirrel(CombinatorialConfigure<SquirrelSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(Squirrel, SquirrelLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region SquirrelSettings
    /// <summary>
    ///   Used within <see cref="SquirrelTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SquirrelSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Squirrel executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? SquirrelTasks.SquirrelPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? SquirrelTasks.SquirrelLogger;
        /// <summary>
        ///   Install the app whose package is in the specified directory.
        /// </summary>
        public virtual string Install { get; internal set; }
        /// <summary>
        ///   Uninstall the app the same dir as Update.exe.
        /// </summary>
        public virtual bool? Uninstall { get; internal set; }
        /// <summary>
        ///   Download the releases specified by the URL and write new results to stdout as JSON.
        /// </summary>
        public virtual bool? Download { get; internal set; }
        /// <summary>
        ///   Check for one available update and writes new results to stdout as JSON.
        /// </summary>
        public virtual bool? CheckForUpdate { get; internal set; }
        /// <summary>
        ///   Update the application to the latest remote version specified by URL.
        /// </summary>
        public virtual string Update { get; internal set; }
        /// <summary>
        ///   Update or generate a releases directory with a given NuGet package.
        /// </summary>
        public virtual string Releasify { get; internal set; }
        /// <summary>
        ///   Create a shortcut for the given executable name.
        /// </summary>
        public virtual string CreateShortcut { get; internal set; }
        /// <summary>
        ///   Remove a shortcut for the given executable name.
        /// </summary>
        public virtual string RemoveShortcut { get; internal set; }
        /// <summary>
        ///   Copy the currently executing Update.exe into the default location.
        /// </summary>
        public virtual string UpdateSelf { get; internal set; }
        /// <summary>
        ///   Start an executable in the latest version of the app package.
        /// </summary>
        public virtual string ProcessStart { get; internal set; }
        /// <summary>
        ///   Start an executable in the latest version of the app package.
        /// </summary>
        public virtual string ProcessStartAndWait { get; internal set; }
        /// <summary>
        ///   Path to a release directory to use with releasify.
        /// </summary>
        public virtual string ReleaseDirectory { get; internal set; }
        /// <summary>
        ///   Path to the NuGet Packages directory for C# apps.
        /// </summary>
        public virtual string PackagesDirectory { get; internal set; }
        /// <summary>
        ///   Path to the Setup.exe to use as a template.
        /// </summary>
        public virtual string BootstrapperExecutable { get; internal set; }
        /// <summary>
        ///   Path to an animated GIF to be displayed during installation.
        /// </summary>
        public virtual string LoadingGif { get; internal set; }
        /// <summary>
        ///   Path to an ICO file that will be used for icon shortcuts.
        /// </summary>
        public virtual string Icon { get; internal set; }
        /// <summary>
        ///   Path to an ICO file that will be used for the Setup executable's icon.
        /// </summary>
        public virtual string SetupIcon { get; internal set; }
        /// <summary>
        ///   Sign the installer via SignTool.exe with the parameters given.
        /// </summary>
        public virtual string SignWithParameters { get; internal set; }
        /// <summary>
        ///   Provides a base URL to prefix the RELEASES file packages with.
        /// </summary>
        public virtual string BaseUrl { get; internal set; }
        /// <summary>
        ///   Arguments that will be used when starting executable.
        /// </summary>
        public virtual string ProcessStartArguments { get; internal set; }
        /// <summary>
        ///   Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.
        /// </summary>
        public virtual IReadOnlyList<string> ShortcutLocations => ShortcutLocationsInternal.AsReadOnly();
        internal List<string> ShortcutLocationsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Don't generate an MSI package.
        /// </summary>
        public virtual bool? GenerateNoMsi { get; internal set; }
        /// <summary>
        ///   Don't generate delta packages to save time
        /// </summary>
        public virtual bool? GenerateNoDelta { get; internal set; }
        /// <summary>
        ///   Set the required .NET framework version, e.g. net461
        /// </summary>
        public virtual string FrameworkVersion { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
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
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region SquirrelSettingsExtensions
    /// <summary>
    ///   Used within <see cref="SquirrelTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SquirrelSettingsExtensions
    {
        #region Install
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.Install"/></em></p>
        ///   <p>Install the app whose package is in the specified directory.</p>
        /// </summary>
        [Pure]
        public static T SetInstall<T>(this T toolSettings, string install) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = install;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.Install"/></em></p>
        ///   <p>Install the app whose package is in the specified directory.</p>
        /// </summary>
        [Pure]
        public static T ResetInstall<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = null;
            return toolSettings;
        }
        #endregion
        #region Uninstall
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.Uninstall"/></em></p>
        ///   <p>Uninstall the app the same dir as Update.exe.</p>
        /// </summary>
        [Pure]
        public static T SetUninstall<T>(this T toolSettings, bool? uninstall) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstall = uninstall;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.Uninstall"/></em></p>
        ///   <p>Uninstall the app the same dir as Update.exe.</p>
        /// </summary>
        [Pure]
        public static T ResetUninstall<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstall = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SquirrelSettings.Uninstall"/></em></p>
        ///   <p>Uninstall the app the same dir as Update.exe.</p>
        /// </summary>
        [Pure]
        public static T EnableUninstall<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstall = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SquirrelSettings.Uninstall"/></em></p>
        ///   <p>Uninstall the app the same dir as Update.exe.</p>
        /// </summary>
        [Pure]
        public static T DisableUninstall<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstall = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SquirrelSettings.Uninstall"/></em></p>
        ///   <p>Uninstall the app the same dir as Update.exe.</p>
        /// </summary>
        [Pure]
        public static T ToggleUninstall<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstall = !toolSettings.Uninstall;
            return toolSettings;
        }
        #endregion
        #region Download
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.Download"/></em></p>
        ///   <p>Download the releases specified by the URL and write new results to stdout as JSON.</p>
        /// </summary>
        [Pure]
        public static T SetDownload<T>(this T toolSettings, bool? download) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = download;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.Download"/></em></p>
        ///   <p>Download the releases specified by the URL and write new results to stdout as JSON.</p>
        /// </summary>
        [Pure]
        public static T ResetDownload<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SquirrelSettings.Download"/></em></p>
        ///   <p>Download the releases specified by the URL and write new results to stdout as JSON.</p>
        /// </summary>
        [Pure]
        public static T EnableDownload<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SquirrelSettings.Download"/></em></p>
        ///   <p>Download the releases specified by the URL and write new results to stdout as JSON.</p>
        /// </summary>
        [Pure]
        public static T DisableDownload<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SquirrelSettings.Download"/></em></p>
        ///   <p>Download the releases specified by the URL and write new results to stdout as JSON.</p>
        /// </summary>
        [Pure]
        public static T ToggleDownload<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Download = !toolSettings.Download;
            return toolSettings;
        }
        #endregion
        #region CheckForUpdate
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.CheckForUpdate"/></em></p>
        ///   <p>Check for one available update and writes new results to stdout as JSON.</p>
        /// </summary>
        [Pure]
        public static T SetCheckForUpdate<T>(this T toolSettings, bool? checkForUpdate) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = checkForUpdate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.CheckForUpdate"/></em></p>
        ///   <p>Check for one available update and writes new results to stdout as JSON.</p>
        /// </summary>
        [Pure]
        public static T ResetCheckForUpdate<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SquirrelSettings.CheckForUpdate"/></em></p>
        ///   <p>Check for one available update and writes new results to stdout as JSON.</p>
        /// </summary>
        [Pure]
        public static T EnableCheckForUpdate<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SquirrelSettings.CheckForUpdate"/></em></p>
        ///   <p>Check for one available update and writes new results to stdout as JSON.</p>
        /// </summary>
        [Pure]
        public static T DisableCheckForUpdate<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SquirrelSettings.CheckForUpdate"/></em></p>
        ///   <p>Check for one available update and writes new results to stdout as JSON.</p>
        /// </summary>
        [Pure]
        public static T ToggleCheckForUpdate<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckForUpdate = !toolSettings.CheckForUpdate;
            return toolSettings;
        }
        #endregion
        #region Update
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.Update"/></em></p>
        ///   <p>Update the application to the latest remote version specified by URL.</p>
        /// </summary>
        [Pure]
        public static T SetUpdate<T>(this T toolSettings, string update) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Update = update;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.Update"/></em></p>
        ///   <p>Update the application to the latest remote version specified by URL.</p>
        /// </summary>
        [Pure]
        public static T ResetUpdate<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Update = null;
            return toolSettings;
        }
        #endregion
        #region Releasify
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.Releasify"/></em></p>
        ///   <p>Update or generate a releases directory with a given NuGet package.</p>
        /// </summary>
        [Pure]
        public static T SetReleasify<T>(this T toolSettings, string releasify) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Releasify = releasify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.Releasify"/></em></p>
        ///   <p>Update or generate a releases directory with a given NuGet package.</p>
        /// </summary>
        [Pure]
        public static T ResetReleasify<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Releasify = null;
            return toolSettings;
        }
        #endregion
        #region CreateShortcut
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.CreateShortcut"/></em></p>
        ///   <p>Create a shortcut for the given executable name.</p>
        /// </summary>
        [Pure]
        public static T SetCreateShortcut<T>(this T toolSettings, string createShortcut) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateShortcut = createShortcut;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.CreateShortcut"/></em></p>
        ///   <p>Create a shortcut for the given executable name.</p>
        /// </summary>
        [Pure]
        public static T ResetCreateShortcut<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateShortcut = null;
            return toolSettings;
        }
        #endregion
        #region RemoveShortcut
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.RemoveShortcut"/></em></p>
        ///   <p>Remove a shortcut for the given executable name.</p>
        /// </summary>
        [Pure]
        public static T SetRemoveShortcut<T>(this T toolSettings, string removeShortcut) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RemoveShortcut = removeShortcut;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.RemoveShortcut"/></em></p>
        ///   <p>Remove a shortcut for the given executable name.</p>
        /// </summary>
        [Pure]
        public static T ResetRemoveShortcut<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RemoveShortcut = null;
            return toolSettings;
        }
        #endregion
        #region UpdateSelf
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.UpdateSelf"/></em></p>
        ///   <p>Copy the currently executing Update.exe into the default location.</p>
        /// </summary>
        [Pure]
        public static T SetUpdateSelf<T>(this T toolSettings, string updateSelf) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateSelf = updateSelf;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.UpdateSelf"/></em></p>
        ///   <p>Copy the currently executing Update.exe into the default location.</p>
        /// </summary>
        [Pure]
        public static T ResetUpdateSelf<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpdateSelf = null;
            return toolSettings;
        }
        #endregion
        #region ProcessStart
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.ProcessStart"/></em></p>
        ///   <p>Start an executable in the latest version of the app package.</p>
        /// </summary>
        [Pure]
        public static T SetProcessStart<T>(this T toolSettings, string processStart) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStart = processStart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.ProcessStart"/></em></p>
        ///   <p>Start an executable in the latest version of the app package.</p>
        /// </summary>
        [Pure]
        public static T ResetProcessStart<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStart = null;
            return toolSettings;
        }
        #endregion
        #region ProcessStartAndWait
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.ProcessStartAndWait"/></em></p>
        ///   <p>Start an executable in the latest version of the app package.</p>
        /// </summary>
        [Pure]
        public static T SetProcessStartAndWait<T>(this T toolSettings, string processStartAndWait) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStartAndWait = processStartAndWait;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.ProcessStartAndWait"/></em></p>
        ///   <p>Start an executable in the latest version of the app package.</p>
        /// </summary>
        [Pure]
        public static T ResetProcessStartAndWait<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStartAndWait = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.ReleaseDirectory"/></em></p>
        ///   <p>Path to a release directory to use with releasify.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseDirectory<T>(this T toolSettings, string releaseDirectory) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseDirectory = releaseDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.ReleaseDirectory"/></em></p>
        ///   <p>Path to a release directory to use with releasify.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseDirectory<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseDirectory = null;
            return toolSettings;
        }
        #endregion
        #region PackagesDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.PackagesDirectory"/></em></p>
        ///   <p>Path to the NuGet Packages directory for C# apps.</p>
        /// </summary>
        [Pure]
        public static T SetPackagesDirectory<T>(this T toolSettings, string packagesDirectory) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesDirectory = packagesDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.PackagesDirectory"/></em></p>
        ///   <p>Path to the NuGet Packages directory for C# apps.</p>
        /// </summary>
        [Pure]
        public static T ResetPackagesDirectory<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PackagesDirectory = null;
            return toolSettings;
        }
        #endregion
        #region BootstrapperExecutable
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.BootstrapperExecutable"/></em></p>
        ///   <p>Path to the Setup.exe to use as a template.</p>
        /// </summary>
        [Pure]
        public static T SetBootstrapperExecutable<T>(this T toolSettings, string bootstrapperExecutable) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BootstrapperExecutable = bootstrapperExecutable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.BootstrapperExecutable"/></em></p>
        ///   <p>Path to the Setup.exe to use as a template.</p>
        /// </summary>
        [Pure]
        public static T ResetBootstrapperExecutable<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BootstrapperExecutable = null;
            return toolSettings;
        }
        #endregion
        #region LoadingGif
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.LoadingGif"/></em></p>
        ///   <p>Path to an animated GIF to be displayed during installation.</p>
        /// </summary>
        [Pure]
        public static T SetLoadingGif<T>(this T toolSettings, string loadingGif) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadingGif = loadingGif;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.LoadingGif"/></em></p>
        ///   <p>Path to an animated GIF to be displayed during installation.</p>
        /// </summary>
        [Pure]
        public static T ResetLoadingGif<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LoadingGif = null;
            return toolSettings;
        }
        #endregion
        #region Icon
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.Icon"/></em></p>
        ///   <p>Path to an ICO file that will be used for icon shortcuts.</p>
        /// </summary>
        [Pure]
        public static T SetIcon<T>(this T toolSettings, string icon) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Icon = icon;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.Icon"/></em></p>
        ///   <p>Path to an ICO file that will be used for icon shortcuts.</p>
        /// </summary>
        [Pure]
        public static T ResetIcon<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Icon = null;
            return toolSettings;
        }
        #endregion
        #region SetupIcon
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.SetupIcon"/></em></p>
        ///   <p>Path to an ICO file that will be used for the Setup executable's icon.</p>
        /// </summary>
        [Pure]
        public static T SetSetupIcon<T>(this T toolSettings, string setupIcon) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetupIcon = setupIcon;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.SetupIcon"/></em></p>
        ///   <p>Path to an ICO file that will be used for the Setup executable's icon.</p>
        /// </summary>
        [Pure]
        public static T ResetSetupIcon<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetupIcon = null;
            return toolSettings;
        }
        #endregion
        #region SignWithParameters
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.SignWithParameters"/></em></p>
        ///   <p>Sign the installer via SignTool.exe with the parameters given.</p>
        /// </summary>
        [Pure]
        public static T SetSignWithParameters<T>(this T toolSettings, string signWithParameters) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignWithParameters = signWithParameters;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.SignWithParameters"/></em></p>
        ///   <p>Sign the installer via SignTool.exe with the parameters given.</p>
        /// </summary>
        [Pure]
        public static T ResetSignWithParameters<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignWithParameters = null;
            return toolSettings;
        }
        #endregion
        #region BaseUrl
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.BaseUrl"/></em></p>
        ///   <p>Provides a base URL to prefix the RELEASES file packages with.</p>
        /// </summary>
        [Pure]
        public static T SetBaseUrl<T>(this T toolSettings, string baseUrl) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseUrl = baseUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.BaseUrl"/></em></p>
        ///   <p>Provides a base URL to prefix the RELEASES file packages with.</p>
        /// </summary>
        [Pure]
        public static T ResetBaseUrl<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseUrl = null;
            return toolSettings;
        }
        #endregion
        #region ProcessStartArguments
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.ProcessStartArguments"/></em></p>
        ///   <p>Arguments that will be used when starting executable.</p>
        /// </summary>
        [Pure]
        public static T SetProcessStartArguments<T>(this T toolSettings, string processStartArguments) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStartArguments = processStartArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.ProcessStartArguments"/></em></p>
        ///   <p>Arguments that will be used when starting executable.</p>
        /// </summary>
        [Pure]
        public static T ResetProcessStartArguments<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProcessStartArguments = null;
            return toolSettings;
        }
        #endregion
        #region ShortcutLocations
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.ShortcutLocations"/> to a new list</em></p>
        ///   <p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p>
        /// </summary>
        [Pure]
        public static T SetShortcutLocations<T>(this T toolSettings, params string[] shortcutLocations) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShortcutLocationsInternal = shortcutLocations.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.ShortcutLocations"/> to a new list</em></p>
        ///   <p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p>
        /// </summary>
        [Pure]
        public static T SetShortcutLocations<T>(this T toolSettings, IEnumerable<string> shortcutLocations) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShortcutLocationsInternal = shortcutLocations.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SquirrelSettings.ShortcutLocations"/></em></p>
        ///   <p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p>
        /// </summary>
        [Pure]
        public static T AddShortcutLocations<T>(this T toolSettings, params string[] shortcutLocations) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShortcutLocationsInternal.AddRange(shortcutLocations);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="SquirrelSettings.ShortcutLocations"/></em></p>
        ///   <p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p>
        /// </summary>
        [Pure]
        public static T AddShortcutLocations<T>(this T toolSettings, IEnumerable<string> shortcutLocations) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShortcutLocationsInternal.AddRange(shortcutLocations);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="SquirrelSettings.ShortcutLocations"/></em></p>
        ///   <p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p>
        /// </summary>
        [Pure]
        public static T ClearShortcutLocations<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShortcutLocationsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SquirrelSettings.ShortcutLocations"/></em></p>
        ///   <p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p>
        /// </summary>
        [Pure]
        public static T RemoveShortcutLocations<T>(this T toolSettings, params string[] shortcutLocations) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(shortcutLocations);
            toolSettings.ShortcutLocationsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="SquirrelSettings.ShortcutLocations"/></em></p>
        ///   <p>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</p>
        /// </summary>
        [Pure]
        public static T RemoveShortcutLocations<T>(this T toolSettings, IEnumerable<string> shortcutLocations) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(shortcutLocations);
            toolSettings.ShortcutLocationsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region GenerateNoMsi
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.GenerateNoMsi"/></em></p>
        ///   <p>Don't generate an MSI package.</p>
        /// </summary>
        [Pure]
        public static T SetGenerateNoMsi<T>(this T toolSettings, bool? generateNoMsi) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoMsi = generateNoMsi;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.GenerateNoMsi"/></em></p>
        ///   <p>Don't generate an MSI package.</p>
        /// </summary>
        [Pure]
        public static T ResetGenerateNoMsi<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoMsi = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SquirrelSettings.GenerateNoMsi"/></em></p>
        ///   <p>Don't generate an MSI package.</p>
        /// </summary>
        [Pure]
        public static T EnableGenerateNoMsi<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoMsi = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SquirrelSettings.GenerateNoMsi"/></em></p>
        ///   <p>Don't generate an MSI package.</p>
        /// </summary>
        [Pure]
        public static T DisableGenerateNoMsi<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoMsi = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SquirrelSettings.GenerateNoMsi"/></em></p>
        ///   <p>Don't generate an MSI package.</p>
        /// </summary>
        [Pure]
        public static T ToggleGenerateNoMsi<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoMsi = !toolSettings.GenerateNoMsi;
            return toolSettings;
        }
        #endregion
        #region GenerateNoDelta
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.GenerateNoDelta"/></em></p>
        ///   <p>Don't generate delta packages to save time</p>
        /// </summary>
        [Pure]
        public static T SetGenerateNoDelta<T>(this T toolSettings, bool? generateNoDelta) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoDelta = generateNoDelta;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.GenerateNoDelta"/></em></p>
        ///   <p>Don't generate delta packages to save time</p>
        /// </summary>
        [Pure]
        public static T ResetGenerateNoDelta<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoDelta = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="SquirrelSettings.GenerateNoDelta"/></em></p>
        ///   <p>Don't generate delta packages to save time</p>
        /// </summary>
        [Pure]
        public static T EnableGenerateNoDelta<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoDelta = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="SquirrelSettings.GenerateNoDelta"/></em></p>
        ///   <p>Don't generate delta packages to save time</p>
        /// </summary>
        [Pure]
        public static T DisableGenerateNoDelta<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoDelta = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="SquirrelSettings.GenerateNoDelta"/></em></p>
        ///   <p>Don't generate delta packages to save time</p>
        /// </summary>
        [Pure]
        public static T ToggleGenerateNoDelta<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateNoDelta = !toolSettings.GenerateNoDelta;
            return toolSettings;
        }
        #endregion
        #region FrameworkVersion
        /// <summary>
        ///   <p><em>Sets <see cref="SquirrelSettings.FrameworkVersion"/></em></p>
        ///   <p>Set the required .NET framework version, e.g. net461</p>
        /// </summary>
        [Pure]
        public static T SetFrameworkVersion<T>(this T toolSettings, string frameworkVersion) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FrameworkVersion = frameworkVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SquirrelSettings.FrameworkVersion"/></em></p>
        ///   <p>Set the required .NET framework version, e.g. net461</p>
        /// </summary>
        [Pure]
        public static T ResetFrameworkVersion<T>(this T toolSettings) where T : SquirrelSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FrameworkVersion = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}

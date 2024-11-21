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

namespace Nuke.Common.Tools.Squirrel;

/// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p><p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class SquirrelTasks : ToolTasks, IRequireNuGetPackage
{
    public static string SquirrelPath => new SquirrelTasks().GetToolPath();
    public const string PackageId = "Squirrel.Windows";
    public const string PackageExecutable = "Squirrel.exe";
    /// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p><p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Squirrel(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new SquirrelTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p><p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--baseUrl</c> via <see cref="SquirrelSettings.BaseUrl"/></li><li><c>--bootstrapperExe</c> via <see cref="SquirrelSettings.BootstrapperExecutable"/></li><li><c>--checkForUpdate</c> via <see cref="SquirrelSettings.CheckForUpdate"/></li><li><c>--createShortcut</c> via <see cref="SquirrelSettings.CreateShortcut"/></li><li><c>--download</c> via <see cref="SquirrelSettings.Download"/></li><li><c>--framework-version</c> via <see cref="SquirrelSettings.FrameworkVersion"/></li><li><c>--icon</c> via <see cref="SquirrelSettings.Icon"/></li><li><c>--install</c> via <see cref="SquirrelSettings.Install"/></li><li><c>--loadingGif</c> via <see cref="SquirrelSettings.LoadingGif"/></li><li><c>--no-delta</c> via <see cref="SquirrelSettings.GenerateNoDelta"/></li><li><c>--no-msi</c> via <see cref="SquirrelSettings.GenerateNoMsi"/></li><li><c>--packagesDir</c> via <see cref="SquirrelSettings.PackagesDirectory"/></li><li><c>--process-start-args</c> via <see cref="SquirrelSettings.ProcessStartArguments"/></li><li><c>--processStart</c> via <see cref="SquirrelSettings.ProcessStart"/></li><li><c>--processStartAndWait</c> via <see cref="SquirrelSettings.ProcessStartAndWait"/></li><li><c>--releaseDir</c> via <see cref="SquirrelSettings.ReleaseDirectory"/></li><li><c>--releasify</c> via <see cref="SquirrelSettings.Releasify"/></li><li><c>--removeShortcut</c> via <see cref="SquirrelSettings.RemoveShortcut"/></li><li><c>--setupIcon</c> via <see cref="SquirrelSettings.SetupIcon"/></li><li><c>--shortcut-locations</c> via <see cref="SquirrelSettings.ShortcutLocations"/></li><li><c>--signWithParams</c> via <see cref="SquirrelSettings.SignWithParameters"/></li><li><c>--uninstall</c> via <see cref="SquirrelSettings.Uninstall"/></li><li><c>--update</c> via <see cref="SquirrelSettings.Update"/></li><li><c>--updateSelf</c> via <see cref="SquirrelSettings.UpdateSelf"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Squirrel(SquirrelSettings options = null) => new SquirrelTasks().Run(options);
    /// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p><p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--baseUrl</c> via <see cref="SquirrelSettings.BaseUrl"/></li><li><c>--bootstrapperExe</c> via <see cref="SquirrelSettings.BootstrapperExecutable"/></li><li><c>--checkForUpdate</c> via <see cref="SquirrelSettings.CheckForUpdate"/></li><li><c>--createShortcut</c> via <see cref="SquirrelSettings.CreateShortcut"/></li><li><c>--download</c> via <see cref="SquirrelSettings.Download"/></li><li><c>--framework-version</c> via <see cref="SquirrelSettings.FrameworkVersion"/></li><li><c>--icon</c> via <see cref="SquirrelSettings.Icon"/></li><li><c>--install</c> via <see cref="SquirrelSettings.Install"/></li><li><c>--loadingGif</c> via <see cref="SquirrelSettings.LoadingGif"/></li><li><c>--no-delta</c> via <see cref="SquirrelSettings.GenerateNoDelta"/></li><li><c>--no-msi</c> via <see cref="SquirrelSettings.GenerateNoMsi"/></li><li><c>--packagesDir</c> via <see cref="SquirrelSettings.PackagesDirectory"/></li><li><c>--process-start-args</c> via <see cref="SquirrelSettings.ProcessStartArguments"/></li><li><c>--processStart</c> via <see cref="SquirrelSettings.ProcessStart"/></li><li><c>--processStartAndWait</c> via <see cref="SquirrelSettings.ProcessStartAndWait"/></li><li><c>--releaseDir</c> via <see cref="SquirrelSettings.ReleaseDirectory"/></li><li><c>--releasify</c> via <see cref="SquirrelSettings.Releasify"/></li><li><c>--removeShortcut</c> via <see cref="SquirrelSettings.RemoveShortcut"/></li><li><c>--setupIcon</c> via <see cref="SquirrelSettings.SetupIcon"/></li><li><c>--shortcut-locations</c> via <see cref="SquirrelSettings.ShortcutLocations"/></li><li><c>--signWithParams</c> via <see cref="SquirrelSettings.SignWithParameters"/></li><li><c>--uninstall</c> via <see cref="SquirrelSettings.Uninstall"/></li><li><c>--update</c> via <see cref="SquirrelSettings.Update"/></li><li><c>--updateSelf</c> via <see cref="SquirrelSettings.UpdateSelf"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Squirrel(Configure<SquirrelSettings> configurator) => new SquirrelTasks().Run(configurator.Invoke(new SquirrelSettings()));
    /// <summary><p>Squirrel is both a set of tools and a library, to completely manage both installation and updating your Desktop Windows application, written in either C# or any other language (i.e., Squirrel can manage native C++ applications).</p><p>For more details, visit the <a href="https://github.com/Squirrel/Squirrel.Windows">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--baseUrl</c> via <see cref="SquirrelSettings.BaseUrl"/></li><li><c>--bootstrapperExe</c> via <see cref="SquirrelSettings.BootstrapperExecutable"/></li><li><c>--checkForUpdate</c> via <see cref="SquirrelSettings.CheckForUpdate"/></li><li><c>--createShortcut</c> via <see cref="SquirrelSettings.CreateShortcut"/></li><li><c>--download</c> via <see cref="SquirrelSettings.Download"/></li><li><c>--framework-version</c> via <see cref="SquirrelSettings.FrameworkVersion"/></li><li><c>--icon</c> via <see cref="SquirrelSettings.Icon"/></li><li><c>--install</c> via <see cref="SquirrelSettings.Install"/></li><li><c>--loadingGif</c> via <see cref="SquirrelSettings.LoadingGif"/></li><li><c>--no-delta</c> via <see cref="SquirrelSettings.GenerateNoDelta"/></li><li><c>--no-msi</c> via <see cref="SquirrelSettings.GenerateNoMsi"/></li><li><c>--packagesDir</c> via <see cref="SquirrelSettings.PackagesDirectory"/></li><li><c>--process-start-args</c> via <see cref="SquirrelSettings.ProcessStartArguments"/></li><li><c>--processStart</c> via <see cref="SquirrelSettings.ProcessStart"/></li><li><c>--processStartAndWait</c> via <see cref="SquirrelSettings.ProcessStartAndWait"/></li><li><c>--releaseDir</c> via <see cref="SquirrelSettings.ReleaseDirectory"/></li><li><c>--releasify</c> via <see cref="SquirrelSettings.Releasify"/></li><li><c>--removeShortcut</c> via <see cref="SquirrelSettings.RemoveShortcut"/></li><li><c>--setupIcon</c> via <see cref="SquirrelSettings.SetupIcon"/></li><li><c>--shortcut-locations</c> via <see cref="SquirrelSettings.ShortcutLocations"/></li><li><c>--signWithParams</c> via <see cref="SquirrelSettings.SignWithParameters"/></li><li><c>--uninstall</c> via <see cref="SquirrelSettings.Uninstall"/></li><li><c>--update</c> via <see cref="SquirrelSettings.Update"/></li><li><c>--updateSelf</c> via <see cref="SquirrelSettings.UpdateSelf"/></li></ul></remarks>
    public static IEnumerable<(SquirrelSettings Settings, IReadOnlyCollection<Output> Output)> Squirrel(CombinatorialConfigure<SquirrelSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(Squirrel, degreeOfParallelism, completeOnFailure);
}
#region SquirrelSettings
/// <summary>Used within <see cref="SquirrelTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SquirrelSettings>))]
[Command(Type = typeof(SquirrelTasks), Command = nameof(SquirrelTasks.Squirrel))]
public partial class SquirrelSettings : ToolOptions
{
    /// <summary>Install the app whose package is in the specified directory.</summary>
    [Argument(Format = "--install={value}")] public string Install => Get<string>(() => Install);
    /// <summary>Uninstall the app the same dir as Update.exe.</summary>
    [Argument(Format = "--uninstall")] public bool? Uninstall => Get<bool?>(() => Uninstall);
    /// <summary>Download the releases specified by the URL and write new results to stdout as JSON.</summary>
    [Argument(Format = "--download")] public bool? Download => Get<bool?>(() => Download);
    /// <summary>Check for one available update and writes new results to stdout as JSON.</summary>
    [Argument(Format = "--checkForUpdate")] public bool? CheckForUpdate => Get<bool?>(() => CheckForUpdate);
    /// <summary>Update the application to the latest remote version specified by URL.</summary>
    [Argument(Format = "--update={value}")] public string Update => Get<string>(() => Update);
    /// <summary>Update or generate a releases directory with a given NuGet package.</summary>
    [Argument(Format = "--releasify={value}")] public string Releasify => Get<string>(() => Releasify);
    /// <summary>Create a shortcut for the given executable name.</summary>
    [Argument(Format = "--createShortcut={value}")] public string CreateShortcut => Get<string>(() => CreateShortcut);
    /// <summary>Remove a shortcut for the given executable name.</summary>
    [Argument(Format = "--removeShortcut={value}")] public string RemoveShortcut => Get<string>(() => RemoveShortcut);
    /// <summary>Copy the currently executing Update.exe into the default location.</summary>
    [Argument(Format = "--updateSelf={value}")] public string UpdateSelf => Get<string>(() => UpdateSelf);
    /// <summary>Start an executable in the latest version of the app package.</summary>
    [Argument(Format = "--processStart={value}")] public string ProcessStart => Get<string>(() => ProcessStart);
    /// <summary>Start an executable in the latest version of the app package.</summary>
    [Argument(Format = "--processStartAndWait={value}")] public string ProcessStartAndWait => Get<string>(() => ProcessStartAndWait);
    /// <summary>Path to a release directory to use with releasify.</summary>
    [Argument(Format = "--releaseDir={value}")] public string ReleaseDirectory => Get<string>(() => ReleaseDirectory);
    /// <summary>Path to the NuGet Packages directory for C# apps.</summary>
    [Argument(Format = "--packagesDir={value}")] public string PackagesDirectory => Get<string>(() => PackagesDirectory);
    /// <summary>Path to the Setup.exe to use as a template.</summary>
    [Argument(Format = "--bootstrapperExe={value}")] public string BootstrapperExecutable => Get<string>(() => BootstrapperExecutable);
    /// <summary>Path to an animated GIF to be displayed during installation.</summary>
    [Argument(Format = "--loadingGif={value}")] public string LoadingGif => Get<string>(() => LoadingGif);
    /// <summary>Path to an ICO file that will be used for icon shortcuts.</summary>
    [Argument(Format = "--icon={value}")] public string Icon => Get<string>(() => Icon);
    /// <summary>Path to an ICO file that will be used for the Setup executable's icon.</summary>
    [Argument(Format = "--setupIcon={value}")] public string SetupIcon => Get<string>(() => SetupIcon);
    /// <summary>Sign the installer via SignTool.exe with the parameters given.</summary>
    [Argument(Format = "--signWithParams={value}")] public string SignWithParameters => Get<string>(() => SignWithParameters);
    /// <summary>Provides a base URL to prefix the RELEASES file packages with.</summary>
    [Argument(Format = "--baseUrl={value}")] public string BaseUrl => Get<string>(() => BaseUrl);
    /// <summary>Arguments that will be used when starting executable.</summary>
    [Argument(Format = "--process-start-args={value}")] public string ProcessStartArguments => Get<string>(() => ProcessStartArguments);
    /// <summary>Comma-separated string of shortcut locations, e.g. 'Desktop,StartMenu'.</summary>
    [Argument(Format = "--shortcut-locations={value}", Separator = ",")] public IReadOnlyList<string> ShortcutLocations => Get<List<string>>(() => ShortcutLocations);
    /// <summary>Don't generate an MSI package.</summary>
    [Argument(Format = "--no-msi")] public bool? GenerateNoMsi => Get<bool?>(() => GenerateNoMsi);
    /// <summary>Don't generate delta packages to save time</summary>
    [Argument(Format = "--no-delta")] public bool? GenerateNoDelta => Get<bool?>(() => GenerateNoDelta);
    /// <summary>Set the required .NET framework version, e.g. net461</summary>
    [Argument(Format = "--framework-version={value}")] public string FrameworkVersion => Get<string>(() => FrameworkVersion);
}
#endregion
#region SquirrelSettingsExtensions
/// <summary>Used within <see cref="SquirrelTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SquirrelSettingsExtensions
{
    #region Install
    /// <inheritdoc cref="SquirrelSettings.Install"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Install))]
    public static T SetInstall<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Install, v));
    /// <inheritdoc cref="SquirrelSettings.Install"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Install))]
    public static T ResetInstall<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.Install));
    #endregion
    #region Uninstall
    /// <inheritdoc cref="SquirrelSettings.Uninstall"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Uninstall))]
    public static T SetUninstall<T>(this T o, bool? v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Uninstall, v));
    /// <inheritdoc cref="SquirrelSettings.Uninstall"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Uninstall))]
    public static T ResetUninstall<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.Uninstall));
    /// <inheritdoc cref="SquirrelSettings.Uninstall"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Uninstall))]
    public static T EnableUninstall<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Uninstall, true));
    /// <inheritdoc cref="SquirrelSettings.Uninstall"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Uninstall))]
    public static T DisableUninstall<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Uninstall, false));
    /// <inheritdoc cref="SquirrelSettings.Uninstall"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Uninstall))]
    public static T ToggleUninstall<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Uninstall, !o.Uninstall));
    #endregion
    #region Download
    /// <inheritdoc cref="SquirrelSettings.Download"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Download))]
    public static T SetDownload<T>(this T o, bool? v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Download, v));
    /// <inheritdoc cref="SquirrelSettings.Download"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Download))]
    public static T ResetDownload<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.Download));
    /// <inheritdoc cref="SquirrelSettings.Download"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Download))]
    public static T EnableDownload<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Download, true));
    /// <inheritdoc cref="SquirrelSettings.Download"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Download))]
    public static T DisableDownload<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Download, false));
    /// <inheritdoc cref="SquirrelSettings.Download"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Download))]
    public static T ToggleDownload<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Download, !o.Download));
    #endregion
    #region CheckForUpdate
    /// <inheritdoc cref="SquirrelSettings.CheckForUpdate"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.CheckForUpdate))]
    public static T SetCheckForUpdate<T>(this T o, bool? v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.CheckForUpdate, v));
    /// <inheritdoc cref="SquirrelSettings.CheckForUpdate"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.CheckForUpdate))]
    public static T ResetCheckForUpdate<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.CheckForUpdate));
    /// <inheritdoc cref="SquirrelSettings.CheckForUpdate"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.CheckForUpdate))]
    public static T EnableCheckForUpdate<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.CheckForUpdate, true));
    /// <inheritdoc cref="SquirrelSettings.CheckForUpdate"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.CheckForUpdate))]
    public static T DisableCheckForUpdate<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.CheckForUpdate, false));
    /// <inheritdoc cref="SquirrelSettings.CheckForUpdate"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.CheckForUpdate))]
    public static T ToggleCheckForUpdate<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.CheckForUpdate, !o.CheckForUpdate));
    #endregion
    #region Update
    /// <inheritdoc cref="SquirrelSettings.Update"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Update))]
    public static T SetUpdate<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Update, v));
    /// <inheritdoc cref="SquirrelSettings.Update"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Update))]
    public static T ResetUpdate<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.Update));
    #endregion
    #region Releasify
    /// <inheritdoc cref="SquirrelSettings.Releasify"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Releasify))]
    public static T SetReleasify<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Releasify, v));
    /// <inheritdoc cref="SquirrelSettings.Releasify"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Releasify))]
    public static T ResetReleasify<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.Releasify));
    #endregion
    #region CreateShortcut
    /// <inheritdoc cref="SquirrelSettings.CreateShortcut"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.CreateShortcut))]
    public static T SetCreateShortcut<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.CreateShortcut, v));
    /// <inheritdoc cref="SquirrelSettings.CreateShortcut"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.CreateShortcut))]
    public static T ResetCreateShortcut<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.CreateShortcut));
    #endregion
    #region RemoveShortcut
    /// <inheritdoc cref="SquirrelSettings.RemoveShortcut"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.RemoveShortcut))]
    public static T SetRemoveShortcut<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.RemoveShortcut, v));
    /// <inheritdoc cref="SquirrelSettings.RemoveShortcut"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.RemoveShortcut))]
    public static T ResetRemoveShortcut<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.RemoveShortcut));
    #endregion
    #region UpdateSelf
    /// <inheritdoc cref="SquirrelSettings.UpdateSelf"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.UpdateSelf))]
    public static T SetUpdateSelf<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.UpdateSelf, v));
    /// <inheritdoc cref="SquirrelSettings.UpdateSelf"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.UpdateSelf))]
    public static T ResetUpdateSelf<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.UpdateSelf));
    #endregion
    #region ProcessStart
    /// <inheritdoc cref="SquirrelSettings.ProcessStart"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ProcessStart))]
    public static T SetProcessStart<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.ProcessStart, v));
    /// <inheritdoc cref="SquirrelSettings.ProcessStart"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ProcessStart))]
    public static T ResetProcessStart<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.ProcessStart));
    #endregion
    #region ProcessStartAndWait
    /// <inheritdoc cref="SquirrelSettings.ProcessStartAndWait"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ProcessStartAndWait))]
    public static T SetProcessStartAndWait<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.ProcessStartAndWait, v));
    /// <inheritdoc cref="SquirrelSettings.ProcessStartAndWait"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ProcessStartAndWait))]
    public static T ResetProcessStartAndWait<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.ProcessStartAndWait));
    #endregion
    #region ReleaseDirectory
    /// <inheritdoc cref="SquirrelSettings.ReleaseDirectory"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ReleaseDirectory))]
    public static T SetReleaseDirectory<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.ReleaseDirectory, v));
    /// <inheritdoc cref="SquirrelSettings.ReleaseDirectory"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ReleaseDirectory))]
    public static T ResetReleaseDirectory<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.ReleaseDirectory));
    #endregion
    #region PackagesDirectory
    /// <inheritdoc cref="SquirrelSettings.PackagesDirectory"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.PackagesDirectory))]
    public static T SetPackagesDirectory<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.PackagesDirectory, v));
    /// <inheritdoc cref="SquirrelSettings.PackagesDirectory"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.PackagesDirectory))]
    public static T ResetPackagesDirectory<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.PackagesDirectory));
    #endregion
    #region BootstrapperExecutable
    /// <inheritdoc cref="SquirrelSettings.BootstrapperExecutable"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.BootstrapperExecutable))]
    public static T SetBootstrapperExecutable<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.BootstrapperExecutable, v));
    /// <inheritdoc cref="SquirrelSettings.BootstrapperExecutable"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.BootstrapperExecutable))]
    public static T ResetBootstrapperExecutable<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.BootstrapperExecutable));
    #endregion
    #region LoadingGif
    /// <inheritdoc cref="SquirrelSettings.LoadingGif"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.LoadingGif))]
    public static T SetLoadingGif<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.LoadingGif, v));
    /// <inheritdoc cref="SquirrelSettings.LoadingGif"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.LoadingGif))]
    public static T ResetLoadingGif<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.LoadingGif));
    #endregion
    #region Icon
    /// <inheritdoc cref="SquirrelSettings.Icon"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Icon))]
    public static T SetIcon<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.Icon, v));
    /// <inheritdoc cref="SquirrelSettings.Icon"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.Icon))]
    public static T ResetIcon<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.Icon));
    #endregion
    #region SetupIcon
    /// <inheritdoc cref="SquirrelSettings.SetupIcon"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.SetupIcon))]
    public static T SetSetupIcon<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.SetupIcon, v));
    /// <inheritdoc cref="SquirrelSettings.SetupIcon"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.SetupIcon))]
    public static T ResetSetupIcon<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.SetupIcon));
    #endregion
    #region SignWithParameters
    /// <inheritdoc cref="SquirrelSettings.SignWithParameters"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.SignWithParameters))]
    public static T SetSignWithParameters<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.SignWithParameters, v));
    /// <inheritdoc cref="SquirrelSettings.SignWithParameters"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.SignWithParameters))]
    public static T ResetSignWithParameters<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.SignWithParameters));
    #endregion
    #region BaseUrl
    /// <inheritdoc cref="SquirrelSettings.BaseUrl"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.BaseUrl))]
    public static T SetBaseUrl<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.BaseUrl, v));
    /// <inheritdoc cref="SquirrelSettings.BaseUrl"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.BaseUrl))]
    public static T ResetBaseUrl<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.BaseUrl));
    #endregion
    #region ProcessStartArguments
    /// <inheritdoc cref="SquirrelSettings.ProcessStartArguments"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ProcessStartArguments))]
    public static T SetProcessStartArguments<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.ProcessStartArguments, v));
    /// <inheritdoc cref="SquirrelSettings.ProcessStartArguments"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ProcessStartArguments))]
    public static T ResetProcessStartArguments<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.ProcessStartArguments));
    #endregion
    #region ShortcutLocations
    /// <inheritdoc cref="SquirrelSettings.ShortcutLocations"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ShortcutLocations))]
    public static T SetShortcutLocations<T>(this T o, params string[] v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.ShortcutLocations, v));
    /// <inheritdoc cref="SquirrelSettings.ShortcutLocations"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ShortcutLocations))]
    public static T SetShortcutLocations<T>(this T o, IEnumerable<string> v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.ShortcutLocations, v));
    /// <inheritdoc cref="SquirrelSettings.ShortcutLocations"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ShortcutLocations))]
    public static T AddShortcutLocations<T>(this T o, params string[] v) where T : SquirrelSettings => o.Modify(b => b.AddCollection(() => o.ShortcutLocations, v));
    /// <inheritdoc cref="SquirrelSettings.ShortcutLocations"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ShortcutLocations))]
    public static T AddShortcutLocations<T>(this T o, IEnumerable<string> v) where T : SquirrelSettings => o.Modify(b => b.AddCollection(() => o.ShortcutLocations, v));
    /// <inheritdoc cref="SquirrelSettings.ShortcutLocations"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ShortcutLocations))]
    public static T RemoveShortcutLocations<T>(this T o, params string[] v) where T : SquirrelSettings => o.Modify(b => b.RemoveCollection(() => o.ShortcutLocations, v));
    /// <inheritdoc cref="SquirrelSettings.ShortcutLocations"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ShortcutLocations))]
    public static T RemoveShortcutLocations<T>(this T o, IEnumerable<string> v) where T : SquirrelSettings => o.Modify(b => b.RemoveCollection(() => o.ShortcutLocations, v));
    /// <inheritdoc cref="SquirrelSettings.ShortcutLocations"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.ShortcutLocations))]
    public static T ClearShortcutLocations<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.ClearCollection(() => o.ShortcutLocations));
    #endregion
    #region GenerateNoMsi
    /// <inheritdoc cref="SquirrelSettings.GenerateNoMsi"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.GenerateNoMsi))]
    public static T SetGenerateNoMsi<T>(this T o, bool? v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.GenerateNoMsi, v));
    /// <inheritdoc cref="SquirrelSettings.GenerateNoMsi"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.GenerateNoMsi))]
    public static T ResetGenerateNoMsi<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.GenerateNoMsi));
    /// <inheritdoc cref="SquirrelSettings.GenerateNoMsi"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.GenerateNoMsi))]
    public static T EnableGenerateNoMsi<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.GenerateNoMsi, true));
    /// <inheritdoc cref="SquirrelSettings.GenerateNoMsi"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.GenerateNoMsi))]
    public static T DisableGenerateNoMsi<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.GenerateNoMsi, false));
    /// <inheritdoc cref="SquirrelSettings.GenerateNoMsi"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.GenerateNoMsi))]
    public static T ToggleGenerateNoMsi<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.GenerateNoMsi, !o.GenerateNoMsi));
    #endregion
    #region GenerateNoDelta
    /// <inheritdoc cref="SquirrelSettings.GenerateNoDelta"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.GenerateNoDelta))]
    public static T SetGenerateNoDelta<T>(this T o, bool? v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.GenerateNoDelta, v));
    /// <inheritdoc cref="SquirrelSettings.GenerateNoDelta"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.GenerateNoDelta))]
    public static T ResetGenerateNoDelta<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.GenerateNoDelta));
    /// <inheritdoc cref="SquirrelSettings.GenerateNoDelta"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.GenerateNoDelta))]
    public static T EnableGenerateNoDelta<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.GenerateNoDelta, true));
    /// <inheritdoc cref="SquirrelSettings.GenerateNoDelta"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.GenerateNoDelta))]
    public static T DisableGenerateNoDelta<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.GenerateNoDelta, false));
    /// <inheritdoc cref="SquirrelSettings.GenerateNoDelta"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.GenerateNoDelta))]
    public static T ToggleGenerateNoDelta<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.GenerateNoDelta, !o.GenerateNoDelta));
    #endregion
    #region FrameworkVersion
    /// <inheritdoc cref="SquirrelSettings.FrameworkVersion"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.FrameworkVersion))]
    public static T SetFrameworkVersion<T>(this T o, string v) where T : SquirrelSettings => o.Modify(b => b.Set(() => o.FrameworkVersion, v));
    /// <inheritdoc cref="SquirrelSettings.FrameworkVersion"/>
    [Pure] [Builder(Type = typeof(SquirrelSettings), Property = nameof(SquirrelSettings.FrameworkVersion))]
    public static T ResetFrameworkVersion<T>(this T o) where T : SquirrelSettings => o.Modify(b => b.Remove(() => o.FrameworkVersion));
    #endregion
}
#endregion

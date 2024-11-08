// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Unity/Unity.json

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

namespace Nuke.Common.Tools.Unity;

/// <summary><p>Unity is usually launched by double-clicking its icon from the desktop. However, it is also possible to run it from the command line (from the macOS Terminal or the Windows Command Prompt). When launched in this way, Unity can receive commands and information on startup, which can be very useful for test suites, automated builds and other production tasks.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public partial class UnityTasks : ToolTasks
{
    public static string UnityPath => new UnityTasks().GetToolPath();
    /// <summary><p>Unity is usually launched by double-clicking its icon from the desktop. However, it is also possible to run it from the command line (from the macOS Terminal or the Windows Command Prompt). When launched in this way, Unity can receive commands and information on startup, which can be very useful for test suites, automated builds and other production tasks.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Unity(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new UnityTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>(2018.2+) Exports the currently activated license to the path of the Unity executable or either the default Unity license location, see the logs or <a href="https://docs.unity3d.com/Manual/ActivationFAQ.html">Activation FAQ</a> for more information.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-batchmode</c> via <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></li><li><c>-password</c> via <see cref="UnityCreateManualActivationFileSettings.Password"/></li><li><c>-quit</c> via <see cref="UnityCreateManualActivationFileSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityCreateManualActivationFileSettings.Serial"/></li><li><c>-silent-crashes</c> via <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></li><li><c>-username</c> via <see cref="UnityCreateManualActivationFileSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> UnityCreateManualActivationFile(UnityCreateManualActivationFileSettings options = null) => new UnityTasks().Run(options);
    /// <summary><p>(2018.2+) Exports the currently activated license to the path of the Unity executable or either the default Unity license location, see the logs or <a href="https://docs.unity3d.com/Manual/ActivationFAQ.html">Activation FAQ</a> for more information.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-batchmode</c> via <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></li><li><c>-password</c> via <see cref="UnityCreateManualActivationFileSettings.Password"/></li><li><c>-quit</c> via <see cref="UnityCreateManualActivationFileSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityCreateManualActivationFileSettings.Serial"/></li><li><c>-silent-crashes</c> via <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></li><li><c>-username</c> via <see cref="UnityCreateManualActivationFileSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> UnityCreateManualActivationFile(Configure<UnityCreateManualActivationFileSettings> configurator) => new UnityTasks().Run(configurator.Invoke(new UnityCreateManualActivationFileSettings()));
    /// <summary><p>(2018.2+) Exports the currently activated license to the path of the Unity executable or either the default Unity license location, see the logs or <a href="https://docs.unity3d.com/Manual/ActivationFAQ.html">Activation FAQ</a> for more information.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-batchmode</c> via <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></li><li><c>-password</c> via <see cref="UnityCreateManualActivationFileSettings.Password"/></li><li><c>-quit</c> via <see cref="UnityCreateManualActivationFileSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityCreateManualActivationFileSettings.Serial"/></li><li><c>-silent-crashes</c> via <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></li><li><c>-username</c> via <see cref="UnityCreateManualActivationFileSettings.Username"/></li></ul></remarks>
    public static IEnumerable<(UnityCreateManualActivationFileSettings Settings, IReadOnlyCollection<Output> Output)> UnityCreateManualActivationFile(CombinatorialConfigure<UnityCreateManualActivationFileSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(UnityCreateManualActivationFile, degreeOfParallelism, completeOnFailure);
    /// <summary><p>(2018.2+) Activates Unity with a license file.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-batchmode</c> via <see cref="UnityManualLicenseFileSettings.BatchMode"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-manualLicenseFile</c> via <see cref="UnityManualLicenseFileSettings.LicenseFile"/></li><li><c>-nographics</c> via <see cref="UnityManualLicenseFileSettings.NoGraphics"/></li><li><c>-password</c> via <see cref="UnityManualLicenseFileSettings.Password"/></li><li><c>-quit</c> via <see cref="UnityManualLicenseFileSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityManualLicenseFileSettings.Serial"/></li><li><c>-silent-crashes</c> via <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></li><li><c>-username</c> via <see cref="UnityManualLicenseFileSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> UnityManualLicenseFile(UnityManualLicenseFileSettings options = null) => new UnityTasks().Run(options);
    /// <summary><p>(2018.2+) Activates Unity with a license file.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-batchmode</c> via <see cref="UnityManualLicenseFileSettings.BatchMode"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-manualLicenseFile</c> via <see cref="UnityManualLicenseFileSettings.LicenseFile"/></li><li><c>-nographics</c> via <see cref="UnityManualLicenseFileSettings.NoGraphics"/></li><li><c>-password</c> via <see cref="UnityManualLicenseFileSettings.Password"/></li><li><c>-quit</c> via <see cref="UnityManualLicenseFileSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityManualLicenseFileSettings.Serial"/></li><li><c>-silent-crashes</c> via <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></li><li><c>-username</c> via <see cref="UnityManualLicenseFileSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> UnityManualLicenseFile(Configure<UnityManualLicenseFileSettings> configurator) => new UnityTasks().Run(configurator.Invoke(new UnityManualLicenseFileSettings()));
    /// <summary><p>(2018.2+) Activates Unity with a license file.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-batchmode</c> via <see cref="UnityManualLicenseFileSettings.BatchMode"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-manualLicenseFile</c> via <see cref="UnityManualLicenseFileSettings.LicenseFile"/></li><li><c>-nographics</c> via <see cref="UnityManualLicenseFileSettings.NoGraphics"/></li><li><c>-password</c> via <see cref="UnityManualLicenseFileSettings.Password"/></li><li><c>-quit</c> via <see cref="UnityManualLicenseFileSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityManualLicenseFileSettings.Serial"/></li><li><c>-silent-crashes</c> via <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></li><li><c>-username</c> via <see cref="UnityManualLicenseFileSettings.Username"/></li></ul></remarks>
    public static IEnumerable<(UnityManualLicenseFileSettings Settings, IReadOnlyCollection<Output> Output)> UnityManualLicenseFile(CombinatorialConfigure<UnityManualLicenseFileSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(UnityManualLicenseFile, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Execute Unity.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;customArguments&gt;</c> via <see cref="UnityProjectOptions.CustomArguments"/></li><li><c>-accept-apiupdate</c> via <see cref="UnityProjectOptions.AcceptApiUpdate"/></li><li><c>-assetServerUpdate</c> via <see cref="UnityProjectOptions.AssetServerUpdate"/></li><li><c>-batchmode</c> via <see cref="UnitySettings.BatchMode"/></li><li><c>-buildLinux32Player</c> via <see cref="UnitySettings.BuildLinux32Player"/></li><li><c>-buildLinux64Player</c> via <see cref="UnitySettings.BuildLinux64Player"/></li><li><c>-buildLinuxUniversalPlayer</c> via <see cref="UnitySettings.BuildLinuxUniversalPlayer"/></li><li><c>-buildOSX64Player</c> via <see cref="UnitySettings.BuildOSX64Player"/></li><li><c>-buildOSXPlayer</c> via <see cref="UnitySettings.BuildOSXPlayer"/></li><li><c>-buildOSXUniversalPlayer</c> via <see cref="UnitySettings.BuildOSXUniversalPlayer"/></li><li><c>-buildTarget</c> via <see cref="UnityProjectOptions.BuildTarget"/></li><li><c>-buildWindows64Player</c> via <see cref="UnitySettings.BuildWindows64Player"/></li><li><c>-buildWindowsPlayer</c> via <see cref="UnitySettings.BuildWindowsPlayer"/></li><li><c>-cacheServerIPAddress</c> via <see cref="UnityProjectOptions.CacheServerIPAddress"/></li><li><c>-createProject</c> via <see cref="UnitySettings.CreateProject"/></li><li><c>-disable-assembly-updater</c> via <see cref="UnityProjectOptions.DisableAssemblyUpdater"/></li><li><c>-editorTestsCategories</c> via <see cref="UnitySettings.EditorTestsCategories"/></li><li><c>-editorTestsFilter</c> via <see cref="UnitySettings.EditorTestsFilter"/></li><li><c>-editorTestsResultFile</c> via <see cref="UnitySettings.EditorTestsResultFile"/></li><li><c>-executeMethod</c> via <see cref="UnitySettings.ExecuteMethod"/></li><li><c>-exportPackage</c> via <see cref="UnitySettings.ExportPackage"/></li><li><c>-force-clamped</c> via <see cref="UnityProjectOptions.ForceClamped"/></li><li><c>-force-d3d11</c> via <see cref="UnityProjectOptions.ForceD3d11"/></li><li><c>-force-device-index</c> via <see cref="UnityProjectOptions.ForceDeviceIndex"/></li><li><c>-force-gfx-metal</c> via <see cref="UnityProjectOptions.ForceGfxMetal"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCore"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCoreXY"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLES"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLESXY"/></li><li><c>-force-low-power-device</c> via <see cref="UnityProjectOptions.ForceLowPowerDevice"/></li><li><c>-importPackage</c> via <see cref="UnitySettings.ImportPackage"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnitySettings.NoGraphics"/></li><li><c>-noUpm</c> via <see cref="UnityProjectOptions.NoUpm"/></li><li><c>-password</c> via <see cref="UnitySettings.Password"/></li><li><c>-projectPath</c> via <see cref="UnityProjectOptions.ProjectPath"/></li><li><c>-quit</c> via <see cref="UnitySettings.Quit"/></li><li><c>-runEditorTests</c> via <see cref="UnitySettings.RunEditorTests"/></li><li><c>-serial</c> via <see cref="UnitySettings.Serial"/></li><li><c>-setDefaultPlatformTextureFormat</c> via <see cref="UnityProjectOptions.DefaultPlatformTextureFormat"/></li><li><c>-silent-crashes</c> via <see cref="UnitySettings.SilentCrashes"/></li><li><c>-stackTraceLogType</c> via <see cref="UnityProjectOptions.StackTraceLogType"/></li><li><c>-username</c> via <see cref="UnitySettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Unity(UnitySettings options = null) => new UnityTasks().Run(options);
    /// <summary><p>Execute Unity.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;customArguments&gt;</c> via <see cref="UnityProjectOptions.CustomArguments"/></li><li><c>-accept-apiupdate</c> via <see cref="UnityProjectOptions.AcceptApiUpdate"/></li><li><c>-assetServerUpdate</c> via <see cref="UnityProjectOptions.AssetServerUpdate"/></li><li><c>-batchmode</c> via <see cref="UnitySettings.BatchMode"/></li><li><c>-buildLinux32Player</c> via <see cref="UnitySettings.BuildLinux32Player"/></li><li><c>-buildLinux64Player</c> via <see cref="UnitySettings.BuildLinux64Player"/></li><li><c>-buildLinuxUniversalPlayer</c> via <see cref="UnitySettings.BuildLinuxUniversalPlayer"/></li><li><c>-buildOSX64Player</c> via <see cref="UnitySettings.BuildOSX64Player"/></li><li><c>-buildOSXPlayer</c> via <see cref="UnitySettings.BuildOSXPlayer"/></li><li><c>-buildOSXUniversalPlayer</c> via <see cref="UnitySettings.BuildOSXUniversalPlayer"/></li><li><c>-buildTarget</c> via <see cref="UnityProjectOptions.BuildTarget"/></li><li><c>-buildWindows64Player</c> via <see cref="UnitySettings.BuildWindows64Player"/></li><li><c>-buildWindowsPlayer</c> via <see cref="UnitySettings.BuildWindowsPlayer"/></li><li><c>-cacheServerIPAddress</c> via <see cref="UnityProjectOptions.CacheServerIPAddress"/></li><li><c>-createProject</c> via <see cref="UnitySettings.CreateProject"/></li><li><c>-disable-assembly-updater</c> via <see cref="UnityProjectOptions.DisableAssemblyUpdater"/></li><li><c>-editorTestsCategories</c> via <see cref="UnitySettings.EditorTestsCategories"/></li><li><c>-editorTestsFilter</c> via <see cref="UnitySettings.EditorTestsFilter"/></li><li><c>-editorTestsResultFile</c> via <see cref="UnitySettings.EditorTestsResultFile"/></li><li><c>-executeMethod</c> via <see cref="UnitySettings.ExecuteMethod"/></li><li><c>-exportPackage</c> via <see cref="UnitySettings.ExportPackage"/></li><li><c>-force-clamped</c> via <see cref="UnityProjectOptions.ForceClamped"/></li><li><c>-force-d3d11</c> via <see cref="UnityProjectOptions.ForceD3d11"/></li><li><c>-force-device-index</c> via <see cref="UnityProjectOptions.ForceDeviceIndex"/></li><li><c>-force-gfx-metal</c> via <see cref="UnityProjectOptions.ForceGfxMetal"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCore"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCoreXY"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLES"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLESXY"/></li><li><c>-force-low-power-device</c> via <see cref="UnityProjectOptions.ForceLowPowerDevice"/></li><li><c>-importPackage</c> via <see cref="UnitySettings.ImportPackage"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnitySettings.NoGraphics"/></li><li><c>-noUpm</c> via <see cref="UnityProjectOptions.NoUpm"/></li><li><c>-password</c> via <see cref="UnitySettings.Password"/></li><li><c>-projectPath</c> via <see cref="UnityProjectOptions.ProjectPath"/></li><li><c>-quit</c> via <see cref="UnitySettings.Quit"/></li><li><c>-runEditorTests</c> via <see cref="UnitySettings.RunEditorTests"/></li><li><c>-serial</c> via <see cref="UnitySettings.Serial"/></li><li><c>-setDefaultPlatformTextureFormat</c> via <see cref="UnityProjectOptions.DefaultPlatformTextureFormat"/></li><li><c>-silent-crashes</c> via <see cref="UnitySettings.SilentCrashes"/></li><li><c>-stackTraceLogType</c> via <see cref="UnityProjectOptions.StackTraceLogType"/></li><li><c>-username</c> via <see cref="UnitySettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Unity(Configure<UnitySettings> configurator) => new UnityTasks().Run(configurator.Invoke(new UnitySettings()));
    /// <summary><p>Execute Unity.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;customArguments&gt;</c> via <see cref="UnityProjectOptions.CustomArguments"/></li><li><c>-accept-apiupdate</c> via <see cref="UnityProjectOptions.AcceptApiUpdate"/></li><li><c>-assetServerUpdate</c> via <see cref="UnityProjectOptions.AssetServerUpdate"/></li><li><c>-batchmode</c> via <see cref="UnitySettings.BatchMode"/></li><li><c>-buildLinux32Player</c> via <see cref="UnitySettings.BuildLinux32Player"/></li><li><c>-buildLinux64Player</c> via <see cref="UnitySettings.BuildLinux64Player"/></li><li><c>-buildLinuxUniversalPlayer</c> via <see cref="UnitySettings.BuildLinuxUniversalPlayer"/></li><li><c>-buildOSX64Player</c> via <see cref="UnitySettings.BuildOSX64Player"/></li><li><c>-buildOSXPlayer</c> via <see cref="UnitySettings.BuildOSXPlayer"/></li><li><c>-buildOSXUniversalPlayer</c> via <see cref="UnitySettings.BuildOSXUniversalPlayer"/></li><li><c>-buildTarget</c> via <see cref="UnityProjectOptions.BuildTarget"/></li><li><c>-buildWindows64Player</c> via <see cref="UnitySettings.BuildWindows64Player"/></li><li><c>-buildWindowsPlayer</c> via <see cref="UnitySettings.BuildWindowsPlayer"/></li><li><c>-cacheServerIPAddress</c> via <see cref="UnityProjectOptions.CacheServerIPAddress"/></li><li><c>-createProject</c> via <see cref="UnitySettings.CreateProject"/></li><li><c>-disable-assembly-updater</c> via <see cref="UnityProjectOptions.DisableAssemblyUpdater"/></li><li><c>-editorTestsCategories</c> via <see cref="UnitySettings.EditorTestsCategories"/></li><li><c>-editorTestsFilter</c> via <see cref="UnitySettings.EditorTestsFilter"/></li><li><c>-editorTestsResultFile</c> via <see cref="UnitySettings.EditorTestsResultFile"/></li><li><c>-executeMethod</c> via <see cref="UnitySettings.ExecuteMethod"/></li><li><c>-exportPackage</c> via <see cref="UnitySettings.ExportPackage"/></li><li><c>-force-clamped</c> via <see cref="UnityProjectOptions.ForceClamped"/></li><li><c>-force-d3d11</c> via <see cref="UnityProjectOptions.ForceD3d11"/></li><li><c>-force-device-index</c> via <see cref="UnityProjectOptions.ForceDeviceIndex"/></li><li><c>-force-gfx-metal</c> via <see cref="UnityProjectOptions.ForceGfxMetal"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCore"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCoreXY"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLES"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLESXY"/></li><li><c>-force-low-power-device</c> via <see cref="UnityProjectOptions.ForceLowPowerDevice"/></li><li><c>-importPackage</c> via <see cref="UnitySettings.ImportPackage"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnitySettings.NoGraphics"/></li><li><c>-noUpm</c> via <see cref="UnityProjectOptions.NoUpm"/></li><li><c>-password</c> via <see cref="UnitySettings.Password"/></li><li><c>-projectPath</c> via <see cref="UnityProjectOptions.ProjectPath"/></li><li><c>-quit</c> via <see cref="UnitySettings.Quit"/></li><li><c>-runEditorTests</c> via <see cref="UnitySettings.RunEditorTests"/></li><li><c>-serial</c> via <see cref="UnitySettings.Serial"/></li><li><c>-setDefaultPlatformTextureFormat</c> via <see cref="UnityProjectOptions.DefaultPlatformTextureFormat"/></li><li><c>-silent-crashes</c> via <see cref="UnitySettings.SilentCrashes"/></li><li><c>-stackTraceLogType</c> via <see cref="UnityProjectOptions.StackTraceLogType"/></li><li><c>-username</c> via <see cref="UnitySettings.Username"/></li></ul></remarks>
    public static IEnumerable<(UnitySettings Settings, IReadOnlyCollection<Output> Output)> Unity(CombinatorialConfigure<UnitySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(Unity, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Return the currenlty activated Unity license.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-batchmode</c> via <see cref="UnityReturnLicenseSettings.BatchMode"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnityReturnLicenseSettings.NoGraphics"/></li><li><c>-password</c> via <see cref="UnityReturnLicenseSettings.Password"/></li><li><c>-quit</c> via <see cref="UnityReturnLicenseSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityReturnLicenseSettings.Serial"/></li><li><c>-silent-crashes</c> via <see cref="UnityReturnLicenseSettings.SilentCrashes"/></li><li><c>-username</c> via <see cref="UnityReturnLicenseSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> UnityReturnLicense(UnityReturnLicenseSettings options = null) => new UnityTasks().Run(options);
    /// <summary><p>Return the currenlty activated Unity license.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-batchmode</c> via <see cref="UnityReturnLicenseSettings.BatchMode"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnityReturnLicenseSettings.NoGraphics"/></li><li><c>-password</c> via <see cref="UnityReturnLicenseSettings.Password"/></li><li><c>-quit</c> via <see cref="UnityReturnLicenseSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityReturnLicenseSettings.Serial"/></li><li><c>-silent-crashes</c> via <see cref="UnityReturnLicenseSettings.SilentCrashes"/></li><li><c>-username</c> via <see cref="UnityReturnLicenseSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> UnityReturnLicense(Configure<UnityReturnLicenseSettings> configurator) => new UnityTasks().Run(configurator.Invoke(new UnityReturnLicenseSettings()));
    /// <summary><p>Return the currenlty activated Unity license.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>-batchmode</c> via <see cref="UnityReturnLicenseSettings.BatchMode"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnityReturnLicenseSettings.NoGraphics"/></li><li><c>-password</c> via <see cref="UnityReturnLicenseSettings.Password"/></li><li><c>-quit</c> via <see cref="UnityReturnLicenseSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityReturnLicenseSettings.Serial"/></li><li><c>-silent-crashes</c> via <see cref="UnityReturnLicenseSettings.SilentCrashes"/></li><li><c>-username</c> via <see cref="UnityReturnLicenseSettings.Username"/></li></ul></remarks>
    public static IEnumerable<(UnityReturnLicenseSettings Settings, IReadOnlyCollection<Output> Output)> UnityReturnLicense(CombinatorialConfigure<UnityReturnLicenseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(UnityReturnLicense, degreeOfParallelism, completeOnFailure);
    /// <summary><p>(2019.2+) Run tests in the project using Unity Test Framework. This argument requires the <c>projectPath</c>, and it's good practice to run it with <c>batchmode</c> argument. <c>quit</c> is not required, because the Editor automatically closes down after the run is finished.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;customArguments&gt;</c> via <see cref="UnityProjectOptions.CustomArguments"/></li><li><c>-accept-apiupdate</c> via <see cref="UnityProjectOptions.AcceptApiUpdate"/></li><li><c>-assetServerUpdate</c> via <see cref="UnityProjectOptions.AssetServerUpdate"/></li><li><c>-batchmode</c> via <see cref="UnityRunTestsSettings.BatchMode"/></li><li><c>-buildTarget</c> via <see cref="UnityProjectOptions.BuildTarget"/></li><li><c>-cacheServerIPAddress</c> via <see cref="UnityProjectOptions.CacheServerIPAddress"/></li><li><c>-disable-assembly-updater</c> via <see cref="UnityProjectOptions.DisableAssemblyUpdater"/></li><li><c>-force-clamped</c> via <see cref="UnityProjectOptions.ForceClamped"/></li><li><c>-force-d3d11</c> via <see cref="UnityProjectOptions.ForceD3d11"/></li><li><c>-force-device-index</c> via <see cref="UnityProjectOptions.ForceDeviceIndex"/></li><li><c>-force-gfx-metal</c> via <see cref="UnityProjectOptions.ForceGfxMetal"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCore"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCoreXY"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLES"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLESXY"/></li><li><c>-force-low-power-device</c> via <see cref="UnityProjectOptions.ForceLowPowerDevice"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnityRunTestsSettings.NoGraphics"/></li><li><c>-noUpm</c> via <see cref="UnityProjectOptions.NoUpm"/></li><li><c>-password</c> via <see cref="UnityRunTestsSettings.Password"/></li><li><c>-projectPath</c> via <see cref="UnityProjectOptions.ProjectPath"/></li><li><c>-quit</c> via <see cref="UnityRunTestsSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityRunTestsSettings.Serial"/></li><li><c>-setDefaultPlatformTextureFormat</c> via <see cref="UnityProjectOptions.DefaultPlatformTextureFormat"/></li><li><c>-silent-crashes</c> via <see cref="UnityRunTestsSettings.SilentCrashes"/></li><li><c>-stackTraceLogType</c> via <see cref="UnityProjectOptions.StackTraceLogType"/></li><li><c>-testCategory</c> via <see cref="UnityRunTestsSettings.TestCategories"/></li><li><c>-testFilter</c> via <see cref="UnityRunTestsSettings.TestFilters"/></li><li><c>-testPlatform</c> via <see cref="UnityRunTestsSettings.TestPlatform"/></li><li><c>-testResults</c> via <see cref="UnityRunTestsSettings.TestResultFile"/></li><li><c>-username</c> via <see cref="UnityRunTestsSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> UnityRunTests(UnityRunTestsSettings options = null) => new UnityTasks().Run(options);
    /// <summary><p>(2019.2+) Run tests in the project using Unity Test Framework. This argument requires the <c>projectPath</c>, and it's good practice to run it with <c>batchmode</c> argument. <c>quit</c> is not required, because the Editor automatically closes down after the run is finished.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;customArguments&gt;</c> via <see cref="UnityProjectOptions.CustomArguments"/></li><li><c>-accept-apiupdate</c> via <see cref="UnityProjectOptions.AcceptApiUpdate"/></li><li><c>-assetServerUpdate</c> via <see cref="UnityProjectOptions.AssetServerUpdate"/></li><li><c>-batchmode</c> via <see cref="UnityRunTestsSettings.BatchMode"/></li><li><c>-buildTarget</c> via <see cref="UnityProjectOptions.BuildTarget"/></li><li><c>-cacheServerIPAddress</c> via <see cref="UnityProjectOptions.CacheServerIPAddress"/></li><li><c>-disable-assembly-updater</c> via <see cref="UnityProjectOptions.DisableAssemblyUpdater"/></li><li><c>-force-clamped</c> via <see cref="UnityProjectOptions.ForceClamped"/></li><li><c>-force-d3d11</c> via <see cref="UnityProjectOptions.ForceD3d11"/></li><li><c>-force-device-index</c> via <see cref="UnityProjectOptions.ForceDeviceIndex"/></li><li><c>-force-gfx-metal</c> via <see cref="UnityProjectOptions.ForceGfxMetal"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCore"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCoreXY"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLES"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLESXY"/></li><li><c>-force-low-power-device</c> via <see cref="UnityProjectOptions.ForceLowPowerDevice"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnityRunTestsSettings.NoGraphics"/></li><li><c>-noUpm</c> via <see cref="UnityProjectOptions.NoUpm"/></li><li><c>-password</c> via <see cref="UnityRunTestsSettings.Password"/></li><li><c>-projectPath</c> via <see cref="UnityProjectOptions.ProjectPath"/></li><li><c>-quit</c> via <see cref="UnityRunTestsSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityRunTestsSettings.Serial"/></li><li><c>-setDefaultPlatformTextureFormat</c> via <see cref="UnityProjectOptions.DefaultPlatformTextureFormat"/></li><li><c>-silent-crashes</c> via <see cref="UnityRunTestsSettings.SilentCrashes"/></li><li><c>-stackTraceLogType</c> via <see cref="UnityProjectOptions.StackTraceLogType"/></li><li><c>-testCategory</c> via <see cref="UnityRunTestsSettings.TestCategories"/></li><li><c>-testFilter</c> via <see cref="UnityRunTestsSettings.TestFilters"/></li><li><c>-testPlatform</c> via <see cref="UnityRunTestsSettings.TestPlatform"/></li><li><c>-testResults</c> via <see cref="UnityRunTestsSettings.TestResultFile"/></li><li><c>-username</c> via <see cref="UnityRunTestsSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> UnityRunTests(Configure<UnityRunTestsSettings> configurator) => new UnityTasks().Run(configurator.Invoke(new UnityRunTestsSettings()));
    /// <summary><p>(2019.2+) Run tests in the project using Unity Test Framework. This argument requires the <c>projectPath</c>, and it's good practice to run it with <c>batchmode</c> argument. <c>quit</c> is not required, because the Editor automatically closes down after the run is finished.</p><p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;customArguments&gt;</c> via <see cref="UnityProjectOptions.CustomArguments"/></li><li><c>-accept-apiupdate</c> via <see cref="UnityProjectOptions.AcceptApiUpdate"/></li><li><c>-assetServerUpdate</c> via <see cref="UnityProjectOptions.AssetServerUpdate"/></li><li><c>-batchmode</c> via <see cref="UnityRunTestsSettings.BatchMode"/></li><li><c>-buildTarget</c> via <see cref="UnityProjectOptions.BuildTarget"/></li><li><c>-cacheServerIPAddress</c> via <see cref="UnityProjectOptions.CacheServerIPAddress"/></li><li><c>-disable-assembly-updater</c> via <see cref="UnityProjectOptions.DisableAssemblyUpdater"/></li><li><c>-force-clamped</c> via <see cref="UnityProjectOptions.ForceClamped"/></li><li><c>-force-d3d11</c> via <see cref="UnityProjectOptions.ForceD3d11"/></li><li><c>-force-device-index</c> via <see cref="UnityProjectOptions.ForceDeviceIndex"/></li><li><c>-force-gfx-metal</c> via <see cref="UnityProjectOptions.ForceGfxMetal"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCore"/></li><li><c>-force-glcore</c> via <see cref="UnityProjectOptions.ForceGLCoreXY"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLES"/></li><li><c>-force-gles</c> via <see cref="UnityProjectOptions.ForceGLESXY"/></li><li><c>-force-low-power-device</c> via <see cref="UnityProjectOptions.ForceLowPowerDevice"/></li><li><c>-logFile</c> via <see cref="UnityOptionsBase.LogFile"/></li><li><c>-nographics</c> via <see cref="UnityRunTestsSettings.NoGraphics"/></li><li><c>-noUpm</c> via <see cref="UnityProjectOptions.NoUpm"/></li><li><c>-password</c> via <see cref="UnityRunTestsSettings.Password"/></li><li><c>-projectPath</c> via <see cref="UnityProjectOptions.ProjectPath"/></li><li><c>-quit</c> via <see cref="UnityRunTestsSettings.Quit"/></li><li><c>-serial</c> via <see cref="UnityRunTestsSettings.Serial"/></li><li><c>-setDefaultPlatformTextureFormat</c> via <see cref="UnityProjectOptions.DefaultPlatformTextureFormat"/></li><li><c>-silent-crashes</c> via <see cref="UnityRunTestsSettings.SilentCrashes"/></li><li><c>-stackTraceLogType</c> via <see cref="UnityProjectOptions.StackTraceLogType"/></li><li><c>-testCategory</c> via <see cref="UnityRunTestsSettings.TestCategories"/></li><li><c>-testFilter</c> via <see cref="UnityRunTestsSettings.TestFilters"/></li><li><c>-testPlatform</c> via <see cref="UnityRunTestsSettings.TestPlatform"/></li><li><c>-testResults</c> via <see cref="UnityRunTestsSettings.TestResultFile"/></li><li><c>-username</c> via <see cref="UnityRunTestsSettings.Username"/></li></ul></remarks>
    public static IEnumerable<(UnityRunTestsSettings Settings, IReadOnlyCollection<Output> Output)> UnityRunTests(CombinatorialConfigure<UnityRunTestsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(UnityRunTests, degreeOfParallelism, completeOnFailure);
}
#region UnityCreateManualActivationFileSettings
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityCreateManualActivationFileSettings>))]
[Command(Type = typeof(UnityTasks), Command = nameof(UnityTasks.UnityCreateManualActivationFile), Arguments = "-createManualActivationFile")]
public partial class UnityCreateManualActivationFileSettings : UnityOptionsBase
{
    /// <summary>Enter a username into the log-in form during activation of the Unity Editor.</summary>
    [Argument(Format = "-username {value}")] public string Username => Get<string>(() => Username);
    /// <summary>Enter a password into the log-in form during activation of the Unity Editor.</summary>
    [Argument(Format = "-password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</summary>
    [Argument(Format = "-serial {value}", Secret = true)] public string Serial => Get<string>(() => Serial);
    /// <summary>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</summary>
    [Argument(Format = "-batchmode")] public bool? BatchMode => Get<bool?>(() => BatchMode);
    /// <summary>Don't display a crash dialog.</summary>
    [Argument(Format = "-silent-crashes")] public bool? SilentCrashes => Get<bool?>(() => SilentCrashes);
    /// <summary>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</summary>
    [Argument(Format = "-nographics")] public bool? NoGraphics => Get<bool?>(() => NoGraphics);
    /// <summary>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</summary>
    [Argument(Format = "-quit")] public bool? Quit => Get<bool?>(() => Quit);
}
#endregion
#region UnityManualLicenseFileSettings
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityManualLicenseFileSettings>))]
[Command(Type = typeof(UnityTasks), Command = nameof(UnityTasks.UnityManualLicenseFile))]
public partial class UnityManualLicenseFileSettings : UnityOptionsBase
{
    /// <summary>The path to the license file.</summary>
    [Argument(Format = "-manualLicenseFile {value}")] public string LicenseFile => Get<string>(() => LicenseFile);
    /// <summary>Enter a username into the log-in form during activation of the Unity Editor.</summary>
    [Argument(Format = "-username {value}")] public string Username => Get<string>(() => Username);
    /// <summary>Enter a password into the log-in form during activation of the Unity Editor.</summary>
    [Argument(Format = "-password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</summary>
    [Argument(Format = "-serial {value}", Secret = true)] public string Serial => Get<string>(() => Serial);
    /// <summary>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</summary>
    [Argument(Format = "-batchmode")] public bool? BatchMode => Get<bool?>(() => BatchMode);
    /// <summary>Don't display a crash dialog.</summary>
    [Argument(Format = "-silent-crashes")] public bool? SilentCrashes => Get<bool?>(() => SilentCrashes);
    /// <summary>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</summary>
    [Argument(Format = "-nographics")] public bool? NoGraphics => Get<bool?>(() => NoGraphics);
    /// <summary>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</summary>
    [Argument(Format = "-quit")] public bool? Quit => Get<bool?>(() => Quit);
}
#endregion
#region UnitySettings
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnitySettings>))]
[Command(Type = typeof(UnityTasks), Command = nameof(UnityTasks.Unity))]
public partial class UnitySettings : UnityProjectOptions
{
    /// <summary>Build a 32-bit standalone Linux player (for example, <c>-buildLinux32Player path/to/your/build</c>).</summary>
    [Argument(Format = "-buildLinux32Player {value}")] public string BuildLinux32Player => Get<string>(() => BuildLinux32Player);
    /// <summary>Build a 64-bit standalone Linux player (for example, <c>-buildLinux64Player path/to/your/build</c>).</summary>
    [Argument(Format = "-buildLinux64Player {value}")] public string BuildLinux64Player => Get<string>(() => BuildLinux64Player);
    /// <summary>Build a combined 32-bit and 64-bit standalone Linux player (for example, <c>-buildLinuxUniversalPlayer path/to/your/build</c>).</summary>
    [Argument(Format = "-buildLinuxUniversalPlayer {value}")] public string BuildLinuxUniversalPlayer => Get<string>(() => BuildLinuxUniversalPlayer);
    /// <summary>Build a 32-bit standalone Mac OSX player (for example, <c>-buildOSXPlayer path/to/your/build.app</c>).</summary>
    [Argument(Format = "-buildOSXPlayer {value}")] public string BuildOSXPlayer => Get<string>(() => BuildOSXPlayer);
    /// <summary>Build a 64-bit standalone Mac OSX player (for example, <c>-buildOSX64Player path/to/your/build.app</c>).</summary>
    [Argument(Format = "-buildOSX64Player {value}")] public string BuildOSX64Player => Get<string>(() => BuildOSX64Player);
    /// <summary>Build a combined 32-bit and 64-bit standalone Mac OSX player (for example, <c>-buildOSXUniversalPlayer path/to/your/build.app</c>).</summary>
    [Argument(Format = "-buildOSXUniversalPlayer {value}")] public string BuildOSXUniversalPlayer => Get<string>(() => BuildOSXUniversalPlayer);
    /// <summary>Build a 32-bit standalone Windows player (for example, <c>-buildWindowsPlayer path/to/your/build.exe</c>).</summary>
    [Argument(Format = "-buildWindowsPlayer {value}")] public string BuildWindowsPlayer => Get<string>(() => BuildWindowsPlayer);
    /// <summary>Build a 64-bit standalone Windows player (for example, <c>-buildWindows64Player path/to/your/build.exe</c>).</summary>
    [Argument(Format = "-buildWindows64Player {value}")] public string BuildWindows64Player => Get<string>(() => BuildWindows64Player);
    /// <summary>Create an empty project at the given path.</summary>
    [Argument(Format = "-createProject {value}")] public string CreateProject => Get<string>(() => CreateProject);
    /// <summary>Execute the static method as soon as Unity is started, the project is open and after the optional Asset server update has been performed. This can be used to do tasks such as continous integration, performing Unit Tests, making builds or preparing data. To return an error from the command line process, either throw an exception which causes Unity to exit with return code <b>1</b>, or call <a href="https:/docs.unity3d.com/ScriptReference/EditorApplication.Exit.html">EditorApplication.Exit</a> with a non-zero return code.To use <b>ExecuteMethod</b>, you need to place the enclosing script in an Editor folder. The method to be executed must be defined as <c>static</c>.</summary>
    [Argument(Format = "-executeMethod {value}")] public string ExecuteMethod => Get<string>(() => ExecuteMethod);
    /// <summary>Import the given <a href="https://docs.unity3d.com/Manual/HOWTO-exportpackage.html">package</a>. No import dialog is shown.</summary>
    [Argument(Format = "-importPackage {value}")] public string ImportPackage => Get<string>(() => ImportPackage);
    /// <summary>Run Editor tests from the project. This argument requires the <c>projectPath</c>, and it’s good practice to run it with <c>batchmode</c> argument. <c>quit</c> is not required, because the Editor automatically closes down after the run is finished.</summary>
    [Argument(Format = "-runEditorTests")] public bool? RunEditorTests => Get<bool?>(() => RunEditorTests);
    /// <summary>Filter editor tests by categories.</summary>
    [Argument(Format = "-editorTestsCategories {value}", Separator = ",")] public IReadOnlyList<string> EditorTestsCategories => Get<List<string>>(() => EditorTestsCategories);
    /// <summary>Filter editor tests by names.</summary>
    [Argument(Format = "-editorTestsFilter {value}", Separator = ",")] public IReadOnlyList<string> EditorTestsFilter => Get<List<string>>(() => EditorTestsFilter);
    /// <summary>Path where the result file should be placed. If the path is a folder, a default file name is used. If not specified, the results are placed in the project's root folder.</summary>
    [Argument(Format = "-editorTestsResultFile {value}")] public string EditorTestsResultFile => Get<string>(() => EditorTestsResultFile);
    /// <summary>Export a package, given a path (or set of given paths).<c>-exportPackage &lt;exportAssetPath&gt; &lt;exportFileName&gt;</c> In this example exportAssetPath is a folder (relative to to the Unity project root) to export from the Unity project, and exportFileName is the package name. Currently, this option only exports whole folders at a time. You normally need to use this command with the -projectPath argument.</summary>
    [Argument(Format = "-exportPackage {value}", Separator = " ")] public IReadOnlyList<string> ExportPackage => Get<List<string>>(() => ExportPackage);
    /// <summary>Enter a username into the log-in form during activation of the Unity Editor.</summary>
    [Argument(Format = "-username {value}")] public string Username => Get<string>(() => Username);
    /// <summary>Enter a password into the log-in form during activation of the Unity Editor.</summary>
    [Argument(Format = "-password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</summary>
    [Argument(Format = "-serial {value}", Secret = true)] public string Serial => Get<string>(() => Serial);
    /// <summary>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</summary>
    [Argument(Format = "-batchmode")] public bool? BatchMode => Get<bool?>(() => BatchMode);
    /// <summary>Don't display a crash dialog.</summary>
    [Argument(Format = "-silent-crashes")] public bool? SilentCrashes => Get<bool?>(() => SilentCrashes);
    /// <summary>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</summary>
    [Argument(Format = "-nographics")] public bool? NoGraphics => Get<bool?>(() => NoGraphics);
    /// <summary>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</summary>
    [Argument(Format = "-quit")] public bool? Quit => Get<bool?>(() => Quit);
}
#endregion
#region UnityReturnLicenseSettings
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityReturnLicenseSettings>))]
[Command(Type = typeof(UnityTasks), Command = nameof(UnityTasks.UnityReturnLicense), Arguments = "-returnlicense")]
public partial class UnityReturnLicenseSettings : UnityOptionsBase
{
    /// <summary>Enter a username into the log-in form during activation of the Unity Editor.</summary>
    [Argument(Format = "-username {value}")] public string Username => Get<string>(() => Username);
    /// <summary>Enter a password into the log-in form during activation of the Unity Editor.</summary>
    [Argument(Format = "-password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</summary>
    [Argument(Format = "-serial {value}", Secret = true)] public string Serial => Get<string>(() => Serial);
    /// <summary>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</summary>
    [Argument(Format = "-batchmode")] public bool? BatchMode => Get<bool?>(() => BatchMode);
    /// <summary>Don't display a crash dialog.</summary>
    [Argument(Format = "-silent-crashes")] public bool? SilentCrashes => Get<bool?>(() => SilentCrashes);
    /// <summary>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</summary>
    [Argument(Format = "-nographics")] public bool? NoGraphics => Get<bool?>(() => NoGraphics);
    /// <summary>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</summary>
    [Argument(Format = "-quit")] public bool? Quit => Get<bool?>(() => Quit);
}
#endregion
#region UnityRunTestsSettings
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityRunTestsSettings>))]
[Command(Type = typeof(UnityTasks), Command = nameof(UnityTasks.UnityRunTests), Arguments = "-runTests")]
public partial class UnityRunTestsSettings : UnityProjectOptions
{
    /// <summary>A list of test categories to include in the run, or a regular expression pattern to match category names. If using both <c>TestFilters</c> and <c>TestCategories</c>, then only tests that match both are run. This argument supports negation using '!'. If using '!MyCategory' then no tests with the 'MyCategory' category will be included in the run.</summary>
    [Argument(Format = "-testCategory {value}", Separator = ";", QuoteMultiple = true)] public IReadOnlyList<string> TestCategories => Get<List<string>>(() => TestCategories);
    /// <summary>A list of test names to run, or a regular expression pattern to match tests by their full name. This argument supports negation using '!'. If using the test filter '!MyNamespace.Something.MyTest', then all tests except that test will be run. It is also possible to run a specific variation of a parameterized test like so: 'ClassName.MethodName(Param1,Param2)'.</summary>
    [Argument(Format = "-testFilter {value}", Separator = ";", QuoteMultiple = true)] public IReadOnlyList<string> TestFilters => Get<List<string>>(() => TestFilters);
    /// <summary>Path where the result file should be placed. If the path is a folder, a default file name is used. If not specified, the results are placed in the project's root folder.</summary>
    [Argument(Format = "-testResults {value}")] public string TestResultFile => Get<string>(() => TestResultFile);
    /// <summary>The platform to run tests on.</summary>
    [Argument(Format = "-testPlatform {value}")] public UnityTestPlatform TestPlatform => Get<UnityTestPlatform>(() => TestPlatform);
    /// <summary>Enter a username into the log-in form during activation of the Unity Editor.</summary>
    [Argument(Format = "-username {value}")] public string Username => Get<string>(() => Username);
    /// <summary>Enter a password into the log-in form during activation of the Unity Editor.</summary>
    [Argument(Format = "-password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</summary>
    [Argument(Format = "-serial {value}", Secret = true)] public string Serial => Get<string>(() => Serial);
    /// <summary>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</summary>
    [Argument(Format = "-batchmode")] public bool? BatchMode => Get<bool?>(() => BatchMode);
    /// <summary>Don't display a crash dialog.</summary>
    [Argument(Format = "-silent-crashes")] public bool? SilentCrashes => Get<bool?>(() => SilentCrashes);
    /// <summary>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</summary>
    [Argument(Format = "-nographics")] public bool? NoGraphics => Get<bool?>(() => NoGraphics);
    /// <summary>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</summary>
    [Argument(Format = "-quit")] public bool? Quit => Get<bool?>(() => Quit);
}
#endregion
#region UnityOptionsBase
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityOptionsBase>))]
public partial class UnityOptionsBase : ToolOptions
{
    /// <summary>Specify where the Editor or Windows/Linux/OSX standalone log file are written.</summary>
    [Argument(Format = "-logFile {value}")] public string LogFile => Get<string>(() => LogFile);
    /// <summary>(experimental) If set to true only warnings and errors will be printed to the output.</summary>
    public bool? MinimalOutput => Get<bool?>(() => MinimalOutput);
    /// <summary>Define exit codes which will not fail the build.</summary>
    public IReadOnlyList<int> StableExitCodes => Get<List<int>>(() => StableExitCodes);
    /// <summary>Defines the Unity version to use. The version must be installed via Unity Hub.</summary>
    public string HubVersion => Get<string>(() => HubVersion);
}
#endregion
#region UnityProjectOptions
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityProjectOptions>))]
public partial class UnityProjectOptions : UnityOptionsBase
{
    /// <summary>Force an update of the project in the <a href="https://docs.unity3d.com/Manual/AssetServer.html">Asset Server</a> given by <c>IP:port</c>. The port is optional, and if not given it is assumed to be the standard one (10733). It is advisable to use this command in conjunction with the <c>-projectPath</c> argument to ensure you are working with the correct project. If no project name is given, then the last project opened by Unity is used. If no project exists at the path given by <c>-projectPath</c>, then one is created automatically.</summary>
    [Argument(Format = "-assetServerUpdate {value}")] public string AssetServerUpdate => Get<string>(() => AssetServerUpdate);
    /// <summary>Allows the selection of an active build target before a project is loaded.</summary>
    [Argument(Format = "-buildTarget {value}")] public UnityBuildTarget BuildTarget => Get<UnityBuildTarget>(() => BuildTarget);
    /// <summary>(Windows only) Make the Editor use Direct3D 11 for rendering. Normally the graphics API depends on player settings (typically defaults to D3D11).</summary>
    [Argument(Format = "-force-d3d11")] public bool? ForceD3d11 => Get<bool?>(() => ForceD3d11);
    /// <summary>(macOS only) When using Metal, make the Editor use a particular GPU device by passing it the index of that GPU.</summary>
    [Argument(Format = "-force-device-index")] public bool? ForceDeviceIndex => Get<bool?>(() => ForceDeviceIndex);
    /// <summary>(macOS only) Make the Editor use Metal as the default graphics API.</summary>
    [Argument(Format = "-force-gfx-metal")] public bool? ForceGfxMetal => Get<bool?>(() => ForceGfxMetal);
    /// <summary>(Windows only) Make the Editor use OpenGL 3/4 core profile for rendering. The Editor tries to use the best OpenGL version available and all OpenGL extensions exposed by the OpenGL drivers. If the platform isn't supported, Direct3D is used.</summary>
    [Argument(Format = "-force-glcore")] public bool? ForceGLCore => Get<bool?>(() => ForceGLCore);
    /// <summary>(Windows only) Similar to <c>-force-glcore</c>, but requests a specific OpenGL context version. Accepted values for XY: 32, 33, 40, 41, 42, 43, 44 or 45.</summary>
    [Argument(Format = "-force-glcore{value}")] public UnityGLCore ForceGLCoreXY => Get<UnityGLCore>(() => ForceGLCoreXY);
    /// <summary>(Windows only) Make the Editor use OpenGL for Embedded Systems for rendering. The Editor tries to use the best OpenGL ES version available, and all OpenGL ES extensions exposed by the OpenGL drivers.</summary>
    [Argument(Format = "-force-gles")] public bool? ForceGLES => Get<bool?>(() => ForceGLES);
    /// <summary>(Windows only) Similar to <c>-force-gles</c>, but requests a specific OpenGL ES context version. Accepted values for XY: 30, 31 or 32.</summary>
    [Argument(Format = "-force-gles{value}")] public UnityGLES ForceGLESXY => Get<UnityGLES>(() => ForceGLESXY);
    /// <summary>(2017.3+) (Windows only) Used with <c>-force-glcoreXY</c> to prevent checking for additional OpenGL extensions, allowing it to run between platforms with the same code paths.</summary>
    [Argument(Format = "-force-clamped")] public bool? ForceClamped => Get<bool?>(() => ForceClamped);
    /// <summary>(macOS only) When using Metal, make the Editor use a low power device.</summary>
    [Argument(Format = "-force-low-power-device")] public bool? ForceLowPowerDevice => Get<bool?>(() => ForceLowPowerDevice);
    /// <summary>(2018.1+) Sets the default texture compression to the desired format before importing a texture or building the project. This is so you don’t have to import the texture again with the format you want. The available formats are dxt, pvrtc, atc, etc, etc2, and astc. Note that this is only supported on Android.</summary>
    [Argument(Format = "-setDefaultPlatformTextureFormat {value}")] public string DefaultPlatformTextureFormat => Get<string>(() => DefaultPlatformTextureFormat);
    /// <summary>Specify a space-separated list of assembly names as parameters for Unity to ignore on automatic updates. The space-separated list of assembly names is optional: Pass the command line options without any assembly names to ignore all assemblies.</summary>
    [Argument(Format = "-disable-assembly-updater {value}", Separator = " ")] public IReadOnlyList<string> DisableAssemblyUpdater => Get<List<string>>(() => DisableAssemblyUpdater);
    /// <summary>(2018.1+) Connect to the Cache Server given by <c>IP:port</c> on startup, overriding any configuration stored in the Editor Preferences. Use this to connect multiple instances of Unity to different Cache Servers.</summary>
    [Argument(Format = "-cacheServerIPAddress {value}")] public string CacheServerIPAddress => Get<string>(() => CacheServerIPAddress);
    /// <summary>(2018.1+) Disables the Unity Package Manager.</summary>
    [Argument(Format = "-noUpm")] public bool? NoUpm => Get<bool?>(() => NoUpm);
    /// <summary>(2017.2+) Use this command line option to specify that APIUpdater should run when Unity is launched in batch mode. Omitting this command line argument when launching Unity in batch mode results in APIUpdater not running which can lead to compiler errors. Note that in versions prior to 2017.2 there’s no way to not run APIUpdater when Unity is launched in batch mode.</summary>
    [Argument(Format = "-accept-apiupdate")] public bool? AcceptApiUpdate => Get<bool?>(() => AcceptApiUpdate);
    /// <summary>Custom parameters. To pass parameters, add them to the command line and retrieve them inside the function using <c>System.Environment.GetCommandLineArgs</c>. </summary>
    [Argument(Format = "{value}", Separator = " ")] public IReadOnlyList<string> CustomArguments => Get<List<string>>(() => CustomArguments);
    /// <summary>Detailed debugging feature. StackTraceLogging allows you to allow detailed logging.</summary>
    [Argument(Format = "-stackTraceLogType {value}")] public UnityStackTraceLogType StackTraceLogType => Get<UnityStackTraceLogType>(() => StackTraceLogType);
    /// <summary>Specify the path of the unity project.</summary>
    [Argument(Format = "-projectPath {value}")] public string ProjectPath => Get<string>(() => ProjectPath);
}
#endregion
#region UnityCreateManualActivationFileSettingsExtensions
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class UnityCreateManualActivationFileSettingsExtensions
{
    #region Username
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Username"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Username"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Password
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Password"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Password"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Serial
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Serial"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Serial))]
    public static T SetSerial<T>(this T o, [Secret] string v) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.Serial, v));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Serial"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Serial))]
    public static T ResetSerial<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Remove(() => o.Serial));
    #endregion
    #region BatchMode
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.BatchMode))]
    public static T SetBatchMode<T>(this T o, bool? v) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.BatchMode, v));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.BatchMode))]
    public static T ResetBatchMode<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Remove(() => o.BatchMode));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.BatchMode))]
    public static T EnableBatchMode<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.BatchMode, true));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.BatchMode))]
    public static T DisableBatchMode<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.BatchMode, false));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.BatchMode))]
    public static T ToggleBatchMode<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.BatchMode, !o.BatchMode));
    #endregion
    #region SilentCrashes
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.SilentCrashes))]
    public static T SetSilentCrashes<T>(this T o, bool? v) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.SilentCrashes, v));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.SilentCrashes))]
    public static T ResetSilentCrashes<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Remove(() => o.SilentCrashes));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.SilentCrashes))]
    public static T EnableSilentCrashes<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.SilentCrashes, true));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.SilentCrashes))]
    public static T DisableSilentCrashes<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.SilentCrashes, false));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.SilentCrashes))]
    public static T ToggleSilentCrashes<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.SilentCrashes, !o.SilentCrashes));
    #endregion
    #region NoGraphics
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.NoGraphics))]
    public static T SetNoGraphics<T>(this T o, bool? v) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.NoGraphics, v));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.NoGraphics))]
    public static T ResetNoGraphics<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Remove(() => o.NoGraphics));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.NoGraphics))]
    public static T EnableNoGraphics<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.NoGraphics, true));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.NoGraphics))]
    public static T DisableNoGraphics<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.NoGraphics, false));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.NoGraphics))]
    public static T ToggleNoGraphics<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.NoGraphics, !o.NoGraphics));
    #endregion
    #region Quit
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Quit))]
    public static T SetQuit<T>(this T o, bool? v) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.Quit, v));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Quit))]
    public static T ResetQuit<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Remove(() => o.Quit));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Quit))]
    public static T EnableQuit<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.Quit, true));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Quit))]
    public static T DisableQuit<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.Quit, false));
    /// <inheritdoc cref="UnityCreateManualActivationFileSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityCreateManualActivationFileSettings), Property = nameof(UnityCreateManualActivationFileSettings.Quit))]
    public static T ToggleQuit<T>(this T o) where T : UnityCreateManualActivationFileSettings => o.Modify(b => b.Set(() => o.Quit, !o.Quit));
    #endregion
}
#endregion
#region UnityManualLicenseFileSettingsExtensions
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class UnityManualLicenseFileSettingsExtensions
{
    #region LicenseFile
    /// <inheritdoc cref="UnityManualLicenseFileSettings.LicenseFile"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.LicenseFile))]
    public static T SetLicenseFile<T>(this T o, string v) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.LicenseFile, v));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.LicenseFile"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.LicenseFile))]
    public static T ResetLicenseFile<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Remove(() => o.LicenseFile));
    #endregion
    #region Username
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Username"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Username"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Password
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Password"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Password"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Serial
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Serial"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Serial))]
    public static T SetSerial<T>(this T o, [Secret] string v) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.Serial, v));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Serial"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Serial))]
    public static T ResetSerial<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Remove(() => o.Serial));
    #endregion
    #region BatchMode
    /// <inheritdoc cref="UnityManualLicenseFileSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.BatchMode))]
    public static T SetBatchMode<T>(this T o, bool? v) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.BatchMode, v));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.BatchMode))]
    public static T ResetBatchMode<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Remove(() => o.BatchMode));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.BatchMode))]
    public static T EnableBatchMode<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.BatchMode, true));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.BatchMode))]
    public static T DisableBatchMode<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.BatchMode, false));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.BatchMode))]
    public static T ToggleBatchMode<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.BatchMode, !o.BatchMode));
    #endregion
    #region SilentCrashes
    /// <inheritdoc cref="UnityManualLicenseFileSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.SilentCrashes))]
    public static T SetSilentCrashes<T>(this T o, bool? v) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.SilentCrashes, v));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.SilentCrashes))]
    public static T ResetSilentCrashes<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Remove(() => o.SilentCrashes));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.SilentCrashes))]
    public static T EnableSilentCrashes<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.SilentCrashes, true));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.SilentCrashes))]
    public static T DisableSilentCrashes<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.SilentCrashes, false));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.SilentCrashes))]
    public static T ToggleSilentCrashes<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.SilentCrashes, !o.SilentCrashes));
    #endregion
    #region NoGraphics
    /// <inheritdoc cref="UnityManualLicenseFileSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.NoGraphics))]
    public static T SetNoGraphics<T>(this T o, bool? v) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.NoGraphics, v));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.NoGraphics))]
    public static T ResetNoGraphics<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Remove(() => o.NoGraphics));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.NoGraphics))]
    public static T EnableNoGraphics<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.NoGraphics, true));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.NoGraphics))]
    public static T DisableNoGraphics<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.NoGraphics, false));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.NoGraphics))]
    public static T ToggleNoGraphics<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.NoGraphics, !o.NoGraphics));
    #endregion
    #region Quit
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Quit))]
    public static T SetQuit<T>(this T o, bool? v) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.Quit, v));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Quit))]
    public static T ResetQuit<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Remove(() => o.Quit));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Quit))]
    public static T EnableQuit<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.Quit, true));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Quit))]
    public static T DisableQuit<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.Quit, false));
    /// <inheritdoc cref="UnityManualLicenseFileSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityManualLicenseFileSettings), Property = nameof(UnityManualLicenseFileSettings.Quit))]
    public static T ToggleQuit<T>(this T o) where T : UnityManualLicenseFileSettings => o.Modify(b => b.Set(() => o.Quit, !o.Quit));
    #endregion
}
#endregion
#region UnitySettingsExtensions
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class UnitySettingsExtensions
{
    #region BuildLinux32Player
    /// <inheritdoc cref="UnitySettings.BuildLinux32Player"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildLinux32Player))]
    public static T SetBuildLinux32Player<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.BuildLinux32Player, v));
    /// <inheritdoc cref="UnitySettings.BuildLinux32Player"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildLinux32Player))]
    public static T ResetBuildLinux32Player<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.BuildLinux32Player));
    #endregion
    #region BuildLinux64Player
    /// <inheritdoc cref="UnitySettings.BuildLinux64Player"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildLinux64Player))]
    public static T SetBuildLinux64Player<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.BuildLinux64Player, v));
    /// <inheritdoc cref="UnitySettings.BuildLinux64Player"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildLinux64Player))]
    public static T ResetBuildLinux64Player<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.BuildLinux64Player));
    #endregion
    #region BuildLinuxUniversalPlayer
    /// <inheritdoc cref="UnitySettings.BuildLinuxUniversalPlayer"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildLinuxUniversalPlayer))]
    public static T SetBuildLinuxUniversalPlayer<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.BuildLinuxUniversalPlayer, v));
    /// <inheritdoc cref="UnitySettings.BuildLinuxUniversalPlayer"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildLinuxUniversalPlayer))]
    public static T ResetBuildLinuxUniversalPlayer<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.BuildLinuxUniversalPlayer));
    #endregion
    #region BuildOSXPlayer
    /// <inheritdoc cref="UnitySettings.BuildOSXPlayer"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildOSXPlayer))]
    public static T SetBuildOSXPlayer<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.BuildOSXPlayer, v));
    /// <inheritdoc cref="UnitySettings.BuildOSXPlayer"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildOSXPlayer))]
    public static T ResetBuildOSXPlayer<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.BuildOSXPlayer));
    #endregion
    #region BuildOSX64Player
    /// <inheritdoc cref="UnitySettings.BuildOSX64Player"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildOSX64Player))]
    public static T SetBuildOSX64Player<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.BuildOSX64Player, v));
    /// <inheritdoc cref="UnitySettings.BuildOSX64Player"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildOSX64Player))]
    public static T ResetBuildOSX64Player<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.BuildOSX64Player));
    #endregion
    #region BuildOSXUniversalPlayer
    /// <inheritdoc cref="UnitySettings.BuildOSXUniversalPlayer"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildOSXUniversalPlayer))]
    public static T SetBuildOSXUniversalPlayer<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.BuildOSXUniversalPlayer, v));
    /// <inheritdoc cref="UnitySettings.BuildOSXUniversalPlayer"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildOSXUniversalPlayer))]
    public static T ResetBuildOSXUniversalPlayer<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.BuildOSXUniversalPlayer));
    #endregion
    #region BuildWindowsPlayer
    /// <inheritdoc cref="UnitySettings.BuildWindowsPlayer"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildWindowsPlayer))]
    public static T SetBuildWindowsPlayer<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.BuildWindowsPlayer, v));
    /// <inheritdoc cref="UnitySettings.BuildWindowsPlayer"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildWindowsPlayer))]
    public static T ResetBuildWindowsPlayer<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.BuildWindowsPlayer));
    #endregion
    #region BuildWindows64Player
    /// <inheritdoc cref="UnitySettings.BuildWindows64Player"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildWindows64Player))]
    public static T SetBuildWindows64Player<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.BuildWindows64Player, v));
    /// <inheritdoc cref="UnitySettings.BuildWindows64Player"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BuildWindows64Player))]
    public static T ResetBuildWindows64Player<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.BuildWindows64Player));
    #endregion
    #region CreateProject
    /// <inheritdoc cref="UnitySettings.CreateProject"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.CreateProject))]
    public static T SetCreateProject<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.CreateProject, v));
    /// <inheritdoc cref="UnitySettings.CreateProject"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.CreateProject))]
    public static T ResetCreateProject<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.CreateProject));
    #endregion
    #region ExecuteMethod
    /// <inheritdoc cref="UnitySettings.ExecuteMethod"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ExecuteMethod))]
    public static T SetExecuteMethod<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.ExecuteMethod, v));
    /// <inheritdoc cref="UnitySettings.ExecuteMethod"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ExecuteMethod))]
    public static T ResetExecuteMethod<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.ExecuteMethod));
    #endregion
    #region ImportPackage
    /// <inheritdoc cref="UnitySettings.ImportPackage"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ImportPackage))]
    public static T SetImportPackage<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.ImportPackage, v));
    /// <inheritdoc cref="UnitySettings.ImportPackage"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ImportPackage))]
    public static T ResetImportPackage<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.ImportPackage));
    #endregion
    #region RunEditorTests
    /// <inheritdoc cref="UnitySettings.RunEditorTests"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.RunEditorTests))]
    public static T SetRunEditorTests<T>(this T o, bool? v) where T : UnitySettings => o.Modify(b => b.Set(() => o.RunEditorTests, v));
    /// <inheritdoc cref="UnitySettings.RunEditorTests"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.RunEditorTests))]
    public static T ResetRunEditorTests<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.RunEditorTests));
    /// <inheritdoc cref="UnitySettings.RunEditorTests"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.RunEditorTests))]
    public static T EnableRunEditorTests<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.RunEditorTests, true));
    /// <inheritdoc cref="UnitySettings.RunEditorTests"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.RunEditorTests))]
    public static T DisableRunEditorTests<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.RunEditorTests, false));
    /// <inheritdoc cref="UnitySettings.RunEditorTests"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.RunEditorTests))]
    public static T ToggleRunEditorTests<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.RunEditorTests, !o.RunEditorTests));
    #endregion
    #region EditorTestsCategories
    /// <inheritdoc cref="UnitySettings.EditorTestsCategories"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsCategories))]
    public static T SetEditorTestsCategories<T>(this T o, params string[] v) where T : UnitySettings => o.Modify(b => b.Set(() => o.EditorTestsCategories, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsCategories"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsCategories))]
    public static T SetEditorTestsCategories<T>(this T o, IEnumerable<string> v) where T : UnitySettings => o.Modify(b => b.Set(() => o.EditorTestsCategories, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsCategories"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsCategories))]
    public static T AddEditorTestsCategories<T>(this T o, params string[] v) where T : UnitySettings => o.Modify(b => b.AddCollection(() => o.EditorTestsCategories, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsCategories"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsCategories))]
    public static T AddEditorTestsCategories<T>(this T o, IEnumerable<string> v) where T : UnitySettings => o.Modify(b => b.AddCollection(() => o.EditorTestsCategories, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsCategories"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsCategories))]
    public static T RemoveEditorTestsCategories<T>(this T o, params string[] v) where T : UnitySettings => o.Modify(b => b.RemoveCollection(() => o.EditorTestsCategories, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsCategories"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsCategories))]
    public static T RemoveEditorTestsCategories<T>(this T o, IEnumerable<string> v) where T : UnitySettings => o.Modify(b => b.RemoveCollection(() => o.EditorTestsCategories, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsCategories"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsCategories))]
    public static T ClearEditorTestsCategories<T>(this T o) where T : UnitySettings => o.Modify(b => b.ClearCollection(() => o.EditorTestsCategories));
    #endregion
    #region EditorTestsFilter
    /// <inheritdoc cref="UnitySettings.EditorTestsFilter"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsFilter))]
    public static T SetEditorTestsFilter<T>(this T o, params string[] v) where T : UnitySettings => o.Modify(b => b.Set(() => o.EditorTestsFilter, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsFilter"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsFilter))]
    public static T SetEditorTestsFilter<T>(this T o, IEnumerable<string> v) where T : UnitySettings => o.Modify(b => b.Set(() => o.EditorTestsFilter, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsFilter"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsFilter))]
    public static T AddEditorTestsFilter<T>(this T o, params string[] v) where T : UnitySettings => o.Modify(b => b.AddCollection(() => o.EditorTestsFilter, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsFilter"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsFilter))]
    public static T AddEditorTestsFilter<T>(this T o, IEnumerable<string> v) where T : UnitySettings => o.Modify(b => b.AddCollection(() => o.EditorTestsFilter, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsFilter"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsFilter))]
    public static T RemoveEditorTestsFilter<T>(this T o, params string[] v) where T : UnitySettings => o.Modify(b => b.RemoveCollection(() => o.EditorTestsFilter, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsFilter"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsFilter))]
    public static T RemoveEditorTestsFilter<T>(this T o, IEnumerable<string> v) where T : UnitySettings => o.Modify(b => b.RemoveCollection(() => o.EditorTestsFilter, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsFilter"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsFilter))]
    public static T ClearEditorTestsFilter<T>(this T o) where T : UnitySettings => o.Modify(b => b.ClearCollection(() => o.EditorTestsFilter));
    #endregion
    #region EditorTestsResultFile
    /// <inheritdoc cref="UnitySettings.EditorTestsResultFile"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsResultFile))]
    public static T SetEditorTestsResultFile<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.EditorTestsResultFile, v));
    /// <inheritdoc cref="UnitySettings.EditorTestsResultFile"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.EditorTestsResultFile))]
    public static T ResetEditorTestsResultFile<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.EditorTestsResultFile));
    #endregion
    #region ExportPackage
    /// <inheritdoc cref="UnitySettings.ExportPackage"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ExportPackage))]
    public static T SetExportPackage<T>(this T o, params string[] v) where T : UnitySettings => o.Modify(b => b.Set(() => o.ExportPackage, v));
    /// <inheritdoc cref="UnitySettings.ExportPackage"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ExportPackage))]
    public static T SetExportPackage<T>(this T o, IEnumerable<string> v) where T : UnitySettings => o.Modify(b => b.Set(() => o.ExportPackage, v));
    /// <inheritdoc cref="UnitySettings.ExportPackage"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ExportPackage))]
    public static T AddExportPackage<T>(this T o, params string[] v) where T : UnitySettings => o.Modify(b => b.AddCollection(() => o.ExportPackage, v));
    /// <inheritdoc cref="UnitySettings.ExportPackage"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ExportPackage))]
    public static T AddExportPackage<T>(this T o, IEnumerable<string> v) where T : UnitySettings => o.Modify(b => b.AddCollection(() => o.ExportPackage, v));
    /// <inheritdoc cref="UnitySettings.ExportPackage"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ExportPackage))]
    public static T RemoveExportPackage<T>(this T o, params string[] v) where T : UnitySettings => o.Modify(b => b.RemoveCollection(() => o.ExportPackage, v));
    /// <inheritdoc cref="UnitySettings.ExportPackage"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ExportPackage))]
    public static T RemoveExportPackage<T>(this T o, IEnumerable<string> v) where T : UnitySettings => o.Modify(b => b.RemoveCollection(() => o.ExportPackage, v));
    /// <inheritdoc cref="UnitySettings.ExportPackage"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.ExportPackage))]
    public static T ClearExportPackage<T>(this T o) where T : UnitySettings => o.Modify(b => b.ClearCollection(() => o.ExportPackage));
    #endregion
    #region Username
    /// <inheritdoc cref="UnitySettings.Username"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="UnitySettings.Username"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Username))]
    public static T ResetUsername<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Password
    /// <inheritdoc cref="UnitySettings.Password"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="UnitySettings.Password"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Password))]
    public static T ResetPassword<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Serial
    /// <inheritdoc cref="UnitySettings.Serial"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Serial))]
    public static T SetSerial<T>(this T o, [Secret] string v) where T : UnitySettings => o.Modify(b => b.Set(() => o.Serial, v));
    /// <inheritdoc cref="UnitySettings.Serial"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Serial))]
    public static T ResetSerial<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.Serial));
    #endregion
    #region BatchMode
    /// <inheritdoc cref="UnitySettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BatchMode))]
    public static T SetBatchMode<T>(this T o, bool? v) where T : UnitySettings => o.Modify(b => b.Set(() => o.BatchMode, v));
    /// <inheritdoc cref="UnitySettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BatchMode))]
    public static T ResetBatchMode<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.BatchMode));
    /// <inheritdoc cref="UnitySettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BatchMode))]
    public static T EnableBatchMode<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.BatchMode, true));
    /// <inheritdoc cref="UnitySettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BatchMode))]
    public static T DisableBatchMode<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.BatchMode, false));
    /// <inheritdoc cref="UnitySettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.BatchMode))]
    public static T ToggleBatchMode<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.BatchMode, !o.BatchMode));
    #endregion
    #region SilentCrashes
    /// <inheritdoc cref="UnitySettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.SilentCrashes))]
    public static T SetSilentCrashes<T>(this T o, bool? v) where T : UnitySettings => o.Modify(b => b.Set(() => o.SilentCrashes, v));
    /// <inheritdoc cref="UnitySettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.SilentCrashes))]
    public static T ResetSilentCrashes<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.SilentCrashes));
    /// <inheritdoc cref="UnitySettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.SilentCrashes))]
    public static T EnableSilentCrashes<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.SilentCrashes, true));
    /// <inheritdoc cref="UnitySettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.SilentCrashes))]
    public static T DisableSilentCrashes<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.SilentCrashes, false));
    /// <inheritdoc cref="UnitySettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.SilentCrashes))]
    public static T ToggleSilentCrashes<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.SilentCrashes, !o.SilentCrashes));
    #endregion
    #region NoGraphics
    /// <inheritdoc cref="UnitySettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.NoGraphics))]
    public static T SetNoGraphics<T>(this T o, bool? v) where T : UnitySettings => o.Modify(b => b.Set(() => o.NoGraphics, v));
    /// <inheritdoc cref="UnitySettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.NoGraphics))]
    public static T ResetNoGraphics<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.NoGraphics));
    /// <inheritdoc cref="UnitySettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.NoGraphics))]
    public static T EnableNoGraphics<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.NoGraphics, true));
    /// <inheritdoc cref="UnitySettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.NoGraphics))]
    public static T DisableNoGraphics<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.NoGraphics, false));
    /// <inheritdoc cref="UnitySettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.NoGraphics))]
    public static T ToggleNoGraphics<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.NoGraphics, !o.NoGraphics));
    #endregion
    #region Quit
    /// <inheritdoc cref="UnitySettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Quit))]
    public static T SetQuit<T>(this T o, bool? v) where T : UnitySettings => o.Modify(b => b.Set(() => o.Quit, v));
    /// <inheritdoc cref="UnitySettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Quit))]
    public static T ResetQuit<T>(this T o) where T : UnitySettings => o.Modify(b => b.Remove(() => o.Quit));
    /// <inheritdoc cref="UnitySettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Quit))]
    public static T EnableQuit<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.Quit, true));
    /// <inheritdoc cref="UnitySettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Quit))]
    public static T DisableQuit<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.Quit, false));
    /// <inheritdoc cref="UnitySettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnitySettings), Property = nameof(UnitySettings.Quit))]
    public static T ToggleQuit<T>(this T o) where T : UnitySettings => o.Modify(b => b.Set(() => o.Quit, !o.Quit));
    #endregion
}
#endregion
#region UnityReturnLicenseSettingsExtensions
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class UnityReturnLicenseSettingsExtensions
{
    #region Username
    /// <inheritdoc cref="UnityReturnLicenseSettings.Username"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="UnityReturnLicenseSettings.Username"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Password
    /// <inheritdoc cref="UnityReturnLicenseSettings.Password"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="UnityReturnLicenseSettings.Password"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Serial
    /// <inheritdoc cref="UnityReturnLicenseSettings.Serial"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Serial))]
    public static T SetSerial<T>(this T o, [Secret] string v) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.Serial, v));
    /// <inheritdoc cref="UnityReturnLicenseSettings.Serial"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Serial))]
    public static T ResetSerial<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Remove(() => o.Serial));
    #endregion
    #region BatchMode
    /// <inheritdoc cref="UnityReturnLicenseSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.BatchMode))]
    public static T SetBatchMode<T>(this T o, bool? v) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.BatchMode, v));
    /// <inheritdoc cref="UnityReturnLicenseSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.BatchMode))]
    public static T ResetBatchMode<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Remove(() => o.BatchMode));
    /// <inheritdoc cref="UnityReturnLicenseSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.BatchMode))]
    public static T EnableBatchMode<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.BatchMode, true));
    /// <inheritdoc cref="UnityReturnLicenseSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.BatchMode))]
    public static T DisableBatchMode<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.BatchMode, false));
    /// <inheritdoc cref="UnityReturnLicenseSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.BatchMode))]
    public static T ToggleBatchMode<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.BatchMode, !o.BatchMode));
    #endregion
    #region SilentCrashes
    /// <inheritdoc cref="UnityReturnLicenseSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.SilentCrashes))]
    public static T SetSilentCrashes<T>(this T o, bool? v) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.SilentCrashes, v));
    /// <inheritdoc cref="UnityReturnLicenseSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.SilentCrashes))]
    public static T ResetSilentCrashes<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Remove(() => o.SilentCrashes));
    /// <inheritdoc cref="UnityReturnLicenseSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.SilentCrashes))]
    public static T EnableSilentCrashes<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.SilentCrashes, true));
    /// <inheritdoc cref="UnityReturnLicenseSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.SilentCrashes))]
    public static T DisableSilentCrashes<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.SilentCrashes, false));
    /// <inheritdoc cref="UnityReturnLicenseSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.SilentCrashes))]
    public static T ToggleSilentCrashes<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.SilentCrashes, !o.SilentCrashes));
    #endregion
    #region NoGraphics
    /// <inheritdoc cref="UnityReturnLicenseSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.NoGraphics))]
    public static T SetNoGraphics<T>(this T o, bool? v) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.NoGraphics, v));
    /// <inheritdoc cref="UnityReturnLicenseSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.NoGraphics))]
    public static T ResetNoGraphics<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Remove(() => o.NoGraphics));
    /// <inheritdoc cref="UnityReturnLicenseSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.NoGraphics))]
    public static T EnableNoGraphics<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.NoGraphics, true));
    /// <inheritdoc cref="UnityReturnLicenseSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.NoGraphics))]
    public static T DisableNoGraphics<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.NoGraphics, false));
    /// <inheritdoc cref="UnityReturnLicenseSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.NoGraphics))]
    public static T ToggleNoGraphics<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.NoGraphics, !o.NoGraphics));
    #endregion
    #region Quit
    /// <inheritdoc cref="UnityReturnLicenseSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Quit))]
    public static T SetQuit<T>(this T o, bool? v) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.Quit, v));
    /// <inheritdoc cref="UnityReturnLicenseSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Quit))]
    public static T ResetQuit<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Remove(() => o.Quit));
    /// <inheritdoc cref="UnityReturnLicenseSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Quit))]
    public static T EnableQuit<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.Quit, true));
    /// <inheritdoc cref="UnityReturnLicenseSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Quit))]
    public static T DisableQuit<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.Quit, false));
    /// <inheritdoc cref="UnityReturnLicenseSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityReturnLicenseSettings), Property = nameof(UnityReturnLicenseSettings.Quit))]
    public static T ToggleQuit<T>(this T o) where T : UnityReturnLicenseSettings => o.Modify(b => b.Set(() => o.Quit, !o.Quit));
    #endregion
}
#endregion
#region UnityRunTestsSettingsExtensions
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class UnityRunTestsSettingsExtensions
{
    #region TestCategories
    /// <inheritdoc cref="UnityRunTestsSettings.TestCategories"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestCategories))]
    public static T SetTestCategories<T>(this T o, params string[] v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.TestCategories, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestCategories"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestCategories))]
    public static T SetTestCategories<T>(this T o, IEnumerable<string> v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.TestCategories, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestCategories"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestCategories))]
    public static T AddTestCategories<T>(this T o, params string[] v) where T : UnityRunTestsSettings => o.Modify(b => b.AddCollection(() => o.TestCategories, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestCategories"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestCategories))]
    public static T AddTestCategories<T>(this T o, IEnumerable<string> v) where T : UnityRunTestsSettings => o.Modify(b => b.AddCollection(() => o.TestCategories, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestCategories"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestCategories))]
    public static T RemoveTestCategories<T>(this T o, params string[] v) where T : UnityRunTestsSettings => o.Modify(b => b.RemoveCollection(() => o.TestCategories, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestCategories"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestCategories))]
    public static T RemoveTestCategories<T>(this T o, IEnumerable<string> v) where T : UnityRunTestsSettings => o.Modify(b => b.RemoveCollection(() => o.TestCategories, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestCategories"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestCategories))]
    public static T ClearTestCategories<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.ClearCollection(() => o.TestCategories));
    #endregion
    #region TestFilters
    /// <inheritdoc cref="UnityRunTestsSettings.TestFilters"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestFilters))]
    public static T SetTestFilters<T>(this T o, params string[] v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.TestFilters, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestFilters"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestFilters))]
    public static T SetTestFilters<T>(this T o, IEnumerable<string> v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.TestFilters, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestFilters"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestFilters))]
    public static T AddTestFilters<T>(this T o, params string[] v) where T : UnityRunTestsSettings => o.Modify(b => b.AddCollection(() => o.TestFilters, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestFilters"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestFilters))]
    public static T AddTestFilters<T>(this T o, IEnumerable<string> v) where T : UnityRunTestsSettings => o.Modify(b => b.AddCollection(() => o.TestFilters, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestFilters"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestFilters))]
    public static T RemoveTestFilters<T>(this T o, params string[] v) where T : UnityRunTestsSettings => o.Modify(b => b.RemoveCollection(() => o.TestFilters, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestFilters"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestFilters))]
    public static T RemoveTestFilters<T>(this T o, IEnumerable<string> v) where T : UnityRunTestsSettings => o.Modify(b => b.RemoveCollection(() => o.TestFilters, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestFilters"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestFilters))]
    public static T ClearTestFilters<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.ClearCollection(() => o.TestFilters));
    #endregion
    #region TestResultFile
    /// <inheritdoc cref="UnityRunTestsSettings.TestResultFile"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestResultFile))]
    public static T SetTestResultFile<T>(this T o, string v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.TestResultFile, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestResultFile"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestResultFile))]
    public static T ResetTestResultFile<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Remove(() => o.TestResultFile));
    #endregion
    #region TestPlatform
    /// <inheritdoc cref="UnityRunTestsSettings.TestPlatform"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestPlatform))]
    public static T SetTestPlatform<T>(this T o, UnityTestPlatform v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.TestPlatform, v));
    /// <inheritdoc cref="UnityRunTestsSettings.TestPlatform"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.TestPlatform))]
    public static T ResetTestPlatform<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Remove(() => o.TestPlatform));
    #endregion
    #region Username
    /// <inheritdoc cref="UnityRunTestsSettings.Username"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="UnityRunTestsSettings.Username"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Password
    /// <inheritdoc cref="UnityRunTestsSettings.Password"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="UnityRunTestsSettings.Password"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Serial
    /// <inheritdoc cref="UnityRunTestsSettings.Serial"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Serial))]
    public static T SetSerial<T>(this T o, [Secret] string v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.Serial, v));
    /// <inheritdoc cref="UnityRunTestsSettings.Serial"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Serial))]
    public static T ResetSerial<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Remove(() => o.Serial));
    #endregion
    #region BatchMode
    /// <inheritdoc cref="UnityRunTestsSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.BatchMode))]
    public static T SetBatchMode<T>(this T o, bool? v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.BatchMode, v));
    /// <inheritdoc cref="UnityRunTestsSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.BatchMode))]
    public static T ResetBatchMode<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Remove(() => o.BatchMode));
    /// <inheritdoc cref="UnityRunTestsSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.BatchMode))]
    public static T EnableBatchMode<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.BatchMode, true));
    /// <inheritdoc cref="UnityRunTestsSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.BatchMode))]
    public static T DisableBatchMode<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.BatchMode, false));
    /// <inheritdoc cref="UnityRunTestsSettings.BatchMode"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.BatchMode))]
    public static T ToggleBatchMode<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.BatchMode, !o.BatchMode));
    #endregion
    #region SilentCrashes
    /// <inheritdoc cref="UnityRunTestsSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.SilentCrashes))]
    public static T SetSilentCrashes<T>(this T o, bool? v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.SilentCrashes, v));
    /// <inheritdoc cref="UnityRunTestsSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.SilentCrashes))]
    public static T ResetSilentCrashes<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Remove(() => o.SilentCrashes));
    /// <inheritdoc cref="UnityRunTestsSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.SilentCrashes))]
    public static T EnableSilentCrashes<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.SilentCrashes, true));
    /// <inheritdoc cref="UnityRunTestsSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.SilentCrashes))]
    public static T DisableSilentCrashes<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.SilentCrashes, false));
    /// <inheritdoc cref="UnityRunTestsSettings.SilentCrashes"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.SilentCrashes))]
    public static T ToggleSilentCrashes<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.SilentCrashes, !o.SilentCrashes));
    #endregion
    #region NoGraphics
    /// <inheritdoc cref="UnityRunTestsSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.NoGraphics))]
    public static T SetNoGraphics<T>(this T o, bool? v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.NoGraphics, v));
    /// <inheritdoc cref="UnityRunTestsSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.NoGraphics))]
    public static T ResetNoGraphics<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Remove(() => o.NoGraphics));
    /// <inheritdoc cref="UnityRunTestsSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.NoGraphics))]
    public static T EnableNoGraphics<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.NoGraphics, true));
    /// <inheritdoc cref="UnityRunTestsSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.NoGraphics))]
    public static T DisableNoGraphics<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.NoGraphics, false));
    /// <inheritdoc cref="UnityRunTestsSettings.NoGraphics"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.NoGraphics))]
    public static T ToggleNoGraphics<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.NoGraphics, !o.NoGraphics));
    #endregion
    #region Quit
    /// <inheritdoc cref="UnityRunTestsSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Quit))]
    public static T SetQuit<T>(this T o, bool? v) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.Quit, v));
    /// <inheritdoc cref="UnityRunTestsSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Quit))]
    public static T ResetQuit<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Remove(() => o.Quit));
    /// <inheritdoc cref="UnityRunTestsSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Quit))]
    public static T EnableQuit<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.Quit, true));
    /// <inheritdoc cref="UnityRunTestsSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Quit))]
    public static T DisableQuit<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.Quit, false));
    /// <inheritdoc cref="UnityRunTestsSettings.Quit"/>
    [Pure] [Builder(Type = typeof(UnityRunTestsSettings), Property = nameof(UnityRunTestsSettings.Quit))]
    public static T ToggleQuit<T>(this T o) where T : UnityRunTestsSettings => o.Modify(b => b.Set(() => o.Quit, !o.Quit));
    #endregion
}
#endregion
#region UnityOptionsBaseExtensions
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class UnityOptionsBaseExtensions
{
    #region LogFile
    /// <inheritdoc cref="UnityOptionsBase.LogFile"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.LogFile))]
    public static T SetLogFile<T>(this T o, string v) where T : UnityOptionsBase => o.Modify(b => b.Set(() => o.LogFile, v));
    /// <inheritdoc cref="UnityOptionsBase.LogFile"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.LogFile))]
    public static T ResetLogFile<T>(this T o) where T : UnityOptionsBase => o.Modify(b => b.Remove(() => o.LogFile));
    #endregion
    #region MinimalOutput
    /// <inheritdoc cref="UnityOptionsBase.MinimalOutput"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.MinimalOutput))]
    public static T SetMinimalOutput<T>(this T o, bool? v) where T : UnityOptionsBase => o.Modify(b => b.Set(() => o.MinimalOutput, v));
    /// <inheritdoc cref="UnityOptionsBase.MinimalOutput"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.MinimalOutput))]
    public static T ResetMinimalOutput<T>(this T o) where T : UnityOptionsBase => o.Modify(b => b.Remove(() => o.MinimalOutput));
    /// <inheritdoc cref="UnityOptionsBase.MinimalOutput"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.MinimalOutput))]
    public static T EnableMinimalOutput<T>(this T o) where T : UnityOptionsBase => o.Modify(b => b.Set(() => o.MinimalOutput, true));
    /// <inheritdoc cref="UnityOptionsBase.MinimalOutput"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.MinimalOutput))]
    public static T DisableMinimalOutput<T>(this T o) where T : UnityOptionsBase => o.Modify(b => b.Set(() => o.MinimalOutput, false));
    /// <inheritdoc cref="UnityOptionsBase.MinimalOutput"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.MinimalOutput))]
    public static T ToggleMinimalOutput<T>(this T o) where T : UnityOptionsBase => o.Modify(b => b.Set(() => o.MinimalOutput, !o.MinimalOutput));
    #endregion
    #region StableExitCodes
    /// <inheritdoc cref="UnityOptionsBase.StableExitCodes"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.StableExitCodes))]
    public static T SetStableExitCodes<T>(this T o, params int[] v) where T : UnityOptionsBase => o.Modify(b => b.Set(() => o.StableExitCodes, v));
    /// <inheritdoc cref="UnityOptionsBase.StableExitCodes"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.StableExitCodes))]
    public static T SetStableExitCodes<T>(this T o, IEnumerable<int> v) where T : UnityOptionsBase => o.Modify(b => b.Set(() => o.StableExitCodes, v));
    /// <inheritdoc cref="UnityOptionsBase.StableExitCodes"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.StableExitCodes))]
    public static T AddStableExitCodes<T>(this T o, params int[] v) where T : UnityOptionsBase => o.Modify(b => b.AddCollection(() => o.StableExitCodes, v));
    /// <inheritdoc cref="UnityOptionsBase.StableExitCodes"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.StableExitCodes))]
    public static T AddStableExitCodes<T>(this T o, IEnumerable<int> v) where T : UnityOptionsBase => o.Modify(b => b.AddCollection(() => o.StableExitCodes, v));
    /// <inheritdoc cref="UnityOptionsBase.StableExitCodes"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.StableExitCodes))]
    public static T RemoveStableExitCodes<T>(this T o, params int[] v) where T : UnityOptionsBase => o.Modify(b => b.RemoveCollection(() => o.StableExitCodes, v));
    /// <inheritdoc cref="UnityOptionsBase.StableExitCodes"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.StableExitCodes))]
    public static T RemoveStableExitCodes<T>(this T o, IEnumerable<int> v) where T : UnityOptionsBase => o.Modify(b => b.RemoveCollection(() => o.StableExitCodes, v));
    /// <inheritdoc cref="UnityOptionsBase.StableExitCodes"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.StableExitCodes))]
    public static T ClearStableExitCodes<T>(this T o) where T : UnityOptionsBase => o.Modify(b => b.ClearCollection(() => o.StableExitCodes));
    #endregion
    #region HubVersion
    /// <inheritdoc cref="UnityOptionsBase.HubVersion"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.HubVersion))]
    public static T SetHubVersion<T>(this T o, string v) where T : UnityOptionsBase => o.Modify(b => b.Set(() => o.HubVersion, v));
    /// <inheritdoc cref="UnityOptionsBase.HubVersion"/>
    [Pure] [Builder(Type = typeof(UnityOptionsBase), Property = nameof(UnityOptionsBase.HubVersion))]
    public static T ResetHubVersion<T>(this T o) where T : UnityOptionsBase => o.Modify(b => b.Remove(() => o.HubVersion));
    #endregion
}
#endregion
#region UnityProjectOptionsExtensions
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class UnityProjectOptionsExtensions
{
    #region AssetServerUpdate
    /// <inheritdoc cref="UnityProjectOptions.AssetServerUpdate"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.AssetServerUpdate))]
    public static T SetAssetServerUpdate<T>(this T o, string v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.AssetServerUpdate, v));
    /// <inheritdoc cref="UnityProjectOptions.AssetServerUpdate"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.AssetServerUpdate))]
    public static T ResetAssetServerUpdate<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.AssetServerUpdate));
    #endregion
    #region BuildTarget
    /// <inheritdoc cref="UnityProjectOptions.BuildTarget"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.BuildTarget))]
    public static T SetBuildTarget<T>(this T o, UnityBuildTarget v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.BuildTarget, v));
    /// <inheritdoc cref="UnityProjectOptions.BuildTarget"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.BuildTarget))]
    public static T ResetBuildTarget<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.BuildTarget));
    #endregion
    #region ForceD3d11
    /// <inheritdoc cref="UnityProjectOptions.ForceD3d11"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceD3d11))]
    public static T SetForceD3d11<T>(this T o, bool? v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceD3d11, v));
    /// <inheritdoc cref="UnityProjectOptions.ForceD3d11"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceD3d11))]
    public static T ResetForceD3d11<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.ForceD3d11));
    /// <inheritdoc cref="UnityProjectOptions.ForceD3d11"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceD3d11))]
    public static T EnableForceD3d11<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceD3d11, true));
    /// <inheritdoc cref="UnityProjectOptions.ForceD3d11"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceD3d11))]
    public static T DisableForceD3d11<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceD3d11, false));
    /// <inheritdoc cref="UnityProjectOptions.ForceD3d11"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceD3d11))]
    public static T ToggleForceD3d11<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceD3d11, !o.ForceD3d11));
    #endregion
    #region ForceDeviceIndex
    /// <inheritdoc cref="UnityProjectOptions.ForceDeviceIndex"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceDeviceIndex))]
    public static T SetForceDeviceIndex<T>(this T o, bool? v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceDeviceIndex, v));
    /// <inheritdoc cref="UnityProjectOptions.ForceDeviceIndex"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceDeviceIndex))]
    public static T ResetForceDeviceIndex<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.ForceDeviceIndex));
    /// <inheritdoc cref="UnityProjectOptions.ForceDeviceIndex"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceDeviceIndex))]
    public static T EnableForceDeviceIndex<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceDeviceIndex, true));
    /// <inheritdoc cref="UnityProjectOptions.ForceDeviceIndex"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceDeviceIndex))]
    public static T DisableForceDeviceIndex<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceDeviceIndex, false));
    /// <inheritdoc cref="UnityProjectOptions.ForceDeviceIndex"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceDeviceIndex))]
    public static T ToggleForceDeviceIndex<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceDeviceIndex, !o.ForceDeviceIndex));
    #endregion
    #region ForceGfxMetal
    /// <inheritdoc cref="UnityProjectOptions.ForceGfxMetal"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGfxMetal))]
    public static T SetForceGfxMetal<T>(this T o, bool? v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGfxMetal, v));
    /// <inheritdoc cref="UnityProjectOptions.ForceGfxMetal"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGfxMetal))]
    public static T ResetForceGfxMetal<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.ForceGfxMetal));
    /// <inheritdoc cref="UnityProjectOptions.ForceGfxMetal"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGfxMetal))]
    public static T EnableForceGfxMetal<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGfxMetal, true));
    /// <inheritdoc cref="UnityProjectOptions.ForceGfxMetal"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGfxMetal))]
    public static T DisableForceGfxMetal<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGfxMetal, false));
    /// <inheritdoc cref="UnityProjectOptions.ForceGfxMetal"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGfxMetal))]
    public static T ToggleForceGfxMetal<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGfxMetal, !o.ForceGfxMetal));
    #endregion
    #region ForceGLCore
    /// <inheritdoc cref="UnityProjectOptions.ForceGLCore"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLCore))]
    public static T SetForceGLCore<T>(this T o, bool? v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGLCore, v));
    /// <inheritdoc cref="UnityProjectOptions.ForceGLCore"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLCore))]
    public static T ResetForceGLCore<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.ForceGLCore));
    /// <inheritdoc cref="UnityProjectOptions.ForceGLCore"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLCore))]
    public static T EnableForceGLCore<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGLCore, true));
    /// <inheritdoc cref="UnityProjectOptions.ForceGLCore"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLCore))]
    public static T DisableForceGLCore<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGLCore, false));
    /// <inheritdoc cref="UnityProjectOptions.ForceGLCore"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLCore))]
    public static T ToggleForceGLCore<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGLCore, !o.ForceGLCore));
    #endregion
    #region ForceGLCoreXY
    /// <inheritdoc cref="UnityProjectOptions.ForceGLCoreXY"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLCoreXY))]
    public static T SetForceGLCoreXY<T>(this T o, UnityGLCore v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGLCoreXY, v));
    /// <inheritdoc cref="UnityProjectOptions.ForceGLCoreXY"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLCoreXY))]
    public static T ResetForceGLCoreXY<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.ForceGLCoreXY));
    #endregion
    #region ForceGLES
    /// <inheritdoc cref="UnityProjectOptions.ForceGLES"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLES))]
    public static T SetForceGLES<T>(this T o, bool? v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGLES, v));
    /// <inheritdoc cref="UnityProjectOptions.ForceGLES"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLES))]
    public static T ResetForceGLES<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.ForceGLES));
    /// <inheritdoc cref="UnityProjectOptions.ForceGLES"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLES))]
    public static T EnableForceGLES<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGLES, true));
    /// <inheritdoc cref="UnityProjectOptions.ForceGLES"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLES))]
    public static T DisableForceGLES<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGLES, false));
    /// <inheritdoc cref="UnityProjectOptions.ForceGLES"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLES))]
    public static T ToggleForceGLES<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGLES, !o.ForceGLES));
    #endregion
    #region ForceGLESXY
    /// <inheritdoc cref="UnityProjectOptions.ForceGLESXY"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLESXY))]
    public static T SetForceGLESXY<T>(this T o, UnityGLES v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceGLESXY, v));
    /// <inheritdoc cref="UnityProjectOptions.ForceGLESXY"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceGLESXY))]
    public static T ResetForceGLESXY<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.ForceGLESXY));
    #endregion
    #region ForceClamped
    /// <inheritdoc cref="UnityProjectOptions.ForceClamped"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceClamped))]
    public static T SetForceClamped<T>(this T o, bool? v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceClamped, v));
    /// <inheritdoc cref="UnityProjectOptions.ForceClamped"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceClamped))]
    public static T ResetForceClamped<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.ForceClamped));
    /// <inheritdoc cref="UnityProjectOptions.ForceClamped"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceClamped))]
    public static T EnableForceClamped<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceClamped, true));
    /// <inheritdoc cref="UnityProjectOptions.ForceClamped"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceClamped))]
    public static T DisableForceClamped<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceClamped, false));
    /// <inheritdoc cref="UnityProjectOptions.ForceClamped"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceClamped))]
    public static T ToggleForceClamped<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceClamped, !o.ForceClamped));
    #endregion
    #region ForceLowPowerDevice
    /// <inheritdoc cref="UnityProjectOptions.ForceLowPowerDevice"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceLowPowerDevice))]
    public static T SetForceLowPowerDevice<T>(this T o, bool? v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceLowPowerDevice, v));
    /// <inheritdoc cref="UnityProjectOptions.ForceLowPowerDevice"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceLowPowerDevice))]
    public static T ResetForceLowPowerDevice<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.ForceLowPowerDevice));
    /// <inheritdoc cref="UnityProjectOptions.ForceLowPowerDevice"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceLowPowerDevice))]
    public static T EnableForceLowPowerDevice<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceLowPowerDevice, true));
    /// <inheritdoc cref="UnityProjectOptions.ForceLowPowerDevice"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceLowPowerDevice))]
    public static T DisableForceLowPowerDevice<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceLowPowerDevice, false));
    /// <inheritdoc cref="UnityProjectOptions.ForceLowPowerDevice"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ForceLowPowerDevice))]
    public static T ToggleForceLowPowerDevice<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ForceLowPowerDevice, !o.ForceLowPowerDevice));
    #endregion
    #region DefaultPlatformTextureFormat
    /// <inheritdoc cref="UnityProjectOptions.DefaultPlatformTextureFormat"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.DefaultPlatformTextureFormat))]
    public static T SetDefaultPlatformTextureFormat<T>(this T o, string v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.DefaultPlatformTextureFormat, v));
    /// <inheritdoc cref="UnityProjectOptions.DefaultPlatformTextureFormat"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.DefaultPlatformTextureFormat))]
    public static T ResetDefaultPlatformTextureFormat<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.DefaultPlatformTextureFormat));
    #endregion
    #region DisableAssemblyUpdater
    /// <inheritdoc cref="UnityProjectOptions.DisableAssemblyUpdater"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.DisableAssemblyUpdater))]
    public static T SetDisableAssemblyUpdater<T>(this T o, params string[] v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.DisableAssemblyUpdater, v));
    /// <inheritdoc cref="UnityProjectOptions.DisableAssemblyUpdater"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.DisableAssemblyUpdater))]
    public static T SetDisableAssemblyUpdater<T>(this T o, IEnumerable<string> v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.DisableAssemblyUpdater, v));
    /// <inheritdoc cref="UnityProjectOptions.DisableAssemblyUpdater"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.DisableAssemblyUpdater))]
    public static T AddDisableAssemblyUpdater<T>(this T o, params string[] v) where T : UnityProjectOptions => o.Modify(b => b.AddCollection(() => o.DisableAssemblyUpdater, v));
    /// <inheritdoc cref="UnityProjectOptions.DisableAssemblyUpdater"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.DisableAssemblyUpdater))]
    public static T AddDisableAssemblyUpdater<T>(this T o, IEnumerable<string> v) where T : UnityProjectOptions => o.Modify(b => b.AddCollection(() => o.DisableAssemblyUpdater, v));
    /// <inheritdoc cref="UnityProjectOptions.DisableAssemblyUpdater"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.DisableAssemblyUpdater))]
    public static T RemoveDisableAssemblyUpdater<T>(this T o, params string[] v) where T : UnityProjectOptions => o.Modify(b => b.RemoveCollection(() => o.DisableAssemblyUpdater, v));
    /// <inheritdoc cref="UnityProjectOptions.DisableAssemblyUpdater"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.DisableAssemblyUpdater))]
    public static T RemoveDisableAssemblyUpdater<T>(this T o, IEnumerable<string> v) where T : UnityProjectOptions => o.Modify(b => b.RemoveCollection(() => o.DisableAssemblyUpdater, v));
    /// <inheritdoc cref="UnityProjectOptions.DisableAssemblyUpdater"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.DisableAssemblyUpdater))]
    public static T ClearDisableAssemblyUpdater<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.ClearCollection(() => o.DisableAssemblyUpdater));
    #endregion
    #region CacheServerIPAddress
    /// <inheritdoc cref="UnityProjectOptions.CacheServerIPAddress"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.CacheServerIPAddress))]
    public static T SetCacheServerIPAddress<T>(this T o, string v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.CacheServerIPAddress, v));
    /// <inheritdoc cref="UnityProjectOptions.CacheServerIPAddress"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.CacheServerIPAddress))]
    public static T ResetCacheServerIPAddress<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.CacheServerIPAddress));
    #endregion
    #region NoUpm
    /// <inheritdoc cref="UnityProjectOptions.NoUpm"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.NoUpm))]
    public static T SetNoUpm<T>(this T o, bool? v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.NoUpm, v));
    /// <inheritdoc cref="UnityProjectOptions.NoUpm"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.NoUpm))]
    public static T ResetNoUpm<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.NoUpm));
    /// <inheritdoc cref="UnityProjectOptions.NoUpm"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.NoUpm))]
    public static T EnableNoUpm<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.NoUpm, true));
    /// <inheritdoc cref="UnityProjectOptions.NoUpm"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.NoUpm))]
    public static T DisableNoUpm<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.NoUpm, false));
    /// <inheritdoc cref="UnityProjectOptions.NoUpm"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.NoUpm))]
    public static T ToggleNoUpm<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.NoUpm, !o.NoUpm));
    #endregion
    #region AcceptApiUpdate
    /// <inheritdoc cref="UnityProjectOptions.AcceptApiUpdate"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.AcceptApiUpdate))]
    public static T SetAcceptApiUpdate<T>(this T o, bool? v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.AcceptApiUpdate, v));
    /// <inheritdoc cref="UnityProjectOptions.AcceptApiUpdate"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.AcceptApiUpdate))]
    public static T ResetAcceptApiUpdate<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.AcceptApiUpdate));
    /// <inheritdoc cref="UnityProjectOptions.AcceptApiUpdate"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.AcceptApiUpdate))]
    public static T EnableAcceptApiUpdate<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.AcceptApiUpdate, true));
    /// <inheritdoc cref="UnityProjectOptions.AcceptApiUpdate"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.AcceptApiUpdate))]
    public static T DisableAcceptApiUpdate<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.AcceptApiUpdate, false));
    /// <inheritdoc cref="UnityProjectOptions.AcceptApiUpdate"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.AcceptApiUpdate))]
    public static T ToggleAcceptApiUpdate<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.AcceptApiUpdate, !o.AcceptApiUpdate));
    #endregion
    #region CustomArguments
    /// <inheritdoc cref="UnityProjectOptions.CustomArguments"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.CustomArguments))]
    public static T SetCustomArguments<T>(this T o, params string[] v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.CustomArguments, v));
    /// <inheritdoc cref="UnityProjectOptions.CustomArguments"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.CustomArguments))]
    public static T SetCustomArguments<T>(this T o, IEnumerable<string> v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.CustomArguments, v));
    /// <inheritdoc cref="UnityProjectOptions.CustomArguments"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.CustomArguments))]
    public static T AddCustomArguments<T>(this T o, params string[] v) where T : UnityProjectOptions => o.Modify(b => b.AddCollection(() => o.CustomArguments, v));
    /// <inheritdoc cref="UnityProjectOptions.CustomArguments"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.CustomArguments))]
    public static T AddCustomArguments<T>(this T o, IEnumerable<string> v) where T : UnityProjectOptions => o.Modify(b => b.AddCollection(() => o.CustomArguments, v));
    /// <inheritdoc cref="UnityProjectOptions.CustomArguments"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.CustomArguments))]
    public static T RemoveCustomArguments<T>(this T o, params string[] v) where T : UnityProjectOptions => o.Modify(b => b.RemoveCollection(() => o.CustomArguments, v));
    /// <inheritdoc cref="UnityProjectOptions.CustomArguments"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.CustomArguments))]
    public static T RemoveCustomArguments<T>(this T o, IEnumerable<string> v) where T : UnityProjectOptions => o.Modify(b => b.RemoveCollection(() => o.CustomArguments, v));
    /// <inheritdoc cref="UnityProjectOptions.CustomArguments"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.CustomArguments))]
    public static T ClearCustomArguments<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.ClearCollection(() => o.CustomArguments));
    #endregion
    #region StackTraceLogType
    /// <inheritdoc cref="UnityProjectOptions.StackTraceLogType"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.StackTraceLogType))]
    public static T SetStackTraceLogType<T>(this T o, UnityStackTraceLogType v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.StackTraceLogType, v));
    /// <inheritdoc cref="UnityProjectOptions.StackTraceLogType"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.StackTraceLogType))]
    public static T ResetStackTraceLogType<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.StackTraceLogType));
    #endregion
    #region ProjectPath
    /// <inheritdoc cref="UnityProjectOptions.ProjectPath"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ProjectPath))]
    public static T SetProjectPath<T>(this T o, string v) where T : UnityProjectOptions => o.Modify(b => b.Set(() => o.ProjectPath, v));
    /// <inheritdoc cref="UnityProjectOptions.ProjectPath"/>
    [Pure] [Builder(Type = typeof(UnityProjectOptions), Property = nameof(UnityProjectOptions.ProjectPath))]
    public static T ResetProjectPath<T>(this T o) where T : UnityProjectOptions => o.Modify(b => b.Remove(() => o.ProjectPath));
    #endregion
}
#endregion
#region UnityBuildTarget
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityBuildTarget>))]
public partial class UnityBuildTarget : Enumeration
{
    public static UnityBuildTarget Android = (UnityBuildTarget) "Android";
    public static UnityBuildTarget Bratwurst = (UnityBuildTarget) "Bratwurst";
    public static UnityBuildTarget CloudRendering = (UnityBuildTarget) "CloudRendering";
    public static UnityBuildTarget iOS = (UnityBuildTarget) "iOS";
    public static UnityBuildTarget Linux = (UnityBuildTarget) "Linux";
    public static UnityBuildTarget Linux64 = (UnityBuildTarget) "Linux64";
    public static UnityBuildTarget LinuxHeadlessSimulation = (UnityBuildTarget) "LinuxHeadlessSimulation";
    public static UnityBuildTarget LinuxUniversal = (UnityBuildTarget) "LinuxUniversal";
    public static UnityBuildTarget N3DS = (UnityBuildTarget) "N3DS";
    public static UnityBuildTarget OSXUniversal = (UnityBuildTarget) "OSXUniversal";
    public static UnityBuildTarget PS4 = (UnityBuildTarget) "PS4";
    public static UnityBuildTarget PS5 = (UnityBuildTarget) "PS5";
    public static UnityBuildTarget PSM = (UnityBuildTarget) "PSM";
    public static UnityBuildTarget PSP2 = (UnityBuildTarget) "PSP2";
    public static UnityBuildTarget SamsungTV = (UnityBuildTarget) "SamsungTV";
    public static UnityBuildTarget Stadia = (UnityBuildTarget) "Stadia";
    public static UnityBuildTarget standalone = (UnityBuildTarget) "standalone";
    public static UnityBuildTarget StandaloneLinux = (UnityBuildTarget) "StandaloneLinux";
    public static UnityBuildTarget StandaloneLinux64 = (UnityBuildTarget) "StandaloneLinux64";
    public static UnityBuildTarget StandaloneLinuxUniversal = (UnityBuildTarget) "StandaloneLinuxUniversal";
    public static UnityBuildTarget StandaloneOSX = (UnityBuildTarget) "StandaloneOSX";
    public static UnityBuildTarget StandaloneOSXIntel = (UnityBuildTarget) "StandaloneOSXIntel";
    public static UnityBuildTarget StandaloneOSXIntel64 = (UnityBuildTarget) "StandaloneOSXIntel64";
    public static UnityBuildTarget StandaloneOSXUniversal = (UnityBuildTarget) "StandaloneOSXUniversal";
    public static UnityBuildTarget StandaloneWindows = (UnityBuildTarget) "StandaloneWindows";
    public static UnityBuildTarget StandaloneWindows64 = (UnityBuildTarget) "StandaloneWindows64";
    public static UnityBuildTarget Switch = (UnityBuildTarget) "Switch";
    public static UnityBuildTarget Tizen = (UnityBuildTarget) "Tizen";
    public static UnityBuildTarget tvOS = (UnityBuildTarget) "tvOS";
    public static UnityBuildTarget WSAPlayer = (UnityBuildTarget) "WSAPlayer";
    public static UnityBuildTarget Web = (UnityBuildTarget) "Web";
    public static UnityBuildTarget WebGL = (UnityBuildTarget) "WebGL";
    public static UnityBuildTarget WebStreamed = (UnityBuildTarget) "WebStreamed";
    public static UnityBuildTarget WiiU = (UnityBuildTarget) "WiiU";
    public static UnityBuildTarget Win = (UnityBuildTarget) "Win";
    public static UnityBuildTarget Win64 = (UnityBuildTarget) "Win64";
    public static UnityBuildTarget WindowsStoreApps = (UnityBuildTarget) "WindowsStoreApps";
    public static UnityBuildTarget XboxOne = (UnityBuildTarget) "XboxOne";
    public static implicit operator UnityBuildTarget(string value)
    {
        return new UnityBuildTarget { Value = value };
    }
}
#endregion
#region UnityGLCore
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityGLCore>))]
public partial class UnityGLCore : Enumeration
{
    public static UnityGLCore _32 = (UnityGLCore) "32";
    public static UnityGLCore _33 = (UnityGLCore) "33";
    public static UnityGLCore _40 = (UnityGLCore) "40";
    public static UnityGLCore _41 = (UnityGLCore) "41";
    public static UnityGLCore _42 = (UnityGLCore) "42";
    public static UnityGLCore _43 = (UnityGLCore) "43";
    public static UnityGLCore _44 = (UnityGLCore) "44";
    public static UnityGLCore _45 = (UnityGLCore) "45";
    public static implicit operator UnityGLCore(string value)
    {
        return new UnityGLCore { Value = value };
    }
}
#endregion
#region UnityGLES
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityGLES>))]
public partial class UnityGLES : Enumeration
{
    public static UnityGLES _30 = (UnityGLES) "30";
    public static UnityGLES _31 = (UnityGLES) "31";
    public static UnityGLES _32 = (UnityGLES) "32";
    public static implicit operator UnityGLES(string value)
    {
        return new UnityGLES { Value = value };
    }
}
#endregion
#region UnityStackTraceLogType
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityStackTraceLogType>))]
public partial class UnityStackTraceLogType : Enumeration
{
    public static UnityStackTraceLogType None = (UnityStackTraceLogType) "None";
    public static UnityStackTraceLogType Script_Only = (UnityStackTraceLogType) "Script Only";
    public static UnityStackTraceLogType Full = (UnityStackTraceLogType) "Full";
    public static implicit operator UnityStackTraceLogType(string value)
    {
        return new UnityStackTraceLogType { Value = value };
    }
}
#endregion
#region UnityPlatformTextureFormat
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityPlatformTextureFormat>))]
public partial class UnityPlatformTextureFormat : Enumeration
{
    public static UnityPlatformTextureFormat dxt = (UnityPlatformTextureFormat) "dxt";
    public static UnityPlatformTextureFormat pvrtc = (UnityPlatformTextureFormat) "pvrtc";
    public static UnityPlatformTextureFormat atc = (UnityPlatformTextureFormat) "atc";
    public static UnityPlatformTextureFormat etc = (UnityPlatformTextureFormat) "etc";
    public static UnityPlatformTextureFormat etc2 = (UnityPlatformTextureFormat) "etc2";
    public static UnityPlatformTextureFormat astc = (UnityPlatformTextureFormat) "astc";
    public static implicit operator UnityPlatformTextureFormat(string value)
    {
        return new UnityPlatformTextureFormat { Value = value };
    }
}
#endregion
#region UnityTestPlatform
/// <summary>Used within <see cref="UnityTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<UnityTestPlatform>))]
public partial class UnityTestPlatform : Enumeration
{
    public static UnityTestPlatform EditMode = (UnityTestPlatform) "EditMode";
    public static UnityTestPlatform PlayMode = (UnityTestPlatform) "PlayMode";
    public static implicit operator UnityTestPlatform(string value)
    {
        return new UnityTestPlatform { Value = value };
    }
}
#endregion

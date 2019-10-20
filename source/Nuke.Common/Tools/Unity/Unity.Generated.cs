// Generated from https://github.com/nuke-build/common/blob/master/build/specifications/Unity.json

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

namespace Nuke.Common.Tools.Unity
{
    /// <summary>
    ///   <p>Unity is usually launched by double-clicking its icon from the desktop. However, it is also possible to run it from the command line (from the macOS Terminal or the Windows Command Prompt). When launched in this way, Unity can receive commands and information on startup, which can be very useful for test suites, automated builds and other production tasks.</p>
    ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class UnityTasks
    {
        /// <summary>
        ///   Path to the Unity executable.
        /// </summary>
        public static string UnityPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("UNITY_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> UnityLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Unity is usually launched by double-clicking its icon from the desktop. However, it is also possible to run it from the command line (from the macOS Terminal or the Windows Command Prompt). When launched in this way, Unity can receive commands and information on startup, which can be very useful for test suites, automated builds and other production tasks.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Unity(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(UnityPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, UnityLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>(2018.2+) Exports the currently activated license to the path of the Unity executable or either the default Unity license location, see the logs or <a href="https://docs.unity3d.com/Manual/ActivationFAQ.html">Activation FAQ</a> for more information.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-batchmode</c> via <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></li>
        ///     <li><c>-password</c> via <see cref="UnityCreateManualActivationFileSettings.Password"/></li>
        ///     <li><c>-quit</c> via <see cref="UnityCreateManualActivationFileSettings.Quit"/></li>
        ///     <li><c>-serial</c> via <see cref="UnityCreateManualActivationFileSettings.Serial"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></li>
        ///     <li><c>-username</c> via <see cref="UnityCreateManualActivationFileSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> UnityCreateManualActivationFile(UnityCreateManualActivationFileSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new UnityCreateManualActivationFileSettings();
            PreProcess(ref toolSettings);
            var process = StartProcess(toolSettings);
            AssertProcess(process, toolSettings);
            return process.Output;
        }
        /// <summary>
        ///   <p>(2018.2+) Exports the currently activated license to the path of the Unity executable or either the default Unity license location, see the logs or <a href="https://docs.unity3d.com/Manual/ActivationFAQ.html">Activation FAQ</a> for more information.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-batchmode</c> via <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></li>
        ///     <li><c>-password</c> via <see cref="UnityCreateManualActivationFileSettings.Password"/></li>
        ///     <li><c>-quit</c> via <see cref="UnityCreateManualActivationFileSettings.Quit"/></li>
        ///     <li><c>-serial</c> via <see cref="UnityCreateManualActivationFileSettings.Serial"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></li>
        ///     <li><c>-username</c> via <see cref="UnityCreateManualActivationFileSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> UnityCreateManualActivationFile(Configure<UnityCreateManualActivationFileSettings> configurator)
        {
            return UnityCreateManualActivationFile(configurator(new UnityCreateManualActivationFileSettings()));
        }
        /// <summary>
        ///   <p>(2018.2+) Exports the currently activated license to the path of the Unity executable or either the default Unity license location, see the logs or <a href="https://docs.unity3d.com/Manual/ActivationFAQ.html">Activation FAQ</a> for more information.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-batchmode</c> via <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></li>
        ///     <li><c>-password</c> via <see cref="UnityCreateManualActivationFileSettings.Password"/></li>
        ///     <li><c>-quit</c> via <see cref="UnityCreateManualActivationFileSettings.Quit"/></li>
        ///     <li><c>-serial</c> via <see cref="UnityCreateManualActivationFileSettings.Serial"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></li>
        ///     <li><c>-username</c> via <see cref="UnityCreateManualActivationFileSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(UnityCreateManualActivationFileSettings Settings, IReadOnlyCollection<Output> Output)> UnityCreateManualActivationFile(CombinatorialConfigure<UnityCreateManualActivationFileSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(UnityCreateManualActivationFile, UnityLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>(2018.2+) Activates Unity with a license file.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-batchmode</c> via <see cref="UnityManualLicenseFileSettings.BatchMode"/></li>
        ///     <li><c>-manualLicenseFile</c> via <see cref="UnityManualLicenseFileSettings.LicenseFile"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnityManualLicenseFileSettings.NoGraphics"/></li>
        ///     <li><c>-password</c> via <see cref="UnityManualLicenseFileSettings.Password"/></li>
        ///     <li><c>-quit</c> via <see cref="UnityManualLicenseFileSettings.Quit"/></li>
        ///     <li><c>-serial</c> via <see cref="UnityManualLicenseFileSettings.Serial"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></li>
        ///     <li><c>-username</c> via <see cref="UnityManualLicenseFileSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> UnityManualLicenseFile(UnityManualLicenseFileSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new UnityManualLicenseFileSettings();
            PreProcess(ref toolSettings);
            var process = StartProcess(toolSettings);
            AssertProcess(process, toolSettings);
            return process.Output;
        }
        /// <summary>
        ///   <p>(2018.2+) Activates Unity with a license file.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-batchmode</c> via <see cref="UnityManualLicenseFileSettings.BatchMode"/></li>
        ///     <li><c>-manualLicenseFile</c> via <see cref="UnityManualLicenseFileSettings.LicenseFile"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnityManualLicenseFileSettings.NoGraphics"/></li>
        ///     <li><c>-password</c> via <see cref="UnityManualLicenseFileSettings.Password"/></li>
        ///     <li><c>-quit</c> via <see cref="UnityManualLicenseFileSettings.Quit"/></li>
        ///     <li><c>-serial</c> via <see cref="UnityManualLicenseFileSettings.Serial"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></li>
        ///     <li><c>-username</c> via <see cref="UnityManualLicenseFileSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> UnityManualLicenseFile(Configure<UnityManualLicenseFileSettings> configurator)
        {
            return UnityManualLicenseFile(configurator(new UnityManualLicenseFileSettings()));
        }
        /// <summary>
        ///   <p>(2018.2+) Activates Unity with a license file.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-batchmode</c> via <see cref="UnityManualLicenseFileSettings.BatchMode"/></li>
        ///     <li><c>-manualLicenseFile</c> via <see cref="UnityManualLicenseFileSettings.LicenseFile"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnityManualLicenseFileSettings.NoGraphics"/></li>
        ///     <li><c>-password</c> via <see cref="UnityManualLicenseFileSettings.Password"/></li>
        ///     <li><c>-quit</c> via <see cref="UnityManualLicenseFileSettings.Quit"/></li>
        ///     <li><c>-serial</c> via <see cref="UnityManualLicenseFileSettings.Serial"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></li>
        ///     <li><c>-username</c> via <see cref="UnityManualLicenseFileSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(UnityManualLicenseFileSettings Settings, IReadOnlyCollection<Output> Output)> UnityManualLicenseFile(CombinatorialConfigure<UnityManualLicenseFileSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(UnityManualLicenseFile, UnityLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Execute Unity.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;customArguments&gt;</c> via <see cref="UnitySettings.CustomArguments"/></li>
        ///     <li><c>-accept-apiupdate</c> via <see cref="UnitySettings.AcceptApiUpdate"/></li>
        ///     <li><c>-assetServerUpdate</c> via <see cref="UnitySettings.AssetServerUpdate"/></li>
        ///     <li><c>-batchmode</c> via <see cref="UnitySettings.BatchMode"/></li>
        ///     <li><c>-buildLinux32Player</c> via <see cref="UnitySettings.BuildLinux32Player"/></li>
        ///     <li><c>-buildLinux64Player</c> via <see cref="UnitySettings.BuildLinux64Player"/></li>
        ///     <li><c>-buildLinuxUniversalPlayer</c> via <see cref="UnitySettings.BuildLinuxUniversalPlayer"/></li>
        ///     <li><c>-buildOSX64Player</c> via <see cref="UnitySettings.BuildOSX64Player"/></li>
        ///     <li><c>-buildOSXPlayer</c> via <see cref="UnitySettings.BuildOSXPlayer"/></li>
        ///     <li><c>-buildOSXUniversalPlayer</c> via <see cref="UnitySettings.BuildOSXUniversalPlayer"/></li>
        ///     <li><c>-buildTarget</c> via <see cref="UnitySettings.BuildTarget"/></li>
        ///     <li><c>-buildWindows64Player</c> via <see cref="UnitySettings.BuildWindows64Player"/></li>
        ///     <li><c>-buildWindowsPlayer</c> via <see cref="UnitySettings.BuildWindowsPlayer"/></li>
        ///     <li><c>-cacheServerIPAddress</c> via <see cref="UnitySettings.CacheServerIPAddress"/></li>
        ///     <li><c>-createProject</c> via <see cref="UnitySettings.CreateProject"/></li>
        ///     <li><c>-disable-assembly-updater</c> via <see cref="UnitySettings.DisableAssemblyUpdater"/></li>
        ///     <li><c>-editorTestsCategories</c> via <see cref="UnitySettings.EditorTestsCategories"/></li>
        ///     <li><c>-editorTestsFilter</c> via <see cref="UnitySettings.EditorTestsFilter"/></li>
        ///     <li><c>-editorTestsResultFile</c> via <see cref="UnitySettings.EditorTestsResultFile"/></li>
        ///     <li><c>-executeMethod</c> via <see cref="UnitySettings.ExecuteMethod"/></li>
        ///     <li><c>-exportPackage</c> via <see cref="UnitySettings.ExportPackage"/></li>
        ///     <li><c>-force-clamped</c> via <see cref="UnitySettings.ForceClamped"/></li>
        ///     <li><c>-force-d3d11</c> via <see cref="UnitySettings.ForceD3d11"/></li>
        ///     <li><c>-force-device-index</c> via <see cref="UnitySettings.ForceDeviceIndex"/></li>
        ///     <li><c>-force-gfx-metal</c> via <see cref="UnitySettings.ForceGfxMetal"/></li>
        ///     <li><c>-force-glcore</c> via <see cref="UnitySettings.ForceGLCore"/></li>
        ///     <li><c>-force-glcore</c> via <see cref="UnitySettings.ForceGLCoreXY"/></li>
        ///     <li><c>-force-gles</c> via <see cref="UnitySettings.ForceGLES"/></li>
        ///     <li><c>-force-gles</c> via <see cref="UnitySettings.ForceGLESXY"/></li>
        ///     <li><c>-force-low-power-device</c> via <see cref="UnitySettings.ForceLowPowerDevice"/></li>
        ///     <li><c>-importPackage</c> via <see cref="UnitySettings.ImportPackage"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnitySettings.NoGraphics"/></li>
        ///     <li><c>-noUpm</c> via <see cref="UnitySettings.NoUpm"/></li>
        ///     <li><c>-password</c> via <see cref="UnitySettings.Password"/></li>
        ///     <li><c>-projectPath</c> via <see cref="UnitySettings.ProjectPath"/></li>
        ///     <li><c>-quit</c> via <see cref="UnitySettings.Quit"/></li>
        ///     <li><c>-runEditorTests</c> via <see cref="UnitySettings.RunEditorTests"/></li>
        ///     <li><c>-serial</c> via <see cref="UnitySettings.Serial"/></li>
        ///     <li><c>-setDefaultPlatformTextureFormat</c> via <see cref="UnitySettings.DefaultPlatformTextureFormat"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnitySettings.SilentCrashes"/></li>
        ///     <li><c>-stackTraceLogType</c> via <see cref="UnitySettings.StackTraceLogType"/></li>
        ///     <li><c>-username</c> via <see cref="UnitySettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Unity(UnitySettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new UnitySettings();
            PreProcess(ref toolSettings);
            var process = StartProcess(toolSettings);
            AssertProcess(process, toolSettings);
            return process.Output;
        }
        /// <summary>
        ///   <p>Execute Unity.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;customArguments&gt;</c> via <see cref="UnitySettings.CustomArguments"/></li>
        ///     <li><c>-accept-apiupdate</c> via <see cref="UnitySettings.AcceptApiUpdate"/></li>
        ///     <li><c>-assetServerUpdate</c> via <see cref="UnitySettings.AssetServerUpdate"/></li>
        ///     <li><c>-batchmode</c> via <see cref="UnitySettings.BatchMode"/></li>
        ///     <li><c>-buildLinux32Player</c> via <see cref="UnitySettings.BuildLinux32Player"/></li>
        ///     <li><c>-buildLinux64Player</c> via <see cref="UnitySettings.BuildLinux64Player"/></li>
        ///     <li><c>-buildLinuxUniversalPlayer</c> via <see cref="UnitySettings.BuildLinuxUniversalPlayer"/></li>
        ///     <li><c>-buildOSX64Player</c> via <see cref="UnitySettings.BuildOSX64Player"/></li>
        ///     <li><c>-buildOSXPlayer</c> via <see cref="UnitySettings.BuildOSXPlayer"/></li>
        ///     <li><c>-buildOSXUniversalPlayer</c> via <see cref="UnitySettings.BuildOSXUniversalPlayer"/></li>
        ///     <li><c>-buildTarget</c> via <see cref="UnitySettings.BuildTarget"/></li>
        ///     <li><c>-buildWindows64Player</c> via <see cref="UnitySettings.BuildWindows64Player"/></li>
        ///     <li><c>-buildWindowsPlayer</c> via <see cref="UnitySettings.BuildWindowsPlayer"/></li>
        ///     <li><c>-cacheServerIPAddress</c> via <see cref="UnitySettings.CacheServerIPAddress"/></li>
        ///     <li><c>-createProject</c> via <see cref="UnitySettings.CreateProject"/></li>
        ///     <li><c>-disable-assembly-updater</c> via <see cref="UnitySettings.DisableAssemblyUpdater"/></li>
        ///     <li><c>-editorTestsCategories</c> via <see cref="UnitySettings.EditorTestsCategories"/></li>
        ///     <li><c>-editorTestsFilter</c> via <see cref="UnitySettings.EditorTestsFilter"/></li>
        ///     <li><c>-editorTestsResultFile</c> via <see cref="UnitySettings.EditorTestsResultFile"/></li>
        ///     <li><c>-executeMethod</c> via <see cref="UnitySettings.ExecuteMethod"/></li>
        ///     <li><c>-exportPackage</c> via <see cref="UnitySettings.ExportPackage"/></li>
        ///     <li><c>-force-clamped</c> via <see cref="UnitySettings.ForceClamped"/></li>
        ///     <li><c>-force-d3d11</c> via <see cref="UnitySettings.ForceD3d11"/></li>
        ///     <li><c>-force-device-index</c> via <see cref="UnitySettings.ForceDeviceIndex"/></li>
        ///     <li><c>-force-gfx-metal</c> via <see cref="UnitySettings.ForceGfxMetal"/></li>
        ///     <li><c>-force-glcore</c> via <see cref="UnitySettings.ForceGLCore"/></li>
        ///     <li><c>-force-glcore</c> via <see cref="UnitySettings.ForceGLCoreXY"/></li>
        ///     <li><c>-force-gles</c> via <see cref="UnitySettings.ForceGLES"/></li>
        ///     <li><c>-force-gles</c> via <see cref="UnitySettings.ForceGLESXY"/></li>
        ///     <li><c>-force-low-power-device</c> via <see cref="UnitySettings.ForceLowPowerDevice"/></li>
        ///     <li><c>-importPackage</c> via <see cref="UnitySettings.ImportPackage"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnitySettings.NoGraphics"/></li>
        ///     <li><c>-noUpm</c> via <see cref="UnitySettings.NoUpm"/></li>
        ///     <li><c>-password</c> via <see cref="UnitySettings.Password"/></li>
        ///     <li><c>-projectPath</c> via <see cref="UnitySettings.ProjectPath"/></li>
        ///     <li><c>-quit</c> via <see cref="UnitySettings.Quit"/></li>
        ///     <li><c>-runEditorTests</c> via <see cref="UnitySettings.RunEditorTests"/></li>
        ///     <li><c>-serial</c> via <see cref="UnitySettings.Serial"/></li>
        ///     <li><c>-setDefaultPlatformTextureFormat</c> via <see cref="UnitySettings.DefaultPlatformTextureFormat"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnitySettings.SilentCrashes"/></li>
        ///     <li><c>-stackTraceLogType</c> via <see cref="UnitySettings.StackTraceLogType"/></li>
        ///     <li><c>-username</c> via <see cref="UnitySettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Unity(Configure<UnitySettings> configurator)
        {
            return Unity(configurator(new UnitySettings()));
        }
        /// <summary>
        ///   <p>Execute Unity.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;customArguments&gt;</c> via <see cref="UnitySettings.CustomArguments"/></li>
        ///     <li><c>-accept-apiupdate</c> via <see cref="UnitySettings.AcceptApiUpdate"/></li>
        ///     <li><c>-assetServerUpdate</c> via <see cref="UnitySettings.AssetServerUpdate"/></li>
        ///     <li><c>-batchmode</c> via <see cref="UnitySettings.BatchMode"/></li>
        ///     <li><c>-buildLinux32Player</c> via <see cref="UnitySettings.BuildLinux32Player"/></li>
        ///     <li><c>-buildLinux64Player</c> via <see cref="UnitySettings.BuildLinux64Player"/></li>
        ///     <li><c>-buildLinuxUniversalPlayer</c> via <see cref="UnitySettings.BuildLinuxUniversalPlayer"/></li>
        ///     <li><c>-buildOSX64Player</c> via <see cref="UnitySettings.BuildOSX64Player"/></li>
        ///     <li><c>-buildOSXPlayer</c> via <see cref="UnitySettings.BuildOSXPlayer"/></li>
        ///     <li><c>-buildOSXUniversalPlayer</c> via <see cref="UnitySettings.BuildOSXUniversalPlayer"/></li>
        ///     <li><c>-buildTarget</c> via <see cref="UnitySettings.BuildTarget"/></li>
        ///     <li><c>-buildWindows64Player</c> via <see cref="UnitySettings.BuildWindows64Player"/></li>
        ///     <li><c>-buildWindowsPlayer</c> via <see cref="UnitySettings.BuildWindowsPlayer"/></li>
        ///     <li><c>-cacheServerIPAddress</c> via <see cref="UnitySettings.CacheServerIPAddress"/></li>
        ///     <li><c>-createProject</c> via <see cref="UnitySettings.CreateProject"/></li>
        ///     <li><c>-disable-assembly-updater</c> via <see cref="UnitySettings.DisableAssemblyUpdater"/></li>
        ///     <li><c>-editorTestsCategories</c> via <see cref="UnitySettings.EditorTestsCategories"/></li>
        ///     <li><c>-editorTestsFilter</c> via <see cref="UnitySettings.EditorTestsFilter"/></li>
        ///     <li><c>-editorTestsResultFile</c> via <see cref="UnitySettings.EditorTestsResultFile"/></li>
        ///     <li><c>-executeMethod</c> via <see cref="UnitySettings.ExecuteMethod"/></li>
        ///     <li><c>-exportPackage</c> via <see cref="UnitySettings.ExportPackage"/></li>
        ///     <li><c>-force-clamped</c> via <see cref="UnitySettings.ForceClamped"/></li>
        ///     <li><c>-force-d3d11</c> via <see cref="UnitySettings.ForceD3d11"/></li>
        ///     <li><c>-force-device-index</c> via <see cref="UnitySettings.ForceDeviceIndex"/></li>
        ///     <li><c>-force-gfx-metal</c> via <see cref="UnitySettings.ForceGfxMetal"/></li>
        ///     <li><c>-force-glcore</c> via <see cref="UnitySettings.ForceGLCore"/></li>
        ///     <li><c>-force-glcore</c> via <see cref="UnitySettings.ForceGLCoreXY"/></li>
        ///     <li><c>-force-gles</c> via <see cref="UnitySettings.ForceGLES"/></li>
        ///     <li><c>-force-gles</c> via <see cref="UnitySettings.ForceGLESXY"/></li>
        ///     <li><c>-force-low-power-device</c> via <see cref="UnitySettings.ForceLowPowerDevice"/></li>
        ///     <li><c>-importPackage</c> via <see cref="UnitySettings.ImportPackage"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnitySettings.NoGraphics"/></li>
        ///     <li><c>-noUpm</c> via <see cref="UnitySettings.NoUpm"/></li>
        ///     <li><c>-password</c> via <see cref="UnitySettings.Password"/></li>
        ///     <li><c>-projectPath</c> via <see cref="UnitySettings.ProjectPath"/></li>
        ///     <li><c>-quit</c> via <see cref="UnitySettings.Quit"/></li>
        ///     <li><c>-runEditorTests</c> via <see cref="UnitySettings.RunEditorTests"/></li>
        ///     <li><c>-serial</c> via <see cref="UnitySettings.Serial"/></li>
        ///     <li><c>-setDefaultPlatformTextureFormat</c> via <see cref="UnitySettings.DefaultPlatformTextureFormat"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnitySettings.SilentCrashes"/></li>
        ///     <li><c>-stackTraceLogType</c> via <see cref="UnitySettings.StackTraceLogType"/></li>
        ///     <li><c>-username</c> via <see cref="UnitySettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(UnitySettings Settings, IReadOnlyCollection<Output> Output)> Unity(CombinatorialConfigure<UnitySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(Unity, UnityLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Return the currenlty activated Unity license.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-batchmode</c> via <see cref="UnityReturnLicenseSettings.BatchMode"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnityReturnLicenseSettings.NoGraphics"/></li>
        ///     <li><c>-password</c> via <see cref="UnityReturnLicenseSettings.Password"/></li>
        ///     <li><c>-quit</c> via <see cref="UnityReturnLicenseSettings.Quit"/></li>
        ///     <li><c>-serial</c> via <see cref="UnityReturnLicenseSettings.Serial"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnityReturnLicenseSettings.SilentCrashes"/></li>
        ///     <li><c>-username</c> via <see cref="UnityReturnLicenseSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> UnityReturnLicense(UnityReturnLicenseSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new UnityReturnLicenseSettings();
            PreProcess(ref toolSettings);
            var process = StartProcess(toolSettings);
            AssertProcess(process, toolSettings);
            return process.Output;
        }
        /// <summary>
        ///   <p>Return the currenlty activated Unity license.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-batchmode</c> via <see cref="UnityReturnLicenseSettings.BatchMode"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnityReturnLicenseSettings.NoGraphics"/></li>
        ///     <li><c>-password</c> via <see cref="UnityReturnLicenseSettings.Password"/></li>
        ///     <li><c>-quit</c> via <see cref="UnityReturnLicenseSettings.Quit"/></li>
        ///     <li><c>-serial</c> via <see cref="UnityReturnLicenseSettings.Serial"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnityReturnLicenseSettings.SilentCrashes"/></li>
        ///     <li><c>-username</c> via <see cref="UnityReturnLicenseSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> UnityReturnLicense(Configure<UnityReturnLicenseSettings> configurator)
        {
            return UnityReturnLicense(configurator(new UnityReturnLicenseSettings()));
        }
        /// <summary>
        ///   <p>Return the currenlty activated Unity license.</p>
        ///   <p>For more details, visit the <a href="https://unity3d.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-batchmode</c> via <see cref="UnityReturnLicenseSettings.BatchMode"/></li>
        ///     <li><c>-nographics</c> via <see cref="UnityReturnLicenseSettings.NoGraphics"/></li>
        ///     <li><c>-password</c> via <see cref="UnityReturnLicenseSettings.Password"/></li>
        ///     <li><c>-quit</c> via <see cref="UnityReturnLicenseSettings.Quit"/></li>
        ///     <li><c>-serial</c> via <see cref="UnityReturnLicenseSettings.Serial"/></li>
        ///     <li><c>-silent-crashes</c> via <see cref="UnityReturnLicenseSettings.SilentCrashes"/></li>
        ///     <li><c>-username</c> via <see cref="UnityReturnLicenseSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(UnityReturnLicenseSettings Settings, IReadOnlyCollection<Output> Output)> UnityReturnLicense(CombinatorialConfigure<UnityReturnLicenseSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(UnityReturnLicense, UnityLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region UnityCreateManualActivationFileSettings
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class UnityCreateManualActivationFileSettings : UnityBaseSettings
    {
        /// <summary>
        ///   Path to the Unity executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => UnityTasks.UnityLogger;
        /// <summary>
        ///   Enter a username into the log-in form during activation of the Unity Editor.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Enter a password into the log-in form during activation of the Unity Editor.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.
        /// </summary>
        public virtual string Serial { get; internal set; }
        /// <summary>
        ///   Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.
        /// </summary>
        public virtual bool? BatchMode { get; internal set; }
        /// <summary>
        ///   Don't display a crash dialog.
        /// </summary>
        public virtual bool? SilentCrashes { get; internal set; }
        /// <summary>
        ///   When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.
        /// </summary>
        public virtual bool? NoGraphics { get; internal set; }
        /// <summary>
        ///   Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).
        /// </summary>
        public virtual bool? Quit { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-createManualActivationFile")
              .Add("-username {value}", Username)
              .Add("-password {value}", Password, secret: true)
              .Add("-serial {value}", Serial, secret: true)
              .Add("-batchmode", BatchMode)
              .Add("-silent-crashes", SilentCrashes)
              .Add("-nographics", NoGraphics)
              .Add("-quit", Quit);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region UnityManualLicenseFileSettings
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class UnityManualLicenseFileSettings : UnityBaseSettings
    {
        /// <summary>
        ///   Path to the Unity executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => UnityTasks.UnityLogger;
        /// <summary>
        ///   The path to the license file.
        /// </summary>
        public virtual string LicenseFile { get; internal set; }
        /// <summary>
        ///   Enter a username into the log-in form during activation of the Unity Editor.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Enter a password into the log-in form during activation of the Unity Editor.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.
        /// </summary>
        public virtual string Serial { get; internal set; }
        /// <summary>
        ///   Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.
        /// </summary>
        public virtual bool? BatchMode { get; internal set; }
        /// <summary>
        ///   Don't display a crash dialog.
        /// </summary>
        public virtual bool? SilentCrashes { get; internal set; }
        /// <summary>
        ///   When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.
        /// </summary>
        public virtual bool? NoGraphics { get; internal set; }
        /// <summary>
        ///   Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).
        /// </summary>
        public virtual bool? Quit { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-manualLicenseFile {value}", LicenseFile)
              .Add("-username {value}", Username)
              .Add("-password {value}", Password, secret: true)
              .Add("-serial {value}", Serial, secret: true)
              .Add("-batchmode", BatchMode)
              .Add("-silent-crashes", SilentCrashes)
              .Add("-nographics", NoGraphics)
              .Add("-quit", Quit);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region UnitySettings
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class UnitySettings : UnityBaseSettings
    {
        /// <summary>
        ///   Path to the Unity executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => UnityTasks.UnityLogger;
        /// <summary>
        ///   Force an update of the project in the <a href="https://docs.unity3d.com/Manual/AssetServer.html">Asset Server</a> given by <c>IP:port</c>. The port is optional, and if not given it is assumed to be the standard one (10733). It is advisable to use this command in conjunction with the <c>-projectPath</c> argument to ensure you are working with the correct project. If no project name is given, then the last project opened by Unity is used. If no project exists at the path given by <c>-projectPath</c>, then one is created automatically.
        /// </summary>
        public virtual string AssetServerUpdate { get; internal set; }
        /// <summary>
        ///   Build a 32-bit standalone Linux player (for example, <c>-buildLinux32Player path/to/your/build</c>).
        /// </summary>
        public virtual string BuildLinux32Player { get; internal set; }
        /// <summary>
        ///   Build a 64-bit standalone Linux player (for example, <c>-buildLinux64Player path/to/your/build</c>).
        /// </summary>
        public virtual string BuildLinux64Player { get; internal set; }
        /// <summary>
        ///   Build a combined 32-bit and 64-bit standalone Linux player (for example, <c>-buildLinuxUniversalPlayer path/to/your/build</c>).
        /// </summary>
        public virtual string BuildLinuxUniversalPlayer { get; internal set; }
        /// <summary>
        ///   Build a 32-bit standalone Mac OSX player (for example, <c>-buildOSXPlayer path/to/your/build.app</c>).
        /// </summary>
        public virtual string BuildOSXPlayer { get; internal set; }
        /// <summary>
        ///   Build a 64-bit standalone Mac OSX player (for example, <c>-buildOSX64Player path/to/your/build.app</c>).
        /// </summary>
        public virtual string BuildOSX64Player { get; internal set; }
        /// <summary>
        ///   Build a combined 32-bit and 64-bit standalone Mac OSX player (for example, <c>-buildOSXUniversalPlayer path/to/your/build.app</c>).
        /// </summary>
        public virtual string BuildOSXUniversalPlayer { get; internal set; }
        /// <summary>
        ///   Allows the selection of an active build target before a project is loaded.
        /// </summary>
        public virtual string BuildTarget { get; internal set; }
        /// <summary>
        ///   Build a 32-bit standalone Windows player (for example, <c>-buildWindowsPlayer path/to/your/build.exe</c>).
        /// </summary>
        public virtual string BuildWindowsPlayer { get; internal set; }
        /// <summary>
        ///   Build a 64-bit standalone Windows player (for example, <c>-buildWindows64Player path/to/your/build.exe</c>).
        /// </summary>
        public virtual string BuildWindows64Player { get; internal set; }
        /// <summary>
        ///   Create an empty project at the given path.
        /// </summary>
        public virtual string CreateProject { get; internal set; }
        /// <summary>
        ///   Execute the static method as soon as Unity is started, the project is open and after the optional Asset server update has been performed. This can be used to do tasks such as continous integration, performing Unit Tests, making builds or preparing data. To return an error from the command line process, either throw an exception which causes Unity to exit with return code <b>1</b>, or call <a href="https:/docs.unity3d.com/ScriptReference/EditorApplication.Exit.html">EditorApplication.Exit</a> with a non-zero return code.To use <b>ExecuteMethod</b>, you need to place the enclosing script in an Editor folder. The method to be executed must be defined as <c>static</c>.
        /// </summary>
        public virtual string ExecuteMethod { get; internal set; }
        /// <summary>
        ///   (Windows only) Make the Editor use Direct3D 11 for rendering. Normally the graphics API depends on player settings (typically defaults to D3D11).
        /// </summary>
        public virtual bool? ForceD3d11 { get; internal set; }
        /// <summary>
        ///   (macOS only) When using Metal, make the Editor use a particular GPU device by passing it the index of that GPU.
        /// </summary>
        public virtual bool? ForceDeviceIndex { get; internal set; }
        /// <summary>
        ///   (macOS only) Make the Editor use Metal as the default graphics API.
        /// </summary>
        public virtual bool? ForceGfxMetal { get; internal set; }
        /// <summary>
        ///   (Windows only) Make the Editor use OpenGL 3/4 core profile for rendering. The Editor tries to use the best OpenGL version available and all OpenGL extensions exposed by the OpenGL drivers. If the platform isn't supported, Direct3D is used.
        /// </summary>
        public virtual bool? ForceGLCore { get; internal set; }
        /// <summary>
        ///   (Windows only) Similar to <c>-force-glcore</c>, but requests a specific OpenGL context version. Accepted values for XY: 32, 33, 40, 41, 42, 43, 44 or 45.
        /// </summary>
        public virtual UnityGLCore ForceGLCoreXY { get; internal set; }
        /// <summary>
        ///   (Windows only) Make the Editor use OpenGL for Embedded Systems for rendering. The Editor tries to use the best OpenGL ES version available, and all OpenGL ES extensions exposed by the OpenGL drivers.
        /// </summary>
        public virtual bool? ForceGLES { get; internal set; }
        /// <summary>
        ///   (Windows only) Similar to <c>-force-gles</c>, but requests a specific OpenGL ES context version. Accepted values for XY: 30, 31 or 32.
        /// </summary>
        public virtual UnityGLES ForceGLESXY { get; internal set; }
        /// <summary>
        ///   (2017.3+) (Windows only) Used with <c>-force-glcoreXY</c> to prevent checking for additional OpenGL extensions, allowing it to run between platforms with the same code paths.
        /// </summary>
        public virtual bool? ForceClamped { get; internal set; }
        /// <summary>
        ///   (macOS only) When using Metal, make the Editor use a low power device.
        /// </summary>
        public virtual bool? ForceLowPowerDevice { get; internal set; }
        /// <summary>
        ///   Import the given <a href="https://docs.unity3d.com/Manual/HOWTO-exportpackage.html">package</a>. No import dialog is shown.
        /// </summary>
        public virtual string ImportPackage { get; internal set; }
        /// <summary>
        ///   (2018.1+) Sets the default texture compression to the desired format before importing a texture or building the project. This is so you don’t have to import the texture again with the format you want. The available formats are dxt, pvrtc, atc, etc, etc2, and astc. Note that this is only supported on Android.
        /// </summary>
        public virtual string DefaultPlatformTextureFormat { get; internal set; }
        /// <summary>
        ///   Specify a space-separated list of assembly names as parameters for Unity to ignore on automatic updates. The space-separated list of assembly names is optional: Pass the command line options without any assembly names to ignore all assemblies.
        /// </summary>
        public virtual IReadOnlyList<string> DisableAssemblyUpdater => DisableAssemblyUpdaterInternal.AsReadOnly();
        internal List<string> DisableAssemblyUpdaterInternal { get; set; } = new List<string>();
        /// <summary>
        ///   (2018.1+) Connect to the Cache Server given by <c>IP:port</c> on startup, overriding any configuration stored in the Editor Preferences. Use this to connect multiple instances of Unity to different Cache Servers.
        /// </summary>
        public virtual string CacheServerIPAddress { get; internal set; }
        /// <summary>
        ///   (2018.1+) Disables the Unity Package Manager.
        /// </summary>
        public virtual bool? NoUpm { get; internal set; }
        /// <summary>
        ///   (2017.2+) Use this command line option to specify that APIUpdater should run when Unity is launched in batch mode. Omitting this command line argument when launching Unity in batch mode results in APIUpdater not running which can lead to compiler errors. Note that in versions prior to 2017.2 there’s no way to not run APIUpdater when Unity is launched in batch mode.
        /// </summary>
        public virtual bool? AcceptApiUpdate { get; internal set; }
        /// <summary>
        ///   Run Editor tests from the project. This argument requires the <c>projectPath</c>, and it’s good practice to run it with <c>batchmode</c> argument. <c>quit</c> is not required, because the Editor automatically closes down after the run is finished.
        /// </summary>
        public virtual bool? RunEditorTests { get; internal set; }
        /// <summary>
        ///   Filter editor tests by categories.
        /// </summary>
        public virtual IReadOnlyList<string> EditorTestsCategories => EditorTestsCategoriesInternal.AsReadOnly();
        internal List<string> EditorTestsCategoriesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Filter editor tests by names.
        /// </summary>
        public virtual IReadOnlyList<string> EditorTestsFilter => EditorTestsFilterInternal.AsReadOnly();
        internal List<string> EditorTestsFilterInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Path where the result file should be placed. If the path is a folder, a default file name is used. If not specified, the results are placed in the project's root folder.
        /// </summary>
        public virtual string EditorTestsResultFile { get; internal set; }
        /// <summary>
        ///   Export a package, given a path (or set of given paths).<c>-exportPackage &lt;exportAssetPath&gt; &lt;exportFileName&gt;</c> In this example exportAssetPath is a folder (relative to to the Unity project root) to export from the Unity project, and exportFileName is the package name. Currently, this option only exports whole folders at a time. You normally need to use this command with the -projectPath argument.
        /// </summary>
        public virtual IReadOnlyList<string> ExportPackage => ExportPackageInternal.AsReadOnly();
        internal List<string> ExportPackageInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Custom parameters. To pass parameters, add them to the command line and retrieve them inside the function using <c>System.Environment.GetCommandLineArgs</c>. 
        /// </summary>
        public virtual IReadOnlyList<string> CustomArguments => CustomArgumentsInternal.AsReadOnly();
        internal List<string> CustomArgumentsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Detailed debugging feature. StackTraceLogging allows you to allow detailed logging.
        /// </summary>
        public virtual UnityStackTraceLogType StackTraceLogType { get; internal set; }
        /// <summary>
        ///   Specify the path of the unity project.
        /// </summary>
        public virtual string ProjectPath { get; internal set; }
        /// <summary>
        ///   Enter a username into the log-in form during activation of the Unity Editor.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Enter a password into the log-in form during activation of the Unity Editor.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.
        /// </summary>
        public virtual string Serial { get; internal set; }
        /// <summary>
        ///   Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.
        /// </summary>
        public virtual bool? BatchMode { get; internal set; }
        /// <summary>
        ///   Don't display a crash dialog.
        /// </summary>
        public virtual bool? SilentCrashes { get; internal set; }
        /// <summary>
        ///   When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.
        /// </summary>
        public virtual bool? NoGraphics { get; internal set; }
        /// <summary>
        ///   Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).
        /// </summary>
        public virtual bool? Quit { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-assetServerUpdate {value}", AssetServerUpdate)
              .Add("-buildLinux32Player {value}", BuildLinux32Player)
              .Add("-buildLinux64Player {value}", BuildLinux64Player)
              .Add("-buildLinuxUniversalPlayer {value}", BuildLinuxUniversalPlayer)
              .Add("-buildOSXPlayer {value}", BuildOSXPlayer)
              .Add("-buildOSX64Player {value}", BuildOSX64Player)
              .Add("-buildOSXUniversalPlayer {value}", BuildOSXUniversalPlayer)
              .Add("-buildTarget {value}", BuildTarget)
              .Add("-buildWindowsPlayer {value}", BuildWindowsPlayer)
              .Add("-buildWindows64Player {value}", BuildWindows64Player)
              .Add("-createProject {value}", CreateProject)
              .Add("-executeMethod {value}", ExecuteMethod)
              .Add("-force-d3d11", ForceD3d11)
              .Add("-force-device-index", ForceDeviceIndex)
              .Add("-force-gfx-metal", ForceGfxMetal)
              .Add("-force-glcore", ForceGLCore)
              .Add("-force-glcore{value}", ForceGLCoreXY)
              .Add("-force-gles", ForceGLES)
              .Add("-force-gles{value}", ForceGLESXY)
              .Add("-force-clamped", ForceClamped)
              .Add("-force-low-power-device", ForceLowPowerDevice)
              .Add("-importPackage {value}", ImportPackage)
              .Add("-setDefaultPlatformTextureFormat {value}", DefaultPlatformTextureFormat)
              .Add("-disable-assembly-updater {value}", DisableAssemblyUpdater, separator: ' ')
              .Add("-cacheServerIPAddress {value}", CacheServerIPAddress)
              .Add("-noUpm", NoUpm)
              .Add("-accept-apiupdate", AcceptApiUpdate)
              .Add("-runEditorTests", RunEditorTests)
              .Add("-editorTestsCategories {value}", EditorTestsCategories, separator: ',')
              .Add("-editorTestsFilter {value}", EditorTestsFilter, separator: ',')
              .Add("-editorTestsResultFile {value}", EditorTestsResultFile)
              .Add("-exportPackage {value}", ExportPackage, separator: ' ')
              .Add("{value}", CustomArguments, separator: ' ')
              .Add("-stackTraceLogType {value}", StackTraceLogType)
              .Add("-projectPath {value}", ProjectPath)
              .Add("-username {value}", Username)
              .Add("-password {value}", Password, secret: true)
              .Add("-serial {value}", Serial, secret: true)
              .Add("-batchmode", BatchMode)
              .Add("-silent-crashes", SilentCrashes)
              .Add("-nographics", NoGraphics)
              .Add("-quit", Quit);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region UnityReturnLicenseSettings
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class UnityReturnLicenseSettings : UnityBaseSettings
    {
        /// <summary>
        ///   Path to the Unity executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? GetToolPath();
        public override Action<OutputType, string> CustomLogger => UnityTasks.UnityLogger;
        /// <summary>
        ///   Enter a username into the log-in form during activation of the Unity Editor.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Enter a password into the log-in form during activation of the Unity Editor.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.
        /// </summary>
        public virtual string Serial { get; internal set; }
        /// <summary>
        ///   Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.
        /// </summary>
        public virtual bool? BatchMode { get; internal set; }
        /// <summary>
        ///   Don't display a crash dialog.
        /// </summary>
        public virtual bool? SilentCrashes { get; internal set; }
        /// <summary>
        ///   When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.
        /// </summary>
        public virtual bool? NoGraphics { get; internal set; }
        /// <summary>
        ///   Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).
        /// </summary>
        public virtual bool? Quit { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-returnlicense")
              .Add("-username {value}", Username)
              .Add("-password {value}", Password, secret: true)
              .Add("-serial {value}", Serial, secret: true)
              .Add("-batchmode", BatchMode)
              .Add("-silent-crashes", SilentCrashes)
              .Add("-nographics", NoGraphics)
              .Add("-quit", Quit);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region UnityBaseSettings
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class UnityBaseSettings : ToolSettings
    {
        /// <summary>
        ///   Specify where the Editor or Windows/Linux/OSX standalone log file are written.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        /// <summary>
        ///   (experimental) If set to true only warnings and errors will be printed to the output.
        /// </summary>
        public virtual bool? MinimalOutput { get; internal set; }
        /// <summary>
        ///   Define exit codes which will not fail the build.
        /// </summary>
        public virtual IReadOnlyList<int> StableExitCodes => StableExitCodesInternal.AsReadOnly();
        internal List<int> StableExitCodesInternal { get; set; } = new List<int>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("-logFile {value}", GetLogFile(), customValue: true);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region UnityCreateManualActivationFileSettingsExtensions
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class UnityCreateManualActivationFileSettingsExtensions
    {
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="UnityCreateManualActivationFileSettings.Username"/></em></p>
        ///   <p>Enter a username into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings SetUsername(this UnityCreateManualActivationFileSettings toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityCreateManualActivationFileSettings.Username"/></em></p>
        ///   <p>Enter a username into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ResetUsername(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="UnityCreateManualActivationFileSettings.Password"/></em></p>
        ///   <p>Enter a password into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings SetPassword(this UnityCreateManualActivationFileSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityCreateManualActivationFileSettings.Password"/></em></p>
        ///   <p>Enter a password into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ResetPassword(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Serial
        /// <summary>
        ///   <p><em>Sets <see cref="UnityCreateManualActivationFileSettings.Serial"/></em></p>
        ///   <p>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings SetSerial(this UnityCreateManualActivationFileSettings toolSettings, string serial)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serial = serial;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityCreateManualActivationFileSettings.Serial"/></em></p>
        ///   <p>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ResetSerial(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serial = null;
            return toolSettings;
        }
        #endregion
        #region BatchMode
        /// <summary>
        ///   <p><em>Sets <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings SetBatchMode(this UnityCreateManualActivationFileSettings toolSettings, bool? batchMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = batchMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ResetBatchMode(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings EnableBatchMode(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings DisableBatchMode(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityCreateManualActivationFileSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ToggleBatchMode(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = !toolSettings.BatchMode;
            return toolSettings;
        }
        #endregion
        #region SilentCrashes
        /// <summary>
        ///   <p><em>Sets <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings SetSilentCrashes(this UnityCreateManualActivationFileSettings toolSettings, bool? silentCrashes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = silentCrashes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ResetSilentCrashes(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings EnableSilentCrashes(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings DisableSilentCrashes(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityCreateManualActivationFileSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ToggleSilentCrashes(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = !toolSettings.SilentCrashes;
            return toolSettings;
        }
        #endregion
        #region NoGraphics
        /// <summary>
        ///   <p><em>Sets <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings SetNoGraphics(this UnityCreateManualActivationFileSettings toolSettings, bool? noGraphics)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = noGraphics;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ResetNoGraphics(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings EnableNoGraphics(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings DisableNoGraphics(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityCreateManualActivationFileSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ToggleNoGraphics(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = !toolSettings.NoGraphics;
            return toolSettings;
        }
        #endregion
        #region Quit
        /// <summary>
        ///   <p><em>Sets <see cref="UnityCreateManualActivationFileSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings SetQuit(this UnityCreateManualActivationFileSettings toolSettings, bool? quit)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = quit;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityCreateManualActivationFileSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ResetQuit(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityCreateManualActivationFileSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings EnableQuit(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityCreateManualActivationFileSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings DisableQuit(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityCreateManualActivationFileSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityCreateManualActivationFileSettings ToggleQuit(this UnityCreateManualActivationFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = !toolSettings.Quit;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region UnityManualLicenseFileSettingsExtensions
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class UnityManualLicenseFileSettingsExtensions
    {
        #region LicenseFile
        /// <summary>
        ///   <p><em>Sets <see cref="UnityManualLicenseFileSettings.LicenseFile"/></em></p>
        ///   <p>The path to the license file.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings SetLicenseFile(this UnityManualLicenseFileSettings toolSettings, string licenseFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LicenseFile = licenseFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityManualLicenseFileSettings.LicenseFile"/></em></p>
        ///   <p>The path to the license file.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ResetLicenseFile(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LicenseFile = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="UnityManualLicenseFileSettings.Username"/></em></p>
        ///   <p>Enter a username into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings SetUsername(this UnityManualLicenseFileSettings toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityManualLicenseFileSettings.Username"/></em></p>
        ///   <p>Enter a username into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ResetUsername(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="UnityManualLicenseFileSettings.Password"/></em></p>
        ///   <p>Enter a password into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings SetPassword(this UnityManualLicenseFileSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityManualLicenseFileSettings.Password"/></em></p>
        ///   <p>Enter a password into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ResetPassword(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Serial
        /// <summary>
        ///   <p><em>Sets <see cref="UnityManualLicenseFileSettings.Serial"/></em></p>
        ///   <p>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings SetSerial(this UnityManualLicenseFileSettings toolSettings, string serial)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serial = serial;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityManualLicenseFileSettings.Serial"/></em></p>
        ///   <p>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ResetSerial(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serial = null;
            return toolSettings;
        }
        #endregion
        #region BatchMode
        /// <summary>
        ///   <p><em>Sets <see cref="UnityManualLicenseFileSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings SetBatchMode(this UnityManualLicenseFileSettings toolSettings, bool? batchMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = batchMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityManualLicenseFileSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ResetBatchMode(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityManualLicenseFileSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings EnableBatchMode(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityManualLicenseFileSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings DisableBatchMode(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityManualLicenseFileSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ToggleBatchMode(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = !toolSettings.BatchMode;
            return toolSettings;
        }
        #endregion
        #region SilentCrashes
        /// <summary>
        ///   <p><em>Sets <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings SetSilentCrashes(this UnityManualLicenseFileSettings toolSettings, bool? silentCrashes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = silentCrashes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ResetSilentCrashes(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings EnableSilentCrashes(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings DisableSilentCrashes(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityManualLicenseFileSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ToggleSilentCrashes(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = !toolSettings.SilentCrashes;
            return toolSettings;
        }
        #endregion
        #region NoGraphics
        /// <summary>
        ///   <p><em>Sets <see cref="UnityManualLicenseFileSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings SetNoGraphics(this UnityManualLicenseFileSettings toolSettings, bool? noGraphics)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = noGraphics;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityManualLicenseFileSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ResetNoGraphics(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityManualLicenseFileSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings EnableNoGraphics(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityManualLicenseFileSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings DisableNoGraphics(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityManualLicenseFileSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ToggleNoGraphics(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = !toolSettings.NoGraphics;
            return toolSettings;
        }
        #endregion
        #region Quit
        /// <summary>
        ///   <p><em>Sets <see cref="UnityManualLicenseFileSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings SetQuit(this UnityManualLicenseFileSettings toolSettings, bool? quit)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = quit;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityManualLicenseFileSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ResetQuit(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityManualLicenseFileSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings EnableQuit(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityManualLicenseFileSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings DisableQuit(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityManualLicenseFileSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityManualLicenseFileSettings ToggleQuit(this UnityManualLicenseFileSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = !toolSettings.Quit;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region UnitySettingsExtensions
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class UnitySettingsExtensions
    {
        #region AssetServerUpdate
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.AssetServerUpdate"/></em></p>
        ///   <p>Force an update of the project in the <a href="https://docs.unity3d.com/Manual/AssetServer.html">Asset Server</a> given by <c>IP:port</c>. The port is optional, and if not given it is assumed to be the standard one (10733). It is advisable to use this command in conjunction with the <c>-projectPath</c> argument to ensure you are working with the correct project. If no project name is given, then the last project opened by Unity is used. If no project exists at the path given by <c>-projectPath</c>, then one is created automatically.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetAssetServerUpdate(this UnitySettings toolSettings, string assetServerUpdate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetServerUpdate = assetServerUpdate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.AssetServerUpdate"/></em></p>
        ///   <p>Force an update of the project in the <a href="https://docs.unity3d.com/Manual/AssetServer.html">Asset Server</a> given by <c>IP:port</c>. The port is optional, and if not given it is assumed to be the standard one (10733). It is advisable to use this command in conjunction with the <c>-projectPath</c> argument to ensure you are working with the correct project. If no project name is given, then the last project opened by Unity is used. If no project exists at the path given by <c>-projectPath</c>, then one is created automatically.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetAssetServerUpdate(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssetServerUpdate = null;
            return toolSettings;
        }
        #endregion
        #region BuildLinux32Player
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.BuildLinux32Player"/></em></p>
        ///   <p>Build a 32-bit standalone Linux player (for example, <c>-buildLinux32Player path/to/your/build</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetBuildLinux32Player(this UnitySettings toolSettings, string buildLinux32Player)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildLinux32Player = buildLinux32Player;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.BuildLinux32Player"/></em></p>
        ///   <p>Build a 32-bit standalone Linux player (for example, <c>-buildLinux32Player path/to/your/build</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetBuildLinux32Player(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildLinux32Player = null;
            return toolSettings;
        }
        #endregion
        #region BuildLinux64Player
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.BuildLinux64Player"/></em></p>
        ///   <p>Build a 64-bit standalone Linux player (for example, <c>-buildLinux64Player path/to/your/build</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetBuildLinux64Player(this UnitySettings toolSettings, string buildLinux64Player)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildLinux64Player = buildLinux64Player;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.BuildLinux64Player"/></em></p>
        ///   <p>Build a 64-bit standalone Linux player (for example, <c>-buildLinux64Player path/to/your/build</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetBuildLinux64Player(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildLinux64Player = null;
            return toolSettings;
        }
        #endregion
        #region BuildLinuxUniversalPlayer
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.BuildLinuxUniversalPlayer"/></em></p>
        ///   <p>Build a combined 32-bit and 64-bit standalone Linux player (for example, <c>-buildLinuxUniversalPlayer path/to/your/build</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetBuildLinuxUniversalPlayer(this UnitySettings toolSettings, string buildLinuxUniversalPlayer)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildLinuxUniversalPlayer = buildLinuxUniversalPlayer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.BuildLinuxUniversalPlayer"/></em></p>
        ///   <p>Build a combined 32-bit and 64-bit standalone Linux player (for example, <c>-buildLinuxUniversalPlayer path/to/your/build</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetBuildLinuxUniversalPlayer(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildLinuxUniversalPlayer = null;
            return toolSettings;
        }
        #endregion
        #region BuildOSXPlayer
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.BuildOSXPlayer"/></em></p>
        ///   <p>Build a 32-bit standalone Mac OSX player (for example, <c>-buildOSXPlayer path/to/your/build.app</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetBuildOSXPlayer(this UnitySettings toolSettings, string buildOSXPlayer)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildOSXPlayer = buildOSXPlayer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.BuildOSXPlayer"/></em></p>
        ///   <p>Build a 32-bit standalone Mac OSX player (for example, <c>-buildOSXPlayer path/to/your/build.app</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetBuildOSXPlayer(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildOSXPlayer = null;
            return toolSettings;
        }
        #endregion
        #region BuildOSX64Player
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.BuildOSX64Player"/></em></p>
        ///   <p>Build a 64-bit standalone Mac OSX player (for example, <c>-buildOSX64Player path/to/your/build.app</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetBuildOSX64Player(this UnitySettings toolSettings, string buildOSX64Player)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildOSX64Player = buildOSX64Player;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.BuildOSX64Player"/></em></p>
        ///   <p>Build a 64-bit standalone Mac OSX player (for example, <c>-buildOSX64Player path/to/your/build.app</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetBuildOSX64Player(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildOSX64Player = null;
            return toolSettings;
        }
        #endregion
        #region BuildOSXUniversalPlayer
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.BuildOSXUniversalPlayer"/></em></p>
        ///   <p>Build a combined 32-bit and 64-bit standalone Mac OSX player (for example, <c>-buildOSXUniversalPlayer path/to/your/build.app</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetBuildOSXUniversalPlayer(this UnitySettings toolSettings, string buildOSXUniversalPlayer)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildOSXUniversalPlayer = buildOSXUniversalPlayer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.BuildOSXUniversalPlayer"/></em></p>
        ///   <p>Build a combined 32-bit and 64-bit standalone Mac OSX player (for example, <c>-buildOSXUniversalPlayer path/to/your/build.app</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetBuildOSXUniversalPlayer(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildOSXUniversalPlayer = null;
            return toolSettings;
        }
        #endregion
        #region BuildTarget
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.BuildTarget"/></em></p>
        ///   <p>Allows the selection of an active build target before a project is loaded.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetBuildTarget(this UnitySettings toolSettings, string buildTarget)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildTarget = buildTarget;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.BuildTarget"/></em></p>
        ///   <p>Allows the selection of an active build target before a project is loaded.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetBuildTarget(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildTarget = null;
            return toolSettings;
        }
        #endregion
        #region BuildWindowsPlayer
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.BuildWindowsPlayer"/></em></p>
        ///   <p>Build a 32-bit standalone Windows player (for example, <c>-buildWindowsPlayer path/to/your/build.exe</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetBuildWindowsPlayer(this UnitySettings toolSettings, string buildWindowsPlayer)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildWindowsPlayer = buildWindowsPlayer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.BuildWindowsPlayer"/></em></p>
        ///   <p>Build a 32-bit standalone Windows player (for example, <c>-buildWindowsPlayer path/to/your/build.exe</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetBuildWindowsPlayer(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildWindowsPlayer = null;
            return toolSettings;
        }
        #endregion
        #region BuildWindows64Player
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.BuildWindows64Player"/></em></p>
        ///   <p>Build a 64-bit standalone Windows player (for example, <c>-buildWindows64Player path/to/your/build.exe</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetBuildWindows64Player(this UnitySettings toolSettings, string buildWindows64Player)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildWindows64Player = buildWindows64Player;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.BuildWindows64Player"/></em></p>
        ///   <p>Build a 64-bit standalone Windows player (for example, <c>-buildWindows64Player path/to/your/build.exe</c>).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetBuildWindows64Player(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildWindows64Player = null;
            return toolSettings;
        }
        #endregion
        #region CreateProject
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.CreateProject"/></em></p>
        ///   <p>Create an empty project at the given path.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetCreateProject(this UnitySettings toolSettings, string createProject)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateProject = createProject;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.CreateProject"/></em></p>
        ///   <p>Create an empty project at the given path.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetCreateProject(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateProject = null;
            return toolSettings;
        }
        #endregion
        #region ExecuteMethod
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ExecuteMethod"/></em></p>
        ///   <p>Execute the static method as soon as Unity is started, the project is open and after the optional Asset server update has been performed. This can be used to do tasks such as continous integration, performing Unit Tests, making builds or preparing data. To return an error from the command line process, either throw an exception which causes Unity to exit with return code <b>1</b>, or call <a href="https:/docs.unity3d.com/ScriptReference/EditorApplication.Exit.html">EditorApplication.Exit</a> with a non-zero return code.To use <b>ExecuteMethod</b>, you need to place the enclosing script in an Editor folder. The method to be executed must be defined as <c>static</c>.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetExecuteMethod(this UnitySettings toolSettings, string executeMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExecuteMethod = executeMethod;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ExecuteMethod"/></em></p>
        ///   <p>Execute the static method as soon as Unity is started, the project is open and after the optional Asset server update has been performed. This can be used to do tasks such as continous integration, performing Unit Tests, making builds or preparing data. To return an error from the command line process, either throw an exception which causes Unity to exit with return code <b>1</b>, or call <a href="https:/docs.unity3d.com/ScriptReference/EditorApplication.Exit.html">EditorApplication.Exit</a> with a non-zero return code.To use <b>ExecuteMethod</b>, you need to place the enclosing script in an Editor folder. The method to be executed must be defined as <c>static</c>.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetExecuteMethod(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExecuteMethod = null;
            return toolSettings;
        }
        #endregion
        #region ForceD3d11
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ForceD3d11"/></em></p>
        ///   <p>(Windows only) Make the Editor use Direct3D 11 for rendering. Normally the graphics API depends on player settings (typically defaults to D3D11).</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetForceD3d11(this UnitySettings toolSettings, bool? forceD3d11)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceD3d11 = forceD3d11;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ForceD3d11"/></em></p>
        ///   <p>(Windows only) Make the Editor use Direct3D 11 for rendering. Normally the graphics API depends on player settings (typically defaults to D3D11).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetForceD3d11(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceD3d11 = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.ForceD3d11"/></em></p>
        ///   <p>(Windows only) Make the Editor use Direct3D 11 for rendering. Normally the graphics API depends on player settings (typically defaults to D3D11).</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableForceD3d11(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceD3d11 = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.ForceD3d11"/></em></p>
        ///   <p>(Windows only) Make the Editor use Direct3D 11 for rendering. Normally the graphics API depends on player settings (typically defaults to D3D11).</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableForceD3d11(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceD3d11 = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.ForceD3d11"/></em></p>
        ///   <p>(Windows only) Make the Editor use Direct3D 11 for rendering. Normally the graphics API depends on player settings (typically defaults to D3D11).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleForceD3d11(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceD3d11 = !toolSettings.ForceD3d11;
            return toolSettings;
        }
        #endregion
        #region ForceDeviceIndex
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ForceDeviceIndex"/></em></p>
        ///   <p>(macOS only) When using Metal, make the Editor use a particular GPU device by passing it the index of that GPU.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetForceDeviceIndex(this UnitySettings toolSettings, bool? forceDeviceIndex)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceDeviceIndex = forceDeviceIndex;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ForceDeviceIndex"/></em></p>
        ///   <p>(macOS only) When using Metal, make the Editor use a particular GPU device by passing it the index of that GPU.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetForceDeviceIndex(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceDeviceIndex = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.ForceDeviceIndex"/></em></p>
        ///   <p>(macOS only) When using Metal, make the Editor use a particular GPU device by passing it the index of that GPU.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableForceDeviceIndex(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceDeviceIndex = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.ForceDeviceIndex"/></em></p>
        ///   <p>(macOS only) When using Metal, make the Editor use a particular GPU device by passing it the index of that GPU.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableForceDeviceIndex(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceDeviceIndex = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.ForceDeviceIndex"/></em></p>
        ///   <p>(macOS only) When using Metal, make the Editor use a particular GPU device by passing it the index of that GPU.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleForceDeviceIndex(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceDeviceIndex = !toolSettings.ForceDeviceIndex;
            return toolSettings;
        }
        #endregion
        #region ForceGfxMetal
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ForceGfxMetal"/></em></p>
        ///   <p>(macOS only) Make the Editor use Metal as the default graphics API.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetForceGfxMetal(this UnitySettings toolSettings, bool? forceGfxMetal)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGfxMetal = forceGfxMetal;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ForceGfxMetal"/></em></p>
        ///   <p>(macOS only) Make the Editor use Metal as the default graphics API.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetForceGfxMetal(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGfxMetal = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.ForceGfxMetal"/></em></p>
        ///   <p>(macOS only) Make the Editor use Metal as the default graphics API.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableForceGfxMetal(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGfxMetal = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.ForceGfxMetal"/></em></p>
        ///   <p>(macOS only) Make the Editor use Metal as the default graphics API.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableForceGfxMetal(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGfxMetal = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.ForceGfxMetal"/></em></p>
        ///   <p>(macOS only) Make the Editor use Metal as the default graphics API.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleForceGfxMetal(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGfxMetal = !toolSettings.ForceGfxMetal;
            return toolSettings;
        }
        #endregion
        #region ForceGLCore
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ForceGLCore"/></em></p>
        ///   <p>(Windows only) Make the Editor use OpenGL 3/4 core profile for rendering. The Editor tries to use the best OpenGL version available and all OpenGL extensions exposed by the OpenGL drivers. If the platform isn't supported, Direct3D is used.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetForceGLCore(this UnitySettings toolSettings, bool? forceGLCore)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLCore = forceGLCore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ForceGLCore"/></em></p>
        ///   <p>(Windows only) Make the Editor use OpenGL 3/4 core profile for rendering. The Editor tries to use the best OpenGL version available and all OpenGL extensions exposed by the OpenGL drivers. If the platform isn't supported, Direct3D is used.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetForceGLCore(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLCore = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.ForceGLCore"/></em></p>
        ///   <p>(Windows only) Make the Editor use OpenGL 3/4 core profile for rendering. The Editor tries to use the best OpenGL version available and all OpenGL extensions exposed by the OpenGL drivers. If the platform isn't supported, Direct3D is used.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableForceGLCore(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLCore = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.ForceGLCore"/></em></p>
        ///   <p>(Windows only) Make the Editor use OpenGL 3/4 core profile for rendering. The Editor tries to use the best OpenGL version available and all OpenGL extensions exposed by the OpenGL drivers. If the platform isn't supported, Direct3D is used.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableForceGLCore(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLCore = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.ForceGLCore"/></em></p>
        ///   <p>(Windows only) Make the Editor use OpenGL 3/4 core profile for rendering. The Editor tries to use the best OpenGL version available and all OpenGL extensions exposed by the OpenGL drivers. If the platform isn't supported, Direct3D is used.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleForceGLCore(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLCore = !toolSettings.ForceGLCore;
            return toolSettings;
        }
        #endregion
        #region ForceGLCoreXY
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ForceGLCoreXY"/></em></p>
        ///   <p>(Windows only) Similar to <c>-force-glcore</c>, but requests a specific OpenGL context version. Accepted values for XY: 32, 33, 40, 41, 42, 43, 44 or 45.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetForceGLCoreXY(this UnitySettings toolSettings, UnityGLCore forceGLCoreXY)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLCoreXY = forceGLCoreXY;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ForceGLCoreXY"/></em></p>
        ///   <p>(Windows only) Similar to <c>-force-glcore</c>, but requests a specific OpenGL context version. Accepted values for XY: 32, 33, 40, 41, 42, 43, 44 or 45.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetForceGLCoreXY(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLCoreXY = null;
            return toolSettings;
        }
        #endregion
        #region ForceGLES
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ForceGLES"/></em></p>
        ///   <p>(Windows only) Make the Editor use OpenGL for Embedded Systems for rendering. The Editor tries to use the best OpenGL ES version available, and all OpenGL ES extensions exposed by the OpenGL drivers.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetForceGLES(this UnitySettings toolSettings, bool? forceGLES)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLES = forceGLES;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ForceGLES"/></em></p>
        ///   <p>(Windows only) Make the Editor use OpenGL for Embedded Systems for rendering. The Editor tries to use the best OpenGL ES version available, and all OpenGL ES extensions exposed by the OpenGL drivers.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetForceGLES(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLES = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.ForceGLES"/></em></p>
        ///   <p>(Windows only) Make the Editor use OpenGL for Embedded Systems for rendering. The Editor tries to use the best OpenGL ES version available, and all OpenGL ES extensions exposed by the OpenGL drivers.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableForceGLES(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLES = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.ForceGLES"/></em></p>
        ///   <p>(Windows only) Make the Editor use OpenGL for Embedded Systems for rendering. The Editor tries to use the best OpenGL ES version available, and all OpenGL ES extensions exposed by the OpenGL drivers.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableForceGLES(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLES = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.ForceGLES"/></em></p>
        ///   <p>(Windows only) Make the Editor use OpenGL for Embedded Systems for rendering. The Editor tries to use the best OpenGL ES version available, and all OpenGL ES extensions exposed by the OpenGL drivers.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleForceGLES(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLES = !toolSettings.ForceGLES;
            return toolSettings;
        }
        #endregion
        #region ForceGLESXY
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ForceGLESXY"/></em></p>
        ///   <p>(Windows only) Similar to <c>-force-gles</c>, but requests a specific OpenGL ES context version. Accepted values for XY: 30, 31 or 32.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetForceGLESXY(this UnitySettings toolSettings, UnityGLES forceGLESXY)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLESXY = forceGLESXY;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ForceGLESXY"/></em></p>
        ///   <p>(Windows only) Similar to <c>-force-gles</c>, but requests a specific OpenGL ES context version. Accepted values for XY: 30, 31 or 32.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetForceGLESXY(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceGLESXY = null;
            return toolSettings;
        }
        #endregion
        #region ForceClamped
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ForceClamped"/></em></p>
        ///   <p>(2017.3+) (Windows only) Used with <c>-force-glcoreXY</c> to prevent checking for additional OpenGL extensions, allowing it to run between platforms with the same code paths.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetForceClamped(this UnitySettings toolSettings, bool? forceClamped)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceClamped = forceClamped;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ForceClamped"/></em></p>
        ///   <p>(2017.3+) (Windows only) Used with <c>-force-glcoreXY</c> to prevent checking for additional OpenGL extensions, allowing it to run between platforms with the same code paths.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetForceClamped(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceClamped = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.ForceClamped"/></em></p>
        ///   <p>(2017.3+) (Windows only) Used with <c>-force-glcoreXY</c> to prevent checking for additional OpenGL extensions, allowing it to run between platforms with the same code paths.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableForceClamped(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceClamped = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.ForceClamped"/></em></p>
        ///   <p>(2017.3+) (Windows only) Used with <c>-force-glcoreXY</c> to prevent checking for additional OpenGL extensions, allowing it to run between platforms with the same code paths.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableForceClamped(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceClamped = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.ForceClamped"/></em></p>
        ///   <p>(2017.3+) (Windows only) Used with <c>-force-glcoreXY</c> to prevent checking for additional OpenGL extensions, allowing it to run between platforms with the same code paths.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleForceClamped(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceClamped = !toolSettings.ForceClamped;
            return toolSettings;
        }
        #endregion
        #region ForceLowPowerDevice
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ForceLowPowerDevice"/></em></p>
        ///   <p>(macOS only) When using Metal, make the Editor use a low power device.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetForceLowPowerDevice(this UnitySettings toolSettings, bool? forceLowPowerDevice)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceLowPowerDevice = forceLowPowerDevice;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ForceLowPowerDevice"/></em></p>
        ///   <p>(macOS only) When using Metal, make the Editor use a low power device.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetForceLowPowerDevice(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceLowPowerDevice = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.ForceLowPowerDevice"/></em></p>
        ///   <p>(macOS only) When using Metal, make the Editor use a low power device.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableForceLowPowerDevice(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceLowPowerDevice = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.ForceLowPowerDevice"/></em></p>
        ///   <p>(macOS only) When using Metal, make the Editor use a low power device.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableForceLowPowerDevice(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceLowPowerDevice = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.ForceLowPowerDevice"/></em></p>
        ///   <p>(macOS only) When using Metal, make the Editor use a low power device.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleForceLowPowerDevice(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceLowPowerDevice = !toolSettings.ForceLowPowerDevice;
            return toolSettings;
        }
        #endregion
        #region ImportPackage
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ImportPackage"/></em></p>
        ///   <p>Import the given <a href="https://docs.unity3d.com/Manual/HOWTO-exportpackage.html">package</a>. No import dialog is shown.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetImportPackage(this UnitySettings toolSettings, string importPackage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportPackage = importPackage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ImportPackage"/></em></p>
        ///   <p>Import the given <a href="https://docs.unity3d.com/Manual/HOWTO-exportpackage.html">package</a>. No import dialog is shown.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetImportPackage(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImportPackage = null;
            return toolSettings;
        }
        #endregion
        #region DefaultPlatformTextureFormat
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.DefaultPlatformTextureFormat"/></em></p>
        ///   <p>(2018.1+) Sets the default texture compression to the desired format before importing a texture or building the project. This is so you don’t have to import the texture again with the format you want. The available formats are dxt, pvrtc, atc, etc, etc2, and astc. Note that this is only supported on Android.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetDefaultPlatformTextureFormat(this UnitySettings toolSettings, string defaultPlatformTextureFormat)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPlatformTextureFormat = defaultPlatformTextureFormat;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.DefaultPlatformTextureFormat"/></em></p>
        ///   <p>(2018.1+) Sets the default texture compression to the desired format before importing a texture or building the project. This is so you don’t have to import the texture again with the format you want. The available formats are dxt, pvrtc, atc, etc, etc2, and astc. Note that this is only supported on Android.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetDefaultPlatformTextureFormat(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DefaultPlatformTextureFormat = null;
            return toolSettings;
        }
        #endregion
        #region DisableAssemblyUpdater
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.DisableAssemblyUpdater"/> to a new list</em></p>
        ///   <p>Specify a space-separated list of assembly names as parameters for Unity to ignore on automatic updates. The space-separated list of assembly names is optional: Pass the command line options without any assembly names to ignore all assemblies.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetDisableAssemblyUpdater(this UnitySettings toolSettings, params string[] disableAssemblyUpdater)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableAssemblyUpdaterInternal = disableAssemblyUpdater.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.DisableAssemblyUpdater"/> to a new list</em></p>
        ///   <p>Specify a space-separated list of assembly names as parameters for Unity to ignore on automatic updates. The space-separated list of assembly names is optional: Pass the command line options without any assembly names to ignore all assemblies.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetDisableAssemblyUpdater(this UnitySettings toolSettings, IEnumerable<string> disableAssemblyUpdater)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableAssemblyUpdaterInternal = disableAssemblyUpdater.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnitySettings.DisableAssemblyUpdater"/></em></p>
        ///   <p>Specify a space-separated list of assembly names as parameters for Unity to ignore on automatic updates. The space-separated list of assembly names is optional: Pass the command line options without any assembly names to ignore all assemblies.</p>
        /// </summary>
        [Pure]
        public static UnitySettings AddDisableAssemblyUpdater(this UnitySettings toolSettings, params string[] disableAssemblyUpdater)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableAssemblyUpdaterInternal.AddRange(disableAssemblyUpdater);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnitySettings.DisableAssemblyUpdater"/></em></p>
        ///   <p>Specify a space-separated list of assembly names as parameters for Unity to ignore on automatic updates. The space-separated list of assembly names is optional: Pass the command line options without any assembly names to ignore all assemblies.</p>
        /// </summary>
        [Pure]
        public static UnitySettings AddDisableAssemblyUpdater(this UnitySettings toolSettings, IEnumerable<string> disableAssemblyUpdater)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableAssemblyUpdaterInternal.AddRange(disableAssemblyUpdater);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="UnitySettings.DisableAssemblyUpdater"/></em></p>
        ///   <p>Specify a space-separated list of assembly names as parameters for Unity to ignore on automatic updates. The space-separated list of assembly names is optional: Pass the command line options without any assembly names to ignore all assemblies.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ClearDisableAssemblyUpdater(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableAssemblyUpdaterInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnitySettings.DisableAssemblyUpdater"/></em></p>
        ///   <p>Specify a space-separated list of assembly names as parameters for Unity to ignore on automatic updates. The space-separated list of assembly names is optional: Pass the command line options without any assembly names to ignore all assemblies.</p>
        /// </summary>
        [Pure]
        public static UnitySettings RemoveDisableAssemblyUpdater(this UnitySettings toolSettings, params string[] disableAssemblyUpdater)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(disableAssemblyUpdater);
            toolSettings.DisableAssemblyUpdaterInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnitySettings.DisableAssemblyUpdater"/></em></p>
        ///   <p>Specify a space-separated list of assembly names as parameters for Unity to ignore on automatic updates. The space-separated list of assembly names is optional: Pass the command line options without any assembly names to ignore all assemblies.</p>
        /// </summary>
        [Pure]
        public static UnitySettings RemoveDisableAssemblyUpdater(this UnitySettings toolSettings, IEnumerable<string> disableAssemblyUpdater)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(disableAssemblyUpdater);
            toolSettings.DisableAssemblyUpdaterInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region CacheServerIPAddress
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.CacheServerIPAddress"/></em></p>
        ///   <p>(2018.1+) Connect to the Cache Server given by <c>IP:port</c> on startup, overriding any configuration stored in the Editor Preferences. Use this to connect multiple instances of Unity to different Cache Servers.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetCacheServerIPAddress(this UnitySettings toolSettings, string cacheServerIPAddress)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheServerIPAddress = cacheServerIPAddress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.CacheServerIPAddress"/></em></p>
        ///   <p>(2018.1+) Connect to the Cache Server given by <c>IP:port</c> on startup, overriding any configuration stored in the Editor Preferences. Use this to connect multiple instances of Unity to different Cache Servers.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetCacheServerIPAddress(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CacheServerIPAddress = null;
            return toolSettings;
        }
        #endregion
        #region NoUpm
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.NoUpm"/></em></p>
        ///   <p>(2018.1+) Disables the Unity Package Manager.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetNoUpm(this UnitySettings toolSettings, bool? noUpm)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoUpm = noUpm;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.NoUpm"/></em></p>
        ///   <p>(2018.1+) Disables the Unity Package Manager.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetNoUpm(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoUpm = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.NoUpm"/></em></p>
        ///   <p>(2018.1+) Disables the Unity Package Manager.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableNoUpm(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoUpm = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.NoUpm"/></em></p>
        ///   <p>(2018.1+) Disables the Unity Package Manager.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableNoUpm(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoUpm = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.NoUpm"/></em></p>
        ///   <p>(2018.1+) Disables the Unity Package Manager.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleNoUpm(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoUpm = !toolSettings.NoUpm;
            return toolSettings;
        }
        #endregion
        #region AcceptApiUpdate
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.AcceptApiUpdate"/></em></p>
        ///   <p>(2017.2+) Use this command line option to specify that APIUpdater should run when Unity is launched in batch mode. Omitting this command line argument when launching Unity in batch mode results in APIUpdater not running which can lead to compiler errors. Note that in versions prior to 2017.2 there’s no way to not run APIUpdater when Unity is launched in batch mode.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetAcceptApiUpdate(this UnitySettings toolSettings, bool? acceptApiUpdate)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptApiUpdate = acceptApiUpdate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.AcceptApiUpdate"/></em></p>
        ///   <p>(2017.2+) Use this command line option to specify that APIUpdater should run when Unity is launched in batch mode. Omitting this command line argument when launching Unity in batch mode results in APIUpdater not running which can lead to compiler errors. Note that in versions prior to 2017.2 there’s no way to not run APIUpdater when Unity is launched in batch mode.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetAcceptApiUpdate(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptApiUpdate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.AcceptApiUpdate"/></em></p>
        ///   <p>(2017.2+) Use this command line option to specify that APIUpdater should run when Unity is launched in batch mode. Omitting this command line argument when launching Unity in batch mode results in APIUpdater not running which can lead to compiler errors. Note that in versions prior to 2017.2 there’s no way to not run APIUpdater when Unity is launched in batch mode.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableAcceptApiUpdate(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptApiUpdate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.AcceptApiUpdate"/></em></p>
        ///   <p>(2017.2+) Use this command line option to specify that APIUpdater should run when Unity is launched in batch mode. Omitting this command line argument when launching Unity in batch mode results in APIUpdater not running which can lead to compiler errors. Note that in versions prior to 2017.2 there’s no way to not run APIUpdater when Unity is launched in batch mode.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableAcceptApiUpdate(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptApiUpdate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.AcceptApiUpdate"/></em></p>
        ///   <p>(2017.2+) Use this command line option to specify that APIUpdater should run when Unity is launched in batch mode. Omitting this command line argument when launching Unity in batch mode results in APIUpdater not running which can lead to compiler errors. Note that in versions prior to 2017.2 there’s no way to not run APIUpdater when Unity is launched in batch mode.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleAcceptApiUpdate(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AcceptApiUpdate = !toolSettings.AcceptApiUpdate;
            return toolSettings;
        }
        #endregion
        #region RunEditorTests
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.RunEditorTests"/></em></p>
        ///   <p>Run Editor tests from the project. This argument requires the <c>projectPath</c>, and it’s good practice to run it with <c>batchmode</c> argument. <c>quit</c> is not required, because the Editor automatically closes down after the run is finished.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetRunEditorTests(this UnitySettings toolSettings, bool? runEditorTests)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunEditorTests = runEditorTests;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.RunEditorTests"/></em></p>
        ///   <p>Run Editor tests from the project. This argument requires the <c>projectPath</c>, and it’s good practice to run it with <c>batchmode</c> argument. <c>quit</c> is not required, because the Editor automatically closes down after the run is finished.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetRunEditorTests(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunEditorTests = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.RunEditorTests"/></em></p>
        ///   <p>Run Editor tests from the project. This argument requires the <c>projectPath</c>, and it’s good practice to run it with <c>batchmode</c> argument. <c>quit</c> is not required, because the Editor automatically closes down after the run is finished.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableRunEditorTests(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunEditorTests = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.RunEditorTests"/></em></p>
        ///   <p>Run Editor tests from the project. This argument requires the <c>projectPath</c>, and it’s good practice to run it with <c>batchmode</c> argument. <c>quit</c> is not required, because the Editor automatically closes down after the run is finished.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableRunEditorTests(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunEditorTests = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.RunEditorTests"/></em></p>
        ///   <p>Run Editor tests from the project. This argument requires the <c>projectPath</c>, and it’s good practice to run it with <c>batchmode</c> argument. <c>quit</c> is not required, because the Editor automatically closes down after the run is finished.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleRunEditorTests(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RunEditorTests = !toolSettings.RunEditorTests;
            return toolSettings;
        }
        #endregion
        #region EditorTestsCategories
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.EditorTestsCategories"/> to a new list</em></p>
        ///   <p>Filter editor tests by categories.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetEditorTestsCategories(this UnitySettings toolSettings, params string[] editorTestsCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsCategoriesInternal = editorTestsCategories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.EditorTestsCategories"/> to a new list</em></p>
        ///   <p>Filter editor tests by categories.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetEditorTestsCategories(this UnitySettings toolSettings, IEnumerable<string> editorTestsCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsCategoriesInternal = editorTestsCategories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnitySettings.EditorTestsCategories"/></em></p>
        ///   <p>Filter editor tests by categories.</p>
        /// </summary>
        [Pure]
        public static UnitySettings AddEditorTestsCategories(this UnitySettings toolSettings, params string[] editorTestsCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsCategoriesInternal.AddRange(editorTestsCategories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnitySettings.EditorTestsCategories"/></em></p>
        ///   <p>Filter editor tests by categories.</p>
        /// </summary>
        [Pure]
        public static UnitySettings AddEditorTestsCategories(this UnitySettings toolSettings, IEnumerable<string> editorTestsCategories)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsCategoriesInternal.AddRange(editorTestsCategories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="UnitySettings.EditorTestsCategories"/></em></p>
        ///   <p>Filter editor tests by categories.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ClearEditorTestsCategories(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsCategoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnitySettings.EditorTestsCategories"/></em></p>
        ///   <p>Filter editor tests by categories.</p>
        /// </summary>
        [Pure]
        public static UnitySettings RemoveEditorTestsCategories(this UnitySettings toolSettings, params string[] editorTestsCategories)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(editorTestsCategories);
            toolSettings.EditorTestsCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnitySettings.EditorTestsCategories"/></em></p>
        ///   <p>Filter editor tests by categories.</p>
        /// </summary>
        [Pure]
        public static UnitySettings RemoveEditorTestsCategories(this UnitySettings toolSettings, IEnumerable<string> editorTestsCategories)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(editorTestsCategories);
            toolSettings.EditorTestsCategoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region EditorTestsFilter
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.EditorTestsFilter"/> to a new list</em></p>
        ///   <p>Filter editor tests by names.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetEditorTestsFilter(this UnitySettings toolSettings, params string[] editorTestsFilter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsFilterInternal = editorTestsFilter.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.EditorTestsFilter"/> to a new list</em></p>
        ///   <p>Filter editor tests by names.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetEditorTestsFilter(this UnitySettings toolSettings, IEnumerable<string> editorTestsFilter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsFilterInternal = editorTestsFilter.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnitySettings.EditorTestsFilter"/></em></p>
        ///   <p>Filter editor tests by names.</p>
        /// </summary>
        [Pure]
        public static UnitySettings AddEditorTestsFilter(this UnitySettings toolSettings, params string[] editorTestsFilter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsFilterInternal.AddRange(editorTestsFilter);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnitySettings.EditorTestsFilter"/></em></p>
        ///   <p>Filter editor tests by names.</p>
        /// </summary>
        [Pure]
        public static UnitySettings AddEditorTestsFilter(this UnitySettings toolSettings, IEnumerable<string> editorTestsFilter)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsFilterInternal.AddRange(editorTestsFilter);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="UnitySettings.EditorTestsFilter"/></em></p>
        ///   <p>Filter editor tests by names.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ClearEditorTestsFilter(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsFilterInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnitySettings.EditorTestsFilter"/></em></p>
        ///   <p>Filter editor tests by names.</p>
        /// </summary>
        [Pure]
        public static UnitySettings RemoveEditorTestsFilter(this UnitySettings toolSettings, params string[] editorTestsFilter)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(editorTestsFilter);
            toolSettings.EditorTestsFilterInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnitySettings.EditorTestsFilter"/></em></p>
        ///   <p>Filter editor tests by names.</p>
        /// </summary>
        [Pure]
        public static UnitySettings RemoveEditorTestsFilter(this UnitySettings toolSettings, IEnumerable<string> editorTestsFilter)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(editorTestsFilter);
            toolSettings.EditorTestsFilterInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region EditorTestsResultFile
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.EditorTestsResultFile"/></em></p>
        ///   <p>Path where the result file should be placed. If the path is a folder, a default file name is used. If not specified, the results are placed in the project's root folder.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetEditorTestsResultFile(this UnitySettings toolSettings, string editorTestsResultFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsResultFile = editorTestsResultFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.EditorTestsResultFile"/></em></p>
        ///   <p>Path where the result file should be placed. If the path is a folder, a default file name is used. If not specified, the results are placed in the project's root folder.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetEditorTestsResultFile(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EditorTestsResultFile = null;
            return toolSettings;
        }
        #endregion
        #region ExportPackage
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ExportPackage"/> to a new list</em></p>
        ///   <p>Export a package, given a path (or set of given paths).<c>-exportPackage &lt;exportAssetPath&gt; &lt;exportFileName&gt;</c> In this example exportAssetPath is a folder (relative to to the Unity project root) to export from the Unity project, and exportFileName is the package name. Currently, this option only exports whole folders at a time. You normally need to use this command with the -projectPath argument.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetExportPackage(this UnitySettings toolSettings, params string[] exportPackage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportPackageInternal = exportPackage.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ExportPackage"/> to a new list</em></p>
        ///   <p>Export a package, given a path (or set of given paths).<c>-exportPackage &lt;exportAssetPath&gt; &lt;exportFileName&gt;</c> In this example exportAssetPath is a folder (relative to to the Unity project root) to export from the Unity project, and exportFileName is the package name. Currently, this option only exports whole folders at a time. You normally need to use this command with the -projectPath argument.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetExportPackage(this UnitySettings toolSettings, IEnumerable<string> exportPackage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportPackageInternal = exportPackage.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnitySettings.ExportPackage"/></em></p>
        ///   <p>Export a package, given a path (or set of given paths).<c>-exportPackage &lt;exportAssetPath&gt; &lt;exportFileName&gt;</c> In this example exportAssetPath is a folder (relative to to the Unity project root) to export from the Unity project, and exportFileName is the package name. Currently, this option only exports whole folders at a time. You normally need to use this command with the -projectPath argument.</p>
        /// </summary>
        [Pure]
        public static UnitySettings AddExportPackage(this UnitySettings toolSettings, params string[] exportPackage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportPackageInternal.AddRange(exportPackage);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnitySettings.ExportPackage"/></em></p>
        ///   <p>Export a package, given a path (or set of given paths).<c>-exportPackage &lt;exportAssetPath&gt; &lt;exportFileName&gt;</c> In this example exportAssetPath is a folder (relative to to the Unity project root) to export from the Unity project, and exportFileName is the package name. Currently, this option only exports whole folders at a time. You normally need to use this command with the -projectPath argument.</p>
        /// </summary>
        [Pure]
        public static UnitySettings AddExportPackage(this UnitySettings toolSettings, IEnumerable<string> exportPackage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportPackageInternal.AddRange(exportPackage);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="UnitySettings.ExportPackage"/></em></p>
        ///   <p>Export a package, given a path (or set of given paths).<c>-exportPackage &lt;exportAssetPath&gt; &lt;exportFileName&gt;</c> In this example exportAssetPath is a folder (relative to to the Unity project root) to export from the Unity project, and exportFileName is the package name. Currently, this option only exports whole folders at a time. You normally need to use this command with the -projectPath argument.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ClearExportPackage(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExportPackageInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnitySettings.ExportPackage"/></em></p>
        ///   <p>Export a package, given a path (or set of given paths).<c>-exportPackage &lt;exportAssetPath&gt; &lt;exportFileName&gt;</c> In this example exportAssetPath is a folder (relative to to the Unity project root) to export from the Unity project, and exportFileName is the package name. Currently, this option only exports whole folders at a time. You normally need to use this command with the -projectPath argument.</p>
        /// </summary>
        [Pure]
        public static UnitySettings RemoveExportPackage(this UnitySettings toolSettings, params string[] exportPackage)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exportPackage);
            toolSettings.ExportPackageInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnitySettings.ExportPackage"/></em></p>
        ///   <p>Export a package, given a path (or set of given paths).<c>-exportPackage &lt;exportAssetPath&gt; &lt;exportFileName&gt;</c> In this example exportAssetPath is a folder (relative to to the Unity project root) to export from the Unity project, and exportFileName is the package name. Currently, this option only exports whole folders at a time. You normally need to use this command with the -projectPath argument.</p>
        /// </summary>
        [Pure]
        public static UnitySettings RemoveExportPackage(this UnitySettings toolSettings, IEnumerable<string> exportPackage)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exportPackage);
            toolSettings.ExportPackageInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region CustomArguments
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.CustomArguments"/> to a new list</em></p>
        ///   <p>Custom parameters. To pass parameters, add them to the command line and retrieve them inside the function using <c>System.Environment.GetCommandLineArgs</c>. </p>
        /// </summary>
        [Pure]
        public static UnitySettings SetCustomArguments(this UnitySettings toolSettings, params string[] customArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CustomArgumentsInternal = customArguments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.CustomArguments"/> to a new list</em></p>
        ///   <p>Custom parameters. To pass parameters, add them to the command line and retrieve them inside the function using <c>System.Environment.GetCommandLineArgs</c>. </p>
        /// </summary>
        [Pure]
        public static UnitySettings SetCustomArguments(this UnitySettings toolSettings, IEnumerable<string> customArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CustomArgumentsInternal = customArguments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnitySettings.CustomArguments"/></em></p>
        ///   <p>Custom parameters. To pass parameters, add them to the command line and retrieve them inside the function using <c>System.Environment.GetCommandLineArgs</c>. </p>
        /// </summary>
        [Pure]
        public static UnitySettings AddCustomArguments(this UnitySettings toolSettings, params string[] customArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CustomArgumentsInternal.AddRange(customArguments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnitySettings.CustomArguments"/></em></p>
        ///   <p>Custom parameters. To pass parameters, add them to the command line and retrieve them inside the function using <c>System.Environment.GetCommandLineArgs</c>. </p>
        /// </summary>
        [Pure]
        public static UnitySettings AddCustomArguments(this UnitySettings toolSettings, IEnumerable<string> customArguments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CustomArgumentsInternal.AddRange(customArguments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="UnitySettings.CustomArguments"/></em></p>
        ///   <p>Custom parameters. To pass parameters, add them to the command line and retrieve them inside the function using <c>System.Environment.GetCommandLineArgs</c>. </p>
        /// </summary>
        [Pure]
        public static UnitySettings ClearCustomArguments(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CustomArgumentsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnitySettings.CustomArguments"/></em></p>
        ///   <p>Custom parameters. To pass parameters, add them to the command line and retrieve them inside the function using <c>System.Environment.GetCommandLineArgs</c>. </p>
        /// </summary>
        [Pure]
        public static UnitySettings RemoveCustomArguments(this UnitySettings toolSettings, params string[] customArguments)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(customArguments);
            toolSettings.CustomArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnitySettings.CustomArguments"/></em></p>
        ///   <p>Custom parameters. To pass parameters, add them to the command line and retrieve them inside the function using <c>System.Environment.GetCommandLineArgs</c>. </p>
        /// </summary>
        [Pure]
        public static UnitySettings RemoveCustomArguments(this UnitySettings toolSettings, IEnumerable<string> customArguments)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(customArguments);
            toolSettings.CustomArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region StackTraceLogType
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.StackTraceLogType"/></em></p>
        ///   <p>Detailed debugging feature. StackTraceLogging allows you to allow detailed logging.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetStackTraceLogType(this UnitySettings toolSettings, UnityStackTraceLogType stackTraceLogType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StackTraceLogType = stackTraceLogType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.StackTraceLogType"/></em></p>
        ///   <p>Detailed debugging feature. StackTraceLogging allows you to allow detailed logging.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetStackTraceLogType(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StackTraceLogType = null;
            return toolSettings;
        }
        #endregion
        #region ProjectPath
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.ProjectPath"/></em></p>
        ///   <p>Specify the path of the unity project.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetProjectPath(this UnitySettings toolSettings, string projectPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectPath = projectPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.ProjectPath"/></em></p>
        ///   <p>Specify the path of the unity project.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetProjectPath(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectPath = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.Username"/></em></p>
        ///   <p>Enter a username into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetUsername(this UnitySettings toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.Username"/></em></p>
        ///   <p>Enter a username into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetUsername(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.Password"/></em></p>
        ///   <p>Enter a password into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetPassword(this UnitySettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.Password"/></em></p>
        ///   <p>Enter a password into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetPassword(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Serial
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.Serial"/></em></p>
        ///   <p>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetSerial(this UnitySettings toolSettings, string serial)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serial = serial;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.Serial"/></em></p>
        ///   <p>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetSerial(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serial = null;
            return toolSettings;
        }
        #endregion
        #region BatchMode
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetBatchMode(this UnitySettings toolSettings, bool? batchMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = batchMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetBatchMode(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableBatchMode(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableBatchMode(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleBatchMode(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = !toolSettings.BatchMode;
            return toolSettings;
        }
        #endregion
        #region SilentCrashes
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetSilentCrashes(this UnitySettings toolSettings, bool? silentCrashes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = silentCrashes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetSilentCrashes(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableSilentCrashes(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableSilentCrashes(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleSilentCrashes(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = !toolSettings.SilentCrashes;
            return toolSettings;
        }
        #endregion
        #region NoGraphics
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetNoGraphics(this UnitySettings toolSettings, bool? noGraphics)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = noGraphics;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetNoGraphics(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableNoGraphics(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableNoGraphics(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleNoGraphics(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = !toolSettings.NoGraphics;
            return toolSettings;
        }
        #endregion
        #region Quit
        /// <summary>
        ///   <p><em>Sets <see cref="UnitySettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnitySettings SetQuit(this UnitySettings toolSettings, bool? quit)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = quit;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnitySettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ResetQuit(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnitySettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnitySettings EnableQuit(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnitySettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnitySettings DisableQuit(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnitySettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnitySettings ToggleQuit(this UnitySettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = !toolSettings.Quit;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region UnityReturnLicenseSettingsExtensions
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class UnityReturnLicenseSettingsExtensions
    {
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="UnityReturnLicenseSettings.Username"/></em></p>
        ///   <p>Enter a username into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings SetUsername(this UnityReturnLicenseSettings toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityReturnLicenseSettings.Username"/></em></p>
        ///   <p>Enter a username into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ResetUsername(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="UnityReturnLicenseSettings.Password"/></em></p>
        ///   <p>Enter a password into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings SetPassword(this UnityReturnLicenseSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityReturnLicenseSettings.Password"/></em></p>
        ///   <p>Enter a password into the log-in form during activation of the Unity Editor.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ResetPassword(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Serial
        /// <summary>
        ///   <p><em>Sets <see cref="UnityReturnLicenseSettings.Serial"/></em></p>
        ///   <p>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings SetSerial(this UnityReturnLicenseSettings toolSettings, string serial)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serial = serial;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityReturnLicenseSettings.Serial"/></em></p>
        ///   <p>Activate Unity with the specified serial key. It is good practice to pass the <c>-batchmode</c> and <c>-quit</c> arguments as well, in order to quit Unity when done, if using this for automated activation of Unity. Please allow a few seconds before the license file is created, because Unity needs to communicate with the license server. Make sure that license file folder exists, and has appropriate permissions before running Unity with this argument. If activation fails, see the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Editor.log</a> for info.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ResetSerial(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serial = null;
            return toolSettings;
        }
        #endregion
        #region BatchMode
        /// <summary>
        ///   <p><em>Sets <see cref="UnityReturnLicenseSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings SetBatchMode(this UnityReturnLicenseSettings toolSettings, bool? batchMode)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = batchMode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityReturnLicenseSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ResetBatchMode(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityReturnLicenseSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings EnableBatchMode(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityReturnLicenseSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings DisableBatchMode(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityReturnLicenseSettings.BatchMode"/></em></p>
        ///   <p>Run Unity in batch mode. This should always be used in conjunction with the other command line arguments, because it ensures no pop-up windows appear and eliminates the need for any human intervention. When an exception occurs during execution of the script code, the Asset server updates fail, or other operations that fail, Unity immediately exits with return code <b>1</b>.<para/>Note that in batch mode, Unity sends a minimal version of its log output to the console. However, the <a href="https://docs.unity3d.com/Manual/LogFiles.html">Log Files</a> still contain the full log information. Opening a project in batch mode while the Editor has the same project open is not supported; only a single instance of Unity can run at a time.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ToggleBatchMode(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BatchMode = !toolSettings.BatchMode;
            return toolSettings;
        }
        #endregion
        #region SilentCrashes
        /// <summary>
        ///   <p><em>Sets <see cref="UnityReturnLicenseSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings SetSilentCrashes(this UnityReturnLicenseSettings toolSettings, bool? silentCrashes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = silentCrashes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityReturnLicenseSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ResetSilentCrashes(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityReturnLicenseSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings EnableSilentCrashes(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityReturnLicenseSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings DisableSilentCrashes(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityReturnLicenseSettings.SilentCrashes"/></em></p>
        ///   <p>Don't display a crash dialog.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ToggleSilentCrashes(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SilentCrashes = !toolSettings.SilentCrashes;
            return toolSettings;
        }
        #endregion
        #region NoGraphics
        /// <summary>
        ///   <p><em>Sets <see cref="UnityReturnLicenseSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings SetNoGraphics(this UnityReturnLicenseSettings toolSettings, bool? noGraphics)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = noGraphics;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityReturnLicenseSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ResetNoGraphics(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityReturnLicenseSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings EnableNoGraphics(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityReturnLicenseSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings DisableNoGraphics(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityReturnLicenseSettings.NoGraphics"/></em></p>
        ///   <p>When running in batch mode, do not initialize the graphics device at all. This makes it possible to run your automated workflows on machines that don't even have a GPU (automated workflows only work when you have a window in focus, otherwise you can't send simulated input commands). Please note that <c>-nographics</c> does not allow you to bake GI on OSX, since Enlighten requires GPU acceleration.</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ToggleNoGraphics(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoGraphics = !toolSettings.NoGraphics;
            return toolSettings;
        }
        #endregion
        #region Quit
        /// <summary>
        ///   <p><em>Sets <see cref="UnityReturnLicenseSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings SetQuit(this UnityReturnLicenseSettings toolSettings, bool? quit)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = quit;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityReturnLicenseSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ResetQuit(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityReturnLicenseSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings EnableQuit(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityReturnLicenseSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings DisableQuit(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityReturnLicenseSettings.Quit"/></em></p>
        ///   <p>Quit the Unity Editor after other commands have finished executing. Note that this can cause error messages to be hidden (however, they still appear in the Editor.log file).</p>
        /// </summary>
        [Pure]
        public static UnityReturnLicenseSettings ToggleQuit(this UnityReturnLicenseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quit = !toolSettings.Quit;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region UnityBaseSettingsExtensions
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class UnityBaseSettingsExtensions
    {
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="UnityBaseSettings.LogFile"/></em></p>
        ///   <p>Specify where the Editor or Windows/Linux/OSX standalone log file are written.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings SetLogFile(this UnityBaseSettings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityBaseSettings.LogFile"/></em></p>
        ///   <p>Specify where the Editor or Windows/Linux/OSX standalone log file are written.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings ResetLogFile(this UnityBaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region MinimalOutput
        /// <summary>
        ///   <p><em>Sets <see cref="UnityBaseSettings.MinimalOutput"/></em></p>
        ///   <p>(experimental) If set to true only warnings and errors will be printed to the output.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings SetMinimalOutput(this UnityBaseSettings toolSettings, bool? minimalOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimalOutput = minimalOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="UnityBaseSettings.MinimalOutput"/></em></p>
        ///   <p>(experimental) If set to true only warnings and errors will be printed to the output.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings ResetMinimalOutput(this UnityBaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimalOutput = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="UnityBaseSettings.MinimalOutput"/></em></p>
        ///   <p>(experimental) If set to true only warnings and errors will be printed to the output.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings EnableMinimalOutput(this UnityBaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimalOutput = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="UnityBaseSettings.MinimalOutput"/></em></p>
        ///   <p>(experimental) If set to true only warnings and errors will be printed to the output.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings DisableMinimalOutput(this UnityBaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimalOutput = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="UnityBaseSettings.MinimalOutput"/></em></p>
        ///   <p>(experimental) If set to true only warnings and errors will be printed to the output.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings ToggleMinimalOutput(this UnityBaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MinimalOutput = !toolSettings.MinimalOutput;
            return toolSettings;
        }
        #endregion
        #region StableExitCodes
        /// <summary>
        ///   <p><em>Sets <see cref="UnityBaseSettings.StableExitCodes"/> to a new list</em></p>
        ///   <p>Define exit codes which will not fail the build.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings SetStableExitCodes(this UnityBaseSettings toolSettings, params int[] stableExitCodes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StableExitCodesInternal = stableExitCodes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="UnityBaseSettings.StableExitCodes"/> to a new list</em></p>
        ///   <p>Define exit codes which will not fail the build.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings SetStableExitCodes(this UnityBaseSettings toolSettings, IEnumerable<int> stableExitCodes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StableExitCodesInternal = stableExitCodes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnityBaseSettings.StableExitCodes"/></em></p>
        ///   <p>Define exit codes which will not fail the build.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings AddStableExitCodes(this UnityBaseSettings toolSettings, params int[] stableExitCodes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StableExitCodesInternal.AddRange(stableExitCodes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="UnityBaseSettings.StableExitCodes"/></em></p>
        ///   <p>Define exit codes which will not fail the build.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings AddStableExitCodes(this UnityBaseSettings toolSettings, IEnumerable<int> stableExitCodes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StableExitCodesInternal.AddRange(stableExitCodes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="UnityBaseSettings.StableExitCodes"/></em></p>
        ///   <p>Define exit codes which will not fail the build.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings ClearStableExitCodes(this UnityBaseSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StableExitCodesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnityBaseSettings.StableExitCodes"/></em></p>
        ///   <p>Define exit codes which will not fail the build.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings RemoveStableExitCodes(this UnityBaseSettings toolSettings, params int[] stableExitCodes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(stableExitCodes);
            toolSettings.StableExitCodesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="UnityBaseSettings.StableExitCodes"/></em></p>
        ///   <p>Define exit codes which will not fail the build.</p>
        /// </summary>
        [Pure]
        public static UnityBaseSettings RemoveStableExitCodes(this UnityBaseSettings toolSettings, IEnumerable<int> stableExitCodes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<int>(stableExitCodes);
            toolSettings.StableExitCodesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region UnityBuildTarget
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<UnityBuildTarget>))]
    public partial class UnityBuildTarget : Enumeration
    {
        public static UnityBuildTarget standalone = (UnityBuildTarget) "standalone";
        public static UnityBuildTarget Win = (UnityBuildTarget) "Win";
        public static UnityBuildTarget Win64 = (UnityBuildTarget) "Win64";
        public static UnityBuildTarget OSXUniversal = (UnityBuildTarget) "OSXUniversal";
        public static UnityBuildTarget Linux = (UnityBuildTarget) "Linux";
        public static UnityBuildTarget Linux64 = (UnityBuildTarget) "Linux64";
        public static UnityBuildTarget LinuxUniversal = (UnityBuildTarget) "LinuxUniversal";
        public static UnityBuildTarget iOS = (UnityBuildTarget) "iOS";
        public static UnityBuildTarget Android = (UnityBuildTarget) "Android";
        public static UnityBuildTarget Web = (UnityBuildTarget) "Web";
        public static UnityBuildTarget WebStreamed = (UnityBuildTarget) "WebStreamed";
        public static UnityBuildTarget WebGL = (UnityBuildTarget) "WebGL";
        public static UnityBuildTarget XboxOne = (UnityBuildTarget) "XboxOne";
        public static UnityBuildTarget PS4 = (UnityBuildTarget) "PS4";
        public static UnityBuildTarget PSP2 = (UnityBuildTarget) "PSP2";
        public static UnityBuildTarget WindowsStoreApps = (UnityBuildTarget) "WindowsStoreApps";
        public static UnityBuildTarget Switch = (UnityBuildTarget) "Switch";
        public static UnityBuildTarget N3DS = (UnityBuildTarget) "N3DS";
        public static UnityBuildTarget tvOS = (UnityBuildTarget) "tvOS";
        public static UnityBuildTarget PSM = (UnityBuildTarget) "PSM";
        public static explicit operator UnityBuildTarget(string value)
        {
            return new UnityBuildTarget { Value = value };
        }
    }
    #endregion
    #region UnityGLCore
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
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
        public static explicit operator UnityGLCore(string value)
        {
            return new UnityGLCore { Value = value };
        }
    }
    #endregion
    #region UnityGLES
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<UnityGLES>))]
    public partial class UnityGLES : Enumeration
    {
        public static UnityGLES _30 = (UnityGLES) "30";
        public static UnityGLES _31 = (UnityGLES) "31";
        public static UnityGLES _32 = (UnityGLES) "32";
        public static explicit operator UnityGLES(string value)
        {
            return new UnityGLES { Value = value };
        }
    }
    #endregion
    #region UnityStackTraceLogType
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<UnityStackTraceLogType>))]
    public partial class UnityStackTraceLogType : Enumeration
    {
        public static UnityStackTraceLogType None = (UnityStackTraceLogType) "None";
        public static UnityStackTraceLogType Script_Only = (UnityStackTraceLogType) "Script Only";
        public static UnityStackTraceLogType Full = (UnityStackTraceLogType) "Full";
        public static explicit operator UnityStackTraceLogType(string value)
        {
            return new UnityStackTraceLogType { Value = value };
        }
    }
    #endregion
    #region UnityPlatformTextureFormat
    /// <summary>
    ///   Used within <see cref="UnityTasks"/>.
    /// </summary>
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
        public static explicit operator UnityPlatformTextureFormat(string value)
        {
            return new UnityPlatformTextureFormat { Value = value };
        }
    }
    #endregion
}

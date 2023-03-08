// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/ReSharper/ReSharper.json

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

namespace Nuke.Common.Tools.ReSharper
{
    /// <summary>
    ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(ReSharperPackageId)]
    public partial class ReSharperTasks
        : IRequireNuGetPackage
    {
        public const string ReSharperPackageId = "JetBrains.ReSharper.GlobalTools";
        /// <summary>
        ///   Path to the ReSharper executable.
        /// </summary>
        public static string ReSharperPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("RESHARPER_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("JetBrains.ReSharper.GlobalTools", "JetBrains.CommandLine.Products.dll");
        public static Action<OutputType, string> ReSharperLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> ReSharper(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(ReSharperPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? ReSharperLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperInspectCodeSettings.TargetPath"/></li>
        ///     <li><c>--absolute-paths</c> via <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></li>
        ///     <li><c>--caches-home</c> via <see cref="ReSharperInspectCodeSettings.CachesHome"/></li>
        ///     <li><c>--config</c> via <see cref="ReSharperInspectCodeSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="ReSharperInspectCodeSettings.CreateConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="ReSharperInspectCodeSettings.Debug"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dotnetcore</c> via <see cref="ReSharperInspectCodeSettings.DotNetCore"/></li>
        ///     <li><c>--dotnetcoresdk</c> via <see cref="ReSharperInspectCodeSettings.DotNetCoreSdk"/></li>
        ///     <li><c>--dumpIssuesTypes</c> via <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></li>
        ///     <li><c>--exclude</c> via <see cref="ReSharperInspectCodeSettings.Exclude"/></li>
        ///     <li><c>--format</c> via <see cref="ReSharperInspectCodeSettings.Format"/></li>
        ///     <li><c>--include</c> via <see cref="ReSharperInspectCodeSettings.Include"/></li>
        ///     <li><c>--jobs</c> via <see cref="ReSharperInspectCodeSettings.Jobs"/></li>
        ///     <li><c>--mono</c> via <see cref="ReSharperInspectCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--no-swea</c> via <see cref="ReSharperInspectCodeSettings.NoSwea"/></li>
        ///     <li><c>--output</c> via <see cref="ReSharperInspectCodeSettings.Output"/></li>
        ///     <li><c>--project</c> via <see cref="ReSharperInspectCodeSettings.Project"/></li>
        ///     <li><c>--properties</c> via <see cref="ReSharperInspectCodeSettings.Properties"/></li>
        ///     <li><c>--settings</c> via <see cref="ReSharperInspectCodeSettings.Settings"/></li>
        ///     <li><c>--severity</c> via <see cref="ReSharperInspectCodeSettings.Severity"/></li>
        ///     <li><c>--targets-for-items</c> via <see cref="ReSharperInspectCodeSettings.ItemTargets"/></li>
        ///     <li><c>--targets-for-references</c> via <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></li>
        ///     <li><c>--toolset</c> via <see cref="ReSharperInspectCodeSettings.Toolset"/></li>
        ///     <li><c>--toolset-path</c> via <see cref="ReSharperInspectCodeSettings.ToolsetPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="ReSharperInspectCodeSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ReSharperInspectCode(ReSharperInspectCodeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ReSharperInspectCodeSettings();
            PreProcess(ref toolSettings);
            using var process = StartProcess(toolSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
            return process.Output;
        }
        /// <summary>
        ///   <p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperInspectCodeSettings.TargetPath"/></li>
        ///     <li><c>--absolute-paths</c> via <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></li>
        ///     <li><c>--caches-home</c> via <see cref="ReSharperInspectCodeSettings.CachesHome"/></li>
        ///     <li><c>--config</c> via <see cref="ReSharperInspectCodeSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="ReSharperInspectCodeSettings.CreateConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="ReSharperInspectCodeSettings.Debug"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dotnetcore</c> via <see cref="ReSharperInspectCodeSettings.DotNetCore"/></li>
        ///     <li><c>--dotnetcoresdk</c> via <see cref="ReSharperInspectCodeSettings.DotNetCoreSdk"/></li>
        ///     <li><c>--dumpIssuesTypes</c> via <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></li>
        ///     <li><c>--exclude</c> via <see cref="ReSharperInspectCodeSettings.Exclude"/></li>
        ///     <li><c>--format</c> via <see cref="ReSharperInspectCodeSettings.Format"/></li>
        ///     <li><c>--include</c> via <see cref="ReSharperInspectCodeSettings.Include"/></li>
        ///     <li><c>--jobs</c> via <see cref="ReSharperInspectCodeSettings.Jobs"/></li>
        ///     <li><c>--mono</c> via <see cref="ReSharperInspectCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--no-swea</c> via <see cref="ReSharperInspectCodeSettings.NoSwea"/></li>
        ///     <li><c>--output</c> via <see cref="ReSharperInspectCodeSettings.Output"/></li>
        ///     <li><c>--project</c> via <see cref="ReSharperInspectCodeSettings.Project"/></li>
        ///     <li><c>--properties</c> via <see cref="ReSharperInspectCodeSettings.Properties"/></li>
        ///     <li><c>--settings</c> via <see cref="ReSharperInspectCodeSettings.Settings"/></li>
        ///     <li><c>--severity</c> via <see cref="ReSharperInspectCodeSettings.Severity"/></li>
        ///     <li><c>--targets-for-items</c> via <see cref="ReSharperInspectCodeSettings.ItemTargets"/></li>
        ///     <li><c>--targets-for-references</c> via <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></li>
        ///     <li><c>--toolset</c> via <see cref="ReSharperInspectCodeSettings.Toolset"/></li>
        ///     <li><c>--toolset-path</c> via <see cref="ReSharperInspectCodeSettings.ToolsetPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="ReSharperInspectCodeSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ReSharperInspectCode(Configure<ReSharperInspectCodeSettings> configurator)
        {
            return ReSharperInspectCode(configurator(new ReSharperInspectCodeSettings()));
        }
        /// <summary>
        ///   <p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperInspectCodeSettings.TargetPath"/></li>
        ///     <li><c>--absolute-paths</c> via <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></li>
        ///     <li><c>--caches-home</c> via <see cref="ReSharperInspectCodeSettings.CachesHome"/></li>
        ///     <li><c>--config</c> via <see cref="ReSharperInspectCodeSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="ReSharperInspectCodeSettings.CreateConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="ReSharperInspectCodeSettings.Debug"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dotnetcore</c> via <see cref="ReSharperInspectCodeSettings.DotNetCore"/></li>
        ///     <li><c>--dotnetcoresdk</c> via <see cref="ReSharperInspectCodeSettings.DotNetCoreSdk"/></li>
        ///     <li><c>--dumpIssuesTypes</c> via <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></li>
        ///     <li><c>--exclude</c> via <see cref="ReSharperInspectCodeSettings.Exclude"/></li>
        ///     <li><c>--format</c> via <see cref="ReSharperInspectCodeSettings.Format"/></li>
        ///     <li><c>--include</c> via <see cref="ReSharperInspectCodeSettings.Include"/></li>
        ///     <li><c>--jobs</c> via <see cref="ReSharperInspectCodeSettings.Jobs"/></li>
        ///     <li><c>--mono</c> via <see cref="ReSharperInspectCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--no-swea</c> via <see cref="ReSharperInspectCodeSettings.NoSwea"/></li>
        ///     <li><c>--output</c> via <see cref="ReSharperInspectCodeSettings.Output"/></li>
        ///     <li><c>--project</c> via <see cref="ReSharperInspectCodeSettings.Project"/></li>
        ///     <li><c>--properties</c> via <see cref="ReSharperInspectCodeSettings.Properties"/></li>
        ///     <li><c>--settings</c> via <see cref="ReSharperInspectCodeSettings.Settings"/></li>
        ///     <li><c>--severity</c> via <see cref="ReSharperInspectCodeSettings.Severity"/></li>
        ///     <li><c>--targets-for-items</c> via <see cref="ReSharperInspectCodeSettings.ItemTargets"/></li>
        ///     <li><c>--targets-for-references</c> via <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></li>
        ///     <li><c>--toolset</c> via <see cref="ReSharperInspectCodeSettings.Toolset"/></li>
        ///     <li><c>--toolset-path</c> via <see cref="ReSharperInspectCodeSettings.ToolsetPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="ReSharperInspectCodeSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ReSharperInspectCodeSettings Settings, IReadOnlyCollection<Output> Output)> ReSharperInspectCode(CombinatorialConfigure<ReSharperInspectCodeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ReSharperInspectCode, ReSharperLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperCleanupCodeSettings.TargetPath"/></li>
        ///     <li><c>--caches-home</c> via <see cref="ReSharperCleanupCodeSettings.CachesHome"/></li>
        ///     <li><c>--config</c> via <see cref="ReSharperCleanupCodeSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="ReSharperCleanupCodeSettings.CreateConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="ReSharperCleanupCodeSettings.Debug"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dotnetcore</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCore"/></li>
        ///     <li><c>--dotnetcoresdk</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCoreSdk"/></li>
        ///     <li><c>--exclude</c> via <see cref="ReSharperCleanupCodeSettings.Exclude"/></li>
        ///     <li><c>--include</c> via <see cref="ReSharperCleanupCodeSettings.Include"/></li>
        ///     <li><c>--mono</c> via <see cref="ReSharperCleanupCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--profile</c> via <see cref="ReSharperCleanupCodeSettings.Profile"/></li>
        ///     <li><c>--properties</c> via <see cref="ReSharperCleanupCodeSettings.Properties"/></li>
        ///     <li><c>--settings</c> via <see cref="ReSharperCleanupCodeSettings.Settings"/></li>
        ///     <li><c>--targets-for-items</c> via <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></li>
        ///     <li><c>--targets-for-references</c> via <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></li>
        ///     <li><c>--toolset</c> via <see cref="ReSharperCleanupCodeSettings.Toolset"/></li>
        ///     <li><c>--toolset-path</c> via <see cref="ReSharperCleanupCodeSettings.ToolsetPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="ReSharperCleanupCodeSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ReSharperCleanupCode(ReSharperCleanupCodeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ReSharperCleanupCodeSettings();
            PreProcess(ref toolSettings);
            using var process = StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperCleanupCodeSettings.TargetPath"/></li>
        ///     <li><c>--caches-home</c> via <see cref="ReSharperCleanupCodeSettings.CachesHome"/></li>
        ///     <li><c>--config</c> via <see cref="ReSharperCleanupCodeSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="ReSharperCleanupCodeSettings.CreateConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="ReSharperCleanupCodeSettings.Debug"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dotnetcore</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCore"/></li>
        ///     <li><c>--dotnetcoresdk</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCoreSdk"/></li>
        ///     <li><c>--exclude</c> via <see cref="ReSharperCleanupCodeSettings.Exclude"/></li>
        ///     <li><c>--include</c> via <see cref="ReSharperCleanupCodeSettings.Include"/></li>
        ///     <li><c>--mono</c> via <see cref="ReSharperCleanupCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--profile</c> via <see cref="ReSharperCleanupCodeSettings.Profile"/></li>
        ///     <li><c>--properties</c> via <see cref="ReSharperCleanupCodeSettings.Properties"/></li>
        ///     <li><c>--settings</c> via <see cref="ReSharperCleanupCodeSettings.Settings"/></li>
        ///     <li><c>--targets-for-items</c> via <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></li>
        ///     <li><c>--targets-for-references</c> via <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></li>
        ///     <li><c>--toolset</c> via <see cref="ReSharperCleanupCodeSettings.Toolset"/></li>
        ///     <li><c>--toolset-path</c> via <see cref="ReSharperCleanupCodeSettings.ToolsetPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="ReSharperCleanupCodeSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ReSharperCleanupCode(Configure<ReSharperCleanupCodeSettings> configurator)
        {
            return ReSharperCleanupCode(configurator(new ReSharperCleanupCodeSettings()));
        }
        /// <summary>
        ///   <p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperCleanupCodeSettings.TargetPath"/></li>
        ///     <li><c>--caches-home</c> via <see cref="ReSharperCleanupCodeSettings.CachesHome"/></li>
        ///     <li><c>--config</c> via <see cref="ReSharperCleanupCodeSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="ReSharperCleanupCodeSettings.CreateConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="ReSharperCleanupCodeSettings.Debug"/></li>
        ///     <li><c>--disable-settings-layers</c> via <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></li>
        ///     <li><c>--dotnetcore</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCore"/></li>
        ///     <li><c>--dotnetcoresdk</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCoreSdk"/></li>
        ///     <li><c>--exclude</c> via <see cref="ReSharperCleanupCodeSettings.Exclude"/></li>
        ///     <li><c>--include</c> via <see cref="ReSharperCleanupCodeSettings.Include"/></li>
        ///     <li><c>--mono</c> via <see cref="ReSharperCleanupCodeSettings.MonoPath"/></li>
        ///     <li><c>--no-buildin-settings</c> via <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></li>
        ///     <li><c>--profile</c> via <see cref="ReSharperCleanupCodeSettings.Profile"/></li>
        ///     <li><c>--properties</c> via <see cref="ReSharperCleanupCodeSettings.Properties"/></li>
        ///     <li><c>--settings</c> via <see cref="ReSharperCleanupCodeSettings.Settings"/></li>
        ///     <li><c>--targets-for-items</c> via <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></li>
        ///     <li><c>--targets-for-references</c> via <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></li>
        ///     <li><c>--toolset</c> via <see cref="ReSharperCleanupCodeSettings.Toolset"/></li>
        ///     <li><c>--toolset-path</c> via <see cref="ReSharperCleanupCodeSettings.ToolsetPath"/></li>
        ///     <li><c>--verbosity</c> via <see cref="ReSharperCleanupCodeSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ReSharperCleanupCodeSettings Settings, IReadOnlyCollection<Output> Output)> ReSharperCleanupCode(CombinatorialConfigure<ReSharperCleanupCodeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ReSharperCleanupCode, ReSharperLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;source&gt;</c> via <see cref="ReSharperDupFinderSettings.Source"/></li>
        ///     <li><c>--caches-home</c> via <see cref="ReSharperDupFinderSettings.CachesHome"/></li>
        ///     <li><c>--config</c> via <see cref="ReSharperDupFinderSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="ReSharperDupFinderSettings.CreateConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="ReSharperDupFinderSettings.Debug"/></li>
        ///     <li><c>--discard-cost</c> via <see cref="ReSharperDupFinderSettings.DiscardCost"/></li>
        ///     <li><c>--discard-fields</c> via <see cref="ReSharperDupFinderSettings.DiscardFields"/></li>
        ///     <li><c>--discard-literals</c> via <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></li>
        ///     <li><c>--discard-local-vars</c> via <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></li>
        ///     <li><c>--discard-types</c> via <see cref="ReSharperDupFinderSettings.DiscardTypes"/></li>
        ///     <li><c>--exclude</c> via <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></li>
        ///     <li><c>--exclude-by-comment</c> via <see cref="ReSharperDupFinderSettings.ExcludeComments"/></li>
        ///     <li><c>--exclude-code-regions</c> via <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></li>
        ///     <li><c>--normalize-types</c> via <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></li>
        ///     <li><c>--output</c> via <see cref="ReSharperDupFinderSettings.OutputFile"/></li>
        ///     <li><c>--properties</c> via <see cref="ReSharperDupFinderSettings.Properties"/></li>
        ///     <li><c>--show-text</c> via <see cref="ReSharperDupFinderSettings.ShowText"/></li>
        ///     <li><c>--verbosity</c> via <see cref="ReSharperDupFinderSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ReSharperDupFinder(ReSharperDupFinderSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ReSharperDupFinderSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;source&gt;</c> via <see cref="ReSharperDupFinderSettings.Source"/></li>
        ///     <li><c>--caches-home</c> via <see cref="ReSharperDupFinderSettings.CachesHome"/></li>
        ///     <li><c>--config</c> via <see cref="ReSharperDupFinderSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="ReSharperDupFinderSettings.CreateConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="ReSharperDupFinderSettings.Debug"/></li>
        ///     <li><c>--discard-cost</c> via <see cref="ReSharperDupFinderSettings.DiscardCost"/></li>
        ///     <li><c>--discard-fields</c> via <see cref="ReSharperDupFinderSettings.DiscardFields"/></li>
        ///     <li><c>--discard-literals</c> via <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></li>
        ///     <li><c>--discard-local-vars</c> via <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></li>
        ///     <li><c>--discard-types</c> via <see cref="ReSharperDupFinderSettings.DiscardTypes"/></li>
        ///     <li><c>--exclude</c> via <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></li>
        ///     <li><c>--exclude-by-comment</c> via <see cref="ReSharperDupFinderSettings.ExcludeComments"/></li>
        ///     <li><c>--exclude-code-regions</c> via <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></li>
        ///     <li><c>--normalize-types</c> via <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></li>
        ///     <li><c>--output</c> via <see cref="ReSharperDupFinderSettings.OutputFile"/></li>
        ///     <li><c>--properties</c> via <see cref="ReSharperDupFinderSettings.Properties"/></li>
        ///     <li><c>--show-text</c> via <see cref="ReSharperDupFinderSettings.ShowText"/></li>
        ///     <li><c>--verbosity</c> via <see cref="ReSharperDupFinderSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ReSharperDupFinder(Configure<ReSharperDupFinderSettings> configurator)
        {
            return ReSharperDupFinder(configurator(new ReSharperDupFinderSettings()));
        }
        /// <summary>
        ///   <p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;source&gt;</c> via <see cref="ReSharperDupFinderSettings.Source"/></li>
        ///     <li><c>--caches-home</c> via <see cref="ReSharperDupFinderSettings.CachesHome"/></li>
        ///     <li><c>--config</c> via <see cref="ReSharperDupFinderSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="ReSharperDupFinderSettings.CreateConfigFile"/></li>
        ///     <li><c>--debug</c> via <see cref="ReSharperDupFinderSettings.Debug"/></li>
        ///     <li><c>--discard-cost</c> via <see cref="ReSharperDupFinderSettings.DiscardCost"/></li>
        ///     <li><c>--discard-fields</c> via <see cref="ReSharperDupFinderSettings.DiscardFields"/></li>
        ///     <li><c>--discard-literals</c> via <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></li>
        ///     <li><c>--discard-local-vars</c> via <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></li>
        ///     <li><c>--discard-types</c> via <see cref="ReSharperDupFinderSettings.DiscardTypes"/></li>
        ///     <li><c>--exclude</c> via <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></li>
        ///     <li><c>--exclude-by-comment</c> via <see cref="ReSharperDupFinderSettings.ExcludeComments"/></li>
        ///     <li><c>--exclude-code-regions</c> via <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></li>
        ///     <li><c>--normalize-types</c> via <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></li>
        ///     <li><c>--output</c> via <see cref="ReSharperDupFinderSettings.OutputFile"/></li>
        ///     <li><c>--properties</c> via <see cref="ReSharperDupFinderSettings.Properties"/></li>
        ///     <li><c>--show-text</c> via <see cref="ReSharperDupFinderSettings.ShowText"/></li>
        ///     <li><c>--verbosity</c> via <see cref="ReSharperDupFinderSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ReSharperDupFinderSettings Settings, IReadOnlyCollection<Output> Output)> ReSharperDupFinder(CombinatorialConfigure<ReSharperDupFinderSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ReSharperDupFinder, ReSharperLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region ReSharperInspectCodeSettings
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ReSharperInspectCodeSettings : ReSharperSettingsBase
    {
        /// <summary>
        ///   Path to the ReSharper executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ReSharperTasks.ReSharperPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ReSharperTasks.ReSharperLogger;
        /// <summary>
        ///   Target path.
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   By default, InspectCode writes its output in <c>XML</c> format. If necessary, you can specify other output formats with this parameter.
        /// </summary>
        public virtual ReSharperFormat Format { get; internal set; }
        /// <summary>
        ///   By default, InspectCode uses heuristics to split its jobs and run them in parallel using as many threads/cores as available. If necessary, you can limit the number of threads.
        /// </summary>
        public virtual int? Jobs { get; internal set; }
        /// <summary>
        ///   By default, files in InspectCode's report are written with paths relative to the solution file. You can use this switch to have absolute paths in the report.
        /// </summary>
        public virtual bool? AbsolutePaths { get; internal set; }
        /// <summary>
        ///   Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c>
        /// </summary>
        public virtual string Project { get; internal set; }
        /// <summary>
        ///   Disables solution-wide analysis.
        /// </summary>
        public virtual bool? NoSwea { get; internal set; }
        /// <summary>
        ///   By default, InspectCode only reports issues with the severity level Suggestion and higher. This parameter lets you change the minimal reported severity level to <c>INFO</c>, <c>HINT</c>, <c>SUGGESTION</c>, <c>WARNING</c>, <c>ERROR</c>. For example, <c>-s=WARNING</c>.
        /// </summary>
        public virtual ReSharperSeverity Severity { get; internal set; }
        /// <summary>
        ///   Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.
        /// </summary>
        public virtual bool? DumpIssuesTypes { get; internal set; }
        /// <summary>
        ///   Default settings are overridden from the <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#solution-team-shared-layer">team-shared layer</a>, if it exists. If necessary, you can use this parameter to specify another <c>.DotSettings</c> file, which will override all other settings.
        /// </summary>
        public virtual string Settings { get; internal set; }
        /// <summary>
        ///   Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.
        /// </summary>
        public virtual IReadOnlyList<ReSharperSettingsLayers> DisableSettingsLayers => DisableSettingsLayersInternal.AsReadOnly();
        internal List<ReSharperSettingsLayers> DisableSettingsLayersInternal { get; set; } = new List<ReSharperSettingsLayers>();
        /// <summary>
        ///   Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c>
        /// </summary>
        public virtual bool? NoBuiltinSettings { get; internal set; }
        /// <summary>
        ///   Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.
        /// </summary>
        public virtual string CachesHome { get; internal set; }
        /// <summary>
        ///   Used to save the current parameters to a configuration file.
        /// </summary>
        public virtual string CreateConfigFile { get; internal set; }
        /// <summary>
        ///   Used to load the parameters described above from a configuration file.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.
        /// </summary>
        public virtual ReSharperVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.
        /// </summary>
        public virtual ReSharperMSBuildToolset Toolset { get; internal set; }
        /// <summary>
        ///   Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c>
        /// </summary>
        public virtual string ToolsetPath { get; internal set; }
        /// <summary>
        ///   By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.
        /// </summary>
        public virtual string DotNetCore { get; internal set; }
        /// <summary>
        ///   Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.
        /// </summary>
        public virtual string DotNetCoreSdk { get; internal set; }
        /// <summary>
        ///   Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c>
        /// </summary>
        public virtual string MonoPath { get; internal set; }
        /// <summary>
        ///   Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.
        /// </summary>
        public virtual IReadOnlyList<string> ReferenceTargets => ReferenceTargetsInternal.AsReadOnly();
        internal List<string> ReferenceTargetsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.
        /// </summary>
        public virtual IReadOnlyList<string> ItemTargets => ItemTargetsInternal.AsReadOnly();
        internal List<string> ItemTargetsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.
        /// </summary>
        public virtual IReadOnlyList<string> Include => IncludeInternal.AsReadOnly();
        internal List<string> IncludeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.
        /// </summary>
        public virtual IReadOnlyList<string> Exclude => ExcludeInternal.AsReadOnly();
        internal List<string> ExcludeInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("inspectcode")
              .Add("{value}", TargetPath)
              .Add("--output={value}", Output)
              .Add("--format={value}", Format)
              .Add("--jobs={value}", Jobs)
              .Add("--absolute-paths", AbsolutePaths)
              .Add("--project={value}", Project)
              .Add("--no-swea", NoSwea)
              .Add("--severity={value}", Severity)
              .Add("--dumpIssuesTypes", DumpIssuesTypes)
              .Add("--settings={value}", Settings)
              .Add("--disable-settings-layers={value}", DisableSettingsLayers, separator: ';')
              .Add("--no-buildin-settings", NoBuiltinSettings)
              .Add("--caches-home={value}", CachesHome)
              .Add("--config-create={value}", CreateConfigFile)
              .Add("--config={value}", ConfigFile)
              .Add("--verbosity={value}", Verbosity)
              .Add("--debug", Debug)
              .Add("--properties={value}", Properties, "{key}={value}")
              .Add("--toolset={value}", Toolset)
              .Add("--toolset-path={value}", ToolsetPath)
              .Add("--dotnetcore={value}", DotNetCore)
              .Add("--dotnetcoresdk={value}", DotNetCoreSdk)
              .Add("--mono={value}", MonoPath)
              .Add("--targets-for-references={value}", ReferenceTargets, separator: ';')
              .Add("--targets-for-items={value}", ItemTargets, separator: ';')
              .Add("--include={value}", Include, separator: ';')
              .Add("--exclude={value}", Exclude, separator: ';');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ReSharperCleanupCodeSettings
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ReSharperCleanupCodeSettings : ReSharperSettingsBase
    {
        /// <summary>
        ///   Path to the ReSharper executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ReSharperTasks.ReSharperPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ReSharperTasks.ReSharperLogger;
        /// <summary>
        ///   Target path.
        /// </summary>
        public virtual string TargetPath { get; internal set; }
        /// <summary>
        ///   A code cleanup profile that lists cleanup tasks to execute.<p/>By default, CleanupCode will apply code cleanup tasks specified in the <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#profiles">Built-in: Full Cleanup profile</a>, that is all <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#tasks">available cleanup tasks</a> tasks except <a href="https://www.jetbrains.com/help/resharper/File_Header_Style.html">updating file header</a>. 
        /// </summary>
        public virtual string Profile { get; internal set; }
        /// <summary>
        ///   Default settings are overridden from the <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#solution-team-shared-layer">team-shared layer</a>, if it exists. If necessary, you can use this parameter to specify another <c>.DotSettings</c> file, which will override all other settings.
        /// </summary>
        public virtual string Settings { get; internal set; }
        /// <summary>
        ///   Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.
        /// </summary>
        public virtual IReadOnlyList<ReSharperSettingsLayers> DisableSettingsLayers => DisableSettingsLayersInternal.AsReadOnly();
        internal List<ReSharperSettingsLayers> DisableSettingsLayersInternal { get; set; } = new List<ReSharperSettingsLayers>();
        /// <summary>
        ///   Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c>
        /// </summary>
        public virtual bool? NoBuiltinSettings { get; internal set; }
        /// <summary>
        ///   Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.
        /// </summary>
        public virtual string CachesHome { get; internal set; }
        /// <summary>
        ///   Used to save the current parameters to a configuration file.
        /// </summary>
        public virtual string CreateConfigFile { get; internal set; }
        /// <summary>
        ///   Used to load the parameters described above from a configuration file.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.
        /// </summary>
        public virtual ReSharperVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.
        /// </summary>
        public virtual ReSharperMSBuildToolset Toolset { get; internal set; }
        /// <summary>
        ///   Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c>
        /// </summary>
        public virtual string ToolsetPath { get; internal set; }
        /// <summary>
        ///   By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.
        /// </summary>
        public virtual string DotNetCore { get; internal set; }
        /// <summary>
        ///   Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.
        /// </summary>
        public virtual string DotNetCoreSdk { get; internal set; }
        /// <summary>
        ///   Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c>
        /// </summary>
        public virtual string MonoPath { get; internal set; }
        /// <summary>
        ///   Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.
        /// </summary>
        public virtual IReadOnlyList<string> ReferenceTargets => ReferenceTargetsInternal.AsReadOnly();
        internal List<string> ReferenceTargetsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.
        /// </summary>
        public virtual IReadOnlyList<string> ItemTargets => ItemTargetsInternal.AsReadOnly();
        internal List<string> ItemTargetsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.
        /// </summary>
        public virtual IReadOnlyList<string> Include => IncludeInternal.AsReadOnly();
        internal List<string> IncludeInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.
        /// </summary>
        public virtual IReadOnlyList<string> Exclude => ExcludeInternal.AsReadOnly();
        internal List<string> ExcludeInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("cleanupcode")
              .Add("{value}", TargetPath)
              .Add("--profile={value}", Profile)
              .Add("--settings={value}", Settings)
              .Add("--disable-settings-layers={value}", DisableSettingsLayers, separator: ';')
              .Add("--no-buildin-settings", NoBuiltinSettings)
              .Add("--caches-home={value}", CachesHome)
              .Add("--config-create={value}", CreateConfigFile)
              .Add("--config={value}", ConfigFile)
              .Add("--verbosity={value}", Verbosity)
              .Add("--debug", Debug)
              .Add("--properties={value}", Properties, "{key}={value}")
              .Add("--toolset={value}", Toolset)
              .Add("--toolset-path={value}", ToolsetPath)
              .Add("--dotnetcore={value}", DotNetCore)
              .Add("--dotnetcoresdk={value}", DotNetCoreSdk)
              .Add("--mono={value}", MonoPath)
              .Add("--targets-for-references={value}", ReferenceTargets, separator: ';')
              .Add("--targets-for-items={value}", ItemTargets, separator: ';')
              .Add("--include={value}", Include, separator: ';')
              .Add("--exclude={value}", Exclude, separator: ';');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ReSharperDupFinderSettings
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ReSharperDupFinderSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the ReSharper executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ReSharperTasks.ReSharperPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ReSharperTasks.ReSharperLogger;
        /// <summary>
        ///   Defines files included into the duplicates search. Use Visual Studio solution or project files, Ant-like wildcards or specific source file and folder names. Paths should be either absolute or relative to the working directory.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   Lets you set the output file.
        /// </summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary>
        ///   Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeFiles => ExcludeFilesInternal.AsReadOnly();
        internal List<string> ExcludeFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Allows excluding files that have a matching substrings in the opening comments.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeComments => ExcludeCommentsInternal.AsReadOnly();
        internal List<string> ExcludeCommentsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeCodeRegions => ExcludeCodeRegionsInternal.AsReadOnly();
        internal List<string> ExcludeCodeRegionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.
        /// </summary>
        public virtual bool? DiscardFields { get; internal set; }
        /// <summary>
        ///   Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.
        /// </summary>
        public virtual bool? DiscardLiterals { get; internal set; }
        /// <summary>
        ///   Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.
        /// </summary>
        public virtual bool? DiscardLocalVars { get; internal set; }
        /// <summary>
        ///   Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.
        /// </summary>
        public virtual bool? DiscardTypes { get; internal set; }
        /// <summary>
        ///   Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.
        /// </summary>
        public virtual int? DiscardCost { get; internal set; }
        /// <summary>
        ///   Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Allows normalizing type names to the last subtype in the output (default: <c>false</c>).
        /// </summary>
        public virtual bool? NormalizeTypes { get; internal set; }
        /// <summary>
        ///   If you use this parameter, the detected duplicate fragments will be embedded into the report.
        /// </summary>
        public virtual bool? ShowText { get; internal set; }
        /// <summary>
        ///   Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.
        /// </summary>
        public virtual string CachesHome { get; internal set; }
        /// <summary>
        ///   Used to save the current parameters to a configuration file.
        /// </summary>
        public virtual string CreateConfigFile { get; internal set; }
        /// <summary>
        ///   Used to load the parameters described above from a configuration file.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        /// <summary>
        ///   By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.
        /// </summary>
        public virtual ReSharperVerbosity Verbosity { get; internal set; }
        /// <summary>
        ///   use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("dupfinder")
              .Add("{value}", Source)
              .Add("--output={value}", OutputFile)
              .Add("--exclude={value}", ExcludeFiles, separator: ';')
              .Add("--exclude-by-comment={value}", ExcludeComments, separator: ';')
              .Add("--exclude-code-regions={value}", ExcludeCodeRegions, separator: ';')
              .Add("--discard-fields={value}", DiscardFields)
              .Add("--discard-literals={value}", DiscardLiterals)
              .Add("--discard-local-vars={value}", DiscardLocalVars)
              .Add("--discard-types={value}", DiscardTypes)
              .Add("--discard-cost={value}", DiscardCost)
              .Add("--properties:{value}", Properties, "{key}={value}")
              .Add("--normalize-types={value}", NormalizeTypes)
              .Add("--show-text={value}", ShowText)
              .Add("--caches-home={value}", CachesHome)
              .Add("--config-create={value}", CreateConfigFile)
              .Add("--config={value}", ConfigFile)
              .Add("--verbosity={value}", Verbosity)
              .Add("--debug", Debug);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ReSharperSettingsBase
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ReSharperSettingsBase : ToolSettings
    {
        /// <summary>
        ///   Allows adding ReSharper plugins that will get included during execution. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>ReSharperPluginLatest</c> or <c>null</c> will download the latest version.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Plugins => PluginsInternal.AsReadOnly();
        internal Dictionary<string, string> PluginsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
    #endregion
    #region ReSharperInspectCodeSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ReSharperInspectCodeSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.TargetPath"/></em></p>
        ///   <p>Target path.</p>
        /// </summary>
        [Pure]
        public static T SetTargetPath<T>(this T toolSettings, string targetPath) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.TargetPath"/></em></p>
        ///   <p>Target path.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPath<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Output"/></em></p>
        ///   <p>Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.Output"/></em></p>
        ///   <p>Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Format
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Format"/></em></p>
        ///   <p>By default, InspectCode writes its output in <c>XML</c> format. If necessary, you can specify other output formats with this parameter.</p>
        /// </summary>
        [Pure]
        public static T SetFormat<T>(this T toolSettings, ReSharperFormat format) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = format;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.Format"/></em></p>
        ///   <p>By default, InspectCode writes its output in <c>XML</c> format. If necessary, you can specify other output formats with this parameter.</p>
        /// </summary>
        [Pure]
        public static T ResetFormat<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Format = null;
            return toolSettings;
        }
        #endregion
        #region Jobs
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Jobs"/></em></p>
        ///   <p>By default, InspectCode uses heuristics to split its jobs and run them in parallel using as many threads/cores as available. If necessary, you can limit the number of threads.</p>
        /// </summary>
        [Pure]
        public static T SetJobs<T>(this T toolSettings, int? jobs) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Jobs = jobs;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.Jobs"/></em></p>
        ///   <p>By default, InspectCode uses heuristics to split its jobs and run them in parallel using as many threads/cores as available. If necessary, you can limit the number of threads.</p>
        /// </summary>
        [Pure]
        public static T ResetJobs<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Jobs = null;
            return toolSettings;
        }
        #endregion
        #region AbsolutePaths
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></em></p>
        ///   <p>By default, files in InspectCode's report are written with paths relative to the solution file. You can use this switch to have absolute paths in the report.</p>
        /// </summary>
        [Pure]
        public static T SetAbsolutePaths<T>(this T toolSettings, bool? absolutePaths) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AbsolutePaths = absolutePaths;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></em></p>
        ///   <p>By default, files in InspectCode's report are written with paths relative to the solution file. You can use this switch to have absolute paths in the report.</p>
        /// </summary>
        [Pure]
        public static T ResetAbsolutePaths<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AbsolutePaths = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></em></p>
        ///   <p>By default, files in InspectCode's report are written with paths relative to the solution file. You can use this switch to have absolute paths in the report.</p>
        /// </summary>
        [Pure]
        public static T EnableAbsolutePaths<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AbsolutePaths = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></em></p>
        ///   <p>By default, files in InspectCode's report are written with paths relative to the solution file. You can use this switch to have absolute paths in the report.</p>
        /// </summary>
        [Pure]
        public static T DisableAbsolutePaths<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AbsolutePaths = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></em></p>
        ///   <p>By default, files in InspectCode's report are written with paths relative to the solution file. You can use this switch to have absolute paths in the report.</p>
        /// </summary>
        [Pure]
        public static T ToggleAbsolutePaths<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AbsolutePaths = !toolSettings.AbsolutePaths;
            return toolSettings;
        }
        #endregion
        #region Project
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Project"/></em></p>
        ///   <p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p>
        /// </summary>
        [Pure]
        public static T SetProject<T>(this T toolSettings, string project) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = project;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.Project"/></em></p>
        ///   <p>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></p>
        /// </summary>
        [Pure]
        public static T ResetProject<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Project = null;
            return toolSettings;
        }
        #endregion
        #region NoSwea
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.NoSwea"/></em></p>
        ///   <p>Disables solution-wide analysis.</p>
        /// </summary>
        [Pure]
        public static T SetNoSwea<T>(this T toolSettings, bool? noSwea) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = noSwea;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.NoSwea"/></em></p>
        ///   <p>Disables solution-wide analysis.</p>
        /// </summary>
        [Pure]
        public static T ResetNoSwea<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperInspectCodeSettings.NoSwea"/></em></p>
        ///   <p>Disables solution-wide analysis.</p>
        /// </summary>
        [Pure]
        public static T EnableNoSwea<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperInspectCodeSettings.NoSwea"/></em></p>
        ///   <p>Disables solution-wide analysis.</p>
        /// </summary>
        [Pure]
        public static T DisableNoSwea<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperInspectCodeSettings.NoSwea"/></em></p>
        ///   <p>Disables solution-wide analysis.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoSwea<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoSwea = !toolSettings.NoSwea;
            return toolSettings;
        }
        #endregion
        #region Severity
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Severity"/></em></p>
        ///   <p>By default, InspectCode only reports issues with the severity level Suggestion and higher. This parameter lets you change the minimal reported severity level to <c>INFO</c>, <c>HINT</c>, <c>SUGGESTION</c>, <c>WARNING</c>, <c>ERROR</c>. For example, <c>-s=WARNING</c>.</p>
        /// </summary>
        [Pure]
        public static T SetSeverity<T>(this T toolSettings, ReSharperSeverity severity) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Severity = severity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.Severity"/></em></p>
        ///   <p>By default, InspectCode only reports issues with the severity level Suggestion and higher. This parameter lets you change the minimal reported severity level to <c>INFO</c>, <c>HINT</c>, <c>SUGGESTION</c>, <c>WARNING</c>, <c>ERROR</c>. For example, <c>-s=WARNING</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetSeverity<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Severity = null;
            return toolSettings;
        }
        #endregion
        #region DumpIssuesTypes
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></em></p>
        ///   <p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p>
        /// </summary>
        [Pure]
        public static T SetDumpIssuesTypes<T>(this T toolSettings, bool? dumpIssuesTypes) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = dumpIssuesTypes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></em></p>
        ///   <p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p>
        /// </summary>
        [Pure]
        public static T ResetDumpIssuesTypes<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></em></p>
        ///   <p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p>
        /// </summary>
        [Pure]
        public static T EnableDumpIssuesTypes<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></em></p>
        ///   <p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p>
        /// </summary>
        [Pure]
        public static T DisableDumpIssuesTypes<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></em></p>
        ///   <p>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</p>
        /// </summary>
        [Pure]
        public static T ToggleDumpIssuesTypes<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DumpIssuesTypes = !toolSettings.DumpIssuesTypes;
            return toolSettings;
        }
        #endregion
        #region Settings
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Settings"/></em></p>
        ///   <p>Default settings are overridden from the <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#solution-team-shared-layer">team-shared layer</a>, if it exists. If necessary, you can use this parameter to specify another <c>.DotSettings</c> file, which will override all other settings.</p>
        /// </summary>
        [Pure]
        public static T SetSettings<T>(this T toolSettings, string settings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Settings = settings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.Settings"/></em></p>
        ///   <p>Default settings are overridden from the <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#solution-team-shared-layer">team-shared layer</a>, if it exists. If necessary, you can use this parameter to specify another <c>.DotSettings</c> file, which will override all other settings.</p>
        /// </summary>
        [Pure]
        public static T ResetSettings<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Settings = null;
            return toolSettings;
        }
        #endregion
        #region DisableSettingsLayers
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/> to a new list</em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDisableSettingsLayers<T>(this T toolSettings, params ReSharperSettingsLayers[] disableSettingsLayers) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/> to a new list</em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDisableSettingsLayers<T>(this T toolSettings, IEnumerable<ReSharperSettingsLayers> disableSettingsLayers) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T AddDisableSettingsLayers<T>(this T toolSettings, params ReSharperSettingsLayers[] disableSettingsLayers) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T AddDisableSettingsLayers<T>(this T toolSettings, IEnumerable<ReSharperSettingsLayers> disableSettingsLayers) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearDisableSettingsLayers<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveDisableSettingsLayers<T>(this T toolSettings, params ReSharperSettingsLayers[] disableSettingsLayers) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<ReSharperSettingsLayers>(disableSettingsLayers);
            toolSettings.DisableSettingsLayersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveDisableSettingsLayers<T>(this T toolSettings, IEnumerable<ReSharperSettingsLayers> disableSettingsLayers) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<ReSharperSettingsLayers>(disableSettingsLayers);
            toolSettings.DisableSettingsLayersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoBuiltinSettings
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T SetNoBuiltinSettings<T>(this T toolSettings, bool? noBuiltinSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = noBuiltinSettings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T ResetNoBuiltinSettings<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T EnableNoBuiltinSettings<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T DisableNoBuiltinSettings<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T ToggleNoBuiltinSettings<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = !toolSettings.NoBuiltinSettings;
            return toolSettings;
        }
        #endregion
        #region CachesHome
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static T SetCachesHome<T>(this T toolSettings, string cachesHome) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = cachesHome;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static T ResetCachesHome<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = null;
            return toolSettings;
        }
        #endregion
        #region CreateConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.CreateConfigFile"/></em></p>
        ///   <p>Used to save the current parameters to a configuration file.</p>
        /// </summary>
        [Pure]
        public static T SetCreateConfigFile<T>(this T toolSettings, string createConfigFile) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateConfigFile = createConfigFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.CreateConfigFile"/></em></p>
        ///   <p>Used to save the current parameters to a configuration file.</p>
        /// </summary>
        [Pure]
        public static T ResetCreateConfigFile<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.ConfigFile"/></em></p>
        ///   <p>Used to load the parameters described above from a configuration file.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.ConfigFile"/></em></p>
        ///   <p>Used to load the parameters described above from a configuration file.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Verbosity"/></em></p>
        ///   <p>By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, ReSharperVerbosity verbosity) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.Verbosity"/></em></p>
        ///   <p>By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperInspectCodeSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperInspectCodeSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperInspectCodeSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, string> properties) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperInspectCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="ReSharperInspectCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="ReSharperInspectCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="ReSharperInspectCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
        #region Toolset
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Toolset"/></em></p>
        ///   <p>Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.</p>
        /// </summary>
        [Pure]
        public static T SetToolset<T>(this T toolSettings, ReSharperMSBuildToolset toolset) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = toolset;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.Toolset"/></em></p>
        ///   <p>Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.</p>
        /// </summary>
        [Pure]
        public static T ResetToolset<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = null;
            return toolSettings;
        }
        #endregion
        #region ToolsetPath
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.ToolsetPath"/></em></p>
        ///   <p>Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c></p>
        /// </summary>
        [Pure]
        public static T SetToolsetPath<T>(this T toolSettings, string toolsetPath) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolsetPath = toolsetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.ToolsetPath"/></em></p>
        ///   <p>Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c></p>
        /// </summary>
        [Pure]
        public static T ResetToolsetPath<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolsetPath = null;
            return toolSettings;
        }
        #endregion
        #region DotNetCore
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.DotNetCore"/></em></p>
        ///   <p>By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDotNetCore<T>(this T toolSettings, string dotNetCore) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCore = dotNetCore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.DotNetCore"/></em></p>
        ///   <p>By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDotNetCore<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCore = null;
            return toolSettings;
        }
        #endregion
        #region DotNetCoreSdk
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.DotNetCoreSdk"/></em></p>
        ///   <p>Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.</p>
        /// </summary>
        [Pure]
        public static T SetDotNetCoreSdk<T>(this T toolSettings, string dotNetCoreSdk) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCoreSdk = dotNetCoreSdk;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.DotNetCoreSdk"/></em></p>
        ///   <p>Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.</p>
        /// </summary>
        [Pure]
        public static T ResetDotNetCoreSdk<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCoreSdk = null;
            return toolSettings;
        }
        #endregion
        #region MonoPath
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.MonoPath"/></em></p>
        ///   <p>Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c></p>
        /// </summary>
        [Pure]
        public static T SetMonoPath<T>(this T toolSettings, string monoPath) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MonoPath = monoPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperInspectCodeSettings.MonoPath"/></em></p>
        ///   <p>Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c></p>
        /// </summary>
        [Pure]
        public static T ResetMonoPath<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MonoPath = null;
            return toolSettings;
        }
        #endregion
        #region ReferenceTargets
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetReferenceTargets<T>(this T toolSettings, params string[] referenceTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal = referenceTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetReferenceTargets<T>(this T toolSettings, IEnumerable<string> referenceTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal = referenceTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddReferenceTargets<T>(this T toolSettings, params string[] referenceTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal.AddRange(referenceTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddReferenceTargets<T>(this T toolSettings, IEnumerable<string> referenceTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal.AddRange(referenceTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearReferenceTargets<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveReferenceTargets<T>(this T toolSettings, params string[] referenceTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referenceTargets);
            toolSettings.ReferenceTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveReferenceTargets<T>(this T toolSettings, IEnumerable<string> referenceTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referenceTargets);
            toolSettings.ReferenceTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ItemTargets
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.ItemTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetItemTargets<T>(this T toolSettings, params string[] itemTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal = itemTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.ItemTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetItemTargets<T>(this T toolSettings, IEnumerable<string> itemTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal = itemTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperInspectCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddItemTargets<T>(this T toolSettings, params string[] itemTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal.AddRange(itemTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperInspectCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddItemTargets<T>(this T toolSettings, IEnumerable<string> itemTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal.AddRange(itemTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperInspectCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearItemTargets<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperInspectCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveItemTargets<T>(this T toolSettings, params string[] itemTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(itemTargets);
            toolSettings.ItemTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperInspectCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveItemTargets<T>(this T toolSettings, IEnumerable<string> itemTargets) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(itemTargets);
            toolSettings.ItemTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Include
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Include"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetInclude<T>(this T toolSettings, params string[] include) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Include"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetInclude<T>(this T toolSettings, IEnumerable<string> include) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperInspectCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddInclude<T>(this T toolSettings, params string[] include) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperInspectCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddInclude<T>(this T toolSettings, IEnumerable<string> include) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperInspectCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T ClearInclude<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperInspectCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveInclude<T>(this T toolSettings, params string[] include) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperInspectCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveInclude<T>(this T toolSettings, IEnumerable<string> include) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Exclude
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Exclude"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetExclude<T>(this T toolSettings, params string[] exclude) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperInspectCodeSettings.Exclude"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperInspectCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddExclude<T>(this T toolSettings, params string[] exclude) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperInspectCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperInspectCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T ClearExclude<T>(this T toolSettings) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperInspectCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveExclude<T>(this T toolSettings, params string[] exclude) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperInspectCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : ReSharperInspectCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ReSharperCleanupCodeSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ReSharperCleanupCodeSettingsExtensions
    {
        #region TargetPath
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.TargetPath"/></em></p>
        ///   <p>Target path.</p>
        /// </summary>
        [Pure]
        public static T SetTargetPath<T>(this T toolSettings, string targetPath) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = targetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.TargetPath"/></em></p>
        ///   <p>Target path.</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPath<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPath = null;
            return toolSettings;
        }
        #endregion
        #region Profile
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.Profile"/></em></p>
        ///   <p>A code cleanup profile that lists cleanup tasks to execute.<p/>By default, CleanupCode will apply code cleanup tasks specified in the <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#profiles">Built-in: Full Cleanup profile</a>, that is all <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#tasks">available cleanup tasks</a> tasks except <a href="https://www.jetbrains.com/help/resharper/File_Header_Style.html">updating file header</a>. </p>
        /// </summary>
        [Pure]
        public static T SetProfile<T>(this T toolSettings, string profile) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = profile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.Profile"/></em></p>
        ///   <p>A code cleanup profile that lists cleanup tasks to execute.<p/>By default, CleanupCode will apply code cleanup tasks specified in the <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#profiles">Built-in: Full Cleanup profile</a>, that is all <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#tasks">available cleanup tasks</a> tasks except <a href="https://www.jetbrains.com/help/resharper/File_Header_Style.html">updating file header</a>. </p>
        /// </summary>
        [Pure]
        public static T ResetProfile<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Profile = null;
            return toolSettings;
        }
        #endregion
        #region Settings
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.Settings"/></em></p>
        ///   <p>Default settings are overridden from the <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#solution-team-shared-layer">team-shared layer</a>, if it exists. If necessary, you can use this parameter to specify another <c>.DotSettings</c> file, which will override all other settings.</p>
        /// </summary>
        [Pure]
        public static T SetSettings<T>(this T toolSettings, string settings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Settings = settings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.Settings"/></em></p>
        ///   <p>Default settings are overridden from the <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#solution-team-shared-layer">team-shared layer</a>, if it exists. If necessary, you can use this parameter to specify another <c>.DotSettings</c> file, which will override all other settings.</p>
        /// </summary>
        [Pure]
        public static T ResetSettings<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Settings = null;
            return toolSettings;
        }
        #endregion
        #region DisableSettingsLayers
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/> to a new list</em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDisableSettingsLayers<T>(this T toolSettings, params ReSharperSettingsLayers[] disableSettingsLayers) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/> to a new list</em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDisableSettingsLayers<T>(this T toolSettings, IEnumerable<ReSharperSettingsLayers> disableSettingsLayers) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal = disableSettingsLayers.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T AddDisableSettingsLayers<T>(this T toolSettings, params ReSharperSettingsLayers[] disableSettingsLayers) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T AddDisableSettingsLayers<T>(this T toolSettings, IEnumerable<ReSharperSettingsLayers> disableSettingsLayers) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.AddRange(disableSettingsLayers);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearDisableSettingsLayers<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableSettingsLayersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveDisableSettingsLayers<T>(this T toolSettings, params ReSharperSettingsLayers[] disableSettingsLayers) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<ReSharperSettingsLayers>(disableSettingsLayers);
            toolSettings.DisableSettingsLayersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></em></p>
        ///   <p>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveDisableSettingsLayers<T>(this T toolSettings, IEnumerable<ReSharperSettingsLayers> disableSettingsLayers) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<ReSharperSettingsLayers>(disableSettingsLayers);
            toolSettings.DisableSettingsLayersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region NoBuiltinSettings
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T SetNoBuiltinSettings<T>(this T toolSettings, bool? noBuiltinSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = noBuiltinSettings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T ResetNoBuiltinSettings<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T EnableNoBuiltinSettings<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T DisableNoBuiltinSettings<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></em></p>
        ///   <p>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></p>
        /// </summary>
        [Pure]
        public static T ToggleNoBuiltinSettings<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuiltinSettings = !toolSettings.NoBuiltinSettings;
            return toolSettings;
        }
        #endregion
        #region CachesHome
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static T SetCachesHome<T>(this T toolSettings, string cachesHome) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = cachesHome;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static T ResetCachesHome<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = null;
            return toolSettings;
        }
        #endregion
        #region CreateConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.CreateConfigFile"/></em></p>
        ///   <p>Used to save the current parameters to a configuration file.</p>
        /// </summary>
        [Pure]
        public static T SetCreateConfigFile<T>(this T toolSettings, string createConfigFile) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateConfigFile = createConfigFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.CreateConfigFile"/></em></p>
        ///   <p>Used to save the current parameters to a configuration file.</p>
        /// </summary>
        [Pure]
        public static T ResetCreateConfigFile<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.ConfigFile"/></em></p>
        ///   <p>Used to load the parameters described above from a configuration file.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.ConfigFile"/></em></p>
        ///   <p>Used to load the parameters described above from a configuration file.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.Verbosity"/></em></p>
        ///   <p>By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, ReSharperVerbosity verbosity) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.Verbosity"/></em></p>
        ///   <p>By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperCleanupCodeSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperCleanupCodeSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperCleanupCodeSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, string> properties) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperCleanupCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="ReSharperCleanupCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="ReSharperCleanupCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="ReSharperCleanupCodeSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
        #region Toolset
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.Toolset"/></em></p>
        ///   <p>Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.</p>
        /// </summary>
        [Pure]
        public static T SetToolset<T>(this T toolSettings, ReSharperMSBuildToolset toolset) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = toolset;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.Toolset"/></em></p>
        ///   <p>Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.</p>
        /// </summary>
        [Pure]
        public static T ResetToolset<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Toolset = null;
            return toolSettings;
        }
        #endregion
        #region ToolsetPath
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.ToolsetPath"/></em></p>
        ///   <p>Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c></p>
        /// </summary>
        [Pure]
        public static T SetToolsetPath<T>(this T toolSettings, string toolsetPath) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolsetPath = toolsetPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.ToolsetPath"/></em></p>
        ///   <p>Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c></p>
        /// </summary>
        [Pure]
        public static T ResetToolsetPath<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolsetPath = null;
            return toolSettings;
        }
        #endregion
        #region DotNetCore
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.DotNetCore"/></em></p>
        ///   <p>By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDotNetCore<T>(this T toolSettings, string dotNetCore) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCore = dotNetCore;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.DotNetCore"/></em></p>
        ///   <p>By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDotNetCore<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCore = null;
            return toolSettings;
        }
        #endregion
        #region DotNetCoreSdk
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.DotNetCoreSdk"/></em></p>
        ///   <p>Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.</p>
        /// </summary>
        [Pure]
        public static T SetDotNetCoreSdk<T>(this T toolSettings, string dotNetCoreSdk) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCoreSdk = dotNetCoreSdk;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.DotNetCoreSdk"/></em></p>
        ///   <p>Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.</p>
        /// </summary>
        [Pure]
        public static T ResetDotNetCoreSdk<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DotNetCoreSdk = null;
            return toolSettings;
        }
        #endregion
        #region MonoPath
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.MonoPath"/></em></p>
        ///   <p>Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c></p>
        /// </summary>
        [Pure]
        public static T SetMonoPath<T>(this T toolSettings, string monoPath) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MonoPath = monoPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperCleanupCodeSettings.MonoPath"/></em></p>
        ///   <p>Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c></p>
        /// </summary>
        [Pure]
        public static T ResetMonoPath<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MonoPath = null;
            return toolSettings;
        }
        #endregion
        #region ReferenceTargets
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetReferenceTargets<T>(this T toolSettings, params string[] referenceTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal = referenceTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetReferenceTargets<T>(this T toolSettings, IEnumerable<string> referenceTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal = referenceTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddReferenceTargets<T>(this T toolSettings, params string[] referenceTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal.AddRange(referenceTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddReferenceTargets<T>(this T toolSettings, IEnumerable<string> referenceTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal.AddRange(referenceTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearReferenceTargets<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReferenceTargetsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveReferenceTargets<T>(this T toolSettings, params string[] referenceTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referenceTargets);
            toolSettings.ReferenceTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveReferenceTargets<T>(this T toolSettings, IEnumerable<string> referenceTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(referenceTargets);
            toolSettings.ReferenceTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ItemTargets
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.ItemTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetItemTargets<T>(this T toolSettings, params string[] itemTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal = itemTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.ItemTargets"/> to a new list</em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T SetItemTargets<T>(this T toolSettings, IEnumerable<string> itemTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal = itemTargets.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddItemTargets<T>(this T toolSettings, params string[] itemTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal.AddRange(itemTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T AddItemTargets<T>(this T toolSettings, IEnumerable<string> itemTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal.AddRange(itemTargets);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearItemTargets<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ItemTargetsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveItemTargets<T>(this T toolSettings, params string[] itemTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(itemTargets);
            toolSettings.ItemTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></em></p>
        ///   <p>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveItemTargets<T>(this T toolSettings, IEnumerable<string> itemTargets) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(itemTargets);
            toolSettings.ItemTargetsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Include
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.Include"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetInclude<T>(this T toolSettings, params string[] include) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.Include"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetInclude<T>(this T toolSettings, IEnumerable<string> include) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal = include.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperCleanupCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddInclude<T>(this T toolSettings, params string[] include) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperCleanupCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddInclude<T>(this T toolSettings, IEnumerable<string> include) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.AddRange(include);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperCleanupCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T ClearInclude<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperCleanupCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveInclude<T>(this T toolSettings, params string[] include) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperCleanupCodeSettings.Include"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveInclude<T>(this T toolSettings, IEnumerable<string> include) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(include);
            toolSettings.IncludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Exclude
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.Exclude"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetExclude<T>(this T toolSettings, params string[] exclude) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperCleanupCodeSettings.Exclude"/> to a new list</em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T SetExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal = exclude.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperCleanupCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddExclude<T>(this T toolSettings, params string[] exclude) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperCleanupCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T AddExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.AddRange(exclude);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperCleanupCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T ClearExclude<T>(this T toolSettings) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperCleanupCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveExclude<T>(this T toolSettings, params string[] exclude) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperCleanupCodeSettings.Exclude"/></em></p>
        ///   <p>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</p>
        /// </summary>
        [Pure]
        public static T RemoveExclude<T>(this T toolSettings, IEnumerable<string> exclude) where T : ReSharperCleanupCodeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(exclude);
            toolSettings.ExcludeInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ReSharperDupFinderSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ReSharperDupFinderSettingsExtensions
    {
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.Source"/></em></p>
        ///   <p>Defines files included into the duplicates search. Use Visual Studio solution or project files, Ant-like wildcards or specific source file and folder names. Paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.Source"/></em></p>
        ///   <p>Defines files included into the duplicates search. Use Visual Studio solution or project files, Ant-like wildcards or specific source file and folder names. Paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.OutputFile"/></em></p>
        ///   <p>Lets you set the output file.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFile<T>(this T toolSettings, string outputFile) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.OutputFile"/></em></p>
        ///   <p>Lets you set the output file.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFile<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region ExcludeFiles
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.ExcludeFiles"/> to a new list</em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeFiles<T>(this T toolSettings, params string[] excludeFiles) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal = excludeFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.ExcludeFiles"/> to a new list</em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeFiles<T>(this T toolSettings, IEnumerable<string> excludeFiles) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal = excludeFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeFiles<T>(this T toolSettings, params string[] excludeFiles) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal.AddRange(excludeFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeFiles<T>(this T toolSettings, IEnumerable<string> excludeFiles) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal.AddRange(excludeFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T ClearExcludeFiles<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeFiles<T>(this T toolSettings, params string[] excludeFiles) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeFiles);
            toolSettings.ExcludeFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeFiles<T>(this T toolSettings, IEnumerable<string> excludeFiles) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeFiles);
            toolSettings.ExcludeFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExcludeComments
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.ExcludeComments"/> to a new list</em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeComments<T>(this T toolSettings, params string[] excludeComments) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal = excludeComments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.ExcludeComments"/> to a new list</em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeComments<T>(this T toolSettings, IEnumerable<string> excludeComments) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal = excludeComments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperDupFinderSettings.ExcludeComments"/></em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeComments<T>(this T toolSettings, params string[] excludeComments) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal.AddRange(excludeComments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperDupFinderSettings.ExcludeComments"/></em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeComments<T>(this T toolSettings, IEnumerable<string> excludeComments) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal.AddRange(excludeComments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperDupFinderSettings.ExcludeComments"/></em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T ClearExcludeComments<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperDupFinderSettings.ExcludeComments"/></em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeComments<T>(this T toolSettings, params string[] excludeComments) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeComments);
            toolSettings.ExcludeCommentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperDupFinderSettings.ExcludeComments"/></em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeComments<T>(this T toolSettings, IEnumerable<string> excludeComments) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeComments);
            toolSettings.ExcludeCommentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExcludeCodeRegions
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/> to a new list</em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T SetExcludeCodeRegions<T>(this T toolSettings, params string[] excludeCodeRegions) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal = excludeCodeRegions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/> to a new list</em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T SetExcludeCodeRegions<T>(this T toolSettings, IEnumerable<string> excludeCodeRegions) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal = excludeCodeRegions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T AddExcludeCodeRegions<T>(this T toolSettings, params string[] excludeCodeRegions) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal.AddRange(excludeCodeRegions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T AddExcludeCodeRegions<T>(this T toolSettings, IEnumerable<string> excludeCodeRegions) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal.AddRange(excludeCodeRegions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T ClearExcludeCodeRegions<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeCodeRegions<T>(this T toolSettings, params string[] excludeCodeRegions) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeCodeRegions);
            toolSettings.ExcludeCodeRegionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeCodeRegions<T>(this T toolSettings, IEnumerable<string> excludeCodeRegions) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeCodeRegions);
            toolSettings.ExcludeCodeRegionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DiscardFields
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.DiscardFields"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDiscardFields<T>(this T toolSettings, bool? discardFields) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = discardFields;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.DiscardFields"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDiscardFields<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperDupFinderSettings.DiscardFields"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableDiscardFields<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperDupFinderSettings.DiscardFields"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableDiscardFields<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperDupFinderSettings.DiscardFields"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDiscardFields<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = !toolSettings.DiscardFields;
            return toolSettings;
        }
        #endregion
        #region DiscardLiterals
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDiscardLiterals<T>(this T toolSettings, bool? discardLiterals) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = discardLiterals;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDiscardLiterals<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableDiscardLiterals<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableDiscardLiterals<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDiscardLiterals<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = !toolSettings.DiscardLiterals;
            return toolSettings;
        }
        #endregion
        #region DiscardLocalVars
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDiscardLocalVars<T>(this T toolSettings, bool? discardLocalVars) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = discardLocalVars;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDiscardLocalVars<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableDiscardLocalVars<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableDiscardLocalVars<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDiscardLocalVars<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = !toolSettings.DiscardLocalVars;
            return toolSettings;
        }
        #endregion
        #region DiscardTypes
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.DiscardTypes"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDiscardTypes<T>(this T toolSettings, bool? discardTypes) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = discardTypes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.DiscardTypes"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDiscardTypes<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperDupFinderSettings.DiscardTypes"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableDiscardTypes<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperDupFinderSettings.DiscardTypes"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableDiscardTypes<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperDupFinderSettings.DiscardTypes"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDiscardTypes<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = !toolSettings.DiscardTypes;
            return toolSettings;
        }
        #endregion
        #region DiscardCost
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.DiscardCost"/></em></p>
        ///   <p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p>
        /// </summary>
        [Pure]
        public static T SetDiscardCost<T>(this T toolSettings, int? discardCost) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardCost = discardCost;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.DiscardCost"/></em></p>
        ///   <p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p>
        /// </summary>
        [Pure]
        public static T ResetDiscardCost<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardCost = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, string> properties) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperDupFinderSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="ReSharperDupFinderSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="ReSharperDupFinderSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="ReSharperDupFinderSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
        #region NormalizeTypes
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></em></p>
        ///   <p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p>
        /// </summary>
        [Pure]
        public static T SetNormalizeTypes<T>(this T toolSettings, bool? normalizeTypes) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = normalizeTypes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></em></p>
        ///   <p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p>
        /// </summary>
        [Pure]
        public static T ResetNormalizeTypes<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></em></p>
        ///   <p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p>
        /// </summary>
        [Pure]
        public static T EnableNormalizeTypes<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></em></p>
        ///   <p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p>
        /// </summary>
        [Pure]
        public static T DisableNormalizeTypes<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></em></p>
        ///   <p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p>
        /// </summary>
        [Pure]
        public static T ToggleNormalizeTypes<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = !toolSettings.NormalizeTypes;
            return toolSettings;
        }
        #endregion
        #region ShowText
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.ShowText"/></em></p>
        ///   <p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p>
        /// </summary>
        [Pure]
        public static T SetShowText<T>(this T toolSettings, bool? showText) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = showText;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.ShowText"/></em></p>
        ///   <p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p>
        /// </summary>
        [Pure]
        public static T ResetShowText<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperDupFinderSettings.ShowText"/></em></p>
        ///   <p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p>
        /// </summary>
        [Pure]
        public static T EnableShowText<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperDupFinderSettings.ShowText"/></em></p>
        ///   <p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p>
        /// </summary>
        [Pure]
        public static T DisableShowText<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperDupFinderSettings.ShowText"/></em></p>
        ///   <p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p>
        /// </summary>
        [Pure]
        public static T ToggleShowText<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = !toolSettings.ShowText;
            return toolSettings;
        }
        #endregion
        #region CachesHome
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static T SetCachesHome<T>(this T toolSettings, string cachesHome) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = cachesHome;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.CachesHome"/></em></p>
        ///   <p>Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</p>
        /// </summary>
        [Pure]
        public static T ResetCachesHome<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CachesHome = null;
            return toolSettings;
        }
        #endregion
        #region CreateConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.CreateConfigFile"/></em></p>
        ///   <p>Used to save the current parameters to a configuration file.</p>
        /// </summary>
        [Pure]
        public static T SetCreateConfigFile<T>(this T toolSettings, string createConfigFile) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateConfigFile = createConfigFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.CreateConfigFile"/></em></p>
        ///   <p>Used to save the current parameters to a configuration file.</p>
        /// </summary>
        [Pure]
        public static T ResetCreateConfigFile<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.ConfigFile"/></em></p>
        ///   <p>Used to load the parameters described above from a configuration file.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.ConfigFile"/></em></p>
        ///   <p>Used to load the parameters described above from a configuration file.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.Verbosity"/></em></p>
        ///   <p>By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, ReSharperVerbosity verbosity) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.Verbosity"/></em></p>
        ///   <p>By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperDupFinderSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ReSharperDupFinderSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ReSharperDupFinderSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ReSharperDupFinderSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ReSharperDupFinderSettings.Debug"/></em></p>
        ///   <p>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : ReSharperDupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ReSharperSettingsBaseExtensions
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ReSharperSettingsBaseExtensions
    {
        #region Plugins
        /// <summary>
        ///   <p><em>Sets <see cref="ReSharperSettingsBase.Plugins"/> to a new dictionary</em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during execution. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>ReSharperPluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T SetPlugins<T>(this T toolSettings, IDictionary<string, string> plugins) where T : ReSharperSettingsBase
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal = plugins.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ReSharperSettingsBase.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during execution. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>ReSharperPluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T ClearPlugins<T>(this T toolSettings) where T : ReSharperSettingsBase
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="ReSharperSettingsBase.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during execution. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>ReSharperPluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T AddPlugin<T>(this T toolSettings, string pluginKey, string pluginValue) where T : ReSharperSettingsBase
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Add(pluginKey, pluginValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="ReSharperSettingsBase.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during execution. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>ReSharperPluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T RemovePlugin<T>(this T toolSettings, string pluginKey) where T : ReSharperSettingsBase
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Remove(pluginKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="ReSharperSettingsBase.Plugins"/></em></p>
        ///   <p>Allows adding ReSharper plugins that will get included during execution. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>ReSharperPluginLatest</c> or <c>null</c> will download the latest version.</p>
        /// </summary>
        [Pure]
        public static T SetPlugin<T>(this T toolSettings, string pluginKey, string pluginValue) where T : ReSharperSettingsBase
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal[pluginKey] = pluginValue;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ReSharperSettingsLayers
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<ReSharperSettingsLayers>))]
    public partial class ReSharperSettingsLayers : Enumeration
    {
        public static ReSharperSettingsLayers GlobalAll = (ReSharperSettingsLayers) "GlobalAll";
        public static ReSharperSettingsLayers GlobalPerProduct = (ReSharperSettingsLayers) "GlobalPerProduct";
        public static ReSharperSettingsLayers SolutionShared = (ReSharperSettingsLayers) "SolutionShared";
        public static ReSharperSettingsLayers SolutionPersonal = (ReSharperSettingsLayers) "SolutionPersonal";
        public static implicit operator ReSharperSettingsLayers(string value)
        {
            return new ReSharperSettingsLayers { Value = value };
        }
    }
    #endregion
    #region ReSharperMSBuildToolset
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<ReSharperMSBuildToolset>))]
    public partial class ReSharperMSBuildToolset : Enumeration
    {
        public static ReSharperMSBuildToolset _12_0 = (ReSharperMSBuildToolset) "12.0";
        public static ReSharperMSBuildToolset _14_0 = (ReSharperMSBuildToolset) "14.0";
        public static ReSharperMSBuildToolset _15_0 = (ReSharperMSBuildToolset) "15.0";
        public static implicit operator ReSharperMSBuildToolset(string value)
        {
            return new ReSharperMSBuildToolset { Value = value };
        }
    }
    #endregion
    #region ReSharperFormat
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<ReSharperFormat>))]
    public partial class ReSharperFormat : Enumeration
    {
        public static ReSharperFormat Xml = (ReSharperFormat) "Xml";
        public static ReSharperFormat Html = (ReSharperFormat) "Html";
        public static ReSharperFormat Text = (ReSharperFormat) "Text";
        public static ReSharperFormat Json = (ReSharperFormat) "Json";
        public static implicit operator ReSharperFormat(string value)
        {
            return new ReSharperFormat { Value = value };
        }
    }
    #endregion
    #region ReSharperVerbosity
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<ReSharperVerbosity>))]
    public partial class ReSharperVerbosity : Enumeration
    {
        public static ReSharperVerbosity OFF = (ReSharperVerbosity) "OFF";
        public static ReSharperVerbosity FATAL = (ReSharperVerbosity) "FATAL";
        public static ReSharperVerbosity ERROR = (ReSharperVerbosity) "ERROR";
        public static ReSharperVerbosity WARN = (ReSharperVerbosity) "WARN";
        public static ReSharperVerbosity INFO = (ReSharperVerbosity) "INFO";
        public static ReSharperVerbosity VERBOSE = (ReSharperVerbosity) "VERBOSE";
        public static ReSharperVerbosity TRACE = (ReSharperVerbosity) "TRACE";
        public static implicit operator ReSharperVerbosity(string value)
        {
            return new ReSharperVerbosity { Value = value };
        }
    }
    #endregion
    #region ReSharperSeverity
    /// <summary>
    ///   Used within <see cref="ReSharperTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<ReSharperSeverity>))]
    public partial class ReSharperSeverity : Enumeration
    {
        public static ReSharperSeverity INFO = (ReSharperSeverity) "INFO";
        public static ReSharperSeverity HINT = (ReSharperSeverity) "HINT";
        public static ReSharperSeverity SUGGESTION = (ReSharperSeverity) "SUGGESTION";
        public static ReSharperSeverity WARNING = (ReSharperSeverity) "WARNING";
        public static ReSharperSeverity ERROR = (ReSharperSeverity) "ERROR";
        public static implicit operator ReSharperSeverity(string value)
        {
            return new ReSharperSeverity { Value = value };
        }
    }
    #endregion
}

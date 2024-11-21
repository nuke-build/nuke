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

namespace Nuke.Common.Tools.ReSharper;

/// <summary><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class ReSharperTasks : ToolTasks, IRequireNuGetPackage
{
    public static string ReSharperPath => new ReSharperTasks().GetToolPath();
    public const string PackageId = "JetBrains.ReSharper.GlobalTools";
    public const string PackageExecutable = "JetBrains.CommandLine.Products.dll";
    /// <summary><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> ReSharper(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new ReSharperTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperInspectCodeSettings.TargetPath"/></li><li><c>--absolute-paths</c> via <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></li><li><c>--caches-home</c> via <see cref="ReSharperInspectCodeSettings.CachesHome"/></li><li><c>--config</c> via <see cref="ReSharperInspectCodeSettings.ConfigFile"/></li><li><c>--config-create</c> via <see cref="ReSharperInspectCodeSettings.CreateConfigFile"/></li><li><c>--debug</c> via <see cref="ReSharperInspectCodeSettings.Debug"/></li><li><c>--disable-settings-layers</c> via <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></li><li><c>--dotnetcore</c> via <see cref="ReSharperInspectCodeSettings.DotNetCore"/></li><li><c>--dotnetcoresdk</c> via <see cref="ReSharperInspectCodeSettings.DotNetCoreSdk"/></li><li><c>--dumpIssuesTypes</c> via <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></li><li><c>--exclude</c> via <see cref="ReSharperInspectCodeSettings.Exclude"/></li><li><c>--format</c> via <see cref="ReSharperInspectCodeSettings.Format"/></li><li><c>--include</c> via <see cref="ReSharperInspectCodeSettings.Include"/></li><li><c>--jobs</c> via <see cref="ReSharperInspectCodeSettings.Jobs"/></li><li><c>--mono</c> via <see cref="ReSharperInspectCodeSettings.MonoPath"/></li><li><c>--no-buildin-settings</c> via <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></li><li><c>--no-swea</c> via <see cref="ReSharperInspectCodeSettings.NoSwea"/></li><li><c>--output</c> via <see cref="ReSharperInspectCodeSettings.Output"/></li><li><c>--project</c> via <see cref="ReSharperInspectCodeSettings.Project"/></li><li><c>--properties</c> via <see cref="ReSharperInspectCodeSettings.Properties"/></li><li><c>--settings</c> via <see cref="ReSharperInspectCodeSettings.Settings"/></li><li><c>--severity</c> via <see cref="ReSharperInspectCodeSettings.Severity"/></li><li><c>--targets-for-items</c> via <see cref="ReSharperInspectCodeSettings.ItemTargets"/></li><li><c>--targets-for-references</c> via <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></li><li><c>--toolset</c> via <see cref="ReSharperInspectCodeSettings.Toolset"/></li><li><c>--toolset-path</c> via <see cref="ReSharperInspectCodeSettings.ToolsetPath"/></li><li><c>--verbosity</c> via <see cref="ReSharperInspectCodeSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ReSharperInspectCode(ReSharperInspectCodeSettings options = null) => new ReSharperTasks().Run(options);
    /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperInspectCodeSettings.TargetPath"/></li><li><c>--absolute-paths</c> via <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></li><li><c>--caches-home</c> via <see cref="ReSharperInspectCodeSettings.CachesHome"/></li><li><c>--config</c> via <see cref="ReSharperInspectCodeSettings.ConfigFile"/></li><li><c>--config-create</c> via <see cref="ReSharperInspectCodeSettings.CreateConfigFile"/></li><li><c>--debug</c> via <see cref="ReSharperInspectCodeSettings.Debug"/></li><li><c>--disable-settings-layers</c> via <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></li><li><c>--dotnetcore</c> via <see cref="ReSharperInspectCodeSettings.DotNetCore"/></li><li><c>--dotnetcoresdk</c> via <see cref="ReSharperInspectCodeSettings.DotNetCoreSdk"/></li><li><c>--dumpIssuesTypes</c> via <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></li><li><c>--exclude</c> via <see cref="ReSharperInspectCodeSettings.Exclude"/></li><li><c>--format</c> via <see cref="ReSharperInspectCodeSettings.Format"/></li><li><c>--include</c> via <see cref="ReSharperInspectCodeSettings.Include"/></li><li><c>--jobs</c> via <see cref="ReSharperInspectCodeSettings.Jobs"/></li><li><c>--mono</c> via <see cref="ReSharperInspectCodeSettings.MonoPath"/></li><li><c>--no-buildin-settings</c> via <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></li><li><c>--no-swea</c> via <see cref="ReSharperInspectCodeSettings.NoSwea"/></li><li><c>--output</c> via <see cref="ReSharperInspectCodeSettings.Output"/></li><li><c>--project</c> via <see cref="ReSharperInspectCodeSettings.Project"/></li><li><c>--properties</c> via <see cref="ReSharperInspectCodeSettings.Properties"/></li><li><c>--settings</c> via <see cref="ReSharperInspectCodeSettings.Settings"/></li><li><c>--severity</c> via <see cref="ReSharperInspectCodeSettings.Severity"/></li><li><c>--targets-for-items</c> via <see cref="ReSharperInspectCodeSettings.ItemTargets"/></li><li><c>--targets-for-references</c> via <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></li><li><c>--toolset</c> via <see cref="ReSharperInspectCodeSettings.Toolset"/></li><li><c>--toolset-path</c> via <see cref="ReSharperInspectCodeSettings.ToolsetPath"/></li><li><c>--verbosity</c> via <see cref="ReSharperInspectCodeSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ReSharperInspectCode(Configure<ReSharperInspectCodeSettings> configurator) => new ReSharperTasks().Run(configurator.Invoke(new ReSharperInspectCodeSettings()));
    /// <summary><p>One of ReSharper's most notable features, code inspection, is available even without opening Visual Studio. InspectCode, a free command line tool requires a minimum of one parameter- your solution file- to apply all of ReSharper's inspections.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperInspectCodeSettings.TargetPath"/></li><li><c>--absolute-paths</c> via <see cref="ReSharperInspectCodeSettings.AbsolutePaths"/></li><li><c>--caches-home</c> via <see cref="ReSharperInspectCodeSettings.CachesHome"/></li><li><c>--config</c> via <see cref="ReSharperInspectCodeSettings.ConfigFile"/></li><li><c>--config-create</c> via <see cref="ReSharperInspectCodeSettings.CreateConfigFile"/></li><li><c>--debug</c> via <see cref="ReSharperInspectCodeSettings.Debug"/></li><li><c>--disable-settings-layers</c> via <see cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/></li><li><c>--dotnetcore</c> via <see cref="ReSharperInspectCodeSettings.DotNetCore"/></li><li><c>--dotnetcoresdk</c> via <see cref="ReSharperInspectCodeSettings.DotNetCoreSdk"/></li><li><c>--dumpIssuesTypes</c> via <see cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/></li><li><c>--exclude</c> via <see cref="ReSharperInspectCodeSettings.Exclude"/></li><li><c>--format</c> via <see cref="ReSharperInspectCodeSettings.Format"/></li><li><c>--include</c> via <see cref="ReSharperInspectCodeSettings.Include"/></li><li><c>--jobs</c> via <see cref="ReSharperInspectCodeSettings.Jobs"/></li><li><c>--mono</c> via <see cref="ReSharperInspectCodeSettings.MonoPath"/></li><li><c>--no-buildin-settings</c> via <see cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/></li><li><c>--no-swea</c> via <see cref="ReSharperInspectCodeSettings.NoSwea"/></li><li><c>--output</c> via <see cref="ReSharperInspectCodeSettings.Output"/></li><li><c>--project</c> via <see cref="ReSharperInspectCodeSettings.Project"/></li><li><c>--properties</c> via <see cref="ReSharperInspectCodeSettings.Properties"/></li><li><c>--settings</c> via <see cref="ReSharperInspectCodeSettings.Settings"/></li><li><c>--severity</c> via <see cref="ReSharperInspectCodeSettings.Severity"/></li><li><c>--targets-for-items</c> via <see cref="ReSharperInspectCodeSettings.ItemTargets"/></li><li><c>--targets-for-references</c> via <see cref="ReSharperInspectCodeSettings.ReferenceTargets"/></li><li><c>--toolset</c> via <see cref="ReSharperInspectCodeSettings.Toolset"/></li><li><c>--toolset-path</c> via <see cref="ReSharperInspectCodeSettings.ToolsetPath"/></li><li><c>--verbosity</c> via <see cref="ReSharperInspectCodeSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(ReSharperInspectCodeSettings Settings, IReadOnlyCollection<Output> Output)> ReSharperInspectCode(CombinatorialConfigure<ReSharperInspectCodeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ReSharperInspectCode, degreeOfParallelism, completeOnFailure);
    /// <summary><p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperCleanupCodeSettings.TargetPath"/></li><li><c>--caches-home</c> via <see cref="ReSharperCleanupCodeSettings.CachesHome"/></li><li><c>--config</c> via <see cref="ReSharperCleanupCodeSettings.ConfigFile"/></li><li><c>--config-create</c> via <see cref="ReSharperCleanupCodeSettings.CreateConfigFile"/></li><li><c>--debug</c> via <see cref="ReSharperCleanupCodeSettings.Debug"/></li><li><c>--disable-settings-layers</c> via <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></li><li><c>--dotnetcore</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCore"/></li><li><c>--dotnetcoresdk</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCoreSdk"/></li><li><c>--exclude</c> via <see cref="ReSharperCleanupCodeSettings.Exclude"/></li><li><c>--include</c> via <see cref="ReSharperCleanupCodeSettings.Include"/></li><li><c>--mono</c> via <see cref="ReSharperCleanupCodeSettings.MonoPath"/></li><li><c>--no-buildin-settings</c> via <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></li><li><c>--profile</c> via <see cref="ReSharperCleanupCodeSettings.Profile"/></li><li><c>--properties</c> via <see cref="ReSharperCleanupCodeSettings.Properties"/></li><li><c>--settings</c> via <see cref="ReSharperCleanupCodeSettings.Settings"/></li><li><c>--targets-for-items</c> via <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></li><li><c>--targets-for-references</c> via <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></li><li><c>--toolset</c> via <see cref="ReSharperCleanupCodeSettings.Toolset"/></li><li><c>--toolset-path</c> via <see cref="ReSharperCleanupCodeSettings.ToolsetPath"/></li><li><c>--verbosity</c> via <see cref="ReSharperCleanupCodeSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ReSharperCleanupCode(ReSharperCleanupCodeSettings options = null) => new ReSharperTasks().Run(options);
    /// <summary><p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperCleanupCodeSettings.TargetPath"/></li><li><c>--caches-home</c> via <see cref="ReSharperCleanupCodeSettings.CachesHome"/></li><li><c>--config</c> via <see cref="ReSharperCleanupCodeSettings.ConfigFile"/></li><li><c>--config-create</c> via <see cref="ReSharperCleanupCodeSettings.CreateConfigFile"/></li><li><c>--debug</c> via <see cref="ReSharperCleanupCodeSettings.Debug"/></li><li><c>--disable-settings-layers</c> via <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></li><li><c>--dotnetcore</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCore"/></li><li><c>--dotnetcoresdk</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCoreSdk"/></li><li><c>--exclude</c> via <see cref="ReSharperCleanupCodeSettings.Exclude"/></li><li><c>--include</c> via <see cref="ReSharperCleanupCodeSettings.Include"/></li><li><c>--mono</c> via <see cref="ReSharperCleanupCodeSettings.MonoPath"/></li><li><c>--no-buildin-settings</c> via <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></li><li><c>--profile</c> via <see cref="ReSharperCleanupCodeSettings.Profile"/></li><li><c>--properties</c> via <see cref="ReSharperCleanupCodeSettings.Properties"/></li><li><c>--settings</c> via <see cref="ReSharperCleanupCodeSettings.Settings"/></li><li><c>--targets-for-items</c> via <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></li><li><c>--targets-for-references</c> via <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></li><li><c>--toolset</c> via <see cref="ReSharperCleanupCodeSettings.Toolset"/></li><li><c>--toolset-path</c> via <see cref="ReSharperCleanupCodeSettings.ToolsetPath"/></li><li><c>--verbosity</c> via <see cref="ReSharperCleanupCodeSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ReSharperCleanupCode(Configure<ReSharperCleanupCodeSettings> configurator) => new ReSharperTasks().Run(configurator.Invoke(new ReSharperCleanupCodeSettings()));
    /// <summary><p>CleanupCode is a free command-line tool that can perform code cleanup to instantly eliminate code style violations in a project or solution and ensure a uniform code base.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;targetPath&gt;</c> via <see cref="ReSharperCleanupCodeSettings.TargetPath"/></li><li><c>--caches-home</c> via <see cref="ReSharperCleanupCodeSettings.CachesHome"/></li><li><c>--config</c> via <see cref="ReSharperCleanupCodeSettings.ConfigFile"/></li><li><c>--config-create</c> via <see cref="ReSharperCleanupCodeSettings.CreateConfigFile"/></li><li><c>--debug</c> via <see cref="ReSharperCleanupCodeSettings.Debug"/></li><li><c>--disable-settings-layers</c> via <see cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/></li><li><c>--dotnetcore</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCore"/></li><li><c>--dotnetcoresdk</c> via <see cref="ReSharperCleanupCodeSettings.DotNetCoreSdk"/></li><li><c>--exclude</c> via <see cref="ReSharperCleanupCodeSettings.Exclude"/></li><li><c>--include</c> via <see cref="ReSharperCleanupCodeSettings.Include"/></li><li><c>--mono</c> via <see cref="ReSharperCleanupCodeSettings.MonoPath"/></li><li><c>--no-buildin-settings</c> via <see cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/></li><li><c>--profile</c> via <see cref="ReSharperCleanupCodeSettings.Profile"/></li><li><c>--properties</c> via <see cref="ReSharperCleanupCodeSettings.Properties"/></li><li><c>--settings</c> via <see cref="ReSharperCleanupCodeSettings.Settings"/></li><li><c>--targets-for-items</c> via <see cref="ReSharperCleanupCodeSettings.ItemTargets"/></li><li><c>--targets-for-references</c> via <see cref="ReSharperCleanupCodeSettings.ReferenceTargets"/></li><li><c>--toolset</c> via <see cref="ReSharperCleanupCodeSettings.Toolset"/></li><li><c>--toolset-path</c> via <see cref="ReSharperCleanupCodeSettings.ToolsetPath"/></li><li><c>--verbosity</c> via <see cref="ReSharperCleanupCodeSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(ReSharperCleanupCodeSettings Settings, IReadOnlyCollection<Output> Output)> ReSharperCleanupCode(CombinatorialConfigure<ReSharperCleanupCodeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ReSharperCleanupCode, degreeOfParallelism, completeOnFailure);
    /// <summary><p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;source&gt;</c> via <see cref="ReSharperDupFinderSettings.Source"/></li><li><c>--caches-home</c> via <see cref="ReSharperDupFinderSettings.CachesHome"/></li><li><c>--config</c> via <see cref="ReSharperDupFinderSettings.ConfigFile"/></li><li><c>--config-create</c> via <see cref="ReSharperDupFinderSettings.CreateConfigFile"/></li><li><c>--debug</c> via <see cref="ReSharperDupFinderSettings.Debug"/></li><li><c>--discard-cost</c> via <see cref="ReSharperDupFinderSettings.DiscardCost"/></li><li><c>--discard-fields</c> via <see cref="ReSharperDupFinderSettings.DiscardFields"/></li><li><c>--discard-literals</c> via <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></li><li><c>--discard-local-vars</c> via <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></li><li><c>--discard-types</c> via <see cref="ReSharperDupFinderSettings.DiscardTypes"/></li><li><c>--exclude</c> via <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></li><li><c>--exclude-by-comment</c> via <see cref="ReSharperDupFinderSettings.ExcludeComments"/></li><li><c>--exclude-code-regions</c> via <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></li><li><c>--normalize-types</c> via <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></li><li><c>--output</c> via <see cref="ReSharperDupFinderSettings.OutputFile"/></li><li><c>--properties</c> via <see cref="ReSharperDupFinderSettings.Properties"/></li><li><c>--show-text</c> via <see cref="ReSharperDupFinderSettings.ShowText"/></li><li><c>--verbosity</c> via <see cref="ReSharperDupFinderSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ReSharperDupFinder(ReSharperDupFinderSettings options = null) => new ReSharperTasks().Run(options);
    /// <summary><p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;source&gt;</c> via <see cref="ReSharperDupFinderSettings.Source"/></li><li><c>--caches-home</c> via <see cref="ReSharperDupFinderSettings.CachesHome"/></li><li><c>--config</c> via <see cref="ReSharperDupFinderSettings.ConfigFile"/></li><li><c>--config-create</c> via <see cref="ReSharperDupFinderSettings.CreateConfigFile"/></li><li><c>--debug</c> via <see cref="ReSharperDupFinderSettings.Debug"/></li><li><c>--discard-cost</c> via <see cref="ReSharperDupFinderSettings.DiscardCost"/></li><li><c>--discard-fields</c> via <see cref="ReSharperDupFinderSettings.DiscardFields"/></li><li><c>--discard-literals</c> via <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></li><li><c>--discard-local-vars</c> via <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></li><li><c>--discard-types</c> via <see cref="ReSharperDupFinderSettings.DiscardTypes"/></li><li><c>--exclude</c> via <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></li><li><c>--exclude-by-comment</c> via <see cref="ReSharperDupFinderSettings.ExcludeComments"/></li><li><c>--exclude-code-regions</c> via <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></li><li><c>--normalize-types</c> via <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></li><li><c>--output</c> via <see cref="ReSharperDupFinderSettings.OutputFile"/></li><li><c>--properties</c> via <see cref="ReSharperDupFinderSettings.Properties"/></li><li><c>--show-text</c> via <see cref="ReSharperDupFinderSettings.ShowText"/></li><li><c>--verbosity</c> via <see cref="ReSharperDupFinderSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> ReSharperDupFinder(Configure<ReSharperDupFinderSettings> configurator) => new ReSharperTasks().Run(configurator.Invoke(new ReSharperDupFinderSettings()));
    /// <summary><p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;source&gt;</c> via <see cref="ReSharperDupFinderSettings.Source"/></li><li><c>--caches-home</c> via <see cref="ReSharperDupFinderSettings.CachesHome"/></li><li><c>--config</c> via <see cref="ReSharperDupFinderSettings.ConfigFile"/></li><li><c>--config-create</c> via <see cref="ReSharperDupFinderSettings.CreateConfigFile"/></li><li><c>--debug</c> via <see cref="ReSharperDupFinderSettings.Debug"/></li><li><c>--discard-cost</c> via <see cref="ReSharperDupFinderSettings.DiscardCost"/></li><li><c>--discard-fields</c> via <see cref="ReSharperDupFinderSettings.DiscardFields"/></li><li><c>--discard-literals</c> via <see cref="ReSharperDupFinderSettings.DiscardLiterals"/></li><li><c>--discard-local-vars</c> via <see cref="ReSharperDupFinderSettings.DiscardLocalVars"/></li><li><c>--discard-types</c> via <see cref="ReSharperDupFinderSettings.DiscardTypes"/></li><li><c>--exclude</c> via <see cref="ReSharperDupFinderSettings.ExcludeFiles"/></li><li><c>--exclude-by-comment</c> via <see cref="ReSharperDupFinderSettings.ExcludeComments"/></li><li><c>--exclude-code-regions</c> via <see cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/></li><li><c>--normalize-types</c> via <see cref="ReSharperDupFinderSettings.NormalizeTypes"/></li><li><c>--output</c> via <see cref="ReSharperDupFinderSettings.OutputFile"/></li><li><c>--properties</c> via <see cref="ReSharperDupFinderSettings.Properties"/></li><li><c>--show-text</c> via <see cref="ReSharperDupFinderSettings.ShowText"/></li><li><c>--verbosity</c> via <see cref="ReSharperDupFinderSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(ReSharperDupFinderSettings Settings, IReadOnlyCollection<Output> Output)> ReSharperDupFinder(CombinatorialConfigure<ReSharperDupFinderSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(ReSharperDupFinder, degreeOfParallelism, completeOnFailure);
}
#region ReSharperInspectCodeSettings
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ReSharperInspectCodeSettings>))]
[Command(Type = typeof(ReSharperTasks), Command = nameof(ReSharperTasks.ReSharperInspectCode), Arguments = "inspectcode")]
public partial class ReSharperInspectCodeSettings : ReSharperSettingsBase
{
    /// <summary>Target path.</summary>
    [Argument(Format = "{value}", Position = 1)] public string TargetPath => Get<string>(() => TargetPath);
    /// <summary>Lets you set the output file. By default, the output file is saved in the <em>%TEMP%</em> directory.</summary>
    [Argument(Format = "--output={value}")] public string Output => Get<string>(() => Output);
    /// <summary>By default, InspectCode writes its output in <c>XML</c> format. If necessary, you can specify other output formats with this parameter.</summary>
    [Argument(Format = "--format={value}")] public ReSharperFormat Format => Get<ReSharperFormat>(() => Format);
    /// <summary>By default, InspectCode uses heuristics to split its jobs and run them in parallel using as many threads/cores as available. If necessary, you can limit the number of threads.</summary>
    [Argument(Format = "--jobs={value}")] public int? Jobs => Get<int?>(() => Jobs);
    /// <summary>By default, files in InspectCode's report are written with paths relative to the solution file. You can use this switch to have absolute paths in the report.</summary>
    [Argument(Format = "--absolute-paths")] public bool? AbsolutePaths => Get<bool?>(() => AbsolutePaths);
    /// <summary>Allows analyzing particular project(s) instead of the whole solution. After this parameter, you can type a project name or a wildcard that matches several projects within your solution. For example, <c>--project=*Billing</c></summary>
    [Argument(Format = "--project={value}")] public string Project => Get<string>(() => Project);
    /// <summary>Disables solution-wide analysis.</summary>
    [Argument(Format = "--no-swea")] public bool? NoSwea => Get<bool?>(() => NoSwea);
    /// <summary>By default, InspectCode only reports issues with the severity level Suggestion and higher. This parameter lets you change the minimal reported severity level to <c>INFO</c>, <c>HINT</c>, <c>SUGGESTION</c>, <c>WARNING</c>, <c>ERROR</c>. For example, <c>-s=WARNING</c>.</summary>
    [Argument(Format = "--severity={value}")] public ReSharperSeverity Severity => Get<ReSharperSeverity>(() => Severity);
    /// <summary>Use this option to dump all existing <a href="https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Inspections.html">code inspections</a> to the <a href="https://www.jetbrains.com/help/resharper/InspectCode.html#output">output</a>. This option should be used separately from actual analysis, i.e. without the solution argument.</summary>
    [Argument(Format = "--dumpIssuesTypes")] public bool? DumpIssuesTypes => Get<bool?>(() => DumpIssuesTypes);
    /// <summary>Default settings are overridden from the <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#solution-team-shared-layer">team-shared layer</a>, if it exists. If necessary, you can use this parameter to specify another <c>.DotSettings</c> file, which will override all other settings.</summary>
    [Argument(Format = "--settings={value}")] public string Settings => Get<string>(() => Settings);
    /// <summary>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</summary>
    [Argument(Format = "--disable-settings-layers={value}", Separator = ";")] public IReadOnlyList<ReSharperSettingsLayers> DisableSettingsLayers => Get<List<ReSharperSettingsLayers>>(() => DisableSettingsLayers);
    /// <summary>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></summary>
    [Argument(Format = "--no-buildin-settings")] public bool? NoBuiltinSettings => Get<bool?>(() => NoBuiltinSettings);
    /// <summary>Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</summary>
    [Argument(Format = "--caches-home={value}")] public string CachesHome => Get<string>(() => CachesHome);
    /// <summary>Used to save the current parameters to a configuration file.</summary>
    [Argument(Format = "--config-create={value}")] public string CreateConfigFile => Get<string>(() => CreateConfigFile);
    /// <summary>Used to load the parameters described above from a configuration file.</summary>
    [Argument(Format = "--config={value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.</summary>
    [Argument(Format = "--verbosity={value}")] public ReSharperVerbosity Verbosity => Get<ReSharperVerbosity>(() => Verbosity);
    /// <summary>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</summary>
    [Argument(Format = "--properties:{key}={value}")] public IReadOnlyDictionary<string, string> Properties => Get<Dictionary<string, string>>(() => Properties);
    /// <summary>Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.</summary>
    [Argument(Format = "--toolset={value}")] public ReSharperMSBuildToolset Toolset => Get<ReSharperMSBuildToolset>(() => Toolset);
    /// <summary>Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c></summary>
    [Argument(Format = "--toolset-path={value}")] public string ToolsetPath => Get<string>(() => ToolsetPath);
    /// <summary>By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.</summary>
    [Argument(Format = "--dotnetcore={value}")] public string DotNetCore => Get<string>(() => DotNetCore);
    /// <summary>Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.</summary>
    [Argument(Format = "--dotnetcoresdk={value}")] public string DotNetCoreSdk => Get<string>(() => DotNetCoreSdk);
    /// <summary>Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c></summary>
    [Argument(Format = "--mono={value}")] public string MonoPath => Get<string>(() => MonoPath);
    /// <summary>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</summary>
    [Argument(Format = "--targets-for-references={value}", Separator = ";")] public IReadOnlyList<string> ReferenceTargets => Get<List<string>>(() => ReferenceTargets);
    /// <summary>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</summary>
    [Argument(Format = "--targets-for-items={value}", Separator = ";")] public IReadOnlyList<string> ItemTargets => Get<List<string>>(() => ItemTargets);
    /// <summary>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</summary>
    [Argument(Format = "--include={value}", Separator = ";")] public IReadOnlyList<string> Include => Get<List<string>>(() => Include);
    /// <summary>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</summary>
    [Argument(Format = "--exclude={value}", Separator = ";")] public IReadOnlyList<string> Exclude => Get<List<string>>(() => Exclude);
}
#endregion
#region ReSharperCleanupCodeSettings
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ReSharperCleanupCodeSettings>))]
[Command(Type = typeof(ReSharperTasks), Command = nameof(ReSharperTasks.ReSharperCleanupCode), Arguments = "cleanupcode")]
public partial class ReSharperCleanupCodeSettings : ReSharperSettingsBase
{
    /// <summary>Target path.</summary>
    [Argument(Format = "{value}", Position = 1)] public string TargetPath => Get<string>(() => TargetPath);
    /// <summary>A code cleanup profile that lists cleanup tasks to execute.<p/>By default, CleanupCode will apply code cleanup tasks specified in the <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#profiles">Built-in: Full Cleanup profile</a>, that is all <a href="https://www.jetbrains.com/help/resharper/Code_Cleanup__Index.html#tasks">available cleanup tasks</a> tasks except <a href="https://www.jetbrains.com/help/resharper/File_Header_Style.html">updating file header</a>. </summary>
    [Argument(Format = "--profile={value}")] public string Profile => Get<string>(() => Profile);
    /// <summary>Default settings are overridden from the <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#solution-team-shared-layer">team-shared layer</a>, if it exists. If necessary, you can use this parameter to specify another <c>.DotSettings</c> file, which will override all other settings.</summary>
    [Argument(Format = "--settings={value}")] public string Settings => Get<string>(() => Settings);
    /// <summary>Disables specified <a href="https://www.jetbrains.com/help/resharper/Sharing_Configuration_Options.html#layers">settings layers</a>. Accepted values: <c>GlobalAll</c>, <c>GlobalPerProduct</c>, <c>SolutionShared</c>, <c>SolutionPersonal</c>.</summary>
    [Argument(Format = "--disable-settings-layers={value}", Separator = ";")] public IReadOnlyList<ReSharperSettingsLayers> DisableSettingsLayers => Get<List<ReSharperSettingsLayers>>(() => DisableSettingsLayers);
    /// <summary>Suppresses global, solution and project settings profile usage. Equivalent to using <c>--disable-settings-layers: GlobalAll; GlobalPerProduct; SolutionShared; SolutionPersonal; ProjectShared; ProjectPersonal</c></summary>
    [Argument(Format = "--no-buildin-settings")] public bool? NoBuiltinSettings => Get<bool?>(() => NoBuiltinSettings);
    /// <summary>Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</summary>
    [Argument(Format = "--caches-home={value}")] public string CachesHome => Get<string>(() => CachesHome);
    /// <summary>Used to save the current parameters to a configuration file.</summary>
    [Argument(Format = "--config-create={value}")] public string CreateConfigFile => Get<string>(() => CreateConfigFile);
    /// <summary>Used to load the parameters described above from a configuration file.</summary>
    [Argument(Format = "--config={value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.</summary>
    [Argument(Format = "--verbosity={value}")] public ReSharperVerbosity Verbosity => Get<ReSharperVerbosity>(() => Verbosity);
    /// <summary>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Lets you override MSBuild properties. You can set each property separately ( <c>--properties:prop1=val1</c> <c>--properties:prop2=val2</c>), or use a semicolon to separate multiple properties <c>--properties:prop1=val1;prop2=val2</c>.<para/>Note that the semicolon cannot be used inside values, for example: <c>--properties:ReferencePath="r:\reference1\;r:\reference2\"</c>. In such cases, add each value separately using another <c>--properties</c> parameter — the values will be combined.<para/>The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in CleanupCode parameters.</summary>
    [Argument(Format = "--properties:{key}={value}")] public IReadOnlyDictionary<string, string> Properties => Get<Dictionary<string, string>>(() => Properties);
    /// <summary>Use this option to specify the exact MSBuild version. For example 12.0: <c>--toolset=12.0</c>. By default the highest available MSBuild version is used. This option might not work if you have several installations with the same version, for example 16.0 from Visual Studio 2019 and 16.0 from .NET Core 3.x.</summary>
    [Argument(Format = "--toolset={value}")] public ReSharperMSBuildToolset Toolset => Get<ReSharperMSBuildToolset>(() => Toolset);
    /// <summary>Use this option to specify the exact path to MSBuild. This might be helpful if you have a custom MSBuild installation and want to use it with CleanupCode, for example: <c>--toolset-path="C:\tools\msbuild\bin\MsBuild.exe"</c></summary>
    [Argument(Format = "--toolset-path={value}")] public string ToolsetPath => Get<string>(() => ToolsetPath);
    /// <summary>By default, .NET Core installation is auto-detected. You can use this option to point to the specific .NET Core installation if the auto-detection results in a conflict. Use it without arguments to ignore .NET Core. Example: <c>--dotnetcore=/usr/local/share/dotnet/dotnet</c>.</summary>
    [Argument(Format = "--dotnetcore={value}")] public string DotNetCore => Get<string>(() => DotNetCore);
    /// <summary>Use this option to specify .NET Core SDK version that should provide MSBuild. For example, if you have installed .NET Core with SDKs 2.0.3 and 3.0.100, CleanupCode will prefer 3.0.100 (the latest, including preview versions). Now if you want to run CleanupCode with .NET Core SDK 2.0.3, add <c>--dotnetcoresdk=2.0.3</c> to the command line.</summary>
    [Argument(Format = "--dotnetcoresdk={value}")] public string DotNetCoreSdk => Get<string>(() => DotNetCoreSdk);
    /// <summary>Mono path. Empty to ignore Mono. Not specified for autodetect. Example: <c>--mono=/Library/Frameworks/Mono.framework/Versions/Current/bin/mono.</c></summary>
    [Argument(Format = "--mono={value}")] public string MonoPath => Get<string>(() => MonoPath);
    /// <summary>Names of custom MSBuild targets that will be executed to get referenced assemblies of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-references="GetReferences"</c>.</summary>
    [Argument(Format = "--targets-for-references={value}", Separator = ";")] public IReadOnlyList<string> ReferenceTargets => Get<List<string>>(() => ReferenceTargets);
    /// <summary>Names of custom MSBuild targets that will be executed to get other items (for example, a Compile item) of projects. The targets are defined either in the project file or in the <c>.targets</c> file. Multiple values are separated with the semicolon. For example, <c>--targets-for-items="GetCompileItems"</c>.</summary>
    [Argument(Format = "--targets-for-items={value}", Separator = ";")] public IReadOnlyList<string> ItemTargets => Get<List<string>>(() => ItemTargets);
    /// <summary>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</summary>
    [Argument(Format = "--include={value}", Separator = ";")] public IReadOnlyList<string> Include => Get<List<string>>(() => Include);
    /// <summary>Relative path(s) or wildcards that define the files to include/exclude during the cleanup. If both <c>--include</c> and <c>--exclude</c> are defined and cover the same set of files, <c>--exclude</c> will have higher priority. To specify multiple paths or wildcards, separate them with the semicolon or use the <c>--include</c>/<c>--exclude</c> parameters several times.</summary>
    [Argument(Format = "--exclude={value}", Separator = ";")] public IReadOnlyList<string> Exclude => Get<List<string>>(() => Exclude);
}
#endregion
#region ReSharperDupFinderSettings
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ReSharperDupFinderSettings>))]
[Command(Type = typeof(ReSharperTasks), Command = nameof(ReSharperTasks.ReSharperDupFinder), Arguments = "dupfinder")]
public partial class ReSharperDupFinderSettings : ToolOptions
{
    /// <summary>Defines files included into the duplicates search. Use Visual Studio solution or project files, Ant-like wildcards or specific source file and folder names. Paths should be either absolute or relative to the working directory.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Source => Get<string>(() => Source);
    /// <summary>Lets you set the output file.</summary>
    [Argument(Format = "--output={value}")] public string OutputFile => Get<string>(() => OutputFile);
    /// <summary>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</summary>
    [Argument(Format = "--exclude={value}", Separator = ";")] public IReadOnlyList<string> ExcludeFiles => Get<List<string>>(() => ExcludeFiles);
    /// <summary>Allows excluding files that have a matching substrings in the opening comments.</summary>
    [Argument(Format = "--exclude-by-comment={value}", Separator = ";")] public IReadOnlyList<string> ExcludeComments => Get<List<string>>(() => ExcludeComments);
    /// <summary>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</summary>
    [Argument(Format = "--exclude-code-regions={value}", Separator = ";")] public IReadOnlyList<string> ExcludeCodeRegions => Get<List<string>>(() => ExcludeCodeRegions);
    /// <summary>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</summary>
    [Argument(Format = "--discard-fields={value}")] public bool? DiscardFields => Get<bool?>(() => DiscardFields);
    /// <summary>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</summary>
    [Argument(Format = "--discard-literals={value}")] public bool? DiscardLiterals => Get<bool?>(() => DiscardLiterals);
    /// <summary>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</summary>
    [Argument(Format = "--discard-local-vars={value}")] public bool? DiscardLocalVars => Get<bool?>(() => DiscardLocalVars);
    /// <summary>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</summary>
    [Argument(Format = "--discard-types={value}")] public bool? DiscardTypes => Get<bool?>(() => DiscardTypes);
    /// <summary>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</summary>
    [Argument(Format = "--discard-cost={value}")] public int? DiscardCost => Get<int?>(() => DiscardCost);
    /// <summary>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</summary>
    [Argument(Format = "--properties:{key}={value}")] public IReadOnlyDictionary<string, string> Properties => Get<Dictionary<string, string>>(() => Properties);
    /// <summary>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</summary>
    [Argument(Format = "--normalize-types={value}")] public bool? NormalizeTypes => Get<bool?>(() => NormalizeTypes);
    /// <summary>If you use this parameter, the detected duplicate fragments will be embedded into the report.</summary>
    [Argument(Format = "--show-text={value}")] public bool? ShowText => Get<bool?>(() => ShowText);
    /// <summary>Lets you specify a custom location for the ReSharper caches. By default, the <em>%LOCALAPPDATA%</em> directory is used, unless there are settings files, in which case the one specified there is used. This parameter can be helpful if you want to use a fast SSD disk for the cache or if you want to store all your build processing data in a single place.</summary>
    [Argument(Format = "--caches-home={value}")] public string CachesHome => Get<string>(() => CachesHome);
    /// <summary>Used to save the current parameters to a configuration file.</summary>
    [Argument(Format = "--config-create={value}")] public string CreateConfigFile => Get<string>(() => CreateConfigFile);
    /// <summary>Used to load the parameters described above from a configuration file.</summary>
    [Argument(Format = "--config={value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>By default, only information messages appear in the log. Use this parameter to change the amount of information written to the log by the following levels (the order is from less to more detailed): <c>OFF</c>, <c>FATAL</c>, <c>ERROR</c>, <c>WARN</c>, <c>INFO</c>, <c>VERBOSE</c>, <c>TRACE</c>.<para/>For example, if something goes wrong, you can contact the <a href="https://resharper-support.jetbrains.com/">support team</a> and share a log file with all <c>TRACE</c> messages.</summary>
    [Argument(Format = "--verbosity={value}")] public ReSharperVerbosity Verbosity => Get<ReSharperVerbosity>(() => Verbosity);
    /// <summary>use this option to add execution details of CleanupCode to the output. If you have problems with CleanupCode, these details will be helpful when contacting the <a href="https://resharper-support.jetbrains.com/">support team</a>.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
}
#endregion
#region ReSharperSettingsBase
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<ReSharperSettingsBase>))]
public partial class ReSharperSettingsBase : ToolOptions
{
    /// <summary>Allows adding ReSharper plugins that will get included during execution. To add a plugin, specify its ID and version. Available plugins are listed in the <a href="https://resharper-plugins.jetbrains.com/">Plugin Repository</a>. The ID can be grabbed from the download URL. Using <c>ReSharperPluginLatest</c> or <c>null</c> will download the latest version.</summary>
    public IReadOnlyDictionary<string, string> Plugins => Get<Dictionary<string, string>>(() => Plugins);
}
#endregion
#region ReSharperInspectCodeSettingsExtensions
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ReSharperInspectCodeSettingsExtensions
{
    #region TargetPath
    /// <inheritdoc cref="ReSharperInspectCodeSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.TargetPath))]
    public static T SetTargetPath<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.TargetPath, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.TargetPath))]
    public static T ResetTargetPath<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.TargetPath));
    #endregion
    #region Output
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Output"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Output"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region Format
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Format"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Format))]
    public static T SetFormat<T>(this T o, ReSharperFormat v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Format, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Format"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Format))]
    public static T ResetFormat<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.Format));
    #endregion
    #region Jobs
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Jobs"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Jobs))]
    public static T SetJobs<T>(this T o, int? v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Jobs, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Jobs"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Jobs))]
    public static T ResetJobs<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.Jobs));
    #endregion
    #region AbsolutePaths
    /// <inheritdoc cref="ReSharperInspectCodeSettings.AbsolutePaths"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.AbsolutePaths))]
    public static T SetAbsolutePaths<T>(this T o, bool? v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.AbsolutePaths, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.AbsolutePaths"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.AbsolutePaths))]
    public static T ResetAbsolutePaths<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.AbsolutePaths));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.AbsolutePaths"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.AbsolutePaths))]
    public static T EnableAbsolutePaths<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.AbsolutePaths, true));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.AbsolutePaths"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.AbsolutePaths))]
    public static T DisableAbsolutePaths<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.AbsolutePaths, false));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.AbsolutePaths"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.AbsolutePaths))]
    public static T ToggleAbsolutePaths<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.AbsolutePaths, !o.AbsolutePaths));
    #endregion
    #region Project
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Project"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Project"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Project))]
    public static T ResetProject<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region NoSwea
    /// <inheritdoc cref="ReSharperInspectCodeSettings.NoSwea"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.NoSwea))]
    public static T SetNoSwea<T>(this T o, bool? v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.NoSwea, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.NoSwea"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.NoSwea))]
    public static T ResetNoSwea<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.NoSwea));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.NoSwea"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.NoSwea))]
    public static T EnableNoSwea<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.NoSwea, true));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.NoSwea"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.NoSwea))]
    public static T DisableNoSwea<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.NoSwea, false));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.NoSwea"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.NoSwea))]
    public static T ToggleNoSwea<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.NoSwea, !o.NoSwea));
    #endregion
    #region Severity
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Severity"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Severity))]
    public static T SetSeverity<T>(this T o, ReSharperSeverity v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Severity, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Severity"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Severity))]
    public static T ResetSeverity<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.Severity));
    #endregion
    #region DumpIssuesTypes
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DumpIssuesTypes))]
    public static T SetDumpIssuesTypes<T>(this T o, bool? v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.DumpIssuesTypes, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DumpIssuesTypes))]
    public static T ResetDumpIssuesTypes<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.DumpIssuesTypes));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DumpIssuesTypes))]
    public static T EnableDumpIssuesTypes<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.DumpIssuesTypes, true));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DumpIssuesTypes))]
    public static T DisableDumpIssuesTypes<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.DumpIssuesTypes, false));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DumpIssuesTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DumpIssuesTypes))]
    public static T ToggleDumpIssuesTypes<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.DumpIssuesTypes, !o.DumpIssuesTypes));
    #endregion
    #region Settings
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Settings"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Settings))]
    public static T SetSettings<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Settings, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Settings"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Settings))]
    public static T ResetSettings<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.Settings));
    #endregion
    #region DisableSettingsLayers
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DisableSettingsLayers))]
    public static T SetDisableSettingsLayers<T>(this T o, params ReSharperSettingsLayers[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DisableSettingsLayers))]
    public static T SetDisableSettingsLayers<T>(this T o, IEnumerable<ReSharperSettingsLayers> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DisableSettingsLayers))]
    public static T AddDisableSettingsLayers<T>(this T o, params ReSharperSettingsLayers[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddCollection(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DisableSettingsLayers))]
    public static T AddDisableSettingsLayers<T>(this T o, IEnumerable<ReSharperSettingsLayers> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddCollection(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DisableSettingsLayers))]
    public static T RemoveDisableSettingsLayers<T>(this T o, params ReSharperSettingsLayers[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveCollection(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DisableSettingsLayers))]
    public static T RemoveDisableSettingsLayers<T>(this T o, IEnumerable<ReSharperSettingsLayers> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveCollection(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DisableSettingsLayers))]
    public static T ClearDisableSettingsLayers<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.ClearCollection(() => o.DisableSettingsLayers));
    #endregion
    #region NoBuiltinSettings
    /// <inheritdoc cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.NoBuiltinSettings))]
    public static T SetNoBuiltinSettings<T>(this T o, bool? v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.NoBuiltinSettings, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.NoBuiltinSettings))]
    public static T ResetNoBuiltinSettings<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.NoBuiltinSettings));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.NoBuiltinSettings))]
    public static T EnableNoBuiltinSettings<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.NoBuiltinSettings, true));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.NoBuiltinSettings))]
    public static T DisableNoBuiltinSettings<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.NoBuiltinSettings, false));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.NoBuiltinSettings"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.NoBuiltinSettings))]
    public static T ToggleNoBuiltinSettings<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.NoBuiltinSettings, !o.NoBuiltinSettings));
    #endregion
    #region CachesHome
    /// <inheritdoc cref="ReSharperInspectCodeSettings.CachesHome"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.CachesHome))]
    public static T SetCachesHome<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.CachesHome, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.CachesHome"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.CachesHome))]
    public static T ResetCachesHome<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.CachesHome));
    #endregion
    #region CreateConfigFile
    /// <inheritdoc cref="ReSharperInspectCodeSettings.CreateConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.CreateConfigFile))]
    public static T SetCreateConfigFile<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.CreateConfigFile, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.CreateConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.CreateConfigFile))]
    public static T ResetCreateConfigFile<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.CreateConfigFile));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, ReSharperVerbosity v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region Debug
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Properties
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Properties))]
    public static T SetProperties<T>(this T o, IDictionary<string, string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Properties, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Properties))]
    public static T SetProperty<T>(this T o, string k, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.SetDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Properties))]
    public static T AddProperty<T>(this T o, string k, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Properties))]
    public static T RemoveProperty<T>(this T o, string k) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, k));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Properties))]
    public static T ClearProperties<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.ClearDictionary(() => o.Properties));
    #endregion
    #region Toolset
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Toolset"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Toolset))]
    public static T SetToolset<T>(this T o, ReSharperMSBuildToolset v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Toolset, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Toolset"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Toolset))]
    public static T ResetToolset<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.Toolset));
    #endregion
    #region ToolsetPath
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ToolsetPath"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ToolsetPath))]
    public static T SetToolsetPath<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.ToolsetPath, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ToolsetPath"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ToolsetPath))]
    public static T ResetToolsetPath<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.ToolsetPath));
    #endregion
    #region DotNetCore
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DotNetCore"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DotNetCore))]
    public static T SetDotNetCore<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.DotNetCore, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DotNetCore"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DotNetCore))]
    public static T ResetDotNetCore<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.DotNetCore));
    #endregion
    #region DotNetCoreSdk
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DotNetCoreSdk"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DotNetCoreSdk))]
    public static T SetDotNetCoreSdk<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.DotNetCoreSdk, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.DotNetCoreSdk"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.DotNetCoreSdk))]
    public static T ResetDotNetCoreSdk<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.DotNetCoreSdk));
    #endregion
    #region MonoPath
    /// <inheritdoc cref="ReSharperInspectCodeSettings.MonoPath"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.MonoPath))]
    public static T SetMonoPath<T>(this T o, string v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.MonoPath, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.MonoPath"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.MonoPath))]
    public static T ResetMonoPath<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Remove(() => o.MonoPath));
    #endregion
    #region ReferenceTargets
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ReferenceTargets))]
    public static T SetReferenceTargets<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ReferenceTargets))]
    public static T SetReferenceTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ReferenceTargets))]
    public static T AddReferenceTargets<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddCollection(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ReferenceTargets))]
    public static T AddReferenceTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddCollection(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ReferenceTargets))]
    public static T RemoveReferenceTargets<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveCollection(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ReferenceTargets))]
    public static T RemoveReferenceTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveCollection(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ReferenceTargets))]
    public static T ClearReferenceTargets<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.ClearCollection(() => o.ReferenceTargets));
    #endregion
    #region ItemTargets
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ItemTargets))]
    public static T SetItemTargets<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ItemTargets))]
    public static T SetItemTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ItemTargets))]
    public static T AddItemTargets<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddCollection(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ItemTargets))]
    public static T AddItemTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddCollection(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ItemTargets))]
    public static T RemoveItemTargets<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveCollection(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ItemTargets))]
    public static T RemoveItemTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveCollection(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.ItemTargets))]
    public static T ClearItemTargets<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.ClearCollection(() => o.ItemTargets));
    #endregion
    #region Include
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Include))]
    public static T SetInclude<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Include, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Include))]
    public static T SetInclude<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Include, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Include))]
    public static T AddInclude<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddCollection(() => o.Include, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Include))]
    public static T AddInclude<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddCollection(() => o.Include, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Include))]
    public static T RemoveInclude<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveCollection(() => o.Include, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Include))]
    public static T RemoveInclude<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveCollection(() => o.Include, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Include))]
    public static T ClearInclude<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.ClearCollection(() => o.Include));
    #endregion
    #region Exclude
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Exclude))]
    public static T SetExclude<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Exclude))]
    public static T SetExclude<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.Set(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Exclude))]
    public static T AddExclude<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddCollection(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Exclude))]
    public static T AddExclude<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.AddCollection(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Exclude))]
    public static T RemoveExclude<T>(this T o, params string[] v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveCollection(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Exclude))]
    public static T RemoveExclude<T>(this T o, IEnumerable<string> v) where T : ReSharperInspectCodeSettings => o.Modify(b => b.RemoveCollection(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperInspectCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperInspectCodeSettings), Property = nameof(ReSharperInspectCodeSettings.Exclude))]
    public static T ClearExclude<T>(this T o) where T : ReSharperInspectCodeSettings => o.Modify(b => b.ClearCollection(() => o.Exclude));
    #endregion
}
#endregion
#region ReSharperCleanupCodeSettingsExtensions
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ReSharperCleanupCodeSettingsExtensions
{
    #region TargetPath
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.TargetPath))]
    public static T SetTargetPath<T>(this T o, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.TargetPath, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.TargetPath"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.TargetPath))]
    public static T ResetTargetPath<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.TargetPath));
    #endregion
    #region Profile
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Profile"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Profile))]
    public static T SetProfile<T>(this T o, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Profile, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Profile"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Profile))]
    public static T ResetProfile<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.Profile));
    #endregion
    #region Settings
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Settings"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Settings))]
    public static T SetSettings<T>(this T o, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Settings, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Settings"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Settings))]
    public static T ResetSettings<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.Settings));
    #endregion
    #region DisableSettingsLayers
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DisableSettingsLayers))]
    public static T SetDisableSettingsLayers<T>(this T o, params ReSharperSettingsLayers[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DisableSettingsLayers))]
    public static T SetDisableSettingsLayers<T>(this T o, IEnumerable<ReSharperSettingsLayers> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DisableSettingsLayers))]
    public static T AddDisableSettingsLayers<T>(this T o, params ReSharperSettingsLayers[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddCollection(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DisableSettingsLayers))]
    public static T AddDisableSettingsLayers<T>(this T o, IEnumerable<ReSharperSettingsLayers> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddCollection(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DisableSettingsLayers))]
    public static T RemoveDisableSettingsLayers<T>(this T o, params ReSharperSettingsLayers[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveCollection(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DisableSettingsLayers))]
    public static T RemoveDisableSettingsLayers<T>(this T o, IEnumerable<ReSharperSettingsLayers> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveCollection(() => o.DisableSettingsLayers, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DisableSettingsLayers"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DisableSettingsLayers))]
    public static T ClearDisableSettingsLayers<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.ClearCollection(() => o.DisableSettingsLayers));
    #endregion
    #region NoBuiltinSettings
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.NoBuiltinSettings))]
    public static T SetNoBuiltinSettings<T>(this T o, bool? v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.NoBuiltinSettings, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.NoBuiltinSettings))]
    public static T ResetNoBuiltinSettings<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.NoBuiltinSettings));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.NoBuiltinSettings))]
    public static T EnableNoBuiltinSettings<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.NoBuiltinSettings, true));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.NoBuiltinSettings))]
    public static T DisableNoBuiltinSettings<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.NoBuiltinSettings, false));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.NoBuiltinSettings"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.NoBuiltinSettings))]
    public static T ToggleNoBuiltinSettings<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.NoBuiltinSettings, !o.NoBuiltinSettings));
    #endregion
    #region CachesHome
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.CachesHome"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.CachesHome))]
    public static T SetCachesHome<T>(this T o, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.CachesHome, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.CachesHome"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.CachesHome))]
    public static T ResetCachesHome<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.CachesHome));
    #endregion
    #region CreateConfigFile
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.CreateConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.CreateConfigFile))]
    public static T SetCreateConfigFile<T>(this T o, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.CreateConfigFile, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.CreateConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.CreateConfigFile))]
    public static T ResetCreateConfigFile<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.CreateConfigFile));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, ReSharperVerbosity v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region Debug
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Properties
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Properties))]
    public static T SetProperties<T>(this T o, IDictionary<string, string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Properties, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Properties))]
    public static T SetProperty<T>(this T o, string k, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.SetDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Properties))]
    public static T AddProperty<T>(this T o, string k, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Properties))]
    public static T RemoveProperty<T>(this T o, string k) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, k));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Properties))]
    public static T ClearProperties<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.ClearDictionary(() => o.Properties));
    #endregion
    #region Toolset
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Toolset"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Toolset))]
    public static T SetToolset<T>(this T o, ReSharperMSBuildToolset v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Toolset, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Toolset"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Toolset))]
    public static T ResetToolset<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.Toolset));
    #endregion
    #region ToolsetPath
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ToolsetPath"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ToolsetPath))]
    public static T SetToolsetPath<T>(this T o, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.ToolsetPath, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ToolsetPath"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ToolsetPath))]
    public static T ResetToolsetPath<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.ToolsetPath));
    #endregion
    #region DotNetCore
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DotNetCore"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DotNetCore))]
    public static T SetDotNetCore<T>(this T o, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.DotNetCore, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DotNetCore"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DotNetCore))]
    public static T ResetDotNetCore<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.DotNetCore));
    #endregion
    #region DotNetCoreSdk
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DotNetCoreSdk"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DotNetCoreSdk))]
    public static T SetDotNetCoreSdk<T>(this T o, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.DotNetCoreSdk, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.DotNetCoreSdk"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.DotNetCoreSdk))]
    public static T ResetDotNetCoreSdk<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.DotNetCoreSdk));
    #endregion
    #region MonoPath
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.MonoPath"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.MonoPath))]
    public static T SetMonoPath<T>(this T o, string v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.MonoPath, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.MonoPath"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.MonoPath))]
    public static T ResetMonoPath<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Remove(() => o.MonoPath));
    #endregion
    #region ReferenceTargets
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ReferenceTargets))]
    public static T SetReferenceTargets<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ReferenceTargets))]
    public static T SetReferenceTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ReferenceTargets))]
    public static T AddReferenceTargets<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddCollection(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ReferenceTargets))]
    public static T AddReferenceTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddCollection(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ReferenceTargets))]
    public static T RemoveReferenceTargets<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveCollection(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ReferenceTargets))]
    public static T RemoveReferenceTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveCollection(() => o.ReferenceTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ReferenceTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ReferenceTargets))]
    public static T ClearReferenceTargets<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.ClearCollection(() => o.ReferenceTargets));
    #endregion
    #region ItemTargets
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ItemTargets))]
    public static T SetItemTargets<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ItemTargets))]
    public static T SetItemTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ItemTargets))]
    public static T AddItemTargets<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddCollection(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ItemTargets))]
    public static T AddItemTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddCollection(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ItemTargets))]
    public static T RemoveItemTargets<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveCollection(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ItemTargets))]
    public static T RemoveItemTargets<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveCollection(() => o.ItemTargets, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.ItemTargets"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.ItemTargets))]
    public static T ClearItemTargets<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.ClearCollection(() => o.ItemTargets));
    #endregion
    #region Include
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Include))]
    public static T SetInclude<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Include, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Include))]
    public static T SetInclude<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Include, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Include))]
    public static T AddInclude<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddCollection(() => o.Include, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Include))]
    public static T AddInclude<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddCollection(() => o.Include, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Include))]
    public static T RemoveInclude<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveCollection(() => o.Include, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Include))]
    public static T RemoveInclude<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveCollection(() => o.Include, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Include"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Include))]
    public static T ClearInclude<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.ClearCollection(() => o.Include));
    #endregion
    #region Exclude
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Exclude))]
    public static T SetExclude<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Exclude))]
    public static T SetExclude<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.Set(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Exclude))]
    public static T AddExclude<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddCollection(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Exclude))]
    public static T AddExclude<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.AddCollection(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Exclude))]
    public static T RemoveExclude<T>(this T o, params string[] v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveCollection(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Exclude))]
    public static T RemoveExclude<T>(this T o, IEnumerable<string> v) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.RemoveCollection(() => o.Exclude, v));
    /// <inheritdoc cref="ReSharperCleanupCodeSettings.Exclude"/>
    [Pure] [Builder(Type = typeof(ReSharperCleanupCodeSettings), Property = nameof(ReSharperCleanupCodeSettings.Exclude))]
    public static T ClearExclude<T>(this T o) where T : ReSharperCleanupCodeSettings => o.Modify(b => b.ClearCollection(() => o.Exclude));
    #endregion
}
#endregion
#region ReSharperDupFinderSettingsExtensions
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ReSharperDupFinderSettingsExtensions
{
    #region Source
    /// <inheritdoc cref="ReSharperDupFinderSettings.Source"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Source))]
    public static T SetSource<T>(this T o, string v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.Source, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.Source"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Source))]
    public static T ResetSource<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.Source));
    #endregion
    #region OutputFile
    /// <inheritdoc cref="ReSharperDupFinderSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.OutputFile))]
    public static T SetOutputFile<T>(this T o, string v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.OutputFile, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.OutputFile"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.OutputFile))]
    public static T ResetOutputFile<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.OutputFile));
    #endregion
    #region ExcludeFiles
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeFiles"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeFiles))]
    public static T SetExcludeFiles<T>(this T o, params string[] v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ExcludeFiles, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeFiles"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeFiles))]
    public static T SetExcludeFiles<T>(this T o, IEnumerable<string> v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ExcludeFiles, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeFiles"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeFiles))]
    public static T AddExcludeFiles<T>(this T o, params string[] v) where T : ReSharperDupFinderSettings => o.Modify(b => b.AddCollection(() => o.ExcludeFiles, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeFiles"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeFiles))]
    public static T AddExcludeFiles<T>(this T o, IEnumerable<string> v) where T : ReSharperDupFinderSettings => o.Modify(b => b.AddCollection(() => o.ExcludeFiles, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeFiles"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeFiles))]
    public static T RemoveExcludeFiles<T>(this T o, params string[] v) where T : ReSharperDupFinderSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeFiles, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeFiles"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeFiles))]
    public static T RemoveExcludeFiles<T>(this T o, IEnumerable<string> v) where T : ReSharperDupFinderSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeFiles, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeFiles"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeFiles))]
    public static T ClearExcludeFiles<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.ClearCollection(() => o.ExcludeFiles));
    #endregion
    #region ExcludeComments
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeComments"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeComments))]
    public static T SetExcludeComments<T>(this T o, params string[] v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ExcludeComments, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeComments"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeComments))]
    public static T SetExcludeComments<T>(this T o, IEnumerable<string> v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ExcludeComments, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeComments"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeComments))]
    public static T AddExcludeComments<T>(this T o, params string[] v) where T : ReSharperDupFinderSettings => o.Modify(b => b.AddCollection(() => o.ExcludeComments, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeComments"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeComments))]
    public static T AddExcludeComments<T>(this T o, IEnumerable<string> v) where T : ReSharperDupFinderSettings => o.Modify(b => b.AddCollection(() => o.ExcludeComments, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeComments"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeComments))]
    public static T RemoveExcludeComments<T>(this T o, params string[] v) where T : ReSharperDupFinderSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeComments, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeComments"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeComments))]
    public static T RemoveExcludeComments<T>(this T o, IEnumerable<string> v) where T : ReSharperDupFinderSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeComments, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeComments"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeComments))]
    public static T ClearExcludeComments<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.ClearCollection(() => o.ExcludeComments));
    #endregion
    #region ExcludeCodeRegions
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeCodeRegions))]
    public static T SetExcludeCodeRegions<T>(this T o, params string[] v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ExcludeCodeRegions, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeCodeRegions))]
    public static T SetExcludeCodeRegions<T>(this T o, IEnumerable<string> v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ExcludeCodeRegions, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeCodeRegions))]
    public static T AddExcludeCodeRegions<T>(this T o, params string[] v) where T : ReSharperDupFinderSettings => o.Modify(b => b.AddCollection(() => o.ExcludeCodeRegions, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeCodeRegions))]
    public static T AddExcludeCodeRegions<T>(this T o, IEnumerable<string> v) where T : ReSharperDupFinderSettings => o.Modify(b => b.AddCollection(() => o.ExcludeCodeRegions, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeCodeRegions))]
    public static T RemoveExcludeCodeRegions<T>(this T o, params string[] v) where T : ReSharperDupFinderSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeCodeRegions, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeCodeRegions))]
    public static T RemoveExcludeCodeRegions<T>(this T o, IEnumerable<string> v) where T : ReSharperDupFinderSettings => o.Modify(b => b.RemoveCollection(() => o.ExcludeCodeRegions, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ExcludeCodeRegions"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ExcludeCodeRegions))]
    public static T ClearExcludeCodeRegions<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.ClearCollection(() => o.ExcludeCodeRegions));
    #endregion
    #region DiscardFields
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardFields"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardFields))]
    public static T SetDiscardFields<T>(this T o, bool? v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardFields, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardFields"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardFields))]
    public static T ResetDiscardFields<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.DiscardFields));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardFields"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardFields))]
    public static T EnableDiscardFields<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardFields, true));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardFields"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardFields))]
    public static T DisableDiscardFields<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardFields, false));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardFields"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardFields))]
    public static T ToggleDiscardFields<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardFields, !o.DiscardFields));
    #endregion
    #region DiscardLiterals
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardLiterals"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardLiterals))]
    public static T SetDiscardLiterals<T>(this T o, bool? v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardLiterals, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardLiterals"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardLiterals))]
    public static T ResetDiscardLiterals<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.DiscardLiterals));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardLiterals"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardLiterals))]
    public static T EnableDiscardLiterals<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardLiterals, true));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardLiterals"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardLiterals))]
    public static T DisableDiscardLiterals<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardLiterals, false));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardLiterals"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardLiterals))]
    public static T ToggleDiscardLiterals<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardLiterals, !o.DiscardLiterals));
    #endregion
    #region DiscardLocalVars
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardLocalVars"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardLocalVars))]
    public static T SetDiscardLocalVars<T>(this T o, bool? v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardLocalVars, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardLocalVars"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardLocalVars))]
    public static T ResetDiscardLocalVars<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.DiscardLocalVars));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardLocalVars"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardLocalVars))]
    public static T EnableDiscardLocalVars<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardLocalVars, true));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardLocalVars"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardLocalVars))]
    public static T DisableDiscardLocalVars<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardLocalVars, false));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardLocalVars"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardLocalVars))]
    public static T ToggleDiscardLocalVars<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardLocalVars, !o.DiscardLocalVars));
    #endregion
    #region DiscardTypes
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardTypes))]
    public static T SetDiscardTypes<T>(this T o, bool? v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardTypes, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardTypes))]
    public static T ResetDiscardTypes<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.DiscardTypes));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardTypes))]
    public static T EnableDiscardTypes<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardTypes, true));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardTypes))]
    public static T DisableDiscardTypes<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardTypes, false));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardTypes))]
    public static T ToggleDiscardTypes<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardTypes, !o.DiscardTypes));
    #endregion
    #region DiscardCost
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardCost"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardCost))]
    public static T SetDiscardCost<T>(this T o, int? v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.DiscardCost, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.DiscardCost"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.DiscardCost))]
    public static T ResetDiscardCost<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.DiscardCost));
    #endregion
    #region Properties
    /// <inheritdoc cref="ReSharperDupFinderSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Properties))]
    public static T SetProperties<T>(this T o, IDictionary<string, string> v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.Properties, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="ReSharperDupFinderSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Properties))]
    public static T SetProperty<T>(this T o, string k, string v) where T : ReSharperDupFinderSettings => o.Modify(b => b.SetDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Properties))]
    public static T AddProperty<T>(this T o, string k, string v) where T : ReSharperDupFinderSettings => o.Modify(b => b.AddDictionary(() => o.Properties, k, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Properties))]
    public static T RemoveProperty<T>(this T o, string k) where T : ReSharperDupFinderSettings => o.Modify(b => b.RemoveDictionary(() => o.Properties, k));
    /// <inheritdoc cref="ReSharperDupFinderSettings.Properties"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Properties))]
    public static T ClearProperties<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.ClearDictionary(() => o.Properties));
    #endregion
    #region NormalizeTypes
    /// <inheritdoc cref="ReSharperDupFinderSettings.NormalizeTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.NormalizeTypes))]
    public static T SetNormalizeTypes<T>(this T o, bool? v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.NormalizeTypes, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.NormalizeTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.NormalizeTypes))]
    public static T ResetNormalizeTypes<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.NormalizeTypes));
    /// <inheritdoc cref="ReSharperDupFinderSettings.NormalizeTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.NormalizeTypes))]
    public static T EnableNormalizeTypes<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.NormalizeTypes, true));
    /// <inheritdoc cref="ReSharperDupFinderSettings.NormalizeTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.NormalizeTypes))]
    public static T DisableNormalizeTypes<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.NormalizeTypes, false));
    /// <inheritdoc cref="ReSharperDupFinderSettings.NormalizeTypes"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.NormalizeTypes))]
    public static T ToggleNormalizeTypes<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.NormalizeTypes, !o.NormalizeTypes));
    #endregion
    #region ShowText
    /// <inheritdoc cref="ReSharperDupFinderSettings.ShowText"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ShowText))]
    public static T SetShowText<T>(this T o, bool? v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ShowText, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ShowText"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ShowText))]
    public static T ResetShowText<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.ShowText));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ShowText"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ShowText))]
    public static T EnableShowText<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ShowText, true));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ShowText"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ShowText))]
    public static T DisableShowText<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ShowText, false));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ShowText"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ShowText))]
    public static T ToggleShowText<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ShowText, !o.ShowText));
    #endregion
    #region CachesHome
    /// <inheritdoc cref="ReSharperDupFinderSettings.CachesHome"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.CachesHome))]
    public static T SetCachesHome<T>(this T o, string v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.CachesHome, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.CachesHome"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.CachesHome))]
    public static T ResetCachesHome<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.CachesHome));
    #endregion
    #region CreateConfigFile
    /// <inheritdoc cref="ReSharperDupFinderSettings.CreateConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.CreateConfigFile))]
    public static T SetCreateConfigFile<T>(this T o, string v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.CreateConfigFile, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.CreateConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.CreateConfigFile))]
    public static T ResetCreateConfigFile<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.CreateConfigFile));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="ReSharperDupFinderSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="ReSharperDupFinderSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, ReSharperVerbosity v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
    #region Debug
    /// <inheritdoc cref="ReSharperDupFinderSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="ReSharperDupFinderSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="ReSharperDupFinderSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="ReSharperDupFinderSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="ReSharperDupFinderSettings.Debug"/>
    [Pure] [Builder(Type = typeof(ReSharperDupFinderSettings), Property = nameof(ReSharperDupFinderSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : ReSharperDupFinderSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
}
#endregion
#region ReSharperSettingsBaseExtensions
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class ReSharperSettingsBaseExtensions
{
    #region Plugins
    /// <inheritdoc cref="ReSharperSettingsBase.Plugins"/>
    [Pure] [Builder(Type = typeof(ReSharperSettingsBase), Property = nameof(ReSharperSettingsBase.Plugins))]
    public static T SetPlugins<T>(this T o, IDictionary<string, string> v) where T : ReSharperSettingsBase => o.Modify(b => b.Set(() => o.Plugins, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="ReSharperSettingsBase.Plugins"/>
    [Pure] [Builder(Type = typeof(ReSharperSettingsBase), Property = nameof(ReSharperSettingsBase.Plugins))]
    public static T SetPlugin<T>(this T o, string k, string v) where T : ReSharperSettingsBase => o.Modify(b => b.SetDictionary(() => o.Plugins, k, v));
    /// <inheritdoc cref="ReSharperSettingsBase.Plugins"/>
    [Pure] [Builder(Type = typeof(ReSharperSettingsBase), Property = nameof(ReSharperSettingsBase.Plugins))]
    public static T AddPlugin<T>(this T o, string k, string v) where T : ReSharperSettingsBase => o.Modify(b => b.AddDictionary(() => o.Plugins, k, v));
    /// <inheritdoc cref="ReSharperSettingsBase.Plugins"/>
    [Pure] [Builder(Type = typeof(ReSharperSettingsBase), Property = nameof(ReSharperSettingsBase.Plugins))]
    public static T RemovePlugin<T>(this T o, string k) where T : ReSharperSettingsBase => o.Modify(b => b.RemoveDictionary(() => o.Plugins, k));
    /// <inheritdoc cref="ReSharperSettingsBase.Plugins"/>
    [Pure] [Builder(Type = typeof(ReSharperSettingsBase), Property = nameof(ReSharperSettingsBase.Plugins))]
    public static T ClearPlugins<T>(this T o) where T : ReSharperSettingsBase => o.Modify(b => b.ClearDictionary(() => o.Plugins));
    #endregion
}
#endregion
#region ReSharperSettingsLayers
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
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
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
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
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
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
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
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
/// <summary>Used within <see cref="ReSharperTasks"/>.</summary>
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

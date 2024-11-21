// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/WebConfigTransformRunner/WebConfigTransformRunner.json

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

namespace Nuke.Common.Tools.WebConfigTransformRunner;

/// <summary><p>This is a commandline tool to run an ASP.Net web.config tranformation.</p><p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class WebConfigTransformRunnerTasks : ToolTasks, IRequireNuGetPackage
{
    public static string WebConfigTransformRunnerPath => new WebConfigTransformRunnerTasks().GetToolPath();
    public const string PackageId = "WebConfigTransformRunner";
    public const string PackageExecutable = "WebConfigTransformRunner.exe";
    /// <summary><p>This is a commandline tool to run an ASP.Net web.config tranformation.</p><p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> WebConfigTransformRunner(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new WebConfigTransformRunnerTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>This is a commandline tool to run an ASP.Net web.config tranformation.</p><p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;outputFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.OutputFilename"/></li><li><c>&lt;transformFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.TransformFilename"/></li><li><c>&lt;webConfigFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.WebConfigFilename"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> WebConfigTransformRunner(WebConfigTransformRunnerSettings options = null) => new WebConfigTransformRunnerTasks().Run(options);
    /// <summary><p>This is a commandline tool to run an ASP.Net web.config tranformation.</p><p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;outputFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.OutputFilename"/></li><li><c>&lt;transformFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.TransformFilename"/></li><li><c>&lt;webConfigFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.WebConfigFilename"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> WebConfigTransformRunner(Configure<WebConfigTransformRunnerSettings> configurator) => new WebConfigTransformRunnerTasks().Run(configurator.Invoke(new WebConfigTransformRunnerSettings()));
    /// <summary><p>This is a commandline tool to run an ASP.Net web.config tranformation.</p><p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;outputFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.OutputFilename"/></li><li><c>&lt;transformFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.TransformFilename"/></li><li><c>&lt;webConfigFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.WebConfigFilename"/></li></ul></remarks>
    public static IEnumerable<(WebConfigTransformRunnerSettings Settings, IReadOnlyCollection<Output> Output)> WebConfigTransformRunner(CombinatorialConfigure<WebConfigTransformRunnerSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(WebConfigTransformRunner, degreeOfParallelism, completeOnFailure);
}
#region WebConfigTransformRunnerSettings
/// <summary>Used within <see cref="WebConfigTransformRunnerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<WebConfigTransformRunnerSettings>))]
[Command(Type = typeof(WebConfigTransformRunnerTasks), Command = nameof(WebConfigTransformRunnerTasks.WebConfigTransformRunner))]
public partial class WebConfigTransformRunnerSettings : ToolOptions
{
    /// <summary>The base web.config file</summary>
    [Argument(Format = "{value}", Position = 1)] public string WebConfigFilename => Get<string>(() => WebConfigFilename);
    /// <summary>The transformation web.config file</summary>
    [Argument(Format = "{value}", Position = 2)] public string TransformFilename => Get<string>(() => TransformFilename);
    /// <summary>The path to the output web.config file</summary>
    [Argument(Format = "{value}", Position = 3)] public string OutputFilename => Get<string>(() => OutputFilename);
}
#endregion
#region WebConfigTransformRunnerSettingsExtensions
/// <summary>Used within <see cref="WebConfigTransformRunnerTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class WebConfigTransformRunnerSettingsExtensions
{
    #region WebConfigFilename
    /// <inheritdoc cref="WebConfigTransformRunnerSettings.WebConfigFilename"/>
    [Pure] [Builder(Type = typeof(WebConfigTransformRunnerSettings), Property = nameof(WebConfigTransformRunnerSettings.WebConfigFilename))]
    public static T SetWebConfigFilename<T>(this T o, string v) where T : WebConfigTransformRunnerSettings => o.Modify(b => b.Set(() => o.WebConfigFilename, v));
    /// <inheritdoc cref="WebConfigTransformRunnerSettings.WebConfigFilename"/>
    [Pure] [Builder(Type = typeof(WebConfigTransformRunnerSettings), Property = nameof(WebConfigTransformRunnerSettings.WebConfigFilename))]
    public static T ResetWebConfigFilename<T>(this T o) where T : WebConfigTransformRunnerSettings => o.Modify(b => b.Remove(() => o.WebConfigFilename));
    #endregion
    #region TransformFilename
    /// <inheritdoc cref="WebConfigTransformRunnerSettings.TransformFilename"/>
    [Pure] [Builder(Type = typeof(WebConfigTransformRunnerSettings), Property = nameof(WebConfigTransformRunnerSettings.TransformFilename))]
    public static T SetTransformFilename<T>(this T o, string v) where T : WebConfigTransformRunnerSettings => o.Modify(b => b.Set(() => o.TransformFilename, v));
    /// <inheritdoc cref="WebConfigTransformRunnerSettings.TransformFilename"/>
    [Pure] [Builder(Type = typeof(WebConfigTransformRunnerSettings), Property = nameof(WebConfigTransformRunnerSettings.TransformFilename))]
    public static T ResetTransformFilename<T>(this T o) where T : WebConfigTransformRunnerSettings => o.Modify(b => b.Remove(() => o.TransformFilename));
    #endregion
    #region OutputFilename
    /// <inheritdoc cref="WebConfigTransformRunnerSettings.OutputFilename"/>
    [Pure] [Builder(Type = typeof(WebConfigTransformRunnerSettings), Property = nameof(WebConfigTransformRunnerSettings.OutputFilename))]
    public static T SetOutputFilename<T>(this T o, string v) where T : WebConfigTransformRunnerSettings => o.Modify(b => b.Set(() => o.OutputFilename, v));
    /// <inheritdoc cref="WebConfigTransformRunnerSettings.OutputFilename"/>
    [Pure] [Builder(Type = typeof(WebConfigTransformRunnerSettings), Property = nameof(WebConfigTransformRunnerSettings.OutputFilename))]
    public static T ResetOutputFilename<T>(this T o) where T : WebConfigTransformRunnerSettings => o.Modify(b => b.Remove(() => o.OutputFilename));
    #endregion
}
#endregion

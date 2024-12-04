// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Fixie/Fixie.json

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

namespace Nuke.Common.Tools.Fixie;

/// <summary><p>Fixie is a .NET modern test framework similar to NUnit and xUnit, but with an emphasis on low-ceremony defaults and flexible customization.</p><p>For more details, visit the <a href="https://fixie.github.io/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class FixieTasks : ToolTasks, IRequireNuGetPackage
{
    public static string FixiePath { get => new FixieTasks().GetToolPathInternal(); set => new FixieTasks().SetToolPath(value); }
    public const string PackageId = "fixie.console";
    public const string PackageExecutable = "dotnet-fixie.dll";
    /// <summary><p>Fixie is a .NET modern test framework similar to NUnit and xUnit, but with an emphasis on low-ceremony defaults and flexible customization.</p><p>For more details, visit the <a href="https://fixie.github.io/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Fixie(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new FixieTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>The <c>dotnet fixie</c> command is used to execute Fixie unit tests in a given project.</p><p>For more details, visit the <a href="https://fixie.github.io/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="https://www.nuke.build/docs/common/cli-tools/#fluent-api">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--</c> via <see cref="FixieSettings.CustomArguments"/></li><li><c>--configuration</c> via <see cref="FixieSettings.Configuration"/></li><li><c>--framework</c> via <see cref="FixieSettings.Framework"/></li><li><c>--no-build</c> via <see cref="FixieSettings.NoBuild"/></li><li><c>--report</c> via <see cref="FixieSettings.Report"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Fixie(FixieSettings options = null) => new FixieTasks().Run<FixieSettings>(options);
    /// <inheritdoc cref="FixieTasks.Fixie(Nuke.Common.Tools.Fixie.FixieSettings)"/>
    public static IReadOnlyCollection<Output> Fixie(Configure<FixieSettings> configurator) => new FixieTasks().Run<FixieSettings>(configurator.Invoke(new FixieSettings()));
    /// <inheritdoc cref="FixieTasks.Fixie(Nuke.Common.Tools.Fixie.FixieSettings)"/>
    public static IEnumerable<(FixieSettings Settings, IReadOnlyCollection<Output> Output)> Fixie(CombinatorialConfigure<FixieSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(Fixie, degreeOfParallelism, completeOnFailure);
}
#region FixieSettings
/// <inheritdoc cref="FixieTasks.Fixie(Nuke.Common.Tools.Fixie.FixieSettings)"/>
[PublicAPI]
[ExcludeFromCodeCoverage]
[Command(Type = typeof(FixieTasks), Command = nameof(FixieTasks.Fixie))]
public partial class FixieSettings : ToolOptions
{
    /// <summary>The configuration under which to build. When this option is omitted, the default configuration is `Debug`.</summary>
    [Argument(Format = "--configuration {value}")] public string Configuration => Get<string>(() => Configuration);
    /// <summary>Skip building the test project prior to running it.</summary>
    [Argument(Format = "--no-build")] public bool? NoBuild => Get<bool?>(() => NoBuild);
    /// <summary>Only run test assemblies targeting a specific framework.</summary>
    [Argument(Format = "--framework {value}")] public string Framework => Get<string>(() => Framework);
    /// <summary>Write test results to the specified path, using the xUnit XML format.</summary>
    [Argument(Format = "--report {value}")] public string Report => Get<string>(() => Report);
    /// <summary>Arbitrary arguments made available to custom discovery/execution classes.</summary>
    [Argument(Format = "-- {value}")] public string CustomArguments => Get<string>(() => CustomArguments);
}
#endregion
#region FixieSettingsExtensions
/// <inheritdoc cref="FixieTasks.Fixie(Nuke.Common.Tools.Fixie.FixieSettings)"/>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class FixieSettingsExtensions
{
    #region Configuration
    /// <inheritdoc cref="FixieSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.Configuration))]
    public static T SetConfiguration<T>(this T o, string v) where T : FixieSettings => o.Modify(b => b.Set(() => o.Configuration, v));
    /// <inheritdoc cref="FixieSettings.Configuration"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.Configuration))]
    public static T ResetConfiguration<T>(this T o) where T : FixieSettings => o.Modify(b => b.Remove(() => o.Configuration));
    #endregion
    #region NoBuild
    /// <inheritdoc cref="FixieSettings.NoBuild"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.NoBuild))]
    public static T SetNoBuild<T>(this T o, bool? v) where T : FixieSettings => o.Modify(b => b.Set(() => o.NoBuild, v));
    /// <inheritdoc cref="FixieSettings.NoBuild"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.NoBuild))]
    public static T ResetNoBuild<T>(this T o) where T : FixieSettings => o.Modify(b => b.Remove(() => o.NoBuild));
    /// <inheritdoc cref="FixieSettings.NoBuild"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.NoBuild))]
    public static T EnableNoBuild<T>(this T o) where T : FixieSettings => o.Modify(b => b.Set(() => o.NoBuild, true));
    /// <inheritdoc cref="FixieSettings.NoBuild"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.NoBuild))]
    public static T DisableNoBuild<T>(this T o) where T : FixieSettings => o.Modify(b => b.Set(() => o.NoBuild, false));
    /// <inheritdoc cref="FixieSettings.NoBuild"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.NoBuild))]
    public static T ToggleNoBuild<T>(this T o) where T : FixieSettings => o.Modify(b => b.Set(() => o.NoBuild, !o.NoBuild));
    #endregion
    #region Framework
    /// <inheritdoc cref="FixieSettings.Framework"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.Framework))]
    public static T SetFramework<T>(this T o, string v) where T : FixieSettings => o.Modify(b => b.Set(() => o.Framework, v));
    /// <inheritdoc cref="FixieSettings.Framework"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.Framework))]
    public static T ResetFramework<T>(this T o) where T : FixieSettings => o.Modify(b => b.Remove(() => o.Framework));
    #endregion
    #region Report
    /// <inheritdoc cref="FixieSettings.Report"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.Report))]
    public static T SetReport<T>(this T o, string v) where T : FixieSettings => o.Modify(b => b.Set(() => o.Report, v));
    /// <inheritdoc cref="FixieSettings.Report"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.Report))]
    public static T ResetReport<T>(this T o) where T : FixieSettings => o.Modify(b => b.Remove(() => o.Report));
    #endregion
    #region CustomArguments
    /// <inheritdoc cref="FixieSettings.CustomArguments"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.CustomArguments))]
    public static T SetCustomArguments<T>(this T o, string v) where T : FixieSettings => o.Modify(b => b.Set(() => o.CustomArguments, v));
    /// <inheritdoc cref="FixieSettings.CustomArguments"/>
    [Pure] [Builder(Type = typeof(FixieSettings), Property = nameof(FixieSettings.CustomArguments))]
    public static T ResetCustomArguments<T>(this T o) where T : FixieSettings => o.Modify(b => b.Remove(() => o.CustomArguments));
    #endregion
}
#endregion

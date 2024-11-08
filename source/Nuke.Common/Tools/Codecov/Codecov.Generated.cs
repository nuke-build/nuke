// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Codecov/Codecov.json

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

namespace Nuke.Common.Tools.Codecov;

/// <summary><p>Code coverage is a measurement used to express which lines of code were executed by a test suite. We use three primary terms to describe each line executed.<para/><ul><li>hit - indicates that the source code was executed by the test suite.</li><li>partial - indicates that the source code was not fully executed by the test suite; there are remaining branches that were not executed.</li><li>miss - indicates that the source code was not executed by the test suite.</li></ul><para/>Coverage is the ratio of <c>hits / (sum of hit + partial + miss)</c>. A code base that has 5 lines executed by tests out of 12 total lines will receive a coverage ratio of 41% (rounding down).<para/>Phrased simply, code coverage provides a visual measurement of what source code is being executed by a test suite. This information indicates to the software developer where they should write new tests in an effort to achieve higher coverage.<para/>Testing source code helps to prevent bugs and syntax errors by executing each line with a known variable and cross-checking it with an expected output.</p><p>For more details, visit the <a href="https://about.codecov.io/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId)]
public partial class CodecovTasks : ToolTasks, IRequireNuGetPackage
{
    public static string CodecovPath => new CodecovTasks().GetToolPath();
    public const string PackageId = "CodecovUploader";
    /// <summary><p>Code coverage is a measurement used to express which lines of code were executed by a test suite. We use three primary terms to describe each line executed.<para/><ul><li>hit - indicates that the source code was executed by the test suite.</li><li>partial - indicates that the source code was not fully executed by the test suite; there are remaining branches that were not executed.</li><li>miss - indicates that the source code was not executed by the test suite.</li></ul><para/>Coverage is the ratio of <c>hits / (sum of hit + partial + miss)</c>. A code base that has 5 lines executed by tests out of 12 total lines will receive a coverage ratio of 41% (rounding down).<para/>Phrased simply, code coverage provides a visual measurement of what source code is being executed by a test suite. This information indicates to the software developer where they should write new tests in an effort to achieve higher coverage.<para/>Testing source code helps to prevent bugs and syntax errors by executing each line with a known variable and cross-checking it with an expected output.</p><p>For more details, visit the <a href="https://about.codecov.io/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Codecov(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new CodecovTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Code coverage is a measurement used to express which lines of code were executed by a test suite. We use three primary terms to describe each line executed.<para/><ul><li>hit - indicates that the source code was executed by the test suite.</li><li>partial - indicates that the source code was not fully executed by the test suite; there are remaining branches that were not executed.</li><li>miss - indicates that the source code was not executed by the test suite.</li></ul><para/>Coverage is the ratio of <c>hits / (sum of hit + partial + miss)</c>. A code base that has 5 lines executed by tests out of 12 total lines will receive a coverage ratio of 41% (rounding down).<para/>Phrased simply, code coverage provides a visual measurement of what source code is being executed by a test suite. This information indicates to the software developer where they should write new tests in an effort to achieve higher coverage.<para/>Testing source code helps to prevent bugs and syntax errors by executing each line with a known variable and cross-checking it with an expected output.</p><p>For more details, visit the <a href="https://about.codecov.io/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--branch</c> via <see cref="CodecovSettings.Branch"/></li><li><c>--build</c> via <see cref="CodecovSettings.Build"/></li><li><c>--disable-network</c> via <see cref="CodecovSettings.DisableNetwork"/></li><li><c>--dump</c> via <see cref="CodecovSettings.Dump"/></li><li><c>--env</c> via <see cref="CodecovSettings.EnvironmentVariables"/></li><li><c>--feature</c> via <see cref="CodecovSettings.Features"/></li><li><c>--file</c> via <see cref="CodecovSettings.Files"/></li><li><c>--flag</c> via <see cref="CodecovSettings.Flags"/></li><li><c>--name</c> via <see cref="CodecovSettings.Name"/></li><li><c>--no-color</c> via <see cref="CodecovSettings.NoColor"/></li><li><c>--pr</c> via <see cref="CodecovSettings.PullRequest"/></li><li><c>--required</c> via <see cref="CodecovSettings.Required"/></li><li><c>--root</c> via <see cref="CodecovSettings.RepositoryRoot"/></li><li><c>--sha</c> via <see cref="CodecovSettings.Sha"/></li><li><c>--slug</c> via <see cref="CodecovSettings.Slug"/></li><li><c>--tag</c> via <see cref="CodecovSettings.Tag"/></li><li><c>--token</c> via <see cref="CodecovSettings.Token"/></li><li><c>--url</c> via <see cref="CodecovSettings.Url"/></li><li><c>--verbose</c> via <see cref="CodecovSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Codecov(CodecovSettings options = null) => new CodecovTasks().Run(options);
    /// <summary><p>Code coverage is a measurement used to express which lines of code were executed by a test suite. We use three primary terms to describe each line executed.<para/><ul><li>hit - indicates that the source code was executed by the test suite.</li><li>partial - indicates that the source code was not fully executed by the test suite; there are remaining branches that were not executed.</li><li>miss - indicates that the source code was not executed by the test suite.</li></ul><para/>Coverage is the ratio of <c>hits / (sum of hit + partial + miss)</c>. A code base that has 5 lines executed by tests out of 12 total lines will receive a coverage ratio of 41% (rounding down).<para/>Phrased simply, code coverage provides a visual measurement of what source code is being executed by a test suite. This information indicates to the software developer where they should write new tests in an effort to achieve higher coverage.<para/>Testing source code helps to prevent bugs and syntax errors by executing each line with a known variable and cross-checking it with an expected output.</p><p>For more details, visit the <a href="https://about.codecov.io/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--branch</c> via <see cref="CodecovSettings.Branch"/></li><li><c>--build</c> via <see cref="CodecovSettings.Build"/></li><li><c>--disable-network</c> via <see cref="CodecovSettings.DisableNetwork"/></li><li><c>--dump</c> via <see cref="CodecovSettings.Dump"/></li><li><c>--env</c> via <see cref="CodecovSettings.EnvironmentVariables"/></li><li><c>--feature</c> via <see cref="CodecovSettings.Features"/></li><li><c>--file</c> via <see cref="CodecovSettings.Files"/></li><li><c>--flag</c> via <see cref="CodecovSettings.Flags"/></li><li><c>--name</c> via <see cref="CodecovSettings.Name"/></li><li><c>--no-color</c> via <see cref="CodecovSettings.NoColor"/></li><li><c>--pr</c> via <see cref="CodecovSettings.PullRequest"/></li><li><c>--required</c> via <see cref="CodecovSettings.Required"/></li><li><c>--root</c> via <see cref="CodecovSettings.RepositoryRoot"/></li><li><c>--sha</c> via <see cref="CodecovSettings.Sha"/></li><li><c>--slug</c> via <see cref="CodecovSettings.Slug"/></li><li><c>--tag</c> via <see cref="CodecovSettings.Tag"/></li><li><c>--token</c> via <see cref="CodecovSettings.Token"/></li><li><c>--url</c> via <see cref="CodecovSettings.Url"/></li><li><c>--verbose</c> via <see cref="CodecovSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> Codecov(Configure<CodecovSettings> configurator) => new CodecovTasks().Run(configurator.Invoke(new CodecovSettings()));
    /// <summary><p>Code coverage is a measurement used to express which lines of code were executed by a test suite. We use three primary terms to describe each line executed.<para/><ul><li>hit - indicates that the source code was executed by the test suite.</li><li>partial - indicates that the source code was not fully executed by the test suite; there are remaining branches that were not executed.</li><li>miss - indicates that the source code was not executed by the test suite.</li></ul><para/>Coverage is the ratio of <c>hits / (sum of hit + partial + miss)</c>. A code base that has 5 lines executed by tests out of 12 total lines will receive a coverage ratio of 41% (rounding down).<para/>Phrased simply, code coverage provides a visual measurement of what source code is being executed by a test suite. This information indicates to the software developer where they should write new tests in an effort to achieve higher coverage.<para/>Testing source code helps to prevent bugs and syntax errors by executing each line with a known variable and cross-checking it with an expected output.</p><p>For more details, visit the <a href="https://about.codecov.io/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--branch</c> via <see cref="CodecovSettings.Branch"/></li><li><c>--build</c> via <see cref="CodecovSettings.Build"/></li><li><c>--disable-network</c> via <see cref="CodecovSettings.DisableNetwork"/></li><li><c>--dump</c> via <see cref="CodecovSettings.Dump"/></li><li><c>--env</c> via <see cref="CodecovSettings.EnvironmentVariables"/></li><li><c>--feature</c> via <see cref="CodecovSettings.Features"/></li><li><c>--file</c> via <see cref="CodecovSettings.Files"/></li><li><c>--flag</c> via <see cref="CodecovSettings.Flags"/></li><li><c>--name</c> via <see cref="CodecovSettings.Name"/></li><li><c>--no-color</c> via <see cref="CodecovSettings.NoColor"/></li><li><c>--pr</c> via <see cref="CodecovSettings.PullRequest"/></li><li><c>--required</c> via <see cref="CodecovSettings.Required"/></li><li><c>--root</c> via <see cref="CodecovSettings.RepositoryRoot"/></li><li><c>--sha</c> via <see cref="CodecovSettings.Sha"/></li><li><c>--slug</c> via <see cref="CodecovSettings.Slug"/></li><li><c>--tag</c> via <see cref="CodecovSettings.Tag"/></li><li><c>--token</c> via <see cref="CodecovSettings.Token"/></li><li><c>--url</c> via <see cref="CodecovSettings.Url"/></li><li><c>--verbose</c> via <see cref="CodecovSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(CodecovSettings Settings, IReadOnlyCollection<Output> Output)> Codecov(CombinatorialConfigure<CodecovSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(Codecov, degreeOfParallelism, completeOnFailure);
}
#region CodecovSettings
/// <summary>Used within <see cref="CodecovTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<CodecovSettings>))]
[Command(Type = typeof(CodecovTasks), Command = nameof(CodecovTasks.Codecov))]
public partial class CodecovSettings : ToolOptions
{
    /// <summary>Specify the branch name.</summary>
    [Argument(Format = "--branch {value}")] public string Branch => Get<string>(() => Branch);
    /// <summary>Specify the build number.</summary>
    [Argument(Format = "--build {value}")] public string Build => Get<string>(() => Build);
    /// <summary>Specify the commit sha.</summary>
    [Argument(Format = "--sha {value}")] public string Sha => Get<string>(() => Sha);
    /// <summary>Disable uploading the file network.</summary>
    [Argument(Format = "--disable-network")] public bool? DisableNetwork => Get<bool?>(() => DisableNetwork);
    /// <summary>Don't upload and dump to stdin.</summary>
    [Argument(Format = "--dump")] public bool? Dump => Get<bool?>(() => Dump);
    /// <summary>Specify environment variables to be included with this build.</summary>
    [Argument(Format = "--env {value}", Separator = " ")] public IReadOnlyList<string> EnvironmentVariables => Get<List<string>>(() => EnvironmentVariables);
    /// <summary>Specify features to disable.</summary>
    [Argument(Format = "--feature {value}")] public IReadOnlyList<string> Features => Get<List<string>>(() => Features);
    /// <summary>Target file(s) to upload.</summary>
    [Argument(Format = "--file {value}", Separator = " ")] public IReadOnlyList<string> Files => Get<List<string>>(() => Files);
    /// <summary>Flag the upload to group coverage metrics.</summary>
    [Argument(Format = "--flag {value}", Separator = ",")] public string Flags => Get<string>(() => Flags);
    /// <summary>Custom defined name of the upload. Visible in Codecov UI.</summary>
    [Argument(Format = "--name {value}")] public string Name => Get<string>(() => Name);
    /// <summary>Remove color from the output.</summary>
    [Argument(Format = "--no-color")] public bool? NoColor => Get<bool?>(() => NoColor);
    /// <summary>Specify the pull request number.</summary>
    [Argument(Format = "--pr {value}")] public string PullRequest => Get<string>(() => PullRequest);
    /// <summary>Used when not in git/hg project to identify project root directory.</summary>
    [Argument(Format = "--root {value}")] public string RepositoryRoot => Get<string>(() => RepositoryRoot);
    /// <summary>Exit with <c>1</c> if not successful. Default will Exit with <c>0</c>.</summary>
    [Argument(Format = "--required")] public bool? Required => Get<bool?>(() => Required);
    /// <summary>Owner/repo slug used instead of the private repo token in Enterprise.</summary>
    [Argument(Format = "--slug {value}")] public string Slug => Get<string>(() => Slug);
    /// <summary>Specify the git tag.</summary>
    [Argument(Format = "--tag {value}")] public string Tag => Get<string>(() => Tag);
    /// <summary>Set the private repository token.</summary>
    [Argument(Format = "--token {value}", Secret = true)] public string Token => Get<string>(() => Token);
    /// <summary>Set the target url for Enterprise customers.</summary>
    [Argument(Format = "--url {value}")] public string Url => Get<string>(() => Url);
    /// <summary>Verbose mode.</summary>
    [Argument(Format = "--verbose")] public bool? Verbose => Get<bool?>(() => Verbose);
    /// <summary></summary>
    public string Framework => Get<string>(() => Framework);
}
#endregion
#region CodecovSettingsExtensions
/// <summary>Used within <see cref="CodecovTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class CodecovSettingsExtensions
{
    #region Branch
    /// <inheritdoc cref="CodecovSettings.Branch"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Branch))]
    public static T SetBranch<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Branch, v));
    /// <inheritdoc cref="CodecovSettings.Branch"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Branch))]
    public static T ResetBranch<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Branch));
    #endregion
    #region Build
    /// <inheritdoc cref="CodecovSettings.Build"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Build))]
    public static T SetBuild<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Build, v));
    /// <inheritdoc cref="CodecovSettings.Build"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Build))]
    public static T ResetBuild<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Build));
    #endregion
    #region Sha
    /// <inheritdoc cref="CodecovSettings.Sha"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Sha))]
    public static T SetSha<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Sha, v));
    /// <inheritdoc cref="CodecovSettings.Sha"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Sha))]
    public static T ResetSha<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Sha));
    #endregion
    #region DisableNetwork
    /// <inheritdoc cref="CodecovSettings.DisableNetwork"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.DisableNetwork))]
    public static T SetDisableNetwork<T>(this T o, bool? v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.DisableNetwork, v));
    /// <inheritdoc cref="CodecovSettings.DisableNetwork"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.DisableNetwork))]
    public static T ResetDisableNetwork<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.DisableNetwork));
    /// <inheritdoc cref="CodecovSettings.DisableNetwork"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.DisableNetwork))]
    public static T EnableDisableNetwork<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.DisableNetwork, true));
    /// <inheritdoc cref="CodecovSettings.DisableNetwork"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.DisableNetwork))]
    public static T DisableDisableNetwork<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.DisableNetwork, false));
    /// <inheritdoc cref="CodecovSettings.DisableNetwork"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.DisableNetwork))]
    public static T ToggleDisableNetwork<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.DisableNetwork, !o.DisableNetwork));
    #endregion
    #region Dump
    /// <inheritdoc cref="CodecovSettings.Dump"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Dump))]
    public static T SetDump<T>(this T o, bool? v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Dump, v));
    /// <inheritdoc cref="CodecovSettings.Dump"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Dump))]
    public static T ResetDump<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Dump));
    /// <inheritdoc cref="CodecovSettings.Dump"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Dump))]
    public static T EnableDump<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Dump, true));
    /// <inheritdoc cref="CodecovSettings.Dump"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Dump))]
    public static T DisableDump<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Dump, false));
    /// <inheritdoc cref="CodecovSettings.Dump"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Dump))]
    public static T ToggleDump<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Dump, !o.Dump));
    #endregion
    #region EnvironmentVariables
    /// <inheritdoc cref="CodecovSettings.EnvironmentVariables"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.EnvironmentVariables))]
    public static T SetEnvironmentVariables<T>(this T o, params string[] v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.EnvironmentVariables, v));
    /// <inheritdoc cref="CodecovSettings.EnvironmentVariables"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.EnvironmentVariables))]
    public static T SetEnvironmentVariables<T>(this T o, IEnumerable<string> v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.EnvironmentVariables, v));
    /// <inheritdoc cref="CodecovSettings.EnvironmentVariables"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.EnvironmentVariables))]
    public static T AddEnvironmentVariables<T>(this T o, params string[] v) where T : CodecovSettings => o.Modify(b => b.AddCollection(() => o.EnvironmentVariables, v));
    /// <inheritdoc cref="CodecovSettings.EnvironmentVariables"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.EnvironmentVariables))]
    public static T AddEnvironmentVariables<T>(this T o, IEnumerable<string> v) where T : CodecovSettings => o.Modify(b => b.AddCollection(() => o.EnvironmentVariables, v));
    /// <inheritdoc cref="CodecovSettings.EnvironmentVariables"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.EnvironmentVariables))]
    public static T RemoveEnvironmentVariables<T>(this T o, params string[] v) where T : CodecovSettings => o.Modify(b => b.RemoveCollection(() => o.EnvironmentVariables, v));
    /// <inheritdoc cref="CodecovSettings.EnvironmentVariables"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.EnvironmentVariables))]
    public static T RemoveEnvironmentVariables<T>(this T o, IEnumerable<string> v) where T : CodecovSettings => o.Modify(b => b.RemoveCollection(() => o.EnvironmentVariables, v));
    /// <inheritdoc cref="CodecovSettings.EnvironmentVariables"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.EnvironmentVariables))]
    public static T ClearEnvironmentVariables<T>(this T o) where T : CodecovSettings => o.Modify(b => b.ClearCollection(() => o.EnvironmentVariables));
    #endregion
    #region Features
    /// <inheritdoc cref="CodecovSettings.Features"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Features))]
    public static T SetFeatures<T>(this T o, params string[] v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Features, v));
    /// <inheritdoc cref="CodecovSettings.Features"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Features))]
    public static T SetFeatures<T>(this T o, IEnumerable<string> v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Features, v));
    /// <inheritdoc cref="CodecovSettings.Features"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Features))]
    public static T AddFeatures<T>(this T o, params string[] v) where T : CodecovSettings => o.Modify(b => b.AddCollection(() => o.Features, v));
    /// <inheritdoc cref="CodecovSettings.Features"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Features))]
    public static T AddFeatures<T>(this T o, IEnumerable<string> v) where T : CodecovSettings => o.Modify(b => b.AddCollection(() => o.Features, v));
    /// <inheritdoc cref="CodecovSettings.Features"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Features))]
    public static T RemoveFeatures<T>(this T o, params string[] v) where T : CodecovSettings => o.Modify(b => b.RemoveCollection(() => o.Features, v));
    /// <inheritdoc cref="CodecovSettings.Features"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Features))]
    public static T RemoveFeatures<T>(this T o, IEnumerable<string> v) where T : CodecovSettings => o.Modify(b => b.RemoveCollection(() => o.Features, v));
    /// <inheritdoc cref="CodecovSettings.Features"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Features))]
    public static T ClearFeatures<T>(this T o) where T : CodecovSettings => o.Modify(b => b.ClearCollection(() => o.Features));
    #endregion
    #region Files
    /// <inheritdoc cref="CodecovSettings.Files"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Files))]
    public static T SetFiles<T>(this T o, params string[] v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Files, v));
    /// <inheritdoc cref="CodecovSettings.Files"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Files))]
    public static T SetFiles<T>(this T o, IEnumerable<string> v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Files, v));
    /// <inheritdoc cref="CodecovSettings.Files"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Files))]
    public static T AddFiles<T>(this T o, params string[] v) where T : CodecovSettings => o.Modify(b => b.AddCollection(() => o.Files, v));
    /// <inheritdoc cref="CodecovSettings.Files"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Files))]
    public static T AddFiles<T>(this T o, IEnumerable<string> v) where T : CodecovSettings => o.Modify(b => b.AddCollection(() => o.Files, v));
    /// <inheritdoc cref="CodecovSettings.Files"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Files))]
    public static T RemoveFiles<T>(this T o, params string[] v) where T : CodecovSettings => o.Modify(b => b.RemoveCollection(() => o.Files, v));
    /// <inheritdoc cref="CodecovSettings.Files"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Files))]
    public static T RemoveFiles<T>(this T o, IEnumerable<string> v) where T : CodecovSettings => o.Modify(b => b.RemoveCollection(() => o.Files, v));
    /// <inheritdoc cref="CodecovSettings.Files"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Files))]
    public static T ClearFiles<T>(this T o) where T : CodecovSettings => o.Modify(b => b.ClearCollection(() => o.Files));
    #endregion
    #region Flags
    /// <inheritdoc cref="CodecovSettings.Flags"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Flags))]
    public static T SetFlags<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Flags, v));
    /// <inheritdoc cref="CodecovSettings.Flags"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Flags))]
    public static T ResetFlags<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Flags));
    #endregion
    #region Name
    /// <inheritdoc cref="CodecovSettings.Name"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="CodecovSettings.Name"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Name))]
    public static T ResetName<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region NoColor
    /// <inheritdoc cref="CodecovSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="CodecovSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="CodecovSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="CodecovSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="CodecovSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
    #region PullRequest
    /// <inheritdoc cref="CodecovSettings.PullRequest"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.PullRequest))]
    public static T SetPullRequest<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.PullRequest, v));
    /// <inheritdoc cref="CodecovSettings.PullRequest"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.PullRequest))]
    public static T ResetPullRequest<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.PullRequest));
    #endregion
    #region RepositoryRoot
    /// <inheritdoc cref="CodecovSettings.RepositoryRoot"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.RepositoryRoot))]
    public static T SetRepositoryRoot<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.RepositoryRoot, v));
    /// <inheritdoc cref="CodecovSettings.RepositoryRoot"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.RepositoryRoot))]
    public static T ResetRepositoryRoot<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.RepositoryRoot));
    #endregion
    #region Required
    /// <inheritdoc cref="CodecovSettings.Required"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Required))]
    public static T SetRequired<T>(this T o, bool? v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Required, v));
    /// <inheritdoc cref="CodecovSettings.Required"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Required))]
    public static T ResetRequired<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Required));
    /// <inheritdoc cref="CodecovSettings.Required"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Required))]
    public static T EnableRequired<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Required, true));
    /// <inheritdoc cref="CodecovSettings.Required"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Required))]
    public static T DisableRequired<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Required, false));
    /// <inheritdoc cref="CodecovSettings.Required"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Required))]
    public static T ToggleRequired<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Required, !o.Required));
    #endregion
    #region Slug
    /// <inheritdoc cref="CodecovSettings.Slug"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Slug))]
    public static T SetSlug<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Slug, v));
    /// <inheritdoc cref="CodecovSettings.Slug"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Slug))]
    public static T ResetSlug<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Slug));
    #endregion
    #region Tag
    /// <inheritdoc cref="CodecovSettings.Tag"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Tag))]
    public static T SetTag<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Tag, v));
    /// <inheritdoc cref="CodecovSettings.Tag"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Tag))]
    public static T ResetTag<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Tag));
    #endregion
    #region Token
    /// <inheritdoc cref="CodecovSettings.Token"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Token))]
    public static T SetToken<T>(this T o, [Secret] string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Token, v));
    /// <inheritdoc cref="CodecovSettings.Token"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Token))]
    public static T ResetToken<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Token));
    #endregion
    #region Url
    /// <inheritdoc cref="CodecovSettings.Url"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Url))]
    public static T SetUrl<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="CodecovSettings.Url"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Url))]
    public static T ResetUrl<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Url));
    #endregion
    #region Verbose
    /// <inheritdoc cref="CodecovSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Verbose))]
    public static T SetVerbose<T>(this T o, bool? v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="CodecovSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Verbose));
    /// <inheritdoc cref="CodecovSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Verbose))]
    public static T EnableVerbose<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Verbose, true));
    /// <inheritdoc cref="CodecovSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Verbose))]
    public static T DisableVerbose<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Verbose, false));
    /// <inheritdoc cref="CodecovSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Verbose))]
    public static T ToggleVerbose<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Verbose, !o.Verbose));
    #endregion
    #region Framework
    /// <inheritdoc cref="CodecovSettings.Framework"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Framework))]
    public static T SetFramework<T>(this T o, string v) where T : CodecovSettings => o.Modify(b => b.Set(() => o.Framework, v));
    /// <inheritdoc cref="CodecovSettings.Framework"/>
    [Pure] [Builder(Type = typeof(CodecovSettings), Property = nameof(CodecovSettings.Framework))]
    public static T ResetFramework<T>(this T o) where T : CodecovSettings => o.Modify(b => b.Remove(() => o.Framework));
    #endregion
}
#endregion

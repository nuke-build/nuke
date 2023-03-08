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

namespace Nuke.Common.Tools.Codecov
{
    /// <summary>
    ///   <p>Code coverage is a measurement used to express which lines of code were executed by a test suite. We use three primary terms to describe each line executed.<para/><ul><li>hit - indicates that the source code was executed by the test suite.</li><li>partial - indicates that the source code was not fully executed by the test suite; there are remaining branches that were not executed.</li><li>miss - indicates that the source code was not executed by the test suite.</li></ul><para/>Coverage is the ratio of <c>hits / (sum of hit + partial + miss)</c>. A code base that has 5 lines executed by tests out of 12 total lines will receive a coverage ratio of 41% (rounding down).<para/>Phrased simply, code coverage provides a visual measurement of what source code is being executed by a test suite. This information indicates to the software developer where they should write new tests in an effort to achieve higher coverage.<para/>Testing source code helps to prevent bugs and syntax errors by executing each line with a known variable and cross-checking it with an expected output.</p>
    ///   <p>For more details, visit the <a href="https://about.codecov.io/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(CodecovPackageId)]
    public partial class CodecovTasks
        : IRequireNuGetPackage
    {
        public const string CodecovPackageId = "Codecov.Tool";
        /// <summary>
        ///   Path to the Codecov executable.
        /// </summary>
        public static string CodecovPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("CODECOV_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> CodecovLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Code coverage is a measurement used to express which lines of code were executed by a test suite. We use three primary terms to describe each line executed.<para/><ul><li>hit - indicates that the source code was executed by the test suite.</li><li>partial - indicates that the source code was not fully executed by the test suite; there are remaining branches that were not executed.</li><li>miss - indicates that the source code was not executed by the test suite.</li></ul><para/>Coverage is the ratio of <c>hits / (sum of hit + partial + miss)</c>. A code base that has 5 lines executed by tests out of 12 total lines will receive a coverage ratio of 41% (rounding down).<para/>Phrased simply, code coverage provides a visual measurement of what source code is being executed by a test suite. This information indicates to the software developer where they should write new tests in an effort to achieve higher coverage.<para/>Testing source code helps to prevent bugs and syntax errors by executing each line with a known variable and cross-checking it with an expected output.</p>
        ///   <p>For more details, visit the <a href="https://about.codecov.io/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Codecov(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(CodecovPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? CodecovLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Code coverage is a measurement used to express which lines of code were executed by a test suite. We use three primary terms to describe each line executed.<para/><ul><li>hit - indicates that the source code was executed by the test suite.</li><li>partial - indicates that the source code was not fully executed by the test suite; there are remaining branches that were not executed.</li><li>miss - indicates that the source code was not executed by the test suite.</li></ul><para/>Coverage is the ratio of <c>hits / (sum of hit + partial + miss)</c>. A code base that has 5 lines executed by tests out of 12 total lines will receive a coverage ratio of 41% (rounding down).<para/>Phrased simply, code coverage provides a visual measurement of what source code is being executed by a test suite. This information indicates to the software developer where they should write new tests in an effort to achieve higher coverage.<para/>Testing source code helps to prevent bugs and syntax errors by executing each line with a known variable and cross-checking it with an expected output.</p>
        ///   <p>For more details, visit the <a href="https://about.codecov.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--branch</c> via <see cref="CodecovSettings.Branch"/></li>
        ///     <li><c>--build</c> via <see cref="CodecovSettings.Build"/></li>
        ///     <li><c>--disable-network</c> via <see cref="CodecovSettings.DisableNetwork"/></li>
        ///     <li><c>--dump</c> via <see cref="CodecovSettings.Dump"/></li>
        ///     <li><c>--env</c> via <see cref="CodecovSettings.EnvironmentVariables"/></li>
        ///     <li><c>--feature</c> via <see cref="CodecovSettings.Features"/></li>
        ///     <li><c>--file</c> via <see cref="CodecovSettings.Files"/></li>
        ///     <li><c>--flag</c> via <see cref="CodecovSettings.Flags"/></li>
        ///     <li><c>--name</c> via <see cref="CodecovSettings.Name"/></li>
        ///     <li><c>--no-color</c> via <see cref="CodecovSettings.NoColor"/></li>
        ///     <li><c>--pr</c> via <see cref="CodecovSettings.PullRequest"/></li>
        ///     <li><c>--required</c> via <see cref="CodecovSettings.Required"/></li>
        ///     <li><c>--root</c> via <see cref="CodecovSettings.RepositoryRoot"/></li>
        ///     <li><c>--sha</c> via <see cref="CodecovSettings.Sha"/></li>
        ///     <li><c>--slug</c> via <see cref="CodecovSettings.Slug"/></li>
        ///     <li><c>--tag</c> via <see cref="CodecovSettings.Tag"/></li>
        ///     <li><c>--token</c> via <see cref="CodecovSettings.Token"/></li>
        ///     <li><c>--url</c> via <see cref="CodecovSettings.Url"/></li>
        ///     <li><c>--verbose</c> via <see cref="CodecovSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Codecov(CodecovSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CodecovSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Code coverage is a measurement used to express which lines of code were executed by a test suite. We use three primary terms to describe each line executed.<para/><ul><li>hit - indicates that the source code was executed by the test suite.</li><li>partial - indicates that the source code was not fully executed by the test suite; there are remaining branches that were not executed.</li><li>miss - indicates that the source code was not executed by the test suite.</li></ul><para/>Coverage is the ratio of <c>hits / (sum of hit + partial + miss)</c>. A code base that has 5 lines executed by tests out of 12 total lines will receive a coverage ratio of 41% (rounding down).<para/>Phrased simply, code coverage provides a visual measurement of what source code is being executed by a test suite. This information indicates to the software developer where they should write new tests in an effort to achieve higher coverage.<para/>Testing source code helps to prevent bugs and syntax errors by executing each line with a known variable and cross-checking it with an expected output.</p>
        ///   <p>For more details, visit the <a href="https://about.codecov.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--branch</c> via <see cref="CodecovSettings.Branch"/></li>
        ///     <li><c>--build</c> via <see cref="CodecovSettings.Build"/></li>
        ///     <li><c>--disable-network</c> via <see cref="CodecovSettings.DisableNetwork"/></li>
        ///     <li><c>--dump</c> via <see cref="CodecovSettings.Dump"/></li>
        ///     <li><c>--env</c> via <see cref="CodecovSettings.EnvironmentVariables"/></li>
        ///     <li><c>--feature</c> via <see cref="CodecovSettings.Features"/></li>
        ///     <li><c>--file</c> via <see cref="CodecovSettings.Files"/></li>
        ///     <li><c>--flag</c> via <see cref="CodecovSettings.Flags"/></li>
        ///     <li><c>--name</c> via <see cref="CodecovSettings.Name"/></li>
        ///     <li><c>--no-color</c> via <see cref="CodecovSettings.NoColor"/></li>
        ///     <li><c>--pr</c> via <see cref="CodecovSettings.PullRequest"/></li>
        ///     <li><c>--required</c> via <see cref="CodecovSettings.Required"/></li>
        ///     <li><c>--root</c> via <see cref="CodecovSettings.RepositoryRoot"/></li>
        ///     <li><c>--sha</c> via <see cref="CodecovSettings.Sha"/></li>
        ///     <li><c>--slug</c> via <see cref="CodecovSettings.Slug"/></li>
        ///     <li><c>--tag</c> via <see cref="CodecovSettings.Tag"/></li>
        ///     <li><c>--token</c> via <see cref="CodecovSettings.Token"/></li>
        ///     <li><c>--url</c> via <see cref="CodecovSettings.Url"/></li>
        ///     <li><c>--verbose</c> via <see cref="CodecovSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Codecov(Configure<CodecovSettings> configurator)
        {
            return Codecov(configurator(new CodecovSettings()));
        }
        /// <summary>
        ///   <p>Code coverage is a measurement used to express which lines of code were executed by a test suite. We use three primary terms to describe each line executed.<para/><ul><li>hit - indicates that the source code was executed by the test suite.</li><li>partial - indicates that the source code was not fully executed by the test suite; there are remaining branches that were not executed.</li><li>miss - indicates that the source code was not executed by the test suite.</li></ul><para/>Coverage is the ratio of <c>hits / (sum of hit + partial + miss)</c>. A code base that has 5 lines executed by tests out of 12 total lines will receive a coverage ratio of 41% (rounding down).<para/>Phrased simply, code coverage provides a visual measurement of what source code is being executed by a test suite. This information indicates to the software developer where they should write new tests in an effort to achieve higher coverage.<para/>Testing source code helps to prevent bugs and syntax errors by executing each line with a known variable and cross-checking it with an expected output.</p>
        ///   <p>For more details, visit the <a href="https://about.codecov.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--branch</c> via <see cref="CodecovSettings.Branch"/></li>
        ///     <li><c>--build</c> via <see cref="CodecovSettings.Build"/></li>
        ///     <li><c>--disable-network</c> via <see cref="CodecovSettings.DisableNetwork"/></li>
        ///     <li><c>--dump</c> via <see cref="CodecovSettings.Dump"/></li>
        ///     <li><c>--env</c> via <see cref="CodecovSettings.EnvironmentVariables"/></li>
        ///     <li><c>--feature</c> via <see cref="CodecovSettings.Features"/></li>
        ///     <li><c>--file</c> via <see cref="CodecovSettings.Files"/></li>
        ///     <li><c>--flag</c> via <see cref="CodecovSettings.Flags"/></li>
        ///     <li><c>--name</c> via <see cref="CodecovSettings.Name"/></li>
        ///     <li><c>--no-color</c> via <see cref="CodecovSettings.NoColor"/></li>
        ///     <li><c>--pr</c> via <see cref="CodecovSettings.PullRequest"/></li>
        ///     <li><c>--required</c> via <see cref="CodecovSettings.Required"/></li>
        ///     <li><c>--root</c> via <see cref="CodecovSettings.RepositoryRoot"/></li>
        ///     <li><c>--sha</c> via <see cref="CodecovSettings.Sha"/></li>
        ///     <li><c>--slug</c> via <see cref="CodecovSettings.Slug"/></li>
        ///     <li><c>--tag</c> via <see cref="CodecovSettings.Tag"/></li>
        ///     <li><c>--token</c> via <see cref="CodecovSettings.Token"/></li>
        ///     <li><c>--url</c> via <see cref="CodecovSettings.Url"/></li>
        ///     <li><c>--verbose</c> via <see cref="CodecovSettings.Verbose"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CodecovSettings Settings, IReadOnlyCollection<Output> Output)> Codecov(CombinatorialConfigure<CodecovSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(Codecov, CodecovLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region CodecovSettings
    /// <summary>
    ///   Used within <see cref="CodecovTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CodecovSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Codecov executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? CodecovTasks.CodecovLogger;
        /// <summary>
        ///   Specify the branch name.
        /// </summary>
        public virtual string Branch { get; internal set; }
        /// <summary>
        ///   Specify the build number.
        /// </summary>
        public virtual string Build { get; internal set; }
        /// <summary>
        ///   Specify the commit sha.
        /// </summary>
        public virtual string Sha { get; internal set; }
        /// <summary>
        ///   Disable uploading the file network.
        /// </summary>
        public virtual bool? DisableNetwork { get; internal set; }
        /// <summary>
        ///   Don't upload and dump to stdin.
        /// </summary>
        public virtual bool? Dump { get; internal set; }
        /// <summary>
        ///   Specify environment variables to be included with this build.
        /// </summary>
        public virtual IReadOnlyList<string> EnvironmentVariables => EnvironmentVariablesInternal.AsReadOnly();
        internal List<string> EnvironmentVariablesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Specify features to disable.
        /// </summary>
        public virtual IReadOnlyList<string> Features => FeaturesInternal.AsReadOnly();
        internal List<string> FeaturesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Target file(s) to upload.
        /// </summary>
        public virtual IReadOnlyList<string> Files => FilesInternal.AsReadOnly();
        internal List<string> FilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Flag the upload to group coverage metrics.
        /// </summary>
        public virtual string Flags { get; internal set; }
        /// <summary>
        ///   Custom defined name of the upload. Visible in Codecov UI.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   Remove color from the output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Specify the pull request number.
        /// </summary>
        public virtual string PullRequest { get; internal set; }
        /// <summary>
        ///   Used when not in git/hg project to identify project root directory.
        /// </summary>
        public virtual string RepositoryRoot { get; internal set; }
        /// <summary>
        ///   Exit with <c>1</c> if not successful. Default will Exit with <c>0</c>.
        /// </summary>
        public virtual bool? Required { get; internal set; }
        /// <summary>
        ///   Owner/repo slug used instead of the private repo token in Enterprise.
        /// </summary>
        public virtual string Slug { get; internal set; }
        /// <summary>
        ///   Specify the git tag.
        /// </summary>
        public virtual string Tag { get; internal set; }
        /// <summary>
        ///   Set the private repository token.
        /// </summary>
        public virtual string Token { get; internal set; }
        /// <summary>
        ///   Set the target url for Enterprise customers.
        /// </summary>
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   Verbose mode.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("--branch {value}", Branch)
              .Add("--build {value}", Build)
              .Add("--sha {value}", Sha)
              .Add("--disable-network", DisableNetwork)
              .Add("--dump", Dump)
              .Add("--env {value}", EnvironmentVariables, separator: ' ')
              .Add("--feature {value}", Features)
              .Add("--file {value}", Files, separator: ' ')
              .Add("--flag {value}", Flags, separator: ',')
              .Add("--name {value}", Name)
              .Add("--no-color", NoColor)
              .Add("--pr {value}", PullRequest)
              .Add("--root {value}", RepositoryRoot)
              .Add("--required", Required)
              .Add("--slug {value}", Slug)
              .Add("--tag {value}", Tag)
              .Add("--token {value}", Token, secret: true)
              .Add("--url {value}", Url)
              .Add("--verbose", Verbose);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region CodecovSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CodecovTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CodecovSettingsExtensions
    {
        #region Branch
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Branch"/></em></p>
        ///   <p>Specify the branch name.</p>
        /// </summary>
        [Pure]
        public static T SetBranch<T>(this T toolSettings, string branch) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Branch = branch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Branch"/></em></p>
        ///   <p>Specify the branch name.</p>
        /// </summary>
        [Pure]
        public static T ResetBranch<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Branch = null;
            return toolSettings;
        }
        #endregion
        #region Build
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Build"/></em></p>
        ///   <p>Specify the build number.</p>
        /// </summary>
        [Pure]
        public static T SetBuild<T>(this T toolSettings, string build) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = build;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Build"/></em></p>
        ///   <p>Specify the build number.</p>
        /// </summary>
        [Pure]
        public static T ResetBuild<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Build = null;
            return toolSettings;
        }
        #endregion
        #region Sha
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Sha"/></em></p>
        ///   <p>Specify the commit sha.</p>
        /// </summary>
        [Pure]
        public static T SetSha<T>(this T toolSettings, string sha) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sha = sha;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Sha"/></em></p>
        ///   <p>Specify the commit sha.</p>
        /// </summary>
        [Pure]
        public static T ResetSha<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sha = null;
            return toolSettings;
        }
        #endregion
        #region DisableNetwork
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.DisableNetwork"/></em></p>
        ///   <p>Disable uploading the file network.</p>
        /// </summary>
        [Pure]
        public static T SetDisableNetwork<T>(this T toolSettings, bool? disableNetwork) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableNetwork = disableNetwork;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.DisableNetwork"/></em></p>
        ///   <p>Disable uploading the file network.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableNetwork<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableNetwork = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CodecovSettings.DisableNetwork"/></em></p>
        ///   <p>Disable uploading the file network.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableNetwork<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableNetwork = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CodecovSettings.DisableNetwork"/></em></p>
        ///   <p>Disable uploading the file network.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableNetwork<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableNetwork = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CodecovSettings.DisableNetwork"/></em></p>
        ///   <p>Disable uploading the file network.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableNetwork<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableNetwork = !toolSettings.DisableNetwork;
            return toolSettings;
        }
        #endregion
        #region Dump
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Dump"/></em></p>
        ///   <p>Don't upload and dump to stdin.</p>
        /// </summary>
        [Pure]
        public static T SetDump<T>(this T toolSettings, bool? dump) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Dump = dump;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Dump"/></em></p>
        ///   <p>Don't upload and dump to stdin.</p>
        /// </summary>
        [Pure]
        public static T ResetDump<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Dump = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CodecovSettings.Dump"/></em></p>
        ///   <p>Don't upload and dump to stdin.</p>
        /// </summary>
        [Pure]
        public static T EnableDump<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Dump = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CodecovSettings.Dump"/></em></p>
        ///   <p>Don't upload and dump to stdin.</p>
        /// </summary>
        [Pure]
        public static T DisableDump<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Dump = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CodecovSettings.Dump"/></em></p>
        ///   <p>Don't upload and dump to stdin.</p>
        /// </summary>
        [Pure]
        public static T ToggleDump<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Dump = !toolSettings.Dump;
            return toolSettings;
        }
        #endregion
        #region EnvironmentVariables
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.EnvironmentVariables"/> to a new list</em></p>
        ///   <p>Specify environment variables to be included with this build.</p>
        /// </summary>
        [Pure]
        public static T SetEnvironmentVariables<T>(this T toolSettings, params string[] environmentVariables) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvironmentVariablesInternal = environmentVariables.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.EnvironmentVariables"/> to a new list</em></p>
        ///   <p>Specify environment variables to be included with this build.</p>
        /// </summary>
        [Pure]
        public static T SetEnvironmentVariables<T>(this T toolSettings, IEnumerable<string> environmentVariables) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvironmentVariablesInternal = environmentVariables.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CodecovSettings.EnvironmentVariables"/></em></p>
        ///   <p>Specify environment variables to be included with this build.</p>
        /// </summary>
        [Pure]
        public static T AddEnvironmentVariables<T>(this T toolSettings, params string[] environmentVariables) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvironmentVariablesInternal.AddRange(environmentVariables);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CodecovSettings.EnvironmentVariables"/></em></p>
        ///   <p>Specify environment variables to be included with this build.</p>
        /// </summary>
        [Pure]
        public static T AddEnvironmentVariables<T>(this T toolSettings, IEnumerable<string> environmentVariables) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvironmentVariablesInternal.AddRange(environmentVariables);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CodecovSettings.EnvironmentVariables"/></em></p>
        ///   <p>Specify environment variables to be included with this build.</p>
        /// </summary>
        [Pure]
        public static T ClearEnvironmentVariables<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvironmentVariablesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CodecovSettings.EnvironmentVariables"/></em></p>
        ///   <p>Specify environment variables to be included with this build.</p>
        /// </summary>
        [Pure]
        public static T RemoveEnvironmentVariables<T>(this T toolSettings, params string[] environmentVariables) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(environmentVariables);
            toolSettings.EnvironmentVariablesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CodecovSettings.EnvironmentVariables"/></em></p>
        ///   <p>Specify environment variables to be included with this build.</p>
        /// </summary>
        [Pure]
        public static T RemoveEnvironmentVariables<T>(this T toolSettings, IEnumerable<string> environmentVariables) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(environmentVariables);
            toolSettings.EnvironmentVariablesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Features
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Features"/> to a new list</em></p>
        ///   <p>Specify features to disable.</p>
        /// </summary>
        [Pure]
        public static T SetFeatures<T>(this T toolSettings, params string[] features) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FeaturesInternal = features.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Features"/> to a new list</em></p>
        ///   <p>Specify features to disable.</p>
        /// </summary>
        [Pure]
        public static T SetFeatures<T>(this T toolSettings, IEnumerable<string> features) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FeaturesInternal = features.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CodecovSettings.Features"/></em></p>
        ///   <p>Specify features to disable.</p>
        /// </summary>
        [Pure]
        public static T AddFeatures<T>(this T toolSettings, params string[] features) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FeaturesInternal.AddRange(features);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CodecovSettings.Features"/></em></p>
        ///   <p>Specify features to disable.</p>
        /// </summary>
        [Pure]
        public static T AddFeatures<T>(this T toolSettings, IEnumerable<string> features) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FeaturesInternal.AddRange(features);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CodecovSettings.Features"/></em></p>
        ///   <p>Specify features to disable.</p>
        /// </summary>
        [Pure]
        public static T ClearFeatures<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FeaturesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CodecovSettings.Features"/></em></p>
        ///   <p>Specify features to disable.</p>
        /// </summary>
        [Pure]
        public static T RemoveFeatures<T>(this T toolSettings, params string[] features) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(features);
            toolSettings.FeaturesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CodecovSettings.Features"/></em></p>
        ///   <p>Specify features to disable.</p>
        /// </summary>
        [Pure]
        public static T RemoveFeatures<T>(this T toolSettings, IEnumerable<string> features) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(features);
            toolSettings.FeaturesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Files
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Files"/> to a new list</em></p>
        ///   <p>Target file(s) to upload.</p>
        /// </summary>
        [Pure]
        public static T SetFiles<T>(this T toolSettings, params string[] files) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal = files.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Files"/> to a new list</em></p>
        ///   <p>Target file(s) to upload.</p>
        /// </summary>
        [Pure]
        public static T SetFiles<T>(this T toolSettings, IEnumerable<string> files) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal = files.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CodecovSettings.Files"/></em></p>
        ///   <p>Target file(s) to upload.</p>
        /// </summary>
        [Pure]
        public static T AddFiles<T>(this T toolSettings, params string[] files) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.AddRange(files);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CodecovSettings.Files"/></em></p>
        ///   <p>Target file(s) to upload.</p>
        /// </summary>
        [Pure]
        public static T AddFiles<T>(this T toolSettings, IEnumerable<string> files) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.AddRange(files);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CodecovSettings.Files"/></em></p>
        ///   <p>Target file(s) to upload.</p>
        /// </summary>
        [Pure]
        public static T ClearFiles<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CodecovSettings.Files"/></em></p>
        ///   <p>Target file(s) to upload.</p>
        /// </summary>
        [Pure]
        public static T RemoveFiles<T>(this T toolSettings, params string[] files) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(files);
            toolSettings.FilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CodecovSettings.Files"/></em></p>
        ///   <p>Target file(s) to upload.</p>
        /// </summary>
        [Pure]
        public static T RemoveFiles<T>(this T toolSettings, IEnumerable<string> files) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(files);
            toolSettings.FilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Flags
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Flags"/></em></p>
        ///   <p>Flag the upload to group coverage metrics.</p>
        /// </summary>
        [Pure]
        public static T SetFlags<T>(this T toolSettings, string flags) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Flags = flags;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Flags"/></em></p>
        ///   <p>Flag the upload to group coverage metrics.</p>
        /// </summary>
        [Pure]
        public static T ResetFlags<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Flags = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Name"/></em></p>
        ///   <p>Custom defined name of the upload. Visible in Codecov UI.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Name"/></em></p>
        ///   <p>Custom defined name of the upload. Visible in Codecov UI.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.NoColor"/></em></p>
        ///   <p>Remove color from the output.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.NoColor"/></em></p>
        ///   <p>Remove color from the output.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CodecovSettings.NoColor"/></em></p>
        ///   <p>Remove color from the output.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CodecovSettings.NoColor"/></em></p>
        ///   <p>Remove color from the output.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CodecovSettings.NoColor"/></em></p>
        ///   <p>Remove color from the output.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region PullRequest
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.PullRequest"/></em></p>
        ///   <p>Specify the pull request number.</p>
        /// </summary>
        [Pure]
        public static T SetPullRequest<T>(this T toolSettings, string pullRequest) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequest = pullRequest;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.PullRequest"/></em></p>
        ///   <p>Specify the pull request number.</p>
        /// </summary>
        [Pure]
        public static T ResetPullRequest<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PullRequest = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryRoot
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.RepositoryRoot"/></em></p>
        ///   <p>Used when not in git/hg project to identify project root directory.</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryRoot<T>(this T toolSettings, string repositoryRoot) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryRoot = repositoryRoot;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.RepositoryRoot"/></em></p>
        ///   <p>Used when not in git/hg project to identify project root directory.</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryRoot<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryRoot = null;
            return toolSettings;
        }
        #endregion
        #region Required
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Required"/></em></p>
        ///   <p>Exit with <c>1</c> if not successful. Default will Exit with <c>0</c>.</p>
        /// </summary>
        [Pure]
        public static T SetRequired<T>(this T toolSettings, bool? required) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Required = required;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Required"/></em></p>
        ///   <p>Exit with <c>1</c> if not successful. Default will Exit with <c>0</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetRequired<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Required = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CodecovSettings.Required"/></em></p>
        ///   <p>Exit with <c>1</c> if not successful. Default will Exit with <c>0</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableRequired<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Required = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CodecovSettings.Required"/></em></p>
        ///   <p>Exit with <c>1</c> if not successful. Default will Exit with <c>0</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableRequired<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Required = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CodecovSettings.Required"/></em></p>
        ///   <p>Exit with <c>1</c> if not successful. Default will Exit with <c>0</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleRequired<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Required = !toolSettings.Required;
            return toolSettings;
        }
        #endregion
        #region Slug
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Slug"/></em></p>
        ///   <p>Owner/repo slug used instead of the private repo token in Enterprise.</p>
        /// </summary>
        [Pure]
        public static T SetSlug<T>(this T toolSettings, string slug) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Slug = slug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Slug"/></em></p>
        ///   <p>Owner/repo slug used instead of the private repo token in Enterprise.</p>
        /// </summary>
        [Pure]
        public static T ResetSlug<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Slug = null;
            return toolSettings;
        }
        #endregion
        #region Tag
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Tag"/></em></p>
        ///   <p>Specify the git tag.</p>
        /// </summary>
        [Pure]
        public static T SetTag<T>(this T toolSettings, string tag) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tag = tag;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Tag"/></em></p>
        ///   <p>Specify the git tag.</p>
        /// </summary>
        [Pure]
        public static T ResetTag<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tag = null;
            return toolSettings;
        }
        #endregion
        #region Token
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Token"/></em></p>
        ///   <p>Set the private repository token.</p>
        /// </summary>
        [Pure]
        public static T SetToken<T>(this T toolSettings, [Secret] string token) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Token = token;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Token"/></em></p>
        ///   <p>Set the private repository token.</p>
        /// </summary>
        [Pure]
        public static T ResetToken<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Token = null;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Url"/></em></p>
        ///   <p>Set the target url for Enterprise customers.</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Url"/></em></p>
        ///   <p>Set the target url for Enterprise customers.</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Verbose"/></em></p>
        ///   <p>Verbose mode.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Verbose"/></em></p>
        ///   <p>Verbose mode.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CodecovSettings.Verbose"/></em></p>
        ///   <p>Verbose mode.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CodecovSettings.Verbose"/></em></p>
        ///   <p>Verbose mode.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CodecovSettings.Verbose"/></em></p>
        ///   <p>Verbose mode.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="CodecovSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CodecovSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : CodecovSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}

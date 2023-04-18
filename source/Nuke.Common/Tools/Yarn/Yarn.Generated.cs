// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Yarn/Yarn.json

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

namespace Nuke.Common.Tools.Yarn
{
    /// <summary>
    ///   <p>Yarn is a package manager that doubles down as project manager. Whether you work on one-shot projects or large monorepos, as a hobbyist or an enterprise user, we've got you covered.</p>
    ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [PathToolRequirement(YarnPathExecutable)]
    public partial class YarnTasks
        : IRequirePathTool
    {
        public const string YarnPathExecutable = "yarn";
        /// <summary>
        ///   Path to the Yarn executable.
        /// </summary>
        public static string YarnPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("YARN_EXE") ??
            ToolPathResolver.GetPathExecutable("yarn");
        public static Action<OutputType, string> YarnLogger { get; set; } = CustomLogger;
        /// <summary>
        ///   <p>Yarn is a package manager that doubles down as project manager. Whether you work on one-shot projects or large monorepos, as a hobbyist or an enterprise user, we've got you covered.</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Yarn(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(YarnPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? YarnLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Install the project dependencies</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--check-cache</c> via <see cref="YarnInstallSettings.CheckCache"/></li>
        ///     <li><c>--immutable</c> via <see cref="YarnInstallSettings.Immutable"/></li>
        ///     <li><c>--immutable-cache</c> via <see cref="YarnInstallSettings.ImmutableCache"/></li>
        ///     <li><c>--inline-builds</c> via <see cref="YarnInstallSettings.InlineBuilds"/></li>
        ///     <li><c>--json</c> via <see cref="YarnInstallSettings.Json"/></li>
        ///     <li><c>--mode</c> via <see cref="YarnInstallSettings.Mode"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> YarnInstall(YarnInstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new YarnInstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Install the project dependencies</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--check-cache</c> via <see cref="YarnInstallSettings.CheckCache"/></li>
        ///     <li><c>--immutable</c> via <see cref="YarnInstallSettings.Immutable"/></li>
        ///     <li><c>--immutable-cache</c> via <see cref="YarnInstallSettings.ImmutableCache"/></li>
        ///     <li><c>--inline-builds</c> via <see cref="YarnInstallSettings.InlineBuilds"/></li>
        ///     <li><c>--json</c> via <see cref="YarnInstallSettings.Json"/></li>
        ///     <li><c>--mode</c> via <see cref="YarnInstallSettings.Mode"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> YarnInstall(Configure<YarnInstallSettings> configurator)
        {
            return YarnInstall(configurator(new YarnInstallSettings()));
        }
        /// <summary>
        ///   <p>Install the project dependencies</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--check-cache</c> via <see cref="YarnInstallSettings.CheckCache"/></li>
        ///     <li><c>--immutable</c> via <see cref="YarnInstallSettings.Immutable"/></li>
        ///     <li><c>--immutable-cache</c> via <see cref="YarnInstallSettings.ImmutableCache"/></li>
        ///     <li><c>--inline-builds</c> via <see cref="YarnInstallSettings.InlineBuilds"/></li>
        ///     <li><c>--json</c> via <see cref="YarnInstallSettings.Json"/></li>
        ///     <li><c>--mode</c> via <see cref="YarnInstallSettings.Mode"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(YarnInstallSettings Settings, IReadOnlyCollection<Output> Output)> YarnInstall(CombinatorialConfigure<YarnInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(YarnInstall, YarnLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Run a script defined in the package.json</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;arguments&gt;</c> via <see cref="YarnRunSettings.Arguments"/></li>
        ///     <li><c>&lt;command&gt;</c> via <see cref="YarnRunSettings.Command"/></li>
        ///     <li><c>--binaries-only</c> via <see cref="YarnRunSettings.BinariesOnly"/></li>
        ///     <li><c>--top-level</c> via <see cref="YarnRunSettings.TopLevel"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> YarnRun(YarnRunSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new YarnRunSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Run a script defined in the package.json</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;arguments&gt;</c> via <see cref="YarnRunSettings.Arguments"/></li>
        ///     <li><c>&lt;command&gt;</c> via <see cref="YarnRunSettings.Command"/></li>
        ///     <li><c>--binaries-only</c> via <see cref="YarnRunSettings.BinariesOnly"/></li>
        ///     <li><c>--top-level</c> via <see cref="YarnRunSettings.TopLevel"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> YarnRun(Configure<YarnRunSettings> configurator)
        {
            return YarnRun(configurator(new YarnRunSettings()));
        }
        /// <summary>
        ///   <p>Run a script defined in the package.json</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;arguments&gt;</c> via <see cref="YarnRunSettings.Arguments"/></li>
        ///     <li><c>&lt;command&gt;</c> via <see cref="YarnRunSettings.Command"/></li>
        ///     <li><c>--binaries-only</c> via <see cref="YarnRunSettings.BinariesOnly"/></li>
        ///     <li><c>--top-level</c> via <see cref="YarnRunSettings.TopLevel"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(YarnRunSettings Settings, IReadOnlyCollection<Output> Output)> YarnRun(CombinatorialConfigure<YarnRunSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(YarnRun, YarnLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Read a configuration settings</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="YarnGetConfigSettings.Name"/></li>
        ///     <li><c>--json</c> via <see cref="YarnGetConfigSettings.Json"/></li>
        ///     <li><c>--no-redacted</c> via <see cref="YarnGetConfigSettings.NoRedacted"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> YarnGetConfig(YarnGetConfigSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new YarnGetConfigSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Read a configuration settings</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="YarnGetConfigSettings.Name"/></li>
        ///     <li><c>--json</c> via <see cref="YarnGetConfigSettings.Json"/></li>
        ///     <li><c>--no-redacted</c> via <see cref="YarnGetConfigSettings.NoRedacted"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> YarnGetConfig(Configure<YarnGetConfigSettings> configurator)
        {
            return YarnGetConfig(configurator(new YarnGetConfigSettings()));
        }
        /// <summary>
        ///   <p>Read a configuration settings</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="YarnGetConfigSettings.Name"/></li>
        ///     <li><c>--json</c> via <see cref="YarnGetConfigSettings.Json"/></li>
        ///     <li><c>--no-redacted</c> via <see cref="YarnGetConfigSettings.NoRedacted"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(YarnGetConfigSettings Settings, IReadOnlyCollection<Output> Output)> YarnGetConfig(CombinatorialConfigure<YarnGetConfigSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(YarnGetConfig, YarnLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Change a configuration settings</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="YarnSetConfigSettings.Name"/></li>
        ///     <li><c>&lt;value&gt;</c> via <see cref="YarnSetConfigSettings.Value"/></li>
        ///     <li><c>--home</c> via <see cref="YarnSetConfigSettings.Home"/></li>
        ///     <li><c>--json</c> via <see cref="YarnSetConfigSettings.Json"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> YarnSetConfig(YarnSetConfigSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new YarnSetConfigSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Change a configuration settings</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="YarnSetConfigSettings.Name"/></li>
        ///     <li><c>&lt;value&gt;</c> via <see cref="YarnSetConfigSettings.Value"/></li>
        ///     <li><c>--home</c> via <see cref="YarnSetConfigSettings.Home"/></li>
        ///     <li><c>--json</c> via <see cref="YarnSetConfigSettings.Json"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> YarnSetConfig(Configure<YarnSetConfigSettings> configurator)
        {
            return YarnSetConfig(configurator(new YarnSetConfigSettings()));
        }
        /// <summary>
        ///   <p>Change a configuration settings</p>
        ///   <p>For more details, visit the <a href="https://yarnpkg.com/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="YarnSetConfigSettings.Name"/></li>
        ///     <li><c>&lt;value&gt;</c> via <see cref="YarnSetConfigSettings.Value"/></li>
        ///     <li><c>--home</c> via <see cref="YarnSetConfigSettings.Home"/></li>
        ///     <li><c>--json</c> via <see cref="YarnSetConfigSettings.Json"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(YarnSetConfigSettings Settings, IReadOnlyCollection<Output> Output)> YarnSetConfig(CombinatorialConfigure<YarnSetConfigSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(YarnSetConfig, YarnLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region YarnInstallSettings
    /// <summary>
    ///   Used within <see cref="YarnTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class YarnInstallSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Yarn executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? YarnTasks.YarnPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? YarnTasks.YarnLogger;
        /// <summary>
        ///   Format the output as an NDJSON stream.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   Abort with an error exit code if the lockfile was to be modified.
        /// </summary>
        public virtual bool? Immutable { get; internal set; }
        /// <summary>
        ///   Abort with an error exit code if the cache folder was to be modified.
        /// </summary>
        public virtual bool? ImmutableCache { get; internal set; }
        /// <summary>
        ///   Always refetch the packages and ensure that their checksums are consistent.
        /// </summary>
        public virtual bool? CheckCache { get; internal set; }
        /// <summary>
        ///   Verbosely print the output of the build steps of dependencies.
        /// </summary>
        public virtual bool? InlineBuilds { get; internal set; }
        /// <summary>
        ///   If the <c>--mode=<mode></c> option is set, Yarn will change which artifacts are generated.
        /// </summary>
        public virtual YarnInstallMode Mode { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("install")
              .Add("--json", Json)
              .Add("--immutable", Immutable)
              .Add("--immutable-cache", ImmutableCache)
              .Add("--check-cache", CheckCache)
              .Add("--inline-builds", InlineBuilds)
              .Add("--mode={value}", Mode);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region YarnRunSettings
    /// <summary>
    ///   Used within <see cref="YarnTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class YarnRunSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Yarn executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? YarnTasks.YarnPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? YarnTasks.YarnLogger;
        /// <summary>
        ///   The command to be executed.
        /// </summary>
        public virtual string Command { get; internal set; }
        /// <summary>
        ///   Arguments passed to the script.
        /// </summary>
        public virtual IReadOnlyList<string> Arguments => ArgumentsInternal.AsReadOnly();
        internal List<string> ArgumentsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Check the root workspace for scripts and/or binaries instead of the current one.
        /// </summary>
        public virtual bool? TopLevel { get; internal set; }
        /// <summary>
        ///   Ignore any user defined scripts and only check for binaries.
        /// </summary>
        public virtual bool? BinariesOnly { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("run")
              .Add("{value}", Command)
              .Add("{value}", Arguments, separator: ' ')
              .Add("--top-level", TopLevel)
              .Add("--binaries-only", BinariesOnly);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region YarnGetConfigSettings
    /// <summary>
    ///   Used within <see cref="YarnTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class YarnGetConfigSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Yarn executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? YarnTasks.YarnPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? YarnTasks.YarnLogger;
        /// <summary>
        ///   The name of the configuration setting.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   Format the output as an NDJSON stream.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   Don't redact secrets (such as tokens) from the output.
        /// </summary>
        public virtual bool? NoRedacted { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("config get")
              .Add("{value}", Name)
              .Add("--json", Json)
              .Add("--no-redacted", NoRedacted);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region YarnSetConfigSettings
    /// <summary>
    ///   Used within <see cref="YarnTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class YarnSetConfigSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Yarn executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? YarnTasks.YarnPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? YarnTasks.YarnLogger;
        /// <summary>
        ///   The name of the configuration setting.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   Set complex configuration settings to JSON values.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   The value of the configuration setting.
        /// </summary>
        public virtual string Value { get; internal set; }
        /// <summary>
        ///   Update the home configuration instead of the project configuration.
        /// </summary>
        public virtual bool? Home { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("config set")
              .Add("{value}", Name)
              .Add("--json", Json)
              .Add("{value}", Value)
              .Add("--home", Home);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region YarnInstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="YarnTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class YarnInstallSettingsExtensions
    {
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="YarnInstallSettings.Json"/></em></p>
        ///   <p>Format the output as an NDJSON stream.</p>
        /// </summary>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnInstallSettings.Json"/></em></p>
        ///   <p>Format the output as an NDJSON stream.</p>
        /// </summary>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnInstallSettings.Json"/></em></p>
        ///   <p>Format the output as an NDJSON stream.</p>
        /// </summary>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnInstallSettings.Json"/></em></p>
        ///   <p>Format the output as an NDJSON stream.</p>
        /// </summary>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnInstallSettings.Json"/></em></p>
        ///   <p>Format the output as an NDJSON stream.</p>
        /// </summary>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Immutable
        /// <summary>
        ///   <p><em>Sets <see cref="YarnInstallSettings.Immutable"/></em></p>
        ///   <p>Abort with an error exit code if the lockfile was to be modified.</p>
        /// </summary>
        [Pure]
        public static T SetImmutable<T>(this T toolSettings, bool? immutable) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Immutable = immutable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnInstallSettings.Immutable"/></em></p>
        ///   <p>Abort with an error exit code if the lockfile was to be modified.</p>
        /// </summary>
        [Pure]
        public static T ResetImmutable<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Immutable = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnInstallSettings.Immutable"/></em></p>
        ///   <p>Abort with an error exit code if the lockfile was to be modified.</p>
        /// </summary>
        [Pure]
        public static T EnableImmutable<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Immutable = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnInstallSettings.Immutable"/></em></p>
        ///   <p>Abort with an error exit code if the lockfile was to be modified.</p>
        /// </summary>
        [Pure]
        public static T DisableImmutable<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Immutable = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnInstallSettings.Immutable"/></em></p>
        ///   <p>Abort with an error exit code if the lockfile was to be modified.</p>
        /// </summary>
        [Pure]
        public static T ToggleImmutable<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Immutable = !toolSettings.Immutable;
            return toolSettings;
        }
        #endregion
        #region ImmutableCache
        /// <summary>
        ///   <p><em>Sets <see cref="YarnInstallSettings.ImmutableCache"/></em></p>
        ///   <p>Abort with an error exit code if the cache folder was to be modified.</p>
        /// </summary>
        [Pure]
        public static T SetImmutableCache<T>(this T toolSettings, bool? immutableCache) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImmutableCache = immutableCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnInstallSettings.ImmutableCache"/></em></p>
        ///   <p>Abort with an error exit code if the cache folder was to be modified.</p>
        /// </summary>
        [Pure]
        public static T ResetImmutableCache<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImmutableCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnInstallSettings.ImmutableCache"/></em></p>
        ///   <p>Abort with an error exit code if the cache folder was to be modified.</p>
        /// </summary>
        [Pure]
        public static T EnableImmutableCache<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImmutableCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnInstallSettings.ImmutableCache"/></em></p>
        ///   <p>Abort with an error exit code if the cache folder was to be modified.</p>
        /// </summary>
        [Pure]
        public static T DisableImmutableCache<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImmutableCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnInstallSettings.ImmutableCache"/></em></p>
        ///   <p>Abort with an error exit code if the cache folder was to be modified.</p>
        /// </summary>
        [Pure]
        public static T ToggleImmutableCache<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ImmutableCache = !toolSettings.ImmutableCache;
            return toolSettings;
        }
        #endregion
        #region CheckCache
        /// <summary>
        ///   <p><em>Sets <see cref="YarnInstallSettings.CheckCache"/></em></p>
        ///   <p>Always refetch the packages and ensure that their checksums are consistent.</p>
        /// </summary>
        [Pure]
        public static T SetCheckCache<T>(this T toolSettings, bool? checkCache) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckCache = checkCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnInstallSettings.CheckCache"/></em></p>
        ///   <p>Always refetch the packages and ensure that their checksums are consistent.</p>
        /// </summary>
        [Pure]
        public static T ResetCheckCache<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckCache = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnInstallSettings.CheckCache"/></em></p>
        ///   <p>Always refetch the packages and ensure that their checksums are consistent.</p>
        /// </summary>
        [Pure]
        public static T EnableCheckCache<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckCache = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnInstallSettings.CheckCache"/></em></p>
        ///   <p>Always refetch the packages and ensure that their checksums are consistent.</p>
        /// </summary>
        [Pure]
        public static T DisableCheckCache<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckCache = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnInstallSettings.CheckCache"/></em></p>
        ///   <p>Always refetch the packages and ensure that their checksums are consistent.</p>
        /// </summary>
        [Pure]
        public static T ToggleCheckCache<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CheckCache = !toolSettings.CheckCache;
            return toolSettings;
        }
        #endregion
        #region InlineBuilds
        /// <summary>
        ///   <p><em>Sets <see cref="YarnInstallSettings.InlineBuilds"/></em></p>
        ///   <p>Verbosely print the output of the build steps of dependencies.</p>
        /// </summary>
        [Pure]
        public static T SetInlineBuilds<T>(this T toolSettings, bool? inlineBuilds) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InlineBuilds = inlineBuilds;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnInstallSettings.InlineBuilds"/></em></p>
        ///   <p>Verbosely print the output of the build steps of dependencies.</p>
        /// </summary>
        [Pure]
        public static T ResetInlineBuilds<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InlineBuilds = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnInstallSettings.InlineBuilds"/></em></p>
        ///   <p>Verbosely print the output of the build steps of dependencies.</p>
        /// </summary>
        [Pure]
        public static T EnableInlineBuilds<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InlineBuilds = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnInstallSettings.InlineBuilds"/></em></p>
        ///   <p>Verbosely print the output of the build steps of dependencies.</p>
        /// </summary>
        [Pure]
        public static T DisableInlineBuilds<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InlineBuilds = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnInstallSettings.InlineBuilds"/></em></p>
        ///   <p>Verbosely print the output of the build steps of dependencies.</p>
        /// </summary>
        [Pure]
        public static T ToggleInlineBuilds<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InlineBuilds = !toolSettings.InlineBuilds;
            return toolSettings;
        }
        #endregion
        #region Mode
        /// <summary>
        ///   <p><em>Sets <see cref="YarnInstallSettings.Mode"/></em></p>
        ///   <p>If the <c>--mode=<mode></c> option is set, Yarn will change which artifacts are generated.</p>
        /// </summary>
        [Pure]
        public static T SetMode<T>(this T toolSettings, YarnInstallMode mode) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Mode = mode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnInstallSettings.Mode"/></em></p>
        ///   <p>If the <c>--mode=<mode></c> option is set, Yarn will change which artifacts are generated.</p>
        /// </summary>
        [Pure]
        public static T ResetMode<T>(this T toolSettings) where T : YarnInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Mode = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region YarnRunSettingsExtensions
    /// <summary>
    ///   Used within <see cref="YarnTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class YarnRunSettingsExtensions
    {
        #region Command
        /// <summary>
        ///   <p><em>Sets <see cref="YarnRunSettings.Command"/></em></p>
        ///   <p>The command to be executed.</p>
        /// </summary>
        [Pure]
        public static T SetCommand<T>(this T toolSettings, string command) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnRunSettings.Command"/></em></p>
        ///   <p>The command to be executed.</p>
        /// </summary>
        [Pure]
        public static T ResetCommand<T>(this T toolSettings) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = null;
            return toolSettings;
        }
        #endregion
        #region Arguments
        /// <summary>
        ///   <p><em>Sets <see cref="YarnRunSettings.Arguments"/> to a new list</em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T SetArguments<T>(this T toolSettings, params string[] arguments) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal = arguments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="YarnRunSettings.Arguments"/> to a new list</em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T SetArguments<T>(this T toolSettings, IEnumerable<string> arguments) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal = arguments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="YarnRunSettings.Arguments"/></em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T AddArguments<T>(this T toolSettings, params string[] arguments) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.AddRange(arguments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="YarnRunSettings.Arguments"/></em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T AddArguments<T>(this T toolSettings, IEnumerable<string> arguments) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.AddRange(arguments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="YarnRunSettings.Arguments"/></em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T ClearArguments<T>(this T toolSettings) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ArgumentsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="YarnRunSettings.Arguments"/></em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T RemoveArguments<T>(this T toolSettings, params string[] arguments) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(arguments);
            toolSettings.ArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="YarnRunSettings.Arguments"/></em></p>
        ///   <p>Arguments passed to the script.</p>
        /// </summary>
        [Pure]
        public static T RemoveArguments<T>(this T toolSettings, IEnumerable<string> arguments) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(arguments);
            toolSettings.ArgumentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region TopLevel
        /// <summary>
        ///   <p><em>Sets <see cref="YarnRunSettings.TopLevel"/></em></p>
        ///   <p>Check the root workspace for scripts and/or binaries instead of the current one.</p>
        /// </summary>
        [Pure]
        public static T SetTopLevel<T>(this T toolSettings, bool? topLevel) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TopLevel = topLevel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnRunSettings.TopLevel"/></em></p>
        ///   <p>Check the root workspace for scripts and/or binaries instead of the current one.</p>
        /// </summary>
        [Pure]
        public static T ResetTopLevel<T>(this T toolSettings) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TopLevel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnRunSettings.TopLevel"/></em></p>
        ///   <p>Check the root workspace for scripts and/or binaries instead of the current one.</p>
        /// </summary>
        [Pure]
        public static T EnableTopLevel<T>(this T toolSettings) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TopLevel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnRunSettings.TopLevel"/></em></p>
        ///   <p>Check the root workspace for scripts and/or binaries instead of the current one.</p>
        /// </summary>
        [Pure]
        public static T DisableTopLevel<T>(this T toolSettings) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TopLevel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnRunSettings.TopLevel"/></em></p>
        ///   <p>Check the root workspace for scripts and/or binaries instead of the current one.</p>
        /// </summary>
        [Pure]
        public static T ToggleTopLevel<T>(this T toolSettings) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TopLevel = !toolSettings.TopLevel;
            return toolSettings;
        }
        #endregion
        #region BinariesOnly
        /// <summary>
        ///   <p><em>Sets <see cref="YarnRunSettings.BinariesOnly"/></em></p>
        ///   <p>Ignore any user defined scripts and only check for binaries.</p>
        /// </summary>
        [Pure]
        public static T SetBinariesOnly<T>(this T toolSettings, bool? binariesOnly) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BinariesOnly = binariesOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnRunSettings.BinariesOnly"/></em></p>
        ///   <p>Ignore any user defined scripts and only check for binaries.</p>
        /// </summary>
        [Pure]
        public static T ResetBinariesOnly<T>(this T toolSettings) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BinariesOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnRunSettings.BinariesOnly"/></em></p>
        ///   <p>Ignore any user defined scripts and only check for binaries.</p>
        /// </summary>
        [Pure]
        public static T EnableBinariesOnly<T>(this T toolSettings) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BinariesOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnRunSettings.BinariesOnly"/></em></p>
        ///   <p>Ignore any user defined scripts and only check for binaries.</p>
        /// </summary>
        [Pure]
        public static T DisableBinariesOnly<T>(this T toolSettings) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BinariesOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnRunSettings.BinariesOnly"/></em></p>
        ///   <p>Ignore any user defined scripts and only check for binaries.</p>
        /// </summary>
        [Pure]
        public static T ToggleBinariesOnly<T>(this T toolSettings) where T : YarnRunSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BinariesOnly = !toolSettings.BinariesOnly;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region YarnGetConfigSettingsExtensions
    /// <summary>
    ///   Used within <see cref="YarnTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class YarnGetConfigSettingsExtensions
    {
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="YarnGetConfigSettings.Name"/></em></p>
        ///   <p>The name of the configuration setting.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnGetConfigSettings.Name"/></em></p>
        ///   <p>The name of the configuration setting.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="YarnGetConfigSettings.Json"/></em></p>
        ///   <p>Format the output as an NDJSON stream.</p>
        /// </summary>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnGetConfigSettings.Json"/></em></p>
        ///   <p>Format the output as an NDJSON stream.</p>
        /// </summary>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnGetConfigSettings.Json"/></em></p>
        ///   <p>Format the output as an NDJSON stream.</p>
        /// </summary>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnGetConfigSettings.Json"/></em></p>
        ///   <p>Format the output as an NDJSON stream.</p>
        /// </summary>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnGetConfigSettings.Json"/></em></p>
        ///   <p>Format the output as an NDJSON stream.</p>
        /// </summary>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region NoRedacted
        /// <summary>
        ///   <p><em>Sets <see cref="YarnGetConfigSettings.NoRedacted"/></em></p>
        ///   <p>Don't redact secrets (such as tokens) from the output.</p>
        /// </summary>
        [Pure]
        public static T SetNoRedacted<T>(this T toolSettings, bool? noRedacted) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRedacted = noRedacted;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnGetConfigSettings.NoRedacted"/></em></p>
        ///   <p>Don't redact secrets (such as tokens) from the output.</p>
        /// </summary>
        [Pure]
        public static T ResetNoRedacted<T>(this T toolSettings) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRedacted = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnGetConfigSettings.NoRedacted"/></em></p>
        ///   <p>Don't redact secrets (such as tokens) from the output.</p>
        /// </summary>
        [Pure]
        public static T EnableNoRedacted<T>(this T toolSettings) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRedacted = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnGetConfigSettings.NoRedacted"/></em></p>
        ///   <p>Don't redact secrets (such as tokens) from the output.</p>
        /// </summary>
        [Pure]
        public static T DisableNoRedacted<T>(this T toolSettings) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRedacted = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnGetConfigSettings.NoRedacted"/></em></p>
        ///   <p>Don't redact secrets (such as tokens) from the output.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoRedacted<T>(this T toolSettings) where T : YarnGetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRedacted = !toolSettings.NoRedacted;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region YarnSetConfigSettingsExtensions
    /// <summary>
    ///   Used within <see cref="YarnTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class YarnSetConfigSettingsExtensions
    {
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="YarnSetConfigSettings.Name"/></em></p>
        ///   <p>The name of the configuration setting.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnSetConfigSettings.Name"/></em></p>
        ///   <p>The name of the configuration setting.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="YarnSetConfigSettings.Json"/></em></p>
        ///   <p>Set complex configuration settings to JSON values.</p>
        /// </summary>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnSetConfigSettings.Json"/></em></p>
        ///   <p>Set complex configuration settings to JSON values.</p>
        /// </summary>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnSetConfigSettings.Json"/></em></p>
        ///   <p>Set complex configuration settings to JSON values.</p>
        /// </summary>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnSetConfigSettings.Json"/></em></p>
        ///   <p>Set complex configuration settings to JSON values.</p>
        /// </summary>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnSetConfigSettings.Json"/></em></p>
        ///   <p>Set complex configuration settings to JSON values.</p>
        /// </summary>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Value
        /// <summary>
        ///   <p><em>Sets <see cref="YarnSetConfigSettings.Value"/></em></p>
        ///   <p>The value of the configuration setting.</p>
        /// </summary>
        [Pure]
        public static T SetValue<T>(this T toolSettings, string value) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Value = value;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnSetConfigSettings.Value"/></em></p>
        ///   <p>The value of the configuration setting.</p>
        /// </summary>
        [Pure]
        public static T ResetValue<T>(this T toolSettings) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Value = null;
            return toolSettings;
        }
        #endregion
        #region Home
        /// <summary>
        ///   <p><em>Sets <see cref="YarnSetConfigSettings.Home"/></em></p>
        ///   <p>Update the home configuration instead of the project configuration.</p>
        /// </summary>
        [Pure]
        public static T SetHome<T>(this T toolSettings, bool? home) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Home = home;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YarnSetConfigSettings.Home"/></em></p>
        ///   <p>Update the home configuration instead of the project configuration.</p>
        /// </summary>
        [Pure]
        public static T ResetHome<T>(this T toolSettings) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Home = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YarnSetConfigSettings.Home"/></em></p>
        ///   <p>Update the home configuration instead of the project configuration.</p>
        /// </summary>
        [Pure]
        public static T EnableHome<T>(this T toolSettings) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Home = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YarnSetConfigSettings.Home"/></em></p>
        ///   <p>Update the home configuration instead of the project configuration.</p>
        /// </summary>
        [Pure]
        public static T DisableHome<T>(this T toolSettings) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Home = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YarnSetConfigSettings.Home"/></em></p>
        ///   <p>Update the home configuration instead of the project configuration.</p>
        /// </summary>
        [Pure]
        public static T ToggleHome<T>(this T toolSettings) where T : YarnSetConfigSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Home = !toolSettings.Home;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region YarnInstallMode
    /// <summary>
    ///   Used within <see cref="YarnTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<YarnInstallMode>))]
    public partial class YarnInstallMode : Enumeration
    {
        public static YarnInstallMode skip_build = (YarnInstallMode) "skip-build";
        public static YarnInstallMode update_lockfile = (YarnInstallMode) "update-lockfile";
        public static implicit operator YarnInstallMode(string value)
        {
            return new YarnInstallMode { Value = value };
        }
    }
    #endregion
}

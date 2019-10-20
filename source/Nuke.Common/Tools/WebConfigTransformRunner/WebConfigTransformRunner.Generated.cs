// Generated from https://github.com/nuke-build/common/blob/master/build/specifications/WebConfigTransformRunner.json

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

namespace Nuke.Common.Tools.WebConfigTransformRunner
{
    /// <summary>
    ///   <p>This is a commandline tool to run an ASP.Net web.config tranformation.</p>
    ///   <p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WebConfigTransformRunnerTasks
    {
        /// <summary>
        ///   Path to the WebConfigTransformRunner executable.
        /// </summary>
        public static string WebConfigTransformRunnerPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("WEBCONFIGTRANSFORMRUNNER_EXE") ??
            ToolPathResolver.GetPackageExecutable("WebConfigTransformRunner", "WebConfigTransformRunner.exe");
        public static Action<OutputType, string> WebConfigTransformRunnerLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>This is a commandline tool to run an ASP.Net web.config tranformation.</p>
        ///   <p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> WebConfigTransformRunner(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(WebConfigTransformRunnerPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, WebConfigTransformRunnerLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This is a commandline tool to run an ASP.Net web.config tranformation.</p>
        ///   <p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;outputFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.OutputFilename"/></li>
        ///     <li><c>&lt;transformFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.TransformFilename"/></li>
        ///     <li><c>&lt;webConfigFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.WebConfigFilename"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WebConfigTransformRunner(WebConfigTransformRunnerSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new WebConfigTransformRunnerSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This is a commandline tool to run an ASP.Net web.config tranformation.</p>
        ///   <p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;outputFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.OutputFilename"/></li>
        ///     <li><c>&lt;transformFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.TransformFilename"/></li>
        ///     <li><c>&lt;webConfigFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.WebConfigFilename"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> WebConfigTransformRunner(Configure<WebConfigTransformRunnerSettings> configurator)
        {
            return WebConfigTransformRunner(configurator(new WebConfigTransformRunnerSettings()));
        }
        /// <summary>
        ///   <p>This is a commandline tool to run an ASP.Net web.config tranformation.</p>
        ///   <p>For more details, visit the <a href="https://github.com/erichexter/WebConfigTransformRunner">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;outputFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.OutputFilename"/></li>
        ///     <li><c>&lt;transformFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.TransformFilename"/></li>
        ///     <li><c>&lt;webConfigFilename&gt;</c> via <see cref="WebConfigTransformRunnerSettings.WebConfigFilename"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(WebConfigTransformRunnerSettings Settings, IReadOnlyCollection<Output> Output)> WebConfigTransformRunner(CombinatorialConfigure<WebConfigTransformRunnerSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(WebConfigTransformRunner, WebConfigTransformRunnerLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region WebConfigTransformRunnerSettings
    /// <summary>
    ///   Used within <see cref="WebConfigTransformRunnerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class WebConfigTransformRunnerSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the WebConfigTransformRunner executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? WebConfigTransformRunnerTasks.WebConfigTransformRunnerPath;
        public override Action<OutputType, string> CustomLogger => WebConfigTransformRunnerTasks.WebConfigTransformRunnerLogger;
        /// <summary>
        ///   The base web.config file
        /// </summary>
        public virtual string WebConfigFilename { get; internal set; }
        /// <summary>
        ///   The transformation web.config file
        /// </summary>
        public virtual string TransformFilename { get; internal set; }
        /// <summary>
        ///   The path to the output web.config file
        /// </summary>
        public virtual string OutputFilename { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", WebConfigFilename)
              .Add("{value}", TransformFilename)
              .Add("{value}", OutputFilename);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region WebConfigTransformRunnerSettingsExtensions
    /// <summary>
    ///   Used within <see cref="WebConfigTransformRunnerTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class WebConfigTransformRunnerSettingsExtensions
    {
        #region WebConfigFilename
        /// <summary>
        ///   <p><em>Sets <see cref="WebConfigTransformRunnerSettings.WebConfigFilename"/></em></p>
        ///   <p>The base web.config file</p>
        /// </summary>
        [Pure]
        public static WebConfigTransformRunnerSettings SetWebConfigFilename(this WebConfigTransformRunnerSettings toolSettings, string webConfigFilename)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WebConfigFilename = webConfigFilename;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WebConfigTransformRunnerSettings.WebConfigFilename"/></em></p>
        ///   <p>The base web.config file</p>
        /// </summary>
        [Pure]
        public static WebConfigTransformRunnerSettings ResetWebConfigFilename(this WebConfigTransformRunnerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WebConfigFilename = null;
            return toolSettings;
        }
        #endregion
        #region TransformFilename
        /// <summary>
        ///   <p><em>Sets <see cref="WebConfigTransformRunnerSettings.TransformFilename"/></em></p>
        ///   <p>The transformation web.config file</p>
        /// </summary>
        [Pure]
        public static WebConfigTransformRunnerSettings SetTransformFilename(this WebConfigTransformRunnerSettings toolSettings, string transformFilename)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TransformFilename = transformFilename;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WebConfigTransformRunnerSettings.TransformFilename"/></em></p>
        ///   <p>The transformation web.config file</p>
        /// </summary>
        [Pure]
        public static WebConfigTransformRunnerSettings ResetTransformFilename(this WebConfigTransformRunnerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TransformFilename = null;
            return toolSettings;
        }
        #endregion
        #region OutputFilename
        /// <summary>
        ///   <p><em>Sets <see cref="WebConfigTransformRunnerSettings.OutputFilename"/></em></p>
        ///   <p>The path to the output web.config file</p>
        /// </summary>
        [Pure]
        public static WebConfigTransformRunnerSettings SetOutputFilename(this WebConfigTransformRunnerSettings toolSettings, string outputFilename)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFilename = outputFilename;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="WebConfigTransformRunnerSettings.OutputFilename"/></em></p>
        ///   <p>The path to the output web.config file</p>
        /// </summary>
        [Pure]
        public static WebConfigTransformRunnerSettings ResetOutputFilename(this WebConfigTransformRunnerSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFilename = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}

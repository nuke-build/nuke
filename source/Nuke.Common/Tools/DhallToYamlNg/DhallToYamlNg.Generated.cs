// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/DhallToYamlNg/DhallToYamlNg.json

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

namespace Nuke.Common.Tools.DhallToYamlNg
{
    /// <summary>
    ///   <p>Dhall is a programmable configuration language that you can think of as: JSON + functions + types + imports</p>
    ///   <p>For more details, visit the <a href="https://dhall-lang.org/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DhallToYamlNgTasks
    {
        /// <summary>
        ///   Path to the DhallToYamlNg executable.
        /// </summary>
        public static string DhallToYamlNgPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("DHALLTOYAMLNG_EXE") ??
            ToolPathResolver.GetPathExecutable("dhall-to-yaml-ng");
        public static Action<OutputType, string> DhallToYamlNgLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Dhall is a programmable configuration language that you can think of as: JSON + functions + types + imports</p>
        ///   <p>For more details, visit the <a href="https://dhall-lang.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DhallToYamlNg(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(DhallToYamlNgPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, DhallToYamlNgLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Dhall is a programmable configuration language that you can think of as: JSON + functions + types + imports</p>
        ///   <p>For more details, visit the <a href="https://dhall-lang.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--documents</c> via <see cref="DhallToYamlNgSettings.Documents"/></li>
        ///     <li><c>--explain</c> via <see cref="DhallToYamlNgSettings.Explain"/></li>
        ///     <li><c>--file</c> via <see cref="DhallToYamlNgSettings.File"/></li>
        ///     <li><c>--generated-comment</c> via <see cref="DhallToYamlNgSettings.GeneratedComment"/></li>
        ///     <li><c>--key</c> via <see cref="DhallToYamlNgSettings.Key"/></li>
        ///     <li><c>--no-maps</c> via <see cref="DhallToYamlNgSettings.NoMaps"/></li>
        ///     <li><c>--omit-empty</c> via <see cref="DhallToYamlNgSettings.OmitEmpty"/></li>
        ///     <li><c>--output</c> via <see cref="DhallToYamlNgSettings.Output"/></li>
        ///     <li><c>--preserve-null</c> via <see cref="DhallToYamlNgSettings.PreserveNull"/></li>
        ///     <li><c>--quoted</c> via <see cref="DhallToYamlNgSettings.Quoted"/></li>
        ///     <li><c>--value</c> via <see cref="DhallToYamlNgSettings.Value"/></li>
        ///     <li><c>--version</c> via <see cref="DhallToYamlNgSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DhallToYamlNg(DhallToYamlNgSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DhallToYamlNgSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Dhall is a programmable configuration language that you can think of as: JSON + functions + types + imports</p>
        ///   <p>For more details, visit the <a href="https://dhall-lang.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--documents</c> via <see cref="DhallToYamlNgSettings.Documents"/></li>
        ///     <li><c>--explain</c> via <see cref="DhallToYamlNgSettings.Explain"/></li>
        ///     <li><c>--file</c> via <see cref="DhallToYamlNgSettings.File"/></li>
        ///     <li><c>--generated-comment</c> via <see cref="DhallToYamlNgSettings.GeneratedComment"/></li>
        ///     <li><c>--key</c> via <see cref="DhallToYamlNgSettings.Key"/></li>
        ///     <li><c>--no-maps</c> via <see cref="DhallToYamlNgSettings.NoMaps"/></li>
        ///     <li><c>--omit-empty</c> via <see cref="DhallToYamlNgSettings.OmitEmpty"/></li>
        ///     <li><c>--output</c> via <see cref="DhallToYamlNgSettings.Output"/></li>
        ///     <li><c>--preserve-null</c> via <see cref="DhallToYamlNgSettings.PreserveNull"/></li>
        ///     <li><c>--quoted</c> via <see cref="DhallToYamlNgSettings.Quoted"/></li>
        ///     <li><c>--value</c> via <see cref="DhallToYamlNgSettings.Value"/></li>
        ///     <li><c>--version</c> via <see cref="DhallToYamlNgSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DhallToYamlNg(Configure<DhallToYamlNgSettings> configurator)
        {
            return DhallToYamlNg(configurator(new DhallToYamlNgSettings()));
        }
        /// <summary>
        ///   <p>Dhall is a programmable configuration language that you can think of as: JSON + functions + types + imports</p>
        ///   <p>For more details, visit the <a href="https://dhall-lang.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--documents</c> via <see cref="DhallToYamlNgSettings.Documents"/></li>
        ///     <li><c>--explain</c> via <see cref="DhallToYamlNgSettings.Explain"/></li>
        ///     <li><c>--file</c> via <see cref="DhallToYamlNgSettings.File"/></li>
        ///     <li><c>--generated-comment</c> via <see cref="DhallToYamlNgSettings.GeneratedComment"/></li>
        ///     <li><c>--key</c> via <see cref="DhallToYamlNgSettings.Key"/></li>
        ///     <li><c>--no-maps</c> via <see cref="DhallToYamlNgSettings.NoMaps"/></li>
        ///     <li><c>--omit-empty</c> via <see cref="DhallToYamlNgSettings.OmitEmpty"/></li>
        ///     <li><c>--output</c> via <see cref="DhallToYamlNgSettings.Output"/></li>
        ///     <li><c>--preserve-null</c> via <see cref="DhallToYamlNgSettings.PreserveNull"/></li>
        ///     <li><c>--quoted</c> via <see cref="DhallToYamlNgSettings.Quoted"/></li>
        ///     <li><c>--value</c> via <see cref="DhallToYamlNgSettings.Value"/></li>
        ///     <li><c>--version</c> via <see cref="DhallToYamlNgSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DhallToYamlNgSettings Settings, IReadOnlyCollection<Output> Output)> DhallToYamlNg(CombinatorialConfigure<DhallToYamlNgSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DhallToYamlNg, DhallToYamlNgLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region DhallToYamlNgSettings
    /// <summary>
    ///   Used within <see cref="DhallToYamlNgTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DhallToYamlNgSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DhallToYamlNg executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? DhallToYamlNgTasks.DhallToYamlNgPath;
        public override Action<OutputType, string> ProcessCustomLogger => DhallToYamlNgTasks.DhallToYamlNgLogger;
        /// <summary>
        ///   Explain error messages in detail
        /// </summary>
        public virtual bool? Explain { get; internal set; }
        /// <summary>
        ///   Omit record fields that are null or empty records
        /// </summary>
        public virtual bool? OmitEmpty { get; internal set; }
        /// <summary>
        ///   Preserve record fields that are null
        /// </summary>
        public virtual bool? PreserveNull { get; internal set; }
        /// <summary>
        ///   If given a Dhall list, output a document for every element. Each document, including the first one, will be preceded by "---", even if there is only one document. If not given a list, output a single document (as if it were a list of one element)
        /// </summary>
        public virtual string Documents { get; internal set; }
        /// <summary>
        ///   Prevent from generating not quoted scalars
        /// </summary>
        public virtual bool? Quoted { get; internal set; }
        /// <summary>
        ///   Reserved key field name for association lists
        /// </summary>
        public virtual string Key { get; internal set; }
        /// <summary>
        ///   Reserved value field name for association lists
        /// </summary>
        public virtual string Value { get; internal set; }
        /// <summary>
        ///   Disable conversion of association lists to homogeneous maps
        /// </summary>
        public virtual bool? NoMaps { get; internal set; }
        /// <summary>
        ///   Read expression from a file instead of standard input
        /// </summary>
        public virtual string File { get; internal set; }
        /// <summary>
        ///   Write YAML to a file instead of standard output
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   Include a comment header warning not to edit thegenerated file
        /// </summary>
        public virtual bool? GeneratedComment { get; internal set; }
        /// <summary>
        ///   Display version
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("--explain", Explain)
              .Add("--omit-empty", OmitEmpty)
              .Add("--preserve-null", PreserveNull)
              .Add("--documents {value}", Documents)
              .Add("--quoted", Quoted)
              .Add("--key {value}", Key)
              .Add("--value {value}", Value)
              .Add("--no-maps", NoMaps)
              .Add("--file {value}", File)
              .Add("--output {value}", Output)
              .Add("--generated-comment", GeneratedComment)
              .Add("--version", Version);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region DhallToYamlNgSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DhallToYamlNgTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DhallToYamlNgSettingsExtensions
    {
        #region Explain
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.Explain"/></em></p>
        ///   <p>Explain error messages in detail</p>
        /// </summary>
        [Pure]
        public static T SetExplain<T>(this T toolSettings, bool? explain) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Explain = explain;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.Explain"/></em></p>
        ///   <p>Explain error messages in detail</p>
        /// </summary>
        [Pure]
        public static T ResetExplain<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Explain = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DhallToYamlNgSettings.Explain"/></em></p>
        ///   <p>Explain error messages in detail</p>
        /// </summary>
        [Pure]
        public static T EnableExplain<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Explain = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DhallToYamlNgSettings.Explain"/></em></p>
        ///   <p>Explain error messages in detail</p>
        /// </summary>
        [Pure]
        public static T DisableExplain<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Explain = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DhallToYamlNgSettings.Explain"/></em></p>
        ///   <p>Explain error messages in detail</p>
        /// </summary>
        [Pure]
        public static T ToggleExplain<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Explain = !toolSettings.Explain;
            return toolSettings;
        }
        #endregion
        #region OmitEmpty
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.OmitEmpty"/></em></p>
        ///   <p>Omit record fields that are null or empty records</p>
        /// </summary>
        [Pure]
        public static T SetOmitEmpty<T>(this T toolSettings, bool? omitEmpty) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OmitEmpty = omitEmpty;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.OmitEmpty"/></em></p>
        ///   <p>Omit record fields that are null or empty records</p>
        /// </summary>
        [Pure]
        public static T ResetOmitEmpty<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OmitEmpty = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DhallToYamlNgSettings.OmitEmpty"/></em></p>
        ///   <p>Omit record fields that are null or empty records</p>
        /// </summary>
        [Pure]
        public static T EnableOmitEmpty<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OmitEmpty = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DhallToYamlNgSettings.OmitEmpty"/></em></p>
        ///   <p>Omit record fields that are null or empty records</p>
        /// </summary>
        [Pure]
        public static T DisableOmitEmpty<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OmitEmpty = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DhallToYamlNgSettings.OmitEmpty"/></em></p>
        ///   <p>Omit record fields that are null or empty records</p>
        /// </summary>
        [Pure]
        public static T ToggleOmitEmpty<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OmitEmpty = !toolSettings.OmitEmpty;
            return toolSettings;
        }
        #endregion
        #region PreserveNull
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.PreserveNull"/></em></p>
        ///   <p>Preserve record fields that are null</p>
        /// </summary>
        [Pure]
        public static T SetPreserveNull<T>(this T toolSettings, bool? preserveNull) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreserveNull = preserveNull;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.PreserveNull"/></em></p>
        ///   <p>Preserve record fields that are null</p>
        /// </summary>
        [Pure]
        public static T ResetPreserveNull<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreserveNull = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DhallToYamlNgSettings.PreserveNull"/></em></p>
        ///   <p>Preserve record fields that are null</p>
        /// </summary>
        [Pure]
        public static T EnablePreserveNull<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreserveNull = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DhallToYamlNgSettings.PreserveNull"/></em></p>
        ///   <p>Preserve record fields that are null</p>
        /// </summary>
        [Pure]
        public static T DisablePreserveNull<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreserveNull = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DhallToYamlNgSettings.PreserveNull"/></em></p>
        ///   <p>Preserve record fields that are null</p>
        /// </summary>
        [Pure]
        public static T TogglePreserveNull<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreserveNull = !toolSettings.PreserveNull;
            return toolSettings;
        }
        #endregion
        #region Documents
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.Documents"/></em></p>
        ///   <p>If given a Dhall list, output a document for every element. Each document, including the first one, will be preceded by "---", even if there is only one document. If not given a list, output a single document (as if it were a list of one element)</p>
        /// </summary>
        [Pure]
        public static T SetDocuments<T>(this T toolSettings, string documents) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Documents = documents;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.Documents"/></em></p>
        ///   <p>If given a Dhall list, output a document for every element. Each document, including the first one, will be preceded by "---", even if there is only one document. If not given a list, output a single document (as if it were a list of one element)</p>
        /// </summary>
        [Pure]
        public static T ResetDocuments<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Documents = null;
            return toolSettings;
        }
        #endregion
        #region Quoted
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.Quoted"/></em></p>
        ///   <p>Prevent from generating not quoted scalars</p>
        /// </summary>
        [Pure]
        public static T SetQuoted<T>(this T toolSettings, bool? quoted) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quoted = quoted;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.Quoted"/></em></p>
        ///   <p>Prevent from generating not quoted scalars</p>
        /// </summary>
        [Pure]
        public static T ResetQuoted<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quoted = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DhallToYamlNgSettings.Quoted"/></em></p>
        ///   <p>Prevent from generating not quoted scalars</p>
        /// </summary>
        [Pure]
        public static T EnableQuoted<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quoted = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DhallToYamlNgSettings.Quoted"/></em></p>
        ///   <p>Prevent from generating not quoted scalars</p>
        /// </summary>
        [Pure]
        public static T DisableQuoted<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quoted = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DhallToYamlNgSettings.Quoted"/></em></p>
        ///   <p>Prevent from generating not quoted scalars</p>
        /// </summary>
        [Pure]
        public static T ToggleQuoted<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quoted = !toolSettings.Quoted;
            return toolSettings;
        }
        #endregion
        #region Key
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.Key"/></em></p>
        ///   <p>Reserved key field name for association lists</p>
        /// </summary>
        [Pure]
        public static T SetKey<T>(this T toolSettings, string key) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Key = key;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.Key"/></em></p>
        ///   <p>Reserved key field name for association lists</p>
        /// </summary>
        [Pure]
        public static T ResetKey<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Key = null;
            return toolSettings;
        }
        #endregion
        #region Value
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.Value"/></em></p>
        ///   <p>Reserved value field name for association lists</p>
        /// </summary>
        [Pure]
        public static T SetValue<T>(this T toolSettings, string value) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Value = value;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.Value"/></em></p>
        ///   <p>Reserved value field name for association lists</p>
        /// </summary>
        [Pure]
        public static T ResetValue<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Value = null;
            return toolSettings;
        }
        #endregion
        #region NoMaps
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.NoMaps"/></em></p>
        ///   <p>Disable conversion of association lists to homogeneous maps</p>
        /// </summary>
        [Pure]
        public static T SetNoMaps<T>(this T toolSettings, bool? noMaps) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoMaps = noMaps;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.NoMaps"/></em></p>
        ///   <p>Disable conversion of association lists to homogeneous maps</p>
        /// </summary>
        [Pure]
        public static T ResetNoMaps<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoMaps = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DhallToYamlNgSettings.NoMaps"/></em></p>
        ///   <p>Disable conversion of association lists to homogeneous maps</p>
        /// </summary>
        [Pure]
        public static T EnableNoMaps<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoMaps = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DhallToYamlNgSettings.NoMaps"/></em></p>
        ///   <p>Disable conversion of association lists to homogeneous maps</p>
        /// </summary>
        [Pure]
        public static T DisableNoMaps<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoMaps = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DhallToYamlNgSettings.NoMaps"/></em></p>
        ///   <p>Disable conversion of association lists to homogeneous maps</p>
        /// </summary>
        [Pure]
        public static T ToggleNoMaps<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoMaps = !toolSettings.NoMaps;
            return toolSettings;
        }
        #endregion
        #region File
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.File"/></em></p>
        ///   <p>Read expression from a file instead of standard input</p>
        /// </summary>
        [Pure]
        public static T SetFile<T>(this T toolSettings, string file) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.File"/></em></p>
        ///   <p>Read expression from a file instead of standard input</p>
        /// </summary>
        [Pure]
        public static T ResetFile<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.Output"/></em></p>
        ///   <p>Write YAML to a file instead of standard output</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.Output"/></em></p>
        ///   <p>Write YAML to a file instead of standard output</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region GeneratedComment
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.GeneratedComment"/></em></p>
        ///   <p>Include a comment header warning not to edit thegenerated file</p>
        /// </summary>
        [Pure]
        public static T SetGeneratedComment<T>(this T toolSettings, bool? generatedComment) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratedComment = generatedComment;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.GeneratedComment"/></em></p>
        ///   <p>Include a comment header warning not to edit thegenerated file</p>
        /// </summary>
        [Pure]
        public static T ResetGeneratedComment<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratedComment = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DhallToYamlNgSettings.GeneratedComment"/></em></p>
        ///   <p>Include a comment header warning not to edit thegenerated file</p>
        /// </summary>
        [Pure]
        public static T EnableGeneratedComment<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratedComment = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DhallToYamlNgSettings.GeneratedComment"/></em></p>
        ///   <p>Include a comment header warning not to edit thegenerated file</p>
        /// </summary>
        [Pure]
        public static T DisableGeneratedComment<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratedComment = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DhallToYamlNgSettings.GeneratedComment"/></em></p>
        ///   <p>Include a comment header warning not to edit thegenerated file</p>
        /// </summary>
        [Pure]
        public static T ToggleGeneratedComment<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GeneratedComment = !toolSettings.GeneratedComment;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="DhallToYamlNgSettings.Version"/></em></p>
        ///   <p>Display version</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DhallToYamlNgSettings.Version"/></em></p>
        ///   <p>Display version</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DhallToYamlNgSettings.Version"/></em></p>
        ///   <p>Display version</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DhallToYamlNgSettings.Version"/></em></p>
        ///   <p>Display version</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DhallToYamlNgSettings.Version"/></em></p>
        ///   <p>Display version</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : DhallToYamlNgSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}

// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/YamlToDhall/YamlToDhall.json

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

namespace Nuke.Common.Tools.YamlToDhall
{
    /// <summary>
    ///   <p>Convert a YAML expression to a Dhall expression, given the expected Dhall type</p>
    ///   <p>For more details, visit the <a href="https://dhall-lang.org/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class YamlToDhallTasks
    {
        /// <summary>
        ///   Path to the YamlToDhall executable.
        /// </summary>
        public static string YamlToDhallPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("YAMLTODHALL_EXE") ??
            ToolPathResolver.GetPathExecutable("yaml-to-dhall");
        public static Action<OutputType, string> YamlToDhallLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Convert a YAML expression to a Dhall expression, given the expected Dhall type</p>
        ///   <p>For more details, visit the <a href="https://dhall-lang.org/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> YamlToDhall(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(YamlToDhallPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, YamlToDhallLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Convert a YAML expression to a Dhall expression, given the expected Dhall type</p>
        ///   <p>For more details, visit the <a href="https://dhall-lang.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;schema&gt;</c> via <see cref="YamlToDhallSettings.Schema"/></li>
        ///     <li><c>--ascii</c> via <see cref="YamlToDhallSettings.ASCII"/></li>
        ///     <li><c>--file</c> via <see cref="YamlToDhallSettings.File"/></li>
        ///     <li><c>--no-keyval-arrays</c> via <see cref="YamlToDhallSettings.NoKeyValArrays"/></li>
        ///     <li><c>--no-keyval-maps</c> via <see cref="YamlToDhallSettings.NoKeyValMaps"/></li>
        ///     <li><c>--omissible-lists</c> via <see cref="YamlToDhallSettings.OmissibleLists"/></li>
        ///     <li><c>--output</c> via <see cref="YamlToDhallSettings.Output"/></li>
        ///     <li><c>--records-loose</c> via <see cref="YamlToDhallSettings.RecordsLoose"/></li>
        ///     <li><c>--records-strict</c> via <see cref="YamlToDhallSettings.RecordsStrict"/></li>
        ///     <li><c>--unions-first</c> via <see cref="YamlToDhallSettings.UnionsFirst"/></li>
        ///     <li><c>--unions-none</c> via <see cref="YamlToDhallSettings.UnionsNone"/></li>
        ///     <li><c>--unions-strict</c> via <see cref="YamlToDhallSettings.UnionsStrict"/></li>
        ///     <li><c>--version</c> via <see cref="YamlToDhallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> YamlToDhall(YamlToDhallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new YamlToDhallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Convert a YAML expression to a Dhall expression, given the expected Dhall type</p>
        ///   <p>For more details, visit the <a href="https://dhall-lang.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;schema&gt;</c> via <see cref="YamlToDhallSettings.Schema"/></li>
        ///     <li><c>--ascii</c> via <see cref="YamlToDhallSettings.ASCII"/></li>
        ///     <li><c>--file</c> via <see cref="YamlToDhallSettings.File"/></li>
        ///     <li><c>--no-keyval-arrays</c> via <see cref="YamlToDhallSettings.NoKeyValArrays"/></li>
        ///     <li><c>--no-keyval-maps</c> via <see cref="YamlToDhallSettings.NoKeyValMaps"/></li>
        ///     <li><c>--omissible-lists</c> via <see cref="YamlToDhallSettings.OmissibleLists"/></li>
        ///     <li><c>--output</c> via <see cref="YamlToDhallSettings.Output"/></li>
        ///     <li><c>--records-loose</c> via <see cref="YamlToDhallSettings.RecordsLoose"/></li>
        ///     <li><c>--records-strict</c> via <see cref="YamlToDhallSettings.RecordsStrict"/></li>
        ///     <li><c>--unions-first</c> via <see cref="YamlToDhallSettings.UnionsFirst"/></li>
        ///     <li><c>--unions-none</c> via <see cref="YamlToDhallSettings.UnionsNone"/></li>
        ///     <li><c>--unions-strict</c> via <see cref="YamlToDhallSettings.UnionsStrict"/></li>
        ///     <li><c>--version</c> via <see cref="YamlToDhallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> YamlToDhall(Configure<YamlToDhallSettings> configurator)
        {
            return YamlToDhall(configurator(new YamlToDhallSettings()));
        }
        /// <summary>
        ///   <p>Convert a YAML expression to a Dhall expression, given the expected Dhall type</p>
        ///   <p>For more details, visit the <a href="https://dhall-lang.org/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;schema&gt;</c> via <see cref="YamlToDhallSettings.Schema"/></li>
        ///     <li><c>--ascii</c> via <see cref="YamlToDhallSettings.ASCII"/></li>
        ///     <li><c>--file</c> via <see cref="YamlToDhallSettings.File"/></li>
        ///     <li><c>--no-keyval-arrays</c> via <see cref="YamlToDhallSettings.NoKeyValArrays"/></li>
        ///     <li><c>--no-keyval-maps</c> via <see cref="YamlToDhallSettings.NoKeyValMaps"/></li>
        ///     <li><c>--omissible-lists</c> via <see cref="YamlToDhallSettings.OmissibleLists"/></li>
        ///     <li><c>--output</c> via <see cref="YamlToDhallSettings.Output"/></li>
        ///     <li><c>--records-loose</c> via <see cref="YamlToDhallSettings.RecordsLoose"/></li>
        ///     <li><c>--records-strict</c> via <see cref="YamlToDhallSettings.RecordsStrict"/></li>
        ///     <li><c>--unions-first</c> via <see cref="YamlToDhallSettings.UnionsFirst"/></li>
        ///     <li><c>--unions-none</c> via <see cref="YamlToDhallSettings.UnionsNone"/></li>
        ///     <li><c>--unions-strict</c> via <see cref="YamlToDhallSettings.UnionsStrict"/></li>
        ///     <li><c>--version</c> via <see cref="YamlToDhallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(YamlToDhallSettings Settings, IReadOnlyCollection<Output> Output)> YamlToDhall(CombinatorialConfigure<YamlToDhallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(YamlToDhall, YamlToDhallLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region YamlToDhallSettings
    /// <summary>
    ///   Used within <see cref="YamlToDhallTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class YamlToDhallSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the YamlToDhall executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? YamlToDhallTasks.YamlToDhallPath;
        public override Action<OutputType, string> ProcessCustomLogger => YamlToDhallTasks.YamlToDhallLogger;
        /// <summary>
        ///   Dhall type expression (schema)
        /// </summary>
        public virtual string Schema { get; internal set; }
        /// <summary>
        ///   Fail if any YAML fields are missing from the expected Dhall type
        /// </summary>
        public virtual bool? RecordsStrict { get; internal set; }
        /// <summary>
        ///   Tolerate JSON fields not present within the expected Dhall type
        /// </summary>
        public virtual bool? RecordsLoose { get; internal set; }
        /// <summary>
        ///   Disable conversion of key-value arrays to records
        /// </summary>
        public virtual bool? NoKeyValArrays { get; internal set; }
        /// <summary>
        ///   Disable conversion of homogeneous map objects to association lists
        /// </summary>
        public virtual bool? NoKeyValMaps { get; internal set; }
        /// <summary>
        ///   The first value with the matching type (successfully parsed all the way down the tree) is accepted, even if not the only possible match
        /// </summary>
        public virtual bool? UnionsFirst { get; internal set; }
        /// <summary>
        ///   Unions not allowed
        /// </summary>
        public virtual bool? UnionsNone { get; internal set; }
        /// <summary>
        ///   Error if more than one union values match the type (and parse successfully)
        /// </summary>
        public virtual bool? UnionsStrict { get; internal set; }
        /// <summary>
        ///   Tolerate missing list values, they are assumed empty
        /// </summary>
        public virtual bool? OmissibleLists { get; internal set; }
        /// <summary>
        ///   Read YAML expression from a file instead of standard input
        /// </summary>
        public virtual string File { get; internal set; }
        /// <summary>
        ///   Write Dhall expression to a file instead of standard output
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   Format code using only ASCII syntax
        /// </summary>
        public virtual bool? ASCII { get; internal set; }
        /// <summary>
        ///   Display version
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", Schema)
              .Add("--records-strict", RecordsStrict)
              .Add("--records-loose", RecordsLoose)
              .Add("--no-keyval-arrays", NoKeyValArrays)
              .Add("--no-keyval-maps", NoKeyValMaps)
              .Add("--unions-first", UnionsFirst)
              .Add("--unions-none", UnionsNone)
              .Add("--unions-strict", UnionsStrict)
              .Add("--omissible-lists", OmissibleLists)
              .Add("--file {value}", File)
              .Add("--output {value}", Output)
              .Add("--ascii", ASCII)
              .Add("--version", Version);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region YamlToDhallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="YamlToDhallTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class YamlToDhallSettingsExtensions
    {
        #region Schema
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.Schema"/></em></p>
        ///   <p>Dhall type expression (schema)</p>
        /// </summary>
        [Pure]
        public static T SetSchema<T>(this T toolSettings, string schema) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Schema = schema;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.Schema"/></em></p>
        ///   <p>Dhall type expression (schema)</p>
        /// </summary>
        [Pure]
        public static T ResetSchema<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Schema = null;
            return toolSettings;
        }
        #endregion
        #region RecordsStrict
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.RecordsStrict"/></em></p>
        ///   <p>Fail if any YAML fields are missing from the expected Dhall type</p>
        /// </summary>
        [Pure]
        public static T SetRecordsStrict<T>(this T toolSettings, bool? recordsStrict) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecordsStrict = recordsStrict;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.RecordsStrict"/></em></p>
        ///   <p>Fail if any YAML fields are missing from the expected Dhall type</p>
        /// </summary>
        [Pure]
        public static T ResetRecordsStrict<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecordsStrict = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YamlToDhallSettings.RecordsStrict"/></em></p>
        ///   <p>Fail if any YAML fields are missing from the expected Dhall type</p>
        /// </summary>
        [Pure]
        public static T EnableRecordsStrict<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecordsStrict = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YamlToDhallSettings.RecordsStrict"/></em></p>
        ///   <p>Fail if any YAML fields are missing from the expected Dhall type</p>
        /// </summary>
        [Pure]
        public static T DisableRecordsStrict<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecordsStrict = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YamlToDhallSettings.RecordsStrict"/></em></p>
        ///   <p>Fail if any YAML fields are missing from the expected Dhall type</p>
        /// </summary>
        [Pure]
        public static T ToggleRecordsStrict<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecordsStrict = !toolSettings.RecordsStrict;
            return toolSettings;
        }
        #endregion
        #region RecordsLoose
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.RecordsLoose"/></em></p>
        ///   <p>Tolerate JSON fields not present within the expected Dhall type</p>
        /// </summary>
        [Pure]
        public static T SetRecordsLoose<T>(this T toolSettings, bool? recordsLoose) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecordsLoose = recordsLoose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.RecordsLoose"/></em></p>
        ///   <p>Tolerate JSON fields not present within the expected Dhall type</p>
        /// </summary>
        [Pure]
        public static T ResetRecordsLoose<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecordsLoose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YamlToDhallSettings.RecordsLoose"/></em></p>
        ///   <p>Tolerate JSON fields not present within the expected Dhall type</p>
        /// </summary>
        [Pure]
        public static T EnableRecordsLoose<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecordsLoose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YamlToDhallSettings.RecordsLoose"/></em></p>
        ///   <p>Tolerate JSON fields not present within the expected Dhall type</p>
        /// </summary>
        [Pure]
        public static T DisableRecordsLoose<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecordsLoose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YamlToDhallSettings.RecordsLoose"/></em></p>
        ///   <p>Tolerate JSON fields not present within the expected Dhall type</p>
        /// </summary>
        [Pure]
        public static T ToggleRecordsLoose<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecordsLoose = !toolSettings.RecordsLoose;
            return toolSettings;
        }
        #endregion
        #region NoKeyValArrays
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.NoKeyValArrays"/></em></p>
        ///   <p>Disable conversion of key-value arrays to records</p>
        /// </summary>
        [Pure]
        public static T SetNoKeyValArrays<T>(this T toolSettings, bool? noKeyValArrays) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoKeyValArrays = noKeyValArrays;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.NoKeyValArrays"/></em></p>
        ///   <p>Disable conversion of key-value arrays to records</p>
        /// </summary>
        [Pure]
        public static T ResetNoKeyValArrays<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoKeyValArrays = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YamlToDhallSettings.NoKeyValArrays"/></em></p>
        ///   <p>Disable conversion of key-value arrays to records</p>
        /// </summary>
        [Pure]
        public static T EnableNoKeyValArrays<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoKeyValArrays = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YamlToDhallSettings.NoKeyValArrays"/></em></p>
        ///   <p>Disable conversion of key-value arrays to records</p>
        /// </summary>
        [Pure]
        public static T DisableNoKeyValArrays<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoKeyValArrays = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YamlToDhallSettings.NoKeyValArrays"/></em></p>
        ///   <p>Disable conversion of key-value arrays to records</p>
        /// </summary>
        [Pure]
        public static T ToggleNoKeyValArrays<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoKeyValArrays = !toolSettings.NoKeyValArrays;
            return toolSettings;
        }
        #endregion
        #region NoKeyValMaps
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.NoKeyValMaps"/></em></p>
        ///   <p>Disable conversion of homogeneous map objects to association lists</p>
        /// </summary>
        [Pure]
        public static T SetNoKeyValMaps<T>(this T toolSettings, bool? noKeyValMaps) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoKeyValMaps = noKeyValMaps;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.NoKeyValMaps"/></em></p>
        ///   <p>Disable conversion of homogeneous map objects to association lists</p>
        /// </summary>
        [Pure]
        public static T ResetNoKeyValMaps<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoKeyValMaps = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YamlToDhallSettings.NoKeyValMaps"/></em></p>
        ///   <p>Disable conversion of homogeneous map objects to association lists</p>
        /// </summary>
        [Pure]
        public static T EnableNoKeyValMaps<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoKeyValMaps = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YamlToDhallSettings.NoKeyValMaps"/></em></p>
        ///   <p>Disable conversion of homogeneous map objects to association lists</p>
        /// </summary>
        [Pure]
        public static T DisableNoKeyValMaps<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoKeyValMaps = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YamlToDhallSettings.NoKeyValMaps"/></em></p>
        ///   <p>Disable conversion of homogeneous map objects to association lists</p>
        /// </summary>
        [Pure]
        public static T ToggleNoKeyValMaps<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoKeyValMaps = !toolSettings.NoKeyValMaps;
            return toolSettings;
        }
        #endregion
        #region UnionsFirst
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.UnionsFirst"/></em></p>
        ///   <p>The first value with the matching type (successfully parsed all the way down the tree) is accepted, even if not the only possible match</p>
        /// </summary>
        [Pure]
        public static T SetUnionsFirst<T>(this T toolSettings, bool? unionsFirst) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsFirst = unionsFirst;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.UnionsFirst"/></em></p>
        ///   <p>The first value with the matching type (successfully parsed all the way down the tree) is accepted, even if not the only possible match</p>
        /// </summary>
        [Pure]
        public static T ResetUnionsFirst<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsFirst = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YamlToDhallSettings.UnionsFirst"/></em></p>
        ///   <p>The first value with the matching type (successfully parsed all the way down the tree) is accepted, even if not the only possible match</p>
        /// </summary>
        [Pure]
        public static T EnableUnionsFirst<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsFirst = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YamlToDhallSettings.UnionsFirst"/></em></p>
        ///   <p>The first value with the matching type (successfully parsed all the way down the tree) is accepted, even if not the only possible match</p>
        /// </summary>
        [Pure]
        public static T DisableUnionsFirst<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsFirst = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YamlToDhallSettings.UnionsFirst"/></em></p>
        ///   <p>The first value with the matching type (successfully parsed all the way down the tree) is accepted, even if not the only possible match</p>
        /// </summary>
        [Pure]
        public static T ToggleUnionsFirst<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsFirst = !toolSettings.UnionsFirst;
            return toolSettings;
        }
        #endregion
        #region UnionsNone
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.UnionsNone"/></em></p>
        ///   <p>Unions not allowed</p>
        /// </summary>
        [Pure]
        public static T SetUnionsNone<T>(this T toolSettings, bool? unionsNone) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsNone = unionsNone;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.UnionsNone"/></em></p>
        ///   <p>Unions not allowed</p>
        /// </summary>
        [Pure]
        public static T ResetUnionsNone<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsNone = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YamlToDhallSettings.UnionsNone"/></em></p>
        ///   <p>Unions not allowed</p>
        /// </summary>
        [Pure]
        public static T EnableUnionsNone<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsNone = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YamlToDhallSettings.UnionsNone"/></em></p>
        ///   <p>Unions not allowed</p>
        /// </summary>
        [Pure]
        public static T DisableUnionsNone<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsNone = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YamlToDhallSettings.UnionsNone"/></em></p>
        ///   <p>Unions not allowed</p>
        /// </summary>
        [Pure]
        public static T ToggleUnionsNone<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsNone = !toolSettings.UnionsNone;
            return toolSettings;
        }
        #endregion
        #region UnionsStrict
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.UnionsStrict"/></em></p>
        ///   <p>Error if more than one union values match the type (and parse successfully)</p>
        /// </summary>
        [Pure]
        public static T SetUnionsStrict<T>(this T toolSettings, bool? unionsStrict) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsStrict = unionsStrict;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.UnionsStrict"/></em></p>
        ///   <p>Error if more than one union values match the type (and parse successfully)</p>
        /// </summary>
        [Pure]
        public static T ResetUnionsStrict<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsStrict = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YamlToDhallSettings.UnionsStrict"/></em></p>
        ///   <p>Error if more than one union values match the type (and parse successfully)</p>
        /// </summary>
        [Pure]
        public static T EnableUnionsStrict<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsStrict = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YamlToDhallSettings.UnionsStrict"/></em></p>
        ///   <p>Error if more than one union values match the type (and parse successfully)</p>
        /// </summary>
        [Pure]
        public static T DisableUnionsStrict<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsStrict = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YamlToDhallSettings.UnionsStrict"/></em></p>
        ///   <p>Error if more than one union values match the type (and parse successfully)</p>
        /// </summary>
        [Pure]
        public static T ToggleUnionsStrict<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UnionsStrict = !toolSettings.UnionsStrict;
            return toolSettings;
        }
        #endregion
        #region OmissibleLists
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.OmissibleLists"/></em></p>
        ///   <p>Tolerate missing list values, they are assumed empty</p>
        /// </summary>
        [Pure]
        public static T SetOmissibleLists<T>(this T toolSettings, bool? omissibleLists) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OmissibleLists = omissibleLists;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.OmissibleLists"/></em></p>
        ///   <p>Tolerate missing list values, they are assumed empty</p>
        /// </summary>
        [Pure]
        public static T ResetOmissibleLists<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OmissibleLists = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YamlToDhallSettings.OmissibleLists"/></em></p>
        ///   <p>Tolerate missing list values, they are assumed empty</p>
        /// </summary>
        [Pure]
        public static T EnableOmissibleLists<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OmissibleLists = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YamlToDhallSettings.OmissibleLists"/></em></p>
        ///   <p>Tolerate missing list values, they are assumed empty</p>
        /// </summary>
        [Pure]
        public static T DisableOmissibleLists<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OmissibleLists = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YamlToDhallSettings.OmissibleLists"/></em></p>
        ///   <p>Tolerate missing list values, they are assumed empty</p>
        /// </summary>
        [Pure]
        public static T ToggleOmissibleLists<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OmissibleLists = !toolSettings.OmissibleLists;
            return toolSettings;
        }
        #endregion
        #region File
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.File"/></em></p>
        ///   <p>Read YAML expression from a file instead of standard input</p>
        /// </summary>
        [Pure]
        public static T SetFile<T>(this T toolSettings, string file) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = file;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.File"/></em></p>
        ///   <p>Read YAML expression from a file instead of standard input</p>
        /// </summary>
        [Pure]
        public static T ResetFile<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.File = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.Output"/></em></p>
        ///   <p>Write Dhall expression to a file instead of standard output</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.Output"/></em></p>
        ///   <p>Write Dhall expression to a file instead of standard output</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region ASCII
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.ASCII"/></em></p>
        ///   <p>Format code using only ASCII syntax</p>
        /// </summary>
        [Pure]
        public static T SetASCII<T>(this T toolSettings, bool? ascii) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ASCII = ascii;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.ASCII"/></em></p>
        ///   <p>Format code using only ASCII syntax</p>
        /// </summary>
        [Pure]
        public static T ResetASCII<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ASCII = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YamlToDhallSettings.ASCII"/></em></p>
        ///   <p>Format code using only ASCII syntax</p>
        /// </summary>
        [Pure]
        public static T EnableASCII<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ASCII = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YamlToDhallSettings.ASCII"/></em></p>
        ///   <p>Format code using only ASCII syntax</p>
        /// </summary>
        [Pure]
        public static T DisableASCII<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ASCII = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YamlToDhallSettings.ASCII"/></em></p>
        ///   <p>Format code using only ASCII syntax</p>
        /// </summary>
        [Pure]
        public static T ToggleASCII<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ASCII = !toolSettings.ASCII;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="YamlToDhallSettings.Version"/></em></p>
        ///   <p>Display version</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="YamlToDhallSettings.Version"/></em></p>
        ///   <p>Display version</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="YamlToDhallSettings.Version"/></em></p>
        ///   <p>Display version</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="YamlToDhallSettings.Version"/></em></p>
        ///   <p>Display version</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="YamlToDhallSettings.Version"/></em></p>
        ///   <p>Display version</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : YamlToDhallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}

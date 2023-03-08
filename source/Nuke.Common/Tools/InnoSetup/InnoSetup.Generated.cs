// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/InnoSetup/InnoSetup.json

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

namespace Nuke.Common.Tools.InnoSetup
{
    /// <summary>
    ///   <p>Inno Setup is a free installer for Windows programs by Jordan Russell and Martijn Laan. First introduced in 1997, Inno Setup today rivals and even surpasses many commercial installers in feature set and stability.</p>
    ///   <p>For more details, visit the <a href="http://www.jrsoftware.org/isinfo.php">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [PathToolRequirement(InnoSetupPathExecutable)]
    public partial class InnoSetupTasks
        : IRequirePathTool
    {
        public const string InnoSetupPathExecutable = "iscc";
        /// <summary>
        ///   Path to the InnoSetup executable.
        /// </summary>
        public static string InnoSetupPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("INNOSETUP_EXE") ??
            ToolPathResolver.GetPathExecutable("iscc");
        public static Action<OutputType, string> InnoSetupLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Inno Setup is a free installer for Windows programs by Jordan Russell and Martijn Laan. First introduced in 1997, Inno Setup today rivals and even surpasses many commercial installers in feature set and stability.</p>
        ///   <p>For more details, visit the <a href="http://www.jrsoftware.org/isinfo.php">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> InnoSetup(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(InnoSetupPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? InnoSetupLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Inno Setup is a free installer for Windows programs by Jordan Russell and Martijn Laan. First introduced in 1997, Inno Setup today rivals and even surpasses many commercial installers in feature set and stability.</p>
        ///   <p>For more details, visit the <a href="http://www.jrsoftware.org/isinfo.php">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;scriptFile&gt;</c> via <see cref="InnoSetupSettings.ScriptFile"/></li>
        ///     <li><c>/D</c> via <see cref="InnoSetupSettings.KeyValueDefinitions"/></li>
        ///     <li><c>/D</c> via <see cref="InnoSetupSettings.KeyDefinitions"/></li>
        ///     <li><c>/F</c> via <see cref="InnoSetupSettings.OutputBaseFilename"/></li>
        ///     <li><c>/O</c> via <see cref="InnoSetupSettings.Output"/></li>
        ///     <li><c>/O</c> via <see cref="InnoSetupSettings.OutputDir"/></li>
        ///     <li><c>/Q</c> via <see cref="InnoSetupSettings.Quiet"/></li>
        ///     <li><c>/Qp</c> via <see cref="InnoSetupSettings.QuietWithProgress"/></li>
        ///     <li><c>/S</c> via <see cref="InnoSetupSettings.SignTools"/></li>
        ///     <li><c>/V</c> via <see cref="InnoSetupSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> InnoSetup(InnoSetupSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new InnoSetupSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Inno Setup is a free installer for Windows programs by Jordan Russell and Martijn Laan. First introduced in 1997, Inno Setup today rivals and even surpasses many commercial installers in feature set and stability.</p>
        ///   <p>For more details, visit the <a href="http://www.jrsoftware.org/isinfo.php">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;scriptFile&gt;</c> via <see cref="InnoSetupSettings.ScriptFile"/></li>
        ///     <li><c>/D</c> via <see cref="InnoSetupSettings.KeyValueDefinitions"/></li>
        ///     <li><c>/D</c> via <see cref="InnoSetupSettings.KeyDefinitions"/></li>
        ///     <li><c>/F</c> via <see cref="InnoSetupSettings.OutputBaseFilename"/></li>
        ///     <li><c>/O</c> via <see cref="InnoSetupSettings.Output"/></li>
        ///     <li><c>/O</c> via <see cref="InnoSetupSettings.OutputDir"/></li>
        ///     <li><c>/Q</c> via <see cref="InnoSetupSettings.Quiet"/></li>
        ///     <li><c>/Qp</c> via <see cref="InnoSetupSettings.QuietWithProgress"/></li>
        ///     <li><c>/S</c> via <see cref="InnoSetupSettings.SignTools"/></li>
        ///     <li><c>/V</c> via <see cref="InnoSetupSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> InnoSetup(Configure<InnoSetupSettings> configurator)
        {
            return InnoSetup(configurator(new InnoSetupSettings()));
        }
        /// <summary>
        ///   <p>Inno Setup is a free installer for Windows programs by Jordan Russell and Martijn Laan. First introduced in 1997, Inno Setup today rivals and even surpasses many commercial installers in feature set and stability.</p>
        ///   <p>For more details, visit the <a href="http://www.jrsoftware.org/isinfo.php">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;scriptFile&gt;</c> via <see cref="InnoSetupSettings.ScriptFile"/></li>
        ///     <li><c>/D</c> via <see cref="InnoSetupSettings.KeyValueDefinitions"/></li>
        ///     <li><c>/D</c> via <see cref="InnoSetupSettings.KeyDefinitions"/></li>
        ///     <li><c>/F</c> via <see cref="InnoSetupSettings.OutputBaseFilename"/></li>
        ///     <li><c>/O</c> via <see cref="InnoSetupSettings.Output"/></li>
        ///     <li><c>/O</c> via <see cref="InnoSetupSettings.OutputDir"/></li>
        ///     <li><c>/Q</c> via <see cref="InnoSetupSettings.Quiet"/></li>
        ///     <li><c>/Qp</c> via <see cref="InnoSetupSettings.QuietWithProgress"/></li>
        ///     <li><c>/S</c> via <see cref="InnoSetupSettings.SignTools"/></li>
        ///     <li><c>/V</c> via <see cref="InnoSetupSettings.Verbosity"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(InnoSetupSettings Settings, IReadOnlyCollection<Output> Output)> InnoSetup(CombinatorialConfigure<InnoSetupSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(InnoSetup, InnoSetupLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region InnoSetupSettings
    /// <summary>
    ///   Used within <see cref="InnoSetupTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class InnoSetupSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the InnoSetup executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? InnoSetupTasks.InnoSetupPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? InnoSetupTasks.InnoSetupLogger;
        /// <summary>
        ///   The .iss script file to compile
        /// </summary>
        public virtual string ScriptFile { get; internal set; }
        /// <summary>
        ///   Enable or disable output (overrides <c>Output</c>)
        /// </summary>
        public virtual bool? Output { get; internal set; }
        /// <summary>
        ///   Output files to specified path (overrides <c>OutputDir</c>)
        /// </summary>
        public virtual string OutputDir { get; internal set; }
        /// <summary>
        ///   Overrides OutputBaseFilename with the specified filename
        /// </summary>
        public virtual string OutputBaseFilename { get; internal set; }
        /// <summary>
        ///   Sets a SignTool with the specified name and command
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> SignTools => SignToolsInternal.AsReadOnly();
        internal Dictionary<string, string> SignToolsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Quiet compile (print error messages only)
        /// </summary>
        public virtual bool? Quiet { get; internal set; }
        /// <summary>
        ///   Enable quiet compile while still displaying progress
        /// </summary>
        public virtual bool? QuietWithProgress { get; internal set; }
        /// <summary>
        ///   Emulate <c>#define public {name} {value}</c>
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> KeyValueDefinitions => KeyValueDefinitionsInternal.AsReadOnly();
        internal Dictionary<string, string> KeyValueDefinitionsInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Emulate <c>#define public {name}</c>
        /// </summary>
        public virtual IReadOnlyList<string> KeyDefinitions => KeyDefinitionsInternal.AsReadOnly();
        internal List<string> KeyDefinitionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Emulate <c>#pragma verboselevel {number}</c> (highest level is 9)
        /// </summary>
        public virtual int? Verbosity { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", ScriptFile)
              .Add("/O{value}", GetOutput(), customValue: true)
              .Add("/O{value}", OutputDir)
              .Add("/F{value}", OutputBaseFilename)
              .Add("/S{value}", SignTools, "{key}={value}")
              .Add("/Q", Quiet)
              .Add("/Qp", QuietWithProgress)
              .Add("/D{value}", KeyValueDefinitions, "{key}={value}")
              .Add("/D{value}", KeyDefinitions)
              .Add("/V{value}", Verbosity);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region InnoSetupSettingsExtensions
    /// <summary>
    ///   Used within <see cref="InnoSetupTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class InnoSetupSettingsExtensions
    {
        #region ScriptFile
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.ScriptFile"/></em></p>
        ///   <p>The .iss script file to compile</p>
        /// </summary>
        [Pure]
        public static T SetScriptFile<T>(this T toolSettings, string scriptFile) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScriptFile = scriptFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InnoSetupSettings.ScriptFile"/></em></p>
        ///   <p>The .iss script file to compile</p>
        /// </summary>
        [Pure]
        public static T ResetScriptFile<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ScriptFile = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.Output"/></em></p>
        ///   <p>Enable or disable output (overrides <c>Output</c>)</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, bool? output) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InnoSetupSettings.Output"/></em></p>
        ///   <p>Enable or disable output (overrides <c>Output</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="InnoSetupSettings.Output"/></em></p>
        ///   <p>Enable or disable output (overrides <c>Output</c>)</p>
        /// </summary>
        [Pure]
        public static T EnableOutput<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="InnoSetupSettings.Output"/></em></p>
        ///   <p>Enable or disable output (overrides <c>Output</c>)</p>
        /// </summary>
        [Pure]
        public static T DisableOutput<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="InnoSetupSettings.Output"/></em></p>
        ///   <p>Enable or disable output (overrides <c>Output</c>)</p>
        /// </summary>
        [Pure]
        public static T ToggleOutput<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = !toolSettings.Output;
            return toolSettings;
        }
        #endregion
        #region OutputDir
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.OutputDir"/></em></p>
        ///   <p>Output files to specified path (overrides <c>OutputDir</c>)</p>
        /// </summary>
        [Pure]
        public static T SetOutputDir<T>(this T toolSettings, string outputDir) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDir = outputDir;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InnoSetupSettings.OutputDir"/></em></p>
        ///   <p>Output files to specified path (overrides <c>OutputDir</c>)</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDir<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDir = null;
            return toolSettings;
        }
        #endregion
        #region OutputBaseFilename
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.OutputBaseFilename"/></em></p>
        ///   <p>Overrides OutputBaseFilename with the specified filename</p>
        /// </summary>
        [Pure]
        public static T SetOutputBaseFilename<T>(this T toolSettings, string outputBaseFilename) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputBaseFilename = outputBaseFilename;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InnoSetupSettings.OutputBaseFilename"/></em></p>
        ///   <p>Overrides OutputBaseFilename with the specified filename</p>
        /// </summary>
        [Pure]
        public static T ResetOutputBaseFilename<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputBaseFilename = null;
            return toolSettings;
        }
        #endregion
        #region SignTools
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.SignTools"/> to a new dictionary</em></p>
        ///   <p>Sets a SignTool with the specified name and command</p>
        /// </summary>
        [Pure]
        public static T SetSignTools<T>(this T toolSettings, IDictionary<string, string> signTools) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignToolsInternal = signTools.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="InnoSetupSettings.SignTools"/></em></p>
        ///   <p>Sets a SignTool with the specified name and command</p>
        /// </summary>
        [Pure]
        public static T ClearSignTools<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignToolsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="InnoSetupSettings.SignTools"/></em></p>
        ///   <p>Sets a SignTool with the specified name and command</p>
        /// </summary>
        [Pure]
        public static T AddSignTool<T>(this T toolSettings, string signToolKey, string signToolValue) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignToolsInternal.Add(signToolKey, signToolValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="InnoSetupSettings.SignTools"/></em></p>
        ///   <p>Sets a SignTool with the specified name and command</p>
        /// </summary>
        [Pure]
        public static T RemoveSignTool<T>(this T toolSettings, string signToolKey) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignToolsInternal.Remove(signToolKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="InnoSetupSettings.SignTools"/></em></p>
        ///   <p>Sets a SignTool with the specified name and command</p>
        /// </summary>
        [Pure]
        public static T SetSignTool<T>(this T toolSettings, string signToolKey, string signToolValue) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SignToolsInternal[signToolKey] = signToolValue;
            return toolSettings;
        }
        #endregion
        #region Quiet
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.Quiet"/></em></p>
        ///   <p>Quiet compile (print error messages only)</p>
        /// </summary>
        [Pure]
        public static T SetQuiet<T>(this T toolSettings, bool? quiet) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = quiet;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InnoSetupSettings.Quiet"/></em></p>
        ///   <p>Quiet compile (print error messages only)</p>
        /// </summary>
        [Pure]
        public static T ResetQuiet<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="InnoSetupSettings.Quiet"/></em></p>
        ///   <p>Quiet compile (print error messages only)</p>
        /// </summary>
        [Pure]
        public static T EnableQuiet<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="InnoSetupSettings.Quiet"/></em></p>
        ///   <p>Quiet compile (print error messages only)</p>
        /// </summary>
        [Pure]
        public static T DisableQuiet<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="InnoSetupSettings.Quiet"/></em></p>
        ///   <p>Quiet compile (print error messages only)</p>
        /// </summary>
        [Pure]
        public static T ToggleQuiet<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quiet = !toolSettings.Quiet;
            return toolSettings;
        }
        #endregion
        #region QuietWithProgress
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.QuietWithProgress"/></em></p>
        ///   <p>Enable quiet compile while still displaying progress</p>
        /// </summary>
        [Pure]
        public static T SetQuietWithProgress<T>(this T toolSettings, bool? quietWithProgress) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QuietWithProgress = quietWithProgress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InnoSetupSettings.QuietWithProgress"/></em></p>
        ///   <p>Enable quiet compile while still displaying progress</p>
        /// </summary>
        [Pure]
        public static T ResetQuietWithProgress<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QuietWithProgress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="InnoSetupSettings.QuietWithProgress"/></em></p>
        ///   <p>Enable quiet compile while still displaying progress</p>
        /// </summary>
        [Pure]
        public static T EnableQuietWithProgress<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QuietWithProgress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="InnoSetupSettings.QuietWithProgress"/></em></p>
        ///   <p>Enable quiet compile while still displaying progress</p>
        /// </summary>
        [Pure]
        public static T DisableQuietWithProgress<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QuietWithProgress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="InnoSetupSettings.QuietWithProgress"/></em></p>
        ///   <p>Enable quiet compile while still displaying progress</p>
        /// </summary>
        [Pure]
        public static T ToggleQuietWithProgress<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.QuietWithProgress = !toolSettings.QuietWithProgress;
            return toolSettings;
        }
        #endregion
        #region KeyValueDefinitions
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.KeyValueDefinitions"/> to a new dictionary</em></p>
        ///   <p>Emulate <c>#define public {name} {value}</c></p>
        /// </summary>
        [Pure]
        public static T SetKeyValueDefinitions<T>(this T toolSettings, IDictionary<string, string> keyValueDefinitions) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyValueDefinitionsInternal = keyValueDefinitions.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="InnoSetupSettings.KeyValueDefinitions"/></em></p>
        ///   <p>Emulate <c>#define public {name} {value}</c></p>
        /// </summary>
        [Pure]
        public static T ClearKeyValueDefinitions<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyValueDefinitionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="InnoSetupSettings.KeyValueDefinitions"/></em></p>
        ///   <p>Emulate <c>#define public {name} {value}</c></p>
        /// </summary>
        [Pure]
        public static T AddKeyValueDefinition<T>(this T toolSettings, string keyValueDefinitionKey, string keyValueDefinitionValue) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyValueDefinitionsInternal.Add(keyValueDefinitionKey, keyValueDefinitionValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="InnoSetupSettings.KeyValueDefinitions"/></em></p>
        ///   <p>Emulate <c>#define public {name} {value}</c></p>
        /// </summary>
        [Pure]
        public static T RemoveKeyValueDefinition<T>(this T toolSettings, string keyValueDefinitionKey) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyValueDefinitionsInternal.Remove(keyValueDefinitionKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="InnoSetupSettings.KeyValueDefinitions"/></em></p>
        ///   <p>Emulate <c>#define public {name} {value}</c></p>
        /// </summary>
        [Pure]
        public static T SetKeyValueDefinition<T>(this T toolSettings, string keyValueDefinitionKey, string keyValueDefinitionValue) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyValueDefinitionsInternal[keyValueDefinitionKey] = keyValueDefinitionValue;
            return toolSettings;
        }
        #endregion
        #region KeyDefinitions
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.KeyDefinitions"/> to a new list</em></p>
        ///   <p>Emulate <c>#define public {name}</c></p>
        /// </summary>
        [Pure]
        public static T SetKeyDefinitions<T>(this T toolSettings, params string[] keyDefinitions) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyDefinitionsInternal = keyDefinitions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.KeyDefinitions"/> to a new list</em></p>
        ///   <p>Emulate <c>#define public {name}</c></p>
        /// </summary>
        [Pure]
        public static T SetKeyDefinitions<T>(this T toolSettings, IEnumerable<string> keyDefinitions) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyDefinitionsInternal = keyDefinitions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="InnoSetupSettings.KeyDefinitions"/></em></p>
        ///   <p>Emulate <c>#define public {name}</c></p>
        /// </summary>
        [Pure]
        public static T AddKeyDefinitions<T>(this T toolSettings, params string[] keyDefinitions) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyDefinitionsInternal.AddRange(keyDefinitions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="InnoSetupSettings.KeyDefinitions"/></em></p>
        ///   <p>Emulate <c>#define public {name}</c></p>
        /// </summary>
        [Pure]
        public static T AddKeyDefinitions<T>(this T toolSettings, IEnumerable<string> keyDefinitions) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyDefinitionsInternal.AddRange(keyDefinitions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="InnoSetupSettings.KeyDefinitions"/></em></p>
        ///   <p>Emulate <c>#define public {name}</c></p>
        /// </summary>
        [Pure]
        public static T ClearKeyDefinitions<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyDefinitionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="InnoSetupSettings.KeyDefinitions"/></em></p>
        ///   <p>Emulate <c>#define public {name}</c></p>
        /// </summary>
        [Pure]
        public static T RemoveKeyDefinitions<T>(this T toolSettings, params string[] keyDefinitions) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(keyDefinitions);
            toolSettings.KeyDefinitionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="InnoSetupSettings.KeyDefinitions"/></em></p>
        ///   <p>Emulate <c>#define public {name}</c></p>
        /// </summary>
        [Pure]
        public static T RemoveKeyDefinitions<T>(this T toolSettings, IEnumerable<string> keyDefinitions) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(keyDefinitions);
            toolSettings.KeyDefinitionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verbosity
        /// <summary>
        ///   <p><em>Sets <see cref="InnoSetupSettings.Verbosity"/></em></p>
        ///   <p>Emulate <c>#pragma verboselevel {number}</c> (highest level is 9)</p>
        /// </summary>
        [Pure]
        public static T SetVerbosity<T>(this T toolSettings, int? verbosity) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = verbosity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="InnoSetupSettings.Verbosity"/></em></p>
        ///   <p>Emulate <c>#pragma verboselevel {number}</c> (highest level is 9)</p>
        /// </summary>
        [Pure]
        public static T ResetVerbosity<T>(this T toolSettings) where T : InnoSetupSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbosity = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}

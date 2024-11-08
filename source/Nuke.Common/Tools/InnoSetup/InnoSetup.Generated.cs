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

namespace Nuke.Common.Tools.InnoSetup;

/// <summary><p>Inno Setup is a free installer for Windows programs by Jordan Russell and Martijn Laan. First introduced in 1997, Inno Setup today rivals and even surpasses many commercial installers in feature set and stability.</p><p>For more details, visit the <a href="http://www.jrsoftware.org/isinfo.php">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathToolRequirement(PathExecutable)]
[PathTool(Executable = PathExecutable)]
public partial class InnoSetupTasks : ToolTasks, IRequirePathTool
{
    public static string InnoSetupPath => new InnoSetupTasks().GetToolPath();
    public const string PathExecutable = "iscc";
    /// <summary><p>Inno Setup is a free installer for Windows programs by Jordan Russell and Martijn Laan. First introduced in 1997, Inno Setup today rivals and even surpasses many commercial installers in feature set and stability.</p><p>For more details, visit the <a href="http://www.jrsoftware.org/isinfo.php">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> InnoSetup(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new InnoSetupTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Inno Setup is a free installer for Windows programs by Jordan Russell and Martijn Laan. First introduced in 1997, Inno Setup today rivals and even surpasses many commercial installers in feature set and stability.</p><p>For more details, visit the <a href="http://www.jrsoftware.org/isinfo.php">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;scriptFile&gt;</c> via <see cref="InnoSetupSettings.ScriptFile"/></li><li><c>/D</c> via <see cref="InnoSetupSettings.KeyValueDefinitions"/></li><li><c>/D</c> via <see cref="InnoSetupSettings.KeyDefinitions"/></li><li><c>/F</c> via <see cref="InnoSetupSettings.OutputBaseFilename"/></li><li><c>/O</c> via <see cref="InnoSetupSettings.Output"/></li><li><c>/O</c> via <see cref="InnoSetupSettings.OutputDir"/></li><li><c>/Q</c> via <see cref="InnoSetupSettings.Quiet"/></li><li><c>/Qp</c> via <see cref="InnoSetupSettings.QuietWithProgress"/></li><li><c>/S</c> via <see cref="InnoSetupSettings.SignTools"/></li><li><c>/V</c> via <see cref="InnoSetupSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> InnoSetup(InnoSetupSettings options = null) => new InnoSetupTasks().Run(options);
    /// <summary><p>Inno Setup is a free installer for Windows programs by Jordan Russell and Martijn Laan. First introduced in 1997, Inno Setup today rivals and even surpasses many commercial installers in feature set and stability.</p><p>For more details, visit the <a href="http://www.jrsoftware.org/isinfo.php">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;scriptFile&gt;</c> via <see cref="InnoSetupSettings.ScriptFile"/></li><li><c>/D</c> via <see cref="InnoSetupSettings.KeyValueDefinitions"/></li><li><c>/D</c> via <see cref="InnoSetupSettings.KeyDefinitions"/></li><li><c>/F</c> via <see cref="InnoSetupSettings.OutputBaseFilename"/></li><li><c>/O</c> via <see cref="InnoSetupSettings.Output"/></li><li><c>/O</c> via <see cref="InnoSetupSettings.OutputDir"/></li><li><c>/Q</c> via <see cref="InnoSetupSettings.Quiet"/></li><li><c>/Qp</c> via <see cref="InnoSetupSettings.QuietWithProgress"/></li><li><c>/S</c> via <see cref="InnoSetupSettings.SignTools"/></li><li><c>/V</c> via <see cref="InnoSetupSettings.Verbosity"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> InnoSetup(Configure<InnoSetupSettings> configurator) => new InnoSetupTasks().Run(configurator.Invoke(new InnoSetupSettings()));
    /// <summary><p>Inno Setup is a free installer for Windows programs by Jordan Russell and Martijn Laan. First introduced in 1997, Inno Setup today rivals and even surpasses many commercial installers in feature set and stability.</p><p>For more details, visit the <a href="http://www.jrsoftware.org/isinfo.php">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;scriptFile&gt;</c> via <see cref="InnoSetupSettings.ScriptFile"/></li><li><c>/D</c> via <see cref="InnoSetupSettings.KeyValueDefinitions"/></li><li><c>/D</c> via <see cref="InnoSetupSettings.KeyDefinitions"/></li><li><c>/F</c> via <see cref="InnoSetupSettings.OutputBaseFilename"/></li><li><c>/O</c> via <see cref="InnoSetupSettings.Output"/></li><li><c>/O</c> via <see cref="InnoSetupSettings.OutputDir"/></li><li><c>/Q</c> via <see cref="InnoSetupSettings.Quiet"/></li><li><c>/Qp</c> via <see cref="InnoSetupSettings.QuietWithProgress"/></li><li><c>/S</c> via <see cref="InnoSetupSettings.SignTools"/></li><li><c>/V</c> via <see cref="InnoSetupSettings.Verbosity"/></li></ul></remarks>
    public static IEnumerable<(InnoSetupSettings Settings, IReadOnlyCollection<Output> Output)> InnoSetup(CombinatorialConfigure<InnoSetupSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(InnoSetup, degreeOfParallelism, completeOnFailure);
}
#region InnoSetupSettings
/// <summary>Used within <see cref="InnoSetupTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<InnoSetupSettings>))]
[Command(Type = typeof(InnoSetupTasks), Command = nameof(InnoSetupTasks.InnoSetup))]
public partial class InnoSetupSettings : ToolOptions
{
    /// <summary>The .iss script file to compile</summary>
    [Argument(Format = "{value}", Position = 1)] public string ScriptFile => Get<string>(() => ScriptFile);
    /// <summary>Enable or disable output (overrides <c>Output</c>)</summary>
    [Argument(Format = "/O{value}")] public bool? Output => Get<bool?>(() => Output);
    /// <summary>Output files to specified path (overrides <c>OutputDir</c>)</summary>
    [Argument(Format = "/O{value}")] public string OutputDir => Get<string>(() => OutputDir);
    /// <summary>Overrides OutputBaseFilename with the specified filename</summary>
    [Argument(Format = "/F{value}")] public string OutputBaseFilename => Get<string>(() => OutputBaseFilename);
    /// <summary>Sets a SignTool with the specified name and command</summary>
    [Argument(Format = "/S{key}={value}")] public IReadOnlyDictionary<string, string> SignTools => Get<Dictionary<string, string>>(() => SignTools);
    /// <summary>Quiet compile (print error messages only)</summary>
    [Argument(Format = "/Q")] public bool? Quiet => Get<bool?>(() => Quiet);
    /// <summary>Enable quiet compile while still displaying progress</summary>
    [Argument(Format = "/Qp")] public bool? QuietWithProgress => Get<bool?>(() => QuietWithProgress);
    /// <summary>Emulate <c>#define public {name} {value}</c></summary>
    [Argument(Format = "/D{key}={value}", Secret = false)] public IReadOnlyDictionary<string, string> KeyValueDefinitions => Get<Dictionary<string, string>>(() => KeyValueDefinitions);
    /// <summary>Emulate <c>#define public {name}</c></summary>
    [Argument(Format = "/D{value}", Secret = false)] public IReadOnlyList<string> KeyDefinitions => Get<List<string>>(() => KeyDefinitions);
    /// <summary>Emulate <c>#pragma verboselevel {number}</c> (highest level is 9)</summary>
    [Argument(Format = "/V{value}")] public int? Verbosity => Get<int?>(() => Verbosity);
}
#endregion
#region InnoSetupSettingsExtensions
/// <summary>Used within <see cref="InnoSetupTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class InnoSetupSettingsExtensions
{
    #region ScriptFile
    /// <inheritdoc cref="InnoSetupSettings.ScriptFile"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.ScriptFile))]
    public static T SetScriptFile<T>(this T o, string v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.ScriptFile, v));
    /// <inheritdoc cref="InnoSetupSettings.ScriptFile"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.ScriptFile))]
    public static T ResetScriptFile<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Remove(() => o.ScriptFile));
    #endregion
    #region Output
    /// <inheritdoc cref="InnoSetupSettings.Output"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Output))]
    public static T SetOutput<T>(this T o, bool? v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="InnoSetupSettings.Output"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Remove(() => o.Output));
    /// <inheritdoc cref="InnoSetupSettings.Output"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Output))]
    public static T EnableOutput<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.Output, true));
    /// <inheritdoc cref="InnoSetupSettings.Output"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Output))]
    public static T DisableOutput<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.Output, false));
    /// <inheritdoc cref="InnoSetupSettings.Output"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Output))]
    public static T ToggleOutput<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.Output, !o.Output));
    #endregion
    #region OutputDir
    /// <inheritdoc cref="InnoSetupSettings.OutputDir"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.OutputDir))]
    public static T SetOutputDir<T>(this T o, string v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.OutputDir, v));
    /// <inheritdoc cref="InnoSetupSettings.OutputDir"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.OutputDir))]
    public static T ResetOutputDir<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Remove(() => o.OutputDir));
    #endregion
    #region OutputBaseFilename
    /// <inheritdoc cref="InnoSetupSettings.OutputBaseFilename"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.OutputBaseFilename))]
    public static T SetOutputBaseFilename<T>(this T o, string v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.OutputBaseFilename, v));
    /// <inheritdoc cref="InnoSetupSettings.OutputBaseFilename"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.OutputBaseFilename))]
    public static T ResetOutputBaseFilename<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Remove(() => o.OutputBaseFilename));
    #endregion
    #region SignTools
    /// <inheritdoc cref="InnoSetupSettings.SignTools"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.SignTools))]
    public static T SetSignTools<T>(this T o, IDictionary<string, string> v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.SignTools, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="InnoSetupSettings.SignTools"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.SignTools))]
    public static T SetSignTool<T>(this T o, string k, string v) where T : InnoSetupSettings => o.Modify(b => b.SetDictionary(() => o.SignTools, k, v));
    /// <inheritdoc cref="InnoSetupSettings.SignTools"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.SignTools))]
    public static T AddSignTool<T>(this T o, string k, string v) where T : InnoSetupSettings => o.Modify(b => b.AddDictionary(() => o.SignTools, k, v));
    /// <inheritdoc cref="InnoSetupSettings.SignTools"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.SignTools))]
    public static T RemoveSignTool<T>(this T o, string k) where T : InnoSetupSettings => o.Modify(b => b.RemoveDictionary(() => o.SignTools, k));
    /// <inheritdoc cref="InnoSetupSettings.SignTools"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.SignTools))]
    public static T ClearSignTools<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.ClearDictionary(() => o.SignTools));
    #endregion
    #region Quiet
    /// <inheritdoc cref="InnoSetupSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Quiet))]
    public static T SetQuiet<T>(this T o, bool? v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.Quiet, v));
    /// <inheritdoc cref="InnoSetupSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Quiet))]
    public static T ResetQuiet<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Remove(() => o.Quiet));
    /// <inheritdoc cref="InnoSetupSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Quiet))]
    public static T EnableQuiet<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.Quiet, true));
    /// <inheritdoc cref="InnoSetupSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Quiet))]
    public static T DisableQuiet<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.Quiet, false));
    /// <inheritdoc cref="InnoSetupSettings.Quiet"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Quiet))]
    public static T ToggleQuiet<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.Quiet, !o.Quiet));
    #endregion
    #region QuietWithProgress
    /// <inheritdoc cref="InnoSetupSettings.QuietWithProgress"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.QuietWithProgress))]
    public static T SetQuietWithProgress<T>(this T o, bool? v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.QuietWithProgress, v));
    /// <inheritdoc cref="InnoSetupSettings.QuietWithProgress"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.QuietWithProgress))]
    public static T ResetQuietWithProgress<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Remove(() => o.QuietWithProgress));
    /// <inheritdoc cref="InnoSetupSettings.QuietWithProgress"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.QuietWithProgress))]
    public static T EnableQuietWithProgress<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.QuietWithProgress, true));
    /// <inheritdoc cref="InnoSetupSettings.QuietWithProgress"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.QuietWithProgress))]
    public static T DisableQuietWithProgress<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.QuietWithProgress, false));
    /// <inheritdoc cref="InnoSetupSettings.QuietWithProgress"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.QuietWithProgress))]
    public static T ToggleQuietWithProgress<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.QuietWithProgress, !o.QuietWithProgress));
    #endregion
    #region KeyValueDefinitions
    /// <inheritdoc cref="InnoSetupSettings.KeyValueDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyValueDefinitions))]
    public static T SetKeyValueDefinitions<T>(this T o, IDictionary<string, string> v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.KeyValueDefinitions, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="InnoSetupSettings.KeyValueDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyValueDefinitions))]
    public static T SetKeyValueDefinition<T>(this T o, string k, string v) where T : InnoSetupSettings => o.Modify(b => b.SetDictionary(() => o.KeyValueDefinitions, k, v));
    /// <inheritdoc cref="InnoSetupSettings.KeyValueDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyValueDefinitions))]
    public static T AddKeyValueDefinition<T>(this T o, string k, string v) where T : InnoSetupSettings => o.Modify(b => b.AddDictionary(() => o.KeyValueDefinitions, k, v));
    /// <inheritdoc cref="InnoSetupSettings.KeyValueDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyValueDefinitions))]
    public static T RemoveKeyValueDefinition<T>(this T o, string k) where T : InnoSetupSettings => o.Modify(b => b.RemoveDictionary(() => o.KeyValueDefinitions, k));
    /// <inheritdoc cref="InnoSetupSettings.KeyValueDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyValueDefinitions))]
    public static T ClearKeyValueDefinitions<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.ClearDictionary(() => o.KeyValueDefinitions));
    #endregion
    #region KeyDefinitions
    /// <inheritdoc cref="InnoSetupSettings.KeyDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyDefinitions))]
    public static T SetKeyDefinitions<T>(this T o, params string[] v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.KeyDefinitions, v));
    /// <inheritdoc cref="InnoSetupSettings.KeyDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyDefinitions))]
    public static T SetKeyDefinitions<T>(this T o, IEnumerable<string> v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.KeyDefinitions, v));
    /// <inheritdoc cref="InnoSetupSettings.KeyDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyDefinitions))]
    public static T AddKeyDefinitions<T>(this T o, params string[] v) where T : InnoSetupSettings => o.Modify(b => b.AddCollection(() => o.KeyDefinitions, v));
    /// <inheritdoc cref="InnoSetupSettings.KeyDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyDefinitions))]
    public static T AddKeyDefinitions<T>(this T o, IEnumerable<string> v) where T : InnoSetupSettings => o.Modify(b => b.AddCollection(() => o.KeyDefinitions, v));
    /// <inheritdoc cref="InnoSetupSettings.KeyDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyDefinitions))]
    public static T RemoveKeyDefinitions<T>(this T o, params string[] v) where T : InnoSetupSettings => o.Modify(b => b.RemoveCollection(() => o.KeyDefinitions, v));
    /// <inheritdoc cref="InnoSetupSettings.KeyDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyDefinitions))]
    public static T RemoveKeyDefinitions<T>(this T o, IEnumerable<string> v) where T : InnoSetupSettings => o.Modify(b => b.RemoveCollection(() => o.KeyDefinitions, v));
    /// <inheritdoc cref="InnoSetupSettings.KeyDefinitions"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.KeyDefinitions))]
    public static T ClearKeyDefinitions<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.ClearCollection(() => o.KeyDefinitions));
    #endregion
    #region Verbosity
    /// <inheritdoc cref="InnoSetupSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Verbosity))]
    public static T SetVerbosity<T>(this T o, int? v) where T : InnoSetupSettings => o.Modify(b => b.Set(() => o.Verbosity, v));
    /// <inheritdoc cref="InnoSetupSettings.Verbosity"/>
    [Pure] [Builder(Type = typeof(InnoSetupSettings), Property = nameof(InnoSetupSettings.Verbosity))]
    public static T ResetVerbosity<T>(this T o) where T : InnoSetupSettings => o.Modify(b => b.Remove(() => o.Verbosity));
    #endregion
}
#endregion
